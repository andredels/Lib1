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
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb";
        private int adminId;
        private string adminName;
        public BookBorrowRequest(int adminId, string adminName)
        {
            InitializeComponent();
            this.adminId = adminId;
            this.adminName = adminName;
            dataGridView_BookBorrowRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StyleDataGridView();
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
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Build your own JOIN DO NOT USE ReservedBooks
                    string query = "SELECT * FROM [PendingBorrowRequest]";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_BookBorrowRequests.DataSource = null;
                        dataGridView_BookBorrowRequests.DataSource = dataTable;

                        // Configure the DataGridView columns for better display
                        if (dataGridView_BookBorrowRequests.Columns.Contains("RequestDate"))
                        {
                            dataGridView_BookBorrowRequests.Columns["RequestDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_BookBorrowRequests.Columns.Contains("BorrowDate"))
                        {
                            dataGridView_BookBorrowRequests.Columns["BorrowDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }
                        if (dataGridView_BookBorrowRequests.Columns.Contains("ReturnDate"))
                        {
                            dataGridView_BookBorrowRequests.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

                        // Apply professional styling
                        StyleDataGridView();

                        // Load the combo boxes with data from the current DataTable
                        LoadComboBoxesFromDataGrid(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reserved books: {ex.Message}\nStack trace: {ex.StackTrace}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxesFromDataGrid(DataTable dataTable)
        {
            try
            {
                // Clear previous items
                comboBoxStudentNameSearch.Items.Clear();
                comboBoxBookSearch.Items.Clear();

                // Create HashSets to store unique values (to avoid duplicates)
                HashSet<string> uniqueStudentNames = new HashSet<string>();
                HashSet<string> uniqueBookTitles = new HashSet<string>();

                // Extract unique values from the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Add student name if it exists and is not null
                    if (dataTable.Columns.Contains("Fullname") && row["Fullname"] != DBNull.Value)
                    {
                        string fullname = row["Fullname"].ToString().Trim();
                        if (!string.IsNullOrEmpty(fullname))
                        {
                            uniqueStudentNames.Add(fullname);
                        }
                    }

                    // Add book title if it exists and is not null
                    if (dataTable.Columns.Contains("Title") && row["Title"] != DBNull.Value)
                    {
                        string title = row["Title"].ToString().Trim();
                        if (!string.IsNullOrEmpty(title))
                        {
                            uniqueBookTitles.Add(title);
                        }
                    }
                }

                // Sort the unique values alphabetically
                List<string> sortedStudentNames = uniqueStudentNames.OrderBy(name => name).ToList();
                List<string> sortedBookTitles = uniqueBookTitles.OrderBy(title => title).ToList();

                // Add values to combo boxes
                comboBoxStudentNameSearch.Items.AddRange(sortedStudentNames.ToArray());
                comboBoxBookSearch.Items.AddRange(sortedBookTitles.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combo box data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void StyleDataGridView()
        {
            dataGridView_BookBorrowRequests.EnableHeadersVisualStyles = false;
            dataGridView_BookBorrowRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dataGridView_BookBorrowRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_BookBorrowRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView_BookBorrowRequests.RowHeadersVisible = false;
            dataGridView_BookBorrowRequests.BorderStyle = BorderStyle.None;
            dataGridView_BookBorrowRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_BookBorrowRequests.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView_BookBorrowRequests.RowTemplate.Height = 35;
            dataGridView_BookBorrowRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView_BookBorrowRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridView_BookBorrowRequests.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void textBoxBorrowedBookSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBorrowRequests(); // Reload data and refresh combo boxes
            textBoxBorrowedBookSearch.Clear();
        }

        private void comboBoxBookSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBoxStudentNameSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            try
            {
                StringBuilder filterBuilder = new StringBuilder();

                // Student name filter
                if (!string.IsNullOrEmpty(comboBoxStudentNameSearch.Text))
                {
                    string studentName = comboBoxStudentNameSearch.Text.Replace("'", "''");
                    filterBuilder.AppendFormat("[Fullname] LIKE '%{0}%'", studentName);
                }

                // Book title filter
                if (!string.IsNullOrEmpty(comboBoxBookSearch.Text))
                {
                    if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");
                    string bookTitle = comboBoxBookSearch.Text.Replace("'", "''");
                    filterBuilder.AppendFormat("[Title] LIKE '%{0}%'", bookTitle);
                }

                // General search textbox filter (searching across multiple fields)
                if (!string.IsNullOrEmpty(textBoxBorrowedBookSearch.Text))
                {
                    if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");
                    string searchText = textBoxBorrowedBookSearch.Text.Replace("'", "''"); // escape single quotes
                    filterBuilder.AppendFormat("([Title] LIKE '%{0}%' OR [Author] LIKE '%{0}%' OR [ISBN] LIKE '%{0}%' OR [GenreName] LIKE '%{0}%' OR [Publisher] LIKE '%{0}%' OR [Fullname] LIKE '%{0}%')", searchText);
                }

                // Apply the filter
                if (dataGridView_BookBorrowRequests.DataSource is DataTable dt)
                {
                    dt.DefaultView.RowFilter = filterBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering books: " + ex.Message, "Filter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
