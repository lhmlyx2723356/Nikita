namespace Nikita.Assist.DBManager
{
    partial class FrmDataBaseQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataBaseQuery));
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboDbName = new System.Windows.Forms.ToolStripComboBox();
            this.cmdRun = new System.Windows.Forms.ToolStripButton();
            this.cmdNewQuery = new System.Windows.Forms.ToolStripButton();
            this.cmdTable = new System.Windows.Forms.ToolStripButton();
            this.cmdView = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.导出结果ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSql = new Nikita.WinForm.ExtendControl.TextEditorControl();
            this.contextMenuStrip4Editor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdListSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabResult = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRunMessage = new System.Windows.Forms.RichTextBox();
            this.bckWorker = new System.ComponentModel.BackgroundWorker();
            this.toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip4Editor.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.AutoSize = false;
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboDbName,
            this.cmdRun,
            this.cmdNewQuery,
            this.cmdTable,
            this.cmdView,
            this.toolStripDropDownButton1,
            this.toolStripProgressBar1});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1051, 81);
            this.toolBar.TabIndex = 17;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 78);
            this.toolStripLabel1.Text = "当前库：";
            // 
            // cboDbName
            // 
            this.cboDbName.Name = "cboDbName";
            this.cboDbName.Size = new System.Drawing.Size(198, 81);
            // 
            // cmdRun
            // 
            this.cmdRun.AutoSize = false;
            this.cmdRun.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRun.Image = ((System.Drawing.Image)(resources.GetObject("cmdRun.Image")));
            this.cmdRun.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(80, 55);
            this.cmdRun.Text = "执行";
            this.cmdRun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // cmdNewQuery
            // 
            this.cmdNewQuery.AutoSize = false;
            this.cmdNewQuery.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdNewQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewQuery.Image")));
            this.cmdNewQuery.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNewQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdNewQuery.Name = "cmdNewQuery";
            this.cmdNewQuery.Size = new System.Drawing.Size(80, 55);
            this.cmdNewQuery.Text = "停止";
            this.cmdNewQuery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNewQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdNewQuery.Click += new System.EventHandler(this.cmdNewQuery_Click);
            // 
            // cmdTable
            // 
            this.cmdTable.AutoSize = false;
            this.cmdTable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdTable.Image = ((System.Drawing.Image)(resources.GetObject("cmdTable.Image")));
            this.cmdTable.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdTable.Name = "cmdTable";
            this.cmdTable.Size = new System.Drawing.Size(80, 55);
            this.cmdTable.Text = "载入";
            this.cmdTable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdTable.Click += new System.EventHandler(this.cmdTable_Click);
            // 
            // cmdView
            // 
            this.cmdView.AutoSize = false;
            this.cmdView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdView.Image = ((System.Drawing.Image)(resources.GetObject("cmdView.Image")));
            this.cmdView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(80, 55);
            this.cmdView.Text = "保存";
            this.cmdView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出结果ExcelToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 45);
            this.toolStripDropDownButton1.Text = "导出";
            this.toolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 导出结果ExcelToolStripMenuItem
            // 
            this.导出结果ExcelToolStripMenuItem.Name = "导出结果ExcelToolStripMenuItem";
            this.导出结果ExcelToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.导出结果ExcelToolStripMenuItem.Text = "导出Excel";
            this.导出结果ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出结果ExcelToolStripMenuItem_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(117, 25);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 81);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSql);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabResult);
            this.splitContainer1.Size = new System.Drawing.Size(1051, 558);
            this.splitContainer1.SplitterDistance = 412;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 18;
            // 
            // txtSql
            // 
            this.txtSql.ContextMenuStrip = this.contextMenuStrip4Editor;
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.Encoding = ((System.Text.Encoding)(resources.GetObject("txtSql.Encoding")));
            this.txtSql.Location = new System.Drawing.Point(0, 0);
            this.txtSql.Name = "txtSql";
            this.txtSql.ShowEOLMarkers = true;
            this.txtSql.ShowSpaces = true;
            this.txtSql.ShowTabs = true;
            this.txtSql.ShowVRuler = true;
            this.txtSql.Size = new System.Drawing.Size(1051, 412);
            this.txtSql.TabIndex = 0;
            // 
            // contextMenuStrip4Editor
            // 
            this.contextMenuStrip4Editor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdListSplit});
            this.contextMenuStrip4Editor.Name = "contextMenu";
            this.contextMenuStrip4Editor.Size = new System.Drawing.Size(137, 26);
            // 
            // cmdListSplit
            // 
            this.cmdListSplit.Name = "cmdListSplit";
            this.cmdListSplit.Size = new System.Drawing.Size(136, 22);
            this.cmdListSplit.Text = "列表转逗号";
            this.cmdListSplit.Click += new System.EventHandler(this.cmdListSplit_Click);
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.tabPage1);
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResult.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabResult.Location = new System.Drawing.Point(0, 0);
            this.tabResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedIndex = 0;
            this.tabResult.Size = new System.Drawing.Size(1051, 140);
            this.tabResult.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRunMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1043, 110);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "执行信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRunMessage
            // 
            this.txtRunMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRunMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRunMessage.Location = new System.Drawing.Point(3, 4);
            this.txtRunMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRunMessage.Name = "txtRunMessage";
            this.txtRunMessage.Size = new System.Drawing.Size(1037, 102);
            this.txtRunMessage.TabIndex = 0;
            this.txtRunMessage.Text = "";
            // 
            // bckWorker
            // 
            this.bckWorker.WorkerSupportsCancellation = true;
            this.bckWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckWorker_DoWork);
            this.bckWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckWorker_RunWorkerCompleted);
            // 
            // FrmDataBaseQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 639);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolBar);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDataBaseQuery";
            this.Text = "查询窗体";
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip4Editor.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton cmdRun;
        private System.Windows.Forms.ToolStripButton cmdNewQuery;
        private System.Windows.Forms.ToolStripButton cmdTable;
        private System.Windows.Forms.ToolStripButton cmdView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripComboBox cboDbName;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 导出结果ExcelToolStripMenuItem;
        private System.Windows.Forms.TabControl tabResult;
        private System.Windows.Forms.TabPage tabPage1;
        private System.ComponentModel.BackgroundWorker bckWorker;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.RichTextBox txtRunMessage;
        private Nikita.WinForm.ExtendControl.TextEditorControl txtSql;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4Editor;
        private System.Windows.Forms.ToolStripMenuItem cmdListSplit;
    }
}