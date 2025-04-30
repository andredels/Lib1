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

        public Analytics()
        {
            InitializeComponent();
            
            // Initialize both charts but only show Book Ratings chart
            LoadBookRatingsChart();
            LoadMostBorrowedBooksChart();
            
            // Set initial visibility
            cartesianChartBookRating.Visible = true;
            cartesianChartMostBorrowedBooks.Visible = false;
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

        private void btnBookRatings_Click(object sender, EventArgs e)
        {
            cartesianChartBookRating.Visible = true;
            cartesianChartMostBorrowedBooks.Visible = false;
            
            // Optional: Update the button states visually
            btnBookRatings.ButtonBackColor = Color.FromArgb(74, 128, 235); // Pressed color
            btnViewMostBorrowed.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
        }

        private void btnViewMostBorrowed_Click(object sender, EventArgs e)
        {
            cartesianChartBookRating.Visible = false;
            cartesianChartMostBorrowedBooks.Visible = true;
            
            // Optional: Update the button states visually
            btnViewMostBorrowed.ButtonBackColor = Color.FromArgb(74, 128, 235); // Pressed color
            btnBookRatings.ButtonBackColor = Color.FromArgb(255, 128, 0); // Normal color
        }
    }
}
