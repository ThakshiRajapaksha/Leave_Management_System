using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeApplication
{
    public partial class EmployeeForm : Form
    {
        private string employeeID;
        private DatabaseConnection db = new DatabaseConnection();

        public EmployeeForm(string empID)
        {
            InitializeComponent();
            employeeID = empID;
            this.Text = $"Employee Dashboard - {empID}";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Initialize UI
            ConfigureControls();
            LoadLeaveBalances();
            LoadLeaveHistory();
            
        }

        private void ConfigureControls()
        {
            // Configure DataGridView columns
            dgvLeaveHistory.Columns.Clear();
            dgvLeaveHistory.Columns.Add("RequestID", "Request ID");
            dgvLeaveHistory.Columns.Add("LeaveType", "Leave Type");
            dgvLeaveHistory.Columns.Add("StartDate", "Start Date");
            dgvLeaveHistory.Columns.Add("EndDate", "End Date");
            dgvLeaveHistory.Columns.Add("TimeSlot", "Time Slot");
            dgvLeaveHistory.Columns.Add("Status", "Status");
            dgvLeaveHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Enable/disable TimeSlot based on LeaveType
            cmbLeaveType.SelectedIndexChanged += (s, e) =>
            {
                bool isShortLeave = cmbLeaveType.SelectedItem?.ToString() == "Short";
                lblTimeSlot.Enabled = isShortLeave;
                cmbTimeSlot.Enabled = isShortLeave;
                lblEndDate.Enabled = !isShortLeave;
                dtpEndDate.Enabled = !isShortLeave;
            };
            cmbLeaveType.SelectedIndex = 0; // Default to Annual
        }

        private void LoadLeaveBalances()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT AnnualLeaves, CasualLeaves, ShortLeaves FROM LeaveBalances WHERE EmployeeID = @id AND Year = @year";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    cmd.Parameters.AddWithValue("@year", DateTime.Now.Year);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblAnnualLeaves.Text = $"Annual Leaves: {reader["AnnualLeaves"]}";
                        lblCasualLeaves.Text = $"Casual Leaves: {reader["CasualLeaves"]}";
                        lblShortLeaves.Text = $"Short Leaves: {reader["ShortLeaves"]}";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading leave balances: {ex.Message}");
            }
        }

        private void LoadLeaveHistory()
        {
            try
            {
                DataTable dt = db.GetEmployeeLeaveHistory(employeeID, DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1));
                dgvLeaveHistory.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvLeaveHistory.Rows.Add(
                        row["RequestID"], // Add RequestID for deletion
                        row["LeaveType"],
                        ((DateTime)row["StartDate"]).ToShortDateString(),
                        ((DateTime)row["EndDate"]).ToShortDateString(),
                        row["TimeSlot"]?.ToString(),
                        row["Status"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading leave history: {ex.Message}");
            }
        }

        private void btnApplyLeave_Click(object sender, EventArgs e)
        {
            string leaveType = cmbLeaveType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(leaveType))
            {
                MessageBox.Show("Please select a leave type.");
                System.Diagnostics.Debug.WriteLine("Validation failed: Leave type is empty.");
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            string timeSlot = leaveType == "Short" ? cmbTimeSlot.SelectedItem?.ToString() : "";

            if (leaveType == "Short" && string.IsNullOrEmpty(timeSlot))
            {
                MessageBox.Show("Please select a time slot for short leave.");
                System.Diagnostics.Debug.WriteLine("Validation failed: Time slot is empty for short leave.");
                return;
            }

            if (leaveType != "Short" && endDate < startDate)
            {
                MessageBox.Show("End date must be on or after start date.");
                System.Diagnostics.Debug.WriteLine("Validation failed: End date is before start date.");
                return;
            }

            // Calculate the number of days for the leave request
            int days = 0;
            if (leaveType == "Annual" || leaveType == "Casual")
            {
                days = (endDate - startDate).Days + 1;
            }
            else if (leaveType == "Short")
            {
                days = 1; // Short leave counts as 1 "day" for balance purposes
            }

            // Check leave balance before applying
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string balanceQuery = "SELECT AnnualLeaves, CasualLeaves, ShortLeaves FROM LeaveBalances " +
                                        "WHERE EmployeeID = @id AND Year = @year";
                    SqlCommand balanceCmd = new SqlCommand(balanceQuery, conn);
                    balanceCmd.Parameters.AddWithValue("@id", employeeID);
                    balanceCmd.Parameters.AddWithValue("@year", DateTime.Now.Year);
                    SqlDataReader reader = balanceCmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        reader.Close();
                        MessageBox.Show("Leave balance not found. Please contact the admin.");
                        return;
                    }

                    int currentBalance = 0;
                    if (leaveType == "Annual")
                    {
                        currentBalance = (int)reader["AnnualLeaves"];
                    }
                    else if (leaveType == "Casual")
                    {
                        currentBalance = (int)reader["CasualLeaves"];
                    }
                    else if (leaveType == "Short")
                    {
                        currentBalance = (int)reader["ShortLeaves"];
                    }
                    reader.Close();

                    if (currentBalance < days)
                    {
                        MessageBox.Show($"Insufficient {leaveType} leave balance. Available: {currentBalance}, Required: {days}");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking leave balance: {ex.Message}");
                return;
            }

            if (leaveType == "Annual" && startDate < DateTime.Now.AddDays(7))
            {
                MessageBox.Show("Annual leaves must be applied at least 7 days prior to the leave date.");
                System.Diagnostics.Debug.WriteLine("Validation failed: Annual leave not applied 7 days prior.");
                return;
            }

            if (leaveType == "Casual")
            {
                DateTime? rosterStartTime = GetRosterStartTime(startDate);
                if (rosterStartTime.HasValue && DateTime.Now > rosterStartTime.Value)
                {
                    MessageBox.Show("Casual leaves must be applied before your roster starts.");
                    System.Diagnostics.Debug.WriteLine("Validation failed: Casual leave applied after roster start.");
                    return;
                }
            }

            if (leaveType == "Short")
            {
                try
                {
                    string[] timeParts = timeSlot.Split('-');
                    DateTime slotStartTime = DateTime.Parse($"{startDate.ToShortDateString()} {timeParts[0]}");
                    DateTime slotEndTime = DateTime.Parse($"{startDate.ToShortDateString()} {timeParts[1]}");
                    TimeSpan duration = slotEndTime - slotStartTime;

                    // Validate short leave duration (1 hour 30 minutes)
                    if (duration != TimeSpan.FromMinutes(90))
                    {
                        MessageBox.Show("Short leave duration must be exactly 1 hour and 30 minutes.");
                        System.Diagnostics.Debug.WriteLine("Validation failed: Short leave duration is not 1 hour 30 minutes.");
                        return;
                    }

                    if (slotStartTime < DateTime.Now)
                    {
                        MessageBox.Show("Short leaves must be applied for upcoming time slots.");
                        System.Diagnostics.Debug.WriteLine("Validation failed: Short leave time slot is in the past.");
                        return;
                    }
                    endDate = startDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Invalid time slot format: {ex.Message}");
                    System.Diagnostics.Debug.WriteLine($"Validation failed: Invalid time slot format - {ex.Message}");
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO LeaveRequests (EmployeeID, LeaveType, StartDate, EndDate, TimeSlot, Status) " +
                                 "VALUES (@id, @type, @start, @end, @slot, 'Pending')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    cmd.Parameters.AddWithValue("@type", leaveType);
                    cmd.Parameters.AddWithValue("@start", startDate);
                    cmd.Parameters.AddWithValue("@end", endDate);
                    cmd.Parameters.AddWithValue("@slot", timeSlot ?? (object)DBNull.Value);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("No rows were inserted into LeaveRequests.");
                        System.Diagnostics.Debug.WriteLine("Database insertion failed: No rows affected.");
                        return;
                    }
                }

                MessageBox.Show("Leave request submitted successfully.");
                LoadLeaveHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Database insertion failed: {ex.Message}");
            }
        }

        private DateTime? GetRosterStartTime(DateTime leaveDate)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TOP 1 StartTime FROM Rosters WHERE EmployeeID = @id AND CAST(StartTime AS DATE) = @leaveDate ORDER BY StartTime";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    cmd.Parameters.AddWithValue("@leaveDate", leaveDate.Date);
                    object result = cmd.ExecuteScalar();
                    return result != null ? (DateTime?)result : null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetRosterStartTime: {ex.Message}");
                return null;
            }
        }

        private void btnDeleteLeave_Click(object sender, EventArgs e)
        {
            if (dgvLeaveHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a leave request to delete.");
                return;
            }

            int requestID = (int)dgvLeaveHistory.SelectedRows[0].Cells["RequestID"].Value;
            string status = dgvLeaveHistory.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status != "Pending")
            {
                MessageBox.Show("Only pending leave requests can be deleted.");
                return;
            }

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM LeaveRequests WHERE RequestID = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", requestID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Leave request deleted successfully.");
                LoadLeaveHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void lblShortLeaves_Click(object sender, EventArgs e)
        {

        }
    }
}