namespace Nikita.Assist.CodeMaker
{
    partial class FrmTableList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableList));
            this.tvwDataBase = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvwDataBase
            // 
            this.tvwDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDataBase.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvwDataBase.Indent = 19;
            this.tvwDataBase.Location = new System.Drawing.Point(0, 2);
            this.tvwDataBase.Name = "tvwDataBase";
            this.tvwDataBase.Size = new System.Drawing.Size(196, 320);
            this.tvwDataBase.TabIndex = 36;
            // 
            // FrmTableList
            // 
            this.ClientSize = new System.Drawing.Size(196, 322);
            this.Controls.Add(this.tvwDataBase);
            this.DockAreas = ((Nikita.WinForm.ExtendControl.DockAreas)((((Nikita.WinForm.ExtendControl.DockAreas.DockLeft | Nikita.WinForm.ExtendControl.DockAreas.DockRight) 
            | Nikita.WinForm.ExtendControl.DockAreas.DockTop) 
            | Nikita.WinForm.ExtendControl.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTableList";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.ShowHint = Nikita.WinForm.ExtendControl.DockState.DockLeft;
            this.TabText = "数据库信息";
            this.Text = "对象资源管理器";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TreeView tvwDataBase;

    }
}