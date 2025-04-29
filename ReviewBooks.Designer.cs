namespace Lib1
{
    partial class ReviewBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewBooks));
            panel1 = new Panel();
            label2 = new Label();
            comboBoxBookTitleSearch = new ComboBox();
            btnRefresh = new SiticoneNetCoreUI.SiticoneButton();
            textBoxBookSearch = new TextBox();
            siticoneLabel1 = new SiticoneNetCoreUI.SiticoneLabel();
            siticonePictureBox1 = new SiticoneNetCoreUI.SiticonePictureBox();
            dataGridViewReviewBooks = new DataGridView();
            textBoxRateBook = new TextBox();
            siticoneLabel2 = new SiticoneNetCoreUI.SiticoneLabel();
            btnRate = new SiticoneNetCoreUI.SiticoneButton();
            textBoxBookID = new TextBox();
            siticoneLabel3 = new SiticoneNetCoreUI.SiticoneLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviewBooks).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBoxBookTitleSearch);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(textBoxBookSearch);
            panel1.Controls.Add(siticoneLabel1);
            panel1.Controls.Add(siticonePictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 125);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(867, 90);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 30;
            label2.Text = "Book Title";
            // 
            // comboBoxBookTitleSearch
            // 
            comboBoxBookTitleSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBookTitleSearch.FormattingEnabled = true;
            comboBoxBookTitleSearch.Location = new Point(818, 59);
            comboBoxBookTitleSearch.Name = "comboBoxBookTitleSearch";
            comboBoxBookTitleSearch.Size = new Size(125, 28);
            comboBoxBookTitleSearch.TabIndex = 29;
            comboBoxBookTitleSearch.SelectedIndexChanged += comboBoxBookTitleSearch_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnRefresh.AccessibleName = "Refresh";
            btnRefresh.AutoSizeBasedOnText = false;
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.BadgeBackColor = Color.Red;
            btnRefresh.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnRefresh.BadgeValue = 0;
            btnRefresh.BadgeValueForeColor = Color.White;
            btnRefresh.BorderColor = Color.Transparent;
            btnRefresh.BorderWidth = 2;
            btnRefresh.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnRefresh.ButtonImage = null;
            btnRefresh.CanBeep = true;
            btnRefresh.CanGlow = false;
            btnRefresh.CanShake = true;
            btnRefresh.ContextMenuStripEx = null;
            btnRefresh.CornerRadiusBottomLeft = 8;
            btnRefresh.CornerRadiusBottomRight = 8;
            btnRefresh.CornerRadiusTopLeft = 8;
            btnRefresh.CornerRadiusTopRight = 8;
            btnRefresh.CustomCursor = Cursors.Default;
            btnRefresh.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnRefresh.EnableLongPress = false;
            btnRefresh.EnablePressAnimation = true;
            btnRefresh.EnableRippleEffect = true;
            btnRefresh.EnableShadow = false;
            btnRefresh.EnableTextWrapping = false;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnRefresh.GlowIntensity = 100;
            btnRefresh.GlowRadius = 20F;
            btnRefresh.GradientBackground = false;
            btnRefresh.GradientColor = Color.FromArgb(114, 168, 255);
            btnRefresh.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnRefresh.HintText = null;
            btnRefresh.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnRefresh.HoverFontStyle = FontStyle.Regular;
            btnRefresh.HoverTextColor = Color.White;
            btnRefresh.HoverTransitionDuration = 250;
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.ImagePadding = 5;
            btnRefresh.ImageSize = new Size(16, 16);
            btnRefresh.IsRadial = false;
            btnRefresh.IsReadOnly = false;
            btnRefresh.IsToggleButton = false;
            btnRefresh.IsToggled = false;
            btnRefresh.Location = new Point(954, 24);
            btnRefresh.LongPressDurationMS = 1000;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.NormalFontStyle = FontStyle.Regular;
            btnRefresh.ParticleColor = Color.FromArgb(200, 200, 200);
            btnRefresh.ParticleCount = 15;
            btnRefresh.PressAnimationScale = 0.97F;
            btnRefresh.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnRefresh.PressedFontStyle = FontStyle.Regular;
            btnRefresh.PressTransitionDuration = 150;
            btnRefresh.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnRefresh.RippleColor = Color.FromArgb(255, 255, 255);
            btnRefresh.RippleOpacity = 0.3F;
            btnRefresh.RippleRadiusMultiplier = 0.6F;
            btnRefresh.ShadowBlur = 5;
            btnRefresh.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnRefresh.ShadowOffset = new Point(2, 2);
            btnRefresh.ShakeDuration = 500;
            btnRefresh.ShakeIntensity = 5;
            btnRefresh.Size = new Size(126, 29);
            btnRefresh.TabIndex = 26;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
            btnRefresh.TextColor = Color.White;
            btnRefresh.TooltipText = null;
            btnRefresh.UseAdvancedRendering = true;
            btnRefresh.UseParticles = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // textBoxBookSearch
            // 
            textBoxBookSearch.Location = new Point(687, 24);
            textBoxBookSearch.Multiline = true;
            textBoxBookSearch.Name = "textBoxBookSearch";
            textBoxBookSearch.Size = new Size(256, 29);
            textBoxBookSearch.TabIndex = 25;
            textBoxBookSearch.TextChanged += textBoxBookSearch_TextChanged;
            // 
            // siticoneLabel1
            // 
            siticoneLabel1.BackColor = Color.Transparent;
            siticoneLabel1.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabel1.Location = new Point(161, 37);
            siticoneLabel1.Name = "siticoneLabel1";
            siticoneLabel1.Size = new Size(402, 37);
            siticoneLabel1.TabIndex = 3;
            siticoneLabel1.Text = "Review The Books You Borrowed";
            // 
            // siticonePictureBox1
            // 
            siticonePictureBox1.BackColor = Color.Transparent;
            siticonePictureBox1.BorderColor = Color.Transparent;
            siticonePictureBox1.BorderWidth = 1;
            siticonePictureBox1.Brightness = 1F;
            siticonePictureBox1.Contrast = 1F;
            siticonePictureBox1.CornerRadius = 0;
            siticonePictureBox1.DraggingSpeed = 3.15F;
            siticonePictureBox1.EnableAsyncLoading = false;
            siticonePictureBox1.EnableCaching = false;
            siticonePictureBox1.EnableDragDrop = false;
            siticonePictureBox1.EnableExtendedImageSources = false;
            siticonePictureBox1.EnableFilters = false;
            siticonePictureBox1.EnableFlipping = false;
            siticonePictureBox1.EnableGlow = false;
            siticonePictureBox1.EnableHighDpiSupport = false;
            siticonePictureBox1.EnableMouseInteraction = false;
            siticonePictureBox1.EnablePlaceholder = false;
            siticonePictureBox1.EnableRotation = false;
            siticonePictureBox1.EnableShadow = false;
            siticonePictureBox1.EnableSlideshow = false;
            siticonePictureBox1.FlipHorizontal = false;
            siticonePictureBox1.FlipVertical = false;
            siticonePictureBox1.Grayscale = false;
            siticonePictureBox1.Image = (Image)resources.GetObject("siticonePictureBox1.Image");
            siticonePictureBox1.ImageOpacity = 1F;
            siticonePictureBox1.Images = (List<Image>)resources.GetObject("siticonePictureBox1.Images");
            siticonePictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            siticonePictureBox1.IsCircular = false;
            siticonePictureBox1.Location = new Point(3, 4);
            siticonePictureBox1.MaintainAspectRatio = true;
            siticonePictureBox1.Name = "siticonePictureBox1";
            siticonePictureBox1.PlaceholderImage = null;
            siticonePictureBox1.RotationAngle = 0F;
            siticonePictureBox1.Saturation = 1F;
            siticonePictureBox1.ShowBorder = false;
            siticonePictureBox1.Size = new Size(152, 118);
            siticonePictureBox1.SizeMode = SiticoneNetCoreUI.SiticonePictureBoxSizeMode.StretchImage;
            siticonePictureBox1.TabIndex = 2;
            siticonePictureBox1.Text = "siticonePictureBox1";
            // 
            // dataGridViewReviewBooks
            // 
            dataGridViewReviewBooks.BackgroundColor = Color.White;
            dataGridViewReviewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReviewBooks.Location = new Point(16, 154);
            dataGridViewReviewBooks.Name = "dataGridViewReviewBooks";
            dataGridViewReviewBooks.ReadOnly = true;
            dataGridViewReviewBooks.RowHeadersWidth = 51;
            dataGridViewReviewBooks.Size = new Size(1064, 442);
            dataGridViewReviewBooks.TabIndex = 5;
            dataGridViewReviewBooks.CellContentClick += dataGridViewReviewBooks_CellContentClick;
            // 
            // textBoxRateBook
            // 
            textBoxRateBook.Font = new Font("Calibri", 13.8F);
            textBoxRateBook.Location = new Point(785, 630);
            textBoxRateBook.Multiline = true;
            textBoxRateBook.Name = "textBoxRateBook";
            textBoxRateBook.Size = new Size(163, 42);
            textBoxRateBook.TabIndex = 6;
            textBoxRateBook.TextChanged += textBoxRateBook_TextChanged;
            // 
            // siticoneLabel2
            // 
            siticoneLabel2.BackColor = Color.Transparent;
            siticoneLabel2.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            siticoneLabel2.Location = new Point(785, 675);
            siticoneLabel2.Name = "siticoneLabel2";
            siticoneLabel2.Size = new Size(181, 29);
            siticoneLabel2.TabIndex = 7;
            siticoneLabel2.Text = "Rate the book (1-10)";
            // 
            // btnRate
            // 
            btnRate.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnRate.AccessibleName = "Rate Book";
            btnRate.AutoSizeBasedOnText = false;
            btnRate.BackColor = Color.Transparent;
            btnRate.BadgeBackColor = Color.Red;
            btnRate.BadgeFont = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRate.BadgeValue = 0;
            btnRate.BadgeValueForeColor = Color.White;
            btnRate.BorderColor = Color.Transparent;
            btnRate.BorderWidth = 2;
            btnRate.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnRate.ButtonImage = null;
            btnRate.CanBeep = true;
            btnRate.CanGlow = false;
            btnRate.CanShake = true;
            btnRate.ContextMenuStripEx = null;
            btnRate.CornerRadiusBottomLeft = 8;
            btnRate.CornerRadiusBottomRight = 8;
            btnRate.CornerRadiusTopLeft = 8;
            btnRate.CornerRadiusTopRight = 8;
            btnRate.CustomCursor = Cursors.Default;
            btnRate.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnRate.EnableLongPress = false;
            btnRate.EnablePressAnimation = true;
            btnRate.EnableRippleEffect = true;
            btnRate.EnableShadow = false;
            btnRate.EnableTextWrapping = false;
            btnRate.Font = new Font("Segoe UI", 9F);
            btnRate.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnRate.GlowIntensity = 100;
            btnRate.GlowRadius = 20F;
            btnRate.GradientBackground = false;
            btnRate.GradientColor = Color.FromArgb(114, 168, 255);
            btnRate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnRate.HintText = null;
            btnRate.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnRate.HoverFontStyle = FontStyle.Regular;
            btnRate.HoverTextColor = Color.White;
            btnRate.HoverTransitionDuration = 250;
            btnRate.ImageAlign = ContentAlignment.MiddleLeft;
            btnRate.ImagePadding = 5;
            btnRate.ImageSize = new Size(16, 16);
            btnRate.IsRadial = false;
            btnRate.IsReadOnly = false;
            btnRate.IsToggleButton = false;
            btnRate.IsToggled = false;
            btnRate.Location = new Point(954, 630);
            btnRate.LongPressDurationMS = 1000;
            btnRate.Name = "btnRate";
            btnRate.NormalFontStyle = FontStyle.Regular;
            btnRate.ParticleColor = Color.FromArgb(200, 200, 200);
            btnRate.ParticleCount = 15;
            btnRate.PressAnimationScale = 0.97F;
            btnRate.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnRate.PressedFontStyle = FontStyle.Regular;
            btnRate.PressTransitionDuration = 150;
            btnRate.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnRate.RippleColor = Color.FromArgb(255, 255, 255);
            btnRate.RippleOpacity = 0.3F;
            btnRate.RippleRadiusMultiplier = 0.6F;
            btnRate.ShadowBlur = 5;
            btnRate.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnRate.ShadowOffset = new Point(2, 2);
            btnRate.ShakeDuration = 500;
            btnRate.ShakeIntensity = 5;
            btnRate.Size = new Size(120, 42);
            btnRate.TabIndex = 13;
            btnRate.Text = "Rate Book";
            btnRate.TextAlign = ContentAlignment.MiddleCenter;
            btnRate.TextColor = Color.White;
            btnRate.TooltipText = null;
            btnRate.UseAdvancedRendering = true;
            btnRate.UseParticles = false;
            btnRate.Click += btnRate_Click;
            // 
            // textBoxBookID
            // 
            textBoxBookID.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBookID.Location = new Point(113, 630);
            textBoxBookID.Multiline = true;
            textBoxBookID.Name = "textBoxBookID";
            textBoxBookID.Size = new Size(163, 42);
            textBoxBookID.TabIndex = 14;
            textBoxBookID.TextChanged += textBoxBookID_TextChanged;
            // 
            // siticoneLabel3
            // 
            siticoneLabel3.BackColor = Color.Transparent;
            siticoneLabel3.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            siticoneLabel3.Location = new Point(16, 633);
            siticoneLabel3.Name = "siticoneLabel3";
            siticoneLabel3.Size = new Size(91, 33);
            siticoneLabel3.TabIndex = 15;
            siticoneLabel3.Text = "Book ID";
            // 
            // ReviewBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(siticoneLabel3);
            Controls.Add(textBoxBookID);
            Controls.Add(btnRate);
            Controls.Add(siticoneLabel2);
            Controls.Add(textBoxRateBook);
            Controls.Add(dataGridViewReviewBooks);
            Controls.Add(panel1);
            Name = "ReviewBooks";
            Size = new Size(1098, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviewBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticonePictureBox siticonePictureBox1;
        private DataGridView dataGridViewReviewBooks;
        private Label label2;
        private ComboBox comboBoxBookTitleSearch;
        private SiticoneNetCoreUI.SiticoneButton btnRefresh;
        private TextBox textBoxBookSearch;
        private TextBox textBoxRateBook;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel2;
        private SiticoneNetCoreUI.SiticoneButton btnRate;
        private TextBox textBoxBookID;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel3;
    }
}
