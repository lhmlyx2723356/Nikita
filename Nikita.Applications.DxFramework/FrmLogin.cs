using Nikita.Core;
using Nikita.Core4Dx;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;  

namespace Nikita.Applications.DxFramework
{
    public partial class FrmLogin : FrmBase
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private readonly string[] _ctrlNextArray = new string[] { "txtUserName", "txtPassword", "comboBox1" };
        //private string[] _ctrlSaveArrayTxt = new string[] { "账号", "密码" };
        //private string[] _ctrlSaveArray = new string[] { "txtUserName", "txtPassword" };
        Control _ctrlCurrent;
        string _strFocusedControlName;
        private void frmLogin_Load(object sender, EventArgs e)
        {
            comboBox1.Text = ConfigHelper.GetConfigKeyValue("SystemStyle");
            //string loginimg = LinqToXmlHelper.GetXmlNodeValue(FileHelper.GetFilePath("config", "SystemSetting.xml"), "appsetting", "LoginImage");
            //this.BackgroundImage = Image.FromFile(FileHelper.GetFilePath("image", loginimg));

            //StringArrary = GetControlInfo(this.groupControl1);
            //string[] CtlFirst = StringArrary[0].Split(',');
            //GetPreCtl(StringArrary, CtlFirst, this.groupControl1);
        }

        private string GetNextCtrl()
        {
            string ctrlNext = string.Empty;
            for (int i = 0; i < _ctrlNextArray.Length; i++)
            {
                if (_strFocusedControlName == _ctrlNextArray[i].Trim() && (i + 1) < _ctrlNextArray.Length)
                {
                    ctrlNext = _ctrlNextArray[i + 1].Trim();
                }
            }
            return ctrlNext;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (_ctrlCurrent == null)
                {
                    return false;
                }
                string controlNext = GetNextCtrl();
                if (controlNext != string.Empty)
                {
                    Control test = groupControl1.Controls.Find(controlNext, false)[0];
                    DoFocus(test);
                    return true;
                }
                btnLogin_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
         
        private void Ctrl_Enter(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null) _strFocusedControlName = control.Name;
            _ctrlCurrent = sender as Control;
        }
         
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"账号不能为空！");
                txtUserName.Focus();
                return;
            }

            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"密码不能为空！");
                txtPassword.Focus();
                return;
            }  
            DataTable dt = new DataTable();
            if (dt.Rows.Count > 0)
            {
                UserInfoHelper.SystemStyle = comboBox1.Text;
                UserInfoHelper.CreateUserId = dt.Rows[0]["User_Id"].ToString();
                UserInfoHelper.UserName = dt.Rows[0]["UserName"].ToString();
                UserInfoHelper.CreateName = dt.Rows[0]["Realname"].ToString();
                UserInfoHelper.Number = dt.Rows[0]["Number"].ToString();
                UserInfoHelper.Password = dt.Rows[0]["Password"].ToString();
                UserInfoHelper.Dept_Id = dt.Rows[0]["Dept_Id"].ToString();
                UserInfoHelper.Company_Id = "-1";
                UserInfoHelper.CompanyName = "";
                UserInfoHelper.DeptName = "";
                UserInfoHelper.Bloc_Id = "-1";
                UserInfoHelper.BlocName = "";
                DialogResult = DialogResult.OK; 
            }
            else
            {
                MessageDxUtilHelper.ShowTips("用户名或者密码错误，登录失败！");
                txtPassword.SelectAll();
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            splashScreenManager1.ShowWaitForm();
            //BseDal bsedao = new BseDal();
            //BseVersionUpdateLogDAL dao = new BseVersionUpdateLogDAL();
            DataTable dt = new DataTable();// dao.JudgeExistBseVersionUpdateLog(Application.ProductVersion);
            if (dt.Rows.Count == 0 || dt.Rows[0]["NeedUpdate"].ToString() == "0")
            {
                splashScreenManager1.CloseWaitForm(); 
                btnLogin.Enabled = true;
                return;
            } 
            else
            {
                splashScreenManager1.CloseWaitForm();
                string autoUpdateInfo = string.Empty;
                string[] strAutoUpdateInfo = dt.Rows[0]["Remark"].ToString().Trim().Split('|');
                autoUpdateInfo = strAutoUpdateInfo.Aggregate(autoUpdateInfo, (current, t) => current + (t + Environment.NewLine));
                 
                frmAutoUpdateInfo frmUpdate = new frmAutoUpdateInfo(autoUpdateInfo);
                if (frmUpdate.ShowDialog() != DialogResult.OK)
                {
                    return;
                } 

                try
                {
                    if (dt.Rows[0]["FileNames"].ToString().Trim().Length > 0)
                    {
                        string[] fileNames = dt.Rows[0]["FileNames"].ToString().Trim().Split(',');
                        foreach (string t in fileNames)
                        {
                            //bsedao.DownLoadUpdateFile(string.Empty, ConfigurationManager.AppSettings["SystemUpdateFilePath"], t.Trim());
                        }
                    }
                    //if (File.Exists(strFile))
                    //{
                    //    File.SetAttributes(strFile, FileAttributes.Normal);  
                    //}
                    //else
                    //{ 
                    //bsedao.DownLoadUpdateFile(string.Empty, ConfigurationManager.AppSettings["SystemUpdateFilePath"], Application.ProductName + ".zip");
                    Process.Start("H.M.AutoUpdate.exe", Application.ProductName);
                    Application.Exit();
                    //}
                }
                catch (Exception err)
                {
                    MessageBox.Show(@"下载更新文件出错：" + err.Message);
                }
            }
            btnLogin.Enabled = true;
        }
    }
}
