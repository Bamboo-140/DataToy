using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace DataTool
{
    public partial class MainForm : Form
    {
        public string _myConnectionString = "";
        int _rowCount = 1;
        public string _user = string.Empty;
        public string _server = string.Empty;

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
                _myConnectionString = login._connectionString;
                _user = login._userName;
                _server = login._server;
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
                this.toolScriptUser.Text = "用户: " + _user;
                this.Text = this.Text + "[" + _server + "] - DataToy";
            }
            catch { }
        }



        private void btn_Fix_Click(object sender, EventArgs e)
        {
            FixIt(true);
        }
        public void FixIt1()
        {
            //数据集不为空
            if (this.xsD_ResultDisplay1.result.Rows.Count <= 0)
            {
                return;
            }
            //遍历数据集
            //判断数据表是否存在
            //如果存在修改 不存在创建   
            int _progress = 0;
            Stopwatch time = new Stopwatch();

            this.toolScript_Progress.Visible = true;       //使进度条显示出来
            this.toolStripStateInfor.Text = "事务执行中...";
            this.toolScriptTime.Text = "";
            Application.DoEvents();

            time.Start();

            //Application.DoEvents();

            StringBuilder sqlCommand = new StringBuilder();
            int RowCounts = this.xsD_ResultDisplay1.result.Rows.Count;
            object tableName = "";
            for (int i = 0; i < RowCounts; ++i)
            {
                bool alt = true;
                bool exe = true;
                if (Convert.ToBoolean(xsD_ResultDisplay1.result[i]["Choose"]))
                {
                    //如果当前表不存在,且程序未创建该表
                    if (!Existsed(xsD_ResultDisplay1.result[i]["tablename"].ToString()) && !tableName.Equals(xsD_ResultDisplay1.result[i]["tablename"]))
                    {
                        tableName = xsD_ResultDisplay1.result[i]["tablename"];
                        //sqlCommand.AppendFormat("use [{3}] ; create table [{0}] ( [{1}]  {2} )", dr[0], dr[1], dr[2], this.cmb_CurrentDatabase.Text);
                        sqlCommand.AppendFormat("USE [{3}]; CREATE TABLE [{0}] ( [{1}]  {2} )", xsD_ResultDisplay1.result[i]["tablename"], xsD_ResultDisplay1.result[i]["columnname"], xsD_ResultDisplay1.result[i]["datatype"], this.cmb_CurrentDatabase.Text);
                        alt = true;
                    }
                    else if (alt)
                    {
                        //sqlCommand.AppendFormat("use [{3}] ; alter table [{0}] add [{1}]  {2}", dr[0], dr[1], dr[2], this.cmb_CurrentDatabase.Text);
                        sqlCommand.AppendFormat("USE [{3}]; ALTER TABLE [{0}] ADD [{1}]  {2}", xsD_ResultDisplay1.result[i]["tablename"], xsD_ResultDisplay1.result[i]["columnname"], xsD_ResultDisplay1.result[i]["datatype"], this.cmb_CurrentDatabase.Text);
                        alt = false;
                    }
                    else
                    {
                        sqlCommand.AppendFormat(", [{0}] {1} ", xsD_ResultDisplay1.result[i]["columnname"], xsD_ResultDisplay1.result[i]["datatype"]);
                    }


                    sqlCommand.Remove(0, sqlCommand.Length);
                    //++_progress;                    

                    // this.pgs_Detail .Value =(++_progress);
                    //this.toolScriptInfo.Text ="已修复"+ ((this.pgs_Detail.Value / _rowCount) * 100).ToString() + "%";
                    this.toolScript_Progress.Value = (++_progress);         //更新进度信息                           
                }

            }

            time.Stop();
            if (_progress == _rowCount)
            {
                //MessageBox.Show("修复完成！");
                this.toolStripStateInfor.Text = "就绪";
                //this.toolScriptUser.Text = "修复完成"+_progress.ToString()+"条";                    
                this.toolScriptTime.Text = time.Elapsed.ToString();      //将执行时间显示出来
                this.toolScript_Progress.Visible = false;
            }
        }

        private int Execute(StringBuilder sql)
        {
            int times = 0;
            using (SqlConnection conn = new SqlConnection(_myConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql.ToString(), conn))
                {
                    times += command.ExecuteNonQuery();
                }
            }
            return times;
        }
        public StringBuilder FixIt(bool fix)
        {
            StringBuilder sqlCommand = new StringBuilder();
            //数据集不为空
            if (this.xsD_ResultDisplay1.result.Rows.Count <= 0)
            {
                sqlCommand.AppendFormat("");
                return sqlCommand;
            }
            sqlCommand.AppendFormat("USE[{0}]", this.cmb_CurrentDatabase.Text);
            //遍历数据集
            //判断数据表是否存在
            //如果存在修改 不存在创建   
            int _progress = 0;
            Stopwatch time = new Stopwatch();

            this.toolScript_Progress.Visible = true;       //使进度条显示出来
            this.toolStripStateInfor.Text = "事务执行中...";
            this.toolScriptTime.Text = "";
            Application.DoEvents();
            time.Start();
            //Application.DoEvents();
            object tempName = null;
            bool sw = true;
            //int i = 1;
            foreach (DataRow dr in this.xsD_ResultDisplay1.result.Rows)
            {
                if (Convert.ToBoolean(dr["Choose"]))
                {
                    if (!Existsed(dr["tablename"].ToString()) && !dr["tablename"].Equals(tempName))
                    {
                        tempName = dr["tablename"];
                        sw = true;
                        sqlCommand.Append("\r\n GO \r\n");
                        //sqlCommand.AppendFormat("use [{3}] ; create table [{0}] ( [{1}]  {2} ) ;\r\n", dr[0], dr[1], dr[2], this.cmb_CurrentDatabase.Text);
                        sqlCommand.AppendFormat("CREATE TABLE [{0}] ( [{1}]  {2} )", dr["tablename"], dr["columnname"], dr["datatype"]);
                    }
                    else if (sw)
                    {
                        sqlCommand.Append("\r\n GO \r\n");
                        //sqlCommand.AppendFormat("use [{3}] ; alter table [{0}] add [{1}]  {2} ;\r\n", dr[0], dr[1], dr[2], this.cmb_CurrentDatabase.Text);
                        sqlCommand.AppendFormat("ALTER TABLE [{0}] ADD [{1}]  {2} ", dr["tablename"], dr["columnname"], dr["datatype"]);
                        sw = false;
                    }
                    else
                    {
                        if (!dr["tablename"].Equals(tempName))  //如果当前字段不属于这个表则重新alter一下
                        {
                            sqlCommand.Append("\r\n GO \r\n");
                            sqlCommand.AppendFormat("ALTER TABLE [{0}] ADD [{1}]  {2} ", dr["tablename"], dr["columnname"], dr["datatype"]);
                            tempName = dr["tablename"].ToString().Trim();
                        }
                        else
                        {
                            sqlCommand.AppendFormat(",[{0}]  {1} ", dr["columnname"], dr["datatype"]);
                        }
                    }
                    //++_progress;                    

                    // this.pgs_Detail .Value =(++_progress);
                    //this.toolScriptInfo.Text ="已修复"+ ((this.pgs_Detail.Value / _rowCount) * 100).ToString() + "%";
                    toolScript_Progress.Value = (++_progress);         //更新进度信息                           
                }
            }
            if (fix)
            {
                using (SqlConnection conn = new SqlConnection(_myConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sqlCommand.ToString(), conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            time.Stop();
            if (_progress == this.toolScript_Progress.Maximum)
            {
                //MessageBox.Show("修复完成！");
                this.toolStripStateInfor.Text = "就绪";
                //this.toolScriptUser.Text = "修复完成"+_progress.ToString()+"条";                    
                this.toolScriptTime.Text = time.Elapsed.ToString();      //将执行时间显示出来
                this.toolScript_Progress.Visible = false;
            }
            return sqlCommand;
        }


        private bool Existsed(string obj)
        {
            bool exists = true;
            using (SqlConnection conn = new SqlConnection(_myConnectionString))
            {
                conn.Open();
                string sql = "use [" + this.cmb_CurrentDatabase.Text + "]; select id from sysobjects where name = '" + obj + "'";
                using (SqlCommand command = new SqlCommand(sql, conn))
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

            Stopwatch time1 = new Stopwatch();

            if (this.cmb_CurrentDatabase.Text.Equals("") || this.cmb_SourceDatabase.Text.Equals(""))
            {
                MessageBox.Show("请选择要处理的数据库！", "System.Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cmb_CurrentDatabase.Focus();
                return;
            }
            this.toolStripStateInfor.Text = "事务执行中...";
            Application.DoEvents();
            time1.Start();
            StringBuilder sqlBuilder = new StringBuilder();
            try
            {

                sqlBuilder.AppendFormat(" USE [{0}];", this.cmb_SourceDatabase.Text);
                sqlBuilder.Append("      /*对照表数据库   插入临时表#temp1*/");
                sqlBuilder.Append(" ");
                sqlBuilder.Append(" SELECT");
                sqlBuilder.Append("     a.name AS TableName ,");
                sqlBuilder.Append("     b.name AS ColumnName ,");
                sqlBuilder.Append("     c.name AS DataType ,");
                sqlBuilder.Append("     CASE b.prec WHEN -1 THEN 2000  ELSE b.prec END AS Length /*c.length AS Length*/");
                sqlBuilder.Append(" INTO");
                sqlBuilder.Append("     #temp1");
                sqlBuilder.Append(" FROM");
                sqlBuilder.Append("     sysobjects a");
                sqlBuilder.Append(" INNER JOIN syscolumns b ON a.id = b.id");
                sqlBuilder.Append(" INNER JOIN systypes c ON c.xtype = b.xtype");
                sqlBuilder.Append(" WHERE");
                sqlBuilder.Append("     a.xtype = 'U'");
                sqlBuilder.Append("     AND c.name != 'sysname';");
                sqlBuilder.Append(" ");

                sqlBuilder.AppendFormat(" USE [{0}];", this.cmb_CurrentDatabase.Text);
                sqlBuilder.Append("     /*缺失表数据库   插入临时表#temp0*/");

                sqlBuilder.Append("  ");
                sqlBuilder.Append(" SELECT");
                sqlBuilder.Append("     a.name AS TableName ,");
                sqlBuilder.Append("     b.name AS ColumnName ,");
                sqlBuilder.Append("     c.name AS DataType ,");
                sqlBuilder.Append("     CASE b.prec WHEN -1 THEN 2000  ELSE b.prec END AS Length /*c.length AS Length*/");
                sqlBuilder.Append(" INTO");
                sqlBuilder.Append("     #temp0");
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
                sqlBuilder.Append("                     tablename = a.tablename and a.columnname = columnname );");
                sqlBuilder.Append("    /* AND datatype != 'sysname';*/");
                sqlBuilder.Append(" ");
                sqlBuilder.Append(" SELECT * from #temp2  ");
                //sqlBuilder.AppendFormat(" USE {0};", this.cmb_CurrentDatabase.Text);
                using (SqlConnection conn = new SqlConnection(_myConnectionString))
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

                time1.Stop();
                this.toolStripStateInfor.Text = "就绪";
                this.toolScriptTime.Text = time1.Elapsed.ToString();       //将时间显示在状态栏
                this.label4.Text = "共计 '" + _rowCount.ToString() + "' 条记录。";
                // this.pgs_Detail.Maximum = _rowCount;
                //this.toolScript_Progress.Maximum = _rowCount;        //本次查询的记录条数
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if()
        }

        private void btn_Exchange_Click(object sender, EventArgs e)
        {
            string tempName = this.cmb_CurrentDatabase.Text;
            this.cmb_CurrentDatabase.Text = this.cmb_SourceDatabase.Text;
            this.cmb_SourceDatabase.Text = tempName;
        }

        private void lab_SelectedAll_Click(object sender, EventArgs e)
        {
            if (this.xsD_ResultDisplay1.result.Rows.Count <= 0)
            {
                return;
            }
            else
            {
                foreach (DataRow dr in this.xsD_ResultDisplay1.result.Rows)
                {
                    dr["Choose"] = true;
                }
            }
        }


        private void lab_SelectNone_Click(object sender, EventArgs e)
        {
            if (this.xsD_ResultDisplay1.result.Rows.Count <= 0)
            {
                return;
            }
            else
            {
                foreach (DataRow dr in this.xsD_ResultDisplay1.result.Rows)
                {
                    dr["Choose"] = false;
                }
            }
        }

        private void lab_Invert_Click(object sender, EventArgs e)
        {
            if (this.xsD_ResultDisplay1.result.Rows.Count <= 0)
            {
                return;
            }
            else
            {
                foreach (DataRow dr in this.xsD_ResultDisplay1.result.Rows)
                {
                    dr["Choose"] = !Convert.ToBoolean(dr["Choose"]);
                }
                Encoding.GetEncoding("UTF-8");
            }
        }

        private void btn_ExportSQL_Click(object sender, EventArgs e)
        {
            int count = GetSelectCount();
            if (count > 0)
            {
                this.toolScript_Progress.Maximum = count;
                StringBuilder sql = new StringBuilder();
                OutPutForm output = new OutPutForm();
                sql = FixIt(false);
                output.rich_Result.Text = sql.ToString();
                output.Show();
            }
            else
            {
                MessageBox.Show("没有选择任何字段!");
            }

        }

        private void dgv_ShowResult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (this.dgv_ShowResult.CurrentCell.ColumnIndex == this.dgv_ShowResult.Columns["Choose"].Index && e.Button == MouseButtons.Left)
            //{
            //    this.dgv_ShowResult.CurrentCell.Value = !Convert.ToBoolean(dgv_ShowResult.CurrentCell.Value);
            //}
        }
        public void FixIt()
        {
            //数据集不为空
            if (this.xsD_ResultDisplay1.result.Rows.Count <= 0)
            {
                return;
            }
            //遍历数据集
            //判断数据表是否存在
            //如果存在修改 不存在创建   
            int _progress = 0;
            Stopwatch time = new Stopwatch();

            this.toolScript_Progress.Visible = true;       //使进度条显示出来
            this.toolStripStateInfor.Text = "事务执行中...";
            this.toolScriptTime.Text = "";
            Application.DoEvents();

            time.Start();

            //Application.DoEvents();
            using (SqlConnection conn = new SqlConnection(_myConnectionString))
            {
                conn.Open();
                StringBuilder sqlCommand = new StringBuilder();
                foreach (DataRow dr in this.xsD_ResultDisplay1.result.Rows)
                {
                    if (Convert.ToBoolean(dr["Choose"]))
                    {
                        if (!Existsed(dr["tablename"].ToString()))
                        {
                            //sqlCommand.AppendFormat("use [{3}] ; create table [{0}] ( [{1}]  {2} )", dr[0], dr[1], dr[2], this.cmb_CurrentDatabase.Text);
                            sqlCommand.AppendFormat("USE [{3}]; CREATE TABLE [{0}] ( [{1}]  {2} )", dr["tablename"], dr["columnname"], dr["datatype"], this.cmb_CurrentDatabase.Text);
                        }
                        else
                        {
                            //sqlCommand.AppendFormat("use [{3}] ; alter table [{0}] add [{1}]  {2}", dr[0], dr[1], dr[2], this.cmb_CurrentDatabase.Text);
                            sqlCommand.AppendFormat("USE [{3}]; ALTER TABLE [{0}] ADD [{1}]  {2}", dr["tablename"], dr["columnname"], dr["datatype"], this.cmb_CurrentDatabase.Text);
                        }
                        using (SqlCommand command = new SqlCommand(sqlCommand.ToString(), conn))
                        {
                            command.ExecuteNonQuery();
                        }
                        sqlCommand.Remove(0, sqlCommand.Length);
                        //++_progress;                    

                        // this.pgs_Detail .Value =(++_progress);
                        //this.toolScriptInfo.Text ="已修复"+ ((this.pgs_Detail.Value / _rowCount) * 100).ToString() + "%";
                        this.toolScript_Progress.Value = (++_progress);         //更新进度信息                           
                    }
                }

            }
            time.Stop();
            if (_progress == this.toolScript_Progress.Maximum)
            {
                //MessageBox.Show("修复完成！");
                this.toolStripStateInfor.Text = "就绪";
                //this.toolScriptUser.Text = "修复完成"+_progress.ToString()+"条";                    
                this.toolScriptTime.Text = time.Elapsed.ToString();      //将执行时间显示出来
                MessageBox.Show("修复完成!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.toolScript_Progress.Visible = false;
            }

            btn_Seach.PerformClick();
        }

        private void menu_about_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new DataTool.AboutBox1();
            about.ShowDialog();
        }

        private void btn_EachRepair_Click(object sender, EventArgs e)
        {
            int count = GetSelectCount();
            if (count > 0)
            {
                this.toolScript_Progress.Maximum = count;
                FixIt();
            }
            else
            {
                MessageBox.Show("没有选择任何字段!");
            }


        }
        private int GetSelectCount()
        {
            int count = this.xsD_ResultDisplay1.result.Rows.Count;
            int selected = 0;
            for (int i = 0; i < count; ++i)
            {
                DataRow dr = this.xsD_ResultDisplay1.result.Rows[i];
                if (Convert.ToBoolean(dr["Choose"]))
                {
                    ++selected;
                }
            }
            return selected;
        }
    }
}

