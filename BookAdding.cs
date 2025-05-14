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
    public partial class BookAdding : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";
        private string adminFullName;
        public BookAdding(string adminName)
        {
            InitializeComponent();
            adminFullName = adminName;
            LoadGenres();
        }
        private void LoadGenres()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT GenreID, GenreName FROM Genres ORDER BY GenreName";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable genreTable = new DataTable();
                        adapter.Fill(genreTable);

                        comboBoxAddBookGenre.DataSource = genreTable;
                        comboBoxAddBookGenre.DisplayMember = "GenreName";
                        comboBoxAddBookGenre.ValueMember = "GenreID";
                        comboBoxAddBookGenre.SelectedIndex = -1; 
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading genres: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtbxAddBookISBN_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbxAddBookISBN.Text))
            {
                if (!txtbxAddBookISBN.Text.All(char.IsDigit))
                {
                    MessageBox.Show("ISBN must contain only numbers", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbxAddBookISBN.Text = string.Empty;
                }
            }
        }
        private void siticonebtn_AddBookSave_Click(object sender, EventArgs e)
        {
            string title = txtbxAddBookTitle.Text.Trim();
            string author = txtbxAddBookAuthorName.Text.Trim();
            string publisher = txtbxAddBookPublisher.Text.Trim();
            string publicationYearText = txtbxAddBookPublicationYear.Text.Trim();
            string quantityText = txtbxAddBookQuantity.Text.Trim();
            string isbn = txtbxAddBookISBN.Text.Trim();
            string dateAdded = DateTime.Now.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(publisher) ||
                string.IsNullOrEmpty(publicationYearText) || string.IsNullOrEmpty(quantityText) ||
                string.IsNullOrEmpty(isbn) || comboBoxAddBookGenre.SelectedIndex == -1)
            {
                MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isbn.All(char.IsDigit))
            {
                MessageBox.Show("ISBN must contain only numbers", "Invalid ISBN",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isbn.Length != 10 && isbn.Length != 13)
            {
                MessageBox.Show("ISBN must be either 10 or 13 digits long", "Invalid ISBN",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(publicationYearText, out int publicationYear))
            {
                MessageBox.Show("Publication Year must be a valid number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity < 1)
            {
                MessageBox.Show("Quantity must be a valid positive number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Books WHERE ISBN = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", isbn);
                        int existingBooks = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingBooks > 0)
                        {
                            MessageBox.Show("A book with this ISBN already exists in the library. ISBN must be unique for each book.", 
                                "Duplicate ISBN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int genreID;
                    if (comboBoxAddBookGenre.SelectedValue != null)
                    {
                        genreID = Convert.ToInt32(comboBoxAddBookGenre.SelectedValue);
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid genre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "INSERT INTO Books (Title, Author, Publisher, PublicationYear, TotalCopies, AvailableCopies, DateAdded, AddedBy, ISBN, GenreID) " +
                                   "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", title);
                        cmd.Parameters.AddWithValue("?", author);
                        cmd.Parameters.AddWithValue("?", publisher);
                        cmd.Parameters.AddWithValue("?", publicationYear);
                        cmd.Parameters.AddWithValue("?", quantity); 
                        cmd.Parameters.AddWithValue("?", quantity); 
                        cmd.Parameters.AddWithValue("?", DateTime.Parse(dateAdded));
                        cmd.Parameters.AddWithValue("?", adminFullName);
                        cmd.Parameters.AddWithValue("?", isbn);
                        cmd.Parameters.AddWithValue("?", genreID); 

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    conn.Close();
                }
                txtbxAddBookTitle.Clear();
                txtbxAddBookAuthorName.Clear();
                txtbxAddBookPublisher.Clear();
                txtbxAddBookPublicationYear.Clear();
                txtbxAddBookQuantity.Clear();
                txtbxAddBookISBN.Clear();
                comboBoxAddBookGenre.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
