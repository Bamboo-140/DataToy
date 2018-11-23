using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace DataTool
{
    public partial class LoginDatabase : Form
    {
        #region 全局变量
        public string _connectionString = string.Empty;
        public string _userName = string.Empty;
        public string _server = string.Empty;
        #endregion
        private bool logined = false;
        public LoginDatabase(string str)
        {
            InitializeComponent();
            str = this._connectionString;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            logined = false;
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            _connectionString = string.Format ( "Data Source = {0} ; Initial Catalog = master ;User ID = {1}; Password = {2} ",this.cmb_Server.Text,this.txt_UserID.Text,this.mask_Password.Text);
            
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
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
            _userName = this.txt_UserID.Text;
            _server = cmb_Server.Text.Trim().Equals(".") ? "localhost" : cmb_Server.Text.Trim(); ;
        }

        private void LoginDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!logined)
            {
                Application.Exit();
            }
        }

        private void LoginDatabase_Load(object sender, EventArgs e)
        {
            //RegistryKey key = Registry.GetValue("");
            LoadData loading = new LoadData();
            loading.Show();
            Application.DoEvents();
            DataTable dataSources = SqlClientFactory.Instance.CreateDataSourceEnumerator().GetDataSources();
            int count = dataSources.Rows.Count;
            List<string> server = new List<string>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    DataRow dr = dataSources.Rows[i];
                    if (!String.IsNullOrEmpty(dr["InstanceName"].ToString().Trim()))
                    {
                        server.Add(dr["ServerName"].ToString().Trim() + "\\" + dr["InstanceName"].ToString().Trim());
                    }
                    else
                    {
                        server.Add(dr["ServerName"].ToString().Trim());
                    }
                }
            }
            loading.Close();
            this.cmb_Server.Items.Clear();
            this.cmb_Server.Items.AddRange(server.ToArray());
            
        }
    }
}
