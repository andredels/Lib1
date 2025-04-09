using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib1
{
    public partial class StudentMenu : Form
    {
        private int userId;
        private string fullName;

        public StudentMenu()
        {
            InitializeComponent();
            // No user data available when called from cancel buttons
        }

        public StudentMenu(int userId, string fullName)
        {
            InitializeComponent();
            this.userId = userId;
            this.fullName = fullName;
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void viewBooksBorrowedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBorrowedBooks viewBooks = new ViewBorrowedBooks();
            viewBooks.Show();
            this.Hide();
        }

        private void ToolStripMenustdntViewAllBooks_Click(object sender, EventArgs e)
        {
            ViewAllBooks viewAllBooks = new ViewAllBooks("student", this.userId);
            viewAllBooks.Show();
            this.Hide();
        }
    }
}
