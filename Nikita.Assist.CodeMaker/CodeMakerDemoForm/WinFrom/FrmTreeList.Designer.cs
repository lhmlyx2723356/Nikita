namespace Nikita.Assist.CodeMaker
{
    partial class FrmTreeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTreeListDemo));
            this.sptContainer = new System.Windows.Forms.SplitContainer();
            this.sptQuery = new System.Windows.Forms.SplitContainer();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.dataTlvFilterTextBox = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.olvDataTree = new Nikita.WinForm.ExtendControl.DataTreeListView();
            this.olvColumn1 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.olvColumn2 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.olvColumn3 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.olvColumn4 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.olvColumn5 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).BeginInit();
            this.sptContainer.Panel1.SuspendLayout();
            this.sptContainer.Panel2.SuspendLayout();
            this.sptContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();
            this.sptQuery.Panel2.SuspendLayout();
            this.sptQuery.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvDataTree)).BeginInit();
            this.SuspendLayout();
            // 
            // sptContainer
            // 
            this.sptContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptContainer.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.sptContainer.Location = new System.Drawing.Point(0, 0);
            this.sptContainer.Name = "sptContainer";
            this.sptContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptContainer.Panel1
            // 
            this.sptContainer.Panel1.Controls.Add(this.sptQuery);
            // 
            // sptContainer.Panel2
            // 
            this.sptContainer.Panel2.Controls.Add(this.statusStrip1);
            this.sptContainer.Panel2.Controls.Add(this.olvDataTree);
            this.sptContainer.Size = new System.Drawing.Size(784, 561);
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
            this.grpFilter.Controls.Add(this.dataTlvFilterTextBox);
            this.grpFilter.Location = new System.Drawing.Point(5, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(117, 41);
            this.grpFilter.TabIndex = 18;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "通用过滤";
            // 
            // dataTlvFilterTextBox
            // 
            this.dataTlvFilterTextBox.Location = new System.Drawing.Point(11, 14);
            this.dataTlvFilterTextBox.Name = "dataTlvFilterTextBox";
            this.dataTlvFilterTextBox.Size = new System.Drawing.Size(100, 23);
            this.dataTlvFilterTextBox.TabIndex = 0;
            this.dataTlvFilterTextBox.TextChanged += new System.EventHandler(this.textBoxFilterSimple_TextChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(129, 11);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(55, 28);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // olvDataTree
            // 
            this.olvDataTree.AllColumns.Add(this.olvColumn1);
            this.olvDataTree.AllColumns.Add(this.olvColumn2);
            this.olvDataTree.AllColumns.Add(this.olvColumn3);
            this.olvDataTree.AllColumns.Add(this.olvColumn4);
            this.olvDataTree.AllColumns.Add(this.olvColumn5);
            this.olvDataTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5});
            this.olvDataTree.DataSource = null;
            this.olvDataTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvDataTree.KeyAspectName = "Id";
            this.olvDataTree.Location = new System.Drawing.Point(0, 0);
            this.olvDataTree.Name = "olvDataTree";
            this.olvDataTree.OwnerDraw = true;
            this.olvDataTree.ParentKeyAspectName = "ParentId";
            this.olvDataTree.RootKeyValueString = "";
            this.olvDataTree.ShowGroups = false;
            this.olvDataTree.ShowKeyColumns = false;
            this.olvDataTree.Size = new System.Drawing.Size(784, 510);
            this.olvDataTree.SmallImageList = this.imageList1;
            this.olvDataTree.TabIndex = 0;
            this.olvDataTree.UseCompatibleStateImageBehavior = false;
            this.olvDataTree.UseFilterIndicator = true;
            this.olvDataTree.UseFiltering = true;
            this.olvDataTree.View = System.Windows.Forms.View.Details;
            this.olvDataTree.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Text = "名称";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Company";
            this.olvColumn2.Text = "公司";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Occupation";
            this.olvColumn3.Text = "职位";
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Salary";
            this.olvColumn4.Text = "哈哈";
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Height";
            this.olvColumn5.Text = "身高";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "compass");
            this.imageList1.Images.SetKeyName(1, "down");
            this.imageList1.Images.SetKeyName(2, "user");
            this.imageList1.Images.SetKeyName(3, "find");
            this.imageList1.Images.SetKeyName(4, "folder");
            this.imageList1.Images.SetKeyName(5, "movie");
            this.imageList1.Images.SetKeyName(6, "music");
            this.imageList1.Images.SetKeyName(7, "no");
            this.imageList1.Images.SetKeyName(8, "readonly");
            this.imageList1.Images.SetKeyName(9, "public");
            this.imageList1.Images.SetKeyName(10, "recycle");
            this.imageList1.Images.SetKeyName(11, "spanner");
            this.imageList1.Images.SetKeyName(12, "star");
            this.imageList1.Images.SetKeyName(13, "tick");
            this.imageList1.Images.SetKeyName(14, "archive");
            this.imageList1.Images.SetKeyName(15, "system");
            this.imageList1.Images.SetKeyName(16, "hidden");
            this.imageList1.Images.SetKeyName(17, "temporary");
            // 
            // FrmTreeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.sptContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmTreeList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTreeList";
            this.sptContainer.Panel1.ResumeLayout(false);
            this.sptContainer.Panel2.ResumeLayout(false);
            this.sptContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).EndInit();
            this.sptContainer.ResumeLayout(false);
            this.sptQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();
            this.sptQuery.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvDataTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptContainer;
        private System.Windows.Forms.SplitContainer sptQuery;
        private System.Windows.Forms.Button btnQuery;
        private Nikita.WinForm.ExtendControl.DataTreeListView olvDataTree;
        private Nikita.WinForm.ExtendControl.OLVColumn olvColumn1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox dataTlvFilterTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Nikita.WinForm.ExtendControl.OLVColumn olvColumn2;
        private Nikita.WinForm.ExtendControl.OLVColumn olvColumn3;
        private Nikita.WinForm.ExtendControl.OLVColumn olvColumn4;
        private Nikita.WinForm.ExtendControl.OLVColumn olvColumn5;
    }
}