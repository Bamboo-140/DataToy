namespace DataTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Fix = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_CurrentDatabase = new System.Windows.Forms.ComboBox();
            this.cmb_SourceDatabase = new System.Windows.Forms.ComboBox();
            this.btn_Seach = new System.Windows.Forms.Button();
            this.dgv_ShowResult = new System.Windows.Forms.DataGridView();
            this.Choose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tablenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datatypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bds_ResultDisplay = new System.Windows.Forms.BindingSource(this.components);
            this.xsD_ResultDisplay1 = new DataTool.XSD_ResultDisplay();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pgs_Detail = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Exchange = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStateInfor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolScriptTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolScriptUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolScript_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.lab_Invert = new System.Windows.Forms.Label();
            this.lab_SelectedAll = new System.Windows.Forms.Label();
            this.lab_SelectNone = new System.Windows.Forms.Label();
            this.btn_ExportSQL = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_EachRepair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_ResultDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsD_ResultDisplay1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Fix
            // 
            this.btn_Fix.Location = new System.Drawing.Point(270, 344);
            this.btn_Fix.Name = "btn_Fix";
            this.btn_Fix.Size = new System.Drawing.Size(75, 23);
            this.btn_Fix.TabIndex = 0;
            this.btn_Fix.Text = "批处理修复";
            this.btn_Fix.UseVisualStyleBackColor = true;
            this.btn_Fix.Visible = false;
            this.btn_Fix.Click += new System.EventHandler(this.btn_Fix_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "待修正数据库";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "参照数据库";
            // 
            // cmb_CurrentDatabase
            // 
            this.cmb_CurrentDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_CurrentDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_CurrentDatabase.FormattingEnabled = true;
            this.cmb_CurrentDatabase.Location = new System.Drawing.Point(95, 11);
            this.cmb_CurrentDatabase.Name = "cmb_CurrentDatabase";
            this.cmb_CurrentDatabase.Size = new System.Drawing.Size(164, 20);
            this.cmb_CurrentDatabase.TabIndex = 9;
            // 
            // cmb_SourceDatabase
            // 
            this.cmb_SourceDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_SourceDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_SourceDatabase.FormattingEnabled = true;
            this.cmb_SourceDatabase.Location = new System.Drawing.Point(389, 11);
            this.cmb_SourceDatabase.Name = "cmb_SourceDatabase";
            this.cmb_SourceDatabase.Size = new System.Drawing.Size(164, 20);
            this.cmb_SourceDatabase.TabIndex = 10;
            // 
            // btn_Seach
            // 
            this.btn_Seach.Location = new System.Drawing.Point(14, 343);
            this.btn_Seach.Name = "btn_Seach";
            this.btn_Seach.Size = new System.Drawing.Size(125, 23);
            this.btn_Seach.TabIndex = 11;
            this.btn_Seach.Text = "查找缺失表及字段";
            this.btn_Seach.UseVisualStyleBackColor = true;
            this.btn_Seach.Click += new System.EventHandler(this.btn_Seach_Click);
            // 
            // dgv_ShowResult
            // 
            this.dgv_ShowResult.AllowUserToAddRows = false;
            this.dgv_ShowResult.AutoGenerateColumns = false;
            this.dgv_ShowResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShowResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Choose,
            this.tablenameDataGridViewTextBoxColumn,
            this.columnnameDataGridViewTextBoxColumn,
            this.datatypeDataGridViewTextBoxColumn});
            this.dgv_ShowResult.DataSource = this.bds_ResultDisplay;
            this.dgv_ShowResult.Location = new System.Drawing.Point(14, 55);
            this.dgv_ShowResult.Name = "dgv_ShowResult";
            this.dgv_ShowResult.RowTemplate.Height = 23;
            this.dgv_ShowResult.Size = new System.Drawing.Size(539, 274);
            this.dgv_ShowResult.TabIndex = 12;
            this.dgv_ShowResult.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ShowResult_CellMouseDown);
            // 
            // Choose
            // 
            this.Choose.DataPropertyName = "Choose";
            this.Choose.HeaderText = "选择";
            this.Choose.Name = "Choose";
            this.Choose.Width = 50;
            // 
            // tablenameDataGridViewTextBoxColumn
            // 
            this.tablenameDataGridViewTextBoxColumn.DataPropertyName = "tablename";
            this.tablenameDataGridViewTextBoxColumn.HeaderText = "表名";
            this.tablenameDataGridViewTextBoxColumn.Name = "tablenameDataGridViewTextBoxColumn";
            this.tablenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tablenameDataGridViewTextBoxColumn.Width = 150;
            // 
            // columnnameDataGridViewTextBoxColumn
            // 
            this.columnnameDataGridViewTextBoxColumn.DataPropertyName = "columnname";
            this.columnnameDataGridViewTextBoxColumn.HeaderText = "字段名";
            this.columnnameDataGridViewTextBoxColumn.Name = "columnnameDataGridViewTextBoxColumn";
            this.columnnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.columnnameDataGridViewTextBoxColumn.Width = 150;
            // 
            // datatypeDataGridViewTextBoxColumn
            // 
            this.datatypeDataGridViewTextBoxColumn.DataPropertyName = "datatype";
            this.datatypeDataGridViewTextBoxColumn.HeaderText = "数据类型";
            this.datatypeDataGridViewTextBoxColumn.Name = "datatypeDataGridViewTextBoxColumn";
            this.datatypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.datatypeDataGridViewTextBoxColumn.Width = 150;
            // 
            // bds_ResultDisplay
            // 
            this.bds_ResultDisplay.DataMember = "result";
            this.bds_ResultDisplay.DataSource = this.xsD_ResultDisplay1;
            // 
            // xsD_ResultDisplay1
            // 
            this.xsD_ResultDisplay1.DataSetName = "XSD_ResultDisplay";
            this.xsD_ResultDisplay1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "查询结果";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(71, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 15;
            // 
            // pgs_Detail
            // 
            this.pgs_Detail.Location = new System.Drawing.Point(424, 343);
            this.pgs_Detail.Name = "pgs_Detail";
            this.pgs_Detail.Size = new System.Drawing.Size(103, 23);
            this.pgs_Detail.TabIndex = 16;
            this.pgs_Detail.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(533, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "100%";
            this.label5.Visible = false;
            // 
            // btn_Exchange
            // 
            this.btn_Exchange.Location = new System.Drawing.Point(275, 11);
            this.btn_Exchange.Name = "btn_Exchange";
            this.btn_Exchange.Size = new System.Drawing.Size(31, 23);
            this.btn_Exchange.TabIndex = 18;
            this.btn_Exchange.Text = "<->";
            this.btn_Exchange.UseVisualStyleBackColor = true;
            this.btn_Exchange.Click += new System.EventHandler(this.btn_Exchange_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStateInfor,
            this.toolStripStatusLabel1,
            this.toolScriptTime,
            this.toolScriptUser,
            this.toolScript_Progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 380);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 23);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStateInfor
            // 
            this.toolStripStateInfor.AutoSize = false;
            this.toolStripStateInfor.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStateInfor.Name = "toolStripStateInfor";
            this.toolStripStateInfor.Size = new System.Drawing.Size(95, 18);
            this.toolStripStateInfor.Text = "就绪";
            this.toolStripStateInfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(64, 18);
            this.toolStripStatusLabel1.Text = "执行耗时";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolScriptTime
            // 
            this.toolScriptTime.AutoSize = false;
            this.toolScriptTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolScriptTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolScriptTime.Name = "toolScriptTime";
            this.toolScriptTime.Size = new System.Drawing.Size(128, 18);
            // 
            // toolScriptUser
            // 
            this.toolScriptUser.AutoSize = false;
            this.toolScriptUser.Name = "toolScriptUser";
            this.toolScriptUser.Size = new System.Drawing.Size(75, 18);
            // 
            // toolScript_Progress
            // 
            this.toolScript_Progress.Name = "toolScript_Progress";
            this.toolScript_Progress.Size = new System.Drawing.Size(131, 17);
            this.toolScript_Progress.Visible = false;
            // 
            // lab_Invert
            // 
            this.lab_Invert.AutoSize = true;
            this.lab_Invert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_Invert.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Invert.Location = new System.Drawing.Point(224, 346);
            this.lab_Invert.Name = "lab_Invert";
            this.lab_Invert.Size = new System.Drawing.Size(40, 17);
            this.lab_Invert.TabIndex = 21;
            this.lab_Invert.Text = " 反选 ";
            this.lab_Invert.Click += new System.EventHandler(this.lab_Invert_Click);
            // 
            // lab_SelectedAll
            // 
            this.lab_SelectedAll.AutoSize = true;
            this.lab_SelectedAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_SelectedAll.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_SelectedAll.Location = new System.Drawing.Point(153, 346);
            this.lab_SelectedAll.Name = "lab_SelectedAll";
            this.lab_SelectedAll.Size = new System.Drawing.Size(40, 17);
            this.lab_SelectedAll.TabIndex = 22;
            this.lab_SelectedAll.Text = " 全选 ";
            this.lab_SelectedAll.Click += new System.EventHandler(this.lab_SelectedAll_Click);
            // 
            // lab_SelectNone
            // 
            this.lab_SelectNone.AutoSize = true;
            this.lab_SelectNone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_SelectNone.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_SelectNone.Location = new System.Drawing.Point(186, 346);
            this.lab_SelectNone.Name = "lab_SelectNone";
            this.lab_SelectNone.Size = new System.Drawing.Size(44, 17);
            this.lab_SelectNone.TabIndex = 23;
            this.lab_SelectNone.Text = "全不选";
            this.lab_SelectNone.Click += new System.EventHandler(this.lab_SelectNone_Click);
            // 
            // btn_ExportSQL
            // 
            this.btn_ExportSQL.Location = new System.Drawing.Point(351, 344);
            this.btn_ExportSQL.Name = "btn_ExportSQL";
            this.btn_ExportSQL.Size = new System.Drawing.Size(75, 23);
            this.btn_ExportSQL.TabIndex = 24;
            this.btn_ExportSQL.Text = "导出SQL";
            this.btn_ExportSQL.UseVisualStyleBackColor = true;
            this.btn_ExportSQL.Click += new System.EventHandler(this.btn_ExportSQL_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_about});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 25);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menu_about
            // 
            this.menu_about.Name = "menu_about";
            this.menu_about.Size = new System.Drawing.Size(60, 21);
            this.menu_about.Text = "关于(&A)";
            this.menu_about.Visible = false;
            this.menu_about.Click += new System.EventHandler(this.menu_about_Click);
            // 
            // btn_EachRepair
            // 
            this.btn_EachRepair.Location = new System.Drawing.Point(270, 344);
            this.btn_EachRepair.Name = "btn_EachRepair";
            this.btn_EachRepair.Size = new System.Drawing.Size(75, 23);
            this.btn_EachRepair.TabIndex = 26;
            this.btn_EachRepair.Text = "逐条修复";
            this.btn_EachRepair.UseVisualStyleBackColor = true;
            this.btn_EachRepair.Click += new System.EventHandler(this.btn_EachRepair_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 403);
            this.Controls.Add(this.btn_EachRepair);
            this.Controls.Add(this.btn_ExportSQL);
            this.Controls.Add(this.lab_SelectNone);
            this.Controls.Add(this.lab_SelectedAll);
            this.Controls.Add(this.lab_Invert);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_Exchange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pgs_Detail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_ShowResult);
            this.Controls.Add(this.btn_Seach);
            this.Controls.Add(this.cmb_SourceDatabase);
            this.Controls.Add(this.cmb_CurrentDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Fix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_ResultDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsD_ResultDisplay1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Fix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_CurrentDatabase;
        private System.Windows.Forms.ComboBox cmb_SourceDatabase;
        private System.Windows.Forms.Button btn_Seach;
        private System.Windows.Forms.DataGridView dgv_ShowResult;
        private System.Windows.Forms.Label label3;
        private XSD_ResultDisplay xsD_ResultDisplay1;
        private System.Windows.Forms.BindingSource bds_ResultDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pgs_Detail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Exchange;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStateInfor;
        private System.Windows.Forms.ToolStripProgressBar toolScript_Progress;
        private System.Windows.Forms.ToolStripStatusLabel toolScriptUser;
        private System.Windows.Forms.ToolStripStatusLabel toolScriptTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lab_Invert;
        private System.Windows.Forms.Label lab_SelectedAll;
        private System.Windows.Forms.Label lab_SelectNone;
        private System.Windows.Forms.Button btn_ExportSQL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datatypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_about;
        private System.Windows.Forms.Button btn_EachRepair;
    }
}

