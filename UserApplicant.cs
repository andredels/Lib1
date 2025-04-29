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
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            dataGridView_UserApplicants.EnableHeadersVisualStyles = false;
            dataGridView_UserApplicants.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dataGridView_UserApplicants.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_UserApplicants.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView_UserApplicants.RowHeadersVisible = false;
            dataGridView_UserApplicants.BorderStyle = BorderStyle.None;
            dataGridView_UserApplicants.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_UserApplicants.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView_UserApplicants.RowTemplate.Height = 35;
            dataGridView_UserApplicants.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView_UserApplicants.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridView_UserApplicants.DefaultCellStyle.SelectionForeColor = Color.White;
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
                        LoadUniqueNames(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading registrants: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUniqueNames(DataTable dt)
        {
            comboBoxNames.Items.Clear();
            comboBoxNames.Items.Add("All Names");

            var uniqueNames = dt.AsEnumerable()
                .Select(row => row.Field<string>("Fullname"))
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            comboBoxNames.Items.AddRange(uniqueNames.ToArray());
            comboBoxNames.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingRegistrants();
            txtbox_Search.Clear();
            comboBoxNames.SelectedIndex = 0;
        }

        private void txtbox_Search_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBoxNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                if (dataGridView_UserApplicants.DataSource is DataTable dt)
                {
                    StringBuilder filterBuilder = new StringBuilder();

                    // Name filter from combobox
                    if (comboBoxNames.SelectedIndex > 0) // Skip "All Names"
                    {
                        string selectedName = comboBoxNames.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("[Fullname] = '{0}'", selectedName);
                    }

                    // Search box filter (searching across multiple fields)
                    if (!string.IsNullOrEmpty(txtbox_Search.Text))
                    {
                        if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");
                        string searchText = txtbox_Search.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("(Convert([UserID], 'System.String') LIKE '%{0}%' OR [Username] LIKE '%{0}%' OR [Fullname] LIKE '%{0}%' OR [Email] LIKE '%{0}%' OR [UserType] LIKE '%{0}%')", searchText);
                    }

                    dt.DefaultView.RowFilter = filterBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering applicants: " + ex.Message, "Filter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                LoadPendingRegistrants();

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
