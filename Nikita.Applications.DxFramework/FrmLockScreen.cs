using Nikita.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Nikita.Applications.DxFramework
{
    public partial class FrmLockScreen : Form
    {
        public FrmLockScreen()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.txtPassword.Text.Trim()==string.Empty)
            {
                MessageBox.Show("请输入密码");
                txtPassword.Select();
                return;
            }
            else
            {
                if (txtPassword.Text.Trim()==UserInfoHelper.Password)
                {
                    this.DialogResult  = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误，请重新输入");
                    txtPassword.Select();
                    return;
                }
            }
        }

        private void frmLockScreen_Load(object sender, EventArgs e)
        {
            txtPassword.Select();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                btnOk_Click(null, null);
            }
        }
    }
}
