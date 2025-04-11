using DataLayer;
using EmployeeApplication;
using System;
using System.Windows.Forms;

namespace EmployeeApplication
{
    public partial class LoginForm : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Employee Login";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpID.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both Employee ID and Password.");
                return;
            }

            try
            {
                if (db.Login(txtEmpID.Text, txtPassword.Text, false)) // isAdmin = false for employees
                {
                    EmployeeForm employeeForm = new EmployeeForm(txtEmpID.Text);
                    employeeForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Employee ID or Password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}