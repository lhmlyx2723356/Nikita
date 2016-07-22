namespace Nikita.Base.CacheStore
{
    partial class FrmCacheConfigSimpleDialog
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.lblEditConnectionString = new System.Windows.Forms.Label();
            this.txtEditConnectionString = new System.Windows.Forms.TextBox();
            this.lblEditTableName = new System.Windows.Forms.Label();
            this.cboEditTableName = new System.Windows.Forms.ComboBox();
            this.lblEditFilter = new System.Windows.Forms.Label();
            this.txtEditFilter = new System.Windows.Forms.TextBox();
            this.lblEditCacheTableName = new System.Windows.Forms.Label();
            this.txtEditCacheTableName = new System.Windows.Forms.TextBox();
            this.lblEditCacheVersion = new System.Windows.Forms.Label();
            this.txtEditCacheVersion = new System.Windows.Forms.TextBox();
            this.lblEditRemark = new System.Windows.Forms.Label();
            this.txtEditRemark = new System.Windows.Forms.TextBox();
            this.lblEditStatus = new System.Windows.Forms.Label();
            this.chkEditStatus = new System.Windows.Forms.CheckBox();
            this.dataNavigator = new Nikita.WinForm.ExtendControl.DataNavigator();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataNavigator);
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(434, 370);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(432, 315);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage
            // 
            this.tabPage.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage.Controls.Add(this.lblEditConnectionString);
            this.tabPage.Controls.Add(this.txtEditConnectionString);
            this.tabPage.Controls.Add(this.lblEditTableName);
            this.tabPage.Controls.Add(this.cboEditTableName);
            this.tabPage.Controls.Add(this.lblEditFilter);
            this.tabPage.Controls.Add(this.txtEditFilter);
            this.tabPage.Controls.Add(this.lblEditCacheTableName);
            this.tabPage.Controls.Add(this.txtEditCacheTableName);
            this.tabPage.Controls.Add(this.lblEditCacheVersion);
            this.tabPage.Controls.Add(this.txtEditCacheVersion);
            this.tabPage.Controls.Add(this.lblEditRemark);
            this.tabPage.Controls.Add(this.txtEditRemark);
            this.tabPage.Controls.Add(this.lblEditStatus);
            this.tabPage.Controls.Add(this.chkEditStatus);
            this.tabPage.Location = new System.Drawing.Point(4, 26);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(424, 285);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "基本信息";
            // 
            // lblEditConnectionString
            // 
            this.lblEditConnectionString.Location = new System.Drawing.Point(15, 15);
            this.lblEditConnectionString.Name = "lblEditConnectionString";
            this.lblEditConnectionString.Size = new System.Drawing.Size(60, 23);
            this.lblEditConnectionString.TabIndex = 1;
            this.lblEditConnectionString.Text = "连接串";
            // 
            // txtEditConnectionString
            // 
            this.txtEditConnectionString.Location = new System.Drawing.Point(76, 15);
            this.txtEditConnectionString.Name = "txtEditConnectionString";
            this.txtEditConnectionString.Size = new System.Drawing.Size(332, 23);
            this.txtEditConnectionString.TabIndex = 1;
            this.txtEditConnectionString.Tag = "ConnectionString";
            // 
            // lblEditTableName
            // 
            this.lblEditTableName.Location = new System.Drawing.Point(15, 46);
            this.lblEditTableName.Name = "lblEditTableName";
            this.lblEditTableName.Size = new System.Drawing.Size(60, 16);
            this.lblEditTableName.TabIndex = 1;
            this.lblEditTableName.Text = "表名";
            // 
            // cboEditTableName
            // 
            this.cboEditTableName.Location = new System.Drawing.Point(76, 46);
            this.cboEditTableName.Name = "cboEditTableName";
            this.cboEditTableName.Size = new System.Drawing.Size(130, 25);
            this.cboEditTableName.TabIndex = 2;
            this.cboEditTableName.Tag = "TableName";
            // 
            // lblEditFilter
            // 
            this.lblEditFilter.Location = new System.Drawing.Point(217, 46);
            this.lblEditFilter.Name = "lblEditFilter";
            this.lblEditFilter.Size = new System.Drawing.Size(60, 16);
            this.lblEditFilter.TabIndex = 1;
            this.lblEditFilter.Text = "过滤";
            // 
            // txtEditFilter
            // 
            this.txtEditFilter.Location = new System.Drawing.Point(278, 46);
            this.txtEditFilter.Name = "txtEditFilter";
            this.txtEditFilter.Size = new System.Drawing.Size(130, 23);
            this.txtEditFilter.TabIndex = 10;
            this.txtEditFilter.Tag = "Filter";
            // 
            // lblEditCacheTableName
            // 
            this.lblEditCacheTableName.Location = new System.Drawing.Point(3, 76);
            this.lblEditCacheTableName.Name = "lblEditCacheTableName";
            this.lblEditCacheTableName.Size = new System.Drawing.Size(72, 16);
            this.lblEditCacheTableName.TabIndex = 1;
            this.lblEditCacheTableName.Text = "本地缓存表名";
            // 
            // txtEditCacheTableName
            // 
            this.txtEditCacheTableName.Location = new System.Drawing.Point(76, 76);
            this.txtEditCacheTableName.Name = "txtEditCacheTableName";
            this.txtEditCacheTableName.Size = new System.Drawing.Size(130, 23);
            this.txtEditCacheTableName.TabIndex = 15;
            this.txtEditCacheTableName.Tag = "CacheTableName";
            // 
            // lblEditCacheVersion
            // 
            this.lblEditCacheVersion.Location = new System.Drawing.Point(217, 82);
            this.lblEditCacheVersion.Name = "lblEditCacheVersion";
            this.lblEditCacheVersion.Size = new System.Drawing.Size(60, 16);
            this.lblEditCacheVersion.TabIndex = 1;
            this.lblEditCacheVersion.Text = "缓存版本";
            // 
            // txtEditCacheVersion
            // 
            this.txtEditCacheVersion.Location = new System.Drawing.Point(278, 82);
            this.txtEditCacheVersion.Name = "txtEditCacheVersion";
            this.txtEditCacheVersion.Size = new System.Drawing.Size(130, 23);
            this.txtEditCacheVersion.TabIndex = 25;
            this.txtEditCacheVersion.Tag = "CacheVersion";
            // 
            // lblEditRemark
            // 
            this.lblEditRemark.Location = new System.Drawing.Point(15, 108);
            this.lblEditRemark.Name = "lblEditRemark";
            this.lblEditRemark.Size = new System.Drawing.Size(60, 16);
            this.lblEditRemark.TabIndex = 1;
            this.lblEditRemark.Text = "备注";
            // 
            // txtEditRemark
            // 
            this.txtEditRemark.Location = new System.Drawing.Point(76, 108);
            this.txtEditRemark.Name = "txtEditRemark";
            this.txtEditRemark.Size = new System.Drawing.Size(130, 23);
            this.txtEditRemark.TabIndex = 30;
            this.txtEditRemark.Tag = "Remark";
            // 
            // lblEditStatus
            // 
            this.lblEditStatus.Location = new System.Drawing.Point(217, 111);
            this.lblEditStatus.Name = "lblEditStatus";
            this.lblEditStatus.Size = new System.Drawing.Size(60, 16);
            this.lblEditStatus.TabIndex = 1;
            this.lblEditStatus.Text = "状态";
            // 
            // chkEditStatus
            // 
            this.chkEditStatus.AutoSize = true;
            this.chkEditStatus.Checked = true;
            this.chkEditStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEditStatus.Location = new System.Drawing.Point(278, 111);
            this.chkEditStatus.Name = "chkEditStatus";
            this.chkEditStatus.Size = new System.Drawing.Size(15, 14);
            this.chkEditStatus.TabIndex = 4;
            this.chkEditStatus.Tag = "Status";
            this.chkEditStatus.UseVisualStyleBackColor = true;
            // 
            // dataNavigator
            // 
            this.dataNavigator.CurrentIndex = 0;
            this.dataNavigator.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataNavigator.ListInfo = null;
            this.dataNavigator.Location = new System.Drawing.Point(5, 4);
            this.dataNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.Size = new System.Drawing.Size(249, 32);
            this.dataNavigator.TabIndex = 2;
            this.dataNavigator.PositionChanged += new Nikita.WinForm.ExtendControl.DataNavigator.PostionChangedEventHandler(this.dataNavigator_PositionChanged);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Location = new System.Drawing.Point(341, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(261, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmCacheConfigSimpleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 370);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCacheConfigSimpleDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private WinForm.ExtendControl.DataNavigator dataNavigator;
        public  System.Windows.Forms.Label lblEditConnectionString;
        public System.Windows.Forms.TextBox  txtEditConnectionString;
        public  System.Windows.Forms.Label lblEditTableName;
        public System.Windows.Forms.ComboBox  cboEditTableName;
        public  System.Windows.Forms.Label lblEditFilter;
        public System.Windows.Forms.TextBox  txtEditFilter;
        public  System.Windows.Forms.Label lblEditCacheTableName;
        public System.Windows.Forms.TextBox  txtEditCacheTableName;
        public  System.Windows.Forms.Label lblEditCacheVersion;
        public System.Windows.Forms.TextBox  txtEditCacheVersion;
        public  System.Windows.Forms.Label lblEditRemark;
        public System.Windows.Forms.TextBox  txtEditRemark;
        public  System.Windows.Forms.Label lblEditStatus;
        public System.Windows.Forms.CheckBox  chkEditStatus;
    }
}
