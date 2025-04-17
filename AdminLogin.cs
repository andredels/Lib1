using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib1
{
    public partial class AdminLogin : Form
    {


        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        public AdminLogin()
        {
            InitializeComponent();
            txtboxPasswordAdmin.PasswordChar = '*';
        }

        private void areyouStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            string username = txtboxUsernameAdmin.Text.Trim();
            string password = txtboxPasswordAdmin.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(password); // ✔ Hashing enabled again

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE Username = ? AND Password = ? AND UserType = 'admin' AND ApprovalStatus = 'Approved'";

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

                                MessageBox.Show("Admin login successful! Welcome, " + fullName, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                AdminMenu adminMenu = new AdminMenu(userID, fullName);
                                adminMenu.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid admin username, password, or your account is not approved yet.",
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
    }
}

