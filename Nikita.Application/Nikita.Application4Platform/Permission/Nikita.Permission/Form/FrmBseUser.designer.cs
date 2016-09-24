namespace Nikita.Permission
{
    partial class FrmBseUser
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tab = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.treOrganize = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.treRole = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbSex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtRealName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnImportOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridCMain = new DevExpress.XtraGrid.GridControl();
            this.gridVMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tab)).BeginInit();
            this.tab.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treOrganize)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRealName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tab);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1062, 454);
            this.splitContainerControl1.SplitterPosition = 210;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tab
            // 
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedTabPage = this.xtraTabPage1;
            this.tab.Size = new System.Drawing.Size(210, 454);
            this.tab.TabIndex = 0;
            this.tab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.treOrganize);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(208, 426);
            this.xtraTabPage1.Text = "按组织机构查看";
            // 
            // treOrganize
            // 
            this.treOrganize.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.treOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treOrganize.Location = new System.Drawing.Point(0, 0);
            this.treOrganize.Name = "treOrganize";
            this.treOrganize.Size = new System.Drawing.Size(208, 426);
            this.treOrganize.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "机构列表";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "父级ID";
            this.treeListColumn2.FieldName = "ParentId";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "序号";
            this.treeListColumn3.FieldName = "Organize_Id";
            this.treeListColumn3.Name = "treeListColumn3";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.treRole);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(208, 426);
            this.xtraTabPage2.Text = "按角色查看";
            // 
            // treRole
            // 
            this.treRole.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6});
            this.treRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treRole.Location = new System.Drawing.Point(0, 0);
            this.treRole.Name = "treRole";
            this.treRole.Size = new System.Drawing.Size(208, 426);
            this.treRole.TabIndex = 1;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "序号";
            this.treeListColumn4.FieldName = "序号";
            this.treeListColumn4.Name = "treeListColumn4";
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "父级ID";
            this.treeListColumn5.FieldName = "父级ID";
            this.treeListColumn5.Name = "treeListColumn5";
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "角色列表";
            this.treeListColumn6.FieldName = "Name";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerControl2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl2.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.btnEdit);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnDelete);
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnImportOut);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnImportIn);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnNew);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnQuery);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(840, 454);
            this.splitContainerControl2.SplitterPosition = 89;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(527, 66);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "修改选中";
            this.btnEdit.Click += new System.EventHandler(this.button_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(608, 66);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "作废选中";
            this.btnDelete.Click += new System.EventHandler(this.button_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbSex);
            this.groupControl1.Controls.Add(this.txtRealName);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.txtNumber);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(840, 63);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "groupControl1";
            // 
            // cmbSex
            // 
            this.cmbSex.Location = new System.Drawing.Point(668, 22);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSex.Properties.Items.AddRange(new object[] {
            "",
            "男",
            "女"});
            this.cmbSex.Size = new System.Drawing.Size(142, 22);
            this.cmbSex.TabIndex = 7;
            // 
            // txtRealName
            // 
            this.txtRealName.Location = new System.Drawing.Point(472, 22);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(142, 22);
            this.txtRealName.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(265, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(142, 22);
            this.txtUserName.TabIndex = 5;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(68, 22);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(142, 22);
            this.txtNumber.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(631, 25);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "性别";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(413, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "用户全名";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(216, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "用户名";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户编码";
            // 
            // btnImportOut
            // 
            this.btnImportOut.Location = new System.Drawing.Point(767, 66);
            this.btnImportOut.Name = "btnImportOut";
            this.btnImportOut.Size = new System.Drawing.Size(75, 23);
            this.btnImportOut.TabIndex = 3;
            this.btnImportOut.Text = "导出";
            this.btnImportOut.Click += new System.EventHandler(this.button_Click);
            // 
            // btnImportIn
            // 
            this.btnImportIn.Location = new System.Drawing.Point(686, 66);
            this.btnImportIn.Name = "btnImportIn";
            this.btnImportIn.Size = new System.Drawing.Size(75, 23);
            this.btnImportIn.TabIndex = 2;
            this.btnImportIn.Text = "导入";
            this.btnImportIn.Click += new System.EventHandler(this.button_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(448, 66);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新建";
            this.btnNew.Click += new System.EventHandler(this.button_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(367, 66);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.button_Click);
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.gridCMain);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(840, 353);
            this.splitContainerControl3.SplitterPosition = 40;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // gridCMain
            // 
            this.gridCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCMain.Location = new System.Drawing.Point(0, 0);
            this.gridCMain.MainView = this.gridVMain;
            this.gridCMain.Name = "gridCMain";
            this.gridCMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repImage});
            this.gridCMain.Size = new System.Drawing.Size(840, 301);
            this.gridCMain.TabIndex = 2;
            this.gridCMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVMain});
            this.gridCMain.DoubleClick += new System.EventHandler(this.gridCMain_DoubleClick);
            // 
            // gridVMain
            // 
            this.gridVMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7});
            this.gridVMain.GridControl = this.gridCMain;
            this.gridVMain.IndicatorWidth = 40;
            this.gridVMain.Name = "gridVMain";
            this.gridVMain.OptionsView.ColumnAutoWidth = false;
            this.gridVMain.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "序号";
            this.gridColumn1.FieldName = "User_Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "用户编码";
            this.gridColumn2.FieldName = "Number";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "用户名";
            this.gridColumn3.FieldName = "UserName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "用户全名";
            this.gridColumn4.FieldName = "Realname";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "性别";
            this.gridColumn5.FieldName = "Sex";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "状态";
            this.gridColumn7.FieldName = "State";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // repImage
            // 
            this.repImage.AutoHeight = false;
            this.repImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repImage.Name = "repImage";
            // 
            // FrmBseUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 454);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBseUser";
            this.Text = "FrmBseUser";
            this.Load += new System.EventHandler(this.FrmBseUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tab)).EndInit();
            this.tab.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treOrganize)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRealName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTab.XtraTabControl tab;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTreeList.TreeList treOrganize;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnImportOut;
        private DevExpress.XtraEditors.SimpleButton btnImportIn;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraGrid.GridControl gridCMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repImage; private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraTreeList.TreeList treRole;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtRealName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSex;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
    }
}