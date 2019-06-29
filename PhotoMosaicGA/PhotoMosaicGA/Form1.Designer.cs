namespace PhotoMosaicGA
{
    partial class Form1
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
            this.picBoxOG = new System.Windows.Forms.PictureBox();
            this.picBoxMosaic = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.btnMosaic = new System.Windows.Forms.Button();
            this.btnSpawn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMosaic)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxOG
            // 
            this.picBoxOG.Location = new System.Drawing.Point(12, 12);
            this.picBoxOG.Name = "picBoxOG";
            this.picBoxOG.Size = new System.Drawing.Size(640, 480);
            this.picBoxOG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxOG.TabIndex = 0;
            this.picBoxOG.TabStop = false;
            // 
            // picBoxMosaic
            // 
            this.picBoxMosaic.Location = new System.Drawing.Point(658, 12);
            this.picBoxMosaic.Name = "picBoxMosaic";
            this.picBoxMosaic.Size = new System.Drawing.Size(640, 480);
            this.picBoxMosaic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMosaic.TabIndex = 1;
            this.picBoxMosaic.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(12, 498);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(138, 23);
            this.btnSelectImage.TabIndex = 2;
            this.btnSelectImage.Text = "Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // btnMosaic
            // 
            this.btnMosaic.Location = new System.Drawing.Point(157, 497);
            this.btnMosaic.Name = "btnMosaic";
            this.btnMosaic.Size = new System.Drawing.Size(134, 23);
            this.btnMosaic.TabIndex = 3;
            this.btnMosaic.Text = "Mosaic This Bitch";
            this.btnMosaic.UseVisualStyleBackColor = true;
            this.btnMosaic.Click += new System.EventHandler(this.btnMosaic_Click);
            // 
            // btnSpawn
            // 
            this.btnSpawn.Location = new System.Drawing.Point(297, 497);
            this.btnSpawn.Name = "btnSpawn";
            this.btnSpawn.Size = new System.Drawing.Size(139, 23);
            this.btnSpawn.TabIndex = 4;
            this.btnSpawn.Text = "SpawnGA";
            this.btnSpawn.UseVisualStyleBackColor = true;
            this.btnSpawn.Click += new System.EventHandler(this.btnSpawn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(442, 497);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(825, 291);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 800);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSpawn);
            this.Controls.Add(this.btnMosaic);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.picBoxMosaic);
            this.Controls.Add(this.picBoxOG);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMosaic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxOG;
        private System.Windows.Forms.PictureBox picBoxMosaic;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnMosaic;
        private System.Windows.Forms.Button btnSpawn;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

