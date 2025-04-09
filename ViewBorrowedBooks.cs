using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ViewBorrowedBooks : Form
    {


        public ViewBorrowedBooks()
        {
            InitializeComponent();
        }

        private void btnCancelViewBorrowedBooks_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            studentMenu.Show(this);
            this.Hide();
        }
    }
}
