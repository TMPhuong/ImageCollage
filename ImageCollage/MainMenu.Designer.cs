namespace ImageCollage
{
    partial class MainMenu
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browseBtn = new System.Windows.Forms.Button();
            this.imageTxtBox = new System.Windows.Forms.TextBox();
            this.collageBtn = new System.Windows.Forms.Button();
            this.rBtnLandscape = new System.Windows.Forms.RadioButton();
            this.rBtnPortrait = new System.Windows.Forms.RadioButton();
            this.fillRatio = new System.Windows.Forms.NumericUpDown();
            this.orientRatio = new System.Windows.Forms.NumericUpDown();
            this.lbFillRatio = new System.Windows.Forms.Label();
            this.lbOrientRatio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fillRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orientRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(12, 12);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(99, 33);
            this.browseBtn.TabIndex = 0;
            this.browseBtn.Text = "Browse images";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // imageTxtBox
            // 
            this.imageTxtBox.Location = new System.Drawing.Point(12, 64);
            this.imageTxtBox.Multiline = true;
            this.imageTxtBox.Name = "imageTxtBox";
            this.imageTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.imageTxtBox.Size = new System.Drawing.Size(605, 149);
            this.imageTxtBox.TabIndex = 1;
            // 
            // collageBtn
            // 
            this.collageBtn.Location = new System.Drawing.Point(229, 321);
            this.collageBtn.Name = "collageBtn";
            this.collageBtn.Size = new System.Drawing.Size(150, 49);
            this.collageBtn.TabIndex = 2;
            this.collageBtn.Text = "Collage";
            this.collageBtn.UseVisualStyleBackColor = true;
            this.collageBtn.Click += new System.EventHandler(this.collageBtn_Click);
            // 
            // rBtnLandscape
            // 
            this.rBtnLandscape.AutoSize = true;
            this.rBtnLandscape.Location = new System.Drawing.Point(33, 252);
            this.rBtnLandscape.Name = "rBtnLandscape";
            this.rBtnLandscape.Size = new System.Drawing.Size(78, 17);
            this.rBtnLandscape.TabIndex = 3;
            this.rBtnLandscape.TabStop = true;
            this.rBtnLandscape.Text = "Landscape";
            this.rBtnLandscape.UseVisualStyleBackColor = true;
            this.rBtnLandscape.CheckedChanged += new System.EventHandler(this.rBtnLandscape_CheckedChanged);
            // 
            // rBtnPortrait
            // 
            this.rBtnPortrait.AutoSize = true;
            this.rBtnPortrait.Location = new System.Drawing.Point(195, 252);
            this.rBtnPortrait.Name = "rBtnPortrait";
            this.rBtnPortrait.Size = new System.Drawing.Size(58, 17);
            this.rBtnPortrait.TabIndex = 4;
            this.rBtnPortrait.Text = "Portrait";
            this.rBtnPortrait.UseVisualStyleBackColor = true;
            this.rBtnPortrait.CheckedChanged += new System.EventHandler(this.rBtnPortrait_CheckedChanged);
            // 
            // fillRatio
            // 
            this.fillRatio.Location = new System.Drawing.Point(527, 252);
            this.fillRatio.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.fillRatio.Name = "fillRatio";
            this.fillRatio.Size = new System.Drawing.Size(90, 20);
            this.fillRatio.TabIndex = 5;
            this.fillRatio.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // orientRatio
            // 
            this.orientRatio.Location = new System.Drawing.Point(527, 278);
            this.orientRatio.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.orientRatio.Name = "orientRatio";
            this.orientRatio.Size = new System.Drawing.Size(90, 20);
            this.orientRatio.TabIndex = 6;
            this.orientRatio.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lbFillRatio
            // 
            this.lbFillRatio.AutoSize = true;
            this.lbFillRatio.Location = new System.Drawing.Point(449, 254);
            this.lbFillRatio.Name = "lbFillRatio";
            this.lbFillRatio.Size = new System.Drawing.Size(72, 13);
            this.lbFillRatio.TabIndex = 7;
            this.lbFillRatio.Text = "Fill Area Ratio";
            // 
            // lbOrientRatio
            // 
            this.lbOrientRatio.AutoSize = true;
            this.lbOrientRatio.Location = new System.Drawing.Point(449, 280);
            this.lbOrientRatio.Name = "lbOrientRatio";
            this.lbOrientRatio.Size = new System.Drawing.Size(63, 13);
            this.lbOrientRatio.TabIndex = 8;
            this.lbOrientRatio.Text = "Orient Ratio";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 382);
            this.Controls.Add(this.lbOrientRatio);
            this.Controls.Add(this.lbFillRatio);
            this.Controls.Add(this.orientRatio);
            this.Controls.Add(this.fillRatio);
            this.Controls.Add(this.rBtnPortrait);
            this.Controls.Add(this.rBtnLandscape);
            this.Controls.Add(this.collageBtn);
            this.Controls.Add(this.imageTxtBox);
            this.Controls.Add(this.browseBtn);
            this.Name = "MainMenu";
            this.Text = "Image Collage";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fillRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orientRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox imageTxtBox;
        private System.Windows.Forms.Button collageBtn;
        private System.Windows.Forms.RadioButton rBtnLandscape;
        private System.Windows.Forms.RadioButton rBtnPortrait;
        private System.Windows.Forms.NumericUpDown fillRatio;
        private System.Windows.Forms.NumericUpDown orientRatio;
        private System.Windows.Forms.Label lbFillRatio;
        private System.Windows.Forms.Label lbOrientRatio;
    }
}

