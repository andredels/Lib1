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
        private bool isPendingView = false;

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

                        // Update the view flag
                        isPendingView = false;

                        // Load student names for filter from current data
                        LoadStudentNamesFromGrid();
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
            ReservedBooks.EnableHeadersVisualStyles = false;
            ReservedBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            ReservedBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ReservedBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ReservedBooks.RowHeadersVisible = false;
            ReservedBooks.BorderStyle = BorderStyle.None;
            ReservedBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ReservedBooks.GridColor = Color.FromArgb(224, 224, 224);
            ReservedBooks.RowTemplate.Height = 35;
            ReservedBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            ReservedBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            ReservedBooks.DefaultCellStyle.SelectionForeColor = Color.White;
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

                        // Update the view flag
                        isPendingView = true;

                        // Load student names for filter from current data
                        LoadStudentNamesFromGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pending reservation requests: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStudentNamesFromGrid()
        {
            try
            {
                // Clear previous items
                comboBoxStudentNameSearch.Items.Clear();

                // Get the current data source
                if (ReservedBooks.DataSource is DataTable dataTable)
                {
                    // Create a HashSet to store unique student names
                    HashSet<string> uniqueStudentNames = new HashSet<string>();

                    // Check if the FullName column exists
                    if (dataTable.Columns.Contains("FullName"))
                    {
                        // Extract unique values
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["FullName"] != DBNull.Value)
                            {
                                string fullname = row["FullName"].ToString().Trim();
                                if (!string.IsNullOrEmpty(fullname))
                                {
                                    uniqueStudentNames.Add(fullname);
                                }
                            }
                        }

                        // Sort the names alphabetically
                        List<string> sortedNames = uniqueStudentNames.OrderBy(name => name).ToList();

                        // Add to combo box
                        comboBoxStudentNameSearch.Items.AddRange(sortedNames.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading student names: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ApplyFilters();
        }

        private void textBoxBorrowedBookSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Clear filters
            comboBoxStudentNameSearch.Text = string.Empty;
            textBoxBorrowedBookSearch.Text = string.Empty;

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
        private void ApplyFilters()
        {
            try
            {
                // Get the current data source
                if (ReservedBooks.DataSource is DataTable dt)
                {
                    StringBuilder filterBuilder = new StringBuilder();

                    // Student name filter
                    if (!string.IsNullOrEmpty(comboBoxStudentNameSearch.Text))
                    {
                        string studentName = comboBoxStudentNameSearch.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("[FullName] LIKE '%{0}%'", studentName);
                    }

                    // General search text filter
                    if (!string.IsNullOrEmpty(textBoxBorrowedBookSearch.Text))
                    {
                        if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");

                        string searchText = textBoxBorrowedBookSearch.Text.Replace("'", "''");

                        // Add all relevant columns for searching
                        filterBuilder.AppendFormat("([Title] LIKE '%{0}%' OR [FullName] LIKE '%{0}%' " +
                            "OR [ISBN] LIKE '%{0}%' OR [Status] LIKE '%{0}%'", searchText);

                        // Add additional columns based on view
                        if (isPendingView)
                        {
                            filterBuilder.AppendFormat(" OR [RequestType] LIKE '%{0}%'", searchText);
                        }
                        else
                        {
                            filterBuilder.AppendFormat(" OR [ProcessedBy] LIKE '%{0}%'", searchText);
                        }

                        filterBuilder.Append(")");
                    }

                    // Apply the filter
                    dt.DefaultView.RowFilter = filterBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Filter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
