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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void btnSignUpSIGNUP_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Lib.accdb;";

            // Gather input values
            string username = txtbxSignupUsername.Text.Trim();
            string password = Password.Text.Trim();
            string fullname = txtbxSignupFirstName.Text.Trim() + " " + txtbxSignupLastName.Text.Trim();
            string email = txtbxSignupEmail.Text.Trim();
            string userType = radiobtnStudent.Checked ? "student" : "admin"; // Determine role
            string approvalStatus = "Pending"; // All new users start as "Pending"

            // Check if any field is empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, [Password], Fullname, Email, UserType, ApprovalStatus) " +
                                   "VALUES (@Username, @Password, @Fullname, @Email, @UserType, @ApprovalStatus)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Fullname", fullname);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@UserType", userType);
                        cmd.Parameters.AddWithValue("@ApprovalStatus", approvalStatus);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Signup successful! Please wait for admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to login form
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void radiobtnStudent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radiobtnAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtbxSignupFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void txtbxSignupLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxSignupEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxSignupUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
