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
    public partial class AdminMenu : Form
    {
        private string adminFullName;
        private int userId;
        private string fullName;

        public AdminMenu(int userId, string fullName)
        {
            InitializeComponent();
            this.userId = userId;
            this.fullName = fullName;
            this.adminFullName = fullName;

            // You can use these values to display welcome message or for other functionality
            // For example:
            // lblWelcome.Text = "Welcome, " + fullName;
        }
        public AdminMenu()
        {
            InitializeComponent();

        }

        private void btnExitAdminMenu_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void btnAddNewBookAdmineMenu_Click(object sender, EventArgs e)
        {
            Addbook addbook = new Addbook(adminFullName);
            addbook.Show();
            this.Hide();
        }

        private void btnViewBooksAdminMenu_Click(object sender, EventArgs e)
        {
            ViewAllBooks viewAllBooks = new ViewAllBooks("Admin");
            viewAllBooks.Show();
            this.Hide();
        }

        private void btnViewStudentInfoAdminMenu_Click(object sender, EventArgs e)
        {
            ViewStudentInfo viewStudentInfo = new ViewStudentInfo();
            viewStudentInfo.Show();
            this.Hide();
        }

        private void studentRegistrantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentRegistrants studentRegistrants = new StudentRegistrants();
            studentRegistrants.Show();
            this.Hide();
        }

        private void completeBookDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompleteBookDetails completeBookDetails = new CompleteBookDetails();
            completeBookDetails.Show();
            this.Hide();
        }

        private void bookBorrowRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowRequests bookBorrowRequests = new BorrowRequests();
            bookBorrowRequests.Show();
            this.Hide();
        }
    }
}
