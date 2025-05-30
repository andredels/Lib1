﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib1
{
    public partial class ReviewBooks : UserControl
    {
        private int userId;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb";

        public ReviewBooks()
        {
            InitializeComponent();
        }

        public ReviewBooks(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            btnRate.Enabled = false;
            LoadReturnedBooks();

            dataGridViewReviewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewReviewBooks.SelectionChanged += dataGridViewReviewBooks_SelectionChanged;
        }

        private void LoadReturnedBooks()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT DISTINCT b.BookID, b.Title, b.ISBN, b.AvailableCopies, b.TotalCopies, 
                                   First(bt.ReturnDate) as ReturnDate, First(bt.TransactionID) as TransactionID
                                   FROM Books b
                                   INNER JOIN BookTransactions bt ON b.BookID = bt.BookID
                                   WHERE bt.UserID = ? AND bt.Status = 'Returned'
                                   AND NOT EXISTS (
                                       SELECT 1 FROM BookRatings br 
                                       WHERE br.BookID = b.BookID AND br.UserID = ?
                                   )
                                   GROUP BY b.BookID, b.Title, b.ISBN, b.AvailableCopies, b.TotalCopies
                                   ORDER BY First(bt.ReturnDate) DESC";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("?", OleDbType.Integer).Value = userId;
                        command.Parameters.Add("?", OleDbType.Integer).Value = userId;
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewReviewBooks.DataSource = dataTable;

                        if (dataGridViewReviewBooks.Columns.Contains("ReturnDate"))
                        {
                            dataGridViewReviewBooks.Columns["ReturnDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

                        StyleDataGridView();
                        LoadBookTitlesFromGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading returned books: {ex.Message}\nStack trace: {ex.StackTrace}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            dataGridViewReviewBooks.EnableHeadersVisualStyles = false;
            dataGridViewReviewBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dataGridViewReviewBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewReviewBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewReviewBooks.RowHeadersVisible = false;
            dataGridViewReviewBooks.BorderStyle = BorderStyle.None;
            dataGridViewReviewBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewReviewBooks.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewReviewBooks.RowTemplate.Height = 35;
            dataGridViewReviewBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewReviewBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewReviewBooks.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadBookTitlesFromGrid()
        {
            try
            {
                comboBoxBookTitleSearch.Items.Clear();

                if (dataGridViewReviewBooks.DataSource is DataTable dataTable)
                {
                    HashSet<string> uniqueBookTitles = new HashSet<string>();

                    if (dataTable.Columns.Contains("Title"))
                    {
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

                        List<string> sortedTitles = uniqueBookTitles.OrderBy(title => title).ToList();
                        comboBoxBookTitleSearch.Items.AddRange(sortedTitles.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading book titles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBookSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBoxBookTitleSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                if (dataGridViewReviewBooks.DataSource is DataTable dt)
                {
                    StringBuilder filterBuilder = new StringBuilder();

                    if (!string.IsNullOrEmpty(comboBoxBookTitleSearch.Text))
                    {
                        string bookTitle = comboBoxBookTitleSearch.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("[Title] = '{0}'", bookTitle);
                    }

                    if (!string.IsNullOrEmpty(textBoxBookSearch.Text))
                    {
                        if (filterBuilder.Length > 0) filterBuilder.Append(" AND ");

                        string searchText = textBoxBookSearch.Text.Replace("'", "''");

                        filterBuilder.AppendFormat("([Title] LIKE '%{0}%' OR [ISBN] LIKE '%{0}%')", searchText);
                    }

                    dt.DefaultView.RowFilter = filterBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Filter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxBookTitleSearch.Text = string.Empty;
            textBoxBookSearch.Text = string.Empty;
            LoadReturnedBooks();
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            if (dataGridViewReviewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to rate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxRateBook.Text, out int rating) || rating < 1 || rating > 10)
            {
                MessageBox.Show("Please enter a valid rating between 1 and 10.", "Invalid Rating", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dataGridViewReviewBooks.SelectedRows[0].Cells["BookID"].Value);

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM BookRatings WHERE BookID = ? AND UserID = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.Add("?", OleDbType.Integer).Value = bookId;
                        checkCmd.Parameters.Add("?", OleDbType.Integer).Value = userId;
                        int existingRating = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingRating > 0)
                        {
                            MessageBox.Show("You have already rated this book.", "Already Rated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO BookRatings (BookID, UserID, Rating, RatingDate) VALUES (?, ?, ?, ?)";
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = bookId;
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = userId;
                        insertCmd.Parameters.Add("?", OleDbType.Integer).Value = rating;
                        insertCmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Rating submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxRateBook.Clear();
                    LoadReturnedBooks(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting rating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxRateBook_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewReviewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewReviewBooks.Rows[e.RowIndex];
                textBoxBookID.Text = row.Cells["BookID"].Value.ToString();
            }
        }

        private void textBoxBookID_TextChanged(object sender, EventArgs e)
        {
            btnRate.Enabled = !string.IsNullOrWhiteSpace(textBoxBookID.Text);
        }

        private void dataGridViewReviewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewReviewBooks.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewReviewBooks.SelectedRows[0];

                if (row.DataGridView.Columns.Contains("BookID"))
                    textBoxBookID.Text = row.Cells["BookID"].Value.ToString();

                btnRate.Enabled = true;
            }
            else
            {
                ClearBookDetails();
                btnRate.Enabled = false;
            }
        }

        private void ClearBookDetails()
        {
            textBoxBookID.Text = string.Empty;
        }
    }
}
