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
    public partial class AdminDashBoard : Form
    {
        private string adminFullName;
        private int userId;
        private string fullName;
        public AdminDashBoard(int userId, string fullName)
        {
            InitializeComponent();
            this.userId = userId;
            this.fullName = fullName;
            this.adminFullName = fullName;
        }

        private void adminViewBooksbtn_Click(object sender, EventArgs e)
        {
            userControlpanel.Controls.Clear(); // Clear any existing content
            ViewBooks viewBooksUC = new ViewBooks("Admin"); // Create new instance of the UserControl
            viewBooksUC.Dock = DockStyle.Fill; // Optional: make it fill the panel
            userControlpanel.Controls.Add(viewBooksUC);
        }

        private void adminAddBookbtnbtn_Click(object sender, EventArgs e)
        {
            userControlpanel.Controls.Clear();
            BookAdding bookAddingUC = new BookAdding(adminFullName);
            bookAddingUC.Dock = DockStyle.Fill;
            userControlpanel.Controls.Add(bookAddingUC);
        }

        private void adminBookBorrowRequestbtn_Click(object sender, EventArgs e)
        {
            userControlpanel.Controls.Clear();
            BookBorrowRequest bookBorrowRequestUC = new BookBorrowRequest(userId, adminFullName);
            bookBorrowRequestUC.Dock = DockStyle.Fill;
            userControlpanel.Controls.Add(bookBorrowRequestUC);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            userControlpanel.Controls.Clear();
            UserApplicant userApplicantUC = new UserApplicant();
            userApplicantUC.Dock = DockStyle.Fill;
            userControlpanel.Controls.Add(userApplicantUC);
        }

        private void adminLogoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
           "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                AdminLogin adminLogin = new AdminLogin();
                adminLogin.Show();
                this.FormClosing += (s, args) => this.Dispose();
            }
        }

        private void adminBorrowedBooksbtn_Click(object sender, EventArgs e)
        {
            userControlpanel.Controls.Clear();
            BorrowedBooks borrowedBooksUC = new BorrowedBooks(true, this.userId);  // true for admin view, pass the admin's userId
            borrowedBooksUC.Dock = DockStyle.Fill;
            userControlpanel.Controls.Add(borrowedBooksUC);
        }
    }
}
