namespace ImageCollage
{
    partial class Collage
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
            this.pgBarCollage = new System.Windows.Forms.ProgressBar();
            this.bgWorkerCollage = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pgBarCollage
            // 
            this.pgBarCollage.Location = new System.Drawing.Point(12, 42);
            this.pgBarCollage.Name = "pgBarCollage";
            this.pgBarCollage.Size = new System.Drawing.Size(529, 23);
            this.pgBarCollage.TabIndex = 0;
            // 
            // bgWorkerCollage
            // 
            this.bgWorkerCollage.WorkerReportsProgress = true;
            this.bgWorkerCollage.WorkerSupportsCancellation = true;
            this.bgWorkerCollage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerCollage_DoWork);
            this.bgWorkerCollage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerCollage_ProgressChanged);
            this.bgWorkerCollage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerCollage_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
            // 
            // Collage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 129);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pgBarCollage);
            this.Name = "Collage";
            this.Text = "Collaging images. Please wait ...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Result_FormClosed);
            this.ResumeLayout(false);

        }

        

        

        #endregion

        private System.Windows.Forms.ProgressBar pgBarCollage;
        private System.ComponentModel.BackgroundWorker bgWorkerCollage;
        private System.Windows.Forms.Button btnCancel;

    }
}