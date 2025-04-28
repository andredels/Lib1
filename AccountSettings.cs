using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Lib1
{
    public partial class AccountSettings : UserControl
    {
        private int userId;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";

        public AccountSettings(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.Load += AccountSettings_Load;
        }

        private void AccountSettings_Load(object sender, EventArgs e)
        {
            LoadUserDetails();
            textBoxCurrentPassword.PasswordChar = '*';
            textBoxNewPassword.PasswordChar = '*';
        }

        private void LoadUserDetails()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username, Fullname, Email FROM Users WHERE UserID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", userId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxUsername.Text = reader["Username"].ToString();
                                string fullname = reader["Fullname"].ToString();
                                var names = fullname.Trim().Split(' ');
                                if (names.Length > 1)
                                {
                                    textBoxLastname.Text = names[names.Length - 1];
                                    textBoxFirstName.Text = string.Join(" ", names.Take(names.Length - 1));
                                }
                                else
                                {
                                    textBoxFirstName.Text = fullname;
                                    textBoxLastname.Text = "";
                                }
                                textBoxEmail.Text = reader["Email"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateUsername_Click(object sender, EventArgs e)
        {
            string newUsername = textBoxUsername.Text.Trim();
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Users SET Username = ? WHERE UserID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newUsername);
                        cmd.Parameters.AddWithValue("?", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Username updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating username: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            string newEmail = textBoxEmail.Text.Trim();
            if (string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Users SET Email = ? WHERE UserID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newEmail);
                        cmd.Parameters.AddWithValue("?", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Email updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = textBoxCurrentPassword.Text.Trim();
            string newPassword = textBoxNewPassword.Text.Trim();
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter both current and new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Password FROM Users WHERE UserID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", userId);
                        string dbPassword = cmd.ExecuteScalar()?.ToString();
                        if (dbPassword != SecurityHelper.HashPassword(currentPassword))
                        {
                            MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    string updateQuery = "UPDATE Users SET [Password] = ? WHERE UserID = ?";
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("?", SecurityHelper.HashPassword(newPassword));
                        updateCmd.Parameters.AddWithValue("?", userId);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxCurrentPassword.Clear();
                textBoxNewPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = checkBoxShowPassword.Checked;
            textBoxCurrentPassword.PasswordChar = show ? '\0' : '*';
            textBoxNewPassword.PasswordChar = show ? '\0' : '*';
        }
    }
}
