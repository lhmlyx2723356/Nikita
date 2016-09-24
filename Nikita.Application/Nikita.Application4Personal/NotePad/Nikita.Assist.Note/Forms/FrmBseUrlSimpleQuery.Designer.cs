namespace Nikita.Assist.Note
{
    partial class FrmBseUrlSimpleQuery
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
            this.lblQueryType = new System.Windows.Forms.Label();
            this.cboQueryType = new System.Windows.Forms.ComboBox();
            this.lblQueryUrlContent = new System.Windows.Forms.Label();
            this.txtQueryUrlContent = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.sptView = new System.Windows.Forms.SplitContainer();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.gridmrzId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzUrlTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzUrlContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmrzCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.sptQuery.Panel1.Controls.Add(this.lblQueryType);
            this.sptQuery.Panel1.Controls.Add(this.cboQueryType);
            this.sptQuery.Panel1.Controls.Add(this.lblQueryUrlContent);
            this.sptQuery.Panel1.Controls.Add(this.txtQueryUrlContent);
            // 
            // sptQuery.Panel2
            // 
            this.sptQuery.Panel2.Controls.Add(this.btnQuery);
            this.sptQuery.Size = new System.Drawing.Size(907, 61);
            this.sptQuery.SplitterDistance = 781;
            this.sptQuery.SplitterWidth = 5;
            this.sptQuery.TabIndex = 2;
            this.sptQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblQueryType
            // 
            this.lblQueryType.Location = new System.Drawing.Point(15, 15);
            this.lblQueryType.Name = "lblQueryType";
            this.lblQueryType.Size = new System.Drawing.Size(60, 16);
            this.lblQueryType.TabIndex = 1;
            this.lblQueryType.Text = "类别";
            // 
            // cboQueryType
            // 
            this.cboQueryType.Location = new System.Drawing.Point(76, 15);
            this.cboQueryType.Name = "cboQueryType";
            this.cboQueryType.Size = new System.Drawing.Size(130, 23);
            this.cboQueryType.TabIndex = 2;
            // 
            // lblQueryUrlContent
            // 
            this.lblQueryUrlContent.Location = new System.Drawing.Point(217, 15);
            this.lblQueryUrlContent.Name = "lblQueryUrlContent";
            this.lblQueryUrlContent.Size = new System.Drawing.Size(60, 16);
            this.lblQueryUrlContent.TabIndex = 1;
            this.lblQueryUrlContent.Text = "内容";
            // 
            // txtQueryUrlContent
            // 
            this.txtQueryUrlContent.Location = new System.Drawing.Point(278, 15);
            this.txtQueryUrlContent.Name = "txtQueryUrlContent";
            this.txtQueryUrlContent.Size = new System.Drawing.Size(130, 21);
            this.txtQueryUrlContent.TabIndex = 5;
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
            this.gridmrzId,
            this.gridmrzType,
            this.gridmrzUrlTitle,
            this.gridmrzUrl,
            this.gridmrzUrlContent,
            this.gridmrzRemark,
            this.gridmrzStatus,
            this.gridmrzCreateDate});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.RowHeadersWidth = 50;
            this.grdData.RowTemplate.Height = 23;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(905, 423);
            this.grdData.TabIndex = 0;
            // 
            // gridmrzId
            // 
            this.gridmrzId.DataPropertyName = "Id";
            this.gridmrzId.HeaderText = "序号";
            this.gridmrzId.Name = "gridmrzId";
            // 
            // gridmrzType
            // 
            this.gridmrzType.DataPropertyName = "Type";
            this.gridmrzType.HeaderText = "类别";
            this.gridmrzType.Name = "gridmrzType";
            // 
            // gridmrzUrlTitle
            // 
            this.gridmrzUrlTitle.DataPropertyName = "UrlTitle";
            this.gridmrzUrlTitle.HeaderText = "标题";
            this.gridmrzUrlTitle.Name = "gridmrzUrlTitle";
            // 
            // gridmrzUrl
            // 
            this.gridmrzUrl.DataPropertyName = "Url";
            this.gridmrzUrl.HeaderText = "网址";
            this.gridmrzUrl.Name = "gridmrzUrl";
            // 
            // gridmrzUrlContent
            // 
            this.gridmrzUrlContent.DataPropertyName = "UrlContent";
            this.gridmrzUrlContent.HeaderText = "网址内容";
            this.gridmrzUrlContent.Name = "gridmrzUrlContent";
            // 
            // gridmrzRemark
            // 
            this.gridmrzRemark.DataPropertyName = "Remark";
            this.gridmrzRemark.HeaderText = "备注";
            this.gridmrzRemark.Name = "gridmrzRemark";
            // 
            // gridmrzStatus
            // 
            this.gridmrzStatus.DataPropertyName = "Status";
            this.gridmrzStatus.HeaderText = "状态";
            this.gridmrzStatus.Name = "gridmrzStatus";
            // 
            // gridmrzCreateDate
            // 
            this.gridmrzCreateDate.DataPropertyName = "CreateDate";
            this.gridmrzCreateDate.HeaderText = "创建时间";
            this.gridmrzCreateDate.Name = "gridmrzCreateDate";
            // 
            // Pager
            // 
            this.Pager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pager.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
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
            this.tspCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
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
            this.cmdFirst.Size = new System.Drawing.Size(50, 22);
            this.cmdFirst.Text = "第一条 ";
            this.cmdFirst.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdPre
            // 
            this.cmdPre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdPre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPre.Name = "cmdPre";
            this.cmdPre.Size = new System.Drawing.Size(50, 22);
            this.cmdPre.Text = "上一条 ";
            this.cmdPre.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(50, 22);
            this.cmdNext.Text = "下一条 ";
            this.cmdNext.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.Size = new System.Drawing.Size(62, 22);
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
            this.cmdRefresh.Size = new System.Drawing.Size(38, 22);
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
            this.cmdImport.Size = new System.Drawing.Size(50, 22);
            this.cmdImport.Text = "导出 ";
            // 
            // cmdImportExcel
            // 
            this.cmdImportExcel.Name = "cmdImportExcel";
            this.cmdImportExcel.Size = new System.Drawing.Size(131, 22);
            this.cmdImportExcel.Text = "导出Excel ";
            this.cmdImportExcel.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(38, 22);
            this.cmdCancel.Text = "作废 ";
            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(35, 22);
            this.cmdDelete.Text = "删除";
            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(35, 22);
            this.cmdEdit.Text = "修改";
            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(38, 22);
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
            // FrmBseUrlSimpleQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 561);
            this.Controls.Add(this.sptAll);
            this.Controls.Add(this.tspCommand);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmBseUrlSimpleQuery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBseUrlSimpleQuery";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBseUrlSimpleQuery_FormClosed);
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
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzId;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzType;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzUrlTitle;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzUrl;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzUrlContent;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzRemark;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzStatus;
        public System.Windows.Forms.DataGridViewTextBoxColumn  gridmrzCreateDate;
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
        public  System.Windows.Forms.Label lblQueryType;
        public System.Windows.Forms.ComboBox  cboQueryType;
        public  System.Windows.Forms.Label lblQueryUrlContent;
        public System.Windows.Forms.TextBox  txtQueryUrlContent;
    }
}
