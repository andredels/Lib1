using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.Measure;
using SkiaSharp;
using System.Data;
using System.Text;

namespace Lib1
{
    public partial class Analytics : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb";
        private readonly SKColor[] chartColors = new SKColor[]
        {
            SKColors.RoyalBlue,
            SKColors.ForestGreen,
            SKColors.Crimson,
            SKColors.DarkOrange,
            SKColors.Purple,
            SKColors.Teal,
            SKColors.DarkMagenta,
            SKColors.SaddleBrown,
            SKColors.DarkSlateBlue,
            SKColors.Chocolate
        };
        private bool isAdmin;

        public Analytics(bool isAdminUser)
        {
            InitializeComponent();
            isAdmin = isAdminUser;

            // Set admin-specific controls visibility
            btnViewBookReviews.Visible = isAdmin;

            // Initialize both charts but only show Book Ratings chart
            LoadBookRatingsChart();
            LoadMostBorrowedBooksChart();

            // Set initial visibility
            cartesianChartBookRating.Visible = true;
            cartesianChartMostBorrowedBooks.Visible = false;
            dataGridView_BookReviews.Visible = false;
            comboBoxBookSearch.Visible = false;
            label2.Visible = false;
        }

        private void LoadBookRatingsChart()
        {
            var bookRatings = new Dictionary<string, List<double>>();

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT b.Title, br.Rating 
                                   FROM Books b 
                                   INNER JOIN BookRatings br ON b.BookID = br.BookID";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            double rating = Convert.ToDouble(reader["Rating"]);

                            if (!bookRatings.ContainsKey(title))
                            {
                                bookRatings[title] = new List<double>();
                            }
                            bookRatings[title].Add(rating);
                        }
                    }
                }

                // Calculate average ratings and prepare chart data
                var series = new List<ISeries>();
                int index = 0;

                foreach (var book in bookRatings)
                {
                    double averageRating = book.Value.Count > 0 ? book.Value.Average() : 0;
                    var color = chartColors[index % chartColors.Length];

                    var columnSeries = new ColumnSeries<double>
                    {
                        Name = book.Key,
                        Fill = new SolidColorPaint(color),
                        Values = Enumerable.Repeat(0.0, index)
                            .Concat(new[] { averageRating })
                            .Concat(Enumerable.Repeat(0.0, bookRatings.Count - index - 1))
                            .ToArray()
                    };

                    series.Add(columnSeries);
                    index++;
                }

                // Configure the chart
                cartesianChartBookRating.XAxes = new[]
                {
                    new Axis
                    {
                        Labels = Enumerable.Range(0, bookRatings.Count).Select(x => "").ToArray()
                    }
                };

                cartesianChartBookRating.YAxes = new[]
                {
                    new Axis
                    {
                        Name = "Average Rating",
                        MinLimit = 0,
                        MaxLimit = 10
                    }
                };

                cartesianChartBookRating.Series = series.ToArray();
                cartesianChartBookRating.LegendPosition = LegendPosition.Right;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading book ratings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMostBorrowedBooksChart()
        {
            var bookBorrowCounts = new Dictionary<string, int>();

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT b.Title, COUNT(*) as BorrowCount 
                                   FROM Books b 
                                   INNER JOIN BookTransactions bt ON b.BookID = bt.BookID 
                                   WHERE bt.Status IN ('Approved', 'Returned') 
                                   GROUP BY b.Title 
                                   ORDER BY COUNT(*) DESC";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            int borrowCount = Convert.ToInt32(reader["BorrowCount"]);
                            bookBorrowCounts[title] = borrowCount;
                        }
                    }
                }

                // Prepare chart data
                var series = new List<ISeries>();
                int index = 0;

                foreach (var book in bookBorrowCounts)
                {
                    var color = chartColors[index % chartColors.Length];

                    var columnSeries = new ColumnSeries<double>
                    {
                        Name = book.Key,
                        Fill = new SolidColorPaint(color),
                        Values = Enumerable.Repeat(0.0, index)
                            .Concat(new[] { (double)book.Value })
                            .Concat(Enumerable.Repeat(0.0, bookBorrowCounts.Count - index - 1))
                            .ToArray()
                    };

                    series.Add(columnSeries);
                    index++;
                }

                // Configure the chart
                cartesianChartMostBorrowedBooks.XAxes = new[]
                {
                    new Axis
                    {
                        Labels = Enumerable.Range(0, bookBorrowCounts.Count).Select(x => "").ToArray()
                    }
                };

                cartesianChartMostBorrowedBooks.YAxes = new[]
                {
                    new Axis
                    {
                        Name = "Times Borrowed",
                        MinLimit = 0
                    }
                };

                cartesianChartMostBorrowedBooks.Series = series.ToArray();
                cartesianChartMostBorrowedBooks.LegendPosition = LegendPosition.Right;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading most borrowed books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewBookReviews_Click(object sender, EventArgs e)
        {
            // Hide charts and show book reviews
            cartesianChartBookRating.Visible = false;
            cartesianChartMostBorrowedBooks.Visible = false;
            dataGridView_BookReviews.Visible = true;
            comboBoxBookSearch.Visible = true;
            label2.Visible = true;

            // Load book reviews data
            LoadBookReviews();

            // Update button states visually
            btnViewBookReviews.ButtonBackColor = Color.FromArgb(74, 128, 235); // Pressed color
            btnBookRatings.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
            btnViewMostBorrowed.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
        }

        private void LoadBookReviews()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT BookRatings.RatingID, Users.Fullname, Books.Title, Books.ISBN, BookRatings.Rating, BookRatings.RatingDate
