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
    public partial class UserApplicant : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        public UserApplicant()
        {
            InitializeComponent();
            this.Load += UserApplicant_Load;
        }
        private void UserApplicant_Load(object sender, EventArgs e)
        {
            LoadPendingRegistrants();
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
                        dataGridView_UserApplicants.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading registrants: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void siticoneButtonstdntrgstrnts_Accept_Click(object sender, EventArgs e)
        {
            UpdateUserApprovalStatus("Approved");
        }

        private void dataGridView_UserApplicants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_UserApplicants.Rows[e.RowIndex];

                txtboxstdntrgstrnts_UserId.Text = row.Cells["UserID"].Value.ToString();
                txtboxstdntrgstrnts_Username.Text = row.Cells["Username"].Value.ToString();
                txtboxstdntrgstrnts_FirstName.Text = row.Cells["Fullname"].Value.ToString();
                txtboxstdntrgstrnts_Email.Text = row.Cells["Email"].Value.ToString();
                txtboxstdntrgstrnts_Usertype.Text = row.Cells["UserType"].Value.ToString();
            }
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

        private void siticoneButtonstdntrgstrnts_Decline_Click(object sender, EventArgs e)
        {
            UpdateUserApprovalStatus("Rejected");
        }
    }
}
