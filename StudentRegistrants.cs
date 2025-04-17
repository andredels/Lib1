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
    public partial class StudentRegistrants : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        public StudentRegistrants()
        {
            InitializeComponent();
        }

        private void LoadPendingRegistrants()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserID, Username, Fullname, Email, UserType FROM Users WHERE ApprovalStatus = 'Pending'";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView_UserRegistrants.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading registrants: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StudentRegistrants_Load(object sender, EventArgs e)
        {
            LoadPendingRegistrants();
        }
        private void btnCancelStudentRegistrants_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }

        private void dataGridView_UserRegistrants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_UserRegistrants.Rows[e.RowIndex];

                txtboxstdntrgstrnts_UserId.Text = row.Cells["UserID"].Value.ToString();
                txtboxstdntrgstrnts_Username.Text = row.Cells["Username"].Value.ToString();
                txtboxstdntrgstrnts_FirstName.Text = row.Cells["Fullname"].Value.ToString();
                txtboxstdntrgstrnts_Email.Text = row.Cells["Email"].Value.ToString();
                txtboxstdntrgstrnts_Usertype.Text = row.Cells["UserType"].Value.ToString();
            }
        }

        private void txtboxstdntrgstrnts_StudentNameSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnstdntrgstrnts_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void txtboxstdntrgstrnts_FirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxstdntrgstrnts_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButtonstdntrgstrnts_Accept_Click(object sender, EventArgs e)
        {
            UpdateUserApprovalStatus("Approved");
        }

        private void txtboxstdntrgstrnts_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxstdntrgstrnts_UserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButtonstdntrgstrnts_Decline_Click(object sender, EventArgs e)
        {
            UpdateUserApprovalStatus("Rejected");
        }

        private void UpdateUserApprovalStatus(string status)
        {
            if (string.IsNullOrEmpty(txtboxstdntrgstrnts_UserId.Text))
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(txtboxstdntrgstrnts_UserId.Text);

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET ApprovalStatus = @Status WHERE UserID = @UserId";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"User has been {status.ToLower()}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Refresh the list
                LoadPendingRegistrants();

                // ✅ Clear the fields after update
                txtboxstdntrgstrnts_UserId.Clear();
                txtboxstdntrgstrnts_Username.Clear();
                txtboxstdntrgstrnts_FirstName.Clear();
                txtboxstdntrgstrnts_Email.Clear();
                txtboxstdntrgstrnts_Usertype.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneAdvancedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButtonstdntrgstrnts_Load_Click(object sender, EventArgs e)
        {
            LoadPendingRegistrants();

        }

        private void txtboxstdntrgstrnts_Usertype_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
