namespace Lib1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            txtboxUsernameStudent = new TextBox();
            txtboxPasswordStudent = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox5 = new PictureBox();
            panel1 = new Panel();
            siticoneLabel3 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneCloseButton1 = new SiticoneNetCoreUI.SiticoneCloseButton();
            siticoneLinkedLabel1 = new SiticoneNetCoreUI.SiticoneLinkedLabel();
            btnLogin = new SiticoneNetCoreUI.SiticoneButton();
            btnSignup = new SiticoneNetCoreUI.SiticoneButton();
            pictureBox2 = new PictureBox();
            siticoneAdvancedPanel1 = new SiticoneNetCoreUI.SiticoneAdvancedPanel();
            siticoneLabel2 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel1 = new SiticoneNetCoreUI.SiticoneLabel();
            siticonePictureBox1 = new SiticoneNetCoreUI.SiticonePictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            siticoneAdvancedPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(18, 44);
            label1.Name = "label1";
            label1.Size = new Size(0, 35);
            label1.TabIndex = 4;
            // 
            // txtboxUsernameStudent
            // 
            txtboxUsernameStudent.Location = new Point(102, 233);
            txtboxUsernameStudent.Name = "txtboxUsernameStudent";
            txtboxUsernameStudent.Size = new Size(176, 26);
            txtboxUsernameStudent.TabIndex = 12;
            // 
            // txtboxPasswordStudent
            // 
            txtboxPasswordStudent.Location = new Point(102, 275);
            txtboxPasswordStudent.Name = "txtboxPasswordStudent";
            txtboxPasswordStudent.Size = new Size(176, 26);
            txtboxPasswordStudent.TabIndex = 13;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(61, 233);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 26);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImageLayout = ImageLayout.None;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(61, 275);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 26);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 15;
            pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 224, 192);
            panel1.Controls.Add(siticoneLabel3);
            panel1.Controls.Add(siticoneCloseButton1);
            panel1.Controls.Add(siticoneLinkedLabel1);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnSignup);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(txtboxUsernameStudent);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtboxPasswordStudent);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(252, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 450);
            panel1.TabIndex = 16;
            // 
            // siticoneLabel3
            // 
            siticoneLabel3.BackColor = Color.Transparent;
            siticoneLabel3.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabel3.ForeColor = Color.FromArgb(255, 128, 0);
            siticoneLabel3.Location = new Point(65, 189);
            siticoneLabel3.Name = "siticoneLabel3";
            siticoneLabel3.Size = new Size(217, 34);
            siticoneLabel3.TabIndex = 23;
            siticoneLabel3.Text = "Student Login";
            siticoneLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneCloseButton1
            // 
            siticoneCloseButton1.BackColor = Color.Transparent;
            siticoneCloseButton1.CountdownFont = new Font("Segoe UI", 9F);
            siticoneCloseButton1.Cursor = Cursors.Default;
            siticoneCloseButton1.EnableSound = false;
            siticoneCloseButton1.IconAnimation = SiticoneNetCoreUI.SiticoneCloseButton.CloseIconAnimation.Scale;
            siticoneCloseButton1.IconColor = Color.Black;
            siticoneCloseButton1.Location = new Point(294, 3);
            siticoneCloseButton1.Name = "siticoneCloseButton1";
            siticoneCloseButton1.Size = new Size(40, 40);
            siticoneCloseButton1.TabIndex = 21;
            siticoneCloseButton1.Text = "siticoneCloseButton1";
            siticoneCloseButton1.TooltipText = "Close button";
            // 
            // siticoneLinkedLabel1
            // 
            siticoneLinkedLabel1.BackColor = Color.Transparent;
            siticoneLinkedLabel1.Font = new Font("Segoe UI", 10F);
            siticoneLinkedLabel1.Location = new Point(42, 412);
            siticoneLinkedLabel1.Name = "siticoneLinkedLabel1";
            siticoneLinkedLabel1.Size = new Size(251, 29);
            siticoneLinkedLabel1.TabIndex = 20;
            siticoneLinkedLabel1.TabStop = true;
            siticoneLinkedLabel1.Text = "Are you an admin? Click here.";
            siticoneLinkedLabel1.LinkClicked += siticoneLinkedLabel1_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnLogin.AccessibleName = "LOGIN";
            btnLogin.AutoSizeBasedOnText = false;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BadgeBackColor = Color.Red;
            btnLogin.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLogin.BadgeValue = 0;
            btnLogin.BadgeValueForeColor = Color.White;
            btnLogin.BorderColor = Color.Transparent;
            btnLogin.BorderWidth = 2;
            btnLogin.ButtonBackColor = Color.FromArgb(255, 224, 192);
            btnLogin.ButtonImage = null;
            btnLogin.CanBeep = true;
            btnLogin.CanGlow = false;
            btnLogin.CanShake = true;
            btnLogin.ContextMenuStripEx = null;
            btnLogin.CornerRadiusBottomLeft = 8;
            btnLogin.CornerRadiusBottomRight = 8;
            btnLogin.CornerRadiusTopLeft = 8;
            btnLogin.CornerRadiusTopRight = 8;
            btnLogin.CustomCursor = Cursors.Default;
            btnLogin.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnLogin.EnableLongPress = false;
            btnLogin.EnablePressAnimation = true;
            btnLogin.EnableRippleEffect = true;
            btnLogin.EnableShadow = false;
            btnLogin.EnableTextWrapping = false;
            btnLogin.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnLogin.GlowIntensity = 100;
            btnLogin.GlowRadius = 20F;
            btnLogin.GradientBackground = true;
            btnLogin.GradientColor = Color.FromArgb(128, 64, 0);
            btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnLogin.HintText = null;
            btnLogin.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnLogin.HoverFontStyle = FontStyle.Regular;
            btnLogin.HoverTextColor = Color.Black;
            btnLogin.HoverTransitionDuration = 250;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.ImagePadding = 5;
            btnLogin.ImageSize = new Size(16, 16);
            btnLogin.IsRadial = false;
            btnLogin.IsReadOnly = false;
            btnLogin.IsToggleButton = false;
            btnLogin.IsToggled = false;
            btnLogin.Location = new Point(61, 321);
            btnLogin.LongPressDurationMS = 1000;
            btnLogin.Name = "btnLogin";
            btnLogin.NormalFontStyle = FontStyle.Regular;
            btnLogin.ParticleColor = Color.FromArgb(200, 200, 200);
            btnLogin.ParticleCount = 15;
            btnLogin.PressAnimationScale = 0.97F;
            btnLogin.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnLogin.PressedFontStyle = FontStyle.Regular;
            btnLogin.PressTransitionDuration = 150;
            btnLogin.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnLogin.RippleColor = Color.FromArgb(255, 255, 255);
            btnLogin.RippleOpacity = 0.3F;
            btnLogin.RippleRadiusMultiplier = 0.6F;
            btnLogin.ShadowBlur = 5;
            btnLogin.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnLogin.ShadowOffset = new Point(2, 2);
            btnLogin.ShakeDuration = 500;
            btnLogin.ShakeIntensity = 5;
            btnLogin.Size = new Size(217, 33);
            btnLogin.TabIndex = 19;
            btnLogin.Text = "LOGIN";
            btnLogin.TextAlign = ContentAlignment.MiddleCenter;
            btnLogin.TextColor = Color.Black;
            btnLogin.TooltipText = null;
            btnLogin.UseAdvancedRendering = true;
            btnLogin.UseParticles = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignup
            // 
            btnSignup.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnSignup.AccessibleName = "SIGN UP";
            btnSignup.AutoSizeBasedOnText = false;
            btnSignup.BackColor = Color.Transparent;
            btnSignup.BadgeBackColor = Color.Red;
            btnSignup.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnSignup.BadgeValue = 0;
            btnSignup.BadgeValueForeColor = Color.White;
            btnSignup.BorderColor = Color.Transparent;
            btnSignup.BorderWidth = 2;
            btnSignup.ButtonBackColor = Color.FromArgb(255, 224, 192);
            btnSignup.ButtonImage = null;
            btnSignup.CanBeep = true;
            btnSignup.CanGlow = false;
            btnSignup.CanShake = true;
            btnSignup.ContextMenuStripEx = null;
            btnSignup.CornerRadiusBottomLeft = 8;
            btnSignup.CornerRadiusBottomRight = 8;
            btnSignup.CornerRadiusTopLeft = 8;
            btnSignup.CornerRadiusTopRight = 8;
            btnSignup.CustomCursor = Cursors.Default;
            btnSignup.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnSignup.EnableLongPress = false;
            btnSignup.EnablePressAnimation = true;
            btnSignup.EnableRippleEffect = true;
            btnSignup.EnableShadow = false;
            btnSignup.EnableTextWrapping = false;
            btnSignup.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignup.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnSignup.GlowIntensity = 100;
            btnSignup.GlowRadius = 20F;
            btnSignup.GradientBackground = true;
            btnSignup.GradientColor = Color.FromArgb(128, 64, 0);
            btnSignup.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSignup.HintText = null;
            btnSignup.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnSignup.HoverFontStyle = FontStyle.Regular;
            btnSignup.HoverTextColor = Color.Black;
            btnSignup.HoverTransitionDuration = 250;
            btnSignup.ImageAlign = ContentAlignment.MiddleLeft;
            btnSignup.ImagePadding = 5;
            btnSignup.ImageSize = new Size(16, 16);
            btnSignup.IsRadial = false;
            btnSignup.IsReadOnly = false;
            btnSignup.IsToggleButton = false;
            btnSignup.IsToggled = false;
            btnSignup.Location = new Point(61, 360);
            btnSignup.LongPressDurationMS = 1000;
            btnSignup.Name = "btnSignup";
            btnSignup.NormalFontStyle = FontStyle.Regular;
            btnSignup.ParticleColor = Color.FromArgb(200, 200, 200);
            btnSignup.ParticleCount = 15;
            btnSignup.PressAnimationScale = 0.97F;
            btnSignup.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnSignup.PressedFontStyle = FontStyle.Regular;
            btnSignup.PressTransitionDuration = 150;
            btnSignup.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnSignup.RippleColor = Color.FromArgb(255, 255, 255);
            btnSignup.RippleOpacity = 0.3F;
            btnSignup.RippleRadiusMultiplier = 0.6F;
            btnSignup.ShadowBlur = 5;
            btnSignup.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnSignup.ShadowOffset = new Point(2, 2);
            btnSignup.ShakeDuration = 500;
            btnSignup.ShakeIntensity = 5;
            btnSignup.Size = new Size(217, 33);
            btnSignup.TabIndex = 18;
            btnSignup.Text = "SIGN UP";
            btnSignup.TextAlign = ContentAlignment.MiddleCenter;
            btnSignup.TextColor = Color.Black;
            btnSignup.TooltipText = null;
            btnSignup.UseAdvancedRendering = true;
            btnSignup.UseParticles = false;
            btnSignup.Click += btnSignup_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(91, 33);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(162, 153);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // siticoneAdvancedPanel1
            // 
            siticoneAdvancedPanel1.ActiveBackColor = Color.Empty;
            siticoneAdvancedPanel1.ActiveBorderColor = Color.Empty;
            siticoneAdvancedPanel1.AdvancedBorderStyle = SiticoneNetCoreUI.SiticoneAdvancedPanel.BorderStyleEx.Solid;
            siticoneAdvancedPanel1.AnimationDuration = 500;
            siticoneAdvancedPanel1.AnimationType = SiticoneNetCoreUI.SiticoneAdvancedPanel.AnimationTypeEx.Fade;
            siticoneAdvancedPanel1.BackColor = Color.FromArgb(255, 224, 192);
            siticoneAdvancedPanel1.BackgroundImageCustom = null;
            siticoneAdvancedPanel1.BackgroundImageOpacity = 1F;
            siticoneAdvancedPanel1.BackgroundImageSizeMode = SiticoneNetCoreUI.SiticoneAdvancedPanel.ImageSizeModeEx.Stretch;
            siticoneAdvancedPanel1.BackgroundOverlayColor = Color.FromArgb(0, 0, 0, 0);
            siticoneAdvancedPanel1.BorderColor = Color.Gray;
            siticoneAdvancedPanel1.BorderDashPattern = null;
            siticoneAdvancedPanel1.BorderGlowColor = Color.Cyan;
            siticoneAdvancedPanel1.BorderGlowSize = 3F;
            siticoneAdvancedPanel1.BorderWidth = 1F;
            siticoneAdvancedPanel1.BottomLeftRadius = 5;
            siticoneAdvancedPanel1.BottomRightRadius = 5;
            siticoneAdvancedPanel1.ContentAlignmentCustom = ContentAlignment.MiddleCenter;
            siticoneAdvancedPanel1.Controls.Add(siticoneLabel2);
            siticoneAdvancedPanel1.Controls.Add(siticoneLabel1);
            siticoneAdvancedPanel1.Controls.Add(siticonePictureBox1);
            siticoneAdvancedPanel1.CornerPadding = new Padding(5);
            siticoneAdvancedPanel1.DisabledBackColor = Color.Empty;
            siticoneAdvancedPanel1.DisabledBorderColor = Color.Empty;
            siticoneAdvancedPanel1.Dock = DockStyle.Left;
            siticoneAdvancedPanel1.DoubleBorderSpacing = 2F;
            siticoneAdvancedPanel1.EasingType = SiticoneNetCoreUI.SiticoneAdvancedPanel.EasingTypeEx.Linear;
            siticoneAdvancedPanel1.EnableAnimation = false;
            siticoneAdvancedPanel1.EnableBackgroundImage = false;
            siticoneAdvancedPanel1.EnableBorderGlow = false;
            siticoneAdvancedPanel1.EnableDoubleBorder = false;
            siticoneAdvancedPanel1.EnableGradient = true;
            siticoneAdvancedPanel1.EnableInnerShadow = false;
            siticoneAdvancedPanel1.EnableShadow = false;
            siticoneAdvancedPanel1.EnableSmartPadding = true;
            siticoneAdvancedPanel1.EnableStateStyles = false;
            siticoneAdvancedPanel1.FlowDirectionCustom = FlowDirection.LeftToRight;
            siticoneAdvancedPanel1.GradientAngle = 90F;
            siticoneAdvancedPanel1.GradientEndColor = Color.FromArgb(128, 64, 0);
            siticoneAdvancedPanel1.GradientStartColor = Color.FromArgb(255, 224, 192);
            siticoneAdvancedPanel1.GradientType = SiticoneNetCoreUI.SiticoneAdvancedPanel.GradientTypeEx.Linear;
            siticoneAdvancedPanel1.HoverBackColor = Color.Empty;
            siticoneAdvancedPanel1.HoverBorderColor = Color.Empty;
            siticoneAdvancedPanel1.InnerShadowColor = Color.Black;
            siticoneAdvancedPanel1.InnerShadowDepth = 3;
            siticoneAdvancedPanel1.InnerShadowOpacity = 0.2F;
            siticoneAdvancedPanel1.Location = new Point(0, 0);
            siticoneAdvancedPanel1.Name = "siticoneAdvancedPanel1";
            siticoneAdvancedPanel1.Padding = new Padding(10);
            siticoneAdvancedPanel1.RadialGradientCenter = (PointF)resources.GetObject("siticoneAdvancedPanel1.RadialGradientCenter");
            siticoneAdvancedPanel1.RadialGradientRadius = 1F;
            siticoneAdvancedPanel1.ScaleRatio = 0.8F;
            siticoneAdvancedPanel1.SecondaryBorderColor = Color.DarkGray;
            siticoneAdvancedPanel1.ShadowBlur = 10;
            siticoneAdvancedPanel1.ShadowColor = Color.Black;
            siticoneAdvancedPanel1.ShadowDepth = 5;
            siticoneAdvancedPanel1.ShadowOffset = new Point(2, 2);
            siticoneAdvancedPanel1.ShadowOpacity = 0.3F;
            siticoneAdvancedPanel1.Size = new Size(257, 450);
            siticoneAdvancedPanel1.SlideDirection = new Point(0, -30);
            siticoneAdvancedPanel1.TabIndex = 17;
            siticoneAdvancedPanel1.TopLeftRadius = 5;
            siticoneAdvancedPanel1.TopRightRadius = 5;
            // 
            // siticoneLabel2
            // 
            siticoneLabel2.BackColor = Color.Transparent;
            siticoneLabel2.Font = new Font("Brush Script MT", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            siticoneLabel2.ForeColor = Color.White;
            siticoneLabel2.Location = new Point(0, 368);
            siticoneLabel2.Name = "siticoneLabel2";
            siticoneLabel2.Size = new Size(257, 82);
            siticoneLabel2.TabIndex = 3;
            siticoneLabel2.Text = "A room without books is like a body without a soul";
            siticoneLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneLabel1
            // 
            siticoneLabel1.BackColor = Color.Transparent;
            siticoneLabel1.Font = new Font("Castellar", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabel1.ForeColor = Color.FromArgb(255, 224, 192);
            siticoneLabel1.Location = new Point(0, 262);
            siticoneLabel1.Name = "siticoneLabel1";
            siticoneLabel1.Size = new Size(257, 58);
            siticoneLabel1.TabIndex = 2;
            siticoneLabel1.Text = "BOOK HUB";
            siticoneLabel1.TextAlign = ContentAlignment.MiddleCenter;
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
            siticonePictureBox1.Location = new Point(37, 74);
            siticonePictureBox1.MaintainAspectRatio = true;
            siticonePictureBox1.Name = "siticonePictureBox1";
            siticonePictureBox1.PlaceholderImage = null;
            siticonePictureBox1.RotationAngle = 0F;
            siticonePictureBox1.Saturation = 1F;
            siticonePictureBox1.ShowBorder = false;
            siticonePictureBox1.Size = new Size(195, 185);
            siticonePictureBox1.SizeMode = SiticoneNetCoreUI.SiticonePictureBoxSizeMode.StretchImage;
            siticonePictureBox1.TabIndex = 1;
            siticonePictureBox1.Text = "siticonePictureBox1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(592, 450);
            Controls.Add(panel1);
            Controls.Add(siticoneAdvancedPanel1);
            Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Red;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            siticoneAdvancedPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox txtboxUsernameStudent;
        private TextBox txtboxPasswordStudent;
        private PictureBox pictureBox3;
        private PictureBox pictureBox5;
        private Panel panel1;
        private PictureBox pictureBox2;
        private SiticoneNetCoreUI.SiticoneAdvancedPanel siticoneAdvancedPanel1;
        private SiticoneNetCoreUI.SiticonePictureBox siticonePictureBox1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel2;
        private SiticoneNetCoreUI.SiticoneButton btnSignup;
        private SiticoneNetCoreUI.SiticoneButton btnLogin;
        private SiticoneNetCoreUI.SiticoneLinkedLabel siticoneLinkedLabel1;
        private SiticoneNetCoreUI.SiticoneCloseButton siticoneCloseButton1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel3;
    }
}
