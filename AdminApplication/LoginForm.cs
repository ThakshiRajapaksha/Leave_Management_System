using DataLayer;
using System;
using System.Windows.Forms;

namespace AdminApplication
{
    public partial class LoginForm : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Login button clicked.");
            System.Diagnostics.Debug.WriteLine($"EmployeeID: {txtEmployeeID.Text}, Password: {txtPassword.Text}");
            try
            {
                bool loginResult = db.Login(txtEmployeeID.Text, txtPassword.Text, true);
                System.Diagnostics.Debug.WriteLine($"Login result: {loginResult}");
                if (loginResult)
                {
                    System.Diagnostics.Debug.WriteLine("Opening AdminForm...");
                    AdminForm mainForm = new AdminForm();
                    mainForm.Show();
                    this.Hide();
                    System.Diagnostics.Debug.WriteLine("AdminForm opened, LoginForm hidden.");
                }
                else
                {
                    MessageBox.Show("Admin login failed. Check your credentials or contact support.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}