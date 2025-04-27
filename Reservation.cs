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
        private bool isAdmin = false;
        private int currentUserID = 0;
        private string adminFullName;  // Add field for admin name
        public Reservation(bool isAdminUser, int userID)
        {
            InitializeComponent();
            isAdmin = isAdminUser;
            currentUserID = userID;
            dataGridView_ReservedBooks.AutoGenerateColumns = true;

            // Get the admin's full name from the database
            if (isAdmin)
            {
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

            SetupUIBasedOnUserType();
            LoadReservedBooks();
            if (isAdmin)
            {
                LoadStudentNames();
            }
        }
        private void SetupUIBasedOnUserType()
        {
            // Show/hide buttons based on user type
            btnAccept.Visible = false;
            btnDecline.Visible = false;
            btnLendBook.Visible = true;
            btnViewReservationRequests.Visible = isAdmin;

            // Initially disable action buttons until a row is selected
            btnLendBook.Enabled = false;
            btnAccept.Enabled = false;
            btnDecline.Enabled = false;

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
        private void LoadReservedBooks()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT bt.TransactionID, bt.UserID, b.BookID, b.Title, b.ISBN, 
                                   b.AvailableCopies, b.TotalCopies, bt.RequestDate, bt.ApprovalDate,
                                   bt.Status, bt.ProcessedBy, bt.RequestType, u.FullName
                                   FROM ((BookTransactions bt 
                                   INNER JOIN Books b ON bt.BookID = b.BookID)
                                   INNER JOIN Users u ON bt.UserID = u.UserID)
                                   WHERE bt.RequestType = 'Reservation'";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView_ReservedBooks.DataSource = null;
                            dataGridView_ReservedBooks.DataSource = dataTable;

                            // Format date columns
                            if (dataGridView_ReservedBooks.Columns.Contains("RequestDate"))
                            {
                                dataGridView_ReservedBooks.Columns["RequestDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                            }
                            if (dataGridView_ReservedBooks.Columns.Contains("ApprovalDate"))
                            {
                                dataGridView_ReservedBooks.Columns["ApprovalDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                            }

                            // Hide unnecessary columns
                            if (dataGridView_ReservedBooks.Columns.Contains("BorrowDate"))
                                dataGridView_ReservedBooks.Columns["BorrowDate"].Visible = false;
                            if (dataGridView_ReservedBooks.Columns.Contains("ReturnDate"))
                                dataGridView_ReservedBooks.Columns["ReturnDate"].Visible = false;

                            dataGridView_ReservedBooks.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reserved books: {ex.Message}\nStack trace: {ex.StackTrace}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                        dataGridView_ReservedBooks.DataSource = dataTable;

                        // Configure the DataGridView columns for better display
                        if (dataGridView_ReservedBooks.Columns.Contains("RequestDate"))
                        {
                            dataGridView_ReservedBooks.Columns["RequestDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_ReservedBooks.Columns.Contains("BorrowDate"))
                        {
                            dataGridView_ReservedBooks.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_ReservedBooks.Columns.Contains("ReturnDate"))
                        {
                            dataGridView_ReservedBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
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
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT u.UserID, u.FullName
                                    FROM (Users u 
                                    INNER JOIN BookTransactions bt ON u.UserID = bt.UserID)
                                    WHERE bt.RequestType = 'Reservation'
                                    ORDER BY u.FullName";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Add an "All Students" option
                    DataRow allRow = dataTable.NewRow();
                    allRow["UserID"] = 0;
                    allRow["FullName"] = "All Students";
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
            LoadPendingReservationRequests();
            ClearSelection();
        }

        private void comboBoxStudentNameSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = comboBoxStudentNameSearch.SelectedItem as DataRowView;
                if (drv == null) return;

                int selectedUserID = Convert.ToInt32(drv["UserID"]);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT bt.TransactionID, b.BookID, b.Title, b.ISBN, 
                                    g.GenreName, u.FullName, bt.BorrowDate, bt.ReturnDate, bt.Status, 
                                    bt.ProcessedBy, bt.RequestType
                                    FROM (((BookTransactions bt 
                                    INNER JOIN Books b ON bt.BookID = b.BookID)
                                    INNER JOIN Users u ON bt.UserID = u.UserID)
                                    INNER JOIN Genres g ON b.GenreID = g.GenreID)
                                    WHERE bt.RequestType = 'Reservation'";

                    if (selectedUserID > 0)
                    {
                        query += " AND bt.UserID = @UserID";
                    }

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
                        if (selectedUserID > 0)
                        {
                            command.Parameters.AddWithValue("@UserID", selectedUserID);
                        }

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_ReservedBooks.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering by student: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    if (!isAdmin)
                    {
                        query += " AND bt.UserID = @UserID";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        if (!isAdmin)
                        {
                            command.Parameters.AddWithValue("@UserID", currentUserID);
                        }

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_ReservedBooks.DataSource = dataTable;
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
            if (isAdmin)
            {
                LoadStudentNames();
            }
            ClearSelection();
            btnAccept.Visible = false;
            btnDecline.Visible = false;
            btnLendBook.Visible = true;

        }

        private void dataGridView_ReservedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_ReservedBooks.Rows[e.RowIndex];

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
                    textBoxRequestType.Text = row.Cells["RequestType"].Value.ToString();

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

            btnLendBook.Enabled = false;
            btnAccept.Enabled = false;
            btnDecline.Enabled = false;
        }

    }
}
