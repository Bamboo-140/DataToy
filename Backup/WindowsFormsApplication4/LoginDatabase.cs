using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataTool
{
    public partial class LoginDatabase : Form
    {
        public string IConnectionString = string.Empty;
        private bool logined = false;
        public LoginDatabase(string str)
        {
            InitializeComponent();
            str = this.IConnectionString;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            logined = false;
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            IConnectionString = string.Format ( "Data Source = {0} ; Initial Catalog = master ;User ID = {1}; Password = {2} ",this.txt_SQLServer.Text,this.txt_UserID.Text,this.mask_Password.Text);
            try
            {
                using (SqlConnection conn = new SqlConnection(IConnectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        logined = true;
                        conn.Close();
                    }
                }
                if (logined)
                {
                    this.Hide();
                }
            }
            catch(Exception error)
            {
                logined = false;
                MessageBox.Show(error.Message ,"提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void LoginDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!logined)
            {
                Application.Exit();
            }
        }
    }
}
