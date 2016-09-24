using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Nikita.Core.Sample.DAL;
using Nikita.WinForm.ExtendControl;
using System.Diagnostics;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Core.Sample
{
    public partial class FrmMainDemo : Form
    {
        public FrmMainDemo()
        {
            InitializeComponent();
        }

        private void FrmMainDemo_Load(object sender, EventArgs e)
        {

            T_Sample_MenuDAL dal = new T_Sample_MenuDAL();
            DataTable dt = dal.GetList("").Tables[0];
            InitMenu(menuStrip, dt);
        }

        /// <summary>反射出子窗体实例(不带参数)
        /// 
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetForm(string nameSpace, string name)
        {
            string fullname = nameSpace + "." + name;
            object f = null;
            if (nameSpace == this.GetType().Namespace)
            {
                f = Activator.CreateInstance(Type.GetType(fullname));
            }
            else
            {
                f = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + nameSpace + ".dll").CreateInstance(fullname, false);
            }

            return f;
        }

        /// <summary>查找窗体
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private IDockContent FindDocument(string text)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel1.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        /// <summary>加载菜单，仅支持两级结构
        /// 
        /// </summary>
        /// <param name="menuStrip"></param>
        /// <param name="dtMenuAll"></param>
        private void InitMenu(MenuStrip menuStrip, DataTable dtMenuAll)
        {
            DataRow[] drs = dtMenuAll.Select("ParentId=0");

            DataRow[] drsChild = dtMenuAll.Select("ParentId<>0");

            if (drs.Length > 0)
            {
                for (int i = 0; i < drs.Count(); i++)
                {
                    ToolStripMenuItem itemParent = new ToolStripMenuItem
                    {
                        Text = drs[i]["MenuName"].ToString(),
                        Name = "MenuItem" + drs[i]["id"]
                    };
                    menuStrip.Items.Add(itemParent);
                    string strParentId = drs[i]["id"].ToString().Trim();
                    for (int j = 0; j < drsChild.Count(); j++)
                    {
                        if (drsChild[j]["ParentId"].ToString().Trim() == strParentId)
                        {
                            ToolStripMenuItem itemChild = new ToolStripMenuItem
                            {

                                Text = drsChild[j]["MenuName"].ToString(),
                                Name = drsChild[j]["MenuClass"].ToString(),
                                Tag = drsChild[j]["Fileld1"].ToString()
                            };
                            itemChild.Click += item_Click;
                            itemParent.DropDownItems.Add(itemChild);
                        }

                    }
                }
            }

        }

        /// <summary>单击事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                object frm = GetForm(item.Tag.ToString(), item.Name);
                if (frm is DockContent)
                {
                    DockContent itemDockContent = frm as DockContent;
                    itemDockContent.Text = item.Text;
                    IDockContent iDockContent = FindDocument(itemDockContent.Text);
                    if (iDockContent == null)
                    {
                        itemDockContent.Show(dockPanel1);
                    }
                    else
                    {
                        itemDockContent.Activate();
                    }
                }
                else
                {
                    Form frmother = frm as Form;
                    frmother.ShowDialog();
                }

            }
        }

        private void FrmMainDemo_Shown(object sender, EventArgs e)
        {

            //Process.Start("Nikita.Assist.AutoUpdater.exe", Application.ProductName);

        }

    }
}
