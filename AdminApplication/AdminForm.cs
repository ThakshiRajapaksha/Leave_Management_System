using DataLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdminApplication
{
    public partial class AdminForm : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public AdminForm()
        {
            InitializeComponent();
            this.Text = "Admin Dashboard";
            this.WindowState = FormWindowState.Maximized; // Set to full screen
            this.StartPosition = FormStartPosition.CenterScreen; // Ignored when maximized, but kept for consistency

            // Configure DataGridViews
            dgvPendingLeaves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadPendingLeaves();
            chkPermanent_CheckedChanged(null, null); // Initialize leave balances
            dtpJoinDate_ValueChanged(null, null); // Initialize short leaves
        }

        // Register New Employee
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpID.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Parse leave balances (these fields should exist in the UI, but we'll calculate them if not)
            if (!int.TryParse(txtAnnualLeaves?.Text ?? "0", out int annualLeaves) ||
                !int.TryParse(txtCasualLeaves?.Text ?? "0", out int casualLeaves) ||
                !int.TryParse(txtShortLeaves?.Text ?? "0", out int shortLeaves))
            {
                MessageBox.Show("Please enter valid numbers for leave balances.");
                return;
            }

            try
            {
                if (db.RegisterEmployee(txtEmpID.Text, txtPassword.Text, txtName.Text, dtpJoinDate.Value, chkPermanent.Checked, annualLeaves, casualLeaves, shortLeaves))
                {
                    MessageBox.Show("Employee registered successfully.");
                    ClearRegistrationFields();
                }
                else
                {
                    MessageBox.Show("Registration failed. Employee ID may already exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearRegistrationFields()
        {
            txtEmpID.Clear();
            txtPassword.Clear();
            txtName.Clear();
            dtpJoinDate.Value = DateTime.Now;
            chkPermanent.Checked = false;
            txtAnnualLeaves?.Clear();
            txtCasualLeaves?.Clear();
            txtShortLeaves?.Clear();
        }

        private void chkPermanent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPermanent.Checked)
            {
                txtAnnualLeaves.Text = "14";
                txtCasualLeaves.Text = "7";
            }
            else
            {
                txtAnnualLeaves.Text = "7";
                txtCasualLeaves.Text = "3";
            }
        }

        private void dtpJoinDate_ValueChanged(object sender, EventArgs e)
        {
            int remainingMonths = 12 - dtpJoinDate.Value.Month + 1;
            int shortLeaves = remainingMonths * 2;
            txtShortLeaves.Text = shortLeaves.ToString();
        }

        // Set Roster
        private void btnSetRoster_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRosterEmpID.Text))
            {
                MessageBox.Show("Please enter an Employee ID.");
                return;
            }

            try
            {
                if (dtpStartTime.Value >= dtpEndTime.Value)
                {
                    MessageBox.Show("Start time must be earlier than end time.");
                    return;
                }

                if (db.DefineRoster(txtRosterEmpID.Text, dtpStartTime.Value, dtpEndTime.Value))
                {
                    MessageBox.Show("Roster set successfully.");
                    txtRosterEmpID.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to set roster. Employee ID may not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Load Pending Leaves
        private void LoadPendingLeaves()
        {
            try
            {
                dgvPendingLeaves.DataSource = db.GetPendingLeaves();
                dgvPendingLeaves.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending leaves: {ex.Message}");
            }
        }

        // Approve Leave
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeaves.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a leave request to approve.");
                return;
            }

            try
            {
                int requestID = (int)dgvPendingLeaves.SelectedRows[0].Cells["RequestID"].Value;
                if (db.UpdateLeaveStatus(requestID, "Approved"))
                {
                    MessageBox.Show("Leave approved successfully.");
                    LoadPendingLeaves();
                }
                else
                {
                    MessageBox.Show("Failed to approve leave.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Reject Leave
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPendingLeaves.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a leave request to reject.");
                return;
            }

            try
            {
                int requestID = (int)dgvPendingLeaves.SelectedRows[0].Cells["RequestID"].Value;
                if (db.UpdateLeaveStatus(requestID, "Rejected"))
                {
                    MessageBox.Show("Leave rejected successfully.");
                    LoadPendingLeaves();
                }
                else
                {
                    MessageBox.Show("Failed to reject leave.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Individual Employee Leave Report
        private void btnIndividualReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReportEmpID.Text))
            {
                MessageBox.Show("Please enter an Employee ID.");
                return;
            }

            try
            {
                dgvReports.DataSource = db.GetEmployeeLeaveHistory(txtReportEmpID.Text, dtpReportStart.Value, dtpReportEnd.Value);
                dgvReports.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // All Employees Leave Report
        private void btnAllReport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReports.DataSource = db.GetAllEmployeesLeaveHistory(dtpReportStart.Value, dtpReportEnd.Value);
                dgvReports.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}