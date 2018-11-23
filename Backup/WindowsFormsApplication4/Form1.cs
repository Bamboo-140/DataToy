using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataTool
{
    public partial class MainForm : Form
    {
        public string _myConnectionString = "";
        int _rowCount = 1;

        public MainForm()
        {
            InitializeComponent();
        }
        List<string> databaseList = new List<string>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            using (LoginDatabase login = new LoginDatabase(_myConnectionString))
            {
                login.ShowDialog();
                _myConnectionString = login.IConnectionString;
            }
            string getDatabaseName = "SELECT Name FROM Master..SysDatabases";
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(_myConnectionString))
                {
                    conn.Open();
                    using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(getDatabaseName, conn))
                    {
                        using (System.Data.SqlClient.SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    databaseList.Add(dr["name"].ToString());
                                }
                            }
                        }
                    }
                }
                this.cmb_CurrentDatabase.Items.AddRange(databaseList.ToArray());
                this.cmb_SourceDatabase.Items.AddRange(databaseList.ToArray());
            }
            catch { }
        }



        private void btn_Fix_Click(object sender, EventArgs e)
        {  //数据集不为空
            if(this.xsD_ResultDisplay1.result.Rows.Count <= 0)
            {
                return;
            }
            //遍历数据集
            //判断数据表是否存在
            //如果存在修改 不存在创建
            int _progress = 0;
            using (SqlConnection conn = new SqlConnection(_myConnectionString))
            {
                conn.Open();
                StringBuilder sqlCommand = new StringBuilder();
                foreach (DataRow dr in this.xsD_ResultDisplay1.result.Rows)
                {                    
                    if (!Existsed(dr["tablename"].ToString()))
                    {
                        sqlCommand.AppendFormat("use {3} ; create table {0} ( [{1}]  {2} )", dr[0], dr[1], dr[2],this.cmb_CurrentDatabase.Text);
                    }
                    else
                    {
                        sqlCommand.AppendFormat("use {3} ; alter table {0} add [{1}]  {2}", dr[0], dr[1], dr[2],this.cmb_CurrentDatabase.Text);
                    }
                    using(SqlCommand command = new SqlCommand (sqlCommand .ToString(),conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    sqlCommand.Remove(0, sqlCommand.Length);
                    //++_progress;                    
                    
                    this.pgs_Detail .Value =(++_progress);
                    this.label5.Text = ((_progress / _rowCount) * 100).ToString() + "%";
                }
               
                if (_progress == _rowCount)
                {
                    MessageBox.Show("修复完成！");
                }
            }

        }
                private bool Existsed(string obj)
                {
                    bool exists = true ;
                    using (SqlConnection conn = new SqlConnection(_myConnectionString))
                    {
                        conn.Open();
                        string sql = "use "+this.cmb_CurrentDatabase .Text +"; select id from sysobjects where name = '"+obj+"'";
                        using(SqlCommand command = new SqlCommand (sql,conn))
                        {
                            if (command.ExecuteScalar() == null)
                            {
                                exists = false;
                            }
                        }
                    }
                    return exists;
                }

        private void btn_Seach_Click(object sender, EventArgs e)
        {
            this.xsD_ResultDisplay1.Clear();
            if (this.cmb_CurrentDatabase.Text.Equals("") || this.cmb_SourceDatabase.Text.Equals(""))
            {
                MessageBox.Show("请选择要处理的数据库！","System.Message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.cmb_CurrentDatabase.Focus();
                return;
            }
            StringBuilder sqlBuilder = new StringBuilder();
            try
            {

                sqlBuilder.AppendFormat(" USE {0};", this.cmb_CurrentDatabase.Text);
                sqlBuilder.Append("      /*缺失表数据库   插入临时表#temp0*/");
                sqlBuilder.Append(" ");
                sqlBuilder.Append(" SELECT");
                sqlBuilder.Append("     a.name AS TableName ,");
                sqlBuilder.Append("     b.name AS ColumnName ,");
                sqlBuilder.Append("     c.name AS DataType ,");
                sqlBuilder.Append("     b.prec AS Length");
                sqlBuilder.Append(" INTO");
                sqlBuilder.Append("     #temp0");
                sqlBuilder.Append(" FROM");
                sqlBuilder.Append("     sysobjects a");
                sqlBuilder.Append(" INNER JOIN syscolumns b ON a.id = b.id");
                sqlBuilder.Append(" INNER JOIN systypes c ON c.xtype = b.xtype");
                sqlBuilder.Append(" WHERE");
                sqlBuilder.Append("     a.xtype = 'U'");
                sqlBuilder.Append("     AND c.name != 'sysname';");
                sqlBuilder.Append(" ");

                sqlBuilder.AppendFormat(" USE {0};", this.cmb_SourceDatabase.Text);
                sqlBuilder.Append("     /*对照表数据库   插入临时表#temp1*/");

                sqlBuilder.Append("  ");
                sqlBuilder.Append(" SELECT");
                sqlBuilder.Append("     a.name AS TableName ,");
                sqlBuilder.Append("     b.name AS ColumnName ,");
                sqlBuilder.Append("     c.name AS DataType ,");
                sqlBuilder.Append("     b.prec AS Length");
                sqlBuilder.Append(" INTO");
                sqlBuilder.Append("     #temp1");
                sqlBuilder.Append(" FROM");
                sqlBuilder.Append("     sysobjects a");
                sqlBuilder.Append(" INNER JOIN syscolumns b ON a.id = b.id");
                sqlBuilder.Append(" INNER JOIN systypes c ON c.xtype = b.xtype");
                sqlBuilder.Append(" WHERE");
                sqlBuilder.Append("     a.xtype = 'U'");
                sqlBuilder.Append("     AND c.name != 'sysname';");
                sqlBuilder.Append("  ");
                sqlBuilder.Append(" /*查找缺失表字段及数据类型   插入临时表#temp2（大集合中找不在小集合中的内容）*/");
                sqlBuilder.Append(" SELECT");
                sqlBuilder.Append("     tablename ,");
                sqlBuilder.Append("     columnname ,");
                sqlBuilder.Append("     CASE datatype");
                sqlBuilder.Append("       WHEN 'varchar' THEN 'varchar(' + CONVERT(VARCHAR(50), length) + ')'");
                sqlBuilder.Append("       WHEN 'decimal' THEN 'decimal(18,6)'       /**/");
                sqlBuilder.Append("       WHEN 'char' THEN 'char(' + CONVERT(VARCHAR(50), length) + ')'");
                sqlBuilder.Append("       WHEN 'nvarchar' THEN 'nvarchar(' + CONVERT(VARCHAR(50), length) + ')'");
                sqlBuilder.Append("       WHEN 'binary' THEN 'binary(' + CONVERT(VARCHAR(50), length) + ')'");
                sqlBuilder.Append("       WHEN 'varbinary' THEN 'varbinary(' + CONVERT(VARCHAR(50), length) + ')'");
                sqlBuilder.Append("       ELSE datatype");
                sqlBuilder.Append("     END AS datatype");
                sqlBuilder.Append(" INTO");
                sqlBuilder.Append("     #temp2");
                sqlBuilder.Append(" FROM");
                sqlBuilder.Append("     #temp1 a");
                sqlBuilder.Append(" WHERE");
                sqlBuilder.Append("     NOT EXISTS ( SELECT");
                sqlBuilder.Append("                     *");
                sqlBuilder.Append("                  FROM");
                sqlBuilder.Append("                     #temp0");
                sqlBuilder.Append("                  WHERE");
                sqlBuilder.Append("                     tablename = a.tablename );");
                sqlBuilder.Append("    /* AND datatype != 'sysname';*/");
                sqlBuilder.Append(" ");
                sqlBuilder.Append(" SELECT * from #temp2  ");
                //sqlBuilder.AppendFormat(" USE {0};", this.cmb_CurrentDatabase.Text);
                using (SqlConnection conn = new SqlConnection( _myConnectionString))
                { 
                    conn.Open();                    
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlBuilder.ToString(), conn))
                    {
                        _rowCount = dataAdapter.Fill(this.xsD_ResultDisplay1.Tables["result"]);
                    }
                    string sql = "drop table #temp2;drop table #temp1;drop table #temp0;";
                    using (SqlCommand dropTable = new SqlCommand(sql, conn))
                    {
                        dropTable.ExecuteNonQuery();
                    }
                }
                this.label4.Text = "共计 '"+_rowCount.ToString() + "' 条记录。";
                this.pgs_Detail.Maximum = _rowCount;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if()
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

    }
}
