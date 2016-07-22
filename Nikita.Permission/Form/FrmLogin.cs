using DevExpress.XtraSplashScreen;
using Nikita.Core;
using Nikita.Permission.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmLogin : FrmBase
    {
        private readonly string[] _ctrlNextArray = new string[] { "txtUserName", "txtPassword", "comboBox1" };

        //private string[] _ctrlSaveArrayTxt = new string[] { "账号", "密码" };
        //private string[] _ctrlSaveArray = new string[] { "txtUserName", "txtPassword" };
        private Control _ctrlCurrent;

        private string _strFocusedControlName;

        public FrmLogin()
        {
            InitializeComponent();
        }

        public Form GetForm(Form frmParentForm, string strFormName)
        {
            string fullname = frmParentForm.GetType().Namespace + "." + strFormName;
            Type type = Type.GetType(fullname);
            if (type == null)
            {
                return null;
            }
            Form f = (Form)Activator.CreateInstance(type);
            return f;
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

        private void bckWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DataSet dsMenus = e.Argument as DataSet;
            if (dsMenus != null)
            {
                DataTable dt = dsMenus.Tables[0];
                //foreach (DataRow item in dt.Rows)
                //{
                //    GlobalHelp.DicForms.Add(item["FormName"].ToString(), GetForm(this, item["FormName"].ToString()));
                //}
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw e.Error;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("请稍等....");
                splashScreenManager1.SetWaitFormDescription("正在验证用户信息");
                //SplashScreenManager.ShowForm(typeof (SplashScreen1));
                StaticInfoHelper.IsOpen = 1;
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

                Bse_UserDAL dal = new Bse_UserDAL();
                DataTable dt =
                    dal.GetList("Number='" + txtUserName.Text.Trim() + "' and Password='" + txtPassword.Text.Trim() +
                                "' ").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    UserInfoHelper.CreateUserId = dt.Rows[0]["User_Id"].ToString();
                    UserInfoHelper.UserName = dt.Rows[0]["UserName"].ToString();
                    UserInfoHelper.CreateName = dt.Rows[0]["Realname"].ToString();
                    UserInfoHelper.Number = dt.Rows[0]["Number"].ToString();
                    UserInfoHelper.Password = dt.Rows[0]["Password"].ToString();
                    UserInfoHelper.Dept_Id = dt.Rows[0]["Dept_Id"].ToString();
                    UserInfoHelper.Company_Id = dt.Rows[0]["Company_Id"].ToString();
                    UserInfoHelper.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    UserInfoHelper.DeptName = dt.Rows[0]["DeptName"].ToString();
                    UserInfoHelper.Bloc_Id = dt.Rows[0]["Bloc_Id"].ToString();
                    UserInfoHelper.BlocName = dt.Rows[0]["BlocName"].ToString();
                    UserInfoHelper.SystemId = dt.Rows[0]["SystemId"].ToString();
                    DialogResult = DialogResult.OK;

                    //异步加载窗体
                    Bse_MenuDALExtend menus = new Bse_MenuDALExtend();
                    DataSet dsMenus = menus.GetMenusRibbon();
                    GlobalHelp.DataSetMenus = dsMenus;
                    bckWorker.RunWorkerAsync(dsMenus);
                }
                else
                {
                    MessageDxUtilHelper.ShowTips("用户名或者密码错误，登录失败！");
                    txtPassword.SelectAll();
                }
            }
            finally
            {
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void Ctrl_Enter(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null) _strFocusedControlName = control.Name;
            _ctrlCurrent = sender as Control;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //string loginimg = LinqToXmlHelper.GetXmlNodeValue(FileHelper.GetFilePath("config", "SystemSetting.xml"), "appsetting", "LoginImage");
            //this.BackgroundImage = Image.FromFile(FileHelper.GetFilePath("image", loginimg)); 
            //StringArrary = GetControlInfo(this.groupControl1);
            //string[] CtlFirst = StringArrary[0].Split(',');
            //GetPreCtl(StringArrary, CtlFirst, this.groupControl1);
            if (ConfigHelper.GetConfigKeyValue("AutoLogin") == "true")
            {
                btnLogin_Click(null, null);
            }
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
    }
}