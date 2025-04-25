using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ViewBooks : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        private DataTable booksTable = new DataTable();
        private OleDbDataAdapter adapter;

        public ViewBooks(string userRole, int userId = -1)
        {
            InitializeComponent();
            UserRole = userRole;
            UserID = userId;  // Store the userId
            ConfigureButtons();
            LoadAllBooks();
            LoadGenres();
        }
        public int UserID { get; set; }
        public string UserRole { get; set; }

        private void ConfigureButtons()
        {
            if (UserRole.ToLower() == "admin")
            {
                btnUpdateVwBks.Visible = true;
                btnDeleteVwBks.Visible = true;
                btnBorrowVwBks.Visible = false;
                btnReserveVwBks.Visible = false;
            }
            else if (UserRole.ToLower() == "student")
            {
                btnUpdateVwBks.Visible = false;
                btnDeleteVwBks.Visible = false;
                btnBorrowVwBks.Visible = true;
                btnReserveVwBks.Visible = true;
            }
        }
        private void LoadAllBooks()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    // Modified query to include Genre from Genres table via JOIN
                    string query = @"SELECT Books.BookID, Books.Title, Books.Author, Books.Publisher, 
                                   Books.PublicationYear, Books.ISBN, Books.TotalCopies, Books.AvailableCopies, 
                                   Genres.GenreName as Genre 
                                   FROM Books LEFT JOIN Genres ON Books.GenreID = Genres.GenreID";

                    adapter = new OleDbDataAdapter(query, conn);
                    booksTable.Clear();
                    adapter.Fill(booksTable);

                    datagridViewAllBooks.DataSource = booksTable;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridViewViewAllBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = datagridViewAllBooks.Rows[e.RowIndex];

                textBoxBookNameVwBks.Text = row.Cells["Title"].Value?.ToString() ?? "";
                textBoxAuthorNameVwBks.Text = row.Cells["Author"].Value?.ToString() ?? "";
                textBoxPublisherVwBks.Text = row.Cells["Publisher"].Value?.ToString() ?? "";
                textBoxPublicationYearVwBks.Text = row.Cells["PublicationYear"].Value?.ToString() ?? "";
                textBoxAvailableCopiesVwBks.Text = row.Cells["AvailableCopies"].Value?.ToString() ?? "";
                textBoxTotalCopiesVwBks.Text = row.Cells["TotalCopies"].Value?.ToString() ?? "";
                comboBoxBookGenre.SelectedItem = row.Cells["Genre"].Value?.ToString() ?? "";
                textBoxISBNVwBks.Text = row.Cells["ISBN"].Value?.ToString() ?? "";
            }
        }

        private void btnUpdateVwBks_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (datagridViewAllBooks.SelectedRows.Count == 0 && datagridViewAllBooks.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select a book to update", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the BookID of the selected row
                int rowIndex = datagridViewAllBooks.SelectedCells[0].RowIndex;
                if (rowIndex < 0 || rowIndex >= datagridViewAllBooks.Rows.Count)
                {
                    MessageBox.Show("Invalid row selection", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int bookId = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["BookID"].Value);

                // Validate input fields
                if (string.IsNullOrWhiteSpace(textBoxBookNameVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAuthorNameVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPublisherVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPublicationYearVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAvailableCopiesVwBks.Text))
                {
                    MessageBox.Show("Please fill in all fields", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate numeric fields
                if (!int.TryParse(textBoxPublicationYearVwBks.Text, out int publicationYear))
                {
                    MessageBox.Show("Please enter a valid publication year", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxAvailableCopiesVwBks.Text, out int availableCopies) || availableCopies < 0)
                {
                    MessageBox.Show("Please enter a valid number of available copies (0 or greater)", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get current data to calculate the new total copies
                int currentTotal = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["TotalCopies"].Value);
                int currentAvailable = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["AvailableCopies"].Value);

                // Calculate borrowed books (this number should remain unchanged)
                int borrowedBooks = currentTotal - currentAvailable;

                // Calculate new total copies based on new available copies plus borrowed books
                int newTotalCopies = availableCopies + borrowedBooks;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Books SET Title = @Title, Author = @Author, " +
                                   "Publisher = @Publisher, PublicationYear = @PublicationYear, " +
                                   "TotalCopies = @TotalCopies, AvailableCopies = @AvailableCopies " +
                                   "WHERE BookID = @BookID";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", textBoxBookNameVwBks.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", textBoxAuthorNameVwBks.Text.Trim());
                        cmd.Parameters.AddWithValue("@Publisher", textBoxPublisherVwBks.Text.Trim());
                        cmd.Parameters.AddWithValue("@PublicationYear", publicationYear);
                        cmd.Parameters.AddWithValue("@TotalCopies", newTotalCopies);
                        cmd.Parameters.AddWithValue("@AvailableCopies", availableCopies);
                        cmd.Parameters.AddWithValue("@BookID", bookId);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Book updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the grid
                            LoadAllBooks();

                            // Clear the textboxes
                            ClearTextBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update book.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteVwBks_Click(object sender, EventArgs e)
        {
            if (datagridViewAllBooks.SelectedRows.Count == 0 && datagridViewAllBooks.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a book to delete", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the BookID of the selected row
            int rowIndex = datagridViewAllBooks.SelectedCells[0].RowIndex;
            int bookId = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["BookID"].Value);
            string bookTitle = datagridViewAllBooks.Rows[rowIndex].Cells["Title"].Value.ToString();

            // Confirm deletion
            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{bookTitle}'?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Check if book is currently borrowed
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();

                        // Check if book has any active loans
                        string checkQuery = "SELECT COUNT(*) FROM BookTransactions WHERE BookID = @BookID AND Status = 'Borrowed'";
                        using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@BookID", bookId);
                            int activeLoans = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (activeLoans > 0)
                            {
                                MessageBox.Show("Cannot delete this book as it is currently borrowed by one or more users.",
                                    "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Proceed with deletion
                        string deleteQuery = "DELETE FROM Books WHERE BookID = @BookID";
                        using (OleDbCommand deleteCmd = new OleDbCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@BookID", bookId);
                            int deleteResult = deleteCmd.ExecuteNonQuery();

                            if (deleteResult > 0)
                            {
                                MessageBox.Show("Book deleted successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Refresh the grid
                                LoadAllBooks();

                                // Clear the textboxes
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete book.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting book: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearTextBoxes()
        {
            textBoxBookNameVwBks.Clear();
            textBoxAuthorNameVwBks.Clear();
            textBoxPublisherVwBks.Clear();
            textBoxPublicationYearVwBks.Clear();
            textBoxAvailableCopiesVwBks.Clear();
            textBoxTotalCopiesVwBks.Clear();
            comboBoxBookGenre.SelectedIndex = -1;
            textBoxISBNVwBks.Clear();
        }

        private void btnBorrowVwBks_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a book is selected
                if (datagridViewAllBooks.SelectedRows.Count == 0 && datagridViewAllBooks.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select a book to borrow", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the selected book information
                int rowIndex = datagridViewAllBooks.SelectedCells[0].RowIndex;
                int bookId = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["BookID"].Value);
                string bookTitle = datagridViewAllBooks.Rows[rowIndex].Cells["Title"].Value.ToString();
                int availableCopies = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["AvailableCopies"].Value);

                // Check if book is available
                if (availableCopies <= 0)
                {
                    MessageBox.Show("Sorry, there are no available copies of this book.",
                        "Book Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the current user ID - this is now stored as a property
                if (UserID <= 0)
                {
                    MessageBox.Show("User information is not available. Please login again.",
                        "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // First check if user already has this book borrowed or pending
                    string checkBorrowedQuery = @"SELECT COUNT(*) FROM BookTransactions 
                                         WHERE UserID = ? AND BookID = ? 
                                         AND (Status = 'Pending' OR Status = 'Borrowed')";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkBorrowedQuery, conn))
                    {
                        checkCmd.Parameters.Add("?", OleDbType.Integer).Value = UserID;
                        checkCmd.Parameters.Add("?", OleDbType.Integer).Value = bookId;

                        int existingTransactions = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingTransactions > 0)
                        {
                            MessageBox.Show("You already have this book borrowed or have a pending request for it.",
                                "Duplicate Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Create transaction with current date as the request date
                    DateTime requestDate = DateTime.Now;

                    // Insert into BookTransactions with all necessary fields for a pending request
                    string insertQuery = @"INSERT INTO BookTransactions 
                        (BookID, UserID, Status, RequestDate) 
                        VALUES (?, ?, ?, ?)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = bookId;
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = UserID;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = "Pending";
                        insertCmd.Parameters.Add("?", OleDbType.Date).Value = requestDate;

                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show($"Borrow request for '{bookTitle}' has been submitted successfully. " +
                                $"Your request is pending approval from an administrator.", "Request Submitted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear selections and refresh the books view
                            datagridViewAllBooks.ClearSelection();
                            ClearTextBoxes();
                            LoadAllBooks(); // Refresh the book list
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit borrow request.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing borrow request: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReserveVwBks_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxBookGenre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAvailableCopiesVwBks_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAvailableCopiesVwBks.Text))
            {
                if (!textBoxAvailableCopiesVwBks.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Please enter only numbers for Available Copies", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxAvailableCopiesVwBks.Text = string.Empty;
                }
            }
        }

        private void textBoxISBNVwBks_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxISBNVwBks.Text))
            {
                if (!textBoxISBNVwBks.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Please enter only numbers for Available Copies", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxISBNVwBks.Text = string.Empty;
                }
            }
        }

        private void textBoxTotalCopiesVwBks_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTotalCopiesVwBks.Text))
            {
                if (!textBoxTotalCopiesVwBks.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Please enter only numbers for Available Copies", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTotalCopiesVwBks.Text = string.Empty;
                }
            }
        }
        private void LoadGenres()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT GenreName FROM Genres ORDER BY GenreName";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        comboBoxBookGenre.Items.Clear(); // Clear any existing items
                        while (reader.Read())
                        {
                            comboBoxBookGenre.Items.Add(reader["GenreName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading genres: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
