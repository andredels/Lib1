namespace Lib1
{
    partial class AdminMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenu));
            menuStrip1 = new MenuStrip();
            btnBooksAdminMenu = new ToolStripMenuItem();
            btnAddNewBookAdmineMenu = new ToolStripMenuItem();
            btnViewBooksAdminMenu = new ToolStripMenuItem();
            bookBorrowRequestsToolStripMenuItem = new ToolStripMenuItem();
            btnStudentAdminMenu = new ToolStripMenuItem();
            btnViewStudentInfoAdminMenu = new ToolStripMenuItem();
            studentRegistrantsToolStripMenuItem = new ToolStripMenuItem();
            completeBookDetailsToolStripMenuItem1 = new ToolStripMenuItem();
            btnExitAdminMenu = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnBooksAdminMenu, btnStudentAdminMenu, completeBookDetailsToolStripMenuItem1, btnExitAdminMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(738, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnBooksAdminMenu
            // 
            btnBooksAdminMenu.DropDownItems.AddRange(new ToolStripItem[] { btnAddNewBookAdmineMenu, btnViewBooksAdminMenu, bookBorrowRequestsToolStripMenuItem });
            btnBooksAdminMenu.Image = (Image)resources.GetObject("btnBooksAdminMenu.Image");
            btnBooksAdminMenu.ImageScaling = ToolStripItemImageScaling.None;
            btnBooksAdminMenu.Name = "btnBooksAdminMenu";
            btnBooksAdminMenu.Size = new Size(95, 36);
            btnBooksAdminMenu.Text = "Books";
            // 
            // btnAddNewBookAdmineMenu
            // 
            btnAddNewBookAdmineMenu.Image = (Image)resources.GetObject("btnAddNewBookAdmineMenu.Image");
            btnAddNewBookAdmineMenu.ImageScaling = ToolStripItemImageScaling.None;
            btnAddNewBookAdmineMenu.Name = "btnAddNewBookAdmineMenu";
            btnAddNewBookAdmineMenu.Size = new Size(253, 38);
            btnAddNewBookAdmineMenu.Text = "Add New Book";
            btnAddNewBookAdmineMenu.Click += btnAddNewBookAdmineMenu_Click;
            // 
            // btnViewBooksAdminMenu
            // 
            btnViewBooksAdminMenu.Image = (Image)resources.GetObject("btnViewBooksAdminMenu.Image");
            btnViewBooksAdminMenu.ImageScaling = ToolStripItemImageScaling.None;
            btnViewBooksAdminMenu.Name = "btnViewBooksAdminMenu";
            btnViewBooksAdminMenu.Size = new Size(253, 38);
            btnViewBooksAdminMenu.Text = "View Books";
            btnViewBooksAdminMenu.Click += btnViewBooksAdminMenu_Click;
            // 
            // bookBorrowRequestsToolStripMenuItem
            // 
            bookBorrowRequestsToolStripMenuItem.Image = (Image)resources.GetObject("bookBorrowRequestsToolStripMenuItem.Image");
            bookBorrowRequestsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            bookBorrowRequestsToolStripMenuItem.Name = "bookBorrowRequestsToolStripMenuItem";
            bookBorrowRequestsToolStripMenuItem.Size = new Size(253, 38);
            bookBorrowRequestsToolStripMenuItem.Text = "Book Borrow Requests";
            bookBorrowRequestsToolStripMenuItem.Click += bookBorrowRequestsToolStripMenuItem_Click;
            // 
            // btnStudentAdminMenu
            // 
            btnStudentAdminMenu.DropDownItems.AddRange(new ToolStripItem[] { btnViewStudentInfoAdminMenu, studentRegistrantsToolStripMenuItem });
            btnStudentAdminMenu.Image = (Image)resources.GetObject("btnStudentAdminMenu.Image");
            btnStudentAdminMenu.ImageScaling = ToolStripItemImageScaling.None;
            btnStudentAdminMenu.Name = "btnStudentAdminMenu";
            btnStudentAdminMenu.Size = new Size(106, 36);
            btnStudentAdminMenu.Text = "Student";
            // 
            // btnViewStudentInfoAdminMenu
            // 
            btnViewStudentInfoAdminMenu.Image = (Image)resources.GetObject("btnViewStudentInfoAdminMenu.Image");
            btnViewStudentInfoAdminMenu.ImageScaling = ToolStripItemImageScaling.None;
            btnViewStudentInfoAdminMenu.Name = "btnViewStudentInfoAdminMenu";
            btnViewStudentInfoAdminMenu.Size = new Size(232, 38);
            btnViewStudentInfoAdminMenu.Text = "View Student Info";
            btnViewStudentInfoAdminMenu.Click += btnViewStudentInfoAdminMenu_Click;
            // 
            // studentRegistrantsToolStripMenuItem
            // 
            studentRegistrantsToolStripMenuItem.Image = (Image)resources.GetObject("studentRegistrantsToolStripMenuItem.Image");
            studentRegistrantsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            studentRegistrantsToolStripMenuItem.Name = "studentRegistrantsToolStripMenuItem";
            studentRegistrantsToolStripMenuItem.Size = new Size(232, 38);
            studentRegistrantsToolStripMenuItem.Text = "Student Registrants";
            studentRegistrantsToolStripMenuItem.Click += studentRegistrantsToolStripMenuItem_Click;
            // 
            // completeBookDetailsToolStripMenuItem1
            // 
            completeBookDetailsToolStripMenuItem1.Image = (Image)resources.GetObject("completeBookDetailsToolStripMenuItem1.Image");
            completeBookDetailsToolStripMenuItem1.Name = "completeBookDetailsToolStripMenuItem1";
            completeBookDetailsToolStripMenuItem1.Size = new Size(196, 36);
            completeBookDetailsToolStripMenuItem1.Text = "Complete Book Details";
            completeBookDetailsToolStripMenuItem1.Click += completeBookDetailsToolStripMenuItem1_Click;
            // 
            // btnExitAdminMenu
            // 
            btnExitAdminMenu.Image = (Image)resources.GetObject("btnExitAdminMenu.Image");
            btnExitAdminMenu.ImageScaling = ToolStripItemImageScaling.None;
            btnExitAdminMenu.Name = "btnExitAdminMenu";
            btnExitAdminMenu.Size = new Size(79, 36);
            btnExitAdminMenu.Text = "Exit";
            btnExitAdminMenu.Click += btnExitAdminMenu_Click;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(738, 413);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "AdminMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnBooksAdminMenu;
        private ToolStripMenuItem btnStudentAdminMenu;
        private ToolStripMenuItem completeBookDetailsToolStripMenuItem1;
        private ToolStripMenuItem btnExitAdminMenu;
        private ToolStripMenuItem btnAddNewBookAdmineMenu;
        private ToolStripMenuItem btnViewBooksAdminMenu;
        private ToolStripMenuItem btnViewStudentInfoAdminMenu;
        private ToolStripMenuItem studentRegistrantsToolStripMenuItem;
        private ToolStripMenuItem bookBorrowRequestsToolStripMenuItem;
    }
}