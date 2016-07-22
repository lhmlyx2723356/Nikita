namespace Nikita.Assist.CodeMaker
{
    partial class FrmModelCreater
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModelCreater));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAllToLeft = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnAllToRight = new System.Windows.Forms.Button();
            this.btnToRight = new System.Windows.Forms.Button();
            this.lsbright = new System.Windows.Forms.ListBox();
            this.lsbleft = new System.Windows.Forms.ListBox();
            this.txtCode = new ICSharpCode.TextEditor.TextEditorControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtPrefix);
            this.splitContainer1.Panel1.Controls.Add(this.lblPrefix);
            this.splitContainer1.Panel1.Controls.Add(this.btnGen);
            this.splitContainer1.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtCode);
            this.splitContainer1.Size = new System.Drawing.Size(1081, 561);
            this.splitContainer1.SplitterDistance = 477;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(110, 462);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(168, 23);
            this.txtPrefix.TabIndex = 6;
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(12, 465);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(92, 17);
            this.lblPrefix.TabIndex = 5;
            this.lblPrefix.Text = "去除表名前缀：";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(379, 457);
            this.btnGen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(87, 33);
            this.btnGen.TabIndex = 4;
            this.btnGen.Text = "生成代码";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(284, 457);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 33);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "实体预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAllToLeft);
            this.groupBox2.Controls.Add(this.btnToLeft);
            this.groupBox2.Controls.Add(this.btnAllToRight);
            this.groupBox2.Controls.Add(this.btnToRight);
            this.groupBox2.Controls.Add(this.lsbright);
            this.groupBox2.Controls.Add(this.lsbleft);
            this.groupBox2.Location = new System.Drawing.Point(14, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(480, 433);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择操作表";
            // 
            // btnAllToLeft
            // 
            this.btnAllToLeft.Location = new System.Drawing.Point(206, 315);
            this.btnAllToLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(48, 33);
            this.btnAllToLeft.TabIndex = 1;
            this.btnAllToLeft.Text = "< <";
            this.btnAllToLeft.UseVisualStyleBackColor = true;
            this.btnAllToLeft.Click += new System.EventHandler(this.btnAllToLeft_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point(206, 249);
            this.btnToLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(48, 33);
            this.btnToLeft.TabIndex = 1;
            this.btnToLeft.Text = "<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnAllToRight
            // 
            this.btnAllToRight.Location = new System.Drawing.Point(206, 175);
            this.btnAllToRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAllToRight.Name = "btnAllToRight";
            this.btnAllToRight.Size = new System.Drawing.Size(48, 33);
            this.btnAllToRight.TabIndex = 1;
            this.btnAllToRight.Text = "> >";
            this.btnAllToRight.UseVisualStyleBackColor = true;
            this.btnAllToRight.Click += new System.EventHandler(this.btnAllToRight_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Location = new System.Drawing.Point(206, 104);
            this.btnToRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(48, 33);
            this.btnToRight.TabIndex = 1;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // lsbright
            // 
            this.lsbright.FormattingEnabled = true;
            this.lsbright.ItemHeight = 17;
            this.lsbright.Location = new System.Drawing.Point(272, 28);
            this.lsbright.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbright.Name = "lsbright";
            this.lsbright.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbright.Size = new System.Drawing.Size(180, 378);
            this.lsbright.TabIndex = 0;
            this.lsbright.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbright_MouseDoubleClick);
            // 
            // lsbleft
            // 
            this.lsbleft.FormattingEnabled = true;
            this.lsbleft.ItemHeight = 17;
            this.lsbleft.Location = new System.Drawing.Point(16, 28);
            this.lsbleft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbleft.Name = "lsbleft";
            this.lsbleft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbleft.Size = new System.Drawing.Size(180, 378);
            this.lsbleft.TabIndex = 0;
            this.lsbleft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbleft_MouseDoubleClick);
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Encoding = ((System.Text.Encoding)(resources.GetObject("txtCode.Encoding")));
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.ShowEOLMarkers = true;
            this.txtCode.ShowSpaces = true;
            this.txtCode.ShowTabs = true;
            this.txtCode.ShowVRuler = true;
            this.txtCode.Size = new System.Drawing.Size(597, 559);
            this.txtCode.TabIndex = 0;
            // 
            // FrmModelCreater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 561);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmModelCreater";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量生成实体";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAllToLeft;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnAllToRight;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.ListBox lsbright;
        private System.Windows.Forms.ListBox lsbleft;
        private ICSharpCode.TextEditor.TextEditorControl txtCode;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblPrefix;
    }
}

