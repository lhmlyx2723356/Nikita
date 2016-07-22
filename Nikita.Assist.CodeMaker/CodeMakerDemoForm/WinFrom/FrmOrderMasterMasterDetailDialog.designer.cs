namespace Nikita.Assist.CodeMaker
{
    partial class FrmOrderMasterMasterDetailDialog
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
this.lblEditOrderNumber = new System.Windows.Forms.Label();
            this.txtEditOrderNumber = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.sptDetail = new System.Windows.Forms.SplitContainer();
            this.objListViewDetail = new Nikita.WinForm.ExtendControl.FastObjectListView();
            this.gridDetailmrzDetailId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzOrderId = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzCustomer = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzProductName = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzAmount = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzSumMoney = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.gridDetailmrzStatus = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.grpDetail = new System.Windows.Forms.GroupBox();
this.lblDetailEditCustomer = new System.Windows.Forms.Label();
            this.txtDetailEditCustomer = new System.Windows.Forms.TextBox();
this.lblDetailEditProductName = new System.Windows.Forms.Label();
            this.txtDetailEditProductName = new System.Windows.Forms.TextBox();
this.lblDetailEditAmount = new System.Windows.Forms.Label();
            this.txtDetailEditAmount = new System.Windows.Forms.TextBox();
this.lblDetailEditSumMoney = new System.Windows.Forms.Label();
            this.txtDetailEditSumMoney = new System.Windows.Forms.TextBox();
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
            this.tspCommand.Size = new System.Drawing.Size(784, 26);
            this.tspCommand.TabIndex = 8;
            this.tspCommand.Text = "toolStrip1 ";
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
            // cmdEdit
            // 
            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(39, 23);
            this.cmdEdit.Text = "修改";
            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(39, 23);
            this.cmdSave.Text = "保存";
            this.cmdSave.Click += new System.EventHandler(this.Command_Click);
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
            // cmdCancel
            // 
            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(39, 23);
            this.cmdCancel.Text = "撤销";
            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);
            // 
            // sptAll
            // 
            this.sptAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptAll.Location = new System.Drawing.Point(0, 26);
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
            this.sptAll.Size = new System.Drawing.Size(784, 535);
            this.sptAll.SplitterDistance = 134;
            this.sptAll.TabIndex = 9;
            // 
            // grpMaster
            // 
  this.grpMaster.Controls.Add(this.lblEditOrderNumber);
         this.grpMaster.Controls.Add(this.txtEditOrderNumber);
            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpMaster.Location = new System.Drawing.Point(0, 0);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(784, 134);
            this.grpMaster.TabIndex = 0;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "主表信息";
     this.lblEditOrderNumber.Location = new System.Drawing.Point(15, 15);
            this.lblEditOrderNumber.Name = "lblEditOrderNumber";
            this.lblEditOrderNumber.Size = new System.Drawing.Size(50, 16);
            this.lblEditOrderNumber.TabIndex = 1;
            this.lblEditOrderNumber.Text ="单号";
            // 
            // txtEditOrderNumber
            // 
            this.txtEditOrderNumber.Location = new System.Drawing.Point(70, 15);
            this.txtEditOrderNumber.Name =  "txtEditOrderNumber";
            this.txtEditOrderNumber.Size = new System.Drawing.Size(130, 20);
            this.txtEditOrderNumber.TabIndex = 1;
            this.txtEditOrderNumber.Tag = "OrderNumber";

            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.sptDetail);
            this.tabPage.Location = new System.Drawing.Point(4, 26);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(776, 367);
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
            this.sptDetail.Size = new System.Drawing.Size(770, 361);
            this.sptDetail.SplitterDistance = 436;
            this.sptDetail.TabIndex = 1;
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
            this.objListViewDetail.Location = new System.Drawing.Point(0, 0);
            this.objListViewDetail.Name = "objListViewDetail";
            this.objListViewDetail.OwnerDraw = true;
            this.objListViewDetail.SelectColumnsOnRightClickBehaviour = Nikita.WinForm.ExtendControl.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.objListViewDetail.ShowCommandMenuOnRightClick = true;
            this.objListViewDetail.ShowGroups = false;
            this.objListViewDetail.ShowItemToolTips = true;
            this.objListViewDetail.Size = new System.Drawing.Size(434, 359);
            this.objListViewDetail.TabIndex = 2;
            this.objListViewDetail.UseCompatibleStateImageBehavior = false;
            this.objListViewDetail.UseFilterIndicator = true;
            this.objListViewDetail.UseFiltering = true;
            this.objListViewDetail.View = System.Windows.Forms.View.Details;
            this.objListViewDetail.VirtualMode = true;
            this.objListViewDetail.SelectedIndexChanged += new System.EventHandler(this.objListViewDetail_SelectedIndexChanged);
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
            // grpDetail
            // 
  this.grpDetail.Controls.Add(this.lblDetailEditCustomer);
         this.grpDetail.Controls.Add(this.txtDetailEditCustomer);
  this.grpDetail.Controls.Add(this.lblDetailEditProductName);
         this.grpDetail.Controls.Add(this.txtDetailEditProductName);
  this.grpDetail.Controls.Add(this.lblDetailEditAmount);
         this.grpDetail.Controls.Add(this.txtDetailEditAmount);
  this.grpDetail.Controls.Add(this.lblDetailEditSumMoney);
         this.grpDetail.Controls.Add(this.txtDetailEditSumMoney);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpDetail.Location = new System.Drawing.Point(0, 26);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(0);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(0);
            this.grpDetail.Size = new System.Drawing.Size(328, 333);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
     this.lblDetailEditCustomer.Location = new System.Drawing.Point(15, 40);
            this.lblDetailEditCustomer.Name = "lblDetailEditCustomer";
            this.lblDetailEditCustomer.Size = new System.Drawing.Size(50, 16);
            this.lblDetailEditCustomer.TabIndex = 1;
            this.lblDetailEditCustomer.Text ="客户";
            // 
            // txtDetailEditCustomer
            // 
            this.txtDetailEditCustomer.Location = new System.Drawing.Point(70, 40);
            this.txtDetailEditCustomer.Name =  "txtDetailEditCustomer";
            this.txtDetailEditCustomer.Size = new System.Drawing.Size(130, 20);
            this.txtDetailEditCustomer.TabIndex = 1;
            this.txtDetailEditCustomer.Tag = "Customer";

     this.lblDetailEditProductName.Location = new System.Drawing.Point(15, 65);
            this.lblDetailEditProductName.Name = "lblDetailEditProductName";
            this.lblDetailEditProductName.Size = new System.Drawing.Size(50, 16);
            this.lblDetailEditProductName.TabIndex = 1;
            this.lblDetailEditProductName.Text ="产品";
            // 
            // txtDetailEditProductName
            // 
            this.txtDetailEditProductName.Location = new System.Drawing.Point(70, 65);
            this.txtDetailEditProductName.Name =  "txtDetailEditProductName";
            this.txtDetailEditProductName.Size = new System.Drawing.Size(130, 20);
            this.txtDetailEditProductName.TabIndex = 5;
            this.txtDetailEditProductName.Tag = "ProductName";

     this.lblDetailEditAmount.Location = new System.Drawing.Point(15, 90);
            this.lblDetailEditAmount.Name = "lblDetailEditAmount";
            this.lblDetailEditAmount.Size = new System.Drawing.Size(50, 16);
            this.lblDetailEditAmount.TabIndex = 1;
            this.lblDetailEditAmount.Text ="数量";
            // 
            // txtDetailEditAmount
            // 
            this.txtDetailEditAmount.Location = new System.Drawing.Point(70, 90);
            this.txtDetailEditAmount.Name =  "txtDetailEditAmount";
            this.txtDetailEditAmount.Size = new System.Drawing.Size(130, 20);
            this.txtDetailEditAmount.TabIndex = 10;
            this.txtDetailEditAmount.Tag = "Amount";

     this.lblDetailEditSumMoney.Location = new System.Drawing.Point(15, 115);
            this.lblDetailEditSumMoney.Name = "lblDetailEditSumMoney";
            this.lblDetailEditSumMoney.Size = new System.Drawing.Size(50, 16);
            this.lblDetailEditSumMoney.TabIndex = 1;
            this.lblDetailEditSumMoney.Text ="金额";
            // 
            // txtDetailEditSumMoney
            // 
            this.txtDetailEditSumMoney.Location = new System.Drawing.Point(70, 115);
            this.txtDetailEditSumMoney.Name =  "txtDetailEditSumMoney";
            this.txtDetailEditSumMoney.Size = new System.Drawing.Size(130, 20);
            this.txtDetailEditSumMoney.TabIndex = 15;
            this.txtDetailEditSumMoney.Tag = "SumMoney";

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
            this.tspCommandDetail.Size = new System.Drawing.Size(328, 26);
            this.tspCommandDetail.TabIndex = 14;
            this.tspCommandDetail.Text = "toolStrip1 ";
            // 
            // cmdNewDetail
            // 
            this.cmdNewDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNewDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNewDetail.Name = "cmdNewDetail";
            this.cmdNewDetail.Size = new System.Drawing.Size(39, 23);
            this.cmdNewDetail.Text = "新增";
            this.cmdNewDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdEditDetail
            // 
            this.cmdEditDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdEditDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEditDetail.Name = "cmdEditDetail";
            this.cmdEditDetail.Size = new System.Drawing.Size(39, 23);
            this.cmdEditDetail.Text = "修改";
            this.cmdEditDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdSaveDetail
            // 
            this.cmdSaveDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdSaveDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSaveDetail.Name = "cmdSaveDetail";
            this.cmdSaveDetail.Size = new System.Drawing.Size(39, 23);
            this.cmdSaveDetail.Text = "保存";
            this.cmdSaveDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdDeleteDetail
            // 
            this.cmdDeleteDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdDeleteDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDeleteDetail.Name = "cmdDeleteDetail";
            this.cmdDeleteDetail.Size = new System.Drawing.Size(39, 23);
            this.cmdDeleteDetail.Text = "删除";
            this.cmdDeleteDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdCancelDetail
            // 
            this.cmdCancelDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdCancelDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancelDetail.Name = "cmdCancelDetail";
            this.cmdCancelDetail.Size = new System.Drawing.Size(39, 23);
            this.cmdCancelDetail.Text = "撤销";
            this.cmdCancelDetail.Click += new System.EventHandler(this.Command_Click);
            // 
            // FrmMasterDetailDemoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.sptAll);
            this.Controls.Add(this.tspCommand);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmOrderMasterMasterDetailDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrderMasterMasterDetailDialog";
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
        private System.Windows.Forms.TextBox txtEditOrderNumber;
        private System.Windows.Forms.Label lblEditOrderNumber;
        private System.Windows.Forms.ToolStripButton cmdCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.SplitContainer sptDetail;
        private WinForm.ExtendControl.FastObjectListView objListViewDetail;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzDetailId;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzOrderId;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzCustomer;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzProductName;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzAmount;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzSumMoney;
        private WinForm.ExtendControl.OLVColumn gridDetailmrzStatus;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.TextBox txtDetailEditCustomer;
        private System.Windows.Forms.Label lblDetailEditCustomer;
        private System.Windows.Forms.TextBox txtDetailEditProductName;
        private System.Windows.Forms.Label lblDetailEditProductName;
        private System.Windows.Forms.TextBox txtDetailEditAmount;
        private System.Windows.Forms.Label lblDetailEditAmount;
        private System.Windows.Forms.TextBox txtDetailEditSumMoney;
        private System.Windows.Forms.Label lblDetailEditSumMoney;
        private System.Windows.Forms.ToolStrip tspCommandDetail;
        private System.Windows.Forms.ToolStripButton cmdNewDetail;
        private System.Windows.Forms.ToolStripButton cmdEditDetail;
        private System.Windows.Forms.ToolStripButton cmdSaveDetail;
        private System.Windows.Forms.ToolStripButton cmdDeleteDetail;
        private System.Windows.Forms.ToolStripButton cmdCancelDetail;
    }
}
