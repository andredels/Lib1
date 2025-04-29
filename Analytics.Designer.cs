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
            label1 = new Label();
            pictureBox2 = new PictureBox();
            cartesianChartBookRating = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1098, 125);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(164, 44);
            label1.Name = "label1";
            label1.Size = new Size(202, 41);
            label1.TabIndex = 3;
            label1.Text = "ADD A BOOK";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(17, 19);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(108, 83);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // cartesianChartBookRating
            // 
            cartesianChartBookRating.BackColor = Color.SandyBrown;
            cartesianChartBookRating.Location = new Point(26, 34);
            cartesianChartBookRating.MatchAxesScreenDataRatio = false;
            cartesianChartBookRating.Name = "cartesianChartBookRating";
            cartesianChartBookRating.Size = new Size(498, 435);
            cartesianChartBookRating.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(cartesianChartBookRating);
            panel2.Location = new Point(17, 149);
            panel2.Name = "panel2";
            panel2.Size = new Size(1059, 489);
            panel2.TabIndex = 3;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChartBookRating;
        private Panel panel2;
    }
}
