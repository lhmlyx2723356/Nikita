using Nikita.Base.DbSchemaReader;
using Nikita.Base.DbSchemaReader.Conversion;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Assist.CodeMaker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    public partial class FrmDataBaseMain : Form
    {
        #region 成员变量

        /// <summary>最后选中的树节点
        /// 最后选中的树节点
        /// </summary>
        private TreeNode m_lastSelectedNode;
        private FrmDataBaseList m_frmDataBaseList;
        #endregion 成员变量

        #region 构造函数

        /// <summary>构造函数
        /// 构造函数
        /// </summary>
        public FrmDataBaseMain()
        {
            InitializeComponent();
            m_frmDataBaseList = new FrmDataBaseList();
            m_frmDataBaseList.Show(dockPanel);
            GlobalHelp.TreeView.ImageList = imgList;
            GlobalHelp.TreeView.ContextMenuStrip = contextMenu;
            GlobalHelp.TreeView.MouseUp += tvwDataBase_MouseUp;
            GlobalHelp.DockPanel = this.dockPanel;
            timer.Start();
        }

        #endregion 构造函数

        #region 基本事件

        /// <summary>窗体载入
        /// 窗体载入
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void FrmDataBaseMain_Load(object sender, EventArgs e)
        {
//            NewLinkServer(SqlType.SqlServer);
        }

        /// <summary>显示内存
        /// 显示内存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            lblMemory.Text = string.Format("内存占用：{0}M", GlobalHelp.GetProcessUsedMemory().ToString("0.00"));
        }

        private void 表信息设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmSetInfoTable() as DockContent;
            IDockContent iDockContent = FindDocument(itemDockContent.Text);
            if (iDockContent == null)
            {
                itemDockContent.Show(dockPanel);
            }
            else
            {
                dockPanel.Documents.Where(t => t.DockHandler.TabText == itemDockContent.Text).FirstOrDefault().DockHandler.Show();
            }
        }

        private void 测试批量插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTestBatchInsert test = new FrmTestBatchInsert();
            test.ShowDialog();
        }

        /// <summary>断开连接
        /// 断开连接
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalHelp.TreeView.SelectedNode == null || GlobalHelp.TreeView.SelectedNode.Parent != null)
            {
                MessageBox.Show("请选择要断开的服务器");
                return;
            }
            //GlobalHelp.TreeView.Nodes.Clear();
            TreeNode nodeServer = GetServerNameBySelectNode(GlobalHelp.TreeView.SelectedNode);
            nodeServer.Nodes.Clear();
            this.contextMenu.Items.Clear();
            GlobalHelp.TreeView.SelectedNode = null;
            var serverTag = nodeServer.Tag as ServerTag;
            if (serverTag != null)
                RemoveDatabaseSchema(serverTag.DBType, nodeServer.Text);
            GlobalHelp.TreeView.Nodes.Remove(nodeServer);
        }

        private void 分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GlobalHelp.TreeView.Nodes.Count == 0)
            {
                MessageBox.Show(@"请先连接服务器");
                return;
            }
            DockContent itemDockContent = new FrmExcuteAnalyze(GlobalHelp.TreeView.Nodes);
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

        private void 同步数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmSynchronization();
            IDockContent iDockContent = FindDocument(itemDockContent.Text);
            if (iDockContent == null)
            {
                itemDockContent.Show(dockPanel);
            }
            else
            {
                var firstOrDefault = dockPanel.Documents.FirstOrDefault(t => t.DockHandler.TabText == itemDockContent.Text);
                if (firstOrDefault !=
                    null)
                    firstOrDefault.DockHandler.Show();
            }
        }

        /// <summary>退出
        /// 退出
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 新建连接

        /// <summary>新建连接
        /// 新建连接
        /// </summary>
        /// <param name="dbType">dbType</param>
        private void NewLinkServer(SqlType dbType)
        {
            GlobalHelp.DefauleDatabase = txtDefaultDatabase.Text.Trim().Length==0 ? "BugClose" : txtDefaultDatabase.Text.Trim();
            switch (dbType)
            {
                case SqlType.SqlServer:
                case SqlType.MySql:
                    FrmDbLogin frmDb = new FrmDbLogin(dbType);
                    if (frmDb.ShowDialog() == DialogResult.OK)
                    {
                        if (dbType == SqlType.SqlServer)
                        {
                            if (GlobalHelp.DicSqlServerDatabaseSchema != null && GlobalHelp.DicSqlServerDatabaseSchema.ContainsKey(frmDb.Server))
                            {
                                MessageBox.Show(@"已经连接过该服务器，无需重连");
                                return;
                            }
                        }
                        else if (dbType == SqlType.MySql)
                        {
                            if (GlobalHelp.DicSqlServerDatabaseSchema != null && GlobalHelp.DicSqlServerDatabaseSchema.ContainsKey(frmDb.Server))
                            {
                                MessageBox.Show(@"已经连接过该服务器，无需重连");
                                return;
                            }
                        }
                        ServerTag serverTag = new ServerTag
                        {
                            UID = frmDb.UID,
                            PWD = frmDb.PWD,
                            Server = frmDb.Server,
                            MasterConn = frmDb.DBConn,
                            DBType = dbType,
                            LoadType = frmDb.LoadType,
                            Port = frmDb.Port
                        };
                        if (frmDb.LoadDatabase == null || frmDb.LoadDatabase.Rows.Count == 0)
                        {
                            serverTag.ServerDBNames = DataBaseManager.GetDataBase(dbType, frmDb.DBConn);
                        }
                        else
                        {
                            serverTag.ServerDBNames = frmDb.LoadDatabase;
                        }
                        StartWaiting();
                        bckWorker.RunWorkerAsync(serverTag);
                    } 
                    break;

                case SqlType.Oracle:
                    break;
                case SqlType.SQLite:

                    FrmDbLogin2 frmLogin2 = new FrmDbLogin2(dbType);
                    if (frmLogin2.ShowDialog() == DialogResult.OK)
                    {
                        ServerTag serverTag = new ServerTag {MasterConn = frmLogin2.DBConn, DBType = dbType};
                        string[] strArray = frmLogin2.DBConn.Split('\\');
                        foreach (string item in strArray)
                        {
                            if (item.Contains(".db"))
                            {
                                serverTag.Server = item.Split('.')[0];
                                break;
                            }
                        }
                        DataTable dt = new DataTable();
                        dt.Columns.Add("name", typeof(string));
                        DataRow dr = dt.NewRow();
                        dr["name"] = serverTag.Server;
                        dt.Rows.Add(dr);
                        serverTag.ServerDBNames = dt;
                        StartWaiting();
                        bckWorker.RunWorkerAsync(serverTag);
                    }
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
        }

        private void NewLinkServer_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
                switch (item.Text)
                {
                    case "新建SqlServer连接":
                        NewLinkServer(SqlType.SqlServer);
                        break;

                    case "新建MySql连接":
                        NewLinkServer(SqlType.MySql);
                        break;

                    case "新建MongoDB连接":
                        Process.Start(Application.StartupPath + "\\Mongo-Cola.exe");
                        break;

                    case "新建SQLite连接":
                        NewLinkServer(SqlType.SQLite);
                        break;

                    case "新建连接":
                        var serverTag = item.Tag as ServerTag;
                        if (serverTag != null) NewLinkServer(serverTag.DBType);
                        break;
                }
        }

        #endregion 新建连接

        #endregion 基本事件

        #region 异步加载列表信息

        private void AddDatabaseSchema(SqlType dbType, string strKey, Dictionary<string, DatabaseSchema> dicDatabaseSchema)
        {
            switch (dbType)
            {
                case SqlType.SqlServer:
                    //赋值全局使用
                    if (GlobalHelp.DicSqlServerDatabaseSchema == null)
                    {
                        GlobalHelp.DicSqlServerDatabaseSchema = new Dictionary<string, Dictionary<string, DatabaseSchema>>();
                    }
                    if (!GlobalHelp.DicSqlServerDatabaseSchema.ContainsKey(strKey))
                    {
                        GlobalHelp.DicSqlServerDatabaseSchema.Add(strKey, dicDatabaseSchema);
                    }
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    //赋值全局使用
                    if (GlobalHelp.DicMySqlDatabaseSchema == null)
                    {
                        GlobalHelp.DicMySqlDatabaseSchema = new Dictionary<string, Dictionary<string, DatabaseSchema>>();
                    }
                    if (!GlobalHelp.DicMySqlDatabaseSchema.ContainsKey(strKey))
                    {
                        GlobalHelp.DicMySqlDatabaseSchema.Add(strKey, dicDatabaseSchema);
                    }
                    break;

                case SqlType.SQLite:
                    //赋值全局使用
                    if (GlobalHelp.DicSQLiteDatabaseSchema == null)
                    {
                        GlobalHelp.DicSQLiteDatabaseSchema = new Dictionary<string, Dictionary<string, DatabaseSchema>>();
                    }
                    if (!GlobalHelp.DicSQLiteDatabaseSchema.ContainsKey(strKey))
                    {
                        GlobalHelp.DicSQLiteDatabaseSchema.Add(strKey, dicDatabaseSchema);
                    }

                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
        }

        private void BckWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            ServerTag serverTag = e.Argument as ServerTag;
            if (serverTag != null)
            {
                DataTable dtDbNames = serverTag.ServerDBNames;
                Dictionary<string, DatabaseSchema> dicDatabaseSchema = new Dictionary<string, DatabaseSchema>();
                Stopwatch watch = new Stopwatch();
                watch.Start();
                if (serverTag.DBType == SqlType.SqlServer || serverTag.DBType == SqlType.MySql)
                {
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strPort = serverTag.Port ?? string.Empty;
                        string strConnectionString = DataBaseManager.BuildConn(serverTag.DBType, serverTag.Server, serverTag.UID, serverTag.PWD, strPort, dr[0].ToString());

                        var rdr = new DatabaseReader(strConnectionString, ProviderToSqlType.Convert(serverTag.DBType));
                        if (serverTag.DBType == SqlType.SqlServer)
                        {
                            rdr.Owner = "dbo";
                        }
                        if (!dicDatabaseSchema.ContainsKey(dr[0].ToString()))
                        {
                            dicDatabaseSchema.Add(dr[0].ToString(), rdr.ReadAll(serverTag.LoadType));
                        }
                        //break;
                    }
                }
                else if (serverTag.DBType == SqlType.SQLite)
                {
                    if (!dicDatabaseSchema.ContainsKey(serverTag.Server))
                    {
                        var rdr = new DatabaseReader(serverTag.MasterConn, ProviderToSqlType.Convert(serverTag.DBType));
                        dicDatabaseSchema.Add(serverTag.Server, rdr.ReadAll());
                    }
                }
                watch.Stop();
                serverTag.AllDatabaseSchema = dicDatabaseSchema;
            }
            e.Result = serverTag;
        }

        private void BckWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                toolStripStatusLabel1.Text = e.Error.Message;
            }
            else
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                ServerTag serverTag = e.Result as ServerTag;
                if (serverTag != null)
                {
                    Dictionary<string, DatabaseSchema> dicDatabaseSchema = serverTag.AllDatabaseSchema;
                    toolStripStatusLabel1.Text = "";
                    TreeNode nodeSever = new TreeNode {Text = serverTag.Server, Tag = serverTag, ImageIndex = 0};
                    GlobalHelp.TreeView.Nodes.Add(nodeSever);

                    TreeNode nodeDb = new TreeNode {Text = "数据库", ImageIndex = 0, Tag = dicDatabaseSchema};
                    nodeSever.Nodes.Add(nodeDb);
                    foreach (KeyValuePair<string, DatabaseSchema> keyPair in dicDatabaseSchema)
                    {
                        TreeNode node = new TreeNode();
                        DatabaseTag databaseTag = new DatabaseTag
                        {
                            ServerTag = serverTag,
                            DatabaseName = keyPair.Key,
                            DatabaseSchema = keyPair.Value
                        };
                        node.Tag = databaseTag;
                        node.Text = keyPair.Key;
                        node.ImageIndex = 0;
                        nodeDb.Nodes.Add(node);
                        SchemaToTreeview.PopulateTreeView(keyPair.Value, GlobalHelp.TreeView, node, 2, serverTag.DBType);
                    
#if DEBUG
                        GlobalHelp.TreeView.SelectedNode = node;
#endif
                        //break;
                    }
                    nodeSever.Expand();
                    nodeDb.Expand();
                    nodeDb.Nodes[0].Expand();
                    nodeDb.Nodes[0].Nodes[0].Expand();
                    AddDatabaseSchema(serverTag.DBType, serverTag.Server, dicDatabaseSchema);
                }

                watch.Stop();
                string strTime = watch.ElapsedMilliseconds.ToString();
            }
            StopWaiting();

