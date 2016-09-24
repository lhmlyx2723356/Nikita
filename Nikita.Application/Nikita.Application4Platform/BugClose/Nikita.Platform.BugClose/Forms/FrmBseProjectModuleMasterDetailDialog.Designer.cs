namespace Nikita.Platform.BugClose
{
    partial class FrmBseProjectModuleMasterDetailDialog
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
            this.tspCommand = new System.Windows.Forms.ToolStrip();
            this.cmdNew = new System.Windows.Forms.ToolStripButton();
            this.cmdEdit = new System.Windows.Forms.ToolStripButton();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdCancel = new System.Windows.Forms.ToolStripButton();
            this.sptAll = new System.Windows.Forms.SplitContainer();
            this.grpMaster = new System.Windows.Forms.GroupBox();
            this.lblEditCategory = new System.Windows.Forms.Label();
            this.cboEditCategory = new System.Windows.Forms.ComboBox();
            this.lblEditName = new System.Windows.Forms.Label();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.lblEditOnLevel = new System.Windows.Forms.Label();
            this.cboEditOnLevel = new System.Windows.Forms.ComboBox();
            this.lblEditRemark = new System.Windows.Forms.Label();
            this.txtEditRemark = new System.Windows.Forms.TextBox();
            this.lblEditSort = new System.Windows.Forms.Label();
            this.txtEditSort = new System.Windows.Forms.TextBox();
            this.lblEditStatus = new System.Windows.Forms.Label();
            this.chkEditStatus = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.sptDetail = new System.Windows.Forms.SplitContainer();
            this.objListViewDetail = new Nikita.WinForm.ExtendControl.FastObjectListView();
            this.gridDetailmrzModuleID = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzProjectID = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzName = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzStatus = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzRemark = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzSort = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzDeptId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzCompanyID = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzCreateDate = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzCreateUser = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzEditDate = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzEditUser = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblDetailEditProjectID = new System.Windows.Forms.Label();
            this.cboDetailEditProjectID = new System.Windows.Forms.ComboBox();
            this.lblDetailEditName = new System.Windows.Forms.Label();
            this.txtDetailEditName = new System.Windows.Forms.TextBox();
            this.lblDetailEditRemark = new System.Windows.Forms.Label();
            this.txtDetailEditRemark = new System.Windows.Forms.TextBox();
            this.lblDetailEditSort = new System.Windows.Forms.Label();
            this.txtDetailEditSort = new System.Windows.Forms.TextBox();
            this.lblDetailEditStatus = new System.Windows.Forms.Label();
            this.chkDetailEditStatus = new System.Windows.Forms.CheckBox();
            this.tspCommandDetail = new System.Windows.Forms.ToolStrip();
            this.cmdNewDetail = new System.Windows.Forms.ToolStripButton();
            this.cmdEditDetail = new System.Windows.Forms.ToolStripButton();
            this.cmdSaveDetail = new System.Windows.Forms.ToolStripButton();
            this.cmdDeleteDetail = new System.Windows.Forms.ToolStripButton();
            this.cmdCancelDetail = new System.Windows.Forms.ToolStripButton();
            this.tspCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).BeginInit();
            this.sptAll.Panel1.SuspendLayout();
            this.sptAll.Panel2.SuspendLayout();
            this.sptAll.SuspendLayout();
            this.grpMaster.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptDetail)).BeginInit();
            this.sptDetail.Panel1.SuspendLayout();
            this.sptDetail.Panel2.SuspendLayout();
            this.sptDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.tspCommandDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspCommand
            // 
            this.tspCommand.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNew,
            this.cmdEdit,
            this.cmdSave,
            this.cmdDelete,
            this.cmdCancel});
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspCommand.Size = new System.Drawing.Size(784, 25);
            this.tspCommand.TabIndex = 8;
            this.tspCommand.Text = "toolStrip1 ";
            // 
            // cmdNew
            // 
            this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(36, 22);
            this.cmdNew.Text = "新增";
            this.cmdNew.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(36, 22);
            this.cmdEdit.Text = "修改";
            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(36, 22);
            this.cmdSave.Text = "保存";
            this.cmdSave.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(36, 22);
            this.cmdDelete.Text = "删除";
            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(36, 22);
            this.cmdCancel.Text = "撤销";
            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);
            // 
            // sptAll
            // 
            this.sptAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptAll.Location = new System.Drawing.Point(0, 25);
            this.sptAll.Name = "sptAll";
            this.sptAll.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptAll.Panel1
            // 
            this.sptAll.Panel1.Controls.Add(this.grpMaster);
            // 
            // sptAll.Panel2
            // 
            this.sptAll.Panel2.Controls.Add(this.tabControl1);
            this.sptAll.Size = new System.Drawing.Size(784, 536);
            this.sptAll.SplitterDistance = 81;
            this.sptAll.TabIndex = 9;
            // 
            // grpMaster
            // 
            this.grpMaster.Controls.Add(this.lblEditCategory);
            this.grpMaster.Controls.Add(this.cboEditCategory);
            this.grpMaster.Controls.Add(this.lblEditName);
            this.grpMaster.Controls.Add(this.txtEditName);
            this.grpMaster.Controls.Add(this.lblEditOnLevel);
            this.grpMaster.Controls.Add(this.cboEditOnLevel);
            this.grpMaster.Controls.Add(this.lblEditRemark);
            this.grpMaster.Controls.Add(this.txtEditRemark);
            this.grpMaster.Controls.Add(this.lblEditSort);
            this.grpMaster.Controls.Add(this.txtEditSort);
            this.grpMaster.Controls.Add(this.lblEditStatus);
            this.grpMaster.Controls.Add(this.chkEditStatus);
            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpMaster.Location = new System.Drawing.Point(0, 0);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(784, 81);
            this.grpMaster.TabIndex = 0;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "主表信息";
            // 
            // lblEditCategory
            // 
            this.lblEditCategory.Location = new System.Drawing.Point(15, 15);
            this.lblEditCategory.Name = "lblEditCategory";
            this.lblEditCategory.Size = new System.Drawing.Size(60, 16);
            this.lblEditCategory.TabIndex = 1;
            this.lblEditCategory.Text = "分类";
            // 
            // cboEditCategory
            // 
            this.cboEditCategory.Location = new System.Drawing.Point(76, 15);
            this.cboEditCategory.Name = "cboEditCategory";
            this.cboEditCategory.Size = new System.Drawing.Size(130, 25);
            this.cboEditCategory.TabIndex = 2;
            this.cboEditCategory.Tag = "Category";
            // 
            // lblEditName
            // 
            this.lblEditName.Location = new System.Drawing.Point(217, 15);
            this.lblEditName.Name = "lblEditName";
            this.lblEditName.Size = new System.Drawing.Size(60, 16);
            this.lblEditName.TabIndex = 1;
            this.lblEditName.Text = "名称";
            // 
            // txtEditName
            // 
            this.txtEditName.Location = new System.Drawing.Point(278, 15);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(130, 23);
            this.txtEditName.TabIndex = 5;
            this.txtEditName.Tag = "Name";
            // 
            // lblEditOnLevel
            // 
            this.lblEditOnLevel.Location = new System.Drawing.Point(419, 15);
            this.lblEditOnLevel.Name = "lblEditOnLevel";
            this.lblEditOnLevel.Size = new System.Drawing.Size(60, 16);
            this.lblEditOnLevel.TabIndex = 1;
            this.lblEditOnLevel.Text = "等级";
            // 
            // cboEditOnLevel
            // 
            this.cboEditOnLevel.Location = new System.Drawing.Point(480, 15);
            this.cboEditOnLevel.Name = "cboEditOnLevel";
            this.cboEditOnLevel.Size = new System.Drawing.Size(130, 25);
            this.cboEditOnLevel.TabIndex = 2;
            this.cboEditOnLevel.Tag = "OnLevel";
            // 
            // lblEditRemark
            // 
            this.lblEditRemark.Location = new System.Drawing.Point(15, 45);
            this.lblEditRemark.Name = "lblEditRemark";
            this.lblEditRemark.Size = new System.Drawing.Size(60, 16);
            this.lblEditRemark.TabIndex = 1;
            this.lblEditRemark.Text = "备注";
            // 
            // txtEditRemark
            // 
            this.txtEditRemark.Location = new System.Drawing.Point(76, 45);
            this.txtEditRemark.Name = "txtEditRemark";
            this.txtEditRemark.Size = new System.Drawing.Size(130, 23);
            this.txtEditRemark.TabIndex = 20;
            this.txtEditRemark.Tag = "Remark";
            // 
            // lblEditSort
            // 
            this.lblEditSort.Location = new System.Drawing.Point(217, 45);
            this.lblEditSort.Name = "lblEditSort";
            this.lblEditSort.Size = new System.Drawing.Size(60, 16);
            this.lblEditSort.TabIndex = 1;
            this.lblEditSort.Text = "排序";
            // 
            // txtEditSort
            // 
            this.txtEditSort.Location = new System.Drawing.Point(278, 45);
            this.txtEditSort.Name = "txtEditSort";
            this.txtEditSort.Size = new System.Drawing.Size(130, 23);
            this.txtEditSort.TabIndex = 25;
            this.txtEditSort.Tag = "Sort";
            // 
            // lblEditStatus
            // 
            this.lblEditStatus.Location = new System.Drawing.Point(419, 45);
            this.lblEditStatus.Name = "lblEditStatus";
            this.lblEditStatus.Size = new System.Drawing.Size(60, 16);
            this.lblEditStatus.TabIndex = 1;
            this.lblEditStatus.Text = "状态";
            // 
            // chkEditStatus
            // 
            this.chkEditStatus.AutoSize = true;
            this.chkEditStatus.Location = new System.Drawing.Point(480, 46);
            this.chkEditStatus.Name = "chkEditStatus";
            this.chkEditStatus.Size = new System.Drawing.Size(15, 14);
            this.chkEditStatus.TabIndex = 4;
            this.chkEditStatus.Tag = "Status";
            this.chkEditStatus.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.sptDetail);
            this.tabPage.Location = new System.Drawing.Point(4, 26);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(776, 421);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "明细表信息";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // sptDetail
            // 
            this.sptDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptDetail.Location = new System.Drawing.Point(3, 3);
            this.sptDetail.Name = "sptDetail";
            // 
            // sptDetail.Panel1
            // 
            this.sptDetail.Panel1.Controls.Add(this.objListViewDetail);
            // 
            // sptDetail.Panel2
            // 
            this.sptDetail.Panel2.Controls.Add(this.grpDetail);
            this.sptDetail.Panel2.Controls.Add(this.tspCommandDetail);
            this.sptDetail.Size = new System.Drawing.Size(770, 415);
            this.sptDetail.SplitterDistance = 436;
            this.sptDetail.TabIndex = 1;
            // 
            // objListViewDetail
            // 
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzModuleID);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzProjectID);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzName);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzStatus);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzRemark);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzSort);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzDeptId);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzCompanyID);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzCreateDate);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzCreateUser);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzEditDate);
            this.objListViewDetail.AllColumns.Add(this.gridDetailmrzEditUser);
            this.objListViewDetail.AllowColumnReorder = true;
            this.objListViewDetail.BackColor = System.Drawing.SystemColors.Control;
            this.objListViewDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objListViewDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gridDetailmrzModuleID,
            this.gridDetailmrzProjectID,
            this.gridDetailmrzName,
            this.gridDetailmrzStatus,
            this.gridDetailmrzRemark,
            this.gridDetailmrzSort,
            this.gridDetailmrzDeptId,
            this.gridDetailmrzCompanyID,
            this.gridDetailmrzCreateDate,
            this.gridDetailmrzCreateUser,
            this.gridDetailmrzEditDate,
            this.gridDetailmrzEditUser});
            this.objListViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objListViewDetail.FullRowSelect = true;
            this.objListViewDetail.GridLines = true;
            this.objListViewDetail.HideSelection = false;
            this.objListViewDetail.Location = new System.Drawing.Point(0, 0);
            this.objListViewDetail.Name = "objListViewDetail";
            this.objListViewDetail.OwnerDraw = true;
            this.objListViewDetail.SelectColumnsOnRightClickBehaviour = Nikita.WinForm.ExtendControl.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.objListViewDetail.ShowCommandMenuOnRightClick = true;
            this.objListViewDetail.ShowGroups = false;
            this.objListViewDetail.ShowItemToolTips = true;
            this.objListViewDetail.Size = new System.Drawing.Size(434, 413);
            this.objListViewDetail.TabIndex = 2;
            this.objListViewDetail.UseCompatibleStateImageBehavior = false;
            this.objListViewDetail.UseFilterIndicator = true;
            this.objListViewDetail.UseFiltering = true;
            this.objListViewDetail.View = System.Windows.Forms.View.Details;
            this.objListViewDetail.VirtualMode = true;
            this.objListViewDetail.SelectedIndexChanged += new System.EventHandler(this.objListViewDetail_SelectedIndexChanged);
            // 
            // gridDetailmrzModuleID
            // 
            this.gridDetailmrzModuleID.AspectName = "ModuleID";
            this.gridDetailmrzModuleID.Text = "模块ID";
            // 
            // gridDetailmrzProjectID
            // 
            this.gridDetailmrzProjectID.AspectName = "ProjectID";
            this.gridDetailmrzProjectID.Text = "所属项目";
            // 
            // gridDetailmrzName
            // 
            this.gridDetailmrzName.AspectName = "Name";
            this.gridDetailmrzName.Text = "模块名称";
            // 
            // gridDetailmrzStatus
            // 
            this.gridDetailmrzStatus.AspectName = "Status";
            this.gridDetailmrzStatus.Text = "状态";
            // 
            // gridDetailmrzRemark
            // 
            this.gridDetailmrzRemark.AspectName = "Remark";
            this.gridDetailmrzRemark.Text = "备注";
            // 
            // gridDetailmrzSort
            // 
            this.gridDetailmrzSort.AspectName = "Sort";
            this.gridDetailmrzSort.Text = "排序";
            // 
            // gridDetailmrzDeptId
            // 
            this.gridDetailmrzDeptId.AspectName = "DeptId";
            this.gridDetailmrzDeptId.Text = "DeptId";
            // 
            // gridDetailmrzCompanyID
            // 
            this.gridDetailmrzCompanyID.AspectName = "CompanyID";
            this.gridDetailmrzCompanyID.Text = "CompanyID";
            // 
            // gridDetailmrzCreateDate
            // 
            this.gridDetailmrzCreateDate.AspectName = "CreateDate";
            this.gridDetailmrzCreateDate.Text = "CreateDate";
            // 
            // gridDetailmrzCreateUser
            // 
            this.gridDetailmrzCreateUser.AspectName = "CreateUser";
            this.gridDetailmrzCreateUser.Text = "CreateUser";
            // 
            // gridDetailmrzEditDate
            // 
            this.gridDetailmrzEditDate.AspectName = "EditDate";
            this.gridDetailmrzEditDate.Text = "EditDate";
            // 
            // gridDetailmrzEditUser
            // 
            this.gridDetailmrzEditUser.AspectName = "EditUser";
            this.gridDetailmrzEditUser.Text = "EditUser";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lblDetailEditProjectID);
            this.grpDetail.Controls.Add(this.cboDetailEditProjectID);
            this.grpDetail.Controls.Add(this.lblDetailEditName);
            this.grpDetail.Controls.Add(this.txtDetailEditName);
            this.grpDetail.Controls.Add(this.lblDetailEditRemark);
            this.grpDetail.Controls.Add(this.txtDetailEditRemark);
            this.grpDetail.Controls.Add(this.lblDetailEditSort);
            this.grpDetail.Controls.Add(this.txtDetailEditSort);
            this.grpDetail.Controls.Add(this.lblDetailEditStatus);
            this.grpDetail.Controls.Add(this.chkDetailEditStatus);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpDetail.Location = new System.Drawing.Point(0, 25);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(0);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(0);
            this.grpDetail.Size = new System.Drawing.Size(328, 388);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            // 
            // lblDetailEditProjectID
            // 
            this.lblDetailEditProjectID.Location = new System.Drawing.Point(12, 19);
            this.lblDetailEditProjectID.Name = "lblDetailEditProjectID";
            this.lblDetailEditProjectID.Size = new System.Drawing.Size(60, 16);
            this.lblDetailEditProjectID.TabIndex = 1;
            this.lblDetailEditProjectID.Text = "所属项目";
            // 
            // cboDetailEditProjectID
            // 
            this.cboDetailEditProjectID.Location = new System.Drawing.Point(73, 19);
            this.cboDetailEditProjectID.Name = "cboDetailEditProjectID";
            this.cboDetailEditProjectID.Size = new System.Drawing.Size(130, 25);
            this.cboDetailEditProjectID.TabIndex = 2;
            this.cboDetailEditProjectID.Tag = "ProjectID";
            // 
            // lblDetailEditName
            // 
            this.lblDetailEditName.Location = new System.Drawing.Point(12, 49);
            this.lblDetailEditName.Name = "lblDetailEditName";
            this.lblDetailEditName.Size = new System.Drawing.Size(60, 16);
            this.lblDetailEditName.TabIndex = 1;
            this.lblDetailEditName.Text = "模块名称";
            // 
            // txtDetailEditName
            // 
            this.txtDetailEditName.Location = new System.Drawing.Point(73, 49);
            this.txtDetailEditName.Name = "txtDetailEditName";
            this.txtDetailEditName.Size = new System.Drawing.Size(130, 23);
            this.txtDetailEditName.TabIndex = 5;
            this.txtDetailEditName.Tag = "Name";
            // 
            // lblDetailEditRemark
            // 
            this.lblDetailEditRemark.Location = new System.Drawing.Point(12, 79);
            this.lblDetailEditRemark.Name = "lblDetailEditRemark";
            this.lblDetailEditRemark.Size = new System.Drawing.Size(60, 16);
            this.lblDetailEditRemark.TabIndex = 1;
            this.lblDetailEditRemark.Text = "备注";
            // 
            // txtDetailEditRemark
            // 
            this.txtDetailEditRemark.Location = new System.Drawing.Point(73, 79);
            this.txtDetailEditRemark.Name = "txtDetailEditRemark";
            this.txtDetailEditRemark.Size = new System.Drawing.Size(130, 23);
            this.txtDetailEditRemark.TabIndex = 15;
            this.txtDetailEditRemark.Tag = "Remark";
            // 
            // lblDetailEditSort
            // 
            this.lblDetailEditSort.Location = new System.Drawing.Point(12, 109);
            this.lblDetailEditSort.Name = "lblDetailEditSort";
            this.lblDetailEditSort.Size = new System.Drawing.Size(60, 16);
            this.lblDetailEditSort.TabIndex = 1;
            this.lblDetailEditSort.Text = "排序";
            // 
            // txtDetailEditSort
            // 
            this.txtDetailEditSort.Location = new System.Drawing.Point(73, 109);
            this.txtDetailEditSort.Name = "txtDetailEditSort";
            this.txtDetailEditSort.Size = new System.Drawing.Size(130, 23);
            this.txtDetailEditSort.TabIndex = 20;
            this.txtDetailEditSort.Tag = "Sort";
            // 
            // lblDetailEditStatus
            // 
            this.lblDetailEditStatus.Location = new System.Drawing.Point(12, 139);
            this.lblDetailEditStatus.Name = "lblDetailEditStatus";
            this.lblDetailEditStatus.Size = new System.Drawing.Size(60, 16);
            this.lblDetailEditStatus.TabIndex = 1;
            this.lblDetailEditStatus.Text = "状态";
            // 
            // chkDetailEditStatus
            // 
            this.chkDetailEditStatus.AutoSize = true;
            this.chkDetailEditStatus.Location = new System.Drawing.Point(73, 139);
            this.chkDetailEditStatus.Name = "chkDetailEditStatus";
            this.chkDetailEditStatus.Size = new System.Drawing.Size(15, 14);
            this.chkDetailEditStatus.TabIndex = 4;
            this.chkDetailEditStatus.Tag = "Status";
            this.chkDetailEditStatus.UseVisualStyleBackColor = true;
            // 
            // tspCommandDetail
            // 
            this.tspCommandDetail.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tspCommandDetail.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspCommandDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNewDetail,
            this.cmdEditDetail,
            this.cmdSaveDetail,
            this.cmdDeleteDetail,
            this.cmdCancelDetail});
            this.tspCommandDetail.Location = new System.Drawing.Point(0, 0);
            this.tspCommandDetail.Name = "tspCommandDetail";
            this.tspCommandDetail.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspCommandDetail.Size = new System.Drawing.Size(328, 25);
            this.tspCommandDetail.TabIndex = 14;
            this.tspCommandDetail.Text = "toolStrip1 ";
            // 
            // cmdNewDetail
            // 
            this.cmdNewDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNewDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNewDetail.Name = "cmdNewDetail";
            this.cmdNewDetail.Size = new System.Drawing.Size(36, 22);
            this.cmdNewDetail.Text = "新增";
            this.cmdNewDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdEditDetail
            // 
            this.cmdEditDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEditDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEditDetail.Name = "cmdEditDetail";
            this.cmdEditDetail.Size = new System.Drawing.Size(36, 22);
            this.cmdEditDetail.Text = "修改";
            this.cmdEditDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdSaveDetail
            // 
            this.cmdSaveDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdSaveDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSaveDetail.Name = "cmdSaveDetail";
            this.cmdSaveDetail.Size = new System.Drawing.Size(36, 22);
            this.cmdSaveDetail.Text = "保存";
            this.cmdSaveDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdDeleteDetail
            // 
            this.cmdDeleteDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdDeleteDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDeleteDetail.Name = "cmdDeleteDetail";
            this.cmdDeleteDetail.Size = new System.Drawing.Size(36, 22);
            this.cmdDeleteDetail.Text = "删除";
            this.cmdDeleteDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdCancelDetail
            // 
            this.cmdCancelDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancelDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancelDetail.Name = "cmdCancelDetail";
            this.cmdCancelDetail.Size = new System.Drawing.Size(36, 22);
            this.cmdCancelDetail.Text = "撤销";
            this.cmdCancelDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // FrmBseProjectModuleMasterDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.sptAll);
            this.Controls.Add(this.tspCommand);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmBseProjectModuleMasterDetailDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBseProjectModuleMasterDetailDialog";
            this.Click += new System.EventHandler(this.Command_Click);
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.sptAll.Panel1.ResumeLayout(false);
            this.sptAll.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).EndInit();
            this.sptAll.ResumeLayout(false);
            this.grpMaster.ResumeLayout(false);
            this.grpMaster.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.sptDetail.Panel1.ResumeLayout(false);
            this.sptDetail.Panel2.ResumeLayout(false);
            this.sptDetail.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptDetail)).EndInit();
            this.sptDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.tspCommandDetail.ResumeLayout(false);
            this.tspCommandDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
     #endregion
        private System.Windows.Forms.ToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.ToolStripButton cmdEdit;
        private System.Windows.Forms.ToolStripButton cmdNew;
        private System.Windows.Forms.ToolStripButton cmdSave;
        private System.Windows.Forms.SplitContainer sptAll;
        private System.Windows.Forms.GroupBox grpMaster;
        private System.Windows.Forms.ComboBox  cboEditCategory;
        private System.Windows.Forms.Label lblEditCategory;
        private System.Windows.Forms.TextBox  txtEditName;
        private System.Windows.Forms.Label lblEditName;
        private System.Windows.Forms.ComboBox  cboEditOnLevel;
        private System.Windows.Forms.Label lblEditOnLevel;
        private System.Windows.Forms.TextBox  txtEditRemark;
        private System.Windows.Forms.Label lblEditRemark;
        private System.Windows.Forms.TextBox  txtEditSort;
        private System.Windows.Forms.Label lblEditSort;
        private System.Windows.Forms.CheckBox  chkEditStatus;
        private System.Windows.Forms.Label lblEditStatus;
        private System.Windows.Forms.ToolStripButton cmdCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.SplitContainer sptDetail;
        private WinForm.ExtendControl.FastObjectListView objListViewDetail;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzModuleID;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzProjectID;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzName;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzStatus;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzRemark;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzSort;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzDeptId;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzCompanyID;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzCreateDate;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzCreateUser;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzEditDate;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzEditUser;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.ComboBox  cboDetailEditProjectID;
        private System.Windows.Forms.Label lblDetailEditProjectID;
        private System.Windows.Forms.TextBox  txtDetailEditName;
        private System.Windows.Forms.Label lblDetailEditName;
        private System.Windows.Forms.TextBox  txtDetailEditRemark;
        private System.Windows.Forms.Label lblDetailEditRemark;
        private System.Windows.Forms.TextBox  txtDetailEditSort;
        private System.Windows.Forms.Label lblDetailEditSort;
        private System.Windows.Forms.CheckBox  chkDetailEditStatus;
        private System.Windows.Forms.Label lblDetailEditStatus;
        private System.Windows.Forms.ToolStrip tspCommandDetail;
        private System.Windows.Forms.ToolStripButton cmdNewDetail;
        private System.Windows.Forms.ToolStripButton cmdEditDetail;
        private System.Windows.Forms.ToolStripButton cmdSaveDetail;
        private System.Windows.Forms.ToolStripButton cmdDeleteDetail;
        private System.Windows.Forms.ToolStripButton cmdCancelDetail;
    }
}