FROM Genres INNER JOIN (Users INNER JOIN (Books INNER JOIN BookRatings ON Books.BookID = BookRatings.BookID) ON Users.UserID = BookRatings.UserID) ON Genres.GenreID = Books.GenreID;";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView_BookReviews.DataSource = dataTable;

                        // Configure date format
                        if (dataGridView_BookReviews.Columns.Contains("RatingDate"))
                        {
                            dataGridView_BookReviews.Columns["RatingDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

                        // Style the DataGridView
                        StyleDataGridView();

                        // Load book titles for filter
                        LoadBookTitlesFromGrid(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading book reviews: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            dataGridView_BookReviews.EnableHeadersVisualStyles = false;
            dataGridView_BookReviews.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dataGridView_BookReviews.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_BookReviews.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView_BookReviews.RowHeadersVisible = false;
            dataGridView_BookReviews.BorderStyle = BorderStyle.None;
            dataGridView_BookReviews.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_BookReviews.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView_BookReviews.RowTemplate.Height = 35;
            dataGridView_BookReviews.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView_BookReviews.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridView_BookReviews.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadBookTitlesFromGrid(DataTable dataTable)
        {
            try
            {
                // Clear previous items
                comboBoxBookSearch.Items.Clear();

                // Add "All Books" option
                comboBoxBookSearch.Items.Add("All Books");

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
                    comboBoxBookSearch.Items.AddRange(sortedTitles.ToArray());
                }

                // Select "All Books" by default
                if (comboBoxBookSearch.Items.Count > 0)
                {
                    comboBoxBookSearch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading book titles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxBookSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                if (dataGridView_BookReviews.DataSource is DataTable dt)
                {
                    StringBuilder filterBuilder = new StringBuilder();

                    // Book title filter from combobox
                    if (!string.IsNullOrEmpty(comboBoxBookSearch.Text) && comboBoxBookSearch.Text != "All Books")
                    {
                        string bookTitle = comboBoxBookSearch.Text.Replace("'", "''");
                        filterBuilder.AppendFormat("[Title] = '{0}'", bookTitle);
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

        private void btnBookRatings_Click(object sender, EventArgs e)
        {
            cartesianChartBookRating.Visible = true;
            cartesianChartMostBorrowedBooks.Visible = false;
            dataGridView_BookReviews.Visible = false;
            comboBoxBookSearch.Visible = false;
            label2.Visible = false;

            // Optional: Update the button states visually
            btnBookRatings.ButtonBackColor = Color.FromArgb(74, 128, 235); // Pressed color
            btnViewMostBorrowed.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
            btnViewBookReviews.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
        }

        private void btnViewMostBorrowed_Click(object sender, EventArgs e)
        {
            cartesianChartBookRating.Visible = false;
            cartesianChartMostBorrowedBooks.Visible = true;
            dataGridView_BookReviews.Visible = false;
            comboBoxBookSearch.Visible = false;
            label2.Visible = false;

            // Optional: Update the button states visually
            btnViewMostBorrowed.ButtonBackColor = Color.FromArgb(74, 128, 235); // Pressed color
            btnBookRatings.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
            btnViewBookReviews.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
        }

        private void dataGridView_BookReviews_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
