using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.Define;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmCodeMakerMain : DockContentEx
    {
        #region 变量、常量

        private DbSchema m_dbSchema;
        private FrmTableList m_frmTableList;

        /// <summary>最后选中的树节点
        /// 最后选中的树节点
        /// </summary>
        private TreeNode m_lastSelectedNode;

        #endregion 变量、常量

        #region 构造函数
        /// <summary>构造函数
        ///
        /// </summary>
        public FrmCodeMakerMain()
        {
            InitializeComponent();
        }
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name="dbSchema">dbSchema</param>
        public FrmCodeMakerMain(DbSchema dbSchema)
        {
            InitializeComponent();
            m_dbSchema = dbSchema;
            m_frmTableList = new FrmTableList();
            m_frmTableList.Show(dockPanel);
            //GlobalHelp.TreeView.ImageList = imgList;
            GlobalHelp.TreeView.ContextMenuStrip = contextMenu;
            GlobalHelp.TreeView.MouseUp += tvwDataBase_MouseUp;
            GlobalHelp.DockPanel = dockPanel;
            if (m_dbSchema != null)
            {
                TreeNode treeNode = new TreeNode(m_dbSchema.DatabaseName);
                GlobalHelp.TreeView.Nodes.Add(treeNode);
                FillTables(treeNode, m_dbSchema.DatabaseSchema);
                treeNode.ExpandAll();
            }
        }
        #endregion

        #region 事件

        #region 右键事件
        /// <summary>右键菜单
        /// 右键菜单
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tvwDataBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            var p = new Point(e.X, e.Y);
            var menu = contextMenu;
            menu.Items.Clear();
            var node = GlobalHelp.TreeView.GetNodeAt(p);
            if (node == null)
            {
                return;
            }
            var tag = node.Tag;
            if (tag == null)
            {
                return;
            }
            m_lastSelectedNode = node;
            GlobalHelp.TreeView.SelectedNode = node;

            var cmdGenCode = new ToolStripMenuItem("生成代码") { Image = null };

            var cmdCreateModel = new ToolStripMenuItem("生成实体对象") { Image = null, Tag = tag };
            cmdCreateModel.Click += cmdCreateModel_Click;
            cmdGenCode.DropDownItems.Add(cmdCreateModel);

            var cmdCreateWinFormSimpleQuery = new ToolStripMenuItem("生成简单查询") { Image = null, Tag = tag };
            cmdCreateWinFormSimpleQuery.Click += cmdCreateWinFormSimpleQuery_Click;
            cmdGenCode.DropDownItems.Add(cmdCreateWinFormSimpleQuery);


            var cmdCreateWinFormEditWithDialog = new ToolStripMenuItem("生成单表编辑Dialog") { Image = null, Tag = tag };
            cmdCreateWinFormEditWithDialog.Click += cmdCreateWinFormEditWithDialog_Click;
            cmdGenCode.DropDownItems.Add(cmdCreateWinFormEditWithDialog);


            var cmdCreatNestQuery = new ToolStripMenuItem("生成嵌套查询") { Image = null, Tag = tag };
            cmdCreatNestQuery.Click += cmdCreatNestQuery_Click;
            cmdGenCode.DropDownItems.Add(cmdCreatNestQuery);


            var cmdCreatTree = new ToolStripMenuItem("生成树型编辑") { Image = null, Tag = tag };
            cmdCreatTree.Click += cmdCreatTree_Click;
            cmdGenCode.DropDownItems.Add(cmdCreatTree);



            var cmdCreatParentChild= new ToolStripMenuItem("生成主子表编辑") { Image = null, Tag = tag };
            cmdCreatParentChild.Click += cmdCreatParentChild_Click;
            cmdGenCode.DropDownItems.Add(cmdCreatParentChild);
             
            menu.Items.Add(cmdGenCode);

            menu.Show(GlobalHelp.TreeView, p);
            GlobalHelp.TreeView.SelectedNode = m_lastSelectedNode;
            m_lastSelectedNode = null;
        }

        /// <summary>生成实体对象
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateModel_Click(object sender, EventArgs e)
        {
            IModelMaker modelMaker = ModelMakerManager.GetModelMaker(m_dbSchema.SqlType);
            BasicParameter basicParameter = ParameterManager.GetBasicParameter(GlobalHelp.TreeView.SelectedNode.Text);
            string strContent = modelMaker.GenModelCode(basicParameter.NameSpace, basicParameter.TableName, basicParameter.ClassName, m_dbSchema.DatabaseSchema.ConnectionString, basicParameter.Author);
            string strFolder = basicParameter.OutFolderPath + "\\Model\\";
            FileHelper.GenFile(strFolder, basicParameter.ClassName + ".cs", strContent);
        }

        /// <summary>生成简单查询
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateWinFormSimpleQuery_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmWinFormGen2(m_dbSchema, CodeGenType.WinFromSimpleQuery);
            OpenForm(itemDockContent);
        }

        /// <summary>生成单表编辑Dialog
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateWinFormEditWithDialog_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmWinFormGen2(m_dbSchema, CodeGenType.WinFromEditWithDialog);
            OpenForm(itemDockContent);
        }

        /// <summary>生成主子表编辑
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreatParentChild_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmWinFormGen2(m_dbSchema, CodeGenType.WinFromParentChildEditWithDialog);
            OpenForm(itemDockContent);
        }


        /// <summary>生成树型编辑
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreatTree_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmWinFormGen2(m_dbSchema, CodeGenType.WinFromTreeEditWithDialog);
            OpenForm(itemDockContent);
        }

        /// <summary>生成单表编辑Dialog
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreatNestQuery_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmNestQuerySetting(m_dbSchema, CodeGenType.WinFromNestQuery);
            OpenForm(itemDockContent);
        }

        #endregion 右键事件

        #region 基础事件

        /// <summary>基础设置
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdSetting_Click(object sender, EventArgs e)
        {
            FrmSetInfo frmSetting = new FrmSetInfo();
            frmSetting.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAboutCodeMaker frmAbout = new FrmAboutCodeMaker();
            frmAbout.ShowDialog();
        }

        private void 实体批量生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicParameter basicParameter = ParameterManager.GetBasicParameter(string.Empty);
            FrmModelCreater frmModelCreater = new FrmModelCreater(basicParameter, m_dbSchema);
            frmModelCreater.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 命名设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>代码生成
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCodeMaker_Click(object sender, EventArgs e)
        {

        }
        #endregion 基础事件

        #endregion 事件

        #region 基础方法

        private static void FillTables(TreeNode treeRoot, DatabaseSchema schema)
        {
            //var tableRoot = new TreeNode("表");
            //tableRoot.Tag = schema;
            //treeRoot.Nodes.Add(tableRoot);
            foreach (var table in schema.Tables.OrderBy(x => x.SchemaOwner).ThenBy(x => x.Name))
            {
                var name = table.Name;
                //不要dbo前缀显示
                //if (!string.IsNullOrEmpty(table.SchemaOwner)) name = table.SchemaOwner + "." + name;
                var tableNode = new TreeNode(name) { Tag = table };
                //tableNode.ImageIndex = intImageIndex;
                treeRoot.Nodes.Add(tableNode);
            }
        }

        /// <summary>查找窗体
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                return (from form in MdiChildren where form.Text == text select form as IDockContent).FirstOrDefault();
            }
            return dockPanel.Documents.FirstOrDefault(content => content.DockHandler.TabText == text);
        }

        private void OpenForm(DockContent itemDockContent)
        {
            IDockContent iDockContent = FindDocument(itemDockContent.Text);
            if (iDockContent == null)
            {
                itemDockContent.Show(dockPanel);
            }
            else
            {
                var firstOrDefault = dockPanel.Documents.FirstOrDefault(t => t.DockHandler.TabText == itemDockContent.Text);
                if (firstOrDefault != null)
                    firstOrDefault.DockHandler.Show();
            }
        }

        #endregion 基础方法 
    }
}