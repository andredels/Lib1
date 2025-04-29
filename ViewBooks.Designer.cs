namespace Lib1
{
    partial class ViewBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBooks));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxEndYearSearch = new TextBox();
            textBoxStartYearSearch = new TextBox();
            comboBoxGenreSearch = new ComboBox();
            buttonRefresh = new SiticoneNetCoreUI.SiticoneButton();
            siticoneLabel1 = new SiticoneNetCoreUI.SiticoneLabel();
            siticonePictureBox1 = new SiticoneNetCoreUI.SiticonePictureBox();
            textBoxSearch = new TextBox();
            dataGridView1 = new DataGridView();
            datagridViewAllBooks = new DataGridView();
            btnBorrowVwBks = new SiticoneNetCoreUI.SiticoneButton();
            btnDeleteVwBks = new SiticoneNetCoreUI.SiticoneButton();
            btnUpdateVwBks = new SiticoneNetCoreUI.SiticoneButton();
            textBoxAvailableCopiesVwBks = new TextBox();
            siticoneLabel7 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxPublisherVwBks = new TextBox();
            textBoxPublicationYearVwBks = new TextBox();
            siticoneLabel6 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel5 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxAuthorNameVwBks = new TextBox();
            siticoneLabel4 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxBookNameVwBks = new TextBox();
            siticoneLabel3 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel15 = new SiticoneNetCoreUI.SiticoneLabel();
            textBoxISBNVwBks = new TextBox();
            siticoneLabel14 = new SiticoneNetCoreUI.SiticoneLabel();
            btnReserve = new SiticoneNetCoreUI.SiticoneButton();
            textBoxTotalCopiesVwBks = new TextBox();
            siticoneLabel12 = new SiticoneNetCoreUI.SiticoneLabel();
            comboBoxBookGenre = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)datagridViewAllBooks).BeginInit();
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
            panel1.Controls.Add(comboBoxGenreSearch);
            panel1.Controls.Add(buttonRefresh);
            panel1.Controls.Add(siticoneLabel1);
            panel1.Controls.Add(siticonePictureBox1);
            panel1.Controls.Add(textBoxSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 125);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(969, 84);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 10;
            label3.Text = "Year (End)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(839, 84);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 9;
            label2.Text = "Year (Start)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(708, 84);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 8;
            label1.Text = "Genre";
            // 
            // textBoxEndYearSearch
            // 
            textBoxEndYearSearch.Location = new Point(969, 53);
            textBoxEndYearSearch.Multiline = true;
            textBoxEndYearSearch.Name = "textBoxEndYearSearch";
            textBoxEndYearSearch.Size = new Size(125, 27);
            textBoxEndYearSearch.TabIndex = 7;
            textBoxEndYearSearch.TextChanged += textBoxEndYearSearch_TextChanged;
            // 
            // textBoxStartYearSearch
            // 
            textBoxStartYearSearch.Location = new Point(839, 53);
            textBoxStartYearSearch.Multiline = true;
            textBoxStartYearSearch.Name = "textBoxStartYearSearch";
            textBoxStartYearSearch.Size = new Size(125, 27);
            textBoxStartYearSearch.TabIndex = 6;
            textBoxStartYearSearch.TextChanged += textBoxStartYearSearch_TextChanged;
            // 
            // comboBoxGenreSearch
            // 
            comboBoxGenreSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGenreSearch.FormattingEnabled = true;
            comboBoxGenreSearch.Location = new Point(708, 53);
            comboBoxGenreSearch.Name = "comboBoxGenreSearch";
            comboBoxGenreSearch.Size = new Size(125, 28);
            comboBoxGenreSearch.TabIndex = 5;
            comboBoxGenreSearch.SelectedIndexChanged += comboBoxGenreSearch_SelectedIndexChanged;
            // 
            // buttonRefresh
            // 
            buttonRefresh.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            buttonRefresh.AccessibleName = "Refresh";
            buttonRefresh.AutoSizeBasedOnText = false;
            buttonRefresh.BackColor = Color.Transparent;
            buttonRefresh.BadgeBackColor = Color.Red;
            buttonRefresh.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonRefresh.BadgeValue = 0;
            buttonRefresh.BadgeValueForeColor = Color.White;
            buttonRefresh.BorderColor = Color.Transparent;
            buttonRefresh.BorderWidth = 2;
            buttonRefresh.ButtonBackColor = Color.FromArgb(255, 128, 0);
            buttonRefresh.ButtonImage = null;
            buttonRefresh.CanBeep = true;
            buttonRefresh.CanGlow = false;
            buttonRefresh.CanShake = true;
            buttonRefresh.ContextMenuStripEx = null;
            buttonRefresh.CornerRadiusBottomLeft = 8;
            buttonRefresh.CornerRadiusBottomRight = 8;
            buttonRefresh.CornerRadiusTopLeft = 8;
            buttonRefresh.CornerRadiusTopRight = 8;
            buttonRefresh.CustomCursor = Cursors.Default;
            buttonRefresh.DisabledTextColor = Color.FromArgb(150, 150, 150);
            buttonRefresh.EnableLongPress = false;
            buttonRefresh.EnablePressAnimation = true;
            buttonRefresh.EnableRippleEffect = true;
            buttonRefresh.EnableShadow = false;
            buttonRefresh.EnableTextWrapping = false;
            buttonRefresh.Font = new Font("Segoe UI", 9F);
            buttonRefresh.GlowColor = Color.FromArgb(100, 255, 255, 255);
            buttonRefresh.GlowIntensity = 100;
            buttonRefresh.GlowRadius = 20F;
            buttonRefresh.GradientBackground = false;
            buttonRefresh.GradientColor = Color.FromArgb(114, 168, 255);
            buttonRefresh.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            buttonRefresh.HintText = null;
            buttonRefresh.HoverBackColor = Color.FromArgb(114, 168, 255);
            buttonRefresh.HoverFontStyle = FontStyle.Regular;
            buttonRefresh.HoverTextColor = Color.White;
            buttonRefresh.HoverTransitionDuration = 250;
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.ImagePadding = 5;
            buttonRefresh.ImageSize = new Size(16, 16);
            buttonRefresh.IsRadial = false;
            buttonRefresh.IsReadOnly = false;
            buttonRefresh.IsToggleButton = false;
            buttonRefresh.IsToggled = false;
            buttonRefresh.Location = new Point(969, 18);
            buttonRefresh.LongPressDurationMS = 1000;
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.NormalFontStyle = FontStyle.Regular;
            buttonRefresh.ParticleColor = Color.FromArgb(200, 200, 200);
            buttonRefresh.ParticleCount = 15;
            buttonRefresh.PressAnimationScale = 0.97F;
            buttonRefresh.PressedBackColor = Color.FromArgb(74, 128, 235);
            buttonRefresh.PressedFontStyle = FontStyle.Regular;
            buttonRefresh.PressTransitionDuration = 150;
            buttonRefresh.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            buttonRefresh.RippleColor = Color.FromArgb(255, 255, 255);
            buttonRefresh.RippleOpacity = 0.3F;
            buttonRefresh.RippleRadiusMultiplier = 0.6F;
            buttonRefresh.ShadowBlur = 5;
            buttonRefresh.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            buttonRefresh.ShadowOffset = new Point(2, 2);
            buttonRefresh.ShakeDuration = 500;
            buttonRefresh.ShakeIntensity = 5;
            buttonRefresh.Size = new Size(126, 29);
            buttonRefresh.TabIndex = 4;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.TextAlign = ContentAlignment.MiddleCenter;
            buttonRefresh.TextColor = Color.White;
            buttonRefresh.TooltipText = null;
            buttonRefresh.UseAdvancedRendering = true;
            buttonRefresh.UseParticles = false;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // siticoneLabel1
            // 
            siticoneLabel1.BackColor = Color.Transparent;
            siticoneLabel1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabel1.Location = new Point(239, 44);
            siticoneLabel1.Name = "siticoneLabel1";
            siticoneLabel1.Size = new Size(251, 45);
            siticoneLabel1.TabIndex = 3;
            siticoneLabel1.Text = "View All Books";
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
            siticonePictureBox1.Location = new Point(3, -25);
            siticonePictureBox1.MaintainAspectRatio = true;
            siticonePictureBox1.Name = "siticonePictureBox1";
            siticonePictureBox1.PlaceholderImage = null;
            siticonePictureBox1.RotationAngle = 0F;
            siticonePictureBox1.Saturation = 1F;
            siticonePictureBox1.ShowBorder = false;
            siticonePictureBox1.Size = new Size(243, 181);
            siticonePictureBox1.SizeMode = SiticoneNetCoreUI.SiticonePictureBoxSizeMode.StretchImage;
            siticonePictureBox1.TabIndex = 2;
            siticonePictureBox1.Text = "siticonePictureBox1";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(708, 18);
            textBoxSearch.Multiline = true;
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(251, 29);
            textBoxSearch.TabIndex = 0;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.BurlyWood;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 149);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1065, 301);
            dataGridView1.TabIndex = 1;
            // 
            // datagridViewAllBooks
            // 
            datagridViewAllBooks.BackgroundColor = Color.BurlyWood;
            datagridViewAllBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridViewAllBooks.Location = new Point(16, 149);
            datagridViewAllBooks.Name = "datagridViewAllBooks";
            datagridViewAllBooks.ReadOnly = true;
            datagridViewAllBooks.RowHeadersWidth = 51;
            datagridViewAllBooks.Size = new Size(1065, 301);
            datagridViewAllBooks.TabIndex = 3;
            datagridViewAllBooks.CellContentClick += dataGridViewViewAllBooks_CellContentClick;
            // 
            // btnBorrowVwBks
            // 
            btnBorrowVwBks.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnBorrowVwBks.AccessibleName = "Borrow";
            btnBorrowVwBks.AutoSizeBasedOnText = false;
            btnBorrowVwBks.BackColor = Color.Transparent;
            btnBorrowVwBks.BadgeBackColor = Color.Red;
            btnBorrowVwBks.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnBorrowVwBks.BadgeValue = 0;
            btnBorrowVwBks.BadgeValueForeColor = Color.White;
            btnBorrowVwBks.BorderColor = Color.Transparent;
            btnBorrowVwBks.BorderWidth = 2;
            btnBorrowVwBks.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnBorrowVwBks.ButtonImage = null;
            btnBorrowVwBks.CanBeep = true;
            btnBorrowVwBks.CanGlow = false;
            btnBorrowVwBks.CanShake = true;
            btnBorrowVwBks.ContextMenuStripEx = null;
            btnBorrowVwBks.CornerRadiusBottomLeft = 8;
            btnBorrowVwBks.CornerRadiusBottomRight = 8;
            btnBorrowVwBks.CornerRadiusTopLeft = 8;
            btnBorrowVwBks.CornerRadiusTopRight = 8;
            btnBorrowVwBks.CustomCursor = Cursors.Default;
            btnBorrowVwBks.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnBorrowVwBks.EnableLongPress = false;
            btnBorrowVwBks.EnablePressAnimation = true;
            btnBorrowVwBks.EnableRippleEffect = true;
            btnBorrowVwBks.EnableShadow = false;
            btnBorrowVwBks.EnableTextWrapping = false;
            btnBorrowVwBks.Font = new Font("Segoe UI", 9F);
            btnBorrowVwBks.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnBorrowVwBks.GlowIntensity = 100;
            btnBorrowVwBks.GlowRadius = 20F;
            btnBorrowVwBks.GradientBackground = false;
            btnBorrowVwBks.GradientColor = Color.FromArgb(114, 168, 255);
            btnBorrowVwBks.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnBorrowVwBks.HintText = null;
            btnBorrowVwBks.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnBorrowVwBks.HoverFontStyle = FontStyle.Regular;
            btnBorrowVwBks.HoverTextColor = Color.White;
            btnBorrowVwBks.HoverTransitionDuration = 250;
            btnBorrowVwBks.ImageAlign = ContentAlignment.MiddleLeft;
            btnBorrowVwBks.ImagePadding = 5;
            btnBorrowVwBks.ImageSize = new Size(16, 16);
            btnBorrowVwBks.IsRadial = false;
            btnBorrowVwBks.IsReadOnly = false;
            btnBorrowVwBks.IsToggleButton = false;
            btnBorrowVwBks.IsToggled = false;
            btnBorrowVwBks.Location = new Point(945, 649);
            btnBorrowVwBks.LongPressDurationMS = 1000;
            btnBorrowVwBks.Name = "btnBorrowVwBks";
            btnBorrowVwBks.NormalFontStyle = FontStyle.Regular;
            btnBorrowVwBks.ParticleColor = Color.FromArgb(200, 200, 200);
            btnBorrowVwBks.ParticleCount = 15;
            btnBorrowVwBks.PressAnimationScale = 0.97F;
            btnBorrowVwBks.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnBorrowVwBks.PressedFontStyle = FontStyle.Regular;
            btnBorrowVwBks.PressTransitionDuration = 150;
            btnBorrowVwBks.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnBorrowVwBks.RippleColor = Color.FromArgb(255, 255, 255);
            btnBorrowVwBks.RippleOpacity = 0.3F;
            btnBorrowVwBks.RippleRadiusMultiplier = 0.6F;
            btnBorrowVwBks.ShadowBlur = 5;
            btnBorrowVwBks.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnBorrowVwBks.ShadowOffset = new Point(2, 2);
            btnBorrowVwBks.ShakeDuration = 500;
            btnBorrowVwBks.ShakeIntensity = 5;
            btnBorrowVwBks.Size = new Size(85, 42);
            btnBorrowVwBks.TabIndex = 30;
            btnBorrowVwBks.Text = "Borrow";
            btnBorrowVwBks.TextAlign = ContentAlignment.MiddleCenter;
            btnBorrowVwBks.TextColor = Color.White;
            btnBorrowVwBks.TooltipText = null;
            btnBorrowVwBks.UseAdvancedRendering = true;
            btnBorrowVwBks.UseParticles = false;
            btnBorrowVwBks.Click += btnBorrowVwBks_Click;
            // 
            // btnDeleteVwBks
            // 
            btnDeleteVwBks.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnDeleteVwBks.AccessibleName = "Delete";
            btnDeleteVwBks.AutoSizeBasedOnText = false;
            btnDeleteVwBks.BackColor = Color.Transparent;
            btnDeleteVwBks.BadgeBackColor = Color.Red;
            btnDeleteVwBks.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDeleteVwBks.BadgeValue = 0;
            btnDeleteVwBks.BadgeValueForeColor = Color.White;
            btnDeleteVwBks.BorderColor = Color.Transparent;
            btnDeleteVwBks.BorderWidth = 2;
            btnDeleteVwBks.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnDeleteVwBks.ButtonImage = null;
            btnDeleteVwBks.CanBeep = true;
            btnDeleteVwBks.CanGlow = false;
            btnDeleteVwBks.CanShake = true;
            btnDeleteVwBks.ContextMenuStripEx = null;
            btnDeleteVwBks.CornerRadiusBottomLeft = 8;
            btnDeleteVwBks.CornerRadiusBottomRight = 8;
            btnDeleteVwBks.CornerRadiusTopLeft = 8;
            btnDeleteVwBks.CornerRadiusTopRight = 8;
            btnDeleteVwBks.CustomCursor = Cursors.Default;
            btnDeleteVwBks.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnDeleteVwBks.EnableLongPress = false;
            btnDeleteVwBks.EnablePressAnimation = true;
            btnDeleteVwBks.EnableRippleEffect = true;
            btnDeleteVwBks.EnableShadow = false;
            btnDeleteVwBks.EnableTextWrapping = false;
            btnDeleteVwBks.Font = new Font("Segoe UI", 9F);
            btnDeleteVwBks.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnDeleteVwBks.GlowIntensity = 100;
            btnDeleteVwBks.GlowRadius = 20F;
            btnDeleteVwBks.GradientBackground = false;
            btnDeleteVwBks.GradientColor = Color.FromArgb(114, 168, 255);
            btnDeleteVwBks.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnDeleteVwBks.HintText = null;
            btnDeleteVwBks.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnDeleteVwBks.HoverFontStyle = FontStyle.Regular;
            btnDeleteVwBks.HoverTextColor = Color.White;
            btnDeleteVwBks.HoverTransitionDuration = 250;
            btnDeleteVwBks.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteVwBks.ImagePadding = 5;
            btnDeleteVwBks.ImageSize = new Size(16, 16);
            btnDeleteVwBks.IsRadial = false;
            btnDeleteVwBks.IsReadOnly = false;
            btnDeleteVwBks.IsToggleButton = false;
            btnDeleteVwBks.IsToggled = false;
            btnDeleteVwBks.Location = new Point(945, 649);
            btnDeleteVwBks.LongPressDurationMS = 1000;
            btnDeleteVwBks.Name = "btnDeleteVwBks";
            btnDeleteVwBks.NormalFontStyle = FontStyle.Regular;
            btnDeleteVwBks.ParticleColor = Color.FromArgb(200, 200, 200);
            btnDeleteVwBks.ParticleCount = 15;
            btnDeleteVwBks.PressAnimationScale = 0.97F;
            btnDeleteVwBks.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnDeleteVwBks.PressedFontStyle = FontStyle.Regular;
            btnDeleteVwBks.PressTransitionDuration = 150;
            btnDeleteVwBks.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnDeleteVwBks.RippleColor = Color.FromArgb(255, 255, 255);
            btnDeleteVwBks.RippleOpacity = 0.3F;
            btnDeleteVwBks.RippleRadiusMultiplier = 0.6F;
            btnDeleteVwBks.ShadowBlur = 5;
            btnDeleteVwBks.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnDeleteVwBks.ShadowOffset = new Point(2, 2);
            btnDeleteVwBks.ShakeDuration = 500;
            btnDeleteVwBks.ShakeIntensity = 5;
            btnDeleteVwBks.Size = new Size(85, 42);
            btnDeleteVwBks.TabIndex = 27;
            btnDeleteVwBks.Text = "Delete";
            btnDeleteVwBks.TextAlign = ContentAlignment.MiddleCenter;
            btnDeleteVwBks.TextColor = Color.White;
            btnDeleteVwBks.TooltipText = null;
            btnDeleteVwBks.UseAdvancedRendering = true;
            btnDeleteVwBks.UseParticles = false;
            btnDeleteVwBks.Click += btnDeleteVwBks_Click;
            // 
            // btnUpdateVwBks
            // 
            btnUpdateVwBks.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnUpdateVwBks.AccessibleName = "Update";
            btnUpdateVwBks.AutoSizeBasedOnText = false;
            btnUpdateVwBks.BackColor = Color.Transparent;
            btnUpdateVwBks.BadgeBackColor = Color.Red;
            btnUpdateVwBks.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnUpdateVwBks.BadgeValue = 0;
            btnUpdateVwBks.BadgeValueForeColor = Color.White;
            btnUpdateVwBks.BorderColor = Color.Transparent;
            btnUpdateVwBks.BorderWidth = 2;
            btnUpdateVwBks.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnUpdateVwBks.ButtonImage = null;
            btnUpdateVwBks.CanBeep = true;
            btnUpdateVwBks.CanGlow = false;
            btnUpdateVwBks.CanShake = true;
            btnUpdateVwBks.ContextMenuStripEx = null;
            btnUpdateVwBks.CornerRadiusBottomLeft = 8;
            btnUpdateVwBks.CornerRadiusBottomRight = 8;
            btnUpdateVwBks.CornerRadiusTopLeft = 8;
            btnUpdateVwBks.CornerRadiusTopRight = 8;
            btnUpdateVwBks.CustomCursor = Cursors.Default;
            btnUpdateVwBks.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnUpdateVwBks.EnableLongPress = false;
            btnUpdateVwBks.EnablePressAnimation = true;
            btnUpdateVwBks.EnableRippleEffect = true;
            btnUpdateVwBks.EnableShadow = false;
            btnUpdateVwBks.EnableTextWrapping = false;
            btnUpdateVwBks.Font = new Font("Segoe UI", 9F);
            btnUpdateVwBks.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnUpdateVwBks.GlowIntensity = 100;
            btnUpdateVwBks.GlowRadius = 20F;
            btnUpdateVwBks.GradientBackground = false;
            btnUpdateVwBks.GradientColor = Color.FromArgb(114, 168, 255);
            btnUpdateVwBks.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnUpdateVwBks.HintText = null;
            btnUpdateVwBks.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnUpdateVwBks.HoverFontStyle = FontStyle.Regular;
            btnUpdateVwBks.HoverTextColor = Color.White;
            btnUpdateVwBks.HoverTransitionDuration = 250;
            btnUpdateVwBks.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdateVwBks.ImagePadding = 5;
            btnUpdateVwBks.ImageSize = new Size(16, 16);
            btnUpdateVwBks.IsRadial = false;
            btnUpdateVwBks.IsReadOnly = false;
            btnUpdateVwBks.IsToggleButton = false;
            btnUpdateVwBks.IsToggled = false;
            btnUpdateVwBks.Location = new Point(748, 649);
            btnUpdateVwBks.LongPressDurationMS = 1000;
            btnUpdateVwBks.Name = "btnUpdateVwBks";
            btnUpdateVwBks.NormalFontStyle = FontStyle.Regular;
            btnUpdateVwBks.ParticleColor = Color.FromArgb(200, 200, 200);
            btnUpdateVwBks.ParticleCount = 15;
            btnUpdateVwBks.PressAnimationScale = 0.97F;
            btnUpdateVwBks.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnUpdateVwBks.PressedFontStyle = FontStyle.Regular;
            btnUpdateVwBks.PressTransitionDuration = 150;
            btnUpdateVwBks.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnUpdateVwBks.RippleColor = Color.FromArgb(255, 255, 255);
            btnUpdateVwBks.RippleOpacity = 0.3F;
            btnUpdateVwBks.RippleRadiusMultiplier = 0.6F;
            btnUpdateVwBks.ShadowBlur = 5;
            btnUpdateVwBks.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnUpdateVwBks.ShadowOffset = new Point(2, 2);
            btnUpdateVwBks.ShakeDuration = 500;
            btnUpdateVwBks.ShakeIntensity = 5;
            btnUpdateVwBks.Size = new Size(85, 42);
            btnUpdateVwBks.TabIndex = 26;
            btnUpdateVwBks.Text = "Update";
            btnUpdateVwBks.TextAlign = ContentAlignment.MiddleCenter;
            btnUpdateVwBks.TextColor = Color.White;
            btnUpdateVwBks.TooltipText = null;
            btnUpdateVwBks.UseAdvancedRendering = true;
            btnUpdateVwBks.UseParticles = false;
            btnUpdateVwBks.Click += btnUpdateVwBks_Click;
            // 
            // textBoxAvailableCopiesVwBks
            // 
            textBoxAvailableCopiesVwBks.Location = new Point(748, 523);
            textBoxAvailableCopiesVwBks.Name = "textBoxAvailableCopiesVwBks";
            textBoxAvailableCopiesVwBks.Size = new Size(283, 27);
            textBoxAvailableCopiesVwBks.TabIndex = 25;
            textBoxAvailableCopiesVwBks.TextChanged += textBoxAvailableCopiesVwBks_TextChanged;
            // 
            // siticoneLabel7
            // 
            siticoneLabel7.BackColor = Color.Transparent;
            siticoneLabel7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel7.Location = new Point(570, 524);
            siticoneLabel7.Name = "siticoneLabel7";
            siticoneLabel7.Size = new Size(142, 29);
            siticoneLabel7.TabIndex = 24;
            siticoneLabel7.Text = "Available Copies";
            // 
            // textBoxPublisherVwBks
            // 
            textBoxPublisherVwBks.Location = new Point(193, 664);
            textBoxPublisherVwBks.Name = "textBoxPublisherVwBks";
            textBoxPublisherVwBks.Size = new Size(283, 27);
            textBoxPublisherVwBks.TabIndex = 23;
            // 
            // textBoxPublicationYearVwBks
            // 
            textBoxPublicationYearVwBks.Location = new Point(748, 471);
            textBoxPublicationYearVwBks.Name = "textBoxPublicationYearVwBks";
            textBoxPublicationYearVwBks.Size = new Size(283, 27);
            textBoxPublicationYearVwBks.TabIndex = 22;
            // 
            // siticoneLabel6
            // 
            siticoneLabel6.BackColor = Color.Transparent;
            siticoneLabel6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel6.Location = new Point(21, 665);
            siticoneLabel6.Name = "siticoneLabel6";
            siticoneLabel6.Size = new Size(137, 29);
            siticoneLabel6.TabIndex = 21;
            siticoneLabel6.Text = "Book Publisher";
            // 
            // siticoneLabel5
            // 
            siticoneLabel5.BackColor = Color.Transparent;
            siticoneLabel5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel5.Location = new Point(570, 472);
            siticoneLabel5.Name = "siticoneLabel5";
            siticoneLabel5.Size = new Size(142, 29);
            siticoneLabel5.TabIndex = 20;
            siticoneLabel5.Text = "Publication Year";
            // 
            // textBoxAuthorNameVwBks
            // 
            textBoxAuthorNameVwBks.Location = new Point(193, 523);
            textBoxAuthorNameVwBks.Name = "textBoxAuthorNameVwBks";
            textBoxAuthorNameVwBks.Size = new Size(283, 27);
            textBoxAuthorNameVwBks.TabIndex = 19;
            // 
            // siticoneLabel4
            // 
            siticoneLabel4.BackColor = Color.Transparent;
            siticoneLabel4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel4.Location = new Point(21, 524);
            siticoneLabel4.Name = "siticoneLabel4";
            siticoneLabel4.Size = new Size(137, 29);
            siticoneLabel4.TabIndex = 18;
            siticoneLabel4.Text = "Book Author ";
            // 
            // textBoxBookNameVwBks
            // 
            textBoxBookNameVwBks.Location = new Point(193, 471);
            textBoxBookNameVwBks.Name = "textBoxBookNameVwBks";
            textBoxBookNameVwBks.Size = new Size(283, 27);
            textBoxBookNameVwBks.TabIndex = 17;
            // 
            // siticoneLabel3
            // 
            siticoneLabel3.BackColor = Color.Transparent;
            siticoneLabel3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel3.Location = new Point(21, 472);
            siticoneLabel3.Name = "siticoneLabel3";
            siticoneLabel3.Size = new Size(137, 29);
            siticoneLabel3.TabIndex = 16;
            siticoneLabel3.Text = "Book Title";
            // 
            // siticoneLabel15
            // 
            siticoneLabel15.BackColor = Color.Transparent;
            siticoneLabel15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel15.Location = new Point(570, 575);
            siticoneLabel15.Name = "siticoneLabel15";
            siticoneLabel15.Size = new Size(142, 29);
            siticoneLabel15.TabIndex = 56;
            siticoneLabel15.Text = "Book Genre";
            // 
            // textBoxISBNVwBks
            // 
            textBoxISBNVwBks.Location = new Point(193, 616);
            textBoxISBNVwBks.Name = "textBoxISBNVwBks";
            textBoxISBNVwBks.Size = new Size(283, 27);
            textBoxISBNVwBks.TabIndex = 55;
            textBoxISBNVwBks.TextChanged += textBoxISBNVwBks_TextChanged;
            // 
            // siticoneLabel14
            // 
            siticoneLabel14.BackColor = Color.Transparent;
            siticoneLabel14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel14.Location = new Point(21, 617);
            siticoneLabel14.Name = "siticoneLabel14";
            siticoneLabel14.Size = new Size(137, 29);
            siticoneLabel14.TabIndex = 54;
            siticoneLabel14.Text = "Book ISBN";
            // 
            // btnReserve
            // 
            btnReserve.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnReserve.AccessibleName = "Reserve";
            btnReserve.AutoSizeBasedOnText = false;
            btnReserve.BackColor = Color.Transparent;
            btnReserve.BadgeBackColor = Color.Red;
            btnReserve.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnReserve.BadgeValue = 0;
            btnReserve.BadgeValueForeColor = Color.White;
            btnReserve.BorderColor = Color.Transparent;
            btnReserve.BorderWidth = 2;
            btnReserve.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnReserve.ButtonImage = null;
            btnReserve.CanBeep = true;
            btnReserve.CanGlow = false;
            btnReserve.CanShake = true;
            btnReserve.ContextMenuStripEx = null;
            btnReserve.CornerRadiusBottomLeft = 8;
            btnReserve.CornerRadiusBottomRight = 8;
            btnReserve.CornerRadiusTopLeft = 8;
            btnReserve.CornerRadiusTopRight = 8;
            btnReserve.CustomCursor = Cursors.Default;
            btnReserve.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnReserve.EnableLongPress = false;
            btnReserve.EnablePressAnimation = true;
            btnReserve.EnableRippleEffect = true;
            btnReserve.EnableShadow = false;
            btnReserve.EnableTextWrapping = false;
            btnReserve.Font = new Font("Segoe UI", 9F);
            btnReserve.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnReserve.GlowIntensity = 100;
            btnReserve.GlowRadius = 20F;
            btnReserve.GradientBackground = false;
            btnReserve.GradientColor = Color.FromArgb(114, 168, 255);
            btnReserve.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnReserve.HintText = null;
            btnReserve.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnReserve.HoverFontStyle = FontStyle.Regular;
            btnReserve.HoverTextColor = Color.White;
            btnReserve.HoverTransitionDuration = 250;
            btnReserve.ImageAlign = ContentAlignment.MiddleLeft;
            btnReserve.ImagePadding = 5;
            btnReserve.ImageSize = new Size(16, 16);
            btnReserve.IsRadial = false;
            btnReserve.IsReadOnly = false;
            btnReserve.IsToggleButton = false;
            btnReserve.IsToggled = false;
            btnReserve.Location = new Point(748, 649);
            btnReserve.LongPressDurationMS = 1000;
            btnReserve.Name = "btnReserve";
            btnReserve.NormalFontStyle = FontStyle.Regular;
            btnReserve.ParticleColor = Color.FromArgb(200, 200, 200);
            btnReserve.ParticleCount = 15;
            btnReserve.PressAnimationScale = 0.97F;
            btnReserve.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnReserve.PressedFontStyle = FontStyle.Regular;
            btnReserve.PressTransitionDuration = 150;
            btnReserve.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnReserve.RippleColor = Color.FromArgb(255, 255, 255);
            btnReserve.RippleOpacity = 0.3F;
            btnReserve.RippleRadiusMultiplier = 0.6F;
            btnReserve.ShadowBlur = 5;
            btnReserve.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnReserve.ShadowOffset = new Point(2, 2);
            btnReserve.ShakeDuration = 500;
            btnReserve.ShakeIntensity = 5;
            btnReserve.Size = new Size(85, 42);
            btnReserve.TabIndex = 58;
            btnReserve.Text = "Reserve";
            btnReserve.TextAlign = ContentAlignment.MiddleCenter;
            btnReserve.TextColor = Color.White;
            btnReserve.TooltipText = null;
            btnReserve.UseAdvancedRendering = true;
            btnReserve.UseParticles = false;
            btnReserve.Click += btnReserve_Click;
            // 
            // textBoxTotalCopiesVwBks
            // 
            textBoxTotalCopiesVwBks.Location = new Point(193, 571);
            textBoxTotalCopiesVwBks.Name = "textBoxTotalCopiesVwBks";
            textBoxTotalCopiesVwBks.Size = new Size(283, 27);
            textBoxTotalCopiesVwBks.TabIndex = 60;
            textBoxTotalCopiesVwBks.TextChanged += textBoxTotalCopiesVwBks_TextChanged;
            // 
            // siticoneLabel12
            // 
            siticoneLabel12.BackColor = Color.Transparent;
            siticoneLabel12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            siticoneLabel12.Location = new Point(21, 575);
            siticoneLabel12.Name = "siticoneLabel12";
            siticoneLabel12.Size = new Size(137, 29);
            siticoneLabel12.TabIndex = 59;
            siticoneLabel12.Text = "Total Copies";
            // 
            // comboBoxBookGenre
            // 
            comboBoxBookGenre.FormattingEnabled = true;
            comboBoxBookGenre.Location = new Point(748, 577);
            comboBoxBookGenre.Name = "comboBoxBookGenre";
            comboBoxBookGenre.Size = new Size(283, 28);
            comboBoxBookGenre.TabIndex = 61;
            comboBoxBookGenre.SelectedIndexChanged += comboBoxBookGenre_SelectedIndexChanged;
            // 
            // ViewBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(comboBoxBookGenre);
            Controls.Add(textBoxTotalCopiesVwBks);
            Controls.Add(siticoneLabel12);
            Controls.Add(btnReserve);
            Controls.Add(siticoneLabel15);
            Controls.Add(textBoxISBNVwBks);
            Controls.Add(siticoneLabel14);
            Controls.Add(btnBorrowVwBks);
            Controls.Add(btnDeleteVwBks);
            Controls.Add(btnUpdateVwBks);
            Controls.Add(textBoxAvailableCopiesVwBks);
            Controls.Add(siticoneLabel7);
            Controls.Add(textBoxPublisherVwBks);
            Controls.Add(textBoxPublicationYearVwBks);
            Controls.Add(siticoneLabel6);
            Controls.Add(siticoneLabel5);
            Controls.Add(textBoxAuthorNameVwBks);
            Controls.Add(siticoneLabel4);
            Controls.Add(textBoxBookNameVwBks);
            Controls.Add(siticoneLabel3);
            Controls.Add(datagridViewAllBooks);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "ViewBooks";
            Size = new Size(1098, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)datagridViewAllBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private TextBox textBoxSearch;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticonePictureBox siticonePictureBox1;
        private SiticoneNetCoreUI.SiticoneButton buttonRefresh;
        private ComboBox comboBoxGenreSearch;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxEndYearSearch;
        private TextBox textBoxStartYearSearch;
        private DataGridView datagridViewAllBooks;
        private SiticoneNetCoreUI.SiticoneButton btnBorrowVwBks;
        private SiticoneNetCoreUI.SiticoneButton btnDeleteVwBks;
        private SiticoneNetCoreUI.SiticoneButton btnUpdateVwBks;
        private TextBox textBoxAvailableCopiesVwBks;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel7;
        private TextBox textBoxPublisherVwBks;
        private TextBox textBoxPublicationYearVwBks;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel6;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel5;
        private TextBox textBoxAuthorNameVwBks;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel4;
        private TextBox textBoxBookNameVwBks;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel3;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel15;
        private TextBox textBoxISBNVwBks;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel14;
        private SiticoneNetCoreUI.SiticoneButton btnReserve;
        private TextBox textBoxTotalCopiesVwBks;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel12;
        private ComboBox comboBoxBookGenre;
    }
}
