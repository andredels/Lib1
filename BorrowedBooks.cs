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
    public partial class BorrowedBooks : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb";
        private int selectedTransactionID = 0;
        private bool isAdmin = false;
        private int currentUserID = 0;

        public BorrowedBooks(bool isAdminUser, int userID)
        {
            InitializeComponent();
            isAdmin = isAdminUser;
            currentUserID = userID;
            dataGridView_BorrowedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StyleDataGridView();
            SetupUIBasedOnUserType();
            LoadBorrowedBooks();
            if (isAdmin)
            {
                LoadStudentNames();
            }
            InitializeSearchControls();
        }
        private void SetupUIBasedOnUserType()
        {
            // Show/hide buttons based on user type
            btnViewAllBookTransactions.Visible = isAdmin;
            btnViewOverdueBooks.Visible = isAdmin;
            btnReturn.Visible = !isAdmin;
            btnCancelBorrowRequest.Visible = !isAdmin;

            // Initially disable action buttons until a row is selected
            btnReturn.Enabled = false;
            btnCancelBorrowRequest.Enabled = false;

            // Show/hide student filter for admin, hide for students
            comboBoxStudentNameSearch.Visible = isAdmin;
            if (comboBoxStudentNameSearch.Parent is Label lblStudentName)
            {
                lblStudentName.Visible = isAdmin;
            }

            // Hide UserID and Full Name fields for students
            if (!isAdmin)
            {
                label1.Visible = false;

                labelUserID.Visible = false;
                textBoxUserID.Visible = false;
                labelFullName.Visible = false;
                textBoxFullName.Visible = false;
            }
        }
        private void LoadBorrowedBooks()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT bt.TransactionID, b.BookID, b.Title, b.Author, b.ISBN, 
                                    g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, 
                                    bt.ProcessedBy, bt.RequestType, bt.RequestDate
                                    FROM (((BookTransactions bt 
                                    INNER JOIN Books b ON bt.BookID = b.BookID)
                                    INNER JOIN Users u ON bt.UserID = u.UserID)
                                    INNER JOIN Genres g ON b.GenreID = g.GenreID)";

                    // If not admin, show both approved and pending books for the current user
                    if (!isAdmin)
                    {
                        query += " WHERE (bt.Status = 'Approved' OR bt.Status = 'Pending') AND bt.UserID = @UserID AND bt.RequestType = 'Borrow'";
                    }
                    else
                    {
                        // For admin, show all currently borrowed books (Approved status)
                        query += " WHERE bt.Status = 'Approved' AND bt.RequestType = 'Borrow' AND bt.ReturnDate >= @CurrentDate";
                    }

                    query += " ORDER BY bt.Status DESC, bt.RequestDate DESC"; // Show pending first, then sort by request date

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        if (!isAdmin)
                        {
                            command.Parameters.AddWithValue("@UserID", currentUserID);
                        }
                        if (isAdmin)
                        {
                            command.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);
                        }

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_BorrowedBooks.DataSource = dataTable;

                        // Configure the DataGridView columns for better display
                        if (dataGridView_BorrowedBooks.Columns.Contains("RequestDate"))
                        {
                            dataGridView_BorrowedBooks.Columns["RequestDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_BorrowedBooks.Columns.Contains("BorrowDate"))
                        {
                            dataGridView_BorrowedBooks.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_BorrowedBooks.Columns.Contains("ReturnDate"))
                        {
                            dataGridView_BorrowedBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

                        // Add row highlighting after setting the data source
                        HighlightRows();
                    }
                }
                StyleDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrowed books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStudentNames()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT u.UserID, u.FullName
                                    FROM (Users u 
                                    INNER JOIN BookTransactions bt ON u.UserID = bt.UserID)
                                    WHERE bt.Status = 'Approved'
                                    ORDER BY u.FullName";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Add an "All Borrowers" option
                    DataRow allRow = dataTable.NewRow();
                    allRow["UserID"] = 0;
                    allRow["FullName"] = "All Borrowers";
                    dataTable.Rows.InsertAt(allRow, 0);

                    comboBoxStudentNameSearch.DataSource = dataTable;
                    comboBoxStudentNameSearch.DisplayMember = "FullName";
                    comboBoxStudentNameSearch.ValueMember = "UserID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student names: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_BorrowedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_BorrowedBooks.Rows[e.RowIndex];

                // Store the selected transaction ID
                selectedTransactionID = Convert.ToInt32(row.Cells["TransactionID"].Value);

                // Fill text boxes with the selected row data
                textBoxBookID.Text = row.Cells["BookID"].Value.ToString();
                textBoxBookTitle.Text = row.Cells["Title"].Value.ToString();
                textBoxAuthor.Text = row.Cells["Author"].Value.ToString();
                textBoxISBN.Text = row.Cells["ISBN"].Value.ToString();
                textBoxGenre.Text = row.Cells["GenreName"].Value.ToString();
                textBoxFullName.Text = row.Cells["FullName"].Value.ToString();

                // Handle potentially null dates
                textBoxBorrowDate.Text = row.Cells["BorrowDate"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["BorrowDate"].Value).ToShortDateString()
                    : "Not borrowed yet";

                textBoxReturnDate.Text = row.Cells["ReturnDate"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["ReturnDate"].Value).ToShortDateString()
                    : "Not set";

                string status = row.Cells["Status"].Value.ToString();
                textBoxStatus.Text = status;
                textBoxProcessedBy.Text = row.Cells["ProcessedBy"].Value != DBNull.Value
                    ? row.Cells["ProcessedBy"].Value.ToString()
                    : "Not processed";

                // Enable/disable buttons based on status and request type
                if (!isAdmin)
                {
                    string requestType = row.Cells["RequestType"].Value.ToString();
                    if (requestType.Equals("Borrow", StringComparison.OrdinalIgnoreCase))
                    {
                        btnReturn.Enabled = status.Equals("Approved", StringComparison.OrdinalIgnoreCase);
                        btnCancelBorrowRequest.Enabled = status.Equals("Pending", StringComparison.OrdinalIgnoreCase);
                    }
                    else
                    {
                        btnReturn.Enabled = false;
                        btnCancelBorrowRequest.Enabled = false;
                    }
                }

                // Get UserID for the selected transaction
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID FROM BookTransactions WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        textBoxUserID.Text = command.ExecuteScalar().ToString();
                    }
                }
            }
        }

        private void comboBoxStudentNameSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Don't proceed if triggered during initialization or if nothing is selected
                if (comboBoxStudentNameSearch.SelectedIndex == -1)
                    return;

                // Get the selected value correctly using DataRowView
                DataRowView drv = comboBoxStudentNameSearch.SelectedItem as DataRowView;
                if (drv == null) return;

                int selectedUserID = Convert.ToInt32(drv["UserID"]);

                // Debug information
                Console.WriteLine($"Selected UserID: {selectedUserID}");

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
                            WHERE bt.Status = 'Approved' AND bt.RequestType = 'Borrow'";

                    // If a specific user is selected (not "All Borrowers")
                    if (selectedUserID > 0)
                    {
                        query += " AND bt.UserID = @UserID";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        if (selectedUserID > 0)
                        {
                            command.Parameters.AddWithValue("@UserID", selectedUserID);
                        }

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Set data source
                        dataGridView_BorrowedBooks.DataSource = null; // Clear first to force refresh
                        dataGridView_BorrowedBooks.DataSource = dataTable;

                        // Report on number of rows for debugging
                        Console.WriteLine($"Query returned {dataTable.Rows.Count} rows");

                        // Re-apply formatting
                        if (dataGridView_BorrowedBooks.Columns.Contains("BorrowDate"))
                        {
                            dataGridView_BorrowedBooks.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_BorrowedBooks.Columns.Contains("ReturnDate"))
                        {
                            dataGridView_BorrowedBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

                        // Re-apply row highlighting
                        HighlightRows();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering by student: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAllBookTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT bt.TransactionID, b.BookID, b.Title, b.Author, b.ISBN, 
                            g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, 
                            bt.ProcessedBy, bt.RequestType, bt.RequestDate
                            FROM (((BookTransactions bt 
                            INNER JOIN Books b ON bt.BookID = b.BookID)
                            INNER JOIN Users u ON bt.UserID = u.UserID)
                            INNER JOIN Genres g ON b.GenreID = g.GenreID)
                            WHERE bt.RequestType = 'Borrow'
                            ORDER BY bt.Status DESC, bt.RequestDate DESC";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView_BorrowedBooks.DataSource = dataTable;

                    // Configure the DataGridView columns for better display
                    if (dataGridView_BorrowedBooks.Columns.Contains("RequestDate"))
                    {
                        dataGridView_BorrowedBooks.Columns["RequestDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    }
                    if (dataGridView_BorrowedBooks.Columns.Contains("BorrowDate"))
                    {
                        dataGridView_BorrowedBooks.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    }
                    if (dataGridView_BorrowedBooks.Columns.Contains("ReturnDate"))
                    {
                        dataGridView_BorrowedBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    }

                    // Re-initialize search controls for the new data
                    LoadBookNamesIntoComboBox();

                    // Clear any existing search
                    textBoxBorrowedBookSearch.Text = string.Empty;

                    // Re-apply row highlighting
                    HighlightRows();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading all book transactions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewOverdueBooks_Click(object sender, EventArgs e)
        {
            try
            {
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
                            WHERE bt.Status = 'Approved' AND bt.ReturnDate < @CurrentDate 
                            AND bt.RequestType = 'Borrow'";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_BorrowedBooks.DataSource = dataTable;

                        // Re-initialize search controls for the new data
                        LoadBookNamesIntoComboBox();

                        // Clear any existing search
                        textBoxBorrowedBookSearch.Text = string.Empty;

                        // Re-apply row highlighting
                        HighlightRows();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading overdue books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedTransactionID == 0)
            {
                MessageBox.Show("Please select a book transaction first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verify the status is "Approved" before proceeding
            if (!textBoxStatus.Text.Equals("Approved", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Only currently borrowed books can be returned.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // First get the book ID and return date to update available copies and check for fines
                    int bookID = 0;
                    DateTime returnDate = DateTime.Now; // Default value
                    bool hasReturnDate = false;

                    // Debug: Verify selected transaction ID
                    Console.WriteLine($"Processing return for TransactionID: {selectedTransactionID}");

                    string getInfoQuery = "SELECT BookID, ReturnDate FROM BookTransactions WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(getInfoQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bookID = Convert.ToInt32(reader["BookID"]);
                                Console.WriteLine($"Found BookID: {bookID}");

                                if (reader["ReturnDate"] != DBNull.Value)
                                {
                                    returnDate = Convert.ToDateTime(reader["ReturnDate"]);
                                    hasReturnDate = true;
                                    Console.WriteLine($"Expected Return Date: {returnDate.ToShortDateString()}");
                                }
                                else
                                {
                                    Console.WriteLine("No return date set");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No record found for this TransactionID");
                            }
                        }
                    }

                    // Calculate fine if the book is returned late
                    int fineAmount = 0;
                    DateTime currentDate = DateTime.Now.Date;
                    Console.WriteLine($"Current Date: {currentDate.ToShortDateString()}");

                    if (hasReturnDate && currentDate > returnDate)
                    {
                        // Calculate days overdue
                        TimeSpan daysLate = currentDate - returnDate;
                        int daysOverdue = (int)daysLate.TotalDays;

                        // Calculate fine (5 pesos per day overdue)
                        fineAmount = daysOverdue * 5;

                        Console.WriteLine($"Book is {daysOverdue} days overdue. Fine calculated: ₱{fineAmount}");

                        // Show fine information to the user
                        DialogResult result = MessageBox.Show(
                            $"This book is returned {daysOverdue} day(s) late.\n" +
                            $"Fine amount: ₱{fineAmount}\n\n" +
                            "Do you want to proceed with the return?",
                            "Late Return",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            Console.WriteLine("User cancelled return operation");
                            return; // User cancelled the return operation
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book is not overdue. No fine.");
                    }

                    // Update transaction status to "Returned" and set FineAmount
                    Console.WriteLine($"Updating transaction with Status='Returned' and FineAmount={fineAmount}");

                    // Use parameterized query for safety and correctness
                    string updateStatusQuery = @"UPDATE BookTransactions 
                                      SET Status = 'Returned', FineAmount = ? 
                                      WHERE TransactionID = ?";

                    using (OleDbCommand command = new OleDbCommand(updateStatusQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", fineAmount);
                        command.Parameters.AddWithValue("?", selectedTransactionID);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Update affected {rowsAffected} rows");

                        if (rowsAffected > 0)
                        {
                            // Increase available copies in the Books table
                            string updateBookQuery = @"UPDATE Books 
                                           SET AvailableCopies = AvailableCopies + 1 
                                           WHERE BookID = ?";

                            using (OleDbCommand bookCommand = new OleDbCommand(updateBookQuery, connection))
                            {
                                bookCommand.Parameters.AddWithValue("?", bookID);
                                int booksUpdated = bookCommand.ExecuteNonQuery();
                                Console.WriteLine($"Book update affected {booksUpdated} rows");
                            }

                            // Double check the update was successful
                            string verifyQuery = "SELECT Status, FineAmount FROM BookTransactions WHERE TransactionID = ?";
                            using (OleDbCommand verifyCommand = new OleDbCommand(verifyQuery, connection))
                            {
                                verifyCommand.Parameters.AddWithValue("?", selectedTransactionID);
                                using (OleDbDataReader reader = verifyCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string status = reader["Status"].ToString();
                                        int fine = Convert.ToInt32(reader["FineAmount"]);
                                        Console.WriteLine($"Verified update: Status={status}, FineAmount={fine}");
                                    }
                                }
                            }

                            // Show appropriate message based on whether a fine was charged
                            if (fineAmount > 0)
                            {
                                MessageBox.Show($"Book returned successfully!\nFine of ₱{fineAmount} has been recorded.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Book returned successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            // Refresh the data
                            LoadBorrowedBooks();

                            // Clear the selection
                            ClearSelection();
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Please try again.",
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show("Error returning book: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelBorrowRequest_Click(object sender, EventArgs e)
        {
            if (selectedTransactionID == 0)
            {
                MessageBox.Show("Please select a book transaction first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verify the status is "Pending" and RequestType is "Borrow" before proceeding
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string checkQuery = "SELECT Status, RequestType FROM BookTransactions WHERE TransactionID = @TransactionID";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        using (OleDbDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status = reader["Status"].ToString();
                                string requestType = reader["RequestType"].ToString();

                                if (!status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Only pending requests can be cancelled.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                if (!requestType.Equals("Borrow", StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("This is not a borrow request.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }

                    // First get the book ID and current status
                    int bookID = 0;
                    string currentStatus = "";
                    string getBookInfoQuery = "SELECT BookID, Status FROM BookTransactions WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(getBookInfoQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bookID = Convert.ToInt32(reader["BookID"]);
                                currentStatus = reader["Status"].ToString();
                            }
                        }
                    }

                    // Update transaction status to "Cancelled"
                    string updateStatusQuery = @"UPDATE BookTransactions 
                                              SET Status = 'Cancelled' 
                                              WHERE TransactionID = @TransactionID";

                    using (OleDbCommand command = new OleDbCommand(updateStatusQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Only increase available copies if the status was "Approved"
                            // For "Pending" requests, we don't need to modify the available copies
                            if (currentStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                            {
                                string updateBookQuery = @"UPDATE Books 
                                                       SET AvailableCopies = AvailableCopies + 1 
                                                       WHERE BookID = @BookID";

                                using (OleDbCommand bookCommand = new OleDbCommand(updateBookQuery, connection))
                                {
                                    bookCommand.Parameters.AddWithValue("@BookID", bookID);
                                    bookCommand.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Request cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the data
                            LoadBorrowedBooks();

                            // Clear the selection
                            ClearSelection();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling request: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearSelection()
        {
            selectedTransactionID = 0;
            textBoxUserID.Text = string.Empty;
            textBoxBookTitle.Text = string.Empty;
            textBoxBookID.Text = string.Empty;
            textBoxFullName.Text = string.Empty;
            textBoxAuthor.Text = string.Empty;
            textBoxISBN.Text = string.Empty;
            textBoxBorrowDate.Text = string.Empty;
            textBoxGenre.Text = string.Empty;
            textBoxReturnDate.Text = string.Empty;
            textBoxStatus.Text = string.Empty;
            textBoxProcessedBy.Text = string.Empty;

            // Disable action buttons when selection is cleared
            if (!isAdmin)
            {
                btnReturn.Enabled = false;
                btnCancelBorrowRequest.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBorrowedBooks();
            if (isAdmin)
            {
                LoadStudentNames();
            }
            LoadBookNamesIntoComboBox(); // Re-initialize book search
            textBoxBorrowedBookSearch.Text = string.Empty; // Clear search box
            ClearSelection();
        }

        private void HighlightRows()
        {
            foreach (DataGridViewRow row in dataGridView_BorrowedBooks.Rows)
            {
                // First check if the status is Pending
                if (row.Cells["Status"].Value != null && row.Cells["Status"].Value.ToString() == "Pending")
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    continue; // Skip date checking for pending requests
                }

                // Only check dates for non-pending (approved) books
                if (row.Cells["ReturnDate"].Value != null && row.Cells["ReturnDate"].Value != DBNull.Value)
                {
                    DateTime returnDate = Convert.ToDateTime(row.Cells["ReturnDate"].Value);
                    DateTime currentDate = DateTime.Now.Date;
                    TimeSpan daysUntilReturn = returnDate - currentDate;

                    if (returnDate < currentDate)
                    {
                        // Overdue books - highlight in red
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (daysUntilReturn.TotalDays <= 3)
                    {
                        // Books due within 3 days - highlight in yellow
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void LoadBookNamesIntoComboBox()
        {
            try
            {
                // Clear existing items
                comboBoxBookSearch.Items.Clear();

                // Add "All Books" option
                comboBoxBookSearch.Items.Add("All Books");

                // Get the DataTable from the DataGridView
                DataTable dt = null;

                if (dataGridView_BorrowedBooks.DataSource is DataTable)
                {
                    dt = (DataTable)dataGridView_BorrowedBooks.DataSource;
                }
                else if (dataGridView_BorrowedBooks.DataSource is DataView)
                {
                    dt = ((DataView)dataGridView_BorrowedBooks.DataSource).Table;
                }

                // Check if DataSource is valid
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Create a HashSet to avoid duplicate book titles
                    HashSet<string> bookTitles = new HashSet<string>();

                    // Make sure the Title column exists
                    if (dt.Columns.Contains("Title"))
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["Title"] != DBNull.Value)
                            {
                                string title = row["Title"].ToString();
                                if (!string.IsNullOrEmpty(title) && !bookTitles.Contains(title))
                                {
                                    bookTitles.Add(title);
                                    comboBoxBookSearch.Items.Add(title);
                                }
                            }
                        }
                    }
                }

                // Select "All Books" by default
                if (comboBoxBookSearch.Items.Count > 0)
                {
                    comboBoxBookSearch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading book titles: " + ex.Message);
                // Don't show an error dialog as this might be called frequently
            }
        }

        private void comboBoxBookSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Don't proceed if triggered during initialization or if nothing is selected
                if (comboBoxBookSearch.SelectedIndex == -1)
                    return;

                // Get the selected book
                string selectedBook = comboBoxBookSearch.SelectedItem.ToString();

                // Get the DataTable from the DataGridView
                if (dataGridView_BorrowedBooks.DataSource == null)
                    return;

                DataTable dt = (dataGridView_BorrowedBooks.DataSource as DataTable) ??
                               ((dataGridView_BorrowedBooks.DataSource as DataView)?.Table);

                if (dt == null)
                    return;

                // Create a new DataView from the DataTable
                DataView dv = new DataView(dt);

                // If "All Books" is selected, show all books
                if (selectedBook == "All Books")
                {
                    dv.RowFilter = string.Empty; // Clear any filter
                }
                else
                {
                    // Filter the DataView to show only the selected book
                    // Use "Title" instead of "BookName"
                    dv.RowFilter = $"Title = '{selectedBook.Replace("'", "''")}'";
                }

                // Apply the filtered DataView to the DataGridView
                dataGridView_BorrowedBooks.DataSource = dv;

                // Re-apply row highlighting after filtering
                HighlightRows();

                // Debug message to verify the event fired
                Console.WriteLine($"Book filter applied: {selectedBook}, Rows: {dv.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBorrowedBookSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBoxBorrowedBookSearch.Text.Trim();

                // Get the DataTable from the DataGridView
                if (dataGridView_BorrowedBooks.DataSource == null)
                    return;

                DataTable dt = (dataGridView_BorrowedBooks.DataSource as DataTable) ??
                               ((dataGridView_BorrowedBooks.DataSource as DataView)?.Table);

                if (dt == null)
                    return;

                // Create a new DataView from the DataTable (create a fresh one each time)
                DataView dv = new DataView(dt);

                if (string.IsNullOrEmpty(searchText))
                {
                    dv.RowFilter = string.Empty; // Show all if search is empty
                }
                else
                {
                    // Escape single quotes in the search text to prevent SQL injection
                    searchText = searchText.Replace("'", "''");

                    // Build a filter string that searches across multiple columns
                    // Using the actual column names from your SQL query
                    string filterString = $"Title LIKE '%{searchText}%' OR " +
                                          $"Author LIKE '%{searchText}%' OR " +
                                          $"ISBN LIKE '%{searchText}%' OR " +
                                          $"FullName LIKE '%{searchText}%' OR " +
                                          $"Status LIKE '%{searchText}%' OR " +
                                          $"GenreName LIKE '%{searchText}%'";

                    // Apply the filter
                    dv.RowFilter = filterString;
                }

                // Debug info
                Console.WriteLine($"Search filter applied: '{searchText}', Rows: {dv.Count}");

                // Apply the filtered DataView to the DataGridView - force refresh
                dataGridView_BorrowedBooks.DataSource = null;
                dataGridView_BorrowedBooks.DataSource = dv;

                // Re-apply row highlighting after filtering
                HighlightRows();
            }
            catch (Exception ex)
            {
                // Some filtering expressions might fail, don't show errors for every keystroke
                Console.WriteLine("Error searching books: " + ex.Message);
                // Reset the filter if there's an error
                try
                {
                    if (dataGridView_BorrowedBooks.DataSource is DataView originalView)
                    {
                        originalView.RowFilter = string.Empty;
                    }
                }
                catch { }
            }
        }
        private void InitializeSearchControls()
        {
            try
            {
                // Load book names into combobox
                LoadBookNamesIntoComboBox();

                // Set the ComboBoxes to read-only mode
                comboBoxBookSearch.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxStudentNameSearch.DropDownStyle = ComboBoxStyle.DropDownList;

                // Remove any existing event handlers to prevent duplicates
                comboBoxBookSearch.SelectedIndexChanged -= comboBoxBookSearch_SelectedIndexChanged;
                comboBoxStudentNameSearch.SelectedIndexChanged -= comboBoxStudentNameSearch_SelectedIndexChanged;
                textBoxBorrowedBookSearch.TextChanged -= textBoxBorrowedBookSearch_TextChanged;

                // Re-add event handlers
                comboBoxBookSearch.SelectedIndexChanged += comboBoxBookSearch_SelectedIndexChanged;
                comboBoxStudentNameSearch.SelectedIndexChanged += comboBoxStudentNameSearch_SelectedIndexChanged;
                textBoxBorrowedBookSearch.TextChanged += textBoxBorrowedBookSearch_TextChanged;

                // Force the initial selection if needed
                if (comboBoxBookSearch.Items.Count > 0 && comboBoxBookSearch.SelectedIndex == -1)
                {
                    comboBoxBookSearch.SelectedIndex = 0;
                }

                if (comboBoxStudentNameSearch.Items.Count > 0 && comboBoxStudentNameSearch.SelectedIndex == -1)
                {
                    comboBoxStudentNameSearch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing search controls: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StyleDataGridView()
        {
            dataGridView_BorrowedBooks.EnableHeadersVisualStyles = false;
            dataGridView_BorrowedBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dataGridView_BorrowedBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_BorrowedBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView_BorrowedBooks.RowHeadersVisible = false;
            dataGridView_BorrowedBooks.BorderStyle = BorderStyle.None;
            dataGridView_BorrowedBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_BorrowedBooks.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView_BorrowedBooks.RowTemplate.Height = 35;
            dataGridView_BorrowedBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView_BorrowedBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridView_BorrowedBooks.DefaultCellStyle.SelectionForeColor = Color.White;
        }

    }
}