#if DEBUG
             OpenCodeMaker();
#endif
        }

        /// <summary>开始加载
        /// 开始加载
        /// </summary>
        private void StartWaiting()
        {
            Cursor = Cursors.WaitCursor;
            cmdProgressBar.Visible = true;
            ControlHelper.SetFormControlEnable(this, false, new string[] { cmdProgressBar.Name, GlobalHelp.TreeView.Name });
        }

        /// <summary>结束加载
        /// 结束加载
        /// </summary>
        private void StopWaiting()
        {
            Cursor = Cursors.Default;
            cmdProgressBar.Visible = false;
            ControlHelper.SetFormControlEnable(this, true, new string[] { });
        }

        #endregion 异步加载列表信息

        #region 顶部菜单事件

        private void cmdFunction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现功能");
        }

        /// <summary> 新建查询
        /// 新建查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNewQuery_Click(object sender, EventArgs e)
        {
            if (GlobalHelp.TreeView.Nodes.Count == 0)
            {
                MessageBox.Show("请先连接服务器");
                return;
            }

            if (GlobalHelp.TreeView.SelectedNode == null)
            {
                MessageBox.Show("请选择要新建查询的库");
                return;
            }
            if (GlobalHelp.TreeView.SelectedNode != null && (GlobalHelp.TreeView.SelectedNode.Tag as DatabaseTable) != null)
            {
                string strDefaultSql = "SELECT * FROM " + GlobalHelp.TreeView.SelectedNode.Text;
                OpenDataBaseQuery(strDefaultSql, false);
            }
            else
            {
                OpenDataBaseQuery(string.Empty, false);
            }
        }

        private void cmdProc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现功能");
        }

        /// <summary>/// 重新刷新
        /// 重新刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRefreshAgain_Click(object sender, EventArgs e)
        {
            if (GlobalHelp.TreeView.SelectedNode == null)
            {
                MessageBox.Show("请选择要刷新的服务器");
                return;
            }
            TreeNode node = GetServerNameBySelectNode(GlobalHelp.TreeView.SelectedNode);
            ServerTag serverTag = (node.Tag as ServerTag);
            RemoveDatabaseSchema((node.Tag as ServerTag).DBType, node.Text);
            GlobalHelp.TreeView.Nodes.Remove(node);
            StartWaiting();
            bckWorker.RunWorkerAsync(serverTag);
        }


        /// <summary>搜索
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (GlobalHelp.TreeView.Nodes.Count == 0)
            {
                MessageBox.Show("请选连接服务器");
                return;
            }
            DockContent itemDockContent = new FrmSqlSerach() as DockContent;
            IDockContent iDockContent = FindDocument(itemDockContent.Text);
            if (iDockContent == null)
            {
                itemDockContent.Show(dockPanel);
            }
            else
            {
                dockPanel.Documents.Where(t => t.DockHandler.TabText == itemDockContent.Text).FirstOrDefault().DockHandler.Show();
            }
        }


        private void cmdTable_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现功能");
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现功能");
        }

        private void 快捷键列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockContent itemDockContent = new FrmShutcutList() as DockContent;
            IDockContent iDockContent = FindDocument(itemDockContent.Text);
            if (iDockContent == null)
            {
                itemDockContent.Show(dockPanel);
            }
            else
            {
                dockPanel.Documents.Where(t => t.DockHandler.TabText == itemDockContent.Text).FirstOrDefault().DockHandler.Show();
            }
        }



        #endregion 顶部菜单事件

        #region 右键菜单

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

            var server = node.Tag as ServerTag;//服务器名称
            var databaseParent = node.Tag as Dictionary<string, DatabaseSchema>;//数据库
            var database = node.Tag as DatabaseTag;//数据库明细
            var schema = node.Tag as DatabaseSchema;//表
            var table = node.Tag as DatabaseTable;//明细表
            var column = node.Tag as DatabaseColumn;//列
            string viewParent = node.Tag.ToString();//视图
            var view = node.Tag as DatabaseView;//视图明细
            string viewProceduce = node.Tag.ToString();//存储过程
            var sproc = node.Tag as DatabaseStoredProcedure;//存储过程明细
            var funParent = node.Tag.ToString();//函数
            var fun = node.Tag as DatabaseFunction;//函数明细
            var pack = node.Tag as DatabasePackage;
            var constraint = node.Tag as DatabaseConstraint;
            var trigger = node.Tag as DatabaseTrigger;
            var index = node.Tag as DatabaseIndex;

            #region 服务器名称

            if (server != null)
            {
                var cmdCreateLink = new ToolStripMenuItem("新建连接") {Image = null, Tag = server};
                cmdCreateLink.Click += NewLinkServer_Click;

                var cmdBreakLink = new ToolStripMenuItem("断开连接") {Image = null};
                cmdBreakLink.Click += 断开连接ToolStripMenuItem_Click;

                var cmdSplit1 = new ToolStripSeparator();

                var cmdNewQuery = new ToolStripMenuItem("新建查询") {Image = null};
                cmdNewQuery.Click += cmdNewQuery_Click;

                var cmdSplit2 = new ToolStripSeparator();

                var cmdRefreshServer = new ToolStripMenuItem("刷新") {Image = null, Tag = table};
                cmdRefreshServer.Click += cmdRefresh_Click;

                //var cmdPropertyServer = new ToolStripMenuItem("属性");
                //cmdPropertyServer.Image = null;
                //cmdPropertyServer.Tag = table;
                //cmdPropertyServer.Click += cmdProperty_Click;

                menu.Items.Add(cmdCreateLink);
                menu.Items.Add(cmdBreakLink);
                menu.Items.Add(cmdSplit1);
                menu.Items.Add(cmdNewQuery);
                menu.Items.Add(cmdSplit2);
                menu.Items.Add(cmdRefreshServer);
                //menu.Items.Add(cmdPropertyServer);
            }

            #endregion 服务器名称

            #region 数据库

            else if (databaseParent != null)
            {
                var cmdCreateDataBase = new ToolStripMenuItem("新建数据库") {Image = null};
                cmdCreateDataBase.Click += cmdCreateDataBase_Click;

                var cmdSplit1 = new ToolStripSeparator();

                var cmdRefreshServer = new ToolStripMenuItem("刷新") {Image = null, Tag = table};
                cmdRefreshServer.Click += cmdRefresh_Click;

                menu.Items.Add(cmdCreateDataBase);
                menu.Items.Add(cmdSplit1);
                menu.Items.Add(cmdRefreshServer);
            }

            #endregion 数据库

            #region 右键数据库明细

            else if (database != null)
            {
                var cmdChangeToOtherDbTypeScript = new ToolStripMenuItem("转换脚本") {Image = null, Tag = database};

                var cmdCodeMaker = new ToolStripMenuItem("代码生成");
                cmdCodeMaker.Image = null;
                cmdCodeMaker.Tag = database;
                cmdCodeMaker.Click += cmdCodeMaker_Click;
                foreach (var item in Enum.GetValues(typeof(SqlType)))
                {
                    if (item.ToString() == database.ServerTag.DBType.ToString())
                    {
                        continue;
                    }
                    var cmdChangeItem = new ToolStripMenuItem(item.ToString())
                    {
                        Image = null,
                        Tag = new[] {item, database.DatabaseSchema}
                    };
                    cmdChangeItem.Click += cmdChangeItem_Click;
                    cmdChangeToOtherDbTypeScript.DropDownItems.Add(cmdChangeItem);
                }
                menu.Items.Add(cmdChangeToOtherDbTypeScript);
                menu.Items.Add(cmdCodeMaker);
            }

            #endregion 右键数据库明细

            #region 视图

            else if (viewParent == "视图")
            {
                var cmdCreateView = new ToolStripMenuItem("新建视图");
                cmdCreateView.Image = null;
                cmdCreateView.Tag = view;
                cmdCreateView.Click += cmdCreateView_Click;

                menu.Items.Add(cmdCreateView);
            }
            else if (view != null)
            {
                var cmdCreateView = new ToolStripMenuItem("新建视图");
                cmdCreateView.Image = null;
                cmdCreateView.Tag = view;
                cmdCreateView.Click += cmdCreateView_Click;

                var cmdSplit1 = new ToolStripSeparator();

                var cmdCreateScript = new ToolStripMenuItem("生成脚本");
                cmdCreateScript.Image = null;
                cmdCreateScript.Tag = view;

                var cmdCreateViewScript = new ToolStripMenuItem("Create脚本");
                cmdCreateViewScript.Image = null;
                cmdCreateViewScript.Tag = view;
                cmdCreateViewScript.Click += cmdCreateViewScript_Click;

                cmdCreateScript.DropDownItems.Add(cmdCreateViewScript);

                menu.Items.Add(cmdCreateView);
                menu.Items.Add(cmdSplit1);
                menu.Items.Add(cmdCreateScript);
            }

            #endregion 视图

            #region 右键表

            else if (schema != null)
            {
                var cmdCreateTable = new ToolStripMenuItem("新建表");
                cmdCreateTable.Image = null;
                cmdCreateTable.Tag = schema;
                cmdCreateTable.Click += cmdCreateTable_Click;

                var cmdSplit1 = new ToolStripSeparator();

                var cmdCreateAllTableDDL = new ToolStripMenuItem("生成所有表CREATE语句");
                cmdCreateAllTableDDL.Image = null;
                cmdCreateAllTableDDL.Tag = schema;
                cmdCreateAllTableDDL.Click += cmdCreateAllTableDDL_Click;

                var cmdDeleteAllTableDDL = new ToolStripMenuItem("生成所有表DELETE语句");
                cmdDeleteAllTableDDL.Image = null;
                cmdDeleteAllTableDDL.Tag = schema;
                cmdDeleteAllTableDDL.Click += cmdDeleteAllTableDDL_Click;

                var cmdSplit2 = new ToolStripSeparator();

                var cmdRefreshTable = new ToolStripMenuItem("刷新") {Image = null, Tag = schema};
                cmdRefreshTable.Click += cmdRefresh_Click;

                var cmdSplit3 = new ToolStripSeparator();

                var cmdImportDataDictionary = new ToolStripMenuItem("导出数据字典") {Image = null, Tag = schema};

                var cmdImportDataDictionary2Excel = new ToolStripMenuItem("导出至Excel");
                cmdImportDataDictionary2Excel.Image = null;
                cmdImportDataDictionary2Excel.Tag = schema;
                cmdImportDataDictionary2Excel.Click += cmdImportDataDictionary2Excel_Click;

                var cmdImportDataDictionary2Html = new ToolStripMenuItem("导出至HTML");
                cmdImportDataDictionary2Html.Image = null;
                cmdImportDataDictionary2Html.Tag = schema;
                cmdImportDataDictionary2Html.Click += cmdImportDataDictionary2HTML_Click;

                cmdImportDataDictionary.DropDownItems.Add(cmdImportDataDictionary2Excel);
                cmdImportDataDictionary.DropDownItems.Add(cmdImportDataDictionary2Html);

                menu.Items.Add(cmdCreateTable);
                menu.Items.Add(cmdSplit1);
                menu.Items.Add(cmdCreateAllTableDDL);
                menu.Items.Add(cmdDeleteAllTableDDL);
                menu.Items.Add(cmdSplit2);
                menu.Items.Add(cmdRefreshTable);
                menu.Items.Add(cmdSplit3);
                menu.Items.Add(cmdImportDataDictionary);
            }

            #endregion 右键表

            #region 右键明细表

            else if (table != null)
            {
                BuildTableMenu(menu, table);
            }

            #endregion 右键明细表

            #region 存储过程

            else if (viewProceduce == "存储过程")
            {
                var cmdCreateProc = new ToolStripMenuItem("新建存储过程");
                cmdCreateProc.Image = null;
                cmdCreateProc.Tag = fun;
                cmdCreateProc.Click += cmdCreateProc_Click;

                menu.Items.Add(cmdCreateProc);
            }
            else if (sproc != null)
            {
                var cmdCreateProc = new ToolStripMenuItem("新建存储过程");
                cmdCreateProc.Image = null;
                cmdCreateProc.Tag = sproc;
                cmdCreateProc.Click += cmdCreateProc_Click;

                var cmdSplit1 = new ToolStripSeparator();

                var cmdCreateScript = new ToolStripMenuItem("生成脚本");
                cmdCreateScript.Image = null;
                cmdCreateScript.Tag = sproc;

                var cmdCreateProcScript = new ToolStripMenuItem("Create脚本");
                cmdCreateProcScript.Image = null;
                cmdCreateProcScript.Tag = sproc;
                cmdCreateProcScript.Click += cmdCreateProcScript_Click;

                cmdCreateScript.DropDownItems.Add(cmdCreateProcScript);

                menu.Items.Add(cmdCreateProc);
                menu.Items.Add(cmdSplit1);
                menu.Items.Add(cmdCreateScript);
            }

            #endregion 存储过程

            #region 函数

            else if (funParent == "函数")
            {
                var cmdCreateFun = new ToolStripMenuItem("新建函数") {Image = null, Tag = null};
                cmdCreateFun.Click += cmdCreateFunction_Click;

                menu.Items.Add(cmdCreateFun);
            }
            else if (fun != null)
            {
                var cmdCreateFunction = new ToolStripMenuItem("新建函数");
                cmdCreateFunction.Image = null;
                cmdCreateFunction.Tag = fun;
                cmdCreateFunction.Click += cmdCreateFunction_Click;

                var cmdSplit1 = new ToolStripSeparator();

                var cmdCreateScript = new ToolStripMenuItem("生成脚本") {Image = null, Tag = sproc};

                var cmdCreateFunctionScript = new ToolStripMenuItem("Create脚本") {Image = null, Tag = sproc};
                cmdCreateFunctionScript.Click += cmdCreateFunctionScript_Click;

                cmdCreateScript.DropDownItems.Add(cmdCreateFunctionScript);

                menu.Items.Add(cmdCreateFunction);
                menu.Items.Add(cmdSplit1);
                menu.Items.Add(cmdCreateScript);
            }

            #endregion 函数

            menu.Show(GlobalHelp.TreeView, p);
            GlobalHelp.TreeView.SelectedNode = m_lastSelectedNode;
            m_lastSelectedNode = null;
        }

        #endregion 右键菜单

        #region 右键事件

        #region 右键视图

        /// <summary>新建视图
        /// 新建视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateView_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            string strSql = DataBaseManager.GetCreateView(dbType);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>生成视图Create脚本
        /// 生成视图Create脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateViewScript_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            var toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null)
            {
                string strSql = GlobalHelp.GetSqlTasks(dbType).BuildView(toolStripMenuItem.Tag as DatabaseView);
                OpenDataBaseQuery(strSql, false);
            }
        }

        #endregion 右键视图

        #region 右键存储过程

        /// <summary>新建存储过程
        /// 新建存储过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateProc_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            string strSql = DataBaseManager.GetCreateProc(dbType);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>生成存储过程Create脚本
        /// 生成存储过程Create脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateProcScript_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildProcedure((sender as ToolStripMenuItem).Tag as DatabaseStoredProcedure);
            OpenDataBaseQuery(strSql, false);
        }

        #endregion 右键存储过程

        #region 右键函数

        /// <summary>新建函数
        /// 新建函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateFunction_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            string strSql = DataBaseManager.GetCreateFunction(dbType);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>生成函数Create脚本
        /// 生成函数Create脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateFunctionScript_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildProcedure((sender as ToolStripMenuItem).Tag as DatabaseFunction);
            OpenDataBaseQuery(strSql, false);
        }

        #endregion 右键函数

        #region 右键表

        private void cmdCreateAllTableDDL_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildAllTableDdl((sender as ToolStripMenuItem).Tag as DatabaseSchema);
            OpenDataBaseQuery(strSql, false);
        }

        private void cmdDeleteAllTableDDL_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            string strSql = GlobalHelp.GetSqlTasks(dbType).DeleteAllData((sender as ToolStripMenuItem).Tag as DatabaseSchema);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>
        /// 导出数据字典至Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdImportDataDictionary2Excel_Click(object sender, EventArgs e)
        {
            DatabaseSchema databaseSchema = (sender as ToolStripItem).Tag as DatabaseSchema;
            DataTable dt = DataBaseManager.GetDataDictionary(GetServerTag().DBType, databaseSchema.ConnectionString);
            string strPath = NPOIHelper.ExportToExcel(dt);
            if (strPath == null)
            {
                return;
            }
            DialogResult diaResult = MessageBox.Show(string.Format("导出至{0},是否打开？", strPath), "提示", MessageBoxButtons.YesNo);
            if (diaResult == DialogResult.Yes)
            {
                Process.Start(strPath);
            }
        }

        /// <summary>
        /// 导出数据字典至HTML（简化版）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdImportDataDictionary2HTML_Click(object sender, EventArgs e)
        {
            DatabaseSchema databaseSchema = (sender as ToolStripItem).Tag as DatabaseSchema;
            List<string> lstTableName = new List<string>();
            foreach (DatabaseTable table in databaseSchema.Tables)
            {
                lstTableName.Add(table.Name);
            }

            if (lstTableName.Count > 0)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择存储的位置";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string strPath = dialog.SelectedPath.EndsWith("\\") ? dialog.SelectedPath + GetDbNameBySelectNode(GlobalHelp.TreeView.SelectedNode) + "数据库文档.html" : dialog.SelectedPath + "\\" + GetDbNameBySelectNode(GlobalHelp.TreeView.SelectedNode) + "数据库文档.html";
                    StreamWriter sw = new StreamWriter(strPath, false, Encoding.UTF8);
                    sw.Write(DbDocGen.GenDoc(GetServerTag().DBType, databaseSchema.ConnectionString, lstTableName));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    DialogResult diaResult = MessageBox.Show(string.Format("导出至{0},是否打开？", dialog.SelectedPath), "提示", MessageBoxButtons.YesNo);
                    if (diaResult == DialogResult.Yes)
                    {
                        Process.Start(strPath);
                    }
                }
            }
        }

        #endregion 右键表

        #region 右键数据库明细

        private void cmdChangeItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择保存路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                object[] objTag = (sender as ToolStripMenuItem).Tag as object[];
                SqlType sqlType = (SqlType)(objTag[0]);
                DatabaseSchema databaseSchema = objTag[1] as DatabaseSchema;
                RunTableDdl(new DirectoryInfo(dialog.SelectedPath), sqlType, databaseSchema);
            }
        }
        private void cmdCodeMaker_Click(object sender, EventArgs e)
        {
            OpenCodeMaker();
        }


        private void RunTableDdl(DirectoryInfo directory, SqlType dbType, DatabaseSchema databaseSchema)
        {
            var runner = new TaskRunner(databaseSchema);
            if (runner.RunTableDdl(directory, dbType))
            {
                MessageBox.Show(string.Format("导出至{0}成功", directory.FullName));
            }
            else
            {
                MessageBox.Show(runner.Message);
            }
        }

        #endregion 右键数据库明细

        /// <summary>构建右键明细表菜单
        /// 构建右键明细表菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="table"></param>
        private void BuildTableMenu(ContextMenuStrip menu, DatabaseTable table)
        {
            #region 右键明细表

            var cmdCreateTable = new ToolStripMenuItem("新建表");
            cmdCreateTable.Image = null;
            cmdCreateTable.Tag = table;
            cmdCreateTable.Click += cmdCreateTable_Click;

            var cmdDesignTable = new ToolStripMenuItem("设计表");
            cmdDesignTable.Image = null;
            cmdDesignTable.Tag = table;
            cmdDesignTable.Click += cmdDesignTable_Click;

            var cmdSelectTableAllRow = new ToolStripMenuItem("选择所有行");
            cmdSelectTableAllRow.Image = null;
            cmdSelectTableAllRow.Tag = table;
            cmdSelectTableAllRow.Click += cmdSelectTableAllRow_Click;

            var cmdOpenTable = new ToolStripMenuItem("打开表");
            cmdOpenTable.Image = null;
            cmdOpenTable.Tag = table;
            cmdOpenTable.Click += cmdOpenTable_Click;

            var cmdDeleteTable = new ToolStripMenuItem("清空表");
            cmdDeleteTable.Image = null;
            cmdDeleteTable.Tag = table;
            cmdDeleteTable.Click += cmdDeleteTable_Click;

            var cmdSplit2 = new ToolStripSeparator();

            var cmdImport = new ToolStripMenuItem("导出");
            cmdImport.Image = null;
            cmdImport.Tag = table;

            var cmdImportExcel = new ToolStripMenuItem("导出Excel");
            cmdImportExcel.Image = null;
            cmdImportExcel.Tag = table;
            cmdImportExcel.Click += cmdImportExcel_Click;

            cmdImport.DropDownItems.Add(cmdImportExcel);

            var cmdSplit3 = new ToolStripSeparator();

            #region 生成脚本

            var cmdCreateScript = new ToolStripMenuItem("生成脚本");
            cmdCreateScript.Image = null;
            cmdCreateScript.Tag = table;

            var cmdCreateScript4Select = new ToolStripMenuItem("Select脚本");
            cmdCreateScript4Select.Image = null;
            cmdCreateScript4Select.Tag = table;
            cmdCreateScript4Select.Click += cmdCreateScript4Select_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4Select);

            var cmdCreateScript4SelectPaged = new ToolStripMenuItem("SelectPaged脚本");
            cmdCreateScript4SelectPaged.Image = null;
            cmdCreateScript4SelectPaged.Tag = table;
            cmdCreateScript4SelectPaged.Click += cmdCreateScript4SelectPaged_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4SelectPaged);

            var cmdCreateScript4Insert = new ToolStripMenuItem("Insert脚本");
            cmdCreateScript4Insert.Image = null;
            cmdCreateScript4Insert.Tag = table;
            cmdCreateScript4Insert.Click += cmdCreateScript4Insert_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4Insert);

            var cmdCreateScript4Update = new ToolStripMenuItem("Update脚本");
            cmdCreateScript4Update.Image = null;
            cmdCreateScript4Update.Tag = table;
            cmdCreateScript4Update.Click += cmdCreateScript4Update_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4Update);

            var cmdCreateScript4Delete = new ToolStripMenuItem("Delete脚本");
            cmdCreateScript4Delete.Image = null;
            cmdCreateScript4Delete.Tag = table;
            cmdCreateScript4Delete.Click += cmdCreateScript4Delete_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4Delete);

            var cmdCreateScript4Create = new ToolStripMenuItem("Create脚本");
            cmdCreateScript4Create.Image = null;
            cmdCreateScript4Create.Tag = table;
            cmdCreateScript4Create.Click += cmdCreateScript4Create_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4Create);

            var cmdCreateScript4Drop = new ToolStripMenuItem("Drop脚本");
            cmdCreateScript4Drop.Image = null;
            cmdCreateScript4Drop.Tag = table;
            cmdCreateScript4Drop.Click += cmdDropTable_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4Drop);

            var cmdCreateScript4InsertData = new ToolStripMenuItem("生成10000条数据Insert语句");
            cmdCreateScript4InsertData.Image = null;
            cmdCreateScript4InsertData.Tag = table;
            cmdCreateScript4InsertData.Click += cmdCreateScript4InsertData_Click;

            cmdCreateScript.DropDownItems.Add(cmdCreateScript4InsertData);

            #endregion 生成脚本

            var cmdSplit4 = new ToolStripSeparator();

            var cmdRenameTable = new ToolStripMenuItem("重命名");
            cmdRenameTable.Image = null;
            cmdRenameTable.Tag = table;
            cmdRenameTable.Click += cmdRename_Click;

            var cmdDropTable = new ToolStripMenuItem("删除");
            cmdDropTable.Image = null;
            cmdDropTable.Tag = table;
            cmdDropTable.Click += cmdDrop_Click;

            var cmdSplit5 = new ToolStripSeparator();

            var cmdRefreshTable = new ToolStripMenuItem("刷新");
            cmdRefreshTable.Image = null;
            cmdRefreshTable.Tag = table;
            cmdRefreshTable.Click += cmdRefresh_Click;

            //var cmdTableProperty = new ToolStripMenuItem("属性");
            //cmdTableProperty.Image = null;
            //cmdTableProperty.Tag = table;
            //cmdTableProperty.Click += cmdProperty_Click;

            menu.Items.Add(cmdCreateTable);
            menu.Items.Add(cmdDesignTable);
            menu.Items.Add(cmdSelectTableAllRow);
            menu.Items.Add(cmdOpenTable);
            menu.Items.Add(cmdDeleteTable);
            menu.Items.Add(cmdSplit2);
            menu.Items.Add(cmdImport);
            menu.Items.Add(cmdSplit3);
            menu.Items.Add(cmdCreateScript);
            menu.Items.Add(cmdSplit4);
            menu.Items.Add(cmdRenameTable);
            menu.Items.Add(cmdDropTable);
            menu.Items.Add(cmdSplit5);
            menu.Items.Add(cmdRefreshTable);
            //menu.Items.Add(cmdTableProperty);

            #endregion 右键明细表
        }

        #region 右键明细表事件

        /// <summary>Create脚本
        /// Create脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateScript4Create_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableDdl(databaseTable);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>Delete脚本
        /// Delete脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateScript4Delete_Click(object sender, EventArgs e)
        {
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            SqlType dbType = GetServerDbType();
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableDelete(databaseTable);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>Insert脚本
        /// Insert脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateScript4Insert_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableInsert(databaseTable);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>生成所有数据Insert语句脚本
        /// /// 生成所有数据Insert语句脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateScript4InsertData_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            string strSql = GlobalHelp.GetSqlTasks(dbType).GetData(databaseTable, databaseTable.DatabaseSchema.ConnectionString, ProviderToSqlType.Convert(dbType));
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>Select脚本
        /// Select脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateScript4Select_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableSelect(databaseTable);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>SelectPaged脚本
        /// SelectPaged脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateScript4SelectPaged_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableSelectPaged(databaseTable);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>Update脚本
        /// Update脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateScript4Update_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableUpdate(databaseTable);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>新建表
        /// 新建表
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateTable_Click(object sender, EventArgs e)
        {
            ServerTag serverTag = GetServerTag();
            if (serverTag.DBType != SqlType.SqlServer)
            {
                MessageBox.Show("暂时只支持SqlServer");
                return;
            }
            string strDbName = GetDbNameBySelectNode(GlobalHelp.TreeView.SelectedNode);
            string strTableName = string.Empty;
            if (GlobalHelp.TreeView.SelectedNode.Tag as DatabaseTable != null)
            {
                strTableName = GlobalHelp.TreeView.SelectedNode.Text;
            }
            DockContent itemDockContent = new FrmTableNew(serverTag, strDbName, strTableName, SqlType.SqlServer, true) as DockContent;
            IDockContent iDockContent = itemDockContent as IDockContent;
            itemDockContent.Show(dockPanel);
        }

        /// <summary> 清空表
        /// 清空表
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdDeleteTable_Click(object sender, EventArgs e)
        {
            DatabaseTable databaseTable = (sender as ToolStripMenuItem).Tag as DatabaseTable;
            try
            {
                if (databaseTable == null)
                {
                    return;
                }
                StringBuilder sb = new StringBuilder();
                if (databaseTable.ForeignKeyChildren.Contains(databaseTable))
                {
                    MessageBox.Show("警告: " + databaseTable.Name + "有主外键关联");
                    return;
                }
                else
                {
                    sb.AppendLine("DELETE  FROM " + databaseTable.Name);
                }
                if (sb.ToString() != string.Empty)
                {
                    DialogResult diaResult = MessageBox.Show(string.Format("确定清空{0}表数据吗?", databaseTable.Name), "提示", MessageBoxButtons.YesNo);
                    if (diaResult == DialogResult.Yes)
                    {
                        IDBHelper dbHelper = DataBaseManager.GetDbHelper(GetServerDbType(), databaseTable.DatabaseSchema.ConnectionString);
                        dbHelper.CreateCommand(sb.ToString());
                        bool blnResult = dbHelper.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            MessageBox.Show(string.Format("清空{0}成功！", databaseTable.Name));
        }

        /// <summary>设计表
        /// 设计表
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdDesignTable_Click(object sender, EventArgs e)
        {
            ServerTag serverTag = GetServerTag();
            if (serverTag.DBType != SqlType.SqlServer)
            {
                MessageBox.Show("暂时只支持SqlServer");
                return;
            }
            string strDbName = GetDbNameBySelectNode(GlobalHelp.TreeView.SelectedNode);
            string strTableName = string.Empty;
            if (GlobalHelp.TreeView.SelectedNode.Tag as DatabaseTable != null)
            {
                strTableName = GlobalHelp.TreeView.SelectedNode.Text;
            }
            string strText = "设计表" + "_" + serverTag.Server + "_" + strDbName + "_" + strTableName;
            IDockContent iDockContent = FindDocument(strText);
            if (iDockContent == null)
            {
                DockContent itemDockContent = new FrmTableNew(serverTag, strDbName, strTableName, SqlType.SqlServer, false) as DockContent;
                itemDockContent.Show(dockPanel);
            }
            else
            {
                dockPanel.Documents.Where(t => t.DockHandler.TabText == strText).FirstOrDefault().DockHandler.Show();
            }
            //DockContent itemDockContent =
            //IDockContent iDockContent = itemDockContent as IDockContent;
            //itemDockContent.Show(dockPanel);
        }

        /// <summary>Drop表脚本
        /// Drop表脚本
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdDropTable_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            DatabaseTable databaseTable = (sender as ToolStripItem).Tag as DatabaseTable;
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildDropTable(databaseTable);
            OpenDataBaseQuery(strSql, false);
        }

        /// <summary>导出Excel
        /// 导出Excel
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdImportExcel_Click(object sender, EventArgs e)
        {
            DatabaseTable table = (sender as ToolStripItem).Tag as DatabaseTable;
            SqlType dbType = GetServerDbType();
            IDBHelper helper = DataBaseManager.GetDbHelper(dbType, table.DatabaseSchema.ConnectionString);

            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableSelect(table);
            helper.CreateCommand(strSql);
            DataTable dt = helper.ExecuteQuery();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("无可导出的数据");
                return;
            }
            string strPath = NPOIHelper.ExportToExcel(dt);
            if (strPath == null)
            {
                return;
            }
            DialogResult diaResult = MessageBox.Show(string.Format("导出至{0},是否打开？", strPath), "提示", MessageBoxButtons.YesNo);
            if (diaResult == DialogResult.Yes)
            {
                Process.Start(strPath);
            }
        }

        /// <summary>打开表
        /// 打开表
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdOpenTable_Click(object sender, EventArgs e)
        {
            ServerTag serverTag = GetServerTag();
            string strDbName = GetDbNameBySelectNode(GlobalHelp.TreeView.SelectedNode);

            string strTableName = string.Empty;
            if (GlobalHelp.TreeView.SelectedNode.Tag as DatabaseTable != null)
            {
                strTableName = GlobalHelp.TreeView.SelectedNode.Text;
            }

            string strText = "打开表" + "_" + serverTag.Server + "_" + strDbName + "_" + strTableName;
            IDockContent iDockContent = FindDocument(strText);
            if (iDockContent == null)
            {
                DockContent itemDockContent = new FrmTableView(serverTag, strDbName, strTableName) as DockContent;
                itemDockContent.Show(dockPanel);
            }
            else
            {
                dockPanel.Documents.Where(t => t.DockHandler.TabText == strText).FirstOrDefault().DockHandler.Show();
            }
        }

        /// <summary>选择所有行
        ///选择所有行
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdSelectTableAllRow_Click(object sender, EventArgs e)
        {
            DatabaseTable databaseTable = (sender as ToolStripMenuItem).Tag as DatabaseTable;
            if (databaseTable == null)
            {
                return;
            }
            SqlType dbType = GetServerDbType();
            string strSql = GlobalHelp.GetSqlTasks(dbType).BuildTableSelect(databaseTable);
            OpenDataBaseQuery(strSql, true);
        }

        #endregion 右键明细表事件

        /// <summary>新建数据库
        /// 新建数据库
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdCreateDataBase_Click(object sender, EventArgs e)
        {
            ServerTag serverTag = GetServerTag();
            if (serverTag.DBType != SqlType.SqlServer)
            {
                MessageBox.Show(@"暂时只支持SqlServer");
                return;
            }
            FrmCreateDatabase frmCreateDatabase = new FrmCreateDatabase(serverTag.DBType);
            if (frmCreateDatabase.ShowDialog() == DialogResult.OK)
            {
                IDBHelper helper = DataBaseManager.GetDbHelper(serverTag.DBType, serverTag.MasterConn);
                helper.CreateCommand(frmCreateDatabase.CreateDatabaseScript + " ; SELECT 'OK'");
                DataTable dt = helper.ExecuteQuery();
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show(@"新建数据库成功");
                    //TODO
                    //同步全局的结构字典
                }
                else
                {
                    MessageBox.Show(@"新建数据库失败");
                }
            }
        }

        /// <summary>数据库关系图
        /// 数据库关系图
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdDbRelationView_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现");
            return;
            FrmTableRelationView frmView = new FrmTableRelationView();
            frmView.Show();
        }

        /// <summary> 删除对象(表、视图、存储过程、函数等)
        /// 删除对象(表、视图、存储过程、函数等)
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdDrop_Click(object sender, EventArgs e)
        {
            DropObject(GetServerDbType(), (sender as ToolStripMenuItem).Tag);
        }

        /// <summary>属性
        /// 属性
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdProperty_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现");
        }

        /// <summary>刷新
        /// 刷新
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"暂未实现");
        }

        /// <summary>重命名
        /// 重命名
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdRename_Click(object sender, EventArgs e)
        {
            SqlType dbType = GetServerDbType();
            if (dbType != SqlType.SqlServer)
            {
                MessageBox.Show(@"暂时只支持SqlServer");
                return;
            }
            if (GlobalHelp.TreeView.SelectedNode == null)
            {
                MessageBox.Show(@"请选择要重命名的对象");
                return;
            }
            var toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null) RenameObject(GetServerDbType(), toolStripMenuItem.Tag);
        }

        /// <summary> 删除对象(表、视图、存储过程、函数等)
        /// 删除对象
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <param name="obj">obj</param>
        private bool DropObject(SqlType dbType, object obj)
        {
            bool blnDropFlag = false;
            var schema = obj as DatabaseSchema;
            var view = obj as DatabaseView;
            var table = obj as DatabaseTable;
            var column = obj as DatabaseColumn;
            var pack = obj as DatabasePackage;
            var sproc = obj as DatabaseStoredProcedure;
            var fun = obj as DatabaseFunction;
            var constraint = obj as DatabaseConstraint;
            var trigger = obj as DatabaseTrigger;
            var index = obj as DatabaseIndex;
            StringBuilder sb = new StringBuilder();
            string strName = string.Empty;
            string strConnection = string.Empty;
            if (dbType == SqlType.SqlServer || dbType == SqlType.MySql || dbType == SqlType.MySql)
            {
                //删除视图
                if (view != null)
                {
                    strName = view.Name;
                    strConnection = view.DatabaseSchema.ConnectionString;
                }
                //删除表
                else if (table != null)
                {
                    strName = table.Name;
                    strConnection = table.DatabaseSchema.ConnectionString;
                    if (table.ForeignKeyChildren.Contains(table))
                    {
                        MessageBox.Show(@"警告: " + strName + @"有主外键关联");
                        blnDropFlag = false;
                    }
                    else
                    {
                        var sqlWriter = new SqlWriter(table, dbType);
                        sb.AppendLine("Drop Table " + sqlWriter.EscapedTableName + " ; SELECT 'OK'");
                    }
                }
                //删除存储过程
                else if (sproc != null)
                {
                    strName = sproc.Name;
                    strConnection = sproc.DatabaseSchema.ConnectionString;
                }
                //删除函数
                else if (fun != null)
                {
                    strName = fun.Name;
                    strConnection = fun.DatabaseSchema.ConnectionString;
                }

                #region 执行删除

                if (sb.ToString().Trim() != string.Empty)
                {
                    DialogResult diaResult = MessageBox.Show(string.Format("确定彻底删除{0}吗?", strName), @"提示", MessageBoxButtons.YesNo);
                    if (diaResult == DialogResult.Yes)
                    {
                        IDBHelper dbHelper = DataBaseManager.GetDbHelper(dbType, strConnection);
                        dbHelper.CreateCommand(sb.ToString());
                        DataTable dtResult = dbHelper.ExecuteQuery();
                        if (dtResult.Rows.Count == 1)
                        {
                            MessageBox.Show(string.Format("删除{0}成功！", strName));
                            if (table != null) table.DatabaseSchema.RemoveTable(table);
                            GlobalHelp.TreeView.SelectedNode.Remove();
                            blnDropFlag = true;
                        }
                    }
                }

                #endregion 执行删除
            }
            return blnDropFlag;
        }

        /// <summary> 重命名对象(表、视图、存储过程、函数等)
        /// 重命名对象
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <param name="obj">obj</param>
        private void RenameObject(SqlType dbType, object obj)
        {
            var schema = obj as DatabaseSchema;
            var view = obj as DatabaseView;
            var table = obj as DatabaseTable;
            var column = obj as DatabaseColumn;
            var pack = obj as DatabasePackage;
            var sproc = obj as DatabaseStoredProcedure;
            var fun = obj as DatabaseFunction;
            var constraint = obj as DatabaseConstraint;
            var trigger = obj as DatabaseTrigger;
            var index = obj as DatabaseIndex;
            StringBuilder sb = new StringBuilder();
            string strName = string.Empty;
            string strConnection = string.Empty;
            string strNewName = string.Empty;
            FrmRename frnRename = new FrmRename();
            if (frnRename.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                strNewName = frnRename.Rename;
            }
            if (dbType == SqlType.SqlServer || dbType == SqlType.MySql)
            {
                //重命名表
                if (table != null)
                {
                    strConnection = table.DatabaseSchema.ConnectionString;
                    sb.AppendLine(new SqlTasks(dbType).RenameTable(strNewName, table.Name));
                    table.Name = strNewName;
                }
                //重命名存储过程
                else if (sproc != null)
                {
                    strName = sproc.Name;
                    strConnection = sproc.DatabaseSchema.ConnectionString;
                }
                //重命名视图
                else if (view != null)
                {
                    strName = view.Name;
                    strConnection = view.DatabaseSchema.ConnectionString;
                }
                //重命名函数
                else if (fun != null)
                {
                    strName = fun.Name;
                    strConnection = fun.DatabaseSchema.ConnectionString;
                }

                #region 执行重命名

                if (sb.ToString().Trim() != string.Empty)
                {
                    try
                    {
                        IDBHelper dbHelper = DataBaseManager.GetDbHelper(dbType, strConnection);
                        dbHelper.CreateCommand(sb.ToString());
                        bool blnResult = dbHelper.ExecuteNonQuery();
                        GlobalHelp.TreeView.SelectedNode.Text = strNewName;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    MessageBox.Show(string.Format("重命名{0}成功！", strName));
                }

                #endregion 执行重命名
            }
        }

        #endregion 右键事件

        #region 基本方法

        /// <summary>打开查询窗体
        /// 打开查询窗体
        /// </summary>
        /// <param name="strDefaultSql">strDefaultSql</param>
        /// <param name="blnAutoRun"></param>
        public void OpenDataBaseQuery(string strDefaultSql, bool blnAutoRun)
        {
            string strDbName;
            ServerTag serverTag = GetServerTag();
            if (serverTag.DBType == SqlType.SQLite)
            {
                strDbName = serverTag.Server;
            }
            else
            {
                strDbName = GetDbNameBySelectNode(GlobalHelp.TreeView.SelectedNode);
            }
            DockContent itemDockContent = new FrmDataBaseQuery(serverTag, strDbName, strDefaultSql, blnAutoRun);
            itemDockContent.TabText = strDbName + "查询";
            //IDockContent iDockContent = itemDockContent as IDockContent;
            itemDockContent.Show(dockPanel);
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

        /// <summary>获取数据库名称
        /// 获取数据库名称
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetDbNameBySelectNode(TreeNode node)
        {
            string strDbName = string.Empty;
            List<string> lstPath = node.FullPath.Replace("\\", "*").Split('*').ToList();
            for (int i = 0; i < lstPath.Count; i++)
            {
                if (lstPath[i] == "数据库" && i < lstPath.Count - 1)
                {
                    strDbName = lstPath[i + 1];
                }
            }
            return strDbName;
        }

        /// <summary>获取服务器下的所有数据库集合
        /// 获取服务器下的所有数据库集合
        /// </summary>
        /// <returns></returns>
        private DataTable GetServerDataTables()
        {
            ServerTag serverTag = GetServerTag();
            return serverTag.ServerDBNames;
        }

        /// <summary>获取数据库类型
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        private SqlType GetServerDbType()
        {
            ServerTag serverTag = GetServerTag();
            return serverTag.DBType;
        }

        /// <summary>获取服务器树节点
        /// 获取服务器树节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode GetServerNameBySelectNode(TreeNode node)
        {
            TreeNode treenode;
            if (node.Parent == null)
            {
                treenode = node;
            }
            else
            {
                return GetServerNameBySelectNode(node.Parent);
            }
            return treenode;
        }

        /// <summary>获取服务端TreeNode的Tag
        /// 获取服务端TreeNode的Tag
        /// </summary>
        /// <returns></returns>
        private ServerTag GetServerTag()
        {
            TreeNode serverNode = GetServerNameBySelectNode(GlobalHelp.TreeView.SelectedNode);
            return serverNode.Tag as ServerTag;
        }

        /// <summary>移除数据库结构
        /// 移除数据库结构
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="strKey"></param>
        private void RemoveDatabaseSchema(SqlType dbType, string strKey)
        {
            switch (dbType)
            {
                case SqlType.SqlServer:
                    if (GlobalHelp.DicSqlServerDatabaseSchema != null && GlobalHelp.DicSqlServerDatabaseSchema.ContainsKey(strKey))
                    {
                        GlobalHelp.DicSqlServerDatabaseSchema.Remove(strKey);
                    }
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    if (GlobalHelp.DicMySqlDatabaseSchema != null && GlobalHelp.DicMySqlDatabaseSchema.ContainsKey(strKey))
                    {
                        GlobalHelp.DicMySqlDatabaseSchema.Remove(strKey);
                    }
                    break;

                case SqlType.SQLite:
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
        }

        private void OpenCodeMaker()
        {
            //需引用Nikita.Assist.CodeMaker
            //MessageBox.Show("暂未集成");  
            if (GlobalHelp.TreeView.SelectedNode == null || (GlobalHelp.TreeView.SelectedNode.Tag as DatabaseTag) == null)
            {
                MessageBox.Show(@"请先选中要生成的数据库");
                return;
            }
            DatabaseTag dbTag = ((DatabaseTag) GlobalHelp.TreeView.SelectedNode.Tag);
            DbSchema dbSchema = new DbSchema
            {
                DatabaseSchema = dbTag.DatabaseSchema,
                SqlType = dbTag.ServerTag.DBType,
                DatabaseName=dbTag.DatabaseName
            };
            FrmCodeMakerMain frmCodeMaker = new FrmCodeMakerMain(dbSchema);
            frmCodeMaker.Show();
            //DockContent itemDockContent = new FrmCodeMakerMain(dbSchema) as DockContent;
            //IDockContent iDockContent = FindDocument(itemDockContent.Text);
            //if (iDockContent == null)
            //{
            //    itemDockContent.Show(dockPanel);
            //}
            //else
            //{
            //    dockPanel.Documents.Where(t => t.DockHandler.TabText == itemDockContent.Text).FirstOrDefault().DockHandler.Show();
            //}
        }

        #endregion 基本方法

        private void FrmDataBaseMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalHelp.TreeView.Nodes.Clear();
        }

        private void 脚本批量执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalHelp.TreeView.Nodes.Count == 0)
            {
                MessageBox.Show(@"请先连接服务器");
                return;
            }
            List<ServerTag> lstServerTag = (from TreeNode item in GlobalHelp.TreeView.Nodes where (item.Tag as ServerTag) != null select (ServerTag) item.Tag).ToList();
            FrmDataBaseQueryBatch frmBatch = new FrmDataBaseQueryBatch(lstServerTag);
            frmBatch.ShowDialog();
        }

        private void 代码生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCodeMaker();
        }

        private void cmdCodeMaker_Click_1(object sender, EventArgs e)
        { 
            OpenCodeMaker();
        }
    }
}