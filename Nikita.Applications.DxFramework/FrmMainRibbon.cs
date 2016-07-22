using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars; 
using System.IO;
using Nikita.Core;
using Nikita.Core4Dx;

namespace Nikita.Applications.DxFramework
{
    public partial class FrmMainRibbon : FrmBase
    {
        public FrmMainRibbon()
        {
            InitializeComponent();
            InitSkinGallery();
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        DataTable dtShortcut;
        private void frmRibbonMain_Load(object sender, EventArgs e)
        {
            string Path = FileHelper.GetFilePath("config", "SystemSetting.xml");
            barStaticItem1.Caption = "欢迎您:" + UserInfoHelper.CreateName;
            barStaticItem2.Caption = LinqToXmlHelper.GetXmlNodeValue(Path, "appsetting", "Company");
            barStaticItem3.Caption = LinqToXmlHelper.GetXmlNodeValue(Path, "appsetting", "Telephone");
            barStaticItem4.Caption = LinqToXmlHelper.GetXmlNodeValue(Path, "appsetting", "QQ");
            GetMenuBind();
            this.ribbon.SelectedPage = ribbon.Pages[1];
        }

        /// <summary> 动态加载菜单
        ///
        /// </summary>
        private void GetMenuBind()
        {
            //根据登录用户角色菜单动态创建
            //循环创建卡菜单 
            DataSet dtMenus = new DataSet();// menus.GetMenusRibbon();
            dtMenus.AcceptChanges();

            DataTable baseModuleDT = dtMenus.Tables[1];
            for (int i = 0; i < baseModuleDT.Rows.Count; i++)
            {
                //创建卡
                RibbonPage ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();//菜单卡对象定义
                ribbonPage.Text = baseModuleDT.Rows[i]["Menu_Type_Txt"].ToString();
                this.ribbon.Pages.Add(ribbonPage);

                DataTable baseModuleDTG = dtMenus.Tables[2].Select("Menu_Type_Txt ='" + baseModuleDT.Rows[i]["Menu_Type_Txt"].ToString() + "'").CopyToDataTable();

                if (baseModuleDTG.Rows.Count <= 0)
                {
                    //没有组
                    RibbonPageGroup ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();//菜单卡分组定义
                    ribbonPageGroup.Text = baseModuleDT.Rows[i]["Menu_Type_Txt"].ToString();//卡片组名
                    ribbonPage.Groups.Add(ribbonPageGroup);

                    DataTable baseModuleDTB = dtMenus.Tables[0].Select("Menu_Type_Txt ='" + baseModuleDT.Rows[i]["Menu_Type_Txt"].ToString() + "'").CopyToDataTable();
                    for (int b = 0; b < baseModuleDTB.Rows.Count; b++)
                    {

                        Image image = Image.FromFile(FileHelper.GetFilePath("menuicon", "error.png"));
                        //功能按钮
                        BarButtonItem barButtonItem = new DevExpress.XtraBars.BarButtonItem();
                        barButtonItem.Caption = baseModuleDTB.Rows[b]["Name"].ToString();
                        barButtonItem.LargeGlyph = image;// global::MemberManager.Properties.Resources.group_key;
                        barButtonItem.Name = baseModuleDTB.Rows[b]["FormName"].ToString();
                        barButtonItem.Tag = baseModuleDTB.Rows[b]["NavigateUrl"].ToString(); ;
                        ribbonPageGroup.ItemLinks.Add(barButtonItem);
                        barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ItemClick);//注册事件
                    }
                }
                else
                {
                    for (int g = 0; g < baseModuleDTG.Rows.Count; g++)
                    {
                        //创建组
                        RibbonPageGroup ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();//菜单卡分组定义
                        ribbonPageGroup.Text = baseModuleDTG.Rows[g]["GroupTxt"].ToString();//卡片组名
                        ribbonPage.Groups.Add(ribbonPageGroup);

                        DataTable baseModuleDTB = dtMenus.Tables[0].Select("GroupTxt ='" + baseModuleDTG.Rows[g]["GroupTxt"].ToString() + "' AND Menu_Type_Txt='" + baseModuleDTG.Rows[g]["Menu_Type_Txt"].ToString() + "'").CopyToDataTable();
                        for (int b = 0; b < baseModuleDTB.Rows.Count; b++)
                        {
                            Image image = Image.FromFile(FileHelper.GetFilePath("menuicon", "error.png"));
                            BarButtonItem barButtonItem = new DevExpress.XtraBars.BarButtonItem();
                            barButtonItem.Caption = baseModuleDTB.Rows[b]["Name"].ToString();
                            barButtonItem.LargeGlyph = image;// global::MemberManager.Properties.Resources.group_key;
                            barButtonItem.Name = baseModuleDTB.Rows[b]["FormName"].ToString();
                            barButtonItem.Tag = baseModuleDTB.Rows[b]["NavigateUrl"].ToString(); ;
                            ribbonPageGroup.ItemLinks.Add(barButtonItem);
                            barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ItemClick);//注册事件
                        }

                    }
                }
            }

