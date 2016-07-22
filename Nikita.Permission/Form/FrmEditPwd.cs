using Nikita.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmEditPwd : FrmBase
    {
        public FrmEditPwd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入新密码");
                txtUserName.Select();
                return;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("请再次输入密码");
                txtPassword.Select();
                return;
            }
            if (txtUserName.Text.Trim() != txtPassword.Text.Trim())
            {
                MessageBox.Show("两次输入密码不一致，请重新输入");
                txtPassword.Select();
                return;
            }

            //string[] strKey = new string[] { "Password", "Flag", "User_Id", };
            //string[] strVal = new string[] { txtPassword.Text.Trim(), "9", UserInfoHelper.CreateUserId };
            //DataSet ds = this.DataRequest_By_DataSet("Sp_Bse_User_Add_Edit_Del", strKey, strVal);

            //if (ds != null)
            //{
            //    MessageBox.Show("修改密码成功");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("修改密码失败");
            //    txtPassword.Select();
            //}
        }

        private void frmEditPwd_Load(object sender, EventArgs e)
        {
            txtUserName.Select();
        }
    }
}