namespace TCM.Mysql.CodeGenerate
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lv_tables = new System.Windows.Forms.ListView();
            this.rtClass = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lv_tables
            // 
            this.lv_tables.Location = new System.Drawing.Point(12, 12);
            this.lv_tables.Name = "lv_tables";
            this.lv_tables.Size = new System.Drawing.Size(196, 543);
            this.lv_tables.TabIndex = 0;
            this.lv_tables.UseCompatibleStateImageBehavior = false;
            this.lv_tables.DoubleClick += new System.EventHandler(this.lv_tables_DoubleClick);
            // 
            // rtClass
            // 
            this.rtClass.Location = new System.Drawing.Point(214, 12);
            this.rtClass.Name = "rtClass";
            this.rtClass.Size = new System.Drawing.Size(790, 543);
            this.rtClass.TabIndex = 1;
            this.rtClass.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(476, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "加载中，请稍后.............";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 567);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtClass);
            this.Controls.Add(this.lv_tables);
            this.Name = "frmMain";
            this.Text = "主界面";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_tables;
        private System.Windows.Forms.RichTextBox rtClass;
        private System.Windows.Forms.Label label1;
    }
}