            dtShortcut = dtMenus.Tables[3];
            if (ConfigHelper.GetConfigKeyValue("NeedShortcut") == "true")//是否需要显示快捷方式
            {
                gridControl1.DataSource = GetBindShortcut(dtShortcut);
            }
            else
            {
                gridControl1.Visible = false;
            }
        }

        public DataTable GetBindShortcut(DataTable dt)
        {
            DataTable dtShortcut = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                dtShortcut.Columns.Add("Shortcut_Name", System.Type.GetType("System.String"));
                dtShortcut.Columns.Add("Shortcut_Key", System.Type.GetType("System.String"));
                dtShortcut.Columns.Add("image", System.Type.GetType("System.Byte[]"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dtShortcut.NewRow();
                    dr["Shortcut_Name"] = "链接:" + dt.Rows[i]["Shortcut_Name"].ToString();
                    dr["Shortcut_Key"] = "快捷键:" + dt.Rows[i]["Shortcut_Key"].ToString();
                    string ImagePath = Application.StartupPath + "\\shortcut\\" + dt.Rows[i]["Shortcut_ImageUrl"].ToString();
                    if (File.Exists(ImagePath))
                    {
                        dr["image"] = ImageHelper.ImageToByte(ImagePath);
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
        private void barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string pagename = e.Link.Item.Name; //获取左侧栏的name值
                string caption = e.Link.Caption;
                string url = e.Link.Item.Tag.ToString();

                //获取名字 
                //if (e.Link.Group.Caption == "数据字典")
                //{
                //    if (e.Link.Group.ItemLinks[1].Item.Caption == "存储过程信息" || e.Link.Group.ItemLinks[2].Item.Caption == "视图信息" || e.Link.Group.ItemLinks[3].Item.Caption == "表信息")
                //    {
                //        if (MyUserInfoHelper.is_Visible_Dictionary == false)
                //        {
                //            if (pagename != "frmDictionaryLogin")
                //            {
                //                frmDictionaryLogin SysDbEdit = new frmDictionaryLogin();
                //                SysDbEdit.ShowDialog();
                //            }
                //        }
                //        else
                //        {
                //            if (pagename != "frmDictionaryLogin")
                //            {
                //                OpenForm(this, pagename, caption);
                //            }
                //        }
                //    }

                //    if (pagename == "frmDictionaryLogin")
                //    {
                //        frmDictionaryLogin SysDbEdit = new frmDictionaryLogin();
                //        SysDbEdit.ShowDialog();
                //    }
                //}
                //else
                //{
                OpenForm(this, pagename, caption, url);
                if (this.MdiChildren.Length > 0)
                {
                    gridControl1.Visible = false;
                }
                else
                {
                    gridControl1.Visible = true;
                }

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>双加关闭当前窗体
        /// 
        /// </summary> 
        private DateTime LastClickTime = System.DateTime.Now;
        private void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DateTime PointDt = DateTime.Now;
                TimeSpan pSpan = PointDt.Subtract(LastClickTime);
                if (pSpan.TotalMilliseconds < 300)//如果两次点击的时间间隔小于300毫秒，则认为是双击
                {
                    if (this.MdiChildren.Length > 0)
                    {
                        this.ActiveMdiChild.Close();
                    }
                    LastClickTime = PointDt.AddMinutes(-1);
                }
                else
                {
                    LastClickTime = PointDt;
                }
            }
        }

        /// <summary>反射出子窗体实例
        /// 
        /// </summary>
        /// <param name="ParentForm">父窗体</param>
        /// <param name="name">子窗体名称</param>
        /// <returns></returns>
        public static Form GetForm(Form ParentForm, string name, params Object[] args)
        {
            string fullname = ParentForm.GetType().Namespace + "." + name;
            if (args.Length == 0 || args == null)
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
        /// <param name="ParentForm"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Form GetForm(Form ParentForm, string name)
        {
            string fullname = ParentForm.GetType().Namespace + "." + name;
            Form f = (Form)Activator.CreateInstance(Type.GetType(fullname));
            return f;
        }

        /// <summary>点击顶部菜单打开模态窗体。
        /// 
        /// </summary>
        /// <param name="ParentForm"></param>
        /// <param name="name"></param>
        public static void OpenDialogForm(Form ParentForm, string name)
        {
            Form frm = GetForm(ParentForm, name);
            frm.ShowDialog();
        }

        /// <summary>根据反射实例出来的子窗体去打开子窗体
        /// 
        /// </summary>
        /// <param name="FrmParent">父窗体</param>
        /// <param name="name">子窗体名称</param>
        public static void OpenForm(Form FrmParent, string name, string caption, string url, params Object[] args)
        {
            if (name != "frmMainBrowser")
            {
                if (args.Length == 0 || args == null)
                {
                    Form FrmChild = GetForm(FrmParent, name);
                    FrmChild.Text = caption;
                    DxCtlHelper.OpenChildFrom(FrmParent, FrmChild);
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
                if (args.Length == 0 || args == null)
                {
                    Form FrmChild = GetForm(FrmParent, name);
                    FrmChild.Text = caption;
                    DxCtlHelper.OpenChildFromBs(FrmParent, FrmChild, FrmChild.Text, url);
                }
                //else
                //{
                //    Form FrmChild = GetForm(FrmParent, name, args);
                //    FrmChild.Text = caption;
                //    DxCtlHelper.OpenChildFromBs(FrmParent, FrmChild, FrmChild.Text);
                //}  
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (DataTableHelper.IsHaveRows(dtShortcut))
            {

                //112 F1
                //113 F2
                //114 F3
                //115 F4
                //117 F6
                //118 F7
                //119 F8
                //120 F9

                DataRow[] drs = dtShortcut.Select("Shortcut_Key = '" + keyData.ToString() + "' and System='Frame' ");
                if (drs.Length > 0 && keyData != Keys.Escape && keyData != Keys.F9 && keyData != Keys.F12)
                {
                    if (drs.Length == 1)
                    {
                        OpenForm(this, drs[0]["Shortcut_Form"].ToString(), drs[0]["Shortcut_Name"].ToString(), drs[0]["NavigaUrl"].ToString());

                    }
                    else
                    {
                        MessageBox.Show("一个快捷键对应了多个操作，请重新设置快捷键");
                    }
                }
                else
                {
                    if (keyData == Keys.Escape)//关闭当前页面
                    {
                        if (this.MdiChildren.Length > 0)
                        {
                            this.ActiveMdiChild.Close();
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
            if (this.MdiChildren.Length > 0)
            {
                gridControl1.Visible = false;
            }
            else
            {
                gridControl1.Visible = true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnUpdatePwd_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmEditPwd frmEdit = new frmEditPwd();
            //frmEdit.ShowDialog();
        }

        private void btnChgUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            string path = Application.StartupPath;
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = path + "\\H.M.Frame.exe";
            System.Diagnostics.Process.Start(info);
            this.Close();
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
        //锁屏离开
        private void btnLockScreen_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLockScreen frmlock = new FrmLockScreen();
            if (frmlock.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnUploadFileTool_ItemClick(object sender, ItemClickEventArgs e)
        {

            string path = Application.StartupPath;
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = path + "\\H.M.UploadFileTool.exe";
            System.Diagnostics.Process.Start(info);
            this.Close();
        }

    }
}