namespace Nikita.Platform.BugClose
{
    partial class FrmBseProjectSimpleQuery
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
       this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBseProjectSimpleQuery));
            this.sptAll = new System.Windows.Forms.SplitContainer();
            this.sptQuery = new System.Windows.Forms.SplitContainer();
this.lblQueryName = new System.Windows.Forms.Label();
            this.txtQueryName = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.sptView = new System.Windows.Forms.SplitContainer();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.gridmrzProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcboOnLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridmrzRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzDeptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzCompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcboCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridmrzCreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzEditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzEditUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pager = new Nikita.WinForm.ExtendControl.Pager();
            this.tspCommand = new System.Windows.Forms.ToolStrip();
            this.cmdFirst = new System.Windows.Forms.ToolStripButton();
            this.cmdPre = new System.Windows.Forms.ToolStripButton();
            this.cmdNext = new System.Windows.Forms.ToolStripButton();
            this.cmdLast = new System.Windows.Forms.ToolStripButton();
            this.cmdSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.cmdImport = new System.Windows.Forms.ToolStripSplitButton();
            this.cmdImportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCancel = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdEdit = new System.Windows.Forms.ToolStripButton();
            this.cmdNew = new System.Windows.Forms.ToolStripButton();
 this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).BeginInit();
            this.sptAll.Panel1.SuspendLayout();
            this.sptAll.Panel2.SuspendLayout();
            this.sptAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();
            this.sptQuery.Panel1.SuspendLayout();
            this.sptQuery.Panel2.SuspendLayout();
            this.sptQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptView)).BeginInit();
            this.sptView.Panel1.SuspendLayout();
            this.sptView.Panel2.SuspendLayout();
            this.sptView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tspCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptAll
            // 
            this.sptAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptAll.Location = new System.Drawing.Point(0, 26);
            this.sptAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sptAll.Name = "sptAll";
            this.sptAll.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptAll.Panel1
            // 
            this.sptAll.Panel1.Controls.Add(this.sptQuery);
            // 
            // sptAll.Panel2
            // 
            this.sptAll.Panel2.Controls.Add(this.sptView);
            this.sptAll.Size = new System.Drawing.Size(907, 535);
            this.sptAll.SplitterDistance = 61;
            this.sptAll.SplitterWidth = 6;
            this.sptAll.TabIndex = 2;
            this.sptAll.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // sptQuery
            // 
            this.sptQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sptQuery.Location = new System.Drawing.Point(0, 0);
            this.sptQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sptQuery.Name =  "sptQuery ";
            // 
            // sptQuery.Panel1
            // 
            this.sptQuery.Panel1.Controls.Add(this.lblQueryName);
            this.sptQuery.Panel1.Controls.Add(this.txtQueryName);
            // 
            // sptQuery.Panel2
            // 
            this.sptQuery.Panel2.Controls.Add(this.btnQuery);
            this.sptQuery.Size = new System.Drawing.Size(907, 61);
            this.sptQuery.SplitterDistance = 783;
            this.sptQuery.SplitterWidth = 5;
            this.sptQuery.TabIndex = 2;
            this.sptQuery.Click += new System.EventHandler(this.btnQuery_Click);
     this.lblQueryName.Location = new System.Drawing.Point(15, 15);
            this.lblQueryName.Name = "lblQueryName";
            this.lblQueryName.Size = new System.Drawing.Size(60, 16);
            this.lblQueryName.TabIndex = 1;
            this.lblQueryName.Text ="项目名称";
            // 
            // txtQueryName
            // 
            this.txtQueryName.Location = new System.Drawing.Point(76, 15);
            this.txtQueryName.Name =  "txtQueryName";
            this.txtQueryName.Size = new System.Drawing.Size(130, 20);
            this.txtQueryName.TabIndex = 1;

            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(31, 15);
            this.btnQuery.Name =  "btnQuery ";
            this.btnQuery.Size = new System.Drawing.Size(54, 31);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text =  "查询 ";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // sptView
            // 
            this.sptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sptView.Location = new System.Drawing.Point(0, 0);
            this.sptView.Name =  "sptView ";
            this.sptView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptView.Panel1
            // 
            this.sptView.Panel1.Controls.Add(this.grdData);
            // 
            // sptView.Panel2
            // 
            this.sptView.Panel2.Controls.Add(this.Pager);
            this.sptView.Size = new System.Drawing.Size(907, 468);
            this.sptView.SplitterDistance = 424;
            this.sptView.TabIndex = 0;
            this.sptView.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridmrzProjectID,
            this.gridmrzName,
            this.gridmrzStatus,
            this.gridcboOnLevel,
            this.gridmrzRemark,
            this.gridmrzSort,
            this.gridmrzDeptId,
            this.gridmrzCompanyID,
            this.gridmrzCreateDate,
            this.gridcboCategory,
            this.gridmrzCreateUser,
            this.gridmrzEditDate,
            this.gridmrzEditUser
    });
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name =  "grdData ";
            this.grdData.RowHeadersWidth = 50;
            this.grdData.RowTemplate.Height = 23;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(905, 422);
            this.grdData.TabIndex = 0;
            // 
            //  gridmrzProjectID
            // 
            this.gridmrzProjectID.DataPropertyName = "ProjectID";
            this.gridmrzProjectID.HeaderText = "项目编号";
            this.gridmrzProjectID.Name = "gridmrzProjectID";
            this.gridmrzProjectID.Visible = true;
            // 
            //  gridmrzName
            // 
            this.gridmrzName.DataPropertyName = "Name";
            this.gridmrzName.HeaderText = "项目名称";
            this.gridmrzName.Name = "gridmrzName";
            this.gridmrzName.Visible = true;
            // 
            //  gridmrzStatus
            // 
            this.gridmrzStatus.DataPropertyName = "Status";
            this.gridmrzStatus.HeaderText = "状态";
            this.gridmrzStatus.Name = "gridmrzStatus";
            this.gridmrzStatus.Visible = true;
            // 
            //  gridcboOnLevel
            // 
            this.gridcboOnLevel.DataPropertyName = "OnLevel";
            this.gridcboOnLevel.HeaderText = "项目等级";
            this.gridcboOnLevel.Name = "gridcboOnLevel";
      this.gridcboOnLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridcboOnLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridcboOnLevel.Visible = true;
            // 
            //  gridmrzRemark
            // 
            this.gridmrzRemark.DataPropertyName = "Remark";
            this.gridmrzRemark.HeaderText = "备注";
            this.gridmrzRemark.Name = "gridmrzRemark";
            this.gridmrzRemark.Visible = true;
            // 
            //  gridmrzSort
            // 
            this.gridmrzSort.DataPropertyName = "Sort";
            this.gridmrzSort.HeaderText = "排序";
            this.gridmrzSort.Name = "gridmrzSort";
            this.gridmrzSort.Visible = true;
            // 
            //  gridmrzDeptId
            // 
            this.gridmrzDeptId.DataPropertyName = "DeptId";
            this.gridmrzDeptId.HeaderText = "部门ID";
            this.gridmrzDeptId.Name = "gridmrzDeptId";
            this.gridmrzDeptId.Visible = true;
            // 
            //  gridmrzCompanyID
            // 
            this.gridmrzCompanyID.DataPropertyName = "CompanyID";
            this.gridmrzCompanyID.HeaderText = "公司ID";
            this.gridmrzCompanyID.Name = "gridmrzCompanyID";
            this.gridmrzCompanyID.Visible = true;
            // 
            //  gridmrzCreateDate
            // 
            this.gridmrzCreateDate.DataPropertyName = "CreateDate";
            this.gridmrzCreateDate.HeaderText = "创建时间";
            this.gridmrzCreateDate.Name = "gridmrzCreateDate";
            this.gridmrzCreateDate.Visible = true;
            // 
            //  gridcboCategory
            // 
            this.gridcboCategory.DataPropertyName = "Category";
            this.gridcboCategory.HeaderText = "项目类型";
            this.gridcboCategory.Name = "gridcboCategory";
      this.gridcboCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridcboCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridcboCategory.Visible = true;
            // 
            //  gridmrzCreateUser
            // 
            this.gridmrzCreateUser.DataPropertyName = "CreateUser";
            this.gridmrzCreateUser.HeaderText = "创建人";
            this.gridmrzCreateUser.Name = "gridmrzCreateUser";
            this.gridmrzCreateUser.Visible = true;
            // 
            //  gridmrzEditDate
            // 
            this.gridmrzEditDate.DataPropertyName = "EditDate";
            this.gridmrzEditDate.HeaderText = "编辑时间";
            this.gridmrzEditDate.Name = "gridmrzEditDate";
            this.gridmrzEditDate.Visible = true;
            // 
            //  gridmrzEditUser
            // 
            this.gridmrzEditUser.DataPropertyName = "EditUser";
            this.gridmrzEditUser.HeaderText = "编辑人";
            this.gridmrzEditUser.Name = "gridmrzEditUser";
            this.gridmrzEditUser.Visible = true;
            // Pager
            // 
            this.Pager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pager.Font = new System.Drawing.Font( "微软雅黑 ", 9F);
            this.Pager.Location = new System.Drawing.Point(0, 0);
            this.Pager.Name =  "Pager ";
            this.Pager.PageIndex = 1;
            this.Pager.RecordCount = 0;
            this.Pager.Size = new System.Drawing.Size(905, 38);
            this.Pager.TabIndex = 0;
            this.Pager.PageChanged += new Nikita.WinForm.ExtendControl.PageChangedEventHandler(this.Pager_PageChanged);
            // 
            // tspCommand
            // 
            this.tspCommand.Font = new System.Drawing.Font( "微软雅黑 ", 9F);
     this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdFirst,
            this.cmdPre,
            this.cmdNext,
            this.cmdLast,
            this.cmdSep1,
            this.cmdRefresh,
            this.cmdImport,
            this.cmdCancel,
            this.cmdDelete,
            this.cmdEdit,
            this.cmdNew
     });
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.Name =  "tspCommand ";
            this.tspCommand.Size = new System.Drawing.Size(907, 26);
            this.tspCommand.TabIndex = 4;
            this.tspCommand.Text =  "toolStrip1 ";
            // 
            // cmdFirst
            // 
            this.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFirst.Name =  "cmdFirst ";
            this.cmdFirst.Size = new System.Drawing.Size(52, 23);
            this.cmdFirst.Text =  "第一条 ";
            this.cmdFirst.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdPre
            // 
            this.cmdPre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdPre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPre.Name =  "cmdPre ";
            this.cmdPre.Size = new System.Drawing.Size(52, 23);
            this.cmdPre.Text = "上一条 ";
            this.cmdPre.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNext.Name =  "cmdNext ";
            this.cmdNext.Size = new System.Drawing.Size(52, 23);
            this.cmdNext.Text =  "下一条 ";
            this.cmdNext.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLast.Name =  "cmdLast ";
            this.cmdLast.Size = new System.Drawing.Size(65, 23);
            this.cmdLast.Text =  "最后一条 ";
            this.cmdLast.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdSep1
            // 
            this.cmdSep1.Name =  "cmdSep1 ";
            this.cmdSep1.Size = new System.Drawing.Size(6, 26);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefresh.Name =  "cmdRefresh ";
            this.cmdRefresh.Size = new System.Drawing.Size(39, 23);
            this.cmdRefresh.Text =  "刷新 ";
            this.cmdRefresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.cmdRefresh.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdImportExcel});
            this.cmdImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdImport.Name =  "cmdImport ";
            this.cmdImport.Size = new System.Drawing.Size(51, 23);
            this.cmdImport.Text =  "导出 ";
            // 
            // cmdImportExcel
            // 
            this.cmdImportExcel.Name =  "cmdImportExcel ";
            this.cmdImportExcel.Size = new System.Drawing.Size(135, 24);
            this.cmdImportExcel.Text =  "导出Excel ";
            this.cmdImportExcel.Click += new System.EventHandler(this.Command_Click);
  // 
            // cmdCancel
            // 
            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancel.Name =  "cmdCancel ";
            this.cmdCancel.Size = new System.Drawing.Size(42, 22);
            this.cmdCancel.Text =  "作废 ";
            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name =  "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(42, 22);
            this.cmdDelete.Text =  "删除";
            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEdit.Name =  "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(42, 22);
            this.cmdEdit.Text =  "修改";
            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNew.Name =  "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(42, 22);
            this.cmdNew.Text =  "新增 ";
            this.cmdNew.Click += new System.EventHandler(this.Command_Click);
   // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 0;
            this.toolTip.InitialDelay = 500;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // FrmBseProjectSimpleQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 561);
            this.Controls.Add(this.sptAll);
            this.Controls.Add(this.tspCommand);
            this.Font = new System.Drawing.Font( "微软雅黑 ", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name =  "FrmBseProjectSimpleQuery ";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBseProjectSimpleQuery";
            this.sptAll.Panel1.ResumeLayout(false);
            this.sptAll.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).EndInit();
            this.sptAll.ResumeLayout(false);
            this.sptQuery.Panel1.ResumeLayout(false);
            this.sptQuery.Panel1.PerformLayout();
            this.sptQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();
            this.sptQuery.ResumeLayout(false);
            this.sptView.Panel1.ResumeLayout(false);
            this.sptView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptView)).EndInit();
            this.sptView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.SplitContainer sptAll;
        private System.Windows.Forms.SplitContainer sptQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.SplitContainer sptView;
        private System.Windows.Forms.DataGridView grdData;
        private WinForm.ExtendControl.Pager Pager;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzProjectID;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzName;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzStatus;
        public System.Windows.Forms.DataGridViewComboBoxColumn  gridcboOnLevel;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzRemark;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzSort;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzDeptId;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzCompanyID;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzCreateDate;
        public System.Windows.Forms.DataGridViewComboBoxColumn  gridcboCategory;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzCreateUser;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzEditDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzEditUser;
        private System.Windows.Forms.ToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton cmdRefresh;
        private System.Windows.Forms.ToolStripSplitButton cmdImport;
        private System.Windows.Forms.ToolStripMenuItem cmdImportExcel;
        private System.Windows.Forms.ToolStripButton cmdFirst;
        private System.Windows.Forms.ToolStripButton cmdPre;
        private System.Windows.Forms.ToolStripButton cmdNext;
        private System.Windows.Forms.ToolStripButton cmdLast;
        private System.Windows.Forms.ToolStripSeparator cmdSep1;
      private System.Windows.Forms.ToolStripButton cmdNew;
        private System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.ToolStripButton cmdEdit;
        private System.Windows.Forms.ToolStripButton cmdCancel;
 private System.Windows.Forms.ToolTip toolTip;
        public  System.Windows.Forms.Label lblQueryName;
        public System.Windows.Forms.TextBox  txtQueryName;
    }
}
