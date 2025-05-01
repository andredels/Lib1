namespace Lib1
{
    partial class Analytics
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analytics));
            panel1 = new Panel();
            label2 = new Label();
            comboBoxBookSearch = new ComboBox();
            btnViewBookReviews = new SiticoneNetCoreUI.SiticoneButton();
            btnViewMostBorrowed = new SiticoneNetCoreUI.SiticoneButton();
            btnBookRatings = new SiticoneNetCoreUI.SiticoneButton();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            cartesianChartBookRating = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            panel2 = new Panel();
            dataGridView_BookReviews = new DataGridView();
            cartesianChartMostBorrowedBooks = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_BookReviews).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBoxBookSearch);
            panel1.Controls.Add(btnViewBookReviews);
            panel1.Controls.Add(btnViewMostBorrowed);
            panel1.Controls.Add(btnBookRatings);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 125);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1000, 48);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 89;
            label2.Text = "Book Title";
            // 
            // comboBoxBookSearch
            // 
            comboBoxBookSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBookSearch.FormattingEnabled = true;
            comboBoxBookSearch.Location = new Point(853, 17);
            comboBoxBookSearch.Name = "comboBoxBookSearch";
            comboBoxBookSearch.Size = new Size(223, 28);
            comboBoxBookSearch.TabIndex = 88;
            comboBoxBookSearch.SelectedIndexChanged += comboBoxBookSearch_SelectedIndexChanged;
            // 
            // btnViewBookReviews
            // 
            btnViewBookReviews.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnViewBookReviews.AccessibleName = "View Book Reviews";
            btnViewBookReviews.AutoSizeBasedOnText = false;
            btnViewBookReviews.BackColor = Color.Transparent;
            btnViewBookReviews.BadgeBackColor = Color.Red;
            btnViewBookReviews.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnViewBookReviews.BadgeValue = 0;
            btnViewBookReviews.BadgeValueForeColor = Color.White;
            btnViewBookReviews.BorderColor = Color.Transparent;
            btnViewBookReviews.BorderWidth = 2;
            btnViewBookReviews.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnViewBookReviews.ButtonImage = null;
            btnViewBookReviews.CanBeep = true;
            btnViewBookReviews.CanGlow = false;
            btnViewBookReviews.CanShake = true;
            btnViewBookReviews.ContextMenuStripEx = null;
            btnViewBookReviews.CornerRadiusBottomLeft = 8;
            btnViewBookReviews.CornerRadiusBottomRight = 8;
            btnViewBookReviews.CornerRadiusTopLeft = 8;
            btnViewBookReviews.CornerRadiusTopRight = 8;
            btnViewBookReviews.CustomCursor = Cursors.Default;
            btnViewBookReviews.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnViewBookReviews.EnableLongPress = false;
            btnViewBookReviews.EnablePressAnimation = true;
            btnViewBookReviews.EnableRippleEffect = true;
            btnViewBookReviews.EnableShadow = false;
            btnViewBookReviews.EnableTextWrapping = false;
            btnViewBookReviews.Font = new Font("Segoe UI", 9F);
            btnViewBookReviews.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnViewBookReviews.GlowIntensity = 100;
            btnViewBookReviews.GlowRadius = 20F;
            btnViewBookReviews.GradientBackground = false;
            btnViewBookReviews.GradientColor = Color.FromArgb(114, 168, 255);
            btnViewBookReviews.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnViewBookReviews.HintText = null;
            btnViewBookReviews.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnViewBookReviews.HoverFontStyle = FontStyle.Regular;
            btnViewBookReviews.HoverTextColor = Color.White;
            btnViewBookReviews.HoverTransitionDuration = 250;
            btnViewBookReviews.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewBookReviews.ImagePadding = 5;
            btnViewBookReviews.ImageSize = new Size(16, 16);
            btnViewBookReviews.IsRadial = false;
            btnViewBookReviews.IsReadOnly = false;
            btnViewBookReviews.IsToggleButton = false;
            btnViewBookReviews.IsToggled = false;
            btnViewBookReviews.Location = new Point(456, 79);
            btnViewBookReviews.LongPressDurationMS = 1000;
            btnViewBookReviews.Name = "btnViewBookReviews";
            btnViewBookReviews.NormalFontStyle = FontStyle.Regular;
            btnViewBookReviews.ParticleColor = Color.FromArgb(200, 200, 200);
            btnViewBookReviews.ParticleCount = 15;
            btnViewBookReviews.PressAnimationScale = 0.97F;
            btnViewBookReviews.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnViewBookReviews.PressedFontStyle = FontStyle.Regular;
            btnViewBookReviews.PressTransitionDuration = 150;
            btnViewBookReviews.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnViewBookReviews.RippleColor = Color.FromArgb(255, 255, 255);
            btnViewBookReviews.RippleOpacity = 0.3F;
            btnViewBookReviews.RippleRadiusMultiplier = 0.6F;
            btnViewBookReviews.ShadowBlur = 5;
            btnViewBookReviews.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnViewBookReviews.ShadowOffset = new Point(2, 2);
            btnViewBookReviews.ShakeDuration = 500;
            btnViewBookReviews.ShakeIntensity = 5;
            btnViewBookReviews.Size = new Size(210, 34);
            btnViewBookReviews.TabIndex = 87;
            btnViewBookReviews.Text = "View Book Reviews";
            btnViewBookReviews.TextAlign = ContentAlignment.MiddleCenter;
            btnViewBookReviews.TextColor = Color.White;
            btnViewBookReviews.TooltipText = null;
            btnViewBookReviews.UseAdvancedRendering = true;
            btnViewBookReviews.UseParticles = false;
            btnViewBookReviews.Click += btnViewBookReviews_Click;
            // 
            // btnViewMostBorrowed
            // 
            btnViewMostBorrowed.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnViewMostBorrowed.AccessibleName = "View Most Borrowed Books";
            btnViewMostBorrowed.AutoSizeBasedOnText = false;
            btnViewMostBorrowed.BackColor = Color.Transparent;
            btnViewMostBorrowed.BadgeBackColor = Color.Red;
            btnViewMostBorrowed.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnViewMostBorrowed.BadgeValue = 0;
            btnViewMostBorrowed.BadgeValueForeColor = Color.White;
            btnViewMostBorrowed.BorderColor = Color.Transparent;
            btnViewMostBorrowed.BorderWidth = 2;
            btnViewMostBorrowed.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnViewMostBorrowed.ButtonImage = null;
            btnViewMostBorrowed.CanBeep = true;
            btnViewMostBorrowed.CanGlow = false;
            btnViewMostBorrowed.CanShake = true;
            btnViewMostBorrowed.ContextMenuStripEx = null;
            btnViewMostBorrowed.CornerRadiusBottomLeft = 8;
            btnViewMostBorrowed.CornerRadiusBottomRight = 8;
            btnViewMostBorrowed.CornerRadiusTopLeft = 8;
            btnViewMostBorrowed.CornerRadiusTopRight = 8;
            btnViewMostBorrowed.CustomCursor = Cursors.Default;
            btnViewMostBorrowed.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnViewMostBorrowed.EnableLongPress = false;
            btnViewMostBorrowed.EnablePressAnimation = true;
            btnViewMostBorrowed.EnableRippleEffect = true;
            btnViewMostBorrowed.EnableShadow = false;
            btnViewMostBorrowed.EnableTextWrapping = false;
            btnViewMostBorrowed.Font = new Font("Segoe UI", 9F);
            btnViewMostBorrowed.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnViewMostBorrowed.GlowIntensity = 100;
            btnViewMostBorrowed.GlowRadius = 20F;
            btnViewMostBorrowed.GradientBackground = false;
            btnViewMostBorrowed.GradientColor = Color.FromArgb(114, 168, 255);
            btnViewMostBorrowed.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnViewMostBorrowed.HintText = null;
            btnViewMostBorrowed.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnViewMostBorrowed.HoverFontStyle = FontStyle.Regular;
            btnViewMostBorrowed.HoverTextColor = Color.White;
            btnViewMostBorrowed.HoverTransitionDuration = 250;
            btnViewMostBorrowed.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewMostBorrowed.ImagePadding = 5;
            btnViewMostBorrowed.ImageSize = new Size(16, 16);
            btnViewMostBorrowed.IsRadial = false;
            btnViewMostBorrowed.IsReadOnly = false;
            btnViewMostBorrowed.IsToggleButton = false;
            btnViewMostBorrowed.IsToggled = false;
            btnViewMostBorrowed.Location = new Point(888, 79);
            btnViewMostBorrowed.LongPressDurationMS = 1000;
            btnViewMostBorrowed.Name = "btnViewMostBorrowed";
            btnViewMostBorrowed.NormalFontStyle = FontStyle.Regular;
            btnViewMostBorrowed.ParticleColor = Color.FromArgb(200, 200, 200);
            btnViewMostBorrowed.ParticleCount = 15;
            btnViewMostBorrowed.PressAnimationScale = 0.97F;
            btnViewMostBorrowed.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnViewMostBorrowed.PressedFontStyle = FontStyle.Regular;
            btnViewMostBorrowed.PressTransitionDuration = 150;
            btnViewMostBorrowed.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnViewMostBorrowed.RippleColor = Color.FromArgb(255, 255, 255);
            btnViewMostBorrowed.RippleOpacity = 0.3F;
            btnViewMostBorrowed.RippleRadiusMultiplier = 0.6F;
            btnViewMostBorrowed.ShadowBlur = 5;
            btnViewMostBorrowed.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnViewMostBorrowed.ShadowOffset = new Point(2, 2);
            btnViewMostBorrowed.ShakeDuration = 500;
            btnViewMostBorrowed.ShakeIntensity = 5;
            btnViewMostBorrowed.Size = new Size(210, 34);
            btnViewMostBorrowed.TabIndex = 86;
            btnViewMostBorrowed.Text = "View Most Borrowed Books";
            btnViewMostBorrowed.TextAlign = ContentAlignment.MiddleCenter;
            btnViewMostBorrowed.TextColor = Color.White;
            btnViewMostBorrowed.TooltipText = null;
            btnViewMostBorrowed.UseAdvancedRendering = true;
            btnViewMostBorrowed.UseParticles = false;
            btnViewMostBorrowed.Click += btnViewMostBorrowed_Click;
            // 
            // btnBookRatings
            // 
            btnBookRatings.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnBookRatings.AccessibleName = "View Book Ratings";
            btnBookRatings.AutoSizeBasedOnText = false;
            btnBookRatings.BackColor = Color.Transparent;
            btnBookRatings.BadgeBackColor = Color.Red;
            btnBookRatings.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnBookRatings.BadgeValue = 0;
            btnBookRatings.BadgeValueForeColor = Color.White;
            btnBookRatings.BorderColor = Color.Transparent;
            btnBookRatings.BorderWidth = 2;
            btnBookRatings.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnBookRatings.ButtonImage = null;
            btnBookRatings.CanBeep = true;
            btnBookRatings.CanGlow = false;
            btnBookRatings.CanShake = true;
            btnBookRatings.ContextMenuStripEx = null;
            btnBookRatings.CornerRadiusBottomLeft = 8;
            btnBookRatings.CornerRadiusBottomRight = 8;
            btnBookRatings.CornerRadiusTopLeft = 8;
            btnBookRatings.CornerRadiusTopRight = 8;
            btnBookRatings.CustomCursor = Cursors.Default;
            btnBookRatings.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnBookRatings.EnableLongPress = false;
            btnBookRatings.EnablePressAnimation = true;
            btnBookRatings.EnableRippleEffect = true;
            btnBookRatings.EnableShadow = false;
            btnBookRatings.EnableTextWrapping = false;
            btnBookRatings.Font = new Font("Segoe UI", 9F);
            btnBookRatings.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnBookRatings.GlowIntensity = 100;
            btnBookRatings.GlowRadius = 20F;
            btnBookRatings.GradientBackground = false;
            btnBookRatings.GradientColor = Color.FromArgb(114, 168, 255);
            btnBookRatings.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnBookRatings.HintText = null;
            btnBookRatings.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnBookRatings.HoverFontStyle = FontStyle.Regular;
            btnBookRatings.HoverTextColor = Color.White;
            btnBookRatings.HoverTransitionDuration = 250;
            btnBookRatings.ImageAlign = ContentAlignment.MiddleLeft;
            btnBookRatings.ImagePadding = 5;
            btnBookRatings.ImageSize = new Size(16, 16);
            btnBookRatings.IsRadial = false;
            btnBookRatings.IsReadOnly = false;
            btnBookRatings.IsToggleButton = false;
            btnBookRatings.IsToggled = false;
            btnBookRatings.Location = new Point(672, 79);
            btnBookRatings.LongPressDurationMS = 1000;
            btnBookRatings.Name = "btnBookRatings";
            btnBookRatings.NormalFontStyle = FontStyle.Regular;
            btnBookRatings.ParticleColor = Color.FromArgb(200, 200, 200);
            btnBookRatings.ParticleCount = 15;
            btnBookRatings.PressAnimationScale = 0.97F;
            btnBookRatings.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnBookRatings.PressedFontStyle = FontStyle.Regular;
            btnBookRatings.PressTransitionDuration = 150;
            btnBookRatings.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnBookRatings.RippleColor = Color.FromArgb(255, 255, 255);
            btnBookRatings.RippleOpacity = 0.3F;
            btnBookRatings.RippleRadiusMultiplier = 0.6F;
            btnBookRatings.ShadowBlur = 5;
            btnBookRatings.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnBookRatings.ShadowOffset = new Point(2, 2);
            btnBookRatings.ShakeDuration = 500;
            btnBookRatings.ShakeIntensity = 5;
            btnBookRatings.Size = new Size(210, 34);
            btnBookRatings.TabIndex = 85;
            btnBookRatings.Text = "View Book Ratings";
            btnBookRatings.TextAlign = ContentAlignment.MiddleCenter;
            btnBookRatings.TextColor = Color.White;
            btnBookRatings.TooltipText = null;
            btnBookRatings.UseAdvancedRendering = true;
            btnBookRatings.UseParticles = false;
            btnBookRatings.Click += btnBookRatings_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(162, 45);
            label1.Name = "label1";
            label1.Size = new Size(289, 41);
            label1.TabIndex = 3;
            label1.Text = "BOOK POPULARITY";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(17, 17);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(127, 105);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // cartesianChartBookRating
            // 
            cartesianChartBookRating.BackColor = Color.White;
            cartesianChartBookRating.Dock = DockStyle.Fill;
            cartesianChartBookRating.Location = new Point(0, 0);
            cartesianChartBookRating.MatchAxesScreenDataRatio = false;
            cartesianChartBookRating.Name = "cartesianChartBookRating";
            cartesianChartBookRating.Size = new Size(1059, 543);
            cartesianChartBookRating.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dataGridView_BookReviews);
            panel2.Controls.Add(cartesianChartBookRating);
            panel2.Controls.Add(cartesianChartMostBorrowedBooks);
            panel2.Location = new Point(17, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(1059, 543);
            panel2.TabIndex = 3;
            // 
            // dataGridView_BookReviews
            // 
            dataGridView_BookReviews.BackgroundColor = Color.BurlyWood;
            dataGridView_BookReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_BookReviews.Dock = DockStyle.Fill;
            dataGridView_BookReviews.Location = new Point(0, 0);
            dataGridView_BookReviews.Name = "dataGridView_BookReviews";
            dataGridView_BookReviews.ReadOnly = true;
            dataGridView_BookReviews.RowHeadersWidth = 51;
            dataGridView_BookReviews.Size = new Size(1059, 543);
            dataGridView_BookReviews.TabIndex = 4;
            dataGridView_BookReviews.CellContentClick += dataGridView_BookReviews_CellContentClick;
            // 
            // cartesianChartMostBorrowedBooks
            // 
            cartesianChartMostBorrowedBooks.BackColor = Color.White;
            cartesianChartMostBorrowedBooks.Dock = DockStyle.Fill;
            cartesianChartMostBorrowedBooks.Location = new Point(0, 0);
            cartesianChartMostBorrowedBooks.MatchAxesScreenDataRatio = false;
            cartesianChartMostBorrowedBooks.Name = "cartesianChartMostBorrowedBooks";
            cartesianChartMostBorrowedBooks.Size = new Size(1059, 543);
            cartesianChartMostBorrowedBooks.TabIndex = 3;
            // 
            // Analytics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Analytics";
            Size = new Size(1098, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_BookReviews).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChartBookRating;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChartMostBorrowedBooks;
        private Panel panel2;
        private SiticoneNetCoreUI.SiticoneButton btnViewMostBorrowed;
        private SiticoneNetCoreUI.SiticoneButton btnBookRatings;
        private DataGridView dataGridView_BookReviews;
        private SiticoneNetCoreUI.SiticoneButton btnViewBookReviews;
        private Label label2;
        private ComboBox comboBoxBookSearch;
    }
}
