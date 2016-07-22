namespace Nikita.Assist.CodeMaker
{
    partial class FrmOrderMasterMasterDetailQuery
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
           this.sptAll = new System.Windows.Forms.SplitContainer();
            this.sptQuery = new System.Windows.Forms.SplitContainer();
this.lblQueryOrderNumber = new System.Windows.Forms.Label();
            this.txtQueryOrderNumber = new System.Windows.Forms.TextBox();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.sptMasterDetail = new System.Windows.Forms.SplitContainer();
            this.sptMaster = new System.Windows.Forms.SplitContainer();
            this.grpMaster = new System.Windows.Forms.GroupBox();
            this.objListViewMaster = new Nikita.WinForm.ExtendControl.FastObjectListView();
            this.gridmrzOrderId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzOrderNumber = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzStatus = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzCreateDate = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.Pager = new Nikita.WinForm.ExtendControl.Pager();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.objListViewDetail = new Nikita.WinForm.ExtendControl.FastObjectListView();
            this.gridDetailmrzDetailId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzOrderId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzCustomer = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzProductName = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzAmount = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzSumMoney = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzStatus = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.tspCommand = new System.Windows.Forms.ToolStrip();
            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.cmdCancel = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdEdit = new System.Windows.Forms.ToolStripButton();
            this.cmdNew = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).BeginInit();
            this.sptAll.Panel1.SuspendLayout();
            this.sptAll.Panel2.SuspendLayout();
            this.sptAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();
            this.sptQuery.Panel1.SuspendLayout();
            this.sptQuery.Panel2.SuspendLayout();
            this.sptQuery.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMasterDetail)).BeginInit();
            this.sptMasterDetail.Panel1.SuspendLayout();
            this.sptMasterDetail.Panel2.SuspendLayout();
            this.sptMasterDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMaster)).BeginInit();
            this.sptMaster.Panel1.SuspendLayout();
            this.sptMaster.Panel2.SuspendLayout();
            this.sptMaster.SuspendLayout();
            this.grpMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListViewMaster)).BeginInit();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).BeginInit();
            this.tspCommand.SuspendLayout();
            this.SuspendLayout();
   // 
            // sptAll
            // 
            this.sptAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptAll.Location = new System.Drawing.Point(0, 26);
            this.sptAll.Name = "sptAll";
            this.sptAll.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptAll.Panel1
            // 
            this.sptAll.Panel1.Controls.Add(this.sptQuery);
            // 
            // sptAll.Panel2
            // 
            this.sptAll.Panel2.Controls.Add(this.sptMasterDetail);
            this.sptAll.Size = new System.Drawing.Size(784, 535);
            this.sptAll.SplitterDistance = 57;
            this.sptAll.TabIndex = 0;
            // 
            // sptQuery
            // 
            this.sptQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sptQuery.Location = new System.Drawing.Point(0, 0);
            this.sptQuery.Name = "sptQuery";
            // 
            // sptQuery.Panel1
            // 
            this.sptQuery.Panel1.Controls.Add(this.lblQueryOrderNumber);
            this.sptQuery.Panel1.Controls.Add(this.txtQueryOrderNumber);
            // 
            // sptQuery.Panel2
            // 
            this.sptQuery.Panel2.Controls.Add(this.grpFilter);
            this.sptQuery.Panel2.Controls.Add(this.btnQuery);
            this.sptQuery.Size = new System.Drawing.Size(784, 57);
            this.sptQuery.SplitterDistance = 489;
            this.sptQuery.TabIndex = 2;
     this.lblQueryOrderNumber.Location = new System.Drawing.Point(15, 15);
            this.lblQueryOrderNumber.Name = "lblQueryOrderNumber";
            this.lblQueryOrderNumber.Size = new System.Drawing.Size(50, 16);
            this.lblQueryOrderNumber.TabIndex = 1;
            this.lblQueryOrderNumber.Text ="单号";
            // 
            // txtQueryOrderNumber
            // 
            this.txtQueryOrderNumber.Location = new System.Drawing.Point(70, 15);
            this.txtQueryOrderNumber.Name =  "txtQueryOrderNumber";
            this.txtQueryOrderNumber.Size = new System.Drawing.Size(130, 20);
            this.txtQueryOrderNumber.TabIndex = 1;

            // 
            // grpFilter
            // 
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilter.Controls.Add(this.cboFilterType);
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Location = new System.Drawing.Point(7, 3);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(214, 50);
            this.grpFilter.TabIndex = 21;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text ="通用查询";
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Items.AddRange(new object[] {
            "Any text",
            "Prefix",
            "Regex"});
            this.cboFilterType.Location = new System.Drawing.Point(114, 17);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(94, 25);
            this.cboFilterType.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(7, 17);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 23);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(227, 17);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(55, 28);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // sptMasterDetail
            // 
            this.sptMasterDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptMasterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMasterDetail.Location = new System.Drawing.Point(0, 0);
            this.sptMasterDetail.Name = "sptMasterDetail";
            this.sptMasterDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptMasterDetail.Panel1
            // 
            this.sptMasterDetail.Panel1.Controls.Add(this.sptMaster);
            // 
            // sptMasterDetail.Panel2
            // 
            this.sptMasterDetail.Panel2.Controls.Add(this.grpDetail);
            this.sptMasterDetail.Size = new System.Drawing.Size(784, 474);
            this.sptMasterDetail.SplitterDistance = 271;
            this.sptMasterDetail.TabIndex = 0;
            // 
            // sptMaster
            // 
            this.sptMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMaster.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sptMaster.Location = new System.Drawing.Point(0, 0);
            this.sptMaster.Name = "sptMaster";
            this.sptMaster.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptMaster.Panel1
            // 
            this.sptMaster.Panel1.Controls.Add(this.grpMaster);
            // 
            // sptMaster.Panel2
            // 
            this.sptMaster.Panel2.Controls.Add(this.Pager);
            this.sptMaster.Size = new System.Drawing.Size(784, 271);
            this.sptMaster.SplitterDistance = 226;
            this.sptMaster.TabIndex = 0;
            // 
            // grpMaster
            // 
            this.grpMaster.Controls.Add(this.objListViewMaster);
            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpMaster.Location = new System.Drawing.Point(0, 0);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(782, 224);
            this.grpMaster.TabIndex = 0;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "主表信息";
            // 
            // objListViewMaster
            // 
            this.objListViewMaster.AllColumns.Add(this.gridmrzOrderId);
            this.objListViewMaster.AllColumns.Add(this.gridmrzOrderNumber);
            this.objListViewMaster.AllColumns.Add(this.gridmrzStatus);
            this.objListViewMaster.AllColumns.Add(this.gridmrzCreateDate);
            this.objListViewMaster.AllowColumnReorder = true;
            this.objListViewMaster.BackColor = System.Drawing.SystemColors.Control;
            this.objListViewMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objListViewMaster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gridmrzOrderId,
            this.gridmrzOrderNumber,
            this.gridmrzStatus,
            this.gridmrzCreateDate
});
            this.objListViewMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objListViewMaster.FullRowSelect = true;
            this.objListViewMaster.GridLines = true;
            this.objListViewMaster.HideSelection = false;
            this.objListViewMaster.Location = new System.Drawing.Point(3, 19);
            this.objListViewMaster.Name = "objListViewMaster";
            this.objListViewMaster.OwnerDraw = true;
            this.objListViewMaster.SelectColumnsOnRightClickBehaviour = Nikita.WinForm.ExtendControl.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.objListViewMaster.ShowCommandMenuOnRightClick = true;
            this.objListViewMaster.ShowGroups = false;
            this.objListViewMaster.Size = new System.Drawing.Size(776, 202);
            this.objListViewMaster.TabIndex = 0;
            this.objListViewMaster.UseCompatibleStateImageBehavior = false;
            this.objListViewMaster.UseFilterIndicator = true;
            this.objListViewMaster.UseFiltering = true;
            this.objListViewMaster.View = System.Windows.Forms.View.Details;
            this.objListViewMaster.VirtualMode = true;
            this.objListViewMaster.SelectedIndexChanged += new System.EventHandler(this.objListViewMaster_SelectedIndexChanged);
            this.objListViewMaster.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objListViewMaster_MouseDoubleClick);
            // 
            // gridmrzOrderId
            // 
            this.gridmrzOrderId.AspectName = "OrderId";
            this.gridmrzOrderId.Text = "ID";
            // 
            // gridmrzOrderNumber
            // 
            this.gridmrzOrderNumber.AspectName = "OrderNumber";
            this.gridmrzOrderNumber.Text = "单号";
            // 
            // gridmrzStatus
            // 
            this.gridmrzStatus.AspectName = "Status";
            this.gridmrzStatus.Text = "状态";
            // 
            // gridmrzCreateDate
            // 
            this.gridmrzCreateDate.AspectName = "CreateDate";
            this.gridmrzCreateDate.Text = "创建时间";
            // 
            // Pager
            // 
            this.Pager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pager.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Pager.Location = new System.Drawing.Point(13, 3);
            this.Pager.Name = "Pager";
            this.Pager.PageIndex = 1;
            this.Pager.RecordCount = 0;
            this.Pager.Size = new System.Drawing.Size(735, 34);
            this.Pager.TabIndex = 1;
            this.Pager.PageChanged += new Nikita.WinForm.ExtendControl.PageChangedEventHandler(this.Pager_PageChanged);
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.objListViewDetail);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpDetail.Location = new System.Drawing.Point(0, 0);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(782, 197);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "明细信息";
            // 
            // objListViewDetail
            // 
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzDetailId);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzOrderId);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzCustomer);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzProductName);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzAmount);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzSumMoney);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzStatus);
            this.objListViewDetail.AllowColumnReorder = true;
            this.objListViewDetail.BackColor = System.Drawing.SystemColors.Control;
            this.objListViewDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objListViewDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gridDetailmrzDetailId,
            this.gridDetailmrzOrderId,
            this.gridDetailmrzCustomer,
            this.gridDetailmrzProductName,
            this.gridDetailmrzAmount,
            this.gridDetailmrzSumMoney,
            this.gridDetailmrzStatus
});
            this.objListViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objListViewDetail.FullRowSelect = true;
            this.objListViewDetail.GridLines = true;
            this.objListViewDetail.HideSelection = false;
            this.objListViewDetail.Location = new System.Drawing.Point(3, 19);
            this.objListViewDetail.Name = "objListViewDetail";
            this.objListViewDetail.OwnerDraw = true;
            this.objListViewDetail.SelectColumnsOnRightClickBehaviour = Nikita.WinForm.ExtendControl.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.objListViewDetail.ShowCommandMenuOnRightClick = true;
            this.objListViewDetail.ShowGroups = false;
            this.objListViewDetail.ShowItemToolTips = true;
            this.objListViewDetail.Size = new System.Drawing.Size(776, 175);
            this.objListViewDetail.TabIndex = 1;
            this.objListViewDetail.UseCompatibleStateImageBehavior = false;
            this.objListViewDetail.UseFilterIndicator = true;
            this.objListViewDetail.UseFiltering = true;
            this.objListViewDetail.View = System.Windows.Forms.View.Details;
            this.objListViewDetail.VirtualMode = true;
            // 
            // gridDetailmrzDetailId
            // 
            this.gridDetailmrzDetailId.AspectName = "DetailId";
            this.gridDetailmrzDetailId.Text = "明细ID";
            // 
            // gridDetailmrzOrderId
            // 
            this.gridDetailmrzOrderId.AspectName = "OrderId";
            this.gridDetailmrzOrderId.Text = "主表ID";
            // 
            // gridDetailmrzCustomer
            // 
            this.gridDetailmrzCustomer.AspectName = "Customer";
            this.gridDetailmrzCustomer.Text = "客户";
            // 
            // gridDetailmrzProductName
            // 
            this.gridDetailmrzProductName.AspectName = "ProductName";
            this.gridDetailmrzProductName.Text = "产品";
            // 
            // gridDetailmrzAmount
            // 
            this.gridDetailmrzAmount.AspectName = "Amount";
            this.gridDetailmrzAmount.Text = "数量";
            // 
            // gridDetailmrzSumMoney
            // 
            this.gridDetailmrzSumMoney.AspectName = "SumMoney";
            this.gridDetailmrzSumMoney.Text = "金额";
            // 
            // gridDetailmrzStatus
            // 
            this.gridDetailmrzStatus.AspectName = "Status";
            this.gridDetailmrzStatus.Text = "状态";
            // 
            // tspCommand
            // 
            this.tspCommand.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRefresh,
            this.cmdCancel,
            this.cmdDelete,
            this.cmdEdit,
            this.cmdNew});
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspCommand.Size = new System.Drawing.Size(784, 26);
            this.tspCommand.TabIndex = 7;
            this.tspCommand.Text = "toolStrip1 ";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(43, 23);
            this.cmdRefresh.Text = "刷新 ";
            this.cmdRefresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.cmdRefresh.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(43, 23);
            this.cmdCancel.Text = "作废 ";
            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(39, 23);
            this.cmdDelete.Text = "删除";
            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(39, 23);
            this.cmdEdit.Text = "修改";
            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(39, 23);
            this.cmdNew.Text = "新增";
            this.cmdNew.Click += new System.EventHandler(this.Command_Click);
            // 
            // FrmOrderMasterMasterDetailQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.sptAll);
            this.Controls.Add(this.tspCommand);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmOrderMasterMasterDetailQuery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrderMasterMasterDetailQuery";
            this.sptAll.Panel1.ResumeLayout(false);
            this.sptAll.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).EndInit();
            this.sptAll.ResumeLayout(false);
            this.sptQuery.Panel1.ResumeLayout(false);
            this.sptQuery.Panel1.PerformLayout();
            this.sptQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();
            this.sptQuery.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.sptMasterDetail.Panel1.ResumeLayout(false);
            this.sptMasterDetail.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMasterDetail)).EndInit();
            this.sptMasterDetail.ResumeLayout(false);
            this.sptMaster.Panel1.ResumeLayout(false);
            this.sptMaster.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMaster)).EndInit();
            this.sptMaster.ResumeLayout(false);
            this.grpMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objListViewMaster)).EndInit();
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).EndInit();
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
private System.Windows.Forms.SplitContainer sptAll;
        private System.Windows.Forms.SplitContainer sptMasterDetail;
        private System.Windows.Forms.SplitContainer sptMaster;
        private System.Windows.Forms.GroupBox grpMaster;
        private System.Windows.Forms.SplitContainer sptQuery;
        public  System.Windows.Forms.Label lblQueryOrderNumber;
        public System.Windows.Forms.TextBox  txtQueryOrderNumber;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton cmdRefresh;
        private System.Windows.Forms.ToolStripButton cmdCancel;
        private System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.ToolStripButton cmdEdit;
        private System.Windows.Forms.ToolStripButton cmdNew;
        private WinForm.ExtendControl.Pager Pager;
        private System.Windows.Forms.GroupBox grpDetail;
        private WinForm.ExtendControl.FastObjectListView objListViewMaster;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.TextBox txtFilter;
        public WinForm.ExtendControl.OLVColumn  gridmrzOrderId;
        public WinForm.ExtendControl.OLVColumn  gridmrzOrderNumber;
        public WinForm.ExtendControl.OLVColumn  gridmrzStatus;
        public WinForm.ExtendControl.OLVColumn  gridmrzCreateDate;
        private WinForm.ExtendControl.FastObjectListView objListViewDetail;
        public WinForm.ExtendControl.OLVColumn  gridDetailmrzDetailId;
        public WinForm.ExtendControl.OLVColumn  gridDetailmrzOrderId;
        public WinForm.ExtendControl.OLVColumn  gridDetailmrzCustomer;
        public WinForm.ExtendControl.OLVColumn  gridDetailmrzProductName;
        public WinForm.ExtendControl.OLVColumn  gridDetailmrzAmount;
        public WinForm.ExtendControl.OLVColumn  gridDetailmrzSumMoney;
        public WinForm.ExtendControl.OLVColumn  gridDetailmrzStatus;
    }
}
