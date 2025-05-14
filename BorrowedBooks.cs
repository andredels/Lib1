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
            btnViewAllBookTransactions.Visible = isAdmin;
            btnViewOverdueBooks.Visible = isAdmin;
            btnReturn.Visible = !isAdmin;
            btnCancelBorrowRequest.Visible = !isAdmin;

            btnReturn.Enabled = false;
            btnCancelBorrowRequest.Enabled = false;

            comboBoxStudentNameSearch.Visible = isAdmin;
            if (comboBoxStudentNameSearch.Parent is Label lblStudentName)
            {
                lblStudentName.Visible = isAdmin;
            }

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

                    if (!isAdmin)
                    {
                        query += " WHERE (bt.Status = 'Approved' OR bt.Status = 'Pending') AND bt.UserID = @UserID AND bt.RequestType = 'Borrow'";
                    }
                    else
                    {
                        query += " WHERE bt.Status = 'Approved' AND bt.RequestType = 'Borrow' AND bt.ReturnDate >= @CurrentDate";
                    }

                    query += " ORDER BY bt.Status DESC, bt.RequestDate DESC"; 

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

                selectedTransactionID = Convert.ToInt32(row.Cells["TransactionID"].Value);

                textBoxBookID.Text = row.Cells["BookID"].Value.ToString();
                textBoxBookTitle.Text = row.Cells["Title"].Value.ToString();
                textBoxAuthor.Text = row.Cells["Author"].Value.ToString();
                textBoxISBN.Text = row.Cells["ISBN"].Value.ToString();
                textBoxGenre.Text = row.Cells["GenreName"].Value.ToString();
                textBoxFullName.Text = row.Cells["FullName"].Value.ToString();

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
                if (comboBoxStudentNameSearch.SelectedIndex == -1)
                    return;

                DataRowView drv = comboBoxStudentNameSearch.SelectedItem as DataRowView;
                if (drv == null) return;

                int selectedUserID = Convert.ToInt32(drv["UserID"]);

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

                        dataGridView_BorrowedBooks.DataSource = null; 
                        dataGridView_BorrowedBooks.DataSource = dataTable;

                        Console.WriteLine($"Query returned {dataTable.Rows.Count} rows");

                        if (dataGridView_BorrowedBooks.Columns.Contains("BorrowDate"))
                        {
                            dataGridView_BorrowedBooks.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_BorrowedBooks.Columns.Contains("ReturnDate"))
                        {
                            dataGridView_BorrowedBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

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

                    LoadBookNamesIntoComboBox();

                    textBoxBorrowedBookSearch.Text = string.Empty;

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

                        LoadBookNamesIntoComboBox();

                        textBoxBorrowedBookSearch.Text = string.Empty;

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

                    int bookID = 0;
                    DateTime returnDate = DateTime.Now;
                    bool hasReturnDate = false;

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

                    int fineAmount = 0;
                    DateTime currentDate = DateTime.Now.Date;
                    Console.WriteLine($"Current Date: {currentDate.ToShortDateString()}");

                    if (hasReturnDate && currentDate > returnDate)
                    {
                        TimeSpan daysLate = currentDate - returnDate;
                        int daysOverdue = (int)daysLate.TotalDays;

                        fineAmount = daysOverdue * 5;

                        Console.WriteLine($"Book is {daysOverdue} days overdue. Fine calculated: ₱{fineAmount}");

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
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book is not overdue. No fine.");
                    }

                    Console.WriteLine($"Updating transaction with Status='Returned' and FineAmount={fineAmount}");

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
                            string updateBookQuery = @"UPDATE Books 
                                           SET AvailableCopies = AvailableCopies + 1 
                                           WHERE BookID = ?";

                            using (OleDbCommand bookCommand = new OleDbCommand(updateBookQuery, connection))
                            {
                                bookCommand.Parameters.AddWithValue("?", bookID);
                                int booksUpdated = bookCommand.ExecuteNonQuery();
                                Console.WriteLine($"Book update affected {booksUpdated} rows");
                            }

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

                            LoadBorrowedBooks();
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

                    string updateStatusQuery = @"UPDATE BookTransactions 
                                              SET Status = 'Cancelled' 
                                              WHERE TransactionID = @TransactionID";

                    using (OleDbCommand command = new OleDbCommand(updateStatusQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
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

                            LoadBorrowedBooks();
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
            LoadBookNamesIntoComboBox(); 
            textBoxBorrowedBookSearch.Text = string.Empty; 
            ClearSelection();
        }

        private void HighlightRows()
        {
            foreach (DataGridViewRow row in dataGridView_BorrowedBooks.Rows)
            {
                if (row.Cells["Status"].Value != null && row.Cells["Status"].Value.ToString() == "Pending")
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    continue; 
                }

                if (row.Cells["ReturnDate"].Value != null && row.Cells["ReturnDate"].Value != DBNull.Value)
                {
                    DateTime returnDate = Convert.ToDateTime(row.Cells["ReturnDate"].Value);
                    DateTime currentDate = DateTime.Now.Date;
                    TimeSpan daysUntilReturn = returnDate - currentDate;

                    if (returnDate < currentDate)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (daysUntilReturn.TotalDays <= 3)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void LoadBookNamesIntoComboBox()
        {
            try
            {
                comboBoxBookSearch.Items.Clear();
                comboBoxBookSearch.Items.Add("All Books");

                DataTable dt = null;

                if (dataGridView_BorrowedBooks.DataSource is DataTable)
                {
                    dt = (DataTable)dataGridView_BorrowedBooks.DataSource;
                }
                else if (dataGridView_BorrowedBooks.DataSource is DataView)
                {
                    dt = ((DataView)dataGridView_BorrowedBooks.DataSource).Table;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    HashSet<string> bookTitles = new HashSet<string>();
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

                if (comboBoxBookSearch.Items.Count > 0)
                {
                    comboBoxBookSearch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading book titles: " + ex.Message);
            }
        }

        private void comboBoxBookSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxBookSearch.SelectedIndex == -1)
                    return;

                string selectedBook = comboBoxBookSearch.SelectedItem.ToString();

                if (dataGridView_BorrowedBooks.DataSource == null)
                    return;

                DataTable dt = (dataGridView_BorrowedBooks.DataSource as DataTable) ??
                               ((dataGridView_BorrowedBooks.DataSource as DataView)?.Table);

                if (dt == null)
                    return;

                DataView dv = new DataView(dt);

                if (selectedBook == "All Books")
                {
                    dv.RowFilter = string.Empty; 
                }
                else
                {

                    dv.RowFilter = $"Title = '{selectedBook.Replace("'", "''")}'";
                }

                dataGridView_BorrowedBooks.DataSource = dv;
                HighlightRows();
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

                if (dataGridView_BorrowedBooks.DataSource == null)
                    return;

                DataTable dt = (dataGridView_BorrowedBooks.DataSource as DataTable) ??
                               ((dataGridView_BorrowedBooks.DataSource as DataView)?.Table);

                if (dt == null)
                    return;

                DataView dv = new DataView(dt);

                if (string.IsNullOrEmpty(searchText))
                {
                    dv.RowFilter = string.Empty;
                }
                else
                {
                    searchText = searchText.Replace("'", "''");

                    string filterString = $"Title LIKE '%{searchText}%' OR " +
                                          $"Author LIKE '%{searchText}%' OR " +
                                          $"ISBN LIKE '%{searchText}%' OR " +
                                          $"FullName LIKE '%{searchText}%' OR " +
                                          $"Status LIKE '%{searchText}%' OR " +
                                          $"GenreName LIKE '%{searchText}%'";

                    dv.RowFilter = filterString;
                }

                Console.WriteLine($"Search filter applied: '{searchText}', Rows: {dv.Count}");

                dataGridView_BorrowedBooks.DataSource = null;
                dataGridView_BorrowedBooks.DataSource = dv;

                HighlightRows();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching books: " + ex.Message);
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
                LoadBookNamesIntoComboBox();

                comboBoxBookSearch.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxStudentNameSearch.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxBookSearch.SelectedIndexChanged -= comboBoxBookSearch_SelectedIndexChanged;
                comboBoxStudentNameSearch.SelectedIndexChanged -= comboBoxStudentNameSearch_SelectedIndexChanged;
                textBoxBorrowedBookSearch.TextChanged -= textBoxBorrowedBookSearch_TextChanged;

                comboBoxBookSearch.SelectedIndexChanged += comboBoxBookSearch_SelectedIndexChanged;
                comboBoxStudentNameSearch.SelectedIndexChanged += comboBoxStudentNameSearch_SelectedIndexChanged;
                textBoxBorrowedBookSearch.TextChanged += textBoxBorrowedBookSearch_TextChanged;

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
