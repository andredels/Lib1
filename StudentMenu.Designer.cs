namespace Lib1
{
    partial class StudentMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentMenu));
            menuStrip1 = new MenuStrip();
            ToolStripMenustdntViewAllBooks = new ToolStripMenuItem();
            ToolStripMenustdntViewBorrowedBooks = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenustdntViewAllBooks, ToolStripMenustdntViewBorrowedBooks, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(904, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenustdntViewAllBooks
            // 
            ToolStripMenustdntViewAllBooks.Image = (Image)resources.GetObject("ToolStripMenustdntViewAllBooks.Image");
            ToolStripMenustdntViewAllBooks.ImageScaling = ToolStripItemImageScaling.None;
            ToolStripMenustdntViewAllBooks.Name = "ToolStripMenustdntViewAllBooks";
            ToolStripMenustdntViewAllBooks.Size = new Size(153, 36);
            ToolStripMenustdntViewAllBooks.Text = "View All Books";
            ToolStripMenustdntViewAllBooks.Click += ToolStripMenustdntViewAllBooks_Click;
            // 
            // ToolStripMenustdntViewBorrowedBooks
            // 
            ToolStripMenustdntViewBorrowedBooks.Image = (Image)resources.GetObject("ToolStripMenustdntViewBorrowedBooks.Image");
            ToolStripMenustdntViewBorrowedBooks.ImageScaling = ToolStripItemImageScaling.None;
            ToolStripMenustdntViewBorrowedBooks.Name = "ToolStripMenustdntViewBorrowedBooks";
            ToolStripMenustdntViewBorrowedBooks.Size = new Size(200, 36);
            ToolStripMenustdntViewBorrowedBooks.Text = "View Books Borrowed";
            ToolStripMenustdntViewBorrowedBooks.Click += viewBooksBorrowedToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = (Image)resources.GetObject("exitToolStripMenuItem.Image");
            exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(79, 36);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // StudentMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(904, 503);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "StudentMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenustdntViewAllBooks;
        private ToolStripMenuItem ToolStripMenustdntViewBorrowedBooks;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}