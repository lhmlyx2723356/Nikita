namespace Nikita.WinForm.ExtendControl4DX
{
    partial class MgncPager
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MgncPager));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lcStatus = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonToPage = new DevExpress.XtraEditors.SimpleButton();
            this.textEditToPage = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonExportCurPage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonExportAllPage = new DevExpress.XtraEditors.SimpleButton();
            this.textEditAllPageCount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditPageSize = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonEnd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonNext = new DevExpress.XtraEditors.SimpleButton();
            this.textEditCurPage = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonPre = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonFirst = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditToPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAllPageCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPageSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.lcStatus);
            this.panelControl1.Controls.Add(this.simpleButtonToPage);
            this.panelControl1.Controls.Add(this.textEditToPage);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.simpleButtonExportCurPage);
            this.panelControl1.Controls.Add(this.simpleButtonExportAllPage);
            this.panelControl1.Controls.Add(this.textEditAllPageCount);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.comboBoxEditPageSize);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.simpleButtonEnd);
            this.panelControl1.Controls.Add(this.simpleButtonNext);
            this.panelControl1.Controls.Add(this.textEditCurPage);
            this.panelControl1.Controls.Add(this.simpleButtonPre);
            this.panelControl1.Controls.Add(this.simpleButtonFirst);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(817, 33);
            this.panelControl1.TabIndex = 29;
            // 
            // lcStatus
            // 
            this.lcStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcStatus.Location = new System.Drawing.Point(432, 2);
            this.lcStatus.Name = "lcStatus";
            this.lcStatus.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lcStatus.Size = new System.Drawing.Size(233, 29);
            this.lcStatus.TabIndex = 12;
            this.lcStatus.Text = "(共XXX条记录，每页XX条，共XX页)";
            // 
            // simpleButtonToPage
            // 
            this.simpleButtonToPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonToPage.Location = new System.Drawing.Point(400, 2);
            this.simpleButtonToPage.Name = "simpleButtonToPage";
            this.simpleButtonToPage.Size = new System.Drawing.Size(32, 29);
            this.simpleButtonToPage.TabIndex = 13;
            this.simpleButtonToPage.Text = "跳转";
            this.simpleButtonToPage.Click += new System.EventHandler(this.simpleButtonToPage_Click);
            // 
            // textEditToPage
            // 
            this.textEditToPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.textEditToPage.EditValue = "1";
            this.textEditToPage.Location = new System.Drawing.Point(370, 2);
            this.textEditToPage.Name = "textEditToPage";
            this.textEditToPage.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditToPage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditToPage.Properties.AutoHeight = false;
            this.textEditToPage.Size = new System.Drawing.Size(30, 29);
            this.textEditToPage.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl2.Location = new System.Drawing.Point(330, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 29);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "当前页：";
            // 
            // simpleButtonExportCurPage
            // 
            this.simpleButtonExportCurPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExportCurPage.Location = new System.Drawing.Point(665, 2);
            this.simpleButtonExportCurPage.Name = "simpleButtonExportCurPage";
            this.simpleButtonExportCurPage.Size = new System.Drawing.Size(75, 29);
            this.simpleButtonExportCurPage.TabIndex = 2;
            this.simpleButtonExportCurPage.Text = "导出当前页";
            this.simpleButtonExportCurPage.Click += new System.EventHandler(this.simpleButtonExportCurPage_Click);
            // 
            // simpleButtonExportAllPage
            // 
            this.simpleButtonExportAllPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExportAllPage.Location = new System.Drawing.Point(740, 2);
            this.simpleButtonExportAllPage.Name = "simpleButtonExportAllPage";
            this.simpleButtonExportAllPage.Size = new System.Drawing.Size(75, 29);
            this.simpleButtonExportAllPage.TabIndex = 2;
            this.simpleButtonExportAllPage.Text = "导出全部页";
            this.simpleButtonExportAllPage.Click += new System.EventHandler(this.simpleButtonExportAllPage_Click);
            // 
            // textEditAllPageCount
            // 
            this.textEditAllPageCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.textEditAllPageCount.Location = new System.Drawing.Point(301, 2);
            this.textEditAllPageCount.Name = "textEditAllPageCount";
            this.textEditAllPageCount.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.textEditAllPageCount.Properties.Appearance.Options.UseForeColor = true;
            this.textEditAllPageCount.Properties.AutoHeight = false;
            this.textEditAllPageCount.Properties.ReadOnly = true;
            this.textEditAllPageCount.Size = new System.Drawing.Size(29, 29);
            this.textEditAllPageCount.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl4.Location = new System.Drawing.Point(259, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 29);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "总页数：";
            // 
            // comboBoxEditPageSize
            // 
            this.comboBoxEditPageSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxEditPageSize.EditValue = "100";
            this.comboBoxEditPageSize.Location = new System.Drawing.Point(210, 2);
            this.comboBoxEditPageSize.Name = "comboBoxEditPageSize";
            this.comboBoxEditPageSize.Properties.Appearance.Options.UseTextOptions = true;
            this.comboBoxEditPageSize.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.comboBoxEditPageSize.Properties.AutoHeight = false;
            this.comboBoxEditPageSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditPageSize.Properties.DisplayFormat.FormatString = "d";
            this.comboBoxEditPageSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.comboBoxEditPageSize.Properties.EditFormat.FormatString = "d";
            this.comboBoxEditPageSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.comboBoxEditPageSize.Properties.EditValueChangedDelay = 1;
            this.comboBoxEditPageSize.Properties.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "50",
            "100"});
            this.comboBoxEditPageSize.Size = new System.Drawing.Size(49, 29);
            this.comboBoxEditPageSize.TabIndex = 7;
            this.comboBoxEditPageSize.EditValueChanged += new System.EventHandler(this.comboBoxEditPageSize_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(150, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 29);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = " 分页大小：";
            // 
            // simpleButtonEnd
            // 
            this.simpleButtonEnd.Appearance.Options.UseTextOptions = true;
            this.simpleButtonEnd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButtonEnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonEnd.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonEnd.Image")));
            this.simpleButtonEnd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonEnd.Location = new System.Drawing.Point(121, 2);
            this.simpleButtonEnd.Name = "simpleButtonEnd";
            this.simpleButtonEnd.Size = new System.Drawing.Size(29, 29);
            this.simpleButtonEnd.TabIndex = 0;
            this.simpleButtonEnd.Click += new System.EventHandler(this.simpleButtonEnd_Click);
            // 
            // simpleButtonNext
            // 
            this.simpleButtonNext.Appearance.Options.UseTextOptions = true;
            this.simpleButtonNext.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButtonNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonNext.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonNext.Image")));
            this.simpleButtonNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonNext.Location = new System.Drawing.Point(92, 2);
            this.simpleButtonNext.Name = "simpleButtonNext";
            this.simpleButtonNext.Size = new System.Drawing.Size(29, 29);
            this.simpleButtonNext.TabIndex = 0;
            this.simpleButtonNext.Click += new System.EventHandler(this.simpleButtonNext_Click);
            // 
            // textEditCurPage
            // 
            this.textEditCurPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.textEditCurPage.EditValue = "1";
            this.textEditCurPage.Location = new System.Drawing.Point(60, 2);
            this.textEditCurPage.Name = "textEditCurPage";
            this.textEditCurPage.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditCurPage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditCurPage.Properties.AutoHeight = false;
            this.textEditCurPage.Properties.ReadOnly = true;
            this.textEditCurPage.Size = new System.Drawing.Size(32, 29);
            this.textEditCurPage.TabIndex = 4;
            // 
            // simpleButtonPre
            // 
            this.simpleButtonPre.Appearance.Options.UseTextOptions = true;
            this.simpleButtonPre.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButtonPre.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonPre.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonPre.Image")));
            this.simpleButtonPre.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonPre.Location = new System.Drawing.Point(31, 2);
            this.simpleButtonPre.Name = "simpleButtonPre";
            this.simpleButtonPre.Size = new System.Drawing.Size(29, 29);
            this.simpleButtonPre.TabIndex = 0;
            this.simpleButtonPre.Click += new System.EventHandler(this.simpleButtonPre_Click);
            // 
            // simpleButtonFirst
            // 
            this.simpleButtonFirst.Appearance.Options.UseTextOptions = true;
            this.simpleButtonFirst.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButtonFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonFirst.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonFirst.Image")));
            this.simpleButtonFirst.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonFirst.Location = new System.Drawing.Point(2, 2);
            this.simpleButtonFirst.Name = "simpleButtonFirst";
            this.simpleButtonFirst.Size = new System.Drawing.Size(29, 29);
            this.simpleButtonFirst.TabIndex = 0;
            this.simpleButtonFirst.Click += new System.EventHandler(this.simpleButtonFirst_Click);
            // 
            // MgncPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "MgncPager";
            this.Size = new System.Drawing.Size(817, 33);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditToPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAllPageCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPageSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurPage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit textEditCurPage;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExportAllPage;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExportCurPage;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEnd;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNext;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPre;
        private DevExpress.XtraEditors.SimpleButton simpleButtonFirst;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditPageSize;
        private DevExpress.XtraEditors.TextEdit textEditToPage;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lcStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButtonToPage;
        private DevExpress.XtraEditors.TextEdit textEditAllPageCount;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
