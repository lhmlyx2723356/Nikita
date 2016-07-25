using DevExpress.XtraBars;  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using Nikita.Core;
using Nikita.Core4Dx;
using Nikita.Core.XML;
using Nikita.Core.Images;


namespace Nikita.Applications.DxFramework
{
    //http://192.168.16.95:13126/Service1 95wcf服务
    //95 图片上传地址：95上的D:\MyUpload\Debug\image
    //NavBarControl的NavBarGroup要承载树，则GroupStyle修改成ControlContainer
     
    public partial class FrmMainTree : Form
    {
        public FrmMainTree()
        {
            InitializeComponent();
        }
        DataSet dsTop = null;
        DataSet ds = null;
        DataTable dtShortcut;
        private void frmMain_Load(object sender, EventArgs e)
        {
            //DxCtlHelper.SetFormWindowStateMax(this);
            InitSkin();
            string Path = FileHelper.GetFilePath("config", "SystemSetting.xml");
            barStaticItem1.Caption = "欢迎您:" + UserInfoHelper.CreateName;
            barStaticItem2.Caption = LinqToXmlHelper.GetXmlNodeValue(Path, "appsetting", "Company");
            barStaticItem3.Caption = LinqToXmlHelper.GetXmlNodeValue(Path, "appsetting", "Telephone");
            barStaticItem4.Caption = LinqToXmlHelper.GetXmlNodeValue(Path, "appsetting", "QQ");
            //BseGetMenus menus = new BseGetMenus();
            ds = new DataSet();
            //CreateMenu(this.NavBarCtrlMenu, ds);

            CreateTreeMenu(this.treeListMenu);

            //NotifyIcon notifyicon = new NotifyIcon();
            //ContextMenu notifyContextMenu = new System.Windows.Forms.ContextMenu();
            //string value = ConfigHelper.GetConfigKeyValue("image");
            //string iconname = ConfigHelper.GetConfigKeyValue("iconname");
            //string startimg = ConfigHelper.GetConfigKeyValue("startimg");
            //string stopimg = ConfigHelper.GetConfigKeyValue("stopimg");
            //string exitimg = ConfigHelper.GetConfigKeyValue("exitimg");
            //string path = FileHelper.GetFilePath(value, iconname);
            //string path1 = FileHelper.GetFilePath(value, startimg);
            //string path2 = FileHelper.GetFilePath(value, stopimg);
            //string path3 = FileHelper.GetFilePath(value, exitimg);


            //this.NavBarCtrlMenu.Groups.Clear(); 

            //Bll_Bse_BarMgrMenu TopMenu = FactoryBLL.Create_Bse_BarMgrMenu();
            //Bll_Bse_Menu Menu = FactoryBLL.Create_Bse_Menu();
            //ds = Menu.Get_Menu(Convert.ToInt32(MyUserInfoHelper.CreateUserId));
            //dsTop = TopMenu.Get_TopMenu();
            //InitTopMenu(dsTop);
            //this.Text = MyUserInfoHelper.systemName + "--" + this.Text;

            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(MyUserInfoHelper.skin);
            //int i = this.NavBarCtrlMenu.Groups.Count;



            //string DefaultExpandedGroup = ConfigHelper.GetConfigKeyValue("DefaultExpandedGroup");
            //this.NavBarCtrlMenu.Groups[int.Parse(DefaultExpandedGroup)].Expanded = true;


            //this.panelControl1.ContentImage = Image.FromFile(MyFilePathHelper.GetFilePath("Images", MyUserInfoHelper.mainLogo));
            //panelControl1.Visible = false;



            dtShortcut = ds.Tables[1];

            if (ConfigHelper.GetConfigKeyValue("NeedShortcut") == "true")//是否需要显示快捷方式
            {
                gridControl1.DataSource = GetBindShortcut(dtShortcut);
            }
            else
            {
                gridControl1.Visible = false;
            }

            treeListMenu.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeListMenu_FocusedNodeChanged);

        }

        private void CreateTreeMenu(DevExpress.XtraTreeList.TreeList treeList)
        {

            DxCtlHelper.BindTreeList(treeList, ds.Tables[0], "Module_Id", "ParentId", "Name", "系统菜单");
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

        #region 生成皮肤
        /// <summary>初始化皮肤
        /// 
        /// </summary>
        private void InitSkin()
        {
            BarSubItem bar = new BarSubItem();
            bar.Caption = "系统主题";
            bar.Name = "系统主题";  //迭代出所有皮肤样式  
            //this.bar2.AddItem(bar);
            this.bar3.AddItem(bar);

            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarButtonItem barBI = new BarButtonItem();
                barBI.Tag = skin.SkinName;
                barBI.Name = skin.SkinName;
                barBI.Caption = skin.SkinName;
                barBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ItemClick);
                bar.AddItem(barBI);
                //this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barBI });
                //bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barBI) });
            }
            //this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bar });
            //this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bar) });
            bar.ItemAppearance.Normal.ForeColor = Color.Red;
            bar.ItemAppearance.Normal.Font = new Font("宋体", 9, FontStyle.Bold);
        }

        /// <summary>皮肤主题单击事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
            e.Item.Hint = e.Item.Tag.ToString();
        }
        #endregion

        /// <summary>根据数据源生成顶部的菜单
        /// 
        /// </summary>
        /// <param name="ds"></param>
        private void InitTopMenu(DataSet ds)
        {
            //DataTable dtMenu = ds.Tables[0];
            //DataTable dtInfo = ds.Tables[1];

            //for (int j = 0; j < dtMenu.Rows.Count; j++)
            //{
            //    BarSubItem bar = new BarSubItem();
            //    bar.Caption = dtMenu.Rows[j]["SetText"].ToString();
            //    bar.Name = dtMenu.Rows[j]["SetText"].ToString();
            //    for (int i = 0; i < dtInfo.Rows.Count; i++)
            //    {
            //        if (dtMenu.Rows[j]["SetValue"].ToString() != dtInfo.Rows[i]["Menus_Type"].ToString())
            //        {
            //            continue;
            //        }
            //        BarButtonItem barBI = new BarButtonItem();
            //        barBI.Tag = dtInfo.Rows[i]["Menus_Name"].ToString();
            //        barBI.Name = dtInfo.Rows[i]["Menus_Class"].ToString();
            //        barBI.Caption = dtInfo.Rows[i]["Menus_Name"].ToString();
            //        barBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ButtonItem_LinkClicked);
            //        this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barBI });
            //        bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barBI) });
            //    }
            //    this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bar });
            //    this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bar) });
            //}
        }



        /// <summary>点击子菜单触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

                if (pagename!=null)
                {
                    
                OpenForm(this, pagename, caption, url);
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void NavBarCtrlMenu_Click(object sender, EventArgs e)
        {
            //OpenForm(this, "frmBse_AddressBook", "test");
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
                this.gridControl1.Visible = false;
            }
            else
            {
                this.gridControl1.Visible = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        private void treeListMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            string name = this.treeListMenu.FocusedNode["FormName"].ToString();
            string caption = this.treeListMenu.FocusedNode["Name"].ToString();
            string url = this.treeListMenu.FocusedNode["NavigateUrl"].ToString();
            OpenForm(this, name, caption, url);
            if (this.MdiChildren.Length > 0)
            {
                this.gridControl1.Visible = false;
            }
            else
            {
                this.gridControl1.Visible = true;
            }
        }
    }
}
