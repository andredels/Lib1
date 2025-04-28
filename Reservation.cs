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
    public partial class Reservation : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb";
        private int selectedTransactionID = 0;
        private string adminFullName;

        public Reservation(int userID)
        {
            InitializeComponent();

            //Get the admin's full name from the database
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FullName FROM Users WHERE UserID = @UserID";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            adminFullName = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting admin name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

            SetupUI();
            LoadReservedBooks();

        }

        private void SetupUI()
        {
            // Initially hide approval buttons
            btnAccept.Visible = false;
            btnDecline.Visible = false;
            btnLendBook.Visible = true;

            // Initially disable action buttons until a row is selected
            btnLendBook.Enabled = false;
            btnAccept.Enabled = false;
            btnDecline.Enabled = false;
        }

        private void LoadReservedBooks()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Build your own JOIN DO NOT USE ReservedBooks
                    string query = "SELECT * FROM [ReservedBooks]";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ReservedBooks.DataSource = null;
                        ReservedBooks.DataSource = dataTable;

                        // Configure the DataGridView columns for better display
                        if (ReservedBooks.Columns.Contains("RequestDate"))
                        {
                            ReservedBooks.Columns["RequestDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (ReservedBooks.Columns.Contains("BorrowDate"))
                        {
                            ReservedBooks.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (ReservedBooks.Columns.Contains("ReturnDate"))
                        {
                            ReservedBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

                        // Apply professional styling
                        StyleDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reserved books: {ex.Message}\nStack trace: {ex.StackTrace}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            // Basic styling
            ReservedBooks.BorderStyle = BorderStyle.None;
            ReservedBooks.BackgroundColor = Color.White;
            ReservedBooks.EnableHeadersVisualStyles = false;
            ReservedBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ReservedBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ReservedBooks.GridColor = Color.FromArgb(224, 224, 224);

            // Header styling
            ReservedBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            ReservedBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ReservedBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ReservedBooks.ColumnHeadersHeight = 40;
            ReservedBooks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row styling
            ReservedBooks.RowTemplate.Height = 35;
            ReservedBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            ReservedBooks.DefaultCellStyle.SelectionForeColor = Color.White;
            ReservedBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            ReservedBooks.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            ReservedBooks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ReservedBooks.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            // Selection mode
            ReservedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReservedBooks.MultiSelect = false;

            // Column sizing and scrolling
            ReservedBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            ReservedBooks.AllowUserToResizeColumns = true;
            ReservedBooks.AllowUserToResizeRows = false;
            ReservedBooks.ScrollBars = ScrollBars.Both;
            ReservedBooks.Dock = DockStyle.None;
            ReservedBooks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Set minimum column widths
            foreach (DataGridViewColumn column in ReservedBooks.Columns)
            {
                column.MinimumWidth = 100;
                column.Width = 150;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // Disable row headers
            ReservedBooks.RowHeadersVisible = false;

            // Add some padding
            ReservedBooks.Padding = new Padding(10);
        }

        private void LoadPendingReservationRequests()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Use the PendingReservationRequests query directly
                    string query = "SELECT * FROM PendingReservationRequests";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ReservedBooks.DataSource = dataTable;

                        // Configure the DataGridView columns for better display
                        if (ReservedBooks.Columns.Contains("RequestDate"))
                        {
                            ReservedBooks.Columns["RequestDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (ReservedBooks.Columns.Contains("BorrowDate"))
                        {
                            ReservedBooks.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (ReservedBooks.Columns.Contains("ReturnDate"))
                        {
                            ReservedBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pending reservation requests: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudentNames()
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (selectedTransactionID == 0)
            {
                MessageBox.Show("Please select a reservation request first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE BookTransactions " +
                                         "SET Status = 'Approved', ApprovalDate = @ApprovalDate, ProcessedBy = @ProcessedBy " +
                                         "WHERE TransactionID = @TransactionID";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.Add("@ApprovalDate", OleDbType.Date).Value = DateTime.Now;
                        command.Parameters.Add("@ProcessedBy", OleDbType.VarWChar).Value = adminFullName;
                        command.Parameters.Add("@TransactionID", OleDbType.Integer).Value = selectedTransactionID;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation request approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Update failed.\nTransaction ID: {selectedTransactionID}",
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    LoadPendingReservationRequests();
                    ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving reservation:\n{ex.Message}\n\nTransaction ID: {selectedTransactionID}\nStack Trace: {ex.StackTrace}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (selectedTransactionID == 0)
            {
                MessageBox.Show("Please select a reservation request first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE BookTransactions SET Status = 'Declined' WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Reservation request declined successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingReservationRequests();
                    ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error declining reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLendBook_Click(object sender, EventArgs e)
        {
            if (selectedTransactionID == 0)
            {
                MessageBox.Show("Please select a reservation first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    OleDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // First get the book ID and check available copies
                        int bookID = 0;
                        int availableCopies = 0;
                        string checkQuery = @"SELECT b.BookID, b.AvailableCopies 
                                            FROM Books b 
                                            INNER JOIN BookTransactions bt ON b.BookID = bt.BookID 
                                            WHERE bt.TransactionID = @TransactionID";

                        using (OleDbCommand command = new OleDbCommand(checkQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    bookID = Convert.ToInt32(reader["BookID"]);
                                    availableCopies = Convert.ToInt32(reader["AvailableCopies"]);
                                }
                            }
                        }

                        if (availableCopies <= 0)
                        {
                            MessageBox.Show("This book has no available copies left.", "No Copies Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DateTime currentDate = DateTime.Now;
                        DateTime returnDate = currentDate.AddDays(7); // Return date is 1 week later

                        // Update transaction status to Approved and set all dates, ProcessedBy, and RequestType
                        string updateQuery = @"UPDATE BookTransactions 
                                            SET Status = 'Approved', 
                                                ApprovalDate = ?, 
                                                BorrowDate = ?, 
                                                ReturnDate = ?,
                                                ProcessedBy = ?,
                                                RequestType = 'Borrow'
                                            WHERE TransactionID = ?";

                        using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection, transaction))
                        {
                            cmd.Parameters.Add("?", OleDbType.Date).Value = currentDate;
                            cmd.Parameters.Add("?", OleDbType.Date).Value = currentDate;
                            cmd.Parameters.Add("?", OleDbType.Date).Value = returnDate;
                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = adminFullName;
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = selectedTransactionID;
                            cmd.ExecuteNonQuery();
                        }

                        // Reduce AvailableCopies in Books table
                        string updateBookQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID = ?";
                        using (OleDbCommand cmd = new OleDbCommand(updateBookQuery, connection, transaction))
                        {
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = bookID;
                            cmd.ExecuteNonQuery();
                        }

                        // Commit the transaction if everything is successful
                        transaction.Commit();

                        MessageBox.Show("Book has been successfully lent! The book is now marked as borrowed and will be due in one week.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservedBooks();
                        ClearSelection();
                    }
                    catch (Exception ex)
                    {
                        // If any operation fails, roll back all changes
                        transaction.Rollback();
                        throw; // Re-throw to be caught by outer catch block
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error lending book: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewReservationRequests_Click(object sender, EventArgs e)
        {
            btnAccept.Visible = true;
            btnDecline.Visible = true;
            btnLendBook.Visible = false;

            // Hide approval date, request type, and processed by fields
            siticoneLabel5.Visible = false;
            textBoxApprovalDate.Visible = false;
            siticoneLabel6.Visible = false;
            textBoxRequestType.Visible = false;
            siticoneLabel7.Visible = false;
            textBoxProcessedBy.Visible = false;
            
            LoadPendingReservationRequests();
            ClearSelection();
        }

        private void comboBoxStudentNameSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBoxBorrowedBookSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBoxBorrowedBookSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchText)) return;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT bt.TransactionID, b.BookID, b.Title, b.Author, b.ISBN, 
                                    g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, 
                                    bt.ProcessedBy, bt.RequestType
                                    FROM (((BookTransactions bt 
                                    INNER JOIN Books b ON bt.BookID = b.BookID)
                                    INNER JOIN Users u ON bt.UserID = u.UserID)
                                    INNER JOIN Genres g ON b.GenreID = g.GenreID)
                                    WHERE bt.RequestType = 'Reservation' AND 
                                    (b.Title LIKE @SearchText OR 
                                     b.Author LIKE @SearchText OR 
                                     b.ISBN LIKE @SearchText OR 
                                     u.FullName LIKE @SearchText)";

                    if (btnLendBook.Visible)
                    {
                        query += " AND bt.Status = 'Approved'";
                    }
                    else
                    {
                        query += " AND bt.Status = 'Pending'";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ReservedBooks.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservedBooks();
            ClearSelection();
            btnAccept.Visible = false;
            btnDecline.Visible = false;
            btnLendBook.Visible = true;

            // Show approval date, request type, and processed by fields
            siticoneLabel5.Visible = true;
            textBoxApprovalDate.Visible = true;
            siticoneLabel6.Visible = true;
            textBoxRequestType.Visible = true;
            siticoneLabel7.Visible = true;
            textBoxProcessedBy.Visible = true;
        }


        private void ClearSelection()
        {
            selectedTransactionID = 0;
            textBoxUserID.Text = string.Empty;
            textBoxFullName.Text = string.Empty;
            textBoxBookID.Text = string.Empty;
            textBoxBookTitle.Text = string.Empty;
            textBoxISBN.Text = string.Empty;
            textBoxAvailableCopies.Text = string.Empty;
            textBoxTotalCopies.Text = string.Empty;
            textBoxStatus.Text = string.Empty;
            textBoxRequestDate.Text = string.Empty;
            textBoxApprovalDate.Text = string.Empty;
            textBoxRequestType.Text = string.Empty;
            textBoxProcessedBy.Text = string.Empty;

            btnLendBook.Enabled = false;
            btnAccept.Enabled = false;
            btnDecline.Enabled = false;
        }

        private void ReservedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ReservedBooks.Rows[e.RowIndex];

                selectedTransactionID = Convert.ToInt32(row.Cells["TransactionID"].Value);

                // Check if column exists before filling textboxes
                if (row.DataGridView.Columns.Contains("UserID"))
                    textBoxUserID.Text = row.Cells["UserID"].Value.ToString();

                if (row.DataGridView.Columns.Contains("FullName"))
                    textBoxFullName.Text = row.Cells["FullName"].Value.ToString();

                if (row.DataGridView.Columns.Contains("BookID"))
                    textBoxBookID.Text = row.Cells["BookID"].Value.ToString();

                if (row.DataGridView.Columns.Contains("Title"))
                    textBoxBookTitle.Text = row.Cells["Title"].Value.ToString();

                if (row.DataGridView.Columns.Contains("ISBN"))
                    textBoxISBN.Text = row.Cells["ISBN"].Value.ToString();

                if (row.DataGridView.Columns.Contains("AvailableCopies"))
                    textBoxAvailableCopies.Text = row.Cells["AvailableCopies"].Value.ToString();

                if (row.DataGridView.Columns.Contains("TotalCopies"))
                    textBoxTotalCopies.Text = row.Cells["TotalCopies"].Value.ToString();

                if (row.DataGridView.Columns.Contains("Status"))
                    textBoxStatus.Text = row.Cells["Status"].Value.ToString();

                if (row.DataGridView.Columns.Contains("RequestDate"))
                {
                    var requestDate = row.Cells["RequestDate"].Value;
                    textBoxRequestDate.Text = requestDate != DBNull.Value
                        ? Convert.ToDateTime(requestDate).ToShortDateString()
                        : "Not set";
                }

                if (row.DataGridView.Columns.Contains("ApprovalDate"))
                {
                    var approvalDate = row.Cells["ApprovalDate"].Value;
                    textBoxApprovalDate.Text = approvalDate != DBNull.Value
                        ? Convert.ToDateTime(approvalDate).ToShortDateString()
                        : "Not set";
                }

                if (row.DataGridView.Columns.Contains("RequestType"))
                {
                    textBoxRequestType.Text = row.Cells["RequestType"].Value?.ToString() ?? "Not set";
                }

                if (row.DataGridView.Columns.Contains("ProcessedBy"))
                {
                    textBoxProcessedBy.Text = row.Cells["ProcessedBy"].Value?.ToString() ?? "Not set";
                }

                string status = row.DataGridView.Columns.Contains("Status") ? row.Cells["Status"].Value.ToString() : "";

                // Enable buttons based on view
                if (btnLendBook.Visible)
                {
                    btnLendBook.Enabled = status.Equals("Approved", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    btnAccept.Enabled = status.Equals("Pending", StringComparison.OrdinalIgnoreCase);
                    btnDecline.Enabled = status.Equals("Pending", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
    }
}
