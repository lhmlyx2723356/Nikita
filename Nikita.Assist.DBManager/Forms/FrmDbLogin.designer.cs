using Nikita.WinForm.ExtendControl;

namespace Nikita.Assist.DBManager
{
    partial class FrmDbLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbLogin));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.cboLogin = new System.Windows.Forms.ComboBox();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkRem = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAllowType = new  CheckedComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectDB = new System.Windows.Forms.Button();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(171, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "连接";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(275, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "服务器名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "登录验证:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "登录名:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "密码:";
            // 
            // cboServer
            // 
            this.cboServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(171, 101);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(177, 20);
            this.cboServer.TabIndex = 6;
            // 
            // cboLogin
            // 
            this.cboLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLogin.FormattingEnabled = true;
            this.cboLogin.Items.AddRange(new object[] {
            "SQL Server 身份验证"});
            this.cboLogin.Location = new System.Drawing.Point(171, 125);
            this.cboLogin.Name = "cboLogin";
            this.cboLogin.Size = new System.Drawing.Size(177, 20);
            this.cboLogin.TabIndex = 7;
            // 
            // cboUser
            // 
            this.cboUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(171, 149);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(177, 20);
            this.cboUser.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(171, 173);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(177, 21);
            this.txtPassword.TabIndex = 9;
            // 
            // chkRem
            // 
            this.chkRem.AutoSize = true;
            this.chkRem.Checked = true;
            this.chkRem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRem.Location = new System.Drawing.Point(174, 253);
            this.chkRem.Name = "chkRem";
            this.chkRem.Size = new System.Drawing.Size(72, 16);
            this.chkRem.TabIndex = 13;
            this.chkRem.Text = "记住密码";
            this.chkRem.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "加载类型:";
            // 
            // chkAllowType
            // 
            this.chkAllowType.CheckOnClick = true;
            this.chkAllowType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chkAllowType.DropDownHeight = 1;
            this.chkAllowType.FormattingEnabled = true;
            this.chkAllowType.IntegralHeight = false;
            this.chkAllowType.Location = new System.Drawing.Point(171, 198);
            this.chkAllowType.Name = "chkAllowType";
            this.chkAllowType.Size = new System.Drawing.Size(177, 22);
            this.chkAllowType.TabIndex = 15;
            this.chkAllowType.ValueSeparator = ", ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "加载数据库:";
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.Location = new System.Drawing.Point(353, 226);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(33, 23);
            this.btnSelectDB.TabIndex = 17;
            this.btnSelectDB.Text = "...";
            this.btnSelectDB.UseVisualStyleBackColor = true;
            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(170, 227);
            this.txtDB.Name = "txtDB";
            this.txtDB.ReadOnly = true;
            this.txtDB.Size = new System.Drawing.Size(177, 21);
            this.txtDB.TabIndex = 18;
            // 
            // FrmDbLogin
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(472, 329);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.btnSelectDB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkAllowType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkRem);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.cboLogin);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDbLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请先连接到服务器";
            this.Load += new System.EventHandler(this.frmDictionaryLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.ComboBox cboLogin;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRem;
        private System.Windows.Forms.Label label5;
        private CheckedComboBox chkAllowType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectDB;
        private System.Windows.Forms.TextBox txtDB;




    }
}