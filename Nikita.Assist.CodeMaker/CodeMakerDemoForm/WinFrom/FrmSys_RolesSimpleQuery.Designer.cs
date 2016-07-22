namespace Nikita.Assist.CodeMaker
{
    partial class FrmSys_RolesSimpleQuery
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
            this.sptAll = new System.Windows.Forms.SplitContainer();
            this.sptQuery = new System.Windows.Forms.SplitContainer();
            this.lblQueryRoleName = new System.Windows.Forms.Label();
            this.txtQueryRoleName = new System.Windows.Forms.TextBox();
            this.lblQuerySortnum = new System.Windows.Forms.Label();
            this.txtQuerySortnum = new System.Windows.Forms.TextBox();
            this.lblQueryRemark = new System.Windows.Forms.Label();
            this.cbkQueryRemark = new Nikita.WinForm.ExtendControl.CheckedComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.sptView = new System.Windows.Forms.SplitContainer();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.gridmrzKeyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcboSortnum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridmrzRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzisDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.sptAll.Location = new System.Drawing.Point(0, 25);
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
            this.sptAll.Size = new System.Drawing.Size(907, 536);
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
            this.sptQuery.Name = "sptQuery";
            // 
            // sptQuery.Panel1
            // 
            this.sptQuery.Panel1.Controls.Add(this.lblQueryRoleName);
            this.sptQuery.Panel1.Controls.Add(this.txtQueryRoleName);
            this.sptQuery.Panel1.Controls.Add(this.lblQuerySortnum);
            this.sptQuery.Panel1.Controls.Add(this.txtQuerySortnum);
            this.sptQuery.Panel1.Controls.Add(this.lblQueryRemark);
            this.sptQuery.Panel1.Controls.Add(this.cbkQueryRemark);
            // 
            // sptQuery.Panel2
            // 
            this.sptQuery.Panel2.Controls.Add(this.btnQuery);
            this.sptQuery.Size = new System.Drawing.Size(907, 61);
            this.sptQuery.SplitterDistance = 780;
            this.sptQuery.SplitterWidth = 5;
            this.sptQuery.TabIndex = 2;
            this.sptQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblQueryRoleName
            // 
            this.lblQueryRoleName.Location = new System.Drawing.Point(15, 15);
            this.lblQueryRoleName.Name = "lblQueryRoleName";
            this.lblQueryRoleName.Size = new System.Drawing.Size(50, 16);
            this.lblQueryRoleName.TabIndex = 1;
            this.lblQueryRoleName.Text = "角色名称";
            // 
            // txtQueryRoleName
            // 
            this.txtQueryRoleName.Location = new System.Drawing.Point(70, 15);
            this.txtQueryRoleName.Name = "txtQueryRoleName";
            this.txtQueryRoleName.Size = new System.Drawing.Size(130, 21);
            this.txtQueryRoleName.TabIndex = 1;
            // 
            // lblQuerySortnum
            // 
            this.lblQuerySortnum.Location = new System.Drawing.Point(205, 15);
            this.lblQuerySortnum.Name = "lblQuerySortnum";
            this.lblQuerySortnum.Size = new System.Drawing.Size(50, 16);
            this.lblQuerySortnum.TabIndex = 1;
            this.lblQuerySortnum.Text = "排序";
            // 
            // txtQuerySortnum
            // 
            this.txtQuerySortnum.Location = new System.Drawing.Point(260, 15);
            this.txtQuerySortnum.Name = "txtQuerySortnum";
            this.txtQuerySortnum.Size = new System.Drawing.Size(130, 21);
            this.txtQuerySortnum.TabIndex = 5;
            // 
            // lblQueryRemark
            // 
            this.lblQueryRemark.Location = new System.Drawing.Point(395, 15);
            this.lblQueryRemark.Name = "lblQueryRemark";
            this.lblQueryRemark.Size = new System.Drawing.Size(50, 16);
            this.lblQueryRemark.TabIndex = 1;
            this.lblQueryRemark.Text = "备注";
            // 
            // cbkQueryRemark
            // 
            this.cbkQueryRemark.CheckOnClick = true;
            this.cbkQueryRemark.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbkQueryRemark.DropDownHeight = 1;
            this.cbkQueryRemark.IntegralHeight = false;
            this.cbkQueryRemark.Location = new System.Drawing.Point(450, 15);
            this.cbkQueryRemark.Name = "cbkQueryRemark";
            this.cbkQueryRemark.Size = new System.Drawing.Size(130, 22);
            this.cbkQueryRemark.TabIndex = 10;
            this.cbkQueryRemark.ValueSeparator = ",";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(31, 15);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(54, 31);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询 ";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // sptView
            // 
            this.sptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sptView.Location = new System.Drawing.Point(0, 0);
            this.sptView.Name = "sptView";
            this.sptView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptView.Panel1
            // 
            this.sptView.Panel1.Controls.Add(this.grdData);
            // 
            // sptView.Panel2
            // 
            this.sptView.Panel2.Controls.Add(this.Pager);
            this.sptView.Size = new System.Drawing.Size(907, 469);
            this.sptView.SplitterDistance = 425;
            this.sptView.TabIndex = 0;
            this.sptView.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridmrzKeyId,
            this.gridmrzRoleName,
            this.gridcboSortnum,
            this.gridmrzRemark,
            this.gridmrzisDefault});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.RowHeadersWidth = 50;
            this.grdData.RowTemplate.Height = 23;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(905, 423);
            this.grdData.TabIndex = 0;
            this.grdData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellMouseEnter);
            this.grdData.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellMouseLeave);
            // 
            // gridmrzKeyId
            // 
            this.gridmrzKeyId.DataPropertyName = "KeyId";
            this.gridmrzKeyId.HeaderText = "序号";
            this.gridmrzKeyId.Name = "gridmrzKeyId";
            // 
            // gridmrzRoleName
            // 
            this.gridmrzRoleName.DataPropertyName = "RoleName";
            this.gridmrzRoleName.HeaderText = "角色";
            this.gridmrzRoleName.Name = "gridmrzRoleName";
            // 
            // gridcboSortnum
            // 
            this.gridcboSortnum.DataPropertyName = "Sortnum";
            this.gridcboSortnum.HeaderText = "排序";
            this.gridcboSortnum.Name = "gridcboSortnum";
            this.gridcboSortnum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridcboSortnum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridmrzRemark
            // 
            this.gridmrzRemark.DataPropertyName = "Remark";
            this.gridmrzRemark.HeaderText = "备注";
            this.gridmrzRemark.Name = "gridmrzRemark";
            // 
            // gridmrzisDefault
            // 
            this.gridmrzisDefault.DataPropertyName = "isDefault";
            this.gridmrzisDefault.HeaderText = "默认";
            this.gridmrzisDefault.Name = "gridmrzisDefault";
            // 
            // Pager
            // 
            this.Pager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pager.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Pager.Location = new System.Drawing.Point(0, 0);
            this.Pager.Name = "Pager";
            this.Pager.PageIndex = 1;
            this.Pager.RecordCount = 0;
            this.Pager.Size = new System.Drawing.Size(905, 38);
            this.Pager.TabIndex = 0;
            this.Pager.PageChanged += new Nikita.WinForm.ExtendControl.PageChangedEventHandler(this.Pager_PageChanged);
            // 
            // tspCommand
            // 
            this.tspCommand.Font = new System.Drawing.Font("微软雅黑", 9F);
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
            this.cmdNew});
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspCommand.Size = new System.Drawing.Size(907, 25);
            this.tspCommand.TabIndex = 4;
            this.tspCommand.Text = "toolStrip1 ";
            // 
            // cmdFirst
            // 
            this.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFirst.Name = "cmdFirst";
            this.cmdFirst.Size = new System.Drawing.Size(60, 22);
            this.cmdFirst.Text = "第一条 ";
            this.cmdFirst.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdPre
            // 
            this.cmdPre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdPre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPre.Name = "cmdPre";
            this.cmdPre.Size = new System.Drawing.Size(60, 22);
            this.cmdPre.Text = "上一条 ";
            this.cmdPre.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(60, 22);
            this.cmdNext.Text = "下一条 ";
            this.cmdNext.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.Size = new System.Drawing.Size(75, 22);
            this.cmdLast.Text = "最后一条 ";
            this.cmdLast.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdSep1
            // 
            this.cmdSep1.Name = "cmdSep1";
            this.cmdSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(45, 22);
            this.cmdRefresh.Text = "刷新 ";
            this.cmdRefresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.cmdRefresh.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdImportExcel});
            this.cmdImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(57, 22);
            this.cmdImport.Text = "导出 ";
            // 
            // cmdImportExcel
            // 
            this.cmdImportExcel.Name = "cmdImportExcel";
            this.cmdImportExcel.Size = new System.Drawing.Size(142, 22);
            this.cmdImportExcel.Text = "导出Excel ";
            this.cmdImportExcel.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(45, 22);
            this.cmdCancel.Text = "作废 ";
            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(42, 22);
            this.cmdDelete.Text = "删除";
            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(42, 22);
            this.cmdEdit.Text = "修改";
            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(45, 22);
            this.cmdNew.Text = "新增 ";
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
            // FrmSys_RolesSimpleQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 561);
            this.Controls.Add(this.sptAll);
            this.Controls.Add(this.tspCommand);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSys_RolesSimpleQuery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSys_RolesSimpleQuery";
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
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzKeyId;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzRoleName;
        public System.Windows.Forms.DataGridViewComboBoxColumn  gridcboSortnum;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzRemark;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzisDefault;
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
        public  System.Windows.Forms.Label lblQueryRoleName;
        public System.Windows.Forms.TextBox  txtQueryRoleName;
        public  System.Windows.Forms.Label lblQuerySortnum;
        public System.Windows.Forms.TextBox  txtQuerySortnum;
        public  System.Windows.Forms.Label lblQueryRemark;
        public Nikita.WinForm.ExtendControl.CheckedComboBox  cbkQueryRemark;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
