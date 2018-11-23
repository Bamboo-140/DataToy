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
            this.tablenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datatypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bds_ResultDisplay = new System.Windows.Forms.BindingSource(this.components);
            this.xsD_ResultDisplay1 = new DataTool.XSD_ResultDisplay();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pgs_Detail = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_ResultDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsD_ResultDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Fix
            // 
            this.btn_Fix.Location = new System.Drawing.Point(143, 311);
            this.btn_Fix.Name = "btn_Fix";
            this.btn_Fix.Size = new System.Drawing.Size(75, 23);
            this.btn_Fix.TabIndex = 0;
            this.btn_Fix.Text = "修复";
            this.btn_Fix.UseVisualStyleBackColor = true;
            this.btn_Fix.Click += new System.EventHandler(this.btn_Fix_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "待修正数据库";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "参照数据库";
            // 
            // cmb_CurrentDatabase
            // 
            this.cmb_CurrentDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_CurrentDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_CurrentDatabase.FormattingEnabled = true;
            this.cmb_CurrentDatabase.Location = new System.Drawing.Point(95, 5);
            this.cmb_CurrentDatabase.Name = "cmb_CurrentDatabase";
            this.cmb_CurrentDatabase.Size = new System.Drawing.Size(164, 20);
            this.cmb_CurrentDatabase.TabIndex = 9;
            // 
            // cmb_SourceDatabase
            // 
            this.cmb_SourceDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_SourceDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_SourceDatabase.FormattingEnabled = true;
            this.cmb_SourceDatabase.Location = new System.Drawing.Point(354, 5);
            this.cmb_SourceDatabase.Name = "cmb_SourceDatabase";
            this.cmb_SourceDatabase.Size = new System.Drawing.Size(164, 20);
            this.cmb_SourceDatabase.TabIndex = 10;
            // 
            // btn_Seach
            // 
            this.btn_Seach.Location = new System.Drawing.Point(12, 311);
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
            this.tablenameDataGridViewTextBoxColumn,
            this.columnnameDataGridViewTextBoxColumn,
            this.datatypeDataGridViewTextBoxColumn});
            this.dgv_ShowResult.DataSource = this.bds_ResultDisplay;
            this.dgv_ShowResult.Location = new System.Drawing.Point(14, 56);
            this.dgv_ShowResult.Name = "dgv_ShowResult";
            this.dgv_ShowResult.ReadOnly = true;
            this.dgv_ShowResult.RowTemplate.Height = 23;
            this.dgv_ShowResult.Size = new System.Drawing.Size(504, 229);
            this.dgv_ShowResult.TabIndex = 12;
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
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "查询结果";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(71, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 15;
            // 
            // pgs_Detail
            // 
            this.pgs_Detail.Location = new System.Drawing.Point(224, 311);
            this.pgs_Detail.Name = "pgs_Detail";
            this.pgs_Detail.Size = new System.Drawing.Size(241, 23);
            this.pgs_Detail.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "0%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 358);
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
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "管理界面";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_ResultDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsD_ResultDisplay1)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn tablenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datatypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pgs_Detail;
        private System.Windows.Forms.Label label5;
    }
}

