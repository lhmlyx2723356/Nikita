namespace Nikita.Report.WinForm
{
    partial class FrmReportBase
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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tabReport = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ReportContainer = new System.Windows.Forms.SplitContainer();
            this.SplitContainerQuery = new System.Windows.Forms.SplitContainer();
            this.btnQuery = new System.Windows.Forms.Button();
            this.ReportViewerMain = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabReport.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportContainer)).BeginInit();
            this.ReportContainer.Panel1.SuspendLayout();
            this.ReportContainer.Panel2.SuspendLayout();
            this.ReportContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerQuery)).BeginInit();
            this.SplitContainerQuery.Panel2.SuspendLayout();
            this.SplitContainerQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.tabPage1);
            this.tabReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReport.Location = new System.Drawing.Point(0, 0);
            this.tabReport.Name = "tabReport";
            this.tabReport.SelectedIndex = 0;
            this.tabReport.Size = new System.Drawing.Size(784, 561);
            this.tabReport.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ReportContainer);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "xxx报表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ReportContainer
            // 
            this.ReportContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ReportContainer.Location = new System.Drawing.Point(3, 3);
            this.ReportContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReportContainer.Name = "ReportContainer";
            this.ReportContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ReportContainer.Panel1
            // 
            this.ReportContainer.Panel1.Controls.Add(this.SplitContainerQuery);
            // 
            // ReportContainer.Panel2
            // 
            this.ReportContainer.Panel2.Controls.Add(this.ReportViewerMain);
            this.ReportContainer.Size = new System.Drawing.Size(770, 525);
            this.ReportContainer.SplitterDistance = 52;
            this.ReportContainer.SplitterWidth = 6;
            this.ReportContainer.TabIndex = 1;
            // 
            // SplitContainerQuery
            // 
            this.SplitContainerQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainerQuery.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SplitContainerQuery.Name = "SplitContainerQuery";
            // 
            // SplitContainerQuery.Panel2
            // 
            this.SplitContainerQuery.Panel2.Controls.Add(this.btnQuery);
            this.SplitContainerQuery.Size = new System.Drawing.Size(770, 52);
            this.SplitContainerQuery.SplitterDistance = 652;
            this.SplitContainerQuery.SplitterWidth = 5;
            this.SplitContainerQuery.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(12, 6);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(87, 33);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // ReportViewerMain
            // 
            this.ReportViewerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerMain.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReportViewerMain.Name = "ReportViewerMain";
            this.ReportViewerMain.Size = new System.Drawing.Size(770, 467);
            this.ReportViewerMain.TabIndex = 1;
            // 
            // FrmReportBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabReport);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmReportBase";
            this.ShowIcon = false;
            this.Text = "报表";
            this.Load += new System.EventHandler(this.frmReportBase_Load);
            this.tabReport.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ReportContainer.Panel1.ResumeLayout(false);
            this.ReportContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReportContainer)).EndInit();
            this.ReportContainer.ResumeLayout(false);
            this.SplitContainerQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerQuery)).EndInit();
            this.SplitContainerQuery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion 
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer ReportContainer;
        private System.Windows.Forms.SplitContainer SplitContainerQuery;
        private System.Windows.Forms.Button btnQuery;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewerMain;
    }
}