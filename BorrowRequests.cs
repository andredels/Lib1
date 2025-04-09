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
    public partial class BorrowRequests : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Lib.accdb;";

        public BorrowRequests()
        {
            InitializeComponent();
        }


        private void btnRefresh_BookBorrowRequests_Click(object sender, EventArgs e)
        {
            LoadBorrowRequests();
        }


        private void dataGridView_BookBorrowRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a valid row is clicked (not header)
            {
                DataGridViewRow row = dataGridView_BookBorrowRequests.Rows[e.RowIndex];

                // These aren't in your query results directly, but if you want to use them:
                txtbxBorrowRequest_UserId.Text = row.Cells["UserId"].Value?.ToString() ?? "";
                txtbxBorrowRequest_BookID.Text = row.Cells["BookID"].Value?.ToString() ?? "";
                txtbxBorrowRequest_TotalCopies.Text = row.Cells["TotalCopies"].Value?.ToString() ?? "";
                txtbxBorrowRequest_AvailableCopies.Text = row.Cells["AvailableCopies"].Value?.ToString() ?? "";

                // Fill textboxes with data from the selected row
                txtbxBorrowRequest_Fullname.Text = row.Cells["Fullname"].Value?.ToString() ?? "";
                txtbxBorrowRequest_BookName.Text = row.Cells["Title"].Value?.ToString() ?? "";
                txtbxBorrowRequest_Author.Text = row.Cells["Author"].Value?.ToString() ?? "";
                txtbxBorrowRequest_Publisher.Text = row.Cells["Publisher"].Value?.ToString() ?? "";
                txtbxBorrowRequest_PublicationYear.Text = row.Cells["PublicationYear"].Value?.ToString() ?? "";
                txtbxBorrowRequest_RequestDate.Text = row.Cells["Request Date"].Value?.ToString() ?? "";

               
            }
        }

        private void txtbxBorrowRequest_SearchStudentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAccept_BorrowBookRequests_Click(object sender, EventArgs e)
        {
            if (dataGridView_BookBorrowRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to approve.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int transactionID = Convert.ToInt32(dataGridView_BookBorrowRequests.SelectedRows[0].Cells["TransactionID"].Value);
            int bookID = Convert.ToInt32(dataGridView_BookBorrowRequests.SelectedRows[0].Cells["BookID"].Value);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Update transaction status to Approved and set Approval Date
                string updateQuery = "UPDATE BookTransactions SET Status = 'Approved', [Approval Date] = ? WHERE TransactionID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = transactionID;
                    cmd.ExecuteNonQuery();
                }

                // Reduce AvailableCopies in Books table
                string updateBookQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateBookQuery, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = bookID;
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Borrow request approved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBorrowRequests(); // Refresh data
        }

        private void btnDecline_BorrowBookRequests_Click(object sender, EventArgs e)
        {
            if (dataGridView_BookBorrowRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to decline.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int transactionID = Convert.ToInt32(dataGridView_BookBorrowRequests.SelectedRows[0].Cells["TransactionID"].Value);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Update transaction status to Rejected
                string updateQuery = "UPDATE BookTransactions SET Status = 'Rejected' WHERE TransactionID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = transactionID;
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Borrow request declined!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBorrowRequests(); // Refresh data
        }
        private void LoadBorrowRequests()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookTransactions.TransactionID, BookTransactions.UserId, BookTransactions.BookID, " +
                                   "Users.Fullname, Books.Title, Books.Author, Books.Publisher, Books.PublicationYear, " +
                                   "Books.TotalCopies, Books.AvailableCopies, " +
                                   "BookTransactions.[Request Date], BookTransactions.Status " +
                                   "FROM (BookTransactions " +
                                   "INNER JOIN Users ON BookTransactions.UserId = Users.UserId) " +
                                   "INNER JOIN Books ON BookTransactions.BookID = Books.BookID " +
                                   "WHERE BookTransactions.Status = 'Pending'";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView_BookBorrowRequests.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrow requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

    private void btnLoad_BorrowBookRequests_Click(object sender, EventArgs e)
        {
            LoadBorrowRequests();
        }

        private void btnBack_BorrowBookRequests_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(); // Create a new instance of AdminMenu
            adminMenu.Show();
            this.Close();
        }

        private void txtbxBorrowRequest_UserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_BookID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_Author_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_PublicationYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_RequestDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_Fullname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_BookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_Publisher_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_TotalCopies_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxBorrowRequest_AvailableCopies_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
