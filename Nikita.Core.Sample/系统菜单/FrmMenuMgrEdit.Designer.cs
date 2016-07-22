namespace Nikita.Core.Sample
{
    partial class FrmMenuMgrEdit
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMenuClass = new System.Windows.Forms.Label();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.txtMenuClass = new System.Windows.Forms.TextBox();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(107, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMenuClass
            // 
            this.lblMenuClass.AutoSize = true;
            this.lblMenuClass.Location = new System.Drawing.Point(10, 24);
            this.lblMenuClass.Name = "lblMenuClass";
            this.lblMenuClass.Size = new System.Drawing.Size(53, 12);
            this.lblMenuClass.TabIndex = 1;
            this.lblMenuClass.Text = "菜单类名";
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Location = new System.Drawing.Point(10, 66);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(53, 12);
            this.lblMenuName.TabIndex = 2;
            this.lblMenuName.Text = "菜单名称";
            // 
            // txtMenuClass
            // 
            this.txtMenuClass.Location = new System.Drawing.Point(69, 21);
            this.txtMenuClass.Name = "txtMenuClass";
            this.txtMenuClass.Size = new System.Drawing.Size(163, 21);
            this.txtMenuClass.TabIndex = 3;
            // 
            // txtMenuName
            // 
            this.txtMenuName.Location = new System.Drawing.Point(69, 63);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(163, 21);
            this.txtMenuName.TabIndex = 4;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(69, 99);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(163, 21);
            this.txtNameSpace.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "命名空间";
            // 
            // FrmMenuMgrEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 171);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMenuName);
            this.Controls.Add(this.txtMenuClass);
            this.Controls.Add(this.lblMenuName);
            this.Controls.Add(this.lblMenuClass);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmMenuMgrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单编辑";
            this.Load += new System.EventHandler(this.FrmMenuMgrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMenuClass;
        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.TextBox txtMenuClass;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label1;
    }
}