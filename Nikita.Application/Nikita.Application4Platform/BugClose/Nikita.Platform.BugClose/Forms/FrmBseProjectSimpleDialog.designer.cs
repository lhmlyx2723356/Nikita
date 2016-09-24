namespace Nikita.Platform.BugClose
{
    partial class FrmBseProjectSimpleDialog
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
            this.lblEditCategory = new System.Windows.Forms.Label();
            this.cboEditCategory = new System.Windows.Forms.ComboBox();
            this.lblEditOnLevel = new System.Windows.Forms.Label();
            this.cboEditOnLevel = new System.Windows.Forms.ComboBox();
            this.lblEditRemark = new System.Windows.Forms.Label();
            this.txtEditRemark = new System.Windows.Forms.TextBox();
            this.lblEditSort = new System.Windows.Forms.Label();
            this.txtEditSort = new System.Windows.Forms.TextBox();
            this.lblEditStatus = new System.Windows.Forms.Label();
            this.chkEditStatus = new System.Windows.Forms.CheckBox();
            this.lblEditName = new System.Windows.Forms.Label();
            this.txtEditName = new System.Windows.Forms.TextBox();
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
            this.tabPage.Controls.Add(this.lblEditCategory);
            this.tabPage.Controls.Add(this.cboEditCategory);
            this.tabPage.Controls.Add(this.lblEditOnLevel);
            this.tabPage.Controls.Add(this.cboEditOnLevel);
            this.tabPage.Controls.Add(this.lblEditRemark);
            this.tabPage.Controls.Add(this.txtEditRemark);
            this.tabPage.Controls.Add(this.lblEditSort);
            this.tabPage.Controls.Add(this.txtEditSort);
            this.tabPage.Controls.Add(this.lblEditStatus);
            this.tabPage.Controls.Add(this.chkEditStatus);
            this.tabPage.Controls.Add(this.lblEditName);
            this.tabPage.Controls.Add(this.txtEditName);
            this.tabPage.Location = new System.Drawing.Point(4, 26);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(424, 285);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "基本信息";
            // 
            // lblEditCategory
            // 
            this.lblEditCategory.Location = new System.Drawing.Point(15, 15);
            this.lblEditCategory.Name = "lblEditCategory";
            this.lblEditCategory.Size = new System.Drawing.Size(60, 16);
            this.lblEditCategory.TabIndex = 1;
            this.lblEditCategory.Text = "项目类型";
            // 
            // cboEditCategory
            // 
            this.cboEditCategory.Location = new System.Drawing.Point(76, 15);
            this.cboEditCategory.Name = "cboEditCategory";
            this.cboEditCategory.Size = new System.Drawing.Size(130, 25);
            this.cboEditCategory.TabIndex = 2;
            this.cboEditCategory.Tag = "Category";
            // 
            // lblEditOnLevel
            // 
            this.lblEditOnLevel.Location = new System.Drawing.Point(217, 15);
            this.lblEditOnLevel.Name = "lblEditOnLevel";
            this.lblEditOnLevel.Size = new System.Drawing.Size(60, 16);
            this.lblEditOnLevel.TabIndex = 1;
            this.lblEditOnLevel.Text = "项目等级";
            // 
            // cboEditOnLevel
            // 
            this.cboEditOnLevel.Location = new System.Drawing.Point(278, 15);
            this.cboEditOnLevel.Name = "cboEditOnLevel";
            this.cboEditOnLevel.Size = new System.Drawing.Size(130, 25);
            this.cboEditOnLevel.TabIndex = 2;
            this.cboEditOnLevel.Tag = "OnLevel";
            // 
            // lblEditRemark
            // 
            this.lblEditRemark.Location = new System.Drawing.Point(15, 79);
            this.lblEditRemark.Name = "lblEditRemark";
            this.lblEditRemark.Size = new System.Drawing.Size(60, 16);
            this.lblEditRemark.TabIndex = 1;
            this.lblEditRemark.Text = "项目备注";
            // 
            // txtEditRemark
            // 
            this.txtEditRemark.Location = new System.Drawing.Point(76, 79);
            this.txtEditRemark.Name = "txtEditRemark";
            this.txtEditRemark.Size = new System.Drawing.Size(130, 23);
            this.txtEditRemark.TabIndex = 20;
            this.txtEditRemark.Tag = "Remark";
            // 
            // lblEditSort
            // 
            this.lblEditSort.Location = new System.Drawing.Point(217, 53);
            this.lblEditSort.Name = "lblEditSort";
            this.lblEditSort.Size = new System.Drawing.Size(60, 16);
            this.lblEditSort.TabIndex = 1;
            this.lblEditSort.Text = "排序";
            // 
            // txtEditSort
            // 
            this.txtEditSort.Location = new System.Drawing.Point(278, 53);
            this.txtEditSort.Name = "txtEditSort";
            this.txtEditSort.Size = new System.Drawing.Size(130, 23);
            this.txtEditSort.TabIndex = 25;
            this.txtEditSort.Tag = "Sort";
            // 
            // lblEditStatus
            // 
            this.lblEditStatus.Location = new System.Drawing.Point(217, 86);
            this.lblEditStatus.Name = "lblEditStatus";
            this.lblEditStatus.Size = new System.Drawing.Size(60, 16);
            this.lblEditStatus.TabIndex = 1;
            this.lblEditStatus.Text = "项目状态";
            // 
            // chkEditStatus
            // 
            this.chkEditStatus.AutoSize = true;
            this.chkEditStatus.Location = new System.Drawing.Point(278, 86);
            this.chkEditStatus.Name = "chkEditStatus";
            this.chkEditStatus.Size = new System.Drawing.Size(15, 14);
            this.chkEditStatus.TabIndex = 4;
            this.chkEditStatus.Tag = "Status";
            this.chkEditStatus.UseVisualStyleBackColor = true;
            // 
            // lblEditName
            // 
            this.lblEditName.Location = new System.Drawing.Point(15, 53);
            this.lblEditName.Name = "lblEditName";
            this.lblEditName.Size = new System.Drawing.Size(60, 16);
            this.lblEditName.TabIndex = 1;
            this.lblEditName.Text = "项目名称";
            // 
            // txtEditName
            // 
            this.txtEditName.Location = new System.Drawing.Point(76, 50);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(130, 23);
            this.txtEditName.TabIndex = 5;
            this.txtEditName.Tag = "Name";
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
            // FrmBseProjectSimpleDialog
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
            this.Name = "FrmBseProjectSimpleDialog";
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
        public  System.Windows.Forms.Label lblEditCategory;
        public System.Windows.Forms.ComboBox  cboEditCategory;
        public  System.Windows.Forms.Label lblEditOnLevel;
        public System.Windows.Forms.ComboBox  cboEditOnLevel;
        public  System.Windows.Forms.Label lblEditRemark;
        public System.Windows.Forms.TextBox  txtEditRemark;
        public  System.Windows.Forms.Label lblEditSort;
        public System.Windows.Forms.TextBox  txtEditSort;
        public  System.Windows.Forms.Label lblEditStatus;
        public System.Windows.Forms.CheckBox  chkEditStatus;
        public  System.Windows.Forms.Label lblEditName;
        public System.Windows.Forms.TextBox  txtEditName;
    }
}
