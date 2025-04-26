namespace Lib1
{
    partial class Reservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservation));
            panel1 = new Panel();
            label1 = new Label();
            comboBoxStudentNameSearch = new ComboBox();
            btnRefresh = new SiticoneNetCoreUI.SiticoneButton();
            textBoxBorrowedBookSearch = new TextBox();
            siticoneLabel1 = new SiticoneNetCoreUI.SiticoneLabel();
            siticonePictureBox1 = new SiticoneNetCoreUI.SiticonePictureBox();
            dataGridView_BorrowedBooks = new DataGridView();
            textBoxReturnDate = new TextBox();
            siticoneLabel3 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxStatus = new TextBox();
            siticoneLabel2 = new SiticoneNetCoreUI.SiticoneLabel();
            btnDecline = new SiticoneNetCoreUI.SiticoneButton();
            btnAccept = new SiticoneNetCoreUI.SiticoneButton();
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
            btnViewReservationRequests = new SiticoneNetCoreUI.SiticoneButton();
            btnLendBook = new SiticoneNetCoreUI.SiticoneButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_BorrowedBooks).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(btnViewReservationRequests);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBoxStudentNameSearch);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(textBoxBorrowedBookSearch);
            panel1.Controls.Add(siticoneLabel1);
            panel1.Controls.Add(siticonePictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 125);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(689, 92);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 16;
            label1.Text = "Student Name";
            // 
            // comboBoxStudentNameSearch
            // 
            comboBoxStudentNameSearch.FormattingEnabled = true;
            comboBoxStudentNameSearch.Location = new Point(689, 65);
            comboBoxStudentNameSearch.Name = "comboBoxStudentNameSearch";
            comboBoxStudentNameSearch.Size = new Size(251, 28);
            comboBoxStudentNameSearch.TabIndex = 13;
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
            dataGridView_BorrowedBooks.TabIndex = 4;
            // 
            // textBoxReturnDate
            // 
            textBoxReturnDate.Location = new Point(225, 606);
            textBoxReturnDate.Name = "textBoxReturnDate";
            textBoxReturnDate.Size = new Size(244, 27);
            textBoxReturnDate.TabIndex = 113;
            // 
            // siticoneLabel3
            // 
            siticoneLabel3.BackColor = Color.Transparent;
            siticoneLabel3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel3.Location = new Point(27, 607);
            siticoneLabel3.Name = "siticoneLabel3";
            siticoneLabel3.Size = new Size(142, 29);
            siticoneLabel3.TabIndex = 112;
            siticoneLabel3.Text = "Return Date";
            // 
            // textBoxStatus
            // 
            textBoxStatus.Location = new Point(778, 606);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(256, 27);
            textBoxStatus.TabIndex = 111;
            // 
            // siticoneLabel2
            // 
            siticoneLabel2.BackColor = Color.Transparent;
            siticoneLabel2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel2.Location = new Point(572, 607);
            siticoneLabel2.Name = "siticoneLabel2";
            siticoneLabel2.Size = new Size(142, 29);
            siticoneLabel2.TabIndex = 110;
            siticoneLabel2.Text = "Status";
            // 
            // btnDecline
            // 
            btnDecline.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnDecline.AccessibleName = "Decline";
            btnDecline.AutoSizeBasedOnText = false;
            btnDecline.BackColor = Color.Transparent;
            btnDecline.BadgeBackColor = Color.Red;
            btnDecline.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDecline.BadgeValue = 0;
            btnDecline.BadgeValueForeColor = Color.White;
            btnDecline.BorderColor = Color.Transparent;
            btnDecline.BorderWidth = 2;
            btnDecline.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnDecline.ButtonImage = null;
            btnDecline.CanBeep = true;
            btnDecline.CanGlow = false;
            btnDecline.CanShake = true;
            btnDecline.ContextMenuStripEx = null;
            btnDecline.CornerRadiusBottomLeft = 8;
            btnDecline.CornerRadiusBottomRight = 8;
            btnDecline.CornerRadiusTopLeft = 8;
            btnDecline.CornerRadiusTopRight = 8;
            btnDecline.CustomCursor = Cursors.Default;
            btnDecline.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnDecline.EnableLongPress = false;
            btnDecline.EnablePressAnimation = true;
            btnDecline.EnableRippleEffect = true;
            btnDecline.EnableShadow = false;
            btnDecline.EnableTextWrapping = false;
            btnDecline.Font = new Font("Segoe UI", 9F);
            btnDecline.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnDecline.GlowIntensity = 100;
            btnDecline.GlowRadius = 20F;
            btnDecline.GradientBackground = false;
            btnDecline.GradientColor = Color.FromArgb(114, 168, 255);
            btnDecline.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnDecline.HintText = null;
            btnDecline.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnDecline.HoverFontStyle = FontStyle.Regular;
            btnDecline.HoverTextColor = Color.White;
            btnDecline.HoverTransitionDuration = 250;
            btnDecline.ImageAlign = ContentAlignment.MiddleLeft;
            btnDecline.ImagePadding = 5;
            btnDecline.ImageSize = new Size(16, 16);
            btnDecline.IsRadial = false;
            btnDecline.IsReadOnly = false;
            btnDecline.IsToggleButton = false;
            btnDecline.IsToggled = false;
            btnDecline.Location = new Point(828, 661);
            btnDecline.LongPressDurationMS = 1000;
            btnDecline.Name = "btnDecline";
            btnDecline.NormalFontStyle = FontStyle.Regular;
            btnDecline.ParticleColor = Color.FromArgb(200, 200, 200);
            btnDecline.ParticleCount = 15;
            btnDecline.PressAnimationScale = 0.97F;
            btnDecline.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnDecline.PressedFontStyle = FontStyle.Regular;
            btnDecline.PressTransitionDuration = 150;
            btnDecline.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnDecline.RippleColor = Color.FromArgb(255, 255, 255);
            btnDecline.RippleOpacity = 0.3F;
            btnDecline.RippleRadiusMultiplier = 0.6F;
            btnDecline.ShadowBlur = 5;
            btnDecline.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnDecline.ShadowOffset = new Point(2, 2);
            btnDecline.ShakeDuration = 500;
            btnDecline.ShakeIntensity = 5;
            btnDecline.Size = new Size(248, 39);
            btnDecline.TabIndex = 109;
            btnDecline.Text = "Decline";
            btnDecline.TextAlign = ContentAlignment.MiddleCenter;
            btnDecline.TextColor = Color.White;
            btnDecline.TooltipText = null;
            btnDecline.UseAdvancedRendering = true;
            btnDecline.UseParticles = false;
            // 
            // btnAccept
            // 
            btnAccept.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnAccept.AccessibleName = "Accept";
            btnAccept.AutoSizeBasedOnText = false;
            btnAccept.BackColor = Color.Transparent;
            btnAccept.BadgeBackColor = Color.Red;
            btnAccept.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAccept.BadgeValue = 0;
            btnAccept.BadgeValueForeColor = Color.White;
            btnAccept.BorderColor = Color.Transparent;
            btnAccept.BorderWidth = 2;
            btnAccept.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnAccept.ButtonImage = null;
            btnAccept.CanBeep = true;
            btnAccept.CanGlow = false;
            btnAccept.CanShake = true;
            btnAccept.ContextMenuStripEx = null;
            btnAccept.CornerRadiusBottomLeft = 8;
            btnAccept.CornerRadiusBottomRight = 8;
            btnAccept.CornerRadiusTopLeft = 8;
            btnAccept.CornerRadiusTopRight = 8;
            btnAccept.CustomCursor = Cursors.Default;
            btnAccept.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnAccept.EnableLongPress = false;
            btnAccept.EnablePressAnimation = true;
            btnAccept.EnableRippleEffect = true;
            btnAccept.EnableShadow = false;
            btnAccept.EnableTextWrapping = false;
            btnAccept.Font = new Font("Segoe UI", 9F);
            btnAccept.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnAccept.GlowIntensity = 100;
            btnAccept.GlowRadius = 20F;
            btnAccept.GradientBackground = false;
            btnAccept.GradientColor = Color.FromArgb(114, 168, 255);
            btnAccept.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnAccept.HintText = null;
            btnAccept.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnAccept.HoverFontStyle = FontStyle.Regular;
            btnAccept.HoverTextColor = Color.White;
            btnAccept.HoverTransitionDuration = 250;
            btnAccept.ImageAlign = ContentAlignment.MiddleLeft;
            btnAccept.ImagePadding = 5;
            btnAccept.ImageSize = new Size(16, 16);
            btnAccept.IsRadial = false;
            btnAccept.IsReadOnly = false;
            btnAccept.IsToggleButton = false;
            btnAccept.IsToggled = false;
            btnAccept.Location = new Point(545, 661);
            btnAccept.LongPressDurationMS = 1000;
            btnAccept.Name = "btnAccept";
            btnAccept.NormalFontStyle = FontStyle.Regular;
            btnAccept.ParticleColor = Color.FromArgb(200, 200, 200);
            btnAccept.ParticleCount = 15;
            btnAccept.PressAnimationScale = 0.97F;
            btnAccept.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnAccept.PressedFontStyle = FontStyle.Regular;
            btnAccept.PressTransitionDuration = 150;
            btnAccept.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnAccept.RippleColor = Color.FromArgb(255, 255, 255);
            btnAccept.RippleOpacity = 0.3F;
            btnAccept.RippleRadiusMultiplier = 0.6F;
            btnAccept.ShadowBlur = 5;
            btnAccept.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnAccept.ShadowOffset = new Point(2, 2);
            btnAccept.ShakeDuration = 500;
            btnAccept.ShakeIntensity = 5;
            btnAccept.Size = new Size(248, 39);
            btnAccept.TabIndex = 108;
            btnAccept.Text = "Accept";
            btnAccept.TextAlign = ContentAlignment.MiddleCenter;
            btnAccept.TextColor = Color.White;
            btnAccept.TooltipText = null;
            btnAccept.UseAdvancedRendering = true;
            btnAccept.UseParticles = false;
            // 
            // textBoxGenre
            // 
            textBoxGenre.Location = new Point(778, 562);
            textBoxGenre.Name = "textBoxGenre";
            textBoxGenre.Size = new Size(256, 27);
            textBoxGenre.TabIndex = 105;
            // 
            // siticoneLabel15
            // 
            siticoneLabel15.BackColor = Color.Transparent;
            siticoneLabel15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel15.Location = new Point(572, 563);
            siticoneLabel15.Name = "siticoneLabel15";
            siticoneLabel15.Size = new Size(142, 29);
            siticoneLabel15.TabIndex = 104;
            siticoneLabel15.Text = "Book Genre";
            // 
            // textBoxISBN
            // 
            textBoxISBN.Location = new Point(778, 516);
            textBoxISBN.Name = "textBoxISBN";
            textBoxISBN.Size = new Size(256, 27);
            textBoxISBN.TabIndex = 103;
            // 
            // siticoneLabel14
            // 
            siticoneLabel14.BackColor = Color.Transparent;
            siticoneLabel14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel14.Location = new Point(572, 517);
            siticoneLabel14.Name = "siticoneLabel14";
            siticoneLabel14.Size = new Size(142, 29);
            siticoneLabel14.TabIndex = 102;
            siticoneLabel14.Text = "Book ISBN";
            // 
            // textBoxBorrowDate
            // 
            textBoxBorrowDate.Location = new Point(225, 562);
            textBoxBorrowDate.Name = "textBoxBorrowDate";
            textBoxBorrowDate.Size = new Size(244, 27);
            textBoxBorrowDate.TabIndex = 101;
            // 
            // siticoneLabel13
            // 
            siticoneLabel13.BackColor = Color.Transparent;
            siticoneLabel13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel13.Location = new Point(27, 563);
            siticoneLabel13.Name = "siticoneLabel13";
            siticoneLabel13.Size = new Size(142, 29);
            siticoneLabel13.TabIndex = 100;
            siticoneLabel13.Text = "Borrow Date";
            // 
            // textBoxBookID
            // 
            textBoxBookID.Location = new Point(225, 470);
            textBoxBookID.Name = "textBoxBookID";
            textBoxBookID.Size = new Size(244, 27);
            textBoxBookID.TabIndex = 99;
            // 
            // siticoneLabel11
            // 
            siticoneLabel11.BackColor = Color.Transparent;
            siticoneLabel11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel11.Location = new Point(27, 470);
            siticoneLabel11.Name = "siticoneLabel11";
            siticoneLabel11.Size = new Size(125, 29);
            siticoneLabel11.TabIndex = 98;
            siticoneLabel11.Text = "Book ID";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(778, 426);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(256, 27);
            textBoxFullName.TabIndex = 97;
            // 
            // labelFullName
            // 
            labelFullName.BackColor = Color.Transparent;
            labelFullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFullName.Location = new Point(572, 427);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(101, 29);
            labelFullName.TabIndex = 96;
            labelFullName.Text = "Full Name";
            // 
            // textBoxUserID
            // 
            textBoxUserID.Location = new Point(225, 426);
            textBoxUserID.Name = "textBoxUserID";
            textBoxUserID.Size = new Size(244, 27);
            textBoxUserID.TabIndex = 95;
            // 
            // labelUserID
            // 
            labelUserID.BackColor = Color.Transparent;
            labelUserID.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelUserID.Location = new Point(27, 427);
            labelUserID.Name = "labelUserID";
            labelUserID.Size = new Size(78, 29);
            labelUserID.TabIndex = 94;
            labelUserID.Text = "UserID";
            // 
            // textBoxProcessedBy
            // 
            textBoxProcessedBy.Location = new Point(225, 649);
            textBoxProcessedBy.Name = "textBoxProcessedBy";
            textBoxProcessedBy.Size = new Size(244, 27);
            textBoxProcessedBy.TabIndex = 93;
            // 
            // siticoneLabel5
            // 
            siticoneLabel5.BackColor = Color.Transparent;
            siticoneLabel5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel5.Location = new Point(27, 650);
            siticoneLabel5.Name = "siticoneLabel5";
            siticoneLabel5.Size = new Size(186, 29);
            siticoneLabel5.TabIndex = 92;
            siticoneLabel5.Text = "Processed By";
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Location = new Point(225, 516);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(244, 27);
            textBoxAuthor.TabIndex = 91;
            // 
            // siticoneLabel4
            // 
            siticoneLabel4.BackColor = Color.Transparent;
            siticoneLabel4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel4.Location = new Point(27, 517);
            siticoneLabel4.Name = "siticoneLabel4";
            siticoneLabel4.Size = new Size(166, 29);
            siticoneLabel4.TabIndex = 90;
            siticoneLabel4.Text = "Book Author Name";
            // 
            // textBoxBookTitle
            // 
            textBoxBookTitle.Location = new Point(778, 470);
            textBoxBookTitle.Name = "textBoxBookTitle";
            textBoxBookTitle.Size = new Size(256, 27);
            textBoxBookTitle.TabIndex = 89;
            // 
            // siticoneLabel8
            // 
            siticoneLabel8.BackColor = Color.Transparent;
            siticoneLabel8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel8.Location = new Point(572, 471);
            siticoneLabel8.Name = "siticoneLabel8";
            siticoneLabel8.Size = new Size(125, 29);
            siticoneLabel8.TabIndex = 88;
            siticoneLabel8.Text = "Book Title";
            // 
            // btnViewReservationRequests
            // 
            btnViewReservationRequests.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnViewReservationRequests.AccessibleName = "View Requests";
            btnViewReservationRequests.AutoSizeBasedOnText = false;
            btnViewReservationRequests.BackColor = Color.Transparent;
            btnViewReservationRequests.BadgeBackColor = Color.Red;
            btnViewReservationRequests.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnViewReservationRequests.BadgeValue = 0;
            btnViewReservationRequests.BadgeValueForeColor = Color.White;
            btnViewReservationRequests.BorderColor = Color.Transparent;
            btnViewReservationRequests.BorderWidth = 2;
            btnViewReservationRequests.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnViewReservationRequests.ButtonImage = null;
            btnViewReservationRequests.CanBeep = true;
            btnViewReservationRequests.CanGlow = false;
            btnViewReservationRequests.CanShake = true;
            btnViewReservationRequests.ContextMenuStripEx = null;
            btnViewReservationRequests.CornerRadiusBottomLeft = 8;
            btnViewReservationRequests.CornerRadiusBottomRight = 8;
            btnViewReservationRequests.CornerRadiusTopLeft = 8;
            btnViewReservationRequests.CornerRadiusTopRight = 8;
            btnViewReservationRequests.CustomCursor = Cursors.Default;
            btnViewReservationRequests.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnViewReservationRequests.EnableLongPress = false;
            btnViewReservationRequests.EnablePressAnimation = true;
            btnViewReservationRequests.EnableRippleEffect = true;
            btnViewReservationRequests.EnableShadow = false;
            btnViewReservationRequests.EnableTextWrapping = false;
            btnViewReservationRequests.Font = new Font("Segoe UI", 9F);
            btnViewReservationRequests.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnViewReservationRequests.GlowIntensity = 100;
            btnViewReservationRequests.GlowRadius = 20F;
            btnViewReservationRequests.GradientBackground = false;
            btnViewReservationRequests.GradientColor = Color.FromArgb(114, 168, 255);
            btnViewReservationRequests.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnViewReservationRequests.HintText = null;
            btnViewReservationRequests.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnViewReservationRequests.HoverFontStyle = FontStyle.Regular;
            btnViewReservationRequests.HoverTextColor = Color.White;
            btnViewReservationRequests.HoverTransitionDuration = 250;
            btnViewReservationRequests.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewReservationRequests.ImagePadding = 5;
            btnViewReservationRequests.ImageSize = new Size(16, 16);
            btnViewReservationRequests.IsRadial = false;
            btnViewReservationRequests.IsReadOnly = false;
            btnViewReservationRequests.IsToggleButton = false;
            btnViewReservationRequests.IsToggled = false;
            btnViewReservationRequests.Location = new Point(937, 92);
            btnViewReservationRequests.LongPressDurationMS = 1000;
            btnViewReservationRequests.Name = "btnViewReservationRequests";
            btnViewReservationRequests.NormalFontStyle = FontStyle.Regular;
            btnViewReservationRequests.ParticleColor = Color.FromArgb(200, 200, 200);
            btnViewReservationRequests.ParticleCount = 15;
            btnViewReservationRequests.PressAnimationScale = 0.97F;
            btnViewReservationRequests.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnViewReservationRequests.PressedFontStyle = FontStyle.Regular;
            btnViewReservationRequests.PressTransitionDuration = 150;
            btnViewReservationRequests.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnViewReservationRequests.RippleColor = Color.FromArgb(255, 255, 255);
            btnViewReservationRequests.RippleOpacity = 0.3F;
            btnViewReservationRequests.RippleRadiusMultiplier = 0.6F;
            btnViewReservationRequests.ShadowBlur = 5;
            btnViewReservationRequests.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnViewReservationRequests.ShadowOffset = new Point(2, 2);
            btnViewReservationRequests.ShakeDuration = 500;
            btnViewReservationRequests.ShakeIntensity = 5;
            btnViewReservationRequests.Size = new Size(158, 29);
            btnViewReservationRequests.TabIndex = 17;
            btnViewReservationRequests.Text = "View Requests";
            btnViewReservationRequests.TextAlign = ContentAlignment.MiddleCenter;
            btnViewReservationRequests.TextColor = Color.White;
            btnViewReservationRequests.TooltipText = null;
            btnViewReservationRequests.UseAdvancedRendering = true;
            btnViewReservationRequests.UseParticles = false;
            // 
            // btnLendBook
            // 
            btnLendBook.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnLendBook.AccessibleName = "Lend Book";
            btnLendBook.AutoSizeBasedOnText = false;
            btnLendBook.BackColor = Color.Transparent;
            btnLendBook.BadgeBackColor = Color.Red;
            btnLendBook.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLendBook.BadgeValue = 0;
            btnLendBook.BadgeValueForeColor = Color.White;
            btnLendBook.BorderColor = Color.Transparent;
            btnLendBook.BorderWidth = 2;
            btnLendBook.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnLendBook.ButtonImage = null;
            btnLendBook.CanBeep = true;
            btnLendBook.CanGlow = false;
            btnLendBook.CanShake = true;
            btnLendBook.ContextMenuStripEx = null;
            btnLendBook.CornerRadiusBottomLeft = 8;
            btnLendBook.CornerRadiusBottomRight = 8;
            btnLendBook.CornerRadiusTopLeft = 8;
            btnLendBook.CornerRadiusTopRight = 8;
            btnLendBook.CustomCursor = Cursors.Default;
            btnLendBook.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnLendBook.EnableLongPress = false;
            btnLendBook.EnablePressAnimation = true;
            btnLendBook.EnableRippleEffect = true;
            btnLendBook.EnableShadow = false;
            btnLendBook.EnableTextWrapping = false;
            btnLendBook.Font = new Font("Segoe UI", 9F);
            btnLendBook.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnLendBook.GlowIntensity = 100;
            btnLendBook.GlowRadius = 20F;
            btnLendBook.GradientBackground = false;
            btnLendBook.GradientColor = Color.FromArgb(114, 168, 255);
            btnLendBook.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnLendBook.HintText = null;
            btnLendBook.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnLendBook.HoverFontStyle = FontStyle.Regular;
            btnLendBook.HoverTextColor = Color.White;
            btnLendBook.HoverTransitionDuration = 250;
            btnLendBook.ImageAlign = ContentAlignment.MiddleLeft;
            btnLendBook.ImagePadding = 5;
            btnLendBook.ImageSize = new Size(16, 16);
            btnLendBook.IsRadial = false;
            btnLendBook.IsReadOnly = false;
            btnLendBook.IsToggleButton = false;
            btnLendBook.IsToggled = false;
            btnLendBook.Location = new Point(828, 661);
            btnLendBook.LongPressDurationMS = 1000;
            btnLendBook.Name = "btnLendBook";
            btnLendBook.NormalFontStyle = FontStyle.Regular;
            btnLendBook.ParticleColor = Color.FromArgb(200, 200, 200);
            btnLendBook.ParticleCount = 15;
            btnLendBook.PressAnimationScale = 0.97F;
            btnLendBook.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnLendBook.PressedFontStyle = FontStyle.Regular;
            btnLendBook.PressTransitionDuration = 150;
            btnLendBook.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnLendBook.RippleColor = Color.FromArgb(255, 255, 255);
            btnLendBook.RippleOpacity = 0.3F;
            btnLendBook.RippleRadiusMultiplier = 0.6F;
            btnLendBook.ShadowBlur = 5;
            btnLendBook.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnLendBook.ShadowOffset = new Point(2, 2);
            btnLendBook.ShakeDuration = 500;
            btnLendBook.ShakeIntensity = 5;
            btnLendBook.Size = new Size(248, 39);
            btnLendBook.TabIndex = 114;
            btnLendBook.Text = "Lend Book";
            btnLendBook.TextAlign = ContentAlignment.MiddleCenter;
            btnLendBook.TextColor = Color.White;
            btnLendBook.TooltipText = null;
            btnLendBook.UseAdvancedRendering = true;
            btnLendBook.UseParticles = false;
            // 
            // Reservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(textBoxReturnDate);
            Controls.Add(siticoneLabel3);
            Controls.Add(textBoxStatus);
            Controls.Add(siticoneLabel2);
            Controls.Add(btnDecline);
            Controls.Add(btnAccept);
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
            Controls.Add(btnLendBook);
            Name = "Reservation";
            Size = new Size(1098, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_BorrowedBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox comboBoxStudentNameSearch;
        private SiticoneNetCoreUI.SiticoneButton btnRefresh;
        private TextBox textBoxBorrowedBookSearch;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticonePictureBox siticonePictureBox1;
        private DataGridView dataGridView_BorrowedBooks;
        private TextBox textBoxReturnDate;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel3;
        private TextBox textBoxStatus;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel2;
        private SiticoneNetCoreUI.SiticoneButton btnDecline;
        private SiticoneNetCoreUI.SiticoneButton btnAccept;
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
        private SiticoneNetCoreUI.SiticoneButton btnViewReservationRequests;
        private SiticoneNetCoreUI.SiticoneButton btnLendBook;
    }
}
