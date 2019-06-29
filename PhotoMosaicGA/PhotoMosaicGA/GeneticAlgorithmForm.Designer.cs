namespace PhotoMosaicGA
{
    partial class GeneticAlgorithmForm
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
            this.btnRunGA = new System.Windows.Forms.Button();
            this.redStats = new System.Windows.Forms.RichTextBox();
            this.pixBestMosaic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.picColors = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pixBestMosaic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunGA
            // 
            this.btnRunGA.Location = new System.Drawing.Point(829, 428);
            this.btnRunGA.Name = "btnRunGA";
            this.btnRunGA.Size = new System.Drawing.Size(400, 132);
            this.btnRunGA.TabIndex = 0;
            this.btnRunGA.Text = "run GA";
            this.btnRunGA.UseVisualStyleBackColor = true;
            this.btnRunGA.Click += new System.EventHandler(this.btnRunGA_Click);
            // 
            // redStats
            // 
            this.redStats.Location = new System.Drawing.Point(12, 12);
            this.redStats.Name = "redStats";
            this.redStats.Size = new System.Drawing.Size(806, 142);
            this.redStats.TabIndex = 2;
            this.redStats.Text = "";
            // 
            // pixBestMosaic
            // 
            this.pixBestMosaic.Location = new System.Drawing.Point(12, 160);
            this.pixBestMosaic.Name = "pixBestMosaic";
            this.pixBestMosaic.Size = new System.Drawing.Size(400, 400);
            this.pixBestMosaic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixBestMosaic.TabIndex = 3;
            this.pixBestMosaic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(829, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // picColors
            // 
            this.picColors.Location = new System.Drawing.Point(418, 160);
            this.picColors.Name = "picColors";
            this.picColors.Size = new System.Drawing.Size(400, 400);
            this.picColors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picColors.TabIndex = 5;
            this.picColors.TabStop = false;
            // 
            // GeneticAlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 577);
            this.Controls.Add(this.picColors);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pixBestMosaic);
            this.Controls.Add(this.redStats);
            this.Controls.Add(this.btnRunGA);
            this.Name = "GeneticAlgorithmForm";
            this.Text = "GeneticAlgorithmForm";
            ((System.ComponentModel.ISupportInitialize)(this.pixBestMosaic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunGA;
        private System.Windows.Forms.RichTextBox redStats;
        private System.Windows.Forms.PictureBox pixBestMosaic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox picColors;
    }
}