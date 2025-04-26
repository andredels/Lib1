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
            SetupUIBasedOnUserType();
            LoadBorrowedBooks();
            if (isAdmin)
            {
                LoadStudentNames();
            }
        }
        private void SetupUIBasedOnUserType()
        {
            // Show/hide buttons based on user type
            btnViewAllBookTransactions.Visible = isAdmin;
            btnViewOverdueBooks.Visible = isAdmin;
            btnReturn.Visible = !isAdmin;
            btnCancelBorrowRequest.Visible = !isAdmin;

            // Show/hide student filter for admin, hide for students
            comboBoxStudentNameSearch.Visible = isAdmin;
            if (comboBoxStudentNameSearch.Parent is Label lblStudentName)
            {
                lblStudentName.Visible = isAdmin;
            }

            // Hide UserID and Full Name fields for students
            if (!isAdmin)
            {
                if (textBoxUserID != null && textBoxUserID.Parent is Label lblUserID)
                {
                    lblUserID.Visible = false;
                }
                textBoxUserID.Visible = false;

                if (textBoxFullName != null && textBoxFullName.Parent is Label lblFullName)
                {
                    lblFullName.Visible = false;
                }
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

                    string query = @"SELECT bt.TransactionID, b.BookID, b.Title, b.Author, b.ISBN, 
                                    g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, bt.ProcessedBy
                                    FROM (((BookTransactions bt 
                                    INNER JOIN Books b ON bt.BookID = b.BookID)
                                    INNER JOIN Users u ON bt.UserID = u.UserID)
                                    INNER JOIN Genres g ON b.GenreID = g.GenreID)
                                    WHERE bt.Status = 'Approved'";

                    // If not admin, only show the current user's books
                    if (!isAdmin)
                    {
                        query += " AND bt.UserID = @UserID";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        if (!isAdmin)
                        {
                            command.Parameters.AddWithValue("@UserID", currentUserID);
                        }

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_BorrowedBooks.DataSource = dataTable;

                        // Add row highlighting after setting the data source
                        HighlightRows();
                    }
                }
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
                textBoxBorrowDate.Text = Convert.ToDateTime(row.Cells["BorrowDate"].Value).ToShortDateString();
                textBoxReturnDate.Text = Convert.ToDateTime(row.Cells["ReturnDate"].Value).ToShortDateString();
                textBoxStatus.Text = row.Cells["Status"].Value.ToString();
                textBoxProcessedBy.Text = row.Cells["ProcessedBy"].Value.ToString();

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
                // Fixed: Get the selected value correctly using DataRowView
                DataRowView drv = comboBoxStudentNameSearch.SelectedItem as DataRowView;
                if (drv == null) return;

                int selectedUserID = Convert.ToInt32(drv["UserID"]);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT bt.TransactionID, b.BookID, b.Title, b.Author, b.ISBN, 
                                    g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, bt.ProcessedBy
                                    FROM (((BookTransactions bt 
                                    INNER JOIN Books b ON bt.BookID = b.BookID)
                                    INNER JOIN Users u ON bt.UserID = u.UserID)
                                    INNER JOIN Genres g ON b.GenreID = g.GenreID)
                                    WHERE bt.Status = 'Approved'";

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

                        dataGridView_BorrowedBooks.DataSource = dataTable;
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

                    string query = @"SELECT bt.TransactionID, b.BookID, b.Title, b.Author, b.ISBN, 
                                    g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, bt.ProcessedBy
                                    FROM (((BookTransactions bt 
                                    INNER JOIN Books b ON bt.BookID = b.BookID)
                                    INNER JOIN Users u ON bt.UserID = u.UserID)
                                    INNER JOIN Genres g ON b.GenreID = g.GenreID)";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView_BorrowedBooks.DataSource = dataTable;
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
                                    g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, bt.ProcessedBy
                                    FROM (((BookTransactions bt 
                                    INNER JOIN Books b ON bt.BookID = b.BookID)
                                    INNER JOIN Users u ON bt.UserID = u.UserID)
                                    INNER JOIN Genres g ON b.GenreID = g.GenreID)
                                    WHERE bt.Status = 'Approved' AND bt.ReturnDate < @CurrentDate";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_BorrowedBooks.DataSource = dataTable;
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

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // First get the book ID to update available copies
                    int bookID = 0;
                    string getBookIDQuery = "SELECT BookID FROM BookTransactions WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(getBookIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        bookID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Update transaction status to "Returned"
                    string updateStatusQuery = @"UPDATE BookTransactions 
                                              SET Status = 'Returned' 
                                              WHERE TransactionID = @TransactionID";

                    using (OleDbCommand command = new OleDbCommand(updateStatusQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Increase available copies in the Books table
                            string updateBookQuery = @"UPDATE Books 
                                                   SET AvailableCopies = AvailableCopies + 1 
                                                   WHERE BookID = @BookID";

                            using (OleDbCommand bookCommand = new OleDbCommand(updateBookQuery, connection))
                            {
                                bookCommand.Parameters.AddWithValue("@BookID", bookID);
                                bookCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // First get the book ID to update available copies
                    int bookID = 0;
                    string getBookIDQuery = "SELECT BookID FROM BookTransactions WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(getBookIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        bookID = Convert.ToInt32(command.ExecuteScalar());
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
                            // Increase available copies in the Books table
                            string updateBookQuery = @"UPDATE Books 
                                                   SET AvailableCopies = AvailableCopies + 1 
                                                   WHERE BookID = @BookID";

                            using (OleDbCommand bookCommand = new OleDbCommand(updateBookQuery, connection))
                            {
                                bookCommand.Parameters.AddWithValue("@BookID", bookID);
                                bookCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Borrow request cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Error cancelling borrow request: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBorrowedBooks();
            LoadStudentNames();
            ClearSelection();
        }

        private void HighlightRows()
        {
            foreach (DataGridViewRow row in dataGridView_BorrowedBooks.Rows)
            {
                if (row.Cells["ReturnDate"].Value != null)
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
    }
}
