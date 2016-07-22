namespace Nikita.Assist.CodeMaker.CodeMakerDemoForm.WinFrom
{
    partial class FrmSimpleQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSimpleQuery));
            this.sptAll = new System.Windows.Forms.SplitContainer();
            this.sptQuery = new System.Windows.Forms.SplitContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbkID = new Nikita.WinForm.ExtendControl.CheckedComboBox();
            this.cboQueryTrueName = new System.Windows.Forms.ComboBox();
            this.lblQueryTrueName = new System.Windows.Forms.Label();
            this.txtQueryUserName = new System.Windows.Forms.TextBox();
            this.lblQueryUserName = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.sptView = new System.Windows.Forms.SplitContainer();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colUser_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).BeginInit();
            this.sptAll.Panel1.SuspendLayout();
            this.sptAll.Panel2.SuspendLayout();
            this.sptAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();
            this.sptQuery.Panel1.SuspendLayout();
            this.sptQuery.Panel2.SuspendLayout();
            this.sptQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.sptQuery.Name = "sptQuery";
            // 
            // sptQuery.Panel1
            // 
            this.sptQuery.Panel1.Controls.Add(this.numericUpDown1);
            this.sptQuery.Panel1.Controls.Add(this.label1);
            this.sptQuery.Panel1.Controls.Add(this.cbkID);
            this.sptQuery.Panel1.Controls.Add(this.cboQueryTrueName);
            this.sptQuery.Panel1.Controls.Add(this.lblQueryTrueName);
            this.sptQuery.Panel1.Controls.Add(this.txtQueryUserName);
            this.sptQuery.Panel1.Controls.Add(this.lblQueryUserName);
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(646, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "序号";
            // 
            // cbkID
            // 
            this.cbkID.CheckOnClick = true;
            this.cbkID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbkID.DropDownHeight = 1;
            this.cbkID.FormattingEnabled = true;
            this.cbkID.IntegralHeight = false;
            this.cbkID.Location = new System.Drawing.Point(483, 17);
            this.cbkID.Name = "cbkID";
            this.cbkID.Size = new System.Drawing.Size(121, 24);
            this.cbkID.TabIndex = 4;
            this.cbkID.ValueSeparator = ", ";
            // 
            // cboQueryTrueName
            // 
            this.cboQueryTrueName.FormattingEnabled = true;
            this.cboQueryTrueName.Location = new System.Drawing.Point(268, 17);
            this.cboQueryTrueName.Name = "cboQueryTrueName";
            this.cboQueryTrueName.Size = new System.Drawing.Size(121, 25);
            this.cboQueryTrueName.TabIndex = 3;
            // 
            // lblQueryTrueName
            // 
            this.lblQueryTrueName.AutoSize = true;
            this.lblQueryTrueName.Location = new System.Drawing.Point(217, 21);
            this.lblQueryTrueName.Name = "lblQueryTrueName";
            this.lblQueryTrueName.Size = new System.Drawing.Size(44, 17);
            this.lblQueryTrueName.TabIndex = 2;
            this.lblQueryTrueName.Text = "中文名";
            // 
            // txtQueryUserName
            // 
            this.txtQueryUserName.Location = new System.Drawing.Point(70, 18);
            this.txtQueryUserName.Name = "txtQueryUserName";
            this.txtQueryUserName.Size = new System.Drawing.Size(125, 23);
            this.txtQueryUserName.TabIndex = 1;
            // 
            // lblQueryUserName
            // 
            this.lblQueryUserName.AutoSize = true;
            this.lblQueryUserName.Location = new System.Drawing.Point(20, 21);
            this.lblQueryUserName.Name = "lblQueryUserName";
            this.lblQueryUserName.Size = new System.Drawing.Size(44, 17);
            this.lblQueryUserName.TabIndex = 0;
            this.lblQueryUserName.Text = "用户名";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(31, 15);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(54, 31);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
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
            this.colUser_Id,
            this.colTrueName});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.RowHeadersWidth = 50;
            this.grdData.RowTemplate.Height = 23;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(905, 422);
            this.grdData.TabIndex = 0;
            this.grdData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellMouseEnter);
            // 
            // colUser_Id
            // 
            this.colUser_Id.DataPropertyName = "User_Id";
            this.colUser_Id.HeaderText = "唯一ID";
            this.colUser_Id.Name = "colUser_Id";
            // 
            // colTrueName
            // 
            this.colTrueName.DataPropertyName = "TrueName";
            this.colTrueName.HeaderText = "中文名";
            this.colTrueName.Name = "colTrueName";
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
            this.cmdImport});
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.Size = new System.Drawing.Size(907, 26);
            this.tspCommand.TabIndex = 4;
            this.tspCommand.Text = "toolStrip1";
            // 
            // cmdFirst
            // 
            this.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdFirst.Image = ((System.Drawing.Image)(resources.GetObject("cmdFirst.Image")));
            this.cmdFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFirst.Name = "cmdFirst";
            this.cmdFirst.Size = new System.Drawing.Size(52, 23);
            this.cmdFirst.Text = "第一条";
            this.cmdFirst.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdPre
            // 
            this.cmdPre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdPre.Image = ((System.Drawing.Image)(resources.GetObject("cmdPre.Image")));
            this.cmdPre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPre.Name = "cmdPre";
            this.cmdPre.Size = new System.Drawing.Size(52, 23);
            this.cmdPre.Text = "上一条";
            this.cmdPre.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdNext.Image = ((System.Drawing.Image)(resources.GetObject("cmdNext.Image")));
            this.cmdNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(52, 23);
            this.cmdNext.Text = "下一条";
            this.cmdNext.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdLast.Image = ((System.Drawing.Image)(resources.GetObject("cmdLast.Image")));
            this.cmdLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.Size = new System.Drawing.Size(65, 23);
            this.cmdLast.Text = "最后一条";
            this.cmdLast.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdSep1
            // 
            this.cmdSep1.Name = "cmdSep1";
            this.cmdSep1.Size = new System.Drawing.Size(6, 26);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(39, 23);
            this.cmdRefresh.Text = "刷新";
            this.cmdRefresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.cmdRefresh.Click += new System.EventHandler(this.Command_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdImportExcel});
            this.cmdImport.Image = ((System.Drawing.Image)(resources.GetObject("cmdImport.Image")));
            this.cmdImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(51, 23);
            this.cmdImport.Text = "导出";
            // 
            // cmdImportExcel
            // 
            this.cmdImportExcel.Name = "cmdImportExcel";
            this.cmdImportExcel.Size = new System.Drawing.Size(135, 24);
            this.cmdImportExcel.Text = "导出Excel";
            this.cmdImportExcel.Click += new System.EventHandler(this.Command_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "User_Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "唯一ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TrueName";
            this.dataGridViewTextBoxColumn2.HeaderText = "中文名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // FrmSimpleQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 561);
            this.Controls.Add(this.sptAll);
            this.Controls.Add(this.tspCommand);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSimpleQuery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSimpleQuery";
            this.sptAll.Panel1.ResumeLayout(false);
            this.sptAll.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).EndInit();
            this.sptAll.ResumeLayout(false);
            this.sptQuery.Panel1.ResumeLayout(false);
            this.sptQuery.Panel1.PerformLayout();
            this.sptQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();
            this.sptQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrueName;
        private System.Windows.Forms.ToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton cmdRefresh;
        private System.Windows.Forms.ToolStripSplitButton cmdImport;
        private System.Windows.Forms.ToolStripMenuItem cmdImportExcel;
        private System.Windows.Forms.ToolStripButton cmdFirst;
        private System.Windows.Forms.ToolStripButton cmdPre;
        private System.Windows.Forms.ToolStripButton cmdNext;
        private System.Windows.Forms.ToolStripButton cmdLast;
        private System.Windows.Forms.ToolStripSeparator cmdSep1;
        private System.Windows.Forms.Label lblQueryUserName;
        private System.Windows.Forms.TextBox txtQueryUserName;
        private System.Windows.Forms.Label lblQueryTrueName;
        private System.Windows.Forms.ComboBox cboQueryTrueName;
        private System.Windows.Forms.Label label1;
        private WinForm.ExtendControl.CheckedComboBox cbkID;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;


    }
}