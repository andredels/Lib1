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

                    // Use the ReservedBooks query directly
                    string query = "SELECT * FROM ReservedBooks";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_ReservedBooks.DataSource = dataTable;

                        // Configure date formatting for display
                        foreach (string dateColumn in new[] { "RequestDate", "ApprovalDate" })
                        {
                            if (dataGridView_ReservedBooks.Columns.Contains(dateColumn))
                            {
                                dataGridView_ReservedBooks.Columns[dateColumn].DefaultCellStyle.Format = "MM/dd/yyyy";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reserved books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    WHERE bt.RequestType = 'Reserve'
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

                    // Update status and approval date in a single query without field names
                    string updateQuery = "UPDATE BookTransactions SET Status = 'Approved', ApprovalDate = @ApprovalDate, ProcessedBy = @ProcessedBy WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        command.Parameters.AddWithValue("@ApprovalDate", DateTime.Now.Date); // Use just the date portion
                        command.Parameters.AddWithValue("@ProcessedBy", adminFullName);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation request approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Update failed.\nTransaction ID: {selectedTransactionID}\nAdmin Name: {adminFullName}",
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Refresh the view regardless of outcome
                    LoadPendingReservationRequests();
                    ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving reservation:\n{ex.Message}\n\nTransaction ID: {selectedTransactionID}",
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

                    // Check available copies
                    string checkCopiesQuery = @"SELECT AvailableCopies, BookID FROM Books 
                                              WHERE BookID = (SELECT BookID FROM BookTransactions 
                                                            WHERE TransactionID = @TransactionID)";

                    int availableCopies = 0;
                    int bookID = 0;

                    using (OleDbCommand command = new OleDbCommand(checkCopiesQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                availableCopies = Convert.ToInt32(reader["AvailableCopies"]);
                                bookID = Convert.ToInt32(reader["BookID"]);
                            }
                        }
                    }

                    if (availableCopies <= 0)
                    {
                        MessageBox.Show("No copies available for lending.", "No Copies", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update the transaction to a borrow
                    string updateTransactionQuery = @"UPDATE BookTransactions 
                                                    SET Status = 'Approved', 
                                                        RequestType = 'Borrow',
                                                        BorrowDate = @BorrowDate,
                                                        ReturnDate = @ReturnDate
                                                    WHERE TransactionID = @TransactionID";

                    using (OleDbCommand command = new OleDbCommand(updateTransactionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        command.Parameters.AddWithValue("@BorrowDate", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@ReturnDate", DateTime.Now.Date.AddDays(7)); // 7-day loan period
                        command.ExecuteNonQuery();
                    }

                    // Update available copies
                    string updateCopiesQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID = @BookID";
                    using (OleDbCommand command = new OleDbCommand(updateCopiesQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", bookID);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book has been successfully lent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservedBooks();
                    ClearSelection();
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
                                    WHERE bt.RequestType = 'Reserve'";

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
                                    WHERE bt.RequestType = 'Reserve' AND 
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

                // Store the selected transaction ID
                selectedTransactionID = Convert.ToInt32(row.Cells["TransactionID"].Value);

                // Fill text boxes with the selected row data
                textBoxUserID.Text = row.Cells["UserID"].Value.ToString();
                textBoxFullName.Text = row.Cells["FullName"].Value.ToString();
                textBoxBookID.Text = row.Cells["BookID"].Value.ToString();
                textBoxBookTitle.Text = row.Cells["Title"].Value.ToString();
                textBoxISBN.Text = row.Cells["ISBN"].Value.ToString();
                textBoxAvailableCopies.Text = row.Cells["AvailableCopies"].Value.ToString();
                textBoxTotalCopies.Text = row.Cells["TotalCopies"].Value.ToString();
                textBoxStatus.Text = row.Cells["Status"].Value.ToString();
                
                textBoxRequestDate.Text = row.Cells["RequestDate"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["RequestDate"].Value).ToShortDateString()
                    : "Not set";

                string status = row.Cells["Status"].Value.ToString();

                // Enable buttons based on current view and status
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

            btnLendBook.Enabled = false;
            btnAccept.Enabled = false;
            btnDecline.Enabled = false;
        }

    }
}
