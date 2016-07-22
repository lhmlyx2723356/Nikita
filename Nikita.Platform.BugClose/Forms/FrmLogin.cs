using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.IDAL; 
using Nikita.Base.Services;


namespace Nikita.Platform.BugClose
{
    public partial class FrmLogin : Form 
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtUserName.Select();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = txtPassword.Text = string.Empty;
            txtUserName.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        { 
            if (txtUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入登录账号");
                txtUserName.Select();
                return;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入登录密码");
                txtPassword.Select();
                return;
            }

            DataTable dt = PermissionService.GetPermission(txtUserName.Text.Trim(), txtPassword.Text.Trim(),false);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(@"用户名、密码错误，或者无系统权限");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
         

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            //btnOK.Enabled = false;
            //BseDal bsedao = new BseDal();
            //BseVersionUpdateLogDAL dao = new BseVersionUpdateLogDAL();
            //DataTable dt = dao.JudgeExistBseVersionUpdateLog(Application.ProductVersion);
            //if (dt.Rows.Count == 0 || dt.Rows[0]["NeedUpdate"].ToString() == "0")
            //{
            //    btnOK.Enabled = true;
            //    return;
            //}
            //else
            //{
            //    string autoUpdateInfo = string.Empty;
            //    string[] strAutoUpdateInfo = dt.Rows[0]["Remark"].ToString().Trim().Split('|');
            //    autoUpdateInfo = strAutoUpdateInfo.Aggregate(autoUpdateInfo, (current, t) => current + (t + Environment.NewLine));

            //    FrmAutoUpdateInfo frmUpdate = new FrmAutoUpdateInfo(autoUpdateInfo);
            //    if (frmUpdate.ShowDialog() != DialogResult.OK)
            //    {
            //        return;
            //    }

            //    try
            //    {
            //        if (dt.Rows[0]["FileNames"].ToString().Trim().Length > 0)
            //        {
            //            string[] fileNames = dt.Rows[0]["FileNames"].ToString().Trim().Split(',');
            //            foreach (string t in fileNames)
            //            {
            //                bsedao.DownLoadUpdateFile(string.Empty, ConfigurationManager.AppSettings["SystemUpdateFilePath"], t.Trim());
            //            }
            //        }
            //        //if (File.Exists(strFile))
            //        //{
            //        //    File.SetAttributes(strFile, FileAttributes.Normal);
            //        //}
            //        //else
            //        //{
            //        bsedao.DownLoadUpdateFile(string.Empty, ConfigurationManager.AppSettings["SystemUpdateFilePath"], Application.ProductName + ".zip");
            //        Process.Start("Nikita.Assist.AutoUpdater.exe", Application.ProductName);
            //        Application.Exit();
            //        //}
            //    }
            //    catch (Exception err)
            //    {
            //        MessageBox.Show(@"下载更新文件出错：" + err.Message);
            //    }
            //}
            //btnOK.Enabled = true;
        }
         
    }
}