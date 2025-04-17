namespace Lib1
{
    partial class Addbook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addbook));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            comboBoxAddBookGenre = new ComboBox();
            label8 = new Label();
            txtbxAddBookISBN = new TextBox();
            label7 = new Label();
            btnCancelAddbook = new SiticoneNetCoreUI.SiticoneButton();
            siticonebtn_AddBookSave = new SiticoneNetCoreUI.SiticoneButton();
            txtbxAddBookQuantity = new TextBox();
            label6 = new Label();
            txtbxAddBookPublisher = new TextBox();
            txtbxAddBookPublicationYear = new TextBox();
            txtbxAddBookAuthorName = new TextBox();
            txtbxAddBookTitle = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(347, 509);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 224, 192);
            panel1.Controls.Add(comboBoxAddBookGenre);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtbxAddBookISBN);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(btnCancelAddbook);
            panel1.Controls.Add(siticonebtn_AddBookSave);
            panel1.Controls.Add(txtbxAddBookQuantity);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtbxAddBookPublisher);
            panel1.Controls.Add(txtbxAddBookPublicationYear);
            panel1.Controls.Add(txtbxAddBookAuthorName);
            panel1.Controls.Add(txtbxAddBookTitle);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(345, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(456, 426);
            panel1.TabIndex = 1;
            // 
            // comboBoxAddBookGenre
            // 
            comboBoxAddBookGenre.FormattingEnabled = true;
            comboBoxAddBookGenre.Location = new Point(201, 303);
            comboBoxAddBookGenre.Name = "comboBoxAddBookGenre";
            comboBoxAddBookGenre.Size = new Size(242, 28);
            comboBoxAddBookGenre.TabIndex = 17;
            comboBoxAddBookGenre.SelectedIndexChanged += comboBoxAddBookGenre_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(8, 303);
            label8.Name = "label8";
            label8.Size = new Size(108, 24);
            label8.TabIndex = 16;
            label8.Text = "Book Genre";
            // 
            // txtbxAddBookISBN
            // 
            txtbxAddBookISBN.Location = new Point(201, 256);
            txtbxAddBookISBN.Name = "txtbxAddBookISBN";
            txtbxAddBookISBN.Size = new Size(242, 27);
            txtbxAddBookISBN.TabIndex = 15;
            txtbxAddBookISBN.TextChanged += txtbxAddBookISBN_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(8, 256);
            label7.Name = "label7";
            label7.Size = new Size(95, 24);
            label7.TabIndex = 14;
            label7.Text = "Book ISBN";
            // 
            // btnCancelAddbook
            // 
            btnCancelAddbook.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnCancelAddbook.AccessibleName = "Cancel";
            btnCancelAddbook.AutoSizeBasedOnText = false;
            btnCancelAddbook.BackColor = Color.Transparent;
            btnCancelAddbook.BadgeBackColor = Color.Red;
            btnCancelAddbook.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnCancelAddbook.BadgeValue = 0;
            btnCancelAddbook.BadgeValueForeColor = Color.White;
            btnCancelAddbook.BorderColor = Color.Transparent;
            btnCancelAddbook.BorderWidth = 2;
            btnCancelAddbook.ButtonBackColor = Color.FromArgb(255, 128, 0);
            btnCancelAddbook.ButtonImage = null;
            btnCancelAddbook.CanBeep = true;
            btnCancelAddbook.CanGlow = false;
            btnCancelAddbook.CanShake = true;
            btnCancelAddbook.ContextMenuStripEx = null;
            btnCancelAddbook.CornerRadiusBottomLeft = 8;
            btnCancelAddbook.CornerRadiusBottomRight = 8;
            btnCancelAddbook.CornerRadiusTopLeft = 8;
            btnCancelAddbook.CornerRadiusTopRight = 8;
            btnCancelAddbook.CustomCursor = Cursors.Default;
            btnCancelAddbook.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnCancelAddbook.EnableLongPress = false;
            btnCancelAddbook.EnablePressAnimation = true;
            btnCancelAddbook.EnableRippleEffect = true;
            btnCancelAddbook.EnableShadow = false;
            btnCancelAddbook.EnableTextWrapping = false;
            btnCancelAddbook.Font = new Font("Segoe UI", 9F);
            btnCancelAddbook.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnCancelAddbook.GlowIntensity = 100;
            btnCancelAddbook.GlowRadius = 20F;
            btnCancelAddbook.GradientBackground = false;
            btnCancelAddbook.GradientColor = Color.FromArgb(114, 168, 255);
            btnCancelAddbook.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnCancelAddbook.HintText = null;
            btnCancelAddbook.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnCancelAddbook.HoverFontStyle = FontStyle.Regular;
            btnCancelAddbook.HoverTextColor = Color.White;
            btnCancelAddbook.HoverTransitionDuration = 250;
            btnCancelAddbook.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelAddbook.ImagePadding = 5;
            btnCancelAddbook.ImageSize = new Size(16, 16);
            btnCancelAddbook.IsRadial = false;
            btnCancelAddbook.IsReadOnly = false;
            btnCancelAddbook.IsToggleButton = false;
            btnCancelAddbook.IsToggled = false;
            btnCancelAddbook.Location = new Point(343, 376);
            btnCancelAddbook.LongPressDurationMS = 1000;
            btnCancelAddbook.Name = "btnCancelAddbook";
            btnCancelAddbook.NormalFontStyle = FontStyle.Regular;
            btnCancelAddbook.ParticleColor = Color.FromArgb(200, 200, 200);
            btnCancelAddbook.ParticleCount = 15;
            btnCancelAddbook.PressAnimationScale = 0.97F;
            btnCancelAddbook.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnCancelAddbook.PressedFontStyle = FontStyle.Regular;
            btnCancelAddbook.PressTransitionDuration = 150;
            btnCancelAddbook.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnCancelAddbook.RippleColor = Color.FromArgb(255, 255, 255);
            btnCancelAddbook.RippleOpacity = 0.3F;
            btnCancelAddbook.RippleRadiusMultiplier = 0.6F;
            btnCancelAddbook.ShadowBlur = 5;
            btnCancelAddbook.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnCancelAddbook.ShadowOffset = new Point(2, 2);
            btnCancelAddbook.ShakeDuration = 500;
            btnCancelAddbook.ShakeIntensity = 5;
            btnCancelAddbook.Size = new Size(100, 38);
            btnCancelAddbook.TabIndex = 13;
            btnCancelAddbook.Text = "Cancel";
            btnCancelAddbook.TextAlign = ContentAlignment.MiddleCenter;
            btnCancelAddbook.TextColor = Color.White;
            btnCancelAddbook.TooltipText = null;
            btnCancelAddbook.UseAdvancedRendering = true;
            btnCancelAddbook.UseParticles = false;
            btnCancelAddbook.Click += btnCancelAddbook_Click;
            // 
            // siticonebtn_AddBookSave
            // 
            siticonebtn_AddBookSave.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticonebtn_AddBookSave.AccessibleName = "Save";
            siticonebtn_AddBookSave.AutoSizeBasedOnText = false;
            siticonebtn_AddBookSave.BackColor = Color.Transparent;
            siticonebtn_AddBookSave.BadgeBackColor = Color.Red;
            siticonebtn_AddBookSave.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticonebtn_AddBookSave.BadgeValue = 0;
            siticonebtn_AddBookSave.BadgeValueForeColor = Color.White;
            siticonebtn_AddBookSave.BorderColor = Color.Transparent;
            siticonebtn_AddBookSave.BorderWidth = 2;
            siticonebtn_AddBookSave.ButtonBackColor = Color.FromArgb(255, 128, 0);
            siticonebtn_AddBookSave.ButtonImage = null;
            siticonebtn_AddBookSave.CanBeep = true;
            siticonebtn_AddBookSave.CanGlow = false;
            siticonebtn_AddBookSave.CanShake = true;
            siticonebtn_AddBookSave.ContextMenuStripEx = null;
            siticonebtn_AddBookSave.CornerRadiusBottomLeft = 8;
            siticonebtn_AddBookSave.CornerRadiusBottomRight = 8;
            siticonebtn_AddBookSave.CornerRadiusTopLeft = 8;
            siticonebtn_AddBookSave.CornerRadiusTopRight = 8;
            siticonebtn_AddBookSave.CustomCursor = Cursors.Default;
            siticonebtn_AddBookSave.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticonebtn_AddBookSave.EnableLongPress = false;
            siticonebtn_AddBookSave.EnablePressAnimation = true;
            siticonebtn_AddBookSave.EnableRippleEffect = true;
            siticonebtn_AddBookSave.EnableShadow = false;
            siticonebtn_AddBookSave.EnableTextWrapping = false;
            siticonebtn_AddBookSave.Font = new Font("Segoe UI", 9F);
            siticonebtn_AddBookSave.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticonebtn_AddBookSave.GlowIntensity = 100;
            siticonebtn_AddBookSave.GlowRadius = 20F;
            siticonebtn_AddBookSave.GradientBackground = false;
            siticonebtn_AddBookSave.GradientColor = Color.FromArgb(114, 168, 255);
            siticonebtn_AddBookSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticonebtn_AddBookSave.HintText = null;
            siticonebtn_AddBookSave.HoverBackColor = Color.FromArgb(114, 168, 255);
            siticonebtn_AddBookSave.HoverFontStyle = FontStyle.Regular;
            siticonebtn_AddBookSave.HoverTextColor = Color.White;
            siticonebtn_AddBookSave.HoverTransitionDuration = 250;
            siticonebtn_AddBookSave.ImageAlign = ContentAlignment.MiddleLeft;
            siticonebtn_AddBookSave.ImagePadding = 5;
            siticonebtn_AddBookSave.ImageSize = new Size(16, 16);
            siticonebtn_AddBookSave.IsRadial = false;
            siticonebtn_AddBookSave.IsReadOnly = false;
            siticonebtn_AddBookSave.IsToggleButton = false;
            siticonebtn_AddBookSave.IsToggled = false;
            siticonebtn_AddBookSave.Location = new Point(201, 376);
            siticonebtn_AddBookSave.LongPressDurationMS = 1000;
            siticonebtn_AddBookSave.Name = "siticonebtn_AddBookSave";
            siticonebtn_AddBookSave.NormalFontStyle = FontStyle.Regular;
            siticonebtn_AddBookSave.ParticleColor = Color.FromArgb(200, 200, 200);
            siticonebtn_AddBookSave.ParticleCount = 15;
            siticonebtn_AddBookSave.PressAnimationScale = 0.97F;
            siticonebtn_AddBookSave.PressedBackColor = Color.FromArgb(74, 128, 235);
            siticonebtn_AddBookSave.PressedFontStyle = FontStyle.Regular;
            siticonebtn_AddBookSave.PressTransitionDuration = 150;
            siticonebtn_AddBookSave.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticonebtn_AddBookSave.RippleColor = Color.FromArgb(255, 255, 255);
            siticonebtn_AddBookSave.RippleOpacity = 0.3F;
            siticonebtn_AddBookSave.RippleRadiusMultiplier = 0.6F;
            siticonebtn_AddBookSave.ShadowBlur = 5;
            siticonebtn_AddBookSave.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            siticonebtn_AddBookSave.ShadowOffset = new Point(2, 2);
            siticonebtn_AddBookSave.ShakeDuration = 500;
            siticonebtn_AddBookSave.ShakeIntensity = 5;
            siticonebtn_AddBookSave.Size = new Size(100, 38);
            siticonebtn_AddBookSave.TabIndex = 12;
            siticonebtn_AddBookSave.Text = "Save";
            siticonebtn_AddBookSave.TextAlign = ContentAlignment.MiddleCenter;
            siticonebtn_AddBookSave.TextColor = Color.White;
            siticonebtn_AddBookSave.TooltipText = null;
            siticonebtn_AddBookSave.UseAdvancedRendering = true;
            siticonebtn_AddBookSave.UseParticles = false;
            siticonebtn_AddBookSave.Click += siticonebtn_AddBookSave_Click;
            // 
            // txtbxAddBookQuantity
            // 
            txtbxAddBookQuantity.Location = new Point(201, 211);
            txtbxAddBookQuantity.Name = "txtbxAddBookQuantity";
            txtbxAddBookQuantity.Size = new Size(242, 27);
            txtbxAddBookQuantity.TabIndex = 9;
            txtbxAddBookQuantity.TextChanged += txtbxAddBookQuantity_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(8, 211);
            label6.Name = "label6";
            label6.Size = new Size(129, 24);
            label6.TabIndex = 8;
            label6.Text = "Book Quantity";
            // 
            // txtbxAddBookPublisher
            // 
            txtbxAddBookPublisher.Location = new Point(201, 161);
            txtbxAddBookPublisher.Name = "txtbxAddBookPublisher";
            txtbxAddBookPublisher.Size = new Size(242, 27);
            txtbxAddBookPublisher.TabIndex = 7;
            txtbxAddBookPublisher.TextChanged += txtbxAddBookPublisher_TextChanged;
            // 
            // txtbxAddBookPublicationYear
            // 
            txtbxAddBookPublicationYear.Location = new Point(201, 115);
            txtbxAddBookPublicationYear.Name = "txtbxAddBookPublicationYear";
            txtbxAddBookPublicationYear.Size = new Size(242, 27);
            txtbxAddBookPublicationYear.TabIndex = 6;
            txtbxAddBookPublicationYear.TextChanged += txtbxAddBookPublicationYear_TextChanged;
            // 
            // txtbxAddBookAuthorName
            // 
            txtbxAddBookAuthorName.Location = new Point(201, 66);
            txtbxAddBookAuthorName.Name = "txtbxAddBookAuthorName";
            txtbxAddBookAuthorName.Size = new Size(242, 27);
            txtbxAddBookAuthorName.TabIndex = 5;
            txtbxAddBookAuthorName.TextChanged += txtbxAddBookAuthorName_TextChanged;
            // 
            // txtbxAddBookTitle
            // 
            txtbxAddBookTitle.Location = new Point(201, 23);
            txtbxAddBookTitle.Name = "txtbxAddBookTitle";
            txtbxAddBookTitle.Size = new Size(242, 27);
            txtbxAddBookTitle.TabIndex = 4;
            txtbxAddBookTitle.TextChanged += txtbxAddBookTitle_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(8, 161);
            label5.Name = "label5";
            label5.Size = new Size(135, 24);
            label5.TabIndex = 3;
            label5.Text = "Book Publisher";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(8, 115);
            label4.Name = "label4";
            label4.Size = new Size(191, 24);
            label4.TabIndex = 2;
            label4.Text = "Book Publication Year";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 66);
            label3.Name = "label3";
            label3.Size = new Size(170, 24);
            label3.TabIndex = 1;
            label3.Text = "Book Author Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 23);
            label2.Name = "label2";
            label2.Size = new Size(94, 24);
            label2.TabIndex = 0;
            label2.Text = "Book Title";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(345, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(108, 83);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(459, 26);
            label1.Name = "label1";
            label1.Size = new Size(173, 41);
            label1.TabIndex = 1;
            label1.Text = "ADD BOOK";
            // 
            // Addbook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(800, 509);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Addbook";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Addbook";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtbxAddBookQuantity;
        private Label label6;
        private TextBox txtbxAddBookPublisher;
        private TextBox txtbxAddBookPublicationYear;
        private TextBox txtbxAddBookAuthorName;
        private TextBox txtbxAddBookTitle;
        private SiticoneNetCoreUI.SiticoneButton siticonebtn_AddBookSave;
        private SiticoneNetCoreUI.SiticoneButton siticoneButton2;
        private SiticoneNetCoreUI.SiticoneButton btnCancelAddbook;
        private TextBox txtbxAddBookISBN;
        private Label label7;
        private Label label8;
        private ComboBox comboBoxAddBookGenre;
    }
}