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
    public partial class Addbook : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Lib.accdb;";
        private string adminFullName;
        public Addbook(string adminName)
        {
            InitializeComponent();
            adminFullName = adminName;
        }

        private void btnCancelAddbook_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }

        private void txtbxAddBookTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxAddBookAuthorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxAddBookPublicationYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxAddBookPublisher_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxAddBookQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticonebtn_AddBookSave_Click(object sender, EventArgs e)
        {
            string title = txtbxAddBookTitle.Text.Trim();
            string author = txtbxAddBookAuthorName.Text.Trim();
            string publisher = txtbxAddBookPublisher.Text.Trim();
            string publicationYearText = txtbxAddBookPublicationYear.Text.Trim();
            string quantityText = txtbxAddBookQuantity.Text.Trim();
            string dateAdded = DateTime.Now.ToString("yyyy-MM-dd"); // Automatically store today's date

            // Validate input
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(publisher) ||
                string.IsNullOrEmpty(publicationYearText) || string.IsNullOrEmpty(quantityText))
            {
                MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // ✅ Insert book with automatic DateAdded and AddedBy
                    string query = "INSERT INTO Books (Title, Author, Publisher, PublicationYear, TotalCopies, AvailableCopies, DateAdded, AddedBy) " +
                                   "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", title);
                        cmd.Parameters.AddWithValue("?", author);
                        cmd.Parameters.AddWithValue("?", publisher);
                        cmd.Parameters.AddWithValue("?", publicationYear);
                        cmd.Parameters.AddWithValue("?", quantity);
                        cmd.Parameters.AddWithValue("?", quantity);
                        cmd.Parameters.AddWithValue("?", DateTime.Parse(dateAdded)); // Auto-fill date
                        cmd.Parameters.AddWithValue("?", adminFullName); // Auto-fill admin's name

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    conn.Close();
                }

                // Clear fields after saving
                txtbxAddBookTitle.Clear();
                txtbxAddBookAuthorName.Clear();
                txtbxAddBookPublisher.Clear();
                txtbxAddBookPublicationYear.Clear();
                txtbxAddBookQuantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

