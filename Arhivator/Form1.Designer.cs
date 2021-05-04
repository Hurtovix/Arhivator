
namespace Arhivator
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
            this.btnSelectSourceFile = new System.Windows.Forms.Button();
            this.btnSelectDestFile = new System.Windows.Forms.Button();
            this.tbSourceFilePath = new System.Windows.Forms.TextBox();
            this.tbDestFilePath = new System.Windows.Forms.TextBox();
            this.rbCompress = new System.Windows.Forms.RadioButton();
            this.rbDecompress = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnSelectSourceFile
            // 
            this.btnSelectSourceFile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSelectSourceFile.Location = new System.Drawing.Point(29, 31);
            this.btnSelectSourceFile.Name = "btnSelectSourceFile";
            this.btnSelectSourceFile.Size = new System.Drawing.Size(162, 40);
            this.btnSelectSourceFile.TabIndex = 0;
            this.btnSelectSourceFile.Text = "Select source file";
            this.btnSelectSourceFile.UseVisualStyleBackColor = false;
            this.btnSelectSourceFile.Click += new System.EventHandler(this.btnSelectSourceFile_Click);
            // 
            // btnSelectDestFile
            // 
            this.btnSelectDestFile.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSelectDestFile.Location = new System.Drawing.Point(29, 93);
            this.btnSelectDestFile.Name = "btnSelectDestFile";
            this.btnSelectDestFile.Size = new System.Drawing.Size(162, 40);
            this.btnSelectDestFile.TabIndex = 1;
            this.btnSelectDestFile.Text = "Select destination file";
            this.btnSelectDestFile.UseVisualStyleBackColor = false;
            this.btnSelectDestFile.Click += new System.EventHandler(this.btnSelectDestFile_Click);
            // 
            // tbSourceFilePath
            // 
            this.tbSourceFilePath.Location = new System.Drawing.Point(197, 40);
            this.tbSourceFilePath.Name = "tbSourceFilePath";
            this.tbSourceFilePath.Size = new System.Drawing.Size(301, 22);
            this.tbSourceFilePath.TabIndex = 2;
            this.tbSourceFilePath.TextChanged += new System.EventHandler(this.tbSourceFilePath_TextChanged);
            // 
            // tbDestFilePath
            // 
            this.tbDestFilePath.Location = new System.Drawing.Point(197, 102);
            this.tbDestFilePath.Name = "tbDestFilePath";
            this.tbDestFilePath.Size = new System.Drawing.Size(301, 22);
            this.tbDestFilePath.TabIndex = 3;
            this.tbDestFilePath.TextChanged += new System.EventHandler(this.tbDestFilePath_TextChanged);
            // 
            // rbCompress
            // 
            this.rbCompress.AutoSize = true;
            this.rbCompress.Checked = true;
            this.rbCompress.Location = new System.Drawing.Point(217, 175);
            this.rbCompress.Name = "rbCompress";
            this.rbCompress.Size = new System.Drawing.Size(90, 21);
            this.rbCompress.TabIndex = 4;
            this.rbCompress.TabStop = true;
            this.rbCompress.Text = "compress";
            this.rbCompress.UseVisualStyleBackColor = true;
            // 
            // rbDecompress
            // 
            this.rbDecompress.AutoSize = true;
            this.rbDecompress.Location = new System.Drawing.Point(217, 216);
            this.rbDecompress.Name = "rbDecompress";
            this.rbDecompress.Size = new System.Drawing.Size(106, 21);
            this.rbDecompress.TabIndex = 5;
            this.rbDecompress.Text = "decompress";
            this.rbDecompress.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Location = new System.Drawing.Point(197, 258);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 42);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 336);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(469, 43);
            this.progressBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rbDecompress);
            this.Controls.Add(this.rbCompress);
            this.Controls.Add(this.tbDestFilePath);
            this.Controls.Add(this.tbSourceFilePath);
            this.Controls.Add(this.btnSelectDestFile);
            this.Controls.Add(this.btnSelectSourceFile);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arhivator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectSourceFile;
        private System.Windows.Forms.Button btnSelectDestFile;
        private System.Windows.Forms.TextBox tbSourceFilePath;
        private System.Windows.Forms.TextBox tbDestFilePath;
        private System.Windows.Forms.RadioButton rbCompress;
        private System.Windows.Forms.RadioButton rbDecompress;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

