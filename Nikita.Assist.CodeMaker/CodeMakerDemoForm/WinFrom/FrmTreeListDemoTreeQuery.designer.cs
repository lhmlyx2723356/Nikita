namespace Nikita.Assist.CodeMaker
{
    partial class FrmTreeListDemoTreeQuery
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
            this.sptContainer = new System.Windows.Forms.SplitContainer();
            this.sptQuery = new System.Windows.Forms.SplitContainer();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.sptView = new System.Windows.Forms.SplitContainer();
            this.dataTreeListView = new Nikita.WinForm.ExtendControl.DataTreeListView();
            this.gridmrzId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzParentId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzName = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzValue = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzOnLevel = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzOwerCompanyId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzStatus = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzRemark = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzDept_Id = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzCompany_Id = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzCreateUser = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzCreateDate = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzEditUser = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridmrzEditDate = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.Pager = new Nikita.WinForm.ExtendControl.Pager();
            this.tspCommand = new System.Windows.Forms.ToolStrip();
            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.cmdCancel = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdEdit = new System.Windows.Forms.ToolStripButton();
            this.cmdNewSameLevel = new System.Windows.Forms.ToolStripButton();
            this.cmdNewNextLevel = new System.Windows.Forms.ToolStripButton();
this.lblQueryName = new System.Windows.Forms.Label();
            this.txtQueryName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).BeginInit();
            this.sptContainer.Panel1.SuspendLayout();
            this.sptContainer.Panel2.SuspendLayout();
            this.sptContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();
            this.sptQuery.Panel1.SuspendLayout();
            this.sptQuery.Panel2.SuspendLayout();
            this.sptQuery.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptView)).BeginInit();
            this.sptView.Panel1.SuspendLayout();
            this.sptView.Panel2.SuspendLayout();
            this.sptView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTreeListView)).BeginInit();
            this.tspCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptContainer
            // 
            this.sptContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptContainer.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.sptContainer.Location = new System.Drawing.Point(0, 25);
            this.sptContainer.Name = "sptContainer";
            this.sptContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptContainer.Panel1
            // 
            this.sptContainer.Panel1.Controls.Add(this.sptQuery);
            // 
            // sptContainer.Panel2
            // 
            this.sptContainer.Panel2.Controls.Add(this.sptView);
            this.sptContainer.Size = new System.Drawing.Size(784, 536);
            this.sptContainer.SplitterDistance = 47;
            this.sptContainer.TabIndex = 0;
            // 
            // sptQuery
            // 
            this.sptQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sptQuery.Location = new System.Drawing.Point(0, 0);
            this.sptQuery.Name = "sptQuery";
            // 
            // sptQuery.Panel1
            // 
            this.sptQuery.Panel1.Controls.Add(this.lblQueryName);
            this.sptQuery.Panel1.Controls.Add(this.txtQueryName);
            // 
            // sptQuery.Panel2
            // 
            this.sptQuery.Panel2.Controls.Add(this.grpFilter);
            this.sptQuery.Panel2.Controls.Add(this.btnQuery);
            this.sptQuery.Size = new System.Drawing.Size(784, 47);
            this.sptQuery.SplitterDistance = 592;
            this.sptQuery.TabIndex = 1;
            // 
            // grpFilter
            // 
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Location = new System.Drawing.Point(5, 3);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(117, 41);
            this.grpFilter.TabIndex = 18;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "通用过滤";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(11, 14);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 23);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(128, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(55, 28);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // sptView
            // 
            this.sptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptView.Location = new System.Drawing.Point(0, 0);
            this.sptView.Name = "sptView";
            this.sptView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptView.Panel1
            // 
            this.sptView.Panel1.Controls.Add(this.dataTreeListView);
            // 
            // sptView.Panel2
            // 
            this.sptView.Panel2.Controls.Add(this.Pager);
            this.sptView.Size = new System.Drawing.Size(784, 485);
            this.sptView.SplitterDistance = 434;
            this.sptView.TabIndex = 2;
            // 
            // dataTreeListView
            // 
            this.dataTreeListView.AllColumns.Add(this.gridmrzId);
            this.dataTreeListView.AllColumns.Add(this.gridmrzParentId);
            this.dataTreeListView.AllColumns.Add(this.gridmrzName);
            this.dataTreeListView.AllColumns.Add(this.gridmrzValue);
            this.dataTreeListView.AllColumns.Add(this.gridmrzOnLevel);
            this.dataTreeListView.AllColumns.Add(this.gridmrzOwerCompanyId);
            this.dataTreeListView.AllColumns.Add(this.gridmrzStatus);
            this.dataTreeListView.AllColumns.Add(this.gridmrzRemark);
            this.dataTreeListView.AllColumns.Add(this.gridmrzDept_Id);
            this.dataTreeListView.AllColumns.Add(this.gridmrzCompany_Id);
            this.dataTreeListView.AllColumns.Add(this.gridmrzCreateUser);
            this.dataTreeListView.AllColumns.Add(this.gridmrzCreateDate);
            this.dataTreeListView.AllColumns.Add(this.gridmrzEditUser);
            this.dataTreeListView.AllColumns.Add(this.gridmrzEditDate);
            this.dataTreeListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gridmrzId,
            this.gridmrzParentId,
            this.gridmrzName,
            this.gridmrzValue,
            this.gridmrzOnLevel,
            this.gridmrzOwerCompanyId,
            this.gridmrzStatus,
            this.gridmrzRemark,
            this.gridmrzDept_Id,
            this.gridmrzCompany_Id,
            this.gridmrzCreateUser,
            this.gridmrzCreateDate,
            this.gridmrzEditUser,
            this.gridmrzEditDate
     });
            this.dataTreeListView.DataSource = null;
            this.dataTreeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTreeListView.FullRowSelect = true;
            this.dataTreeListView.KeyAspectName = "Id";
            this.dataTreeListView.Location = new System.Drawing.Point(0, 0);
            this.dataTreeListView.Name = "dataTreeListView";
            this.dataTreeListView.OwnerDraw = true;
            this.dataTreeListView.ParentKeyAspectName = "ParentId";
            this.dataTreeListView.RootKeyValueString = "";
            this.dataTreeListView.ShowGroups = false;
            this.dataTreeListView.ShowKeyColumns = false;
            this.dataTreeListView.Size = new System.Drawing.Size(784, 434);
            this.dataTreeListView.TabIndex = 3;
            this.dataTreeListView.UseCompatibleStateImageBehavior = false;
            this.dataTreeListView.UseFilterIndicator = true;
            this.dataTreeListView.UseFiltering = true;
            this.dataTreeListView.View = System.Windows.Forms.View.Details;
            this.dataTreeListView.VirtualMode = true;
            this.dataTreeListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataTreeListView_MouseDoubleClick);
            // 
            // gridmrzId
            // 
            this.gridmrzId.AspectName = "Id";
            this.gridmrzId.Text = "序号";
            // 
            // gridmrzParentId
            // 
            this.gridmrzParentId.AspectName = "ParentId";
            this.gridmrzParentId.Text = "父级";
            // 
            // gridmrzName
            // 
            this.gridmrzName.AspectName = "Name";
            this.gridmrzName.Text = "名称";
            // 
            // gridmrzValue
            // 
            this.gridmrzValue.AspectName = "Value";
            this.gridmrzValue.Text = "值";
            // 
            // gridmrzOnLevel
            // 
            this.gridmrzOnLevel.AspectName = "OnLevel";
            this.gridmrzOnLevel.Text = "等级";
            // 
            // gridmrzOwerCompanyId
            // 
            this.gridmrzOwerCompanyId.AspectName = "OwerCompanyId";
            this.gridmrzOwerCompanyId.Text = "所属公司";
            // 
            // gridmrzStatus
            // 
            this.gridmrzStatus.AspectName = "Status";
            this.gridmrzStatus.Text = "状态";
            // 
            // gridmrzRemark
            // 
            this.gridmrzRemark.AspectName = "Remark";
            this.gridmrzRemark.Text = "备注";
            // 
            // gridmrzDept_Id
            // 
            this.gridmrzDept_Id.AspectName = "Dept_Id";
            this.gridmrzDept_Id.Text = "DeptID";
            // 
            // gridmrzCompany_Id
            // 
            this.gridmrzCompany_Id.AspectName = "Company_Id";
            this.gridmrzCompany_Id.Text = "Company_Id";
            // 
            // gridmrzCreateUser
            // 
            this.gridmrzCreateUser.AspectName = "CreateUser";
            this.gridmrzCreateUser.Text = "CreateUser";
            // 
            // gridmrzCreateDate
            // 
            this.gridmrzCreateDate.AspectName = "CreateDate";
            this.gridmrzCreateDate.Text = "CreateDate";
            // 
            // gridmrzEditUser
            // 
            this.gridmrzEditUser.AspectName = "EditUser";
            this.gridmrzEditUser.Text = "EditUser";
            // 
            // gridmrzEditDate
            // 
            this.gridmrzEditDate.AspectName = "EditDate";
            this.gridmrzEditDate.Text = "EditDate";
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
            this.Pager.Size = new System.Drawing.Size(784, 47);
            this.Pager.TabIndex = 1;
            this.Pager.PageChanged += new Nikita.WinForm.ExtendControl.PageChangedEventHandler(this.Pager_PageChanged);
            // 
            // tspCommand
            // 
            this.tspCommand.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRefresh,
            this.cmdCancel,
            this.cmdDelete,
            this.cmdEdit,
            this.cmdNewSameLevel,
            this.cmdNewNextLevel});
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspCommand.Size = new System.Drawing.Size(784, 25);
            this.tspCommand.TabIndex = 6;
            this.tspCommand.Text = "toolStrip1 ";
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
            this.cmdEdit.Text ="修改";
            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNewSameLevel
            // 
            this.cmdNewSameLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNewSameLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNewSameLevel.Name = "cmdNewSameLevel";
            this.cmdNewSameLevel.Size = new System.Drawing.Size(72, 22);
            this.cmdNewSameLevel.Text = "新增同级";
            this.cmdNewSameLevel.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNewNextLevel
            // 
            this.cmdNewNextLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNewNextLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNewNextLevel.Name = "cmdNewNextLevel";
            this.cmdNewNextLevel.Size = new System.Drawing.Size(72, 22);
            this.cmdNewNextLevel.Text = "新增下级";
            this.cmdNewNextLevel.Click += new System.EventHandler(this.Command_Click);
     this.lblQueryName.Location = new System.Drawing.Point(15, 15);
            this.lblQueryName.Name = "lblQueryName";
            this.lblQueryName.Size = new System.Drawing.Size(50, 16);
            this.lblQueryName.TabIndex = 1;
            this.lblQueryName.Text ="名称";
            // 
            // txtQueryName
            // 
            this.txtQueryName.Location = new System.Drawing.Point(70, 15);
            this.txtQueryName.Name =  "txtQueryName";
            this.txtQueryName.Size = new System.Drawing.Size(130, 20);
            this.txtQueryName.TabIndex = 1;

            // 
            // FrmTreeListDemoTreeQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.sptContainer);
            this.Controls.Add(this.tspCommand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmTreeListDemoTreeQuery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text =  "FrmTreeListDemoTreeQuery";
            this.sptContainer.Panel1.ResumeLayout(false);
            this.sptContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).EndInit();
            this.sptContainer.ResumeLayout(false);
            this.sptQuery.Panel1.ResumeLayout(false);
            this.sptQuery.Panel1.PerformLayout();
            this.sptQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();
            this.sptQuery.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.sptView.Panel1.ResumeLayout(false);
            this.sptView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptView)).EndInit();
            this.sptView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTreeListView)).EndInit();
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.SplitContainer sptContainer;
        private System.Windows.Forms.SplitContainer sptQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton cmdRefresh;
        private System.Windows.Forms.ToolStripButton cmdCancel;
        private System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.ToolStripButton cmdEdit;
        private System.Windows.Forms.ToolStripButton cmdNewSameLevel;
        private System.Windows.Forms.ToolStripButton cmdNewNextLevel;
        private System.Windows.Forms.SplitContainer sptView;
        private WinForm.ExtendControl.DataTreeListView dataTreeListView;
        public WinForm.ExtendControl.OLVColumn  gridmrzId;
        public WinForm.ExtendControl.OLVColumn  gridmrzParentId;
        public WinForm.ExtendControl.OLVColumn  gridmrzName;
        public WinForm.ExtendControl.OLVColumn  gridmrzValue;
        public WinForm.ExtendControl.OLVColumn  gridmrzOnLevel;
        public WinForm.ExtendControl.OLVColumn  gridmrzOwerCompanyId;
        public WinForm.ExtendControl.OLVColumn  gridmrzStatus;
        public WinForm.ExtendControl.OLVColumn  gridmrzRemark;
        public WinForm.ExtendControl.OLVColumn  gridmrzDept_Id;
        public WinForm.ExtendControl.OLVColumn  gridmrzCompany_Id;
        public WinForm.ExtendControl.OLVColumn  gridmrzCreateUser;
        public WinForm.ExtendControl.OLVColumn  gridmrzCreateDate;
        public WinForm.ExtendControl.OLVColumn  gridmrzEditUser;
        public WinForm.ExtendControl.OLVColumn  gridmrzEditDate;
        private WinForm.ExtendControl.Pager Pager;
        public  System.Windows.Forms.Label lblQueryName;
        public System.Windows.Forms.TextBox  txtQueryName;
    }
}
