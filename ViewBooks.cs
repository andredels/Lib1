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
            UserID = userId; 
            datagridViewAllBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StyleDataGridView();
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
                btnReserve.Visible = false;
            }
            else if (UserRole.ToLower() == "student")
            {
                btnUpdateVwBks.Visible = false;
                btnDeleteVwBks.Visible = false;
                btnBorrowVwBks.Visible = true;
                btnReserve.Visible = true;
            }
        }
        private void LoadAllBooks()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
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
            StyleDataGridView();
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
                if (datagridViewAllBooks.SelectedRows.Count == 0 && datagridViewAllBooks.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select a book to update", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = datagridViewAllBooks.SelectedCells[0].RowIndex;
                if (rowIndex < 0 || rowIndex >= datagridViewAllBooks.Rows.Count)
                {
                    MessageBox.Show("Invalid row selection", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int bookId = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["BookID"].Value);

                if (string.IsNullOrWhiteSpace(textBoxBookNameVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAuthorNameVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPublisherVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPublicationYearVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAvailableCopiesVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxTotalCopiesVwBks.Text) ||
                    string.IsNullOrWhiteSpace(textBoxISBNVwBks.Text) ||
                    comboBoxBookGenre.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all fields", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string isbnString = textBoxISBNVwBks.Text.Trim();
                if (!isbnString.All(char.IsDigit))
                {
                    MessageBox.Show("ISBN must contain only numbers", "Invalid ISBN",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (isbnString.Length != 10 && isbnString.Length != 13)
                {
                    MessageBox.Show("ISBN must be either 10 or 13 digits long", "Invalid ISBN",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxPublicationYearVwBks.Text, out int publicationYear))
                {
                    MessageBox.Show("Please enter a valid publication year", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int currentTotal = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["TotalCopies"].Value);
                int currentAvailable = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["AvailableCopies"].Value);
                int borrowedBooks = currentTotal - currentAvailable;

                if (!int.TryParse(textBoxAvailableCopiesVwBks.Text, out int newAvailableCopies) || newAvailableCopies < 0)
                {
                    MessageBox.Show("Please enter a valid number of available copies (0 or greater)", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxTotalCopiesVwBks.Text, out int newTotalCopies))
                {
                    MessageBox.Show("Please enter a valid number for total copies", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int availableDifference = newAvailableCopies - currentAvailable;
                int totalDifference = newTotalCopies - currentTotal;

                if (availableDifference != 0 || totalDifference != 0)
                {
                    if (availableDifference != 0)
                    {
                        newTotalCopies = currentTotal + availableDifference;
                    }
                    else if (totalDifference != 0)
                    {

                        if (newTotalCopies < borrowedBooks)
                        {
                            MessageBox.Show($"Total copies cannot be less than {borrowedBooks} (number of borrowed books)", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        newAvailableCopies = currentAvailable + totalDifference;
                    }
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    int genreId = -1;
                    string genreQuery = "SELECT GenreID FROM Genres WHERE GenreName = ?";
                    using (OleDbCommand genreCmd = new OleDbCommand(genreQuery, conn))
                    {
                        genreCmd.Parameters.AddWithValue("?", comboBoxBookGenre.SelectedItem.ToString());
                        object result = genreCmd.ExecuteScalar();
                        if (result != null)
                        {
                            genreId = Convert.ToInt32(result);
                        }
                    }

                    if (genreId == -1)
                    {
                        MessageBox.Show("Invalid genre selected", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "UPDATE Books SET Title = @Title, Author = @Author, " +
                                   "Publisher = @Publisher, PublicationYear = @PublicationYear, " +
                                   "TotalCopies = @TotalCopies, AvailableCopies = @AvailableCopies, " +
                                   "ISBN = @ISBN, GenreID = @GenreID " +
                                   "WHERE BookID = @BookID";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", textBoxBookNameVwBks.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", textBoxAuthorNameVwBks.Text.Trim());
                        cmd.Parameters.AddWithValue("@Publisher", textBoxPublisherVwBks.Text.Trim());
                        cmd.Parameters.AddWithValue("@PublicationYear", publicationYear);
                        cmd.Parameters.AddWithValue("@TotalCopies", newTotalCopies);
                        cmd.Parameters.AddWithValue("@AvailableCopies", newAvailableCopies);
                        cmd.Parameters.AddWithValue("@ISBN", isbnString);
                        cmd.Parameters.AddWithValue("@GenreID", genreId);
                        cmd.Parameters.AddWithValue("@BookID", bookId);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Book updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadAllBooks();
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

            int rowIndex = datagridViewAllBooks.SelectedCells[0].RowIndex;
            int bookId = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["BookID"].Value);
            string bookTitle = datagridViewAllBooks.Rows[rowIndex].Cells["Title"].Value.ToString();

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string checkQuery = @"SELECT COUNT(*) FROM BookTransactions WHERE BookID = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", bookId);
                        int transactionCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (transactionCount > 0)
                        {
                            MessageBox.Show(
                                $"Cannot delete '{bookTitle}' because it has existing transaction records.\n\n" +
                                "This includes borrowed, returned, or reserved records.\n" +
                                "To maintain the integrity of transaction history, books with existing records cannot be deleted.",
                                "Deletion Restricted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete '{bookTitle}'?\n\n" +
                        "This action cannot be undone.",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM Books WHERE BookID = ?";
                        using (OleDbCommand deleteCmd = new OleDbCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("?", bookId);
                            int deleteResult = deleteCmd.ExecuteNonQuery();

                            if (deleteResult > 0)
                            {
                                MessageBox.Show("Book deleted successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadAllBooks();
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete book.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (datagridViewAllBooks.SelectedRows.Count == 0 && datagridViewAllBooks.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select a book to borrow", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = datagridViewAllBooks.SelectedCells[0].RowIndex;
                int bookId = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["BookID"].Value);
                string bookTitle = datagridViewAllBooks.Rows[rowIndex].Cells["Title"].Value.ToString();
                int availableCopies = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["AvailableCopies"].Value);

                if (availableCopies <= 0)
                {
                    MessageBox.Show("Sorry, there are no available copies of this book.",
                        "Book Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (UserID <= 0)
                {
                    MessageBox.Show("User information is not available. Please login again.",
                        "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string checkTotalQuery = @"SELECT COUNT(*) FROM BookTransactions 
                                         WHERE UserID = ? 
                                         AND (Status = 'Pending' OR Status = 'Approved')
                                         AND (RequestType = 'Borrow' OR RequestType = 'Reservation')";
                    using (OleDbCommand checkTotalCmd = new OleDbCommand(checkTotalQuery, conn))
                    {
                        checkTotalCmd.Parameters.Add("?", OleDbType.Integer).Value = UserID;
                        int totalBooks = Convert.ToInt32(checkTotalCmd.ExecuteScalar());

                        if (totalBooks >= 3) 
                        {
                            MessageBox.Show("You have reached the maximum limit of books (3) that can be borrowed or reserved at once. " +
                                "Please return some books or wait for your pending requests to be processed before making new requests.",
                                "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

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

                    DateTime requestDate = DateTime.Now;

                    string insertQuery = @"INSERT INTO BookTransactions 
                        (BookID, UserID, Status, RequestDate, RequestType) 
                        VALUES (?, ?, ?, ?, ?)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = bookId;
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = UserID;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = "Pending";
                        insertCmd.Parameters.Add("?", OleDbType.Date).Value = requestDate;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = "Borrow";

                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show($"Borrow request for '{bookTitle}' has been submitted successfully. " +
                                $"Your request is pending approval from an administrator.", "Request Submitted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            datagridViewAllBooks.ClearSelection();
                            ClearTextBoxes();
                            LoadAllBooks(); 
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
                    MessageBox.Show("ISBN must contain only numbers", "Invalid Input",
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
                        comboBoxBookGenre.Items.Clear();
                        comboBoxGenreSearch.Items.Clear(); 
                        while (reader.Read())
                        {
                            string genreName = reader["GenreName"].ToString();
                            comboBoxBookGenre.Items.Add(genreName);
                            comboBoxGenreSearch.Items.Add(genreName);
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

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridViewAllBooks.SelectedRows.Count == 0 && datagridViewAllBooks.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select a book to reserve", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = datagridViewAllBooks.SelectedCells[0].RowIndex;
                int bookId = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["BookID"].Value);
                string bookTitle = datagridViewAllBooks.Rows[rowIndex].Cells["Title"].Value.ToString();
                int availableCopies = Convert.ToInt32(datagridViewAllBooks.Rows[rowIndex].Cells["AvailableCopies"].Value);

                if (availableCopies > 0)
                {
                    MessageBox.Show("This book is currently available for borrowing. Please use the Borrow button instead.",
                        "Book Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (UserID <= 0)
                {
                    MessageBox.Show("User information is not available. Please login again.",
                        "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string checkTotalQuery = @"SELECT COUNT(*) FROM BookTransactions 
                                         WHERE UserID = ? 
                                         AND (Status = 'Pending' OR Status = 'Approved')
                                         AND (RequestType = 'Borrow' OR RequestType = 'Reservation')";
                    using (OleDbCommand checkTotalCmd = new OleDbCommand(checkTotalQuery, conn))
                    {
                        checkTotalCmd.Parameters.Add("?", OleDbType.Integer).Value = UserID;
                        int totalBooks = Convert.ToInt32(checkTotalCmd.ExecuteScalar());

                        if (totalBooks >= 3) 
                        {
                            MessageBox.Show("You have reached the maximum limit of books (3) that can be borrowed or reserved at once. " +
                                "Please return some books or wait for your pending requests to be processed before making new requests.",
                                "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    string checkExistingQuery = @"SELECT COUNT(*) FROM BookTransactions 
                                         WHERE UserID = ? AND BookID = ? 
                                         AND (Status = 'Pending' OR Status = 'Approved')
                                         AND (RequestType = 'Borrow' OR RequestType = 'Reservation')";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkExistingQuery, conn))
                    {
                        checkCmd.Parameters.Add("?", OleDbType.Integer).Value = UserID;
                        checkCmd.Parameters.Add("?", OleDbType.Integer).Value = bookId;

                        int existingTransactions = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingTransactions > 0)
                        {
                            MessageBox.Show("You already have this book borrowed or have a pending request/reservation for it.",
                                "Duplicate Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    DateTime requestDate = DateTime.Now;

                    string insertQuery = @"INSERT INTO BookTransactions 
                        (BookID, UserID, Status, RequestDate, RequestType) 
                        VALUES (?, ?, ?, ?, ?)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = bookId;
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = UserID;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = "Pending";
                        insertCmd.Parameters.Add("?", OleDbType.Date).Value = requestDate;
                        insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = "Reservation";

                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show($"Reservation request for '{bookTitle}' has been submitted successfully. " +
                                $"Your request is pending approval from an administrator.", "Request Submitted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            datagridViewAllBooks.ClearSelection();
                            ClearTextBoxes();
                            LoadAllBooks(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit reservation request.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing reservation request: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxGenreSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void textBoxStartYearSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void textBoxEndYearSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            try
            {
                StringBuilder filterBuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(comboBoxGenreSearch.Text))
                {
                    filterBuilder.AppendFormat("[Genre] LIKE '%{0}%'", comboBoxGenreSearch.Text.Replace("'", "''"));
                }

                if (int.TryParse(textBoxStartYearSearch.Text, out int startYear))
                {
                    if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");
                    filterBuilder.AppendFormat("[PublicationYear] >= {0}", startYear);
                }
                if (int.TryParse(textBoxEndYearSearch.Text, out int endYear))
                {
                    if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");
                    filterBuilder.AppendFormat("[PublicationYear] <= {0}", endYear);
                }

                if (!string.IsNullOrEmpty(textBoxSearch.Text))
                {
                    if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");
                    string searchText = textBoxSearch.Text.Replace("'", "''"); 
                    filterBuilder.AppendFormat("([Title] LIKE '%{0}%' OR [Author] LIKE '%{0}%' OR [ISBN] LIKE '%{0}%' OR [Genre] LIKE '%{0}%' OR [Publisher] LIKE '%{0}%')", searchText);
                }

                (datagridViewAllBooks.DataSource as DataTable).DefaultView.RowFilter = filterBuilder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering books: " + ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxGenreSearch.SelectedIndex = -1;
                comboBoxGenreSearch.Text = "";
                textBoxStartYearSearch.Clear();
                textBoxEndYearSearch.Clear();
                textBoxSearch.Clear();

                LoadAllBooks();

                (datagridViewAllBooks.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StyleDataGridView()
        {
            datagridViewAllBooks.EnableHeadersVisualStyles = false;
            datagridViewAllBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            datagridViewAllBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            datagridViewAllBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            datagridViewAllBooks.RowHeadersVisible = false;
            datagridViewAllBooks.BorderStyle = BorderStyle.None;
            datagridViewAllBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            datagridViewAllBooks.GridColor = Color.FromArgb(224, 224, 224);
            datagridViewAllBooks.RowTemplate.Height = 35;
            datagridViewAllBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            datagridViewAllBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            datagridViewAllBooks.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}
