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
    public partial class UsersInfo : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        public UsersInfo()
        {
            InitializeComponent();
            this.Load += UsersInfo_Load;
            StyleDataGridView();
        }

        private void UsersInfo_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void StyleDataGridView()
        {
            dataGridView_UsersInfo.EnableHeadersVisualStyles = false;
            dataGridView_UsersInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dataGridView_UsersInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_UsersInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView_UsersInfo.RowHeadersVisible = false;
            dataGridView_UsersInfo.BorderStyle = BorderStyle.None;
            dataGridView_UsersInfo.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_UsersInfo.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView_UsersInfo.RowTemplate.Height = 35;
            dataGridView_UsersInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView_UsersInfo.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridView_UsersInfo.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadUsers()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserID, Username, Fullname, Email, UserType FROM Users WHERE ApprovalStatus = 'Approved'";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView_UsersInfo.DataSource = dt;
                        LoadUniqueNames(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ApplyFilters()
        {
            try
            {
                if (dataGridView_UsersInfo.DataSource is DataTable dt)
                {
                    StringBuilder filterBuilder = new StringBuilder();

                    // Name filter from combobox
                    if (comboBoxNames.SelectedIndex > 0) // Skip "All Names"
                    {
                        string selectedName = comboBoxNames.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("[Fullname] = '{0}'", selectedName);
                    }

                    // Search box filter (searching across multiple fields)
                    if (!string.IsNullOrEmpty(txtboxSearch.Text))
                    {
                        if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");
                        string searchText = txtboxSearch.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("(Convert([UserID], 'System.String') LIKE '%{0}%' OR [Username] LIKE '%{0}%' OR [Fullname] LIKE '%{0}%' OR [Email] LIKE '%{0}%' OR [UserType] LIKE '%{0}%')", searchText);
                    }

                    dt.DefaultView.RowFilter = filterBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering users: " + ex.Message, "Filter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            txtboxSearch.Clear();
            comboBoxNames.SelectedIndex = 0;
            ClearFields();
        }

        private void comboBoxNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dataGridView_UsersInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_UsersInfo.Rows[e.RowIndex];

                txtboxUsersInfo_UserId.Text = row.Cells["UserID"].Value.ToString();
                txtboxUsersInfo_Username.Text = row.Cells["Username"].Value.ToString();
                txtboxUsersInfo_FirstName.Text = row.Cells["Fullname"].Value.ToString();
                txtboxUsersInfo_Email.Text = row.Cells["Email"].Value.ToString();
                txtboxUsersInfo_Usertype.Text = row.Cells["UserType"].Value.ToString();
            }
        }

        private void siticoneButtonUsersInfo_Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxUsersInfo_UserId.Text))
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET Username = @Username, Fullname = @Fullname, Email = @Email, UserType = @UserType WHERE UserID = @UserId";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtboxUsersInfo_Username.Text);
                        cmd.Parameters.AddWithValue("@Fullname", txtboxUsersInfo_FirstName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtboxUsersInfo_Email.Text);
                        cmd.Parameters.AddWithValue("@UserType", txtboxUsersInfo_Usertype.Text);
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtboxUsersInfo_UserId.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneButtonUsersInfo_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxUsersInfo_UserId.Text))
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Users WHERE UserID = @UserId";

                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtboxUsersInfo_UserId.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            txtboxUsersInfo_UserId.Clear();
            txtboxUsersInfo_Username.Clear();
            txtboxUsersInfo_FirstName.Clear();
            txtboxUsersInfo_Email.Clear();
            txtboxUsersInfo_Usertype.Clear();
        }
    }
}
