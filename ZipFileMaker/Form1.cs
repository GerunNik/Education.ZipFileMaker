using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZipFileMaker
{
    public partial class Form1 : Form
    {
        List<string> FileList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog searchDialog = new OpenFileDialog();

            searchDialog.RestoreDirectory = true;
            searchDialog.Multiselect = true;
            searchDialog.Title = "Please Select Files for Zip Conversion";

            if (searchDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in searchDialog.FileNames)
                {
                    FileList.Add(file);
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveDialog = new FolderBrowserDialog();
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveDialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZipArchive zip = ZipFile.Open(textBox2.Text + "\\" + name_txt.Text + ".zip", ZipArchiveMode.Create);
            foreach (string file in FileList)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            zip.Dispose();
        }
    }
}
