using System.Data.OleDb;

namespace Lib1
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        public Form1()
        {
            InitializeComponent();
            txtboxPasswordStudent.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtboxUsernameStudent.Text.Trim();
            string password = txtboxPasswordStudent.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(password); // 🔐 Hash input

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE Username = ? AND Password = ? AND UserType = 'student' AND ApprovalStatus = 'Approved'";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", username);
                        cmd.Parameters.AddWithValue("?", hashedPassword);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userID = Convert.ToInt32(reader["UserID"]);
                                string fullName = reader["Fullname"].ToString();

                                MessageBox.Show("Login successful! Welcome, " + fullName, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // ✅ Open StudentDashBoard instead of StudentMenu
                                StudentDashBoard studentDash = new StudentDashBoard(userID, fullName);
                                studentDash.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username, password, or your account is not approved yet.",
                                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void siticoneLinkedLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            AdminLogin adminlogin = new AdminLogin();
            adminlogin.Show();
            this.Hide();
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = ShowPassword.Checked;
            txtboxPasswordStudent.PasswordChar = show ? '\0' : '*';
        }
    }
}
