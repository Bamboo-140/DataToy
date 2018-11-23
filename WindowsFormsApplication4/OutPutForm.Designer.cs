namespace DataTool
{
    partial class OutPutForm
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
            this.rich_Result = new System.Windows.Forms.RichTextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_OutPutFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rich_Result
            // 
            this.rich_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_Result.Location = new System.Drawing.Point(0, 33);
            this.rich_Result.Name = "rich_Result";
            this.rich_Result.Size = new System.Drawing.Size(609, 373);
            this.rich_Result.TabIndex = 0;
            this.rich_Result.Text = "";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(11, 5);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_OutPutFormat);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 33);
            this.panel1.TabIndex = 2;
            // 
            // cmb_OutPutFormat
            // 
            this.cmb_OutPutFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OutPutFormat.FormattingEnabled = true;
            this.cmb_OutPutFormat.Items.AddRange(new object[] {
            "GB2312",
            "Unicode",
            "UTF-8",
            "UTF-16"});
            this.cmb_OutPutFormat.Location = new System.Drawing.Point(147, 7);
            this.cmb_OutPutFormat.Name = "cmb_OutPutFormat";
            this.cmb_OutPutFormat.Size = new System.Drawing.Size(96, 20);
            this.cmb_OutPutFormat.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件格式";
            // 
            // OutPutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 406);
            this.Controls.Add(this.rich_Result);
            this.Controls.Add(this.panel1);
            this.Name = "OutPutForm";
            this.Text = "OutPutForm";
            this.Load += new System.EventHandler(this.OutPutForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rich_Result;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_OutPutFormat;
        private System.Windows.Forms.Label label1;
    }
}