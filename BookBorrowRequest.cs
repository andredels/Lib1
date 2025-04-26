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
    public partial class BookBorrowRequest : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        private int adminId;
        private string adminName;
        public BookBorrowRequest(int adminId, string adminName)
        {
            InitializeComponent();
            this.adminId = adminId;
            this.adminName = adminName;
            this.Load += BookBorrowRequest_Load;
            this.dataGridView_BookBorrowRequests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_BookBorrowRequests_CellClick);
        }
        private void BookBorrowRequest_Load(object sender, EventArgs e)
        {
            LoadBorrowRequests();
        }
        private void dataGridView_BookBorrowRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row when any cell is clicked
                dataGridView_BookBorrowRequests.Rows[e.RowIndex].Selected = true;

                // You can also trigger your existing cell content click handler
                dataGridView_BookBorrowRequests_CellContentClick(sender, e);
            }
        }

        private void btnAccept_BorrowBookRequests_Click(object sender, EventArgs e)
        {
            if (dataGridView_BookBorrowRequests.CurrentCell == null)
            {
                MessageBox.Show("Please select a request to approve.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected row using the CurrentCell's row index
            DataGridViewRow row = dataGridView_BookBorrowRequests.Rows[dataGridView_BookBorrowRequests.CurrentCell.RowIndex];

            // Check that required columns exist and get values safely
            if (!dataGridView_BookBorrowRequests.Columns.Contains("TransactionID") ||
                !dataGridView_BookBorrowRequests.Columns.Contains("BookID"))
            {
                MessageBox.Show("Missing required transaction or book information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int transactionID = Convert.ToInt32(row.Cells["TransactionID"].Value);
            int bookID = Convert.ToInt32(row.Cells["BookID"].Value);

            // Check for available copies if the column exists
            if (dataGridView_BookBorrowRequests.Columns.Contains("AvailableCopies"))
            {
                int availableCopies = Convert.ToInt32(row.Cells["AvailableCopies"].Value);
                if (availableCopies <= 0)
                {
                    MessageBox.Show("This book has no available copies left.", "No Copies Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DateTime currentDate = DateTime.Now;
            DateTime returnDate = currentDate.AddDays(7); // Return date is 1 week later

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Update transaction status to Approved and set all dates, ProcessedBy, and RequestType
                    string updateQuery = @"UPDATE BookTransactions 
                                        SET Status = 'Approved', 
                                            [ApprovalDate] = ?, 
                                            [BorrowDate] = ?, 
                                            [ReturnDate] = ?,
                                            [ProcessedBy] = ?,
                                            [RequestType] = 'Borrow'
                                        WHERE TransactionID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn, transaction))
                    {
                        cmd.Parameters.Add("?", OleDbType.Date).Value = currentDate;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = currentDate;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = returnDate;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = adminName;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = transactionID;
                        cmd.ExecuteNonQuery();
                    }

                    // Reduce AvailableCopies in Books table
                    string updateBookQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(updateBookQuery, conn, transaction))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = bookID;
                        cmd.ExecuteNonQuery();
                    }

                    // Commit the transaction if everything is successful
                    transaction.Commit();

                    MessageBox.Show("Borrow request approved! The book is now marked as borrowed and will be due in one week.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // If any operation fails, roll back all changes
                    transaction.Rollback();
                    MessageBox.Show("Error approving request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Refresh the data to show updated list (pending request should be gone)
            LoadBorrowRequests();
        }

        private void dataGridView_BookBorrowRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a valid row is clicked (not header)
            {
                DataGridViewRow row = dataGridView_BookBorrowRequests.Rows[e.RowIndex];

                // Get the values safely with null checking
                // First check if the column exists in the DataGridView
                if (dataGridView_BookBorrowRequests.Columns.Contains("UserId"))
                    txtbxBorrowRequest_UserId.Text = row.Cells["UserId"].Value?.ToString() ?? "";

                if (dataGridView_BookBorrowRequests.Columns.Contains("BookID"))
                    txtbxBorrowRequest_BookID.Text = row.Cells["BookID"].Value?.ToString() ?? "";

                // For TotalCopies, we need to check if the column exists
                if (dataGridView_BookBorrowRequests.Columns.Contains("TotalCopies"))
                    txtbxBorrowRequest_TotalCopies.Text = row.Cells["TotalCopies"].Value?.ToString() ?? "";

                if (dataGridView_BookBorrowRequests.Columns.Contains("AvailableCopies"))
                    txtbxBorrowRequest_AvailableCopies.Text = row.Cells["AvailableCopies"].Value?.ToString() ?? "";

                // Fill other textboxes
                if (dataGridView_BookBorrowRequests.Columns.Contains("Fullname"))
                    txtbxBorrowRequest_Fullname.Text = row.Cells["Fullname"].Value?.ToString() ?? "";

                if (dataGridView_BookBorrowRequests.Columns.Contains("Title"))
                    txtbxBorrowRequest_BookName.Text = row.Cells["Title"].Value?.ToString() ?? "";

                if (dataGridView_BookBorrowRequests.Columns.Contains("Author"))
                    txtbxBorrowRequest_Author.Text = row.Cells["Author"].Value?.ToString() ?? "";

                if (dataGridView_BookBorrowRequests.Columns.Contains("Publisher"))
                    txtbxBorrowRequest_Publisher.Text = row.Cells["Publisher"].Value?.ToString() ?? "";

                if (dataGridView_BookBorrowRequests.Columns.Contains("PublicationYear"))
                    txtbxBorrowRequest_PublicationYear.Text = row.Cells["PublicationYear"].Value?.ToString() ?? "";

                // Handle possible name differences for request date
                if (dataGridView_BookBorrowRequests.Columns.Contains("Request Date"))
                    txtbxBorrowRequest_RequestDate.Text = row.Cells["Request Date"].Value?.ToString() ?? "";
                else if (dataGridView_BookBorrowRequests.Columns.Contains("RequestDate"))
                    txtbxBorrowRequest_RequestDate.Text = row.Cells["RequestDate"].Value?.ToString() ?? "";

                // Handle new textboxes
                if (dataGridView_BookBorrowRequests.Columns.Contains("ISBN"))
                    txtbxBorrowRequest_ISBN.Text = row.Cells["ISBN"].Value?.ToString() ?? "";

                if (dataGridView_BookBorrowRequests.Columns.Contains("Genre") ||
                    dataGridView_BookBorrowRequests.Columns.Contains("GenreName"))
                {
                    string genreColName = dataGridView_BookBorrowRequests.Columns.Contains("Genre") ? "Genre" : "GenreName";
                    txtbxBorrowRequest_Genre.Text = row.Cells[genreColName].Value?.ToString() ?? "";
                }
            }
        }

        private void btnDecline_BorrowBookRequests_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView_BookBorrowRequests.CurrentCell == null)
                {
                    MessageBox.Show("Please select a request to decline.", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the selected row index
                int rowIndex = dataGridView_BookBorrowRequests.CurrentCell.RowIndex;

                // Check that TransactionID column exists
                if (!dataGridView_BookBorrowRequests.Columns.Contains("TransactionID"))
                {
                    MessageBox.Show("Missing required transaction information.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int transactionID = Convert.ToInt32(dataGridView_BookBorrowRequests.Rows[rowIndex].Cells["TransactionID"].Value);

                // Confirm before declining
                DialogResult result = MessageBox.Show("Are you sure you want to decline this book request?",
                    "Confirm Decline", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            // Update transaction status to Declined and set who processed it
                            string updateQuery = @"UPDATE BookTransactions 
                                      SET Status = 'Declined', ProcessedBy = ? 
                                      WHERE TransactionID = ?";

                            using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                            {
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = adminName;
                                cmd.Parameters.Add("?", OleDbType.Integer).Value = transactionID;

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Borrow request declined successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadBorrowRequests(); // Refresh the list
                                }
                                else
                                {
                                    MessageBox.Show("Failed to decline the request. The record may have been deleted.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Database error: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadBorrowRequests()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Use the PendingBorrowRequest query directly
                    string query = "SELECT * FROM PendingBorrowRequest";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView_BookBorrowRequests.DataSource = dt;

                        // Clear text boxes if there's no data
                        if (dt.Rows.Count == 0)
                        {
                            ClearTextBoxes();
                        }
                    }

                    // Debug: Print column names 
                    if (dataGridView_BookBorrowRequests.Columns.Count > 0)
                    {
                        Console.WriteLine("Available columns in the DataGridView:");
                        foreach (DataGridViewColumn col in dataGridView_BookBorrowRequests.Columns)
                        {
                            Console.WriteLine($"- {col.Name}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrow requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearTextBoxes()
        {
            // Clear all textboxes when there's no data
            txtbxBorrowRequest_UserId.Text = "";
            txtbxBorrowRequest_BookID.Text = "";
            txtbxBorrowRequest_TotalCopies.Text = "";
            txtbxBorrowRequest_AvailableCopies.Text = "";
            txtbxBorrowRequest_Fullname.Text = "";
            txtbxBorrowRequest_BookName.Text = "";
            txtbxBorrowRequest_Author.Text = "";
            txtbxBorrowRequest_Publisher.Text = "";
            txtbxBorrowRequest_PublicationYear.Text = "";
            txtbxBorrowRequest_RequestDate.Text = "";
            txtbxBorrowRequest_ISBN.Text = "";
            txtbxBorrowRequest_Genre.Text = "";
        }
    }
}
