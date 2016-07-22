using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using Nikita.Core;
using Nikita.Permission.DAL;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmMainRibbon : FrmBase
    {
        #region 成员变量

        /// <summary>快捷键数据表
        /// 快捷键数据表
        /// </summary>
        private DataTable m_dtShortcut;

        /// <summary>双加关闭当前窗体
        ///
        /// </summary>
        private DateTime m_lastClickTime = DateTime.Now;

        #endregion 成员变量

        /// <summary>构造函数
        /// 构造函数
        /// </summary>
        public FrmMainRibbon()
        {
            InitializeComponent();
            //加载皮肤
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        #region 基础事件

        /// <summary>快捷键操作
        /// 快捷键操作
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (DataTableHelper.IsHaveRows(m_dtShortcut))
            {
                //112 F1
                //113 F2
                //114 F3
                //115 F4
                //117 F6
                //118 F7
                //119 F8
                //120 F9
                DataRow[] drs = m_dtShortcut.Select("Shortcut_Key = '" + keyData.ToString() + "' and System='Frame' ");
                if (drs.Length > 0 && keyData != Keys.Escape && keyData != Keys.F9 && keyData != Keys.F12)
                {
                    if (drs.Length == 1)
                    {
                        OpenForm(this, drs[0]["Shortcut_Form"].ToString(), drs[0]["Shortcut_Name"].ToString(), drs[0]["NavigaUrl"].ToString());
                    }
                    else
                    {
                        MessageBox.Show(@"一个快捷键对应了多个操作，请重新设置快捷键");
                    }
                }
                else
                {
                    if (keyData == Keys.Escape)//关闭当前页面
                    {
                        if (MdiChildren.Length > 0)
                        {
                            var activeMdiChild = ActiveMdiChild;
                            if (activeMdiChild != null) activeMdiChild.Close();
                        }
                    }

                    if (keyData == Keys.F12)// 退出系统
                    {
                        Application.Exit();
                    }

                    if (keyData == Keys.F9)//切换用户
                    {
                        btnChgUser_ItemClick(null, null);
                    }
                }
            }
            tabControl.Visible = MdiChildren.Length <= 0;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>单击事件
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //获取左侧栏的name值
                string strPageName = e.Link.Item.Name;
                string strCaption = e.Link.Caption;
                string strUrl = e.Link.Item.Tag.ToString();
                if (StaticInfoHelper.IsOpen == 0)
                {
                    SplashScreenManager.ShowWaitForm();
                    SplashScreenManager.SetWaitFormCaption("正在努力打开");
                    SplashScreenManager.SetWaitFormDescription("第一个页面加载稍微慢点,稍等一会");
                    OpenForm(this, strPageName, strCaption, strUrl);
                    SplashScreenManager.CloseWaitForm();
                    StaticInfoHelper.IsOpen = 1;
                }
                else if (StaticInfoHelper.IsOpen == 1)
                {
                    OpenForm(this, strPageName, strCaption, strUrl);
                }
                tabControl.Visible = MdiChildren.Length <= 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>切换用户
        /// 切换用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChgUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            string path = Application.StartupPath;
            ProcessStartInfo info = new ProcessStartInfo { FileName = path + "\\Nikita.Permission.exe" };
            Process.Start(info);
            Close();
        }

        /// <summary>退出
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>修改密码
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdatePwd_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmEditPwd frmEdit = new FrmEditPwd();
            frmEdit.ShowDialog();
        }

        /// <summary>窗体加载
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRibbonMain_Load(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowForm(typeof(SplashScreen1));
            StaticInfoHelper.IsOpen = 0;
            string path = FileHelper.GetFilePath("config", "SystemSetting.xml");
            barStaticItem1.Caption = @"欢迎您:" + UserInfoHelper.CreateName;
            barStaticItem2.Caption = LinqToXmlHelper.GetXmlNodeValue(path, "appsetting", "Company");
            barStaticItem3.Caption = LinqToXmlHelper.GetXmlNodeValue(path, "appsetting", "Telephone");
            barStaticItem4.Caption = LinqToXmlHelper.GetXmlNodeValue(path, "appsetting", "QQ");
            GetMenuBind();
            ribbon.SelectedPage = ribbon.Pages["LimitPage"];
            //if (ConfigHelper.GetConfigKeyValue("AutoRunFrm") != string.Empty)
            //{
            //    string[] strFrm = ConfigHelper.GetConfigKeyValue("AutoRunFrm").Split('|');
            //    foreach (string t in strFrm)
            //    {
            //        OpenForm(this, t.Split('*')[0], t.Split('*')[1], "");
            //    }
            //}
            //SplashScreenManager.CloseForm();
        }

        private void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DateTime pointDt = DateTime.Now;
                TimeSpan pSpan = pointDt.Subtract(m_lastClickTime);
                if (pSpan.TotalMilliseconds < 300)//如果两次点击的时间间隔小于300毫秒，则认为是双击
                {
                    if (MdiChildren.Length > 0)
                    {
                        var activeMdiChild = ActiveMdiChild;
                        if (activeMdiChild != null) activeMdiChild.Close();
                    }
                    if (MdiChildren.Length == 0)
                    {
                        tabControl.Visible = true;
                    }
                    m_lastClickTime = pointDt.AddMinutes(-1);
                }
                else
                {
                    m_lastClickTime = pointDt;
                }
            }
        }

        #endregion 基础事件

        #region 基础方法

        /// <summary>反射出子窗体实例
        ///
        /// </summary>
        /// <param name="frmParentForm">父窗体</param>
        /// <param name="strFormName">子窗体名称</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Form GetForm(Form frmParentForm, string strFormName, params Object[] args)
        {
            string fullname = frmParentForm.GetType().Namespace + "." + strFormName;
            if (args.Length == 0)
            {
                Form f = (Form)Activator.CreateInstance(Type.GetType(fullname));
                return f;
            }
            else
            {
                Form f = (Form)Activator.CreateInstance(Type.GetType(fullname), args);
                return f;
            }
        }

        /// <summary>反射出子窗体实例(不带参数)
        ///
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Form GetForm(Form ParentForm, string strName)
        {
            //if (GlobalHelp.DicForms.ContainsKey(strName))
            //{
            //    return GlobalHelp.DicForms[strName];
            //}
            string strFullname = ParentForm.GetType().Namespace + "." + strName;
            Type type = Type.GetType(strFullname);
            if (type == null)
            {
                MessageBox.Show("找不到对应窗体");
                return null;
            }
            Form f = (Form)Activator.CreateInstance(type);
            return f;
        }

        /// <summary>点击顶部菜单打开模态窗体。
        ///
        /// </summary>
        /// <param name="frmParentForm"></param>
        /// <param name="strName"></param>
        public static void OpenDialogForm(Form frmParentForm, string strName)
        {
            Form frm = GetForm(frmParentForm, strName);
            frm.ShowDialog();
        }

        /// <summary>根据反射实例出来的子窗体去打开子窗体
        ///
        /// </summary>
        /// <param name="frmParent">父窗体</param>
        /// <param name="strName">子窗体名称</param>
        /// <param name="strCaption"></param>
        /// <param name="strUrl"></param>
        /// <param name="args"></param>
        public static void OpenForm(Form frmParent, string strName, string strCaption, string strUrl, params Object[] args)
        {
            if (strName != "frmMainBrowser")
            {
                if (args.Length == 0)
                {
                    Form frmChild = GetForm(frmParent, strName);
                    frmChild.Text = strCaption;
                    DxCtlHelper.OpenChildFrom(frmParent, frmChild);
                }
                //else
                //{
                //    Form FrmChild = GetForm(FrmParent, name, args);
                //    FrmChild.Text = caption;
                //    DxCtlHelper.OpenChildFrom(FrmParent, FrmChild);
                //}
            }
            else
            {
                if (args.Length == 0)
                {
                    Form frmChild = GetForm(frmParent, strName);
                    frmChild.Text = strCaption;
                    DxCtlHelper.OpenChildFromBs(frmParent, frmChild, frmChild.Text, strUrl);
                }
                //else
                //{
                //    Form FrmChild = GetForm(FrmParent, name, args);
                //    FrmChild.Text = caption;
                //    DxCtlHelper.OpenChildFromBs(FrmParent, FrmChild, FrmChild.Text);
                //}
            }
        }

        /// <summary>获取快捷键列表
        /// 获取快捷键列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetBindShortcut(DataTable dt)
        {
            DataTable dtShortcut = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                dtShortcut.Columns.Add("Shortcut_Name", typeof(string));
                //dtShortcut.Columns.Add("Shortcut_Key", typeof(string));
                dtShortcut.Columns.Add("image", typeof(byte[]));
                //dtShortcut.Columns.Add("Shortcut_Name", System.Type.GetType("System.String"));
                //dtShortcut.Columns.Add("Shortcut_Key", System.Type.GetType("System.String"));
                //dtShortcut.Columns.Add("image", System.Type.GetType("System.Byte[]"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dtShortcut.NewRow();
                    //dr["Shortcut_Name"] = "链接:" + dt.Rows[i]["Shortcut_Name"];
                    //dr["Shortcut_Key"] = "快捷键:" + dt.Rows[i]["Shortcut_Key"];
                    dr["Shortcut_Name"] = dt.Rows[i]["Shortcut_Name"] + "(" + dt.Rows[i]["Shortcut_Key"] + ")";
                    string imagePath = Application.StartupPath + "\\shortcut\\" + dt.Rows[i]["Shortcut_ImageUrl"];
                    if (File.Exists(imagePath))
                    {
                        dr["image"] = ImageHelper.ImageToByte(imagePath);
                    }
                    else
                    {
                        if (!File.Exists(Application.StartupPath + "\\shortcut\\noimage.png"))
                        {
                            dr["image"] = null;
                        }
                        else
                        {
                            dr["image"] = ImageHelper.ImageToByte(Application.StartupPath + "\\shortcut\\noimage.png");
                        }
                    }
                    dtShortcut.Rows.Add(dr);
                }
            }
            return dtShortcut;
        }

        /// <summary> 动态加载菜单
        ///
        /// </summary>
        private void GetMenuBind()
        {
            //根据登录用户角色菜单动态创建
            //循环创建卡菜单
            DataSet dsMenus = GlobalHelp.DataSetMenus;
            DataTable baseModuleDt = dsMenus.Tables[1];
            for (int i = 0; i < baseModuleDt.Rows.Count; i++)
            {
                //创建卡
                RibbonPage ribbonPage = new RibbonPage { Text = baseModuleDt.Rows[i]["Menu_Type_Txt"].ToString() };
                ribbonPage.Name = "LimitPage";
                //菜单卡对象定义
                ribbon.Pages.Insert(0, ribbonPage);
                DataTable baseModuleDtg = dsMenus.Tables[2].Select("Menu_Type_Txt ='" + baseModuleDt.Rows[i]["Menu_Type_Txt"] + "'").CopyToDataTable();

                if (baseModuleDtg.Rows.Count <= 0)
                {
                    //没有组
                    RibbonPageGroup ribbonPageGroup = new RibbonPageGroup
                    {
                        Text = baseModuleDt.Rows[i]["Menu_Type_Txt"].ToString()
                    };
                    //菜单卡分组定义
                    //卡片组名
                    ribbonPage.Groups.Add(ribbonPageGroup);

                    DataTable baseModuleDtb = dsMenus.Tables[0].Select("Menu_Type_Txt ='" + baseModuleDt.Rows[i]["Menu_Type_Txt"] + "'").CopyToDataTable();
                    for (int b = 0; b < baseModuleDtb.Rows.Count; b++)
                    {
                        Image image = null;
                        if (baseModuleDtb.Rows[b]["ImagUrl"].ToString() != string.Empty)
                        {
                            image = Image.FromFile(FileHelper.GetFilePath("menuicon", baseModuleDtb.Rows[b]["ImagUrl"].ToString()));
                        }
                        //功能按钮
                        BarButtonItem barButtonItem = new BarButtonItem
                        {
                            Caption = baseModuleDtb.Rows[b]["Name"].ToString(),
                            LargeGlyph = image,
                            Name = baseModuleDtb.Rows[b]["FormName"].ToString(),
                            Tag = baseModuleDtb.Rows[b]["NavigateUrl"].ToString()
                        };
                        ribbonPageGroup.ItemLinks.Add(barButtonItem);
                        barButtonItem.ItemClick += BarButtonItem_ItemClick;//注册事件
                    }
                }
                else
                {
                    for (int g = 0; g < baseModuleDtg.Rows.Count; g++)
                    {
                        //创建组
                        RibbonPageGroup ribbonPageGroup = new RibbonPageGroup
                        {
                            Text = baseModuleDtg.Rows[g]["GroupTxt"].ToString()
                        };
                        //菜单卡分组定义
                        //卡片组名
                        ribbonPage.Groups.Add(ribbonPageGroup);

                        DataTable baseModuleDtb = dsMenus.Tables[0].Select("GroupTxt ='" + baseModuleDtg.Rows[g]["GroupTxt"] + "' AND Menu_Type_Txt='" + baseModuleDtg.Rows[g]["Menu_Type_Txt"] + "'").CopyToDataTable();
                        for (int b = 0; b < baseModuleDtb.Rows.Count; b++)
                        {
                            Image image = null;
                            if (baseModuleDtb.Rows[b]["ImagUrl"].ToString() != string.Empty)
                            {
                                image = Image.FromFile(FileHelper.GetFilePath("menuicon", baseModuleDtb.Rows[b]["ImagUrl"].ToString()));
                            }
                            BarButtonItem barButtonItem = new BarButtonItem
                            {
                                Caption = baseModuleDtb.Rows[b]["Name"].ToString(),
                                LargeGlyph = image,
                                Name = baseModuleDtb.Rows[b]["FormName"].ToString(),
                                Tag = baseModuleDtb.Rows[b]["NavigateUrl"].ToString()
                            };
                            ribbonPageGroup.ItemLinks.Add(barButtonItem);
                            barButtonItem.ItemClick += BarButtonItem_ItemClick;//注册事件
                        }
                    }
                }
            }
            m_dtShortcut = dsMenus.Tables[3];
            if (ConfigHelper.GetConfigKeyValue("NeedShortcut") == "true")//是否需要显示快捷方式
            {
                grdShortCut.DataSource = GetBindShortcut(m_dtShortcut);
            }
            else
            {
                grdShortCut.Visible = false;
                xtraTabPage2.PageVisible = false;
            }
        }

        #endregion 基础方法
    }
}