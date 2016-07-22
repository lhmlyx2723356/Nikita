namespace Nikita.Assist.Note
{
    partial class FrmBseUrlSimpleDialog
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
            this.lblEditType = new System.Windows.Forms.Label();
            this.lblEditUrlTitle = new System.Windows.Forms.Label();
            this.txtEditUrlTitle = new System.Windows.Forms.TextBox();
            this.lblEditUrl = new System.Windows.Forms.Label();
            this.txtEditUrl = new System.Windows.Forms.TextBox();
            this.lblEditUrlContent = new System.Windows.Forms.Label();
            this.txtEditUrlContent = new System.Windows.Forms.TextBox();
            this.lblEditRemark = new System.Windows.Forms.Label();
            this.txtEditRemark = new System.Windows.Forms.TextBox();
            this.lblEditStatus = new System.Windows.Forms.Label();
            this.chkEditStatus = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboEditType = new System.Windows.Forms.ComboBox();
            this.dataNavigator = new Nikita.WinForm.ExtendControl.DataNavigator();
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
            this.tabPage.Controls.Add(this.cboEditType);
            this.tabPage.Controls.Add(this.lblEditType);
            this.tabPage.Controls.Add(this.lblEditUrlTitle);
            this.tabPage.Controls.Add(this.txtEditUrlTitle);
            this.tabPage.Controls.Add(this.lblEditUrl);
            this.tabPage.Controls.Add(this.txtEditUrl);
            this.tabPage.Controls.Add(this.lblEditUrlContent);
            this.tabPage.Controls.Add(this.txtEditUrlContent);
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
            // lblEditType
            // 
            this.lblEditType.Location = new System.Drawing.Point(15, 15);
            this.lblEditType.Name = "lblEditType";
            this.lblEditType.Size = new System.Drawing.Size(60, 16);
            this.lblEditType.TabIndex = 1;
            this.lblEditType.Text = "类别";
            // 
            // lblEditUrlTitle
            // 
            this.lblEditUrlTitle.Location = new System.Drawing.Point(217, 15);
            this.lblEditUrlTitle.Name = "lblEditUrlTitle";
            this.lblEditUrlTitle.Size = new System.Drawing.Size(60, 16);
            this.lblEditUrlTitle.TabIndex = 1;
            this.lblEditUrlTitle.Text = "标题";
            // 
            // txtEditUrlTitle
            // 
            this.txtEditUrlTitle.Location = new System.Drawing.Point(278, 15);
            this.txtEditUrlTitle.Name = "txtEditUrlTitle";
            this.txtEditUrlTitle.Size = new System.Drawing.Size(130, 23);
            this.txtEditUrlTitle.TabIndex = 5;
            this.txtEditUrlTitle.Tag = "UrlTitle";
            // 
            // lblEditUrl
            // 
            this.lblEditUrl.Location = new System.Drawing.Point(15, 45);
            this.lblEditUrl.Name = "lblEditUrl";
            this.lblEditUrl.Size = new System.Drawing.Size(60, 16);
            this.lblEditUrl.TabIndex = 1;
            this.lblEditUrl.Text = "网址";
            // 
            // txtEditUrl
            // 
            this.txtEditUrl.Location = new System.Drawing.Point(76, 45);
            this.txtEditUrl.Name = "txtEditUrl";
            this.txtEditUrl.Size = new System.Drawing.Size(332, 23);
            this.txtEditUrl.TabIndex = 10;
            this.txtEditUrl.Tag = "Url";
            // 
            // lblEditUrlContent
            // 
            this.lblEditUrlContent.Location = new System.Drawing.Point(15, 74);
            this.lblEditUrlContent.Name = "lblEditUrlContent";
            this.lblEditUrlContent.Size = new System.Drawing.Size(60, 16);
            this.lblEditUrlContent.TabIndex = 1;
            this.lblEditUrlContent.Text = "网址内容";
            // 
            // txtEditUrlContent
            // 
            this.txtEditUrlContent.Location = new System.Drawing.Point(76, 74);
            this.txtEditUrlContent.Multiline = true;
            this.txtEditUrlContent.Name = "txtEditUrlContent";
            this.txtEditUrlContent.Size = new System.Drawing.Size(332, 72);
            this.txtEditUrlContent.TabIndex = 15;
            this.txtEditUrlContent.Tag = "UrlContent";
            // 
            // lblEditRemark
            // 
            this.lblEditRemark.Location = new System.Drawing.Point(15, 152);
            this.lblEditRemark.Name = "lblEditRemark";
            this.lblEditRemark.Size = new System.Drawing.Size(60, 16);
            this.lblEditRemark.TabIndex = 1;
            this.lblEditRemark.Text = "备注";
            // 
            // txtEditRemark
            // 
            this.txtEditRemark.Location = new System.Drawing.Point(76, 152);
            this.txtEditRemark.Name = "txtEditRemark";
            this.txtEditRemark.Size = new System.Drawing.Size(332, 23);
            this.txtEditRemark.TabIndex = 20;
            this.txtEditRemark.Tag = "Remark";
            // 
            // lblEditStatus
            // 
            this.lblEditStatus.Location = new System.Drawing.Point(15, 181);
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
            this.chkEditStatus.Location = new System.Drawing.Point(76, 181);
            this.chkEditStatus.Name = "chkEditStatus";
            this.chkEditStatus.Size = new System.Drawing.Size(15, 14);
            this.chkEditStatus.TabIndex = 4;
            this.chkEditStatus.Tag = "Status";
            this.chkEditStatus.UseVisualStyleBackColor = true;
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
            // cboEditType
            // 
            this.cboEditType.Location = new System.Drawing.Point(76, 10);
            this.cboEditType.Name = "cboEditType";
            this.cboEditType.Size = new System.Drawing.Size(130, 25);
            this.cboEditType.TabIndex = 21;
            this.cboEditType.Tag = "Type";
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
            // FrmBseUrlSimpleDialog
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
            this.Name = "FrmBseUrlSimpleDialog";
            this.AcceptButton = btnSave;
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
        public  System.Windows.Forms.Label lblEditType;
        public  System.Windows.Forms.Label lblEditUrlTitle;
        public System.Windows.Forms.TextBox  txtEditUrlTitle;
        public  System.Windows.Forms.Label lblEditUrl;
        public System.Windows.Forms.TextBox  txtEditUrl;
        public  System.Windows.Forms.Label lblEditUrlContent;
        public System.Windows.Forms.TextBox  txtEditUrlContent;
        public  System.Windows.Forms.Label lblEditRemark;
        public System.Windows.Forms.TextBox  txtEditRemark;
        public  System.Windows.Forms.Label lblEditStatus;
        public System.Windows.Forms.CheckBox  chkEditStatus;
        public System.Windows.Forms.ComboBox cboEditType;
    }
}
