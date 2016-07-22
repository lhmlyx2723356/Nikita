namespace Nikita.Core.Sample 
{
    partial class FrmJsonNetDemo
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.textBoxFilterFast = new System.Windows.Forms.TextBox();
            this.olvFast = new Nikita.WinForm.ExtendControl.FastObjectListView();
            this.olvColumn18 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.olvColumn19 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnDemo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtxCode = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtxResult = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvFast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(824, 453);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.comboBox16);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxFilterFast);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.olvFast);
            this.splitContainer2.Size = new System.Drawing.Size(233, 451);
            this.splitContainer2.SplitterDistance = 43;
            this.splitContainer2.TabIndex = 0;
            // 
            // comboBox16
            // 
            this.comboBox16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox16.FormattingEnabled = true;
            this.comboBox16.Items.AddRange(new object[] {
            "Any text",
            "Prefix",
            "Regex"});
            this.comboBox16.Location = new System.Drawing.Point(130, 12);
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(94, 20);
            this.comboBox16.TabIndex = 3;
            // 
            // textBoxFilterFast
            // 
            this.textBoxFilterFast.Location = new System.Drawing.Point(3, 12);
            this.textBoxFilterFast.Name = "textBoxFilterFast";
            this.textBoxFilterFast.Size = new System.Drawing.Size(120, 21);
            this.textBoxFilterFast.TabIndex = 2;
            this.textBoxFilterFast.TextChanged += new System.EventHandler(this.textBoxFilterFast_TextChanged);
            // 
            // olvFast
            // 
            this.olvFast.AllColumns.Add(this.olvColumn18);
            this.olvFast.AllColumns.Add(this.olvColumn19);
            this.olvFast.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.olvFast.BackgroundImageTiled = true;
            this.olvFast.CheckedAspectName = "";
            this.olvFast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn18,
            this.olvColumn19});
            this.olvFast.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvFast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvFast.EmptyListMsg = "没有数据";
            this.olvFast.FullRowSelect = true;
            this.olvFast.GridLines = true;
            this.olvFast.HideSelection = false;
            this.olvFast.Location = new System.Drawing.Point(0, 0);
            this.olvFast.Name = "olvFast";
            this.olvFast.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.olvFast.ShowCommandMenuOnRightClick = true;
            this.olvFast.ShowGroups = false;
            this.olvFast.ShowImagesOnSubItems = true;
            this.olvFast.ShowItemToolTips = true;
            this.olvFast.Size = new System.Drawing.Size(233, 404);
            this.olvFast.SpaceBetweenGroups = 20;
            this.olvFast.TabIndex = 2;
            this.olvFast.TintSortColumn = true;
            this.olvFast.UseCompatibleStateImageBehavior = false;
            this.olvFast.UseFilterIndicator = true;
            this.olvFast.UseFiltering = true;
            this.olvFast.UseHyperlinks = true;
            this.olvFast.View = System.Windows.Forms.View.Details;
            this.olvFast.VirtualMode = true;
            this.olvFast.SelectedIndexChanged += new System.EventHandler(this.olvFast_SelectedIndexChanged);
            this.olvFast.DoubleClick += new System.EventHandler(this.olvFast_DoubleClick);
            // 
            // olvColumn18
            // 
            this.olvColumn18.AspectName = "Id";
            this.olvColumn18.Text = "序号";
            this.olvColumn18.UseInitialLetterForGroup = true;
            this.olvColumn18.Width = 50;
            // 
            // olvColumn19
            // 
            this.olvColumn19.AspectName = "Name";
            this.olvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn19.IsTileViewColumn = true;
            this.olvColumn19.Text = "Demo名称";
            this.olvColumn19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn19.Width = 200;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnDemo);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer3.Size = new System.Drawing.Size(583, 451);
            this.splitContainer3.SplitterDistance = 44;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(4, 12);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(235, 23);
            this.btnDemo.TabIndex = 0;
            this.btnDemo.Text = "测试";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 403);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtxCode);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "关键代码";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtxCode
            // 
            this.rtxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxCode.Location = new System.Drawing.Point(3, 3);
            this.rtxCode.Name = "rtxCode";
            this.rtxCode.Size = new System.Drawing.Size(569, 371);
            this.rtxCode.TabIndex = 1;
            this.rtxCode.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtxResult);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "输出结果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtxResult
            // 
            this.rtxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxResult.Location = new System.Drawing.Point(3, 3);
            this.rtxResult.Name = "rtxResult";
            this.rtxResult.Size = new System.Drawing.Size(571, 372);
            this.rtxResult.TabIndex = 0;
            this.rtxResult.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(824, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // FrmJsonNetDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmJsonNetDemo";
            this.Text = "FrmJsonNetDemo";
            this.Load += new System.EventHandler(this.FrmJsonNetDemo_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvFast)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Nikita.WinForm.ExtendControl.FastObjectListView olvFast;
        private Nikita.WinForm.ExtendControl.OLVColumn olvColumn18;
        private Nikita.WinForm.ExtendControl.OLVColumn olvColumn19;
        private System.Windows.Forms.ComboBox comboBox16;
        private System.Windows.Forms.TextBox textBoxFilterFast;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtxCode;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtxResult;
    }
}