using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DataTool
{
    public partial class OutPutForm : Form
    {
        public OutPutForm()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string formatString = "GB2312";
            if(!cmb_OutPutFormat.Text.Trim().Equals(""))
            {
                formatString = this.cmb_OutPutFormat.Text.Trim();
            }
            SaveFileDialog toFile = new SaveFileDialog();
            toFile.Filter = "SQLScript(*.sql)|*.sql|TextFile(*.txt)|*.txt";

            DialogResult result = new DialogResult();
            result = toFile.ShowDialog();
            if (result == DialogResult.OK && !toFile.FileName.Equals(""))
            {
                FileStream fs = new FileStream(toFile.FileName, FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(fs,Encoding.GetEncoding(formatString));
                writer.Write(this.rich_Result.Text);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }

        private void OutPutForm_Load(object sender, EventArgs e)
        {
            this.cmb_OutPutFormat.SelectedIndex = 0;
        }
    }
}
