using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arhivator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }
        string sourcePath;
        string destPath;
        Zip zipper;

        private void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                sourcePath = ofd.FileName;
                tbSourceFilePath.Text = sourcePath;
            }
        }

        private void btnSelectDestFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                destPath = ofd.FileName;
                tbDestFilePath.Text = destPath;
            }
        }
        public ProgressBar Progress
        {
            get 
            {
                return this.progressBar;
            }
            set
            {
                this.progressBar = value;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string state = rbCompress.Checked == true ? "compress" : "decompress";
            string[] args = new string[3];
            try
            {
                args = new string[3];
                args[0] = state;
                args[1] = sourcePath;
                args[2] = destPath;

                Validation.StringReadValidation(args);

                switch (args[0].ToLower())
                {
                    case "compress":
                        zipper = new Compressor(this, args[1], args[2]);
                        break;
                    case "decompress":
                        zipper = new Decompressor(this, args[1], args[2]);
                        break;
                }

                zipper.Launch();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error is occured!\n Method: {ex.TargetSite}\n Error description {ex.Message}");
            }
        }

        private void ShowInfo()
        {
            MessageBox.Show("To zip or unzip files please proceed with the following pattern to type in:\n" +
                              "Zipping: GZipTest.exe compress [Source file path] [Destination file path]\n" +
                              "Unzipping: GZipTest.exe decompress [Compressed file path] [Destination file path]\n");
        }

        private void tbSourceFilePath_TextChanged(object sender, EventArgs e)
        {
            sourcePath = tbSourceFilePath.Text;
        }

        private void tbDestFilePath_TextChanged(object sender, EventArgs e)
        {
            destPath = tbDestFilePath.Text;
        }
    }
}
