namespace Lib1
{
    partial class BorrowedBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowedBooks));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxEndYearSearch = new TextBox();
            textBoxStartYearSearch = new TextBox();
            comboBoxStudentNameSearch = new ComboBox();
            btnRefresh = new SiticoneNetCoreUI.SiticoneButton();
            textBoxBorrowedBookSearch = new TextBox();
            siticoneLabel1 = new SiticoneNetCoreUI.SiticoneLabel();
            siticonePictureBox1 = new SiticoneNetCoreUI.SiticonePictureBox();
            dataGridView_BorrowedBooks = new DataGridView();
            btnViewOverdueBooks = new SiticoneNetCoreUI.SiticoneButton();
            btnViewAllBookTransactions = new SiticoneNetCoreUI.SiticoneButton();
            textBoxGenre = new TextBox();
            siticoneLabel15 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxISBN = new TextBox();
            siticoneLabel14 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxBorrowDate = new TextBox();
            siticoneLabel13 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxBookID = new TextBox();
            siticoneLabel11 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxFullName = new TextBox();
            labelFullName = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxUserID = new TextBox();
            labelUserID = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxProcessedBy = new TextBox();
            siticoneLabel5 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxAuthor = new TextBox();
            siticoneLabel4 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxBookTitle = new TextBox();
            siticoneLabel8 = new SiticoneNetCoreUI.SiticoneLabel();
            btnReturn = new SiticoneNetCoreUI.SiticoneButton();
            btnCancelBorrowRequest = new SiticoneNetCoreUI.SiticoneButton();
            textBoxStatus = new TextBox();
            siticoneLabel2 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxReturnDate = new TextBox();
            siticoneLabel3 = new SiticoneNetCoreUI.SiticoneLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_BorrowedBooks).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxEndYearSearch);
            panel1.Controls.Add(textBoxStartYearSearch);
            panel1.Controls.Add(comboBoxStudentNameSearch);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(textBoxBorrowedBookSearch);
            panel1.Controls.Add(siticoneLabel1);
            panel1.Controls.Add(siticonePictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 125);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(950, 96);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 18;
            label3.Text = "Year (End)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(820, 96);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 17;
            label2.Text = "Year (Start)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(689, 96);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 16;
            label1.Text = "Student Name";
            // 
            // textBoxEndYearSearch
            // 
            textBoxEndYearSearch.Location = new Point(950, 65);
            textBoxEndYearSearch.Multiline = true;
            textBoxEndYearSearch.Name = "textBoxEndYearSearch";
            textBoxEndYearSearch.Size = new Size(125, 27);
            textBoxEndYearSearch.TabIndex = 15;
            // 
            // textBoxStartYearSearch
            // 
            textBoxStartYearSearch.Location = new Point(820, 65);
            textBoxStartYearSearch.Multiline = true;
            textBoxStartYearSearch.Name = "textBoxStartYearSearch";
            textBoxStartYearSearch.Size = new Size(125, 27);
            textBoxStartYearSearch.TabIndex = 14;
            // 
            // comboBoxStudentNameSearch
            // 
            comboBoxStudentNameSearch.FormattingEnabled = true;
            comboBoxStudentNameSearch.Location = new Point(689, 65);
            comboBoxStudentNameSearch.Name = "comboBoxStudentNameSearch";
            comboBoxStudentNameSearch.Size = new Size(125, 28);
            comboBoxStudentNameSearch.TabIndex = 13;
            comboBoxStudentNameSearch.SelectedIndexChanged += comboBoxStudentNameSearch_SelectedIndexChanged;
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
            btnRefresh.Location = new Point(950, 30);
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
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
            btnRefresh.TextColor = Color.White;
            btnRefresh.TooltipText = null;
            btnRefresh.UseAdvancedRendering = true;
            btnRefresh.UseParticles = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // textBoxBorrowedBookSearch
            // 
            textBoxBorrowedBookSearch.Location = new Point(689, 30);
            textBoxBorrowedBookSearch.Multiline = true;
            textBoxBorrowedBookSearch.Name = "textBoxBorrowedBookSearch";
            textBoxBorrowedBookSearch.Size = new Size(251, 29);
            textBoxBorrowedBookSearch.TabIndex = 11;
            // 
            // siticoneLabel1
            // 
            siticoneLabel1.BackColor = Color.Transparent;
            siticoneLabel1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabel1.Location = new Point(171, 43);
            siticoneLabel1.Name = "siticoneLabel1";
            siticoneLabel1.Size = new Size(350, 46);
            siticoneLabel1.TabIndex = 5;
            siticoneLabel1.Text = "Borrowed Books";
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
            siticonePictureBox1.Location = new Point(3, 3);
            siticonePictureBox1.MaintainAspectRatio = true;
            siticonePictureBox1.Name = "siticonePictureBox1";
            siticonePictureBox1.PlaceholderImage = null;
            siticonePictureBox1.RotationAngle = 0F;
            siticonePictureBox1.Saturation = 1F;
            siticonePictureBox1.ShowBorder = false;
            siticonePictureBox1.Size = new Size(148, 119);
            siticonePictureBox1.SizeMode = SiticoneNetCoreUI.SiticonePictureBoxSizeMode.StretchImage;
            siticonePictureBox1.TabIndex = 4;
            siticonePictureBox1.Text = "siticonePictureBox1";
            // 
            // dataGridView_BorrowedBooks
            // 
            dataGridView_BorrowedBooks.BackgroundColor = Color.BurlyWood;
            dataGridView_BorrowedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_BorrowedBooks.Location = new Point(17, 146);
            dataGridView_BorrowedBooks.Name = "dataGridView_BorrowedBooks";
            dataGridView_BorrowedBooks.ReadOnly = true;
            dataGridView_BorrowedBooks.RowHeadersWidth = 51;
            dataGridView_BorrowedBooks.Size = new Size(1065, 252);
            dataGridView_BorrowedBooks.TabIndex = 3;
            dataGridView_BorrowedBooks.CellContentClick += dataGridView_BorrowedBooks_CellContentClick;
            // 
            // btnViewOverdueBooks
            // 
            btnViewOverdueBooks.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnViewOverdueBooks.AccessibleName = "View Overdue Books";
            btnViewOverdueBooks.AutoSizeBasedOnText = false;
            btnViewOverdueBooks.BackColor = Color.Transparent;
            btnViewOverdueBooks.BadgeBackColor = Color.Red;
            btnViewOverdueBooks.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnViewOverdueBooks.BadgeValue = 0;
            btnViewOverdueBooks.BadgeValueForeColor = Color.White;
            btnViewOverdueBooks.BorderColor = Color.Transparent;
            btnViewOverdueBooks.BorderWidth = 2;
            btnViewOverdueBooks.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnViewOverdueBooks.ButtonImage = null;
            btnViewOverdueBooks.CanBeep = true;
            btnViewOverdueBooks.CanGlow = false;
            btnViewOverdueBooks.CanShake = true;
            btnViewOverdueBooks.ContextMenuStripEx = null;
            btnViewOverdueBooks.CornerRadiusBottomLeft = 8;
            btnViewOverdueBooks.CornerRadiusBottomRight = 8;
            btnViewOverdueBooks.CornerRadiusTopLeft = 8;
            btnViewOverdueBooks.CornerRadiusTopRight = 8;
            btnViewOverdueBooks.CustomCursor = Cursors.Default;
            btnViewOverdueBooks.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnViewOverdueBooks.EnableLongPress = false;
            btnViewOverdueBooks.EnablePressAnimation = true;
            btnViewOverdueBooks.EnableRippleEffect = true;
            btnViewOverdueBooks.EnableShadow = false;
            btnViewOverdueBooks.EnableTextWrapping = false;
            btnViewOverdueBooks.Font = new Font("Segoe UI", 9F);
            btnViewOverdueBooks.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnViewOverdueBooks.GlowIntensity = 100;
            btnViewOverdueBooks.GlowRadius = 20F;
            btnViewOverdueBooks.GradientBackground = false;
            btnViewOverdueBooks.GradientColor = Color.FromArgb(114, 168, 255);
            btnViewOverdueBooks.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnViewOverdueBooks.HintText = null;
            btnViewOverdueBooks.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnViewOverdueBooks.HoverFontStyle = FontStyle.Regular;
            btnViewOverdueBooks.HoverTextColor = Color.White;
            btnViewOverdueBooks.HoverTransitionDuration = 250;
            btnViewOverdueBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewOverdueBooks.ImagePadding = 5;
            btnViewOverdueBooks.ImageSize = new Size(16, 16);
            btnViewOverdueBooks.IsRadial = false;
            btnViewOverdueBooks.IsReadOnly = false;
            btnViewOverdueBooks.IsToggleButton = false;
            btnViewOverdueBooks.IsToggled = false;
            btnViewOverdueBooks.Location = new Point(820, 648);
            btnViewOverdueBooks.LongPressDurationMS = 1000;
            btnViewOverdueBooks.Name = "btnViewOverdueBooks";
            btnViewOverdueBooks.NormalFontStyle = FontStyle.Regular;
            btnViewOverdueBooks.ParticleColor = Color.FromArgb(200, 200, 200);
            btnViewOverdueBooks.ParticleCount = 15;
            btnViewOverdueBooks.PressAnimationScale = 0.97F;
            btnViewOverdueBooks.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnViewOverdueBooks.PressedFontStyle = FontStyle.Regular;
            btnViewOverdueBooks.PressTransitionDuration = 150;
            btnViewOverdueBooks.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnViewOverdueBooks.RippleColor = Color.FromArgb(255, 255, 255);
            btnViewOverdueBooks.RippleOpacity = 0.3F;
            btnViewOverdueBooks.RippleRadiusMultiplier = 0.6F;
            btnViewOverdueBooks.ShadowBlur = 5;
            btnViewOverdueBooks.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnViewOverdueBooks.ShadowOffset = new Point(2, 2);
            btnViewOverdueBooks.ShakeDuration = 500;
            btnViewOverdueBooks.ShakeIntensity = 5;
            btnViewOverdueBooks.Size = new Size(248, 39);
            btnViewOverdueBooks.TabIndex = 81;
            btnViewOverdueBooks.Text = "View Overdue Books";
            btnViewOverdueBooks.TextAlign = ContentAlignment.MiddleCenter;
            btnViewOverdueBooks.TextColor = Color.White;
            btnViewOverdueBooks.TooltipText = null;
            btnViewOverdueBooks.UseAdvancedRendering = true;
            btnViewOverdueBooks.UseParticles = false;
            btnViewOverdueBooks.Click += btnViewOverdueBooks_Click;
            // 
            // btnViewAllBookTransactions
            // 
            btnViewAllBookTransactions.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnViewAllBookTransactions.AccessibleName = "View All Book Transactions";
            btnViewAllBookTransactions.AutoSizeBasedOnText = false;
            btnViewAllBookTransactions.BackColor = Color.Transparent;
            btnViewAllBookTransactions.BadgeBackColor = Color.Red;
            btnViewAllBookTransactions.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnViewAllBookTransactions.BadgeValue = 0;
            btnViewAllBookTransactions.BadgeValueForeColor = Color.White;
            btnViewAllBookTransactions.BorderColor = Color.Transparent;
            btnViewAllBookTransactions.BorderWidth = 2;
            btnViewAllBookTransactions.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnViewAllBookTransactions.ButtonImage = null;
            btnViewAllBookTransactions.CanBeep = true;
            btnViewAllBookTransactions.CanGlow = false;
            btnViewAllBookTransactions.CanShake = true;
            btnViewAllBookTransactions.ContextMenuStripEx = null;
            btnViewAllBookTransactions.CornerRadiusBottomLeft = 8;
            btnViewAllBookTransactions.CornerRadiusBottomRight = 8;
            btnViewAllBookTransactions.CornerRadiusTopLeft = 8;
            btnViewAllBookTransactions.CornerRadiusTopRight = 8;
            btnViewAllBookTransactions.CustomCursor = Cursors.Default;
            btnViewAllBookTransactions.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnViewAllBookTransactions.EnableLongPress = false;
            btnViewAllBookTransactions.EnablePressAnimation = true;
            btnViewAllBookTransactions.EnableRippleEffect = true;
            btnViewAllBookTransactions.EnableShadow = false;
            btnViewAllBookTransactions.EnableTextWrapping = false;
            btnViewAllBookTransactions.Font = new Font("Segoe UI", 9F);
            btnViewAllBookTransactions.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnViewAllBookTransactions.GlowIntensity = 100;
            btnViewAllBookTransactions.GlowRadius = 20F;
            btnViewAllBookTransactions.GradientBackground = false;
            btnViewAllBookTransactions.GradientColor = Color.FromArgb(114, 168, 255);
            btnViewAllBookTransactions.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnViewAllBookTransactions.HintText = null;
            btnViewAllBookTransactions.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnViewAllBookTransactions.HoverFontStyle = FontStyle.Regular;
            btnViewAllBookTransactions.HoverTextColor = Color.White;
            btnViewAllBookTransactions.HoverTransitionDuration = 250;
            btnViewAllBookTransactions.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewAllBookTransactions.ImagePadding = 5;
            btnViewAllBookTransactions.ImageSize = new Size(16, 16);
            btnViewAllBookTransactions.IsRadial = false;
            btnViewAllBookTransactions.IsReadOnly = false;
            btnViewAllBookTransactions.IsToggleButton = false;
            btnViewAllBookTransactions.IsToggled = false;
            btnViewAllBookTransactions.Location = new Point(500, 648);
            btnViewAllBookTransactions.LongPressDurationMS = 1000;
            btnViewAllBookTransactions.Name = "btnViewAllBookTransactions";
            btnViewAllBookTransactions.NormalFontStyle = FontStyle.Regular;
            btnViewAllBookTransactions.ParticleColor = Color.FromArgb(200, 200, 200);
            btnViewAllBookTransactions.ParticleCount = 15;
            btnViewAllBookTransactions.PressAnimationScale = 0.97F;
            btnViewAllBookTransactions.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnViewAllBookTransactions.PressedFontStyle = FontStyle.Regular;
            btnViewAllBookTransactions.PressTransitionDuration = 150;
            btnViewAllBookTransactions.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnViewAllBookTransactions.RippleColor = Color.FromArgb(255, 255, 255);
            btnViewAllBookTransactions.RippleOpacity = 0.3F;
            btnViewAllBookTransactions.RippleRadiusMultiplier = 0.6F;
            btnViewAllBookTransactions.ShadowBlur = 5;
            btnViewAllBookTransactions.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnViewAllBookTransactions.ShadowOffset = new Point(2, 2);
            btnViewAllBookTransactions.ShakeDuration = 500;
            btnViewAllBookTransactions.ShakeIntensity = 5;
            btnViewAllBookTransactions.Size = new Size(248, 39);
            btnViewAllBookTransactions.TabIndex = 80;
            btnViewAllBookTransactions.Text = "View All Book Transactions";
            btnViewAllBookTransactions.TextAlign = ContentAlignment.MiddleCenter;
            btnViewAllBookTransactions.TextColor = Color.White;
            btnViewAllBookTransactions.TooltipText = null;
            btnViewAllBookTransactions.UseAdvancedRendering = true;
            btnViewAllBookTransactions.UseParticles = false;
            btnViewAllBookTransactions.Click += btnViewAllBookTransactions_Click;
            // 
            // textBoxGenre
            // 
            textBoxGenre.Location = new Point(770, 549);
            textBoxGenre.Name = "textBoxGenre";
            textBoxGenre.Size = new Size(256, 27);
            textBoxGenre.TabIndex = 79;
            // 
            // siticoneLabel15
            // 
            siticoneLabel15.BackColor = Color.Transparent;
            siticoneLabel15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel15.Location = new Point(564, 550);
            siticoneLabel15.Name = "siticoneLabel15";
            siticoneLabel15.Size = new Size(142, 29);
            siticoneLabel15.TabIndex = 78;
            siticoneLabel15.Text = "Book Genre";
            // 
            // textBoxISBN
            // 
            textBoxISBN.Location = new Point(770, 503);
            textBoxISBN.Name = "textBoxISBN";
            textBoxISBN.Size = new Size(256, 27);
            textBoxISBN.TabIndex = 77;
            // 
            // siticoneLabel14
            // 
            siticoneLabel14.BackColor = Color.Transparent;
            siticoneLabel14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel14.Location = new Point(564, 504);
            siticoneLabel14.Name = "siticoneLabel14";
            siticoneLabel14.Size = new Size(142, 29);
            siticoneLabel14.TabIndex = 76;
            siticoneLabel14.Text = "Book ISBN";
            // 
            // textBoxBorrowDate
            // 
            textBoxBorrowDate.Location = new Point(217, 549);
            textBoxBorrowDate.Name = "textBoxBorrowDate";
            textBoxBorrowDate.Size = new Size(244, 27);
            textBoxBorrowDate.TabIndex = 75;
            // 
            // siticoneLabel13
            // 
            siticoneLabel13.BackColor = Color.Transparent;
            siticoneLabel13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel13.Location = new Point(19, 550);
            siticoneLabel13.Name = "siticoneLabel13";
            siticoneLabel13.Size = new Size(142, 29);
            siticoneLabel13.TabIndex = 74;
            siticoneLabel13.Text = "Borrow Date";
            // 
            // textBoxBookID
            // 
            textBoxBookID.Location = new Point(217, 457);
            textBoxBookID.Name = "textBoxBookID";
            textBoxBookID.Size = new Size(244, 27);
            textBoxBookID.TabIndex = 71;
            // 
            // siticoneLabel11
            // 
            siticoneLabel11.BackColor = Color.Transparent;
            siticoneLabel11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel11.Location = new Point(19, 457);
            siticoneLabel11.Name = "siticoneLabel11";
            siticoneLabel11.Size = new Size(125, 29);
            siticoneLabel11.TabIndex = 70;
            siticoneLabel11.Text = "Book ID";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(770, 413);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(256, 27);
            textBoxFullName.TabIndex = 69;
            // 
            // labelFullName
            // 
            labelFullName.BackColor = Color.Transparent;
            labelFullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFullName.Location = new Point(564, 414);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(101, 29);
            labelFullName.TabIndex = 68;
            labelFullName.Text = "Full Name";
            // 
            // textBoxUserID
            // 
            textBoxUserID.Location = new Point(217, 413);
            textBoxUserID.Name = "textBoxUserID";
            textBoxUserID.Size = new Size(244, 27);
            textBoxUserID.TabIndex = 67;
            // 
            // labelUserID
            // 
            labelUserID.BackColor = Color.Transparent;
            labelUserID.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelUserID.Location = new Point(19, 414);
            labelUserID.Name = "labelUserID";
            labelUserID.Size = new Size(78, 29);
            labelUserID.TabIndex = 66;
            labelUserID.Text = "UserID";
            // 
            // textBoxProcessedBy
            // 
            textBoxProcessedBy.Location = new Point(217, 636);
            textBoxProcessedBy.Name = "textBoxProcessedBy";
            textBoxProcessedBy.Size = new Size(244, 27);
            textBoxProcessedBy.TabIndex = 62;
            // 
            // siticoneLabel5
            // 
            siticoneLabel5.BackColor = Color.Transparent;
            siticoneLabel5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel5.Location = new Point(19, 637);
            siticoneLabel5.Name = "siticoneLabel5";
            siticoneLabel5.Size = new Size(186, 29);
            siticoneLabel5.TabIndex = 60;
            siticoneLabel5.Text = "Processed By";
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Location = new Point(217, 503);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(244, 27);
            textBoxAuthor.TabIndex = 59;
            // 
            // siticoneLabel4
            // 
            siticoneLabel4.BackColor = Color.Transparent;
            siticoneLabel4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel4.Location = new Point(19, 504);
            siticoneLabel4.Name = "siticoneLabel4";
            siticoneLabel4.Size = new Size(166, 29);
            siticoneLabel4.TabIndex = 58;
            siticoneLabel4.Text = "Book Author Name";
            // 
            // textBoxBookTitle
            // 
            textBoxBookTitle.Location = new Point(770, 457);
            textBoxBookTitle.Name = "textBoxBookTitle";
            textBoxBookTitle.Size = new Size(256, 27);
            textBoxBookTitle.TabIndex = 57;
            // 
            // siticoneLabel8
            // 
            siticoneLabel8.BackColor = Color.Transparent;
            siticoneLabel8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel8.Location = new Point(564, 458);
            siticoneLabel8.Name = "siticoneLabel8";
            siticoneLabel8.Size = new Size(125, 29);
            siticoneLabel8.TabIndex = 56;
            siticoneLabel8.Text = "Book Title";
            // 
            // btnReturn
            // 
            btnReturn.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnReturn.AccessibleName = "Return Book";
            btnReturn.AutoSizeBasedOnText = false;
            btnReturn.BackColor = Color.Transparent;
            btnReturn.BadgeBackColor = Color.Red;
            btnReturn.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnReturn.BadgeValue = 0;
            btnReturn.BadgeValueForeColor = Color.White;
            btnReturn.BorderColor = Color.Transparent;
            btnReturn.BorderWidth = 2;
            btnReturn.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnReturn.ButtonImage = null;
            btnReturn.CanBeep = true;
            btnReturn.CanGlow = false;
            btnReturn.CanShake = true;
            btnReturn.ContextMenuStripEx = null;
            btnReturn.CornerRadiusBottomLeft = 8;
            btnReturn.CornerRadiusBottomRight = 8;
            btnReturn.CornerRadiusTopLeft = 8;
            btnReturn.CornerRadiusTopRight = 8;
            btnReturn.CustomCursor = Cursors.Default;
            btnReturn.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnReturn.EnableLongPress = false;
            btnReturn.EnablePressAnimation = true;
            btnReturn.EnableRippleEffect = true;
            btnReturn.EnableShadow = false;
            btnReturn.EnableTextWrapping = false;
            btnReturn.Font = new Font("Segoe UI", 9F);
            btnReturn.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnReturn.GlowIntensity = 100;
            btnReturn.GlowRadius = 20F;
            btnReturn.GradientBackground = false;
            btnReturn.GradientColor = Color.FromArgb(114, 168, 255);
            btnReturn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnReturn.HintText = null;
            btnReturn.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnReturn.HoverFontStyle = FontStyle.Regular;
            btnReturn.HoverTextColor = Color.White;
            btnReturn.HoverTransitionDuration = 250;
            btnReturn.ImageAlign = ContentAlignment.MiddleLeft;
            btnReturn.ImagePadding = 5;
            btnReturn.ImageSize = new Size(16, 16);
            btnReturn.IsRadial = false;
            btnReturn.IsReadOnly = false;
            btnReturn.IsToggleButton = false;
            btnReturn.IsToggled = false;
            btnReturn.Location = new Point(500, 648);
            btnReturn.LongPressDurationMS = 1000;
            btnReturn.Name = "btnReturn";
            btnReturn.NormalFontStyle = FontStyle.Regular;
            btnReturn.ParticleColor = Color.FromArgb(200, 200, 200);
            btnReturn.ParticleCount = 15;
            btnReturn.PressAnimationScale = 0.97F;
            btnReturn.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnReturn.PressedFontStyle = FontStyle.Regular;
            btnReturn.PressTransitionDuration = 150;
            btnReturn.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnReturn.RippleColor = Color.FromArgb(255, 255, 255);
            btnReturn.RippleOpacity = 0.3F;
            btnReturn.RippleRadiusMultiplier = 0.6F;
            btnReturn.ShadowBlur = 5;
            btnReturn.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnReturn.ShadowOffset = new Point(2, 2);
            btnReturn.ShakeDuration = 500;
            btnReturn.ShakeIntensity = 5;
            btnReturn.Size = new Size(248, 39);
            btnReturn.TabIndex = 82;
            btnReturn.Text = "Return Book";
            btnReturn.TextAlign = ContentAlignment.MiddleCenter;
            btnReturn.TextColor = Color.White;
            btnReturn.TooltipText = null;
            btnReturn.UseAdvancedRendering = true;
            btnReturn.UseParticles = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnCancelBorrowRequest
            // 
            btnCancelBorrowRequest.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnCancelBorrowRequest.AccessibleName = "Cancel Borrow Request";
            btnCancelBorrowRequest.AutoSizeBasedOnText = false;
            btnCancelBorrowRequest.BackColor = Color.Transparent;
            btnCancelBorrowRequest.BadgeBackColor = Color.Red;
            btnCancelBorrowRequest.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnCancelBorrowRequest.BadgeValue = 0;
            btnCancelBorrowRequest.BadgeValueForeColor = Color.White;
            btnCancelBorrowRequest.BorderColor = Color.Transparent;
            btnCancelBorrowRequest.BorderWidth = 2;
            btnCancelBorrowRequest.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnCancelBorrowRequest.ButtonImage = null;
            btnCancelBorrowRequest.CanBeep = true;
            btnCancelBorrowRequest.CanGlow = false;
            btnCancelBorrowRequest.CanShake = true;
            btnCancelBorrowRequest.ContextMenuStripEx = null;
            btnCancelBorrowRequest.CornerRadiusBottomLeft = 8;
            btnCancelBorrowRequest.CornerRadiusBottomRight = 8;
            btnCancelBorrowRequest.CornerRadiusTopLeft = 8;
            btnCancelBorrowRequest.CornerRadiusTopRight = 8;
            btnCancelBorrowRequest.CustomCursor = Cursors.Default;
            btnCancelBorrowRequest.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnCancelBorrowRequest.EnableLongPress = false;
            btnCancelBorrowRequest.EnablePressAnimation = true;
            btnCancelBorrowRequest.EnableRippleEffect = true;
            btnCancelBorrowRequest.EnableShadow = false;
            btnCancelBorrowRequest.EnableTextWrapping = false;
            btnCancelBorrowRequest.Font = new Font("Segoe UI", 9F);
            btnCancelBorrowRequest.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnCancelBorrowRequest.GlowIntensity = 100;
            btnCancelBorrowRequest.GlowRadius = 20F;
            btnCancelBorrowRequest.GradientBackground = false;
            btnCancelBorrowRequest.GradientColor = Color.FromArgb(114, 168, 255);
            btnCancelBorrowRequest.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnCancelBorrowRequest.HintText = null;
            btnCancelBorrowRequest.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnCancelBorrowRequest.HoverFontStyle = FontStyle.Regular;
            btnCancelBorrowRequest.HoverTextColor = Color.White;
            btnCancelBorrowRequest.HoverTransitionDuration = 250;
            btnCancelBorrowRequest.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelBorrowRequest.ImagePadding = 5;
            btnCancelBorrowRequest.ImageSize = new Size(16, 16);
            btnCancelBorrowRequest.IsRadial = false;
            btnCancelBorrowRequest.IsReadOnly = false;
            btnCancelBorrowRequest.IsToggleButton = false;
            btnCancelBorrowRequest.IsToggled = false;
            btnCancelBorrowRequest.Location = new Point(820, 648);
            btnCancelBorrowRequest.LongPressDurationMS = 1000;
            btnCancelBorrowRequest.Name = "btnCancelBorrowRequest";
            btnCancelBorrowRequest.NormalFontStyle = FontStyle.Regular;
            btnCancelBorrowRequest.ParticleColor = Color.FromArgb(200, 200, 200);
            btnCancelBorrowRequest.ParticleCount = 15;
            btnCancelBorrowRequest.PressAnimationScale = 0.97F;
            btnCancelBorrowRequest.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnCancelBorrowRequest.PressedFontStyle = FontStyle.Regular;
            btnCancelBorrowRequest.PressTransitionDuration = 150;
            btnCancelBorrowRequest.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnCancelBorrowRequest.RippleColor = Color.FromArgb(255, 255, 255);
            btnCancelBorrowRequest.RippleOpacity = 0.3F;
            btnCancelBorrowRequest.RippleRadiusMultiplier = 0.6F;
            btnCancelBorrowRequest.ShadowBlur = 5;
            btnCancelBorrowRequest.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnCancelBorrowRequest.ShadowOffset = new Point(2, 2);
            btnCancelBorrowRequest.ShakeDuration = 500;
            btnCancelBorrowRequest.ShakeIntensity = 5;
            btnCancelBorrowRequest.Size = new Size(248, 39);
            btnCancelBorrowRequest.TabIndex = 83;
            btnCancelBorrowRequest.Text = "Cancel Borrow Request";
            btnCancelBorrowRequest.TextAlign = ContentAlignment.MiddleCenter;
            btnCancelBorrowRequest.TextColor = Color.White;
            btnCancelBorrowRequest.TooltipText = null;
            btnCancelBorrowRequest.UseAdvancedRendering = true;
            btnCancelBorrowRequest.UseParticles = false;
            btnCancelBorrowRequest.Click += btnCancelBorrowRequest_Click;
            // 
            // textBoxStatus
            // 
            textBoxStatus.Location = new Point(770, 593);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(256, 27);
            textBoxStatus.TabIndex = 85;
            // 
            // siticoneLabel2
            // 
            siticoneLabel2.BackColor = Color.Transparent;
            siticoneLabel2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel2.Location = new Point(564, 594);
            siticoneLabel2.Name = "siticoneLabel2";
            siticoneLabel2.Size = new Size(142, 29);
            siticoneLabel2.TabIndex = 84;
            siticoneLabel2.Text = "Status";
            // 
            // textBoxReturnDate
            // 
            textBoxReturnDate.Location = new Point(217, 593);
            textBoxReturnDate.Name = "textBoxReturnDate";
            textBoxReturnDate.Size = new Size(244, 27);
            textBoxReturnDate.TabIndex = 87;
            // 
            // siticoneLabel3
            // 
            siticoneLabel3.BackColor = Color.Transparent;
            siticoneLabel3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel3.Location = new Point(19, 594);
            siticoneLabel3.Name = "siticoneLabel3";
            siticoneLabel3.Size = new Size(142, 29);
            siticoneLabel3.TabIndex = 86;
            siticoneLabel3.Text = "Return Date";
            // 
            // BorrowedBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(textBoxReturnDate);
            Controls.Add(siticoneLabel3);
            Controls.Add(textBoxStatus);
            Controls.Add(siticoneLabel2);
            Controls.Add(btnCancelBorrowRequest);
            Controls.Add(btnReturn);
            Controls.Add(btnViewOverdueBooks);
            Controls.Add(btnViewAllBookTransactions);
            Controls.Add(textBoxGenre);
            Controls.Add(siticoneLabel15);
            Controls.Add(textBoxISBN);
            Controls.Add(siticoneLabel14);
            Controls.Add(textBoxBorrowDate);
            Controls.Add(siticoneLabel13);
            Controls.Add(textBoxBookID);
            Controls.Add(siticoneLabel11);
            Controls.Add(textBoxFullName);
            Controls.Add(labelFullName);
            Controls.Add(textBoxUserID);
            Controls.Add(labelUserID);
            Controls.Add(textBoxProcessedBy);
            Controls.Add(siticoneLabel5);
            Controls.Add(textBoxAuthor);
            Controls.Add(siticoneLabel4);
            Controls.Add(textBoxBookTitle);
            Controls.Add(siticoneLabel8);
            Controls.Add(dataGridView_BorrowedBooks);
            Controls.Add(panel1);
            Name = "BorrowedBooks";
            Size = new Size(1098, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_BorrowedBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticonePictureBox siticonePictureBox1;
        private DataGridView dataGridView_BorrowedBooks;
        private SiticoneNetCoreUI.SiticoneButton btnViewOverdueBooks;
        private SiticoneNetCoreUI.SiticoneButton btnViewAllBookTransactions;
        private TextBox textBoxGenre;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel15;
        private TextBox textBoxISBN;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel14;
        private TextBox textBoxBorrowDate;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel13;
        private TextBox textBoxBookID;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel11;
        private TextBox textBoxFullName;
        private SiticoneNetCoreUI.SiticoneLabel labelFullName;
        private TextBox textBoxUserID;
        private SiticoneNetCoreUI.SiticoneLabel labelUserID;
        private TextBox textBoxProcessedBy;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel5;
        private TextBox textBoxAuthor;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel4;
        private TextBox textBoxBookTitle;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel8;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxEndYearSearch;
        private TextBox textBoxStartYearSearch;
        private ComboBox comboBoxStudentNameSearch;
        private SiticoneNetCoreUI.SiticoneButton btnRefresh;
        private TextBox textBoxBorrowedBookSearch;
        private SiticoneNetCoreUI.SiticoneButton btnReturn;
        private SiticoneNetCoreUI.SiticoneButton btnCancelBorrowRequest;
        private TextBox textBoxStatus;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel2;
        private TextBox textBoxReturnDate;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel3;
    }
}
