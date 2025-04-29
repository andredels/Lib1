using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace Lib1
{
    public partial class Analytics : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb";
        
        public Analytics()
        {
            InitializeComponent();
            LoadBookRatingsChart();
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
                var values = new List<double>();
                var labels = new List<string>();

                foreach (var book in bookRatings)
                {
                    double averageRating = book.Value.Count > 0 ? book.Value.Average() : 0;
                    values.Add(averageRating);
                    labels.Add(book.Key);
                }

                // Configure the chart
                cartesianChartBookRating.XAxes = new[]
                {
                    new Axis
                    {
                        Labels = labels.ToArray(),
                        LabelsRotation = 45
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

                cartesianChartBookRating.Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Values = values.ToArray(),
                        Fill = new SolidColorPaint(SKColors.BurlyWood),
                        Name = "Average Book Rating"
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading book ratings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
