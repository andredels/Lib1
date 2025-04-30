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
    public partial class ReservedBooks : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb";
        private int selectedTransactionID = 0;
        private int currentUserID;
        private bool isPendingView = false;

        public ReservedBooks(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
            LoadReservedBooks();
        }

        private void ReservedBooks_Load(object sender, EventArgs e)
        {
            SetupUI();
        }

        private void SetupUI()
        {
            textBoxApprovalDate.Visible = false;
            textBoxProcessedBy.Visible = false;
            siticoneLabel5.Visible = false;
            siticoneLabel7.Visible = false;
        }
        private void SetupUIMain()
        {
            textBoxApprovalDate.Visible = true;
            textBoxProcessedBy.Visible = true;
            siticoneLabel5.Visible = true;
            siticoneLabel7.Visible = true;
        }

        private void LoadReservedBooks()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM [ReservedBooks] WHERE UserID = @UserID";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", currentUserID);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_ReservedBooks.DataSource = null;
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

                        // Apply professional styling
                        StyleDataGridView();

                        // Update the view flag
                        isPendingView = false;

                        // Load book titles for filter
                        LoadBookTitlesFromGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reserved books: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetupUIMain();
        }

        private void StyleDataGridView()
        {
            dataGridView_ReservedBooks.EnableHeadersVisualStyles = false;
            dataGridView_ReservedBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dataGridView_ReservedBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_ReservedBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView_ReservedBooks.RowHeadersVisible = false;
            dataGridView_ReservedBooks.BorderStyle = BorderStyle.None;
            dataGridView_ReservedBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_ReservedBooks.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView_ReservedBooks.RowTemplate.Height = 35;
            dataGridView_ReservedBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView_ReservedBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridView_ReservedBooks.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadPendingReservationRequests()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM PendingReservationRequests WHERE UserID = @UserID";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", currentUserID);
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

                        // Update the view flag
                        isPendingView = true;

                        // Load book titles for filter
                        LoadBookTitlesFromGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pending reservation requests: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetupUI();
        }

        private void LoadBookTitlesFromGrid()
        {
            try
            {
                // Clear previous items
                comboBoxBookTitle.Items.Clear();

                // Get the current data source
                if (dataGridView_ReservedBooks.DataSource is DataTable dataTable)
                {
                    // Create a HashSet to store unique book titles
                    HashSet<string> uniqueBookTitles = new HashSet<string>();

                    // Check if the Title column exists
                    if (dataTable.Columns.Contains("Title"))
                    {
                        // Extract unique values
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["Title"] != DBNull.Value)
                            {
                                string title = row["Title"].ToString().Trim();
                                if (!string.IsNullOrEmpty(title))
                                {
                                    uniqueBookTitles.Add(title);
                                }
                            }
                        }

                        // Sort the titles alphabetically
                        List<string> sortedTitles = uniqueBookTitles.OrderBy(title => title).ToList();

                        // Add to combo box
                        comboBoxBookTitle.Items.AddRange(sortedTitles.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading book titles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedTransactionID == 0)
            {
                MessageBox.Show("Please select a reservation first.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE BookTransactions SET Status = 'Cancelled' WHERE TransactionID = @TransactionID";
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionID);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Reservation cancelled successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (isPendingView)
                    {
                        LoadPendingReservationRequests();
                    }
                    else
                    {
                        LoadReservedBooks();
                    }
                    ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling reservation: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewReservationRequests_Click(object sender, EventArgs e)
        {
            LoadPendingReservationRequests();
            ClearSelection();
        }

        private void comboBoxBookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Clear filters
            comboBoxBookTitle.Text = string.Empty;
            textBoxSearch.Text = string.Empty;

            LoadReservedBooks();
            ClearSelection();
            SetupUIMain();
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

            btnCancel.Enabled = false;
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
                {
                    textBoxRequestType.Text = row.Cells["RequestType"].Value?.ToString() ?? "Not set";
                }

                if (row.DataGridView.Columns.Contains("ProcessedBy"))
                {
                    textBoxProcessedBy.Text = row.Cells["ProcessedBy"].Value?.ToString() ?? "Not set";
                }

                string status = row.DataGridView.Columns.Contains("Status") ?
                    row.Cells["Status"].Value.ToString() : "";

                // Enable cancel button only for pending or approved reservations
                btnCancel.Enabled = status.Equals("Pending", StringComparison.OrdinalIgnoreCase) ||
                                  status.Equals("Approved", StringComparison.OrdinalIgnoreCase);
            }
        }

        private void ApplyFilters()
        {
            try
            {
                // Get the current data source
                if (dataGridView_ReservedBooks.DataSource is DataTable dt)
                {
                    StringBuilder filterBuilder = new StringBuilder();

                    // Book title filter
                    if (!string.IsNullOrEmpty(comboBoxBookTitle.Text))
                    {
                        string bookTitle = comboBoxBookTitle.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("[Title] LIKE '%{0}%'", bookTitle);
                    }

                    // General search text filter
                    if (!string.IsNullOrEmpty(textBoxSearch.Text))
                    {
                        if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");

                        string searchText = textBoxSearch.Text.Replace("'", "''");

                        // Add all relevant columns for searching
                        filterBuilder.AppendFormat("([Title] LIKE '%{0}%' OR [ISBN] LIKE '%{0}%' " +
                            "OR [Status] LIKE '%{0}%'", searchText);

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