using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DatabaseConnection
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=LeaveManagementDB;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool Login(string id, string password, bool isAdmin = false)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Employees WHERE EmployeeID = @id AND Password = @pwd AND IsAdmin = @isAdmin";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pwd", password);
                    cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in Login: {ex.Message}");
                throw;
            }
        }

        public bool RegisterEmployee(string id, string password, string name, DateTime joinDate, bool isPermanent, int annualLeaves, int casualLeaves, int shortLeaves)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string empQuery = "INSERT INTO Employees (EmployeeID, Password, Name, JoinDate, IsPermanent, IsAdmin) " +
                                    "VALUES (@id, @pwd, @name, @join, @perm, 0)";
                    SqlCommand empCmd = new SqlCommand(empQuery, conn);
                    empCmd.Parameters.AddWithValue("@id", id);
                    empCmd.Parameters.AddWithValue("@pwd", password);
                    empCmd.Parameters.AddWithValue("@name", name);
                    empCmd.Parameters.AddWithValue("@join", joinDate);
                    empCmd.Parameters.AddWithValue("@perm", isPermanent);
                    empCmd.ExecuteNonQuery();

                    string balanceQuery = "INSERT INTO LeaveBalances (EmployeeID, Year, AnnualLeaves, CasualLeaves, ShortLeaves) " +
                                        "VALUES (@id, @year, @annual, @casual, @short)";
                    SqlCommand balanceCmd = new SqlCommand(balanceQuery, conn);
                    balanceCmd.Parameters.AddWithValue("@id", id);
                    balanceCmd.Parameters.AddWithValue("@year", DateTime.Now.Year);
                    balanceCmd.Parameters.AddWithValue("@annual", annualLeaves);
                    balanceCmd.Parameters.AddWithValue("@casual", casualLeaves);
                    balanceCmd.Parameters.AddWithValue("@short", shortLeaves);
                    balanceCmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in RegisterEmployee: {ex.Message}");
                return false;
            }
        }

        public bool DefineRoster(string employeeID, DateTime startTime, DateTime endTime)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Rosters (EmployeeID, StartTime, EndTime) " +
                                 "VALUES (@id, @start, @end)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    cmd.Parameters.AddWithValue("@start", startTime);
                    cmd.Parameters.AddWithValue("@end", endTime);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in DefineRoster: {ex.Message}");
                return false;
            }
        }

        public bool UpdateLeaveStatus(int requestID, string status)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string selectQuery = "SELECT EmployeeID, LeaveType, StartDate, EndDate FROM LeaveRequests WHERE RequestID = @id";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@id", requestID);
                    SqlDataReader reader = selectCmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        reader.Close();
                        return false;
                    }

                    string employeeID = reader["EmployeeID"].ToString();
                    string leaveType = reader["LeaveType"].ToString();
                    DateTime startDate = (DateTime)reader["StartDate"];
                    DateTime endDate = (DateTime)reader["EndDate"];
                    reader.Close();

                    if (status == "Approved")
                    {
                        int days = 0;
                        if (leaveType == "Annual" || leaveType == "Casual")
                        {
                            days = (endDate - startDate).Days + 1;
                        }
                        else if (leaveType == "Short")
                        {
                            days = 1;
                        }

                        string balanceQuery = "SELECT AnnualLeaves, CasualLeaves, ShortLeaves FROM LeaveBalances " +
                                            "WHERE EmployeeID = @id AND Year = @year";
                        SqlCommand balanceCmd = new SqlCommand(balanceQuery, conn);
                        balanceCmd.Parameters.AddWithValue("@id", employeeID);
                        balanceCmd.Parameters.AddWithValue("@year", DateTime.Now.Year);
                        SqlDataReader balanceReader = balanceCmd.ExecuteReader();

                        if (!balanceReader.Read())
                        {
                            balanceReader.Close();
                            throw new Exception("Leave balance not found for this employee.");
                        }

                        int currentBalance = 0;
                        if (leaveType == "Annual")
                        {
                            currentBalance = (int)balanceReader["AnnualLeaves"];
                        }
                        else if (leaveType == "Casual")
                        {
                            currentBalance = (int)balanceReader["CasualLeaves"];
                        }
                        else if (leaveType == "Short")
                        {
                            currentBalance = (int)balanceReader["ShortLeaves"];
                        }
                        balanceReader.Close();

                        if (currentBalance < days)
                        {
                            throw new Exception($"Insufficient {leaveType} leave balance. Available: {currentBalance}, Required: {days}");
                        }

                        string updateBalanceQuery = "";
                        if (leaveType == "Annual")
                        {
                            updateBalanceQuery = "UPDATE LeaveBalances SET AnnualLeaves = AnnualLeaves - @days " +
                                                "WHERE EmployeeID = @id AND Year = @year";
                        }
                        else if (leaveType == "Casual")
                        {
                            updateBalanceQuery = "UPDATE LeaveBalances SET CasualLeaves = CasualLeaves - @days " +
                                                "WHERE EmployeeID = @id AND Year = @year";
                        }
                        else if (leaveType == "Short")
                        {
                            updateBalanceQuery = "UPDATE LeaveBalances SET ShortLeaves = ShortLeaves - @days " +
                                                "WHERE EmployeeID = @id AND Year = @year";
                        }

                        SqlCommand updateBalanceCmd = new SqlCommand(updateBalanceQuery, conn);
                        updateBalanceCmd.Parameters.AddWithValue("@days", days);
                        updateBalanceCmd.Parameters.AddWithValue("@id", employeeID);
                        updateBalanceCmd.Parameters.AddWithValue("@year", DateTime.Now.Year);
                        updateBalanceCmd.ExecuteNonQuery();
                    }

                    string updateQuery = "UPDATE LeaveRequests SET Status = @status WHERE RequestID = @id";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@status", status);
                    updateCmd.Parameters.AddWithValue("@id", requestID);
                    updateCmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in UpdateLeaveStatus: {ex.Message}");
                throw;
            }
        }

        public DataTable GetPendingLeaves()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT RequestID, EmployeeID, LeaveType, StartDate, EndDate, TimeSlot " +
                             "FROM LeaveRequests WHERE Status = 'Pending'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetEmployeeLeaveHistory(string employeeID, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT RequestID, LeaveType, StartDate, EndDate, TimeSlot, Status " +
                             "FROM LeaveRequests WHERE EmployeeID = @id " +
                             "AND CAST(StartDate AS DATE) <= @end " +
                             "AND CAST(EndDate AS DATE) >= @start";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", employeeID);
                adapter.SelectCommand.Parameters.AddWithValue("@start", startDate.Date);
                adapter.SelectCommand.Parameters.AddWithValue("@end", endDate.Date);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetAllEmployeesLeaveHistory(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT RequestID, EmployeeID, LeaveType, StartDate, EndDate, TimeSlot, Status " +
                             "FROM LeaveRequests WHERE CAST(StartDate AS DATE) <= @end " +
                             "AND CAST(EndDate AS DATE) >= @start";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@start", startDate.Date);
                adapter.SelectCommand.Parameters.AddWithValue("@end", endDate.Date);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool UpdateLeaveBalances(string employeeID, int annualLeaves, int casualLeaves, int shortLeaves)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE LeaveBalances SET AnnualLeaves = @annual, CasualLeaves = @casual, ShortLeaves = @short " +
                                 "WHERE EmployeeID = @id AND Year = @year";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    cmd.Parameters.AddWithValue("@year", DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@annual", annualLeaves);
                    cmd.Parameters.AddWithValue("@casual", casualLeaves);
                    cmd.Parameters.AddWithValue("@short", shortLeaves);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in UpdateLeaveBalances: {ex.Message}");
                return false;
            }
        }
    }
}