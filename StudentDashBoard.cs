using Microsoft.VisualBasic.Logging;
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
    public partial class StudentDashBoard : Form
    {
        private int userId;
        private string fullName;
        public StudentDashBoard()
        {
            InitializeComponent();
        }
        public StudentDashBoard(int userId, string fullName)
        {
            InitializeComponent();
            this.userId = userId;
            this.fullName = fullName;
        }

        private void studentViewBooksbtn_Click(object sender, EventArgs e)
        {

            userControlpanel.Controls.Clear();
            ViewBooks viewBooksUC = new ViewBooks("Student", this.userId); // Pass the userId here
            viewBooksUC.Dock = DockStyle.Fill;
            userControlpanel.Controls.Add(viewBooksUC);
        }

        private void studentBorrowedBooksbtn_Click(object sender, EventArgs e)
        {
            userControlpanel.Controls.Clear();
            BorrowedBooks borrowedBooksUC = new BorrowedBooks(false, this.userId);  // false for student view, pass the userId
            borrowedBooksUC.Dock = DockStyle.Fill;
            userControlpanel.Controls.Add(borrowedBooksUC);
        }

        private void studentAccountSettingsbtn_Click(object sender, EventArgs e)
        {
            userControlpanel.Controls.Clear();
            AccountSettings accountSettingsUC = new AccountSettings(this.userId);
            accountSettingsUC.Dock = DockStyle.Fill;
            userControlpanel.Controls.Add(accountSettingsUC);
        }

        private void studentLogoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
            "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the current form
                this.Hide();

                // Open the login form
                Form1 loginForm = new Form1();
                loginForm.Show();

                // Dispose the current form when closed
                this.FormClosing += (s, args) => this.Dispose();
            }
        }
    }
}
