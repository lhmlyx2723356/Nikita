using Nikita.Assist.WcfConfiguration;
using Nikita.Assist.WcfConfiguration.DAL;
using Nikita.Assist.WcfConfiguration.Model;
using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.WcfHost
{
    public partial class FrmWcfHost : Form
    {
        /*
         * 解决：使用 MMC 启用 Net.TCP 端口共享服务
          1.从“开始”菜单中，通过打开“命令提示符”窗口并键入 services.msc，或通过打开“运行”并在“打开”框中键入 services.msc，打开服务管理控制台。
          2.在服务列表的“名称”列中，右击“Net.Tcp Port Sharing Service”，并从菜单中选择“属性”。
          3.若要启用服务的手动启动功能，请在“属性”窗口中选择“常规”选项卡，并在“启动类型”框中选择“手动”，然后单击“应用”。
          4.若要启动服务，请在“服务”状态区域中单击“启动”按钮。现在，服务状态区域应显示为“已启动”。
          5.若要返回到服务列表，请单击“确定”并退出 MMC 控制台。
   (Windows Communication Foundation (WCF) 使用一个名为 Net.TCP 端口共享服务的 Windows 服务，以方便在多个进程之间共享 TCP 端口。此服务作为 WCF 的一部分进行安装，但作为一项安全预防措施，默认情况下不会启用该服务，因此必须在首次使用它之前手动启用。本主题描述如何使用 Microsoft 管理控制台 (MMC) 管理单元配置 Net TCP 端口共享服务。*/
        //参考：http://www.cnblogs.com/huangxincheng/p/4575488.html

        /// <summary>选中的TreeNode
        ///
        /// </summary>
        private static List<TreeNode> _lstCheckTreeNodes;

        private List<ServiceHost>  _lstServiceHost;

        public FrmWcfHost()
        {
            InitializeComponent();
            _lstServiceHost = new List<ServiceHost>();
        }

        /// <summary>获取当前运行项目所对应的config里的Setting里Key为'SetKey'
        /// 所对应的value值
        /// </summary>
        /// <param name="strSetKey">App.config里设置的key值</param>
        /// <returns></returns>
        public static string GetConfigKeyValue(string strSetKey)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(strSetKey))
            {
                val = ConfigurationManager.AppSettings[strSetKey];
            }
            return val;
        }

        public void ShowTip(string txt, string caption, int time)
        {
            notifyIcon1.BalloonTipText = txt;
            notifyIcon1.BalloonTipTitle = caption;
            notifyIcon1.ShowBalloonTip(time);//显示气泡提示，参数为显示时间
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            List<TreeNode> treeNodes = GetAllCheckNodes(treeView1);
            if (treeNodes.Count == 0)
            {
                MessageBox.Show(@"请选择要启动的服务！");
                return;
            }
            if (rcbState.Text.Trim() != string.Empty)
            {
                if (rcbState.Text.Contains("启动成功"))
                {
                    MessageBox.Show(@"服务已经在开启中了！");
                    return;
                }
            }

            rcbState.Text = string.Empty;
            foreach (var item in treeNodes)
            {
                WcfConfigInfo wcfConfig = item.Tag as WcfConfigInfo;
                if (wcfConfig != null)
                {
                    Type typeClassName = Assembly.LoadFrom(wcfConfig.WcfServiceNameSpace + ".dll").GetType(wcfConfig.WcfServiceNameSpace + "." + wcfConfig.WcfServiceClassName, true, true);
                    ServiceHost host = new ServiceHost(typeClassName, new Uri(wcfConfig.EnpointBindUrl));
                    Type typeInterfaceName = Assembly.LoadFrom(wcfConfig.WcfServiceNameSpace + ".dll").GetType(wcfConfig.WcfServiceNameSpace + "." + wcfConfig.WcfServiceInterfaceName, true, true);
                    if (wcfConfig.WcfServiceClassName != null)
                    {
                        if (wcfConfig.WcfType=="TCP")
                        { 
                            host.AddServiceEndpoint(typeInterfaceName, new NetTcpBinding() { PortSharingEnabled = true }, wcfConfig.WcfServiceClassName);
                        }
                        else if (wcfConfig.WcfType == "Duplex")
                        {
                           
                         ServiceEndpoint endpoint=   host.AddServiceEndpoint(typeInterfaceName, new WSDualHttpBinding() {ClientBaseAddress =new Uri(wcfConfig.EnpointBindUrl) }, wcfConfig.WcfServiceClassName);
                            endpoint.Name = "SendServiceWcf";
                            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior {HttpGetEnabled = true};
                            host.Description.Behaviors.Add(behavior);
                        }
                    }
                    //公布元数据
                    //_host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                    //_host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                    host.Open();
                    _lstServiceHost.Add(host);
                    //foreach (var channelDispatcherBase in host.ChannelDispatchers)
                    //{
                    //foreach (var ed in cd.Endpoints)
                    //{
                    rcbState.Text += (@"[" + wcfConfig.WcfServiceName + @"]" + @"启动成功," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + Environment.NewLine;
                    //}
                    //}
                }
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            if (_lstServiceHost.Count == 0)
            {
                MessageBox.Show(@"服务不存在，无从停起");
                return;
            }
            //判断服务是否关闭
            rcbState.Text = string.Empty;
            foreach (ServiceHost host in _lstServiceHost)
            {
                if (host.State != CommunicationState.Closed)
                {
                    host.Close();
                }
            }

            rcbState.Text = (@"所有服务已经被关闭---" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRun.Checked)
            {
                AutoRunHelper.SetAutoRun(Application.StartupPath + "\\Nikita.Assist.WcfHost.exe", true);
                MessageBox.Show(@"开启启动设置成功，下次开机后会自动启动服务！");
            }
            if (!chkAutoRun.Checked)
            {
                AutoRunHelper.SetAutoRun(Application.StartupPath + "\\Nikita.Assist.WcfHost.exe", false); MessageBox.Show(@"取消开机启动成功！");
            }
        }

        private void FrmWcfHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideFrom();
            ShowTip("服务在这休息休息。", "提示", 2000);
            notifyIcon1.ShowBalloonTip(2000);//显示气泡提示，参数为显示时间
            e.Cancel = true;
        }

        private void FrmWcfHost_Load(object sender, EventArgs e)
        {
            chkAutoRun.Visible = GetConfigKeyValue("AutoRun") == "true"; 
            WcfConfigInfoDAL dal = new WcfConfigInfoDAL();
            List<WcfConfigInfo> lstInfo = dal.GetListArray("State=1");
            foreach (WcfConfigInfo item in lstInfo)
            {
                TreeNode node = treeView1.Nodes.Add("[" + item.WcfServiceName + "]");//+ item.EnpointBindUrl
                node.Tag = item;
            }
            if (lstInfo.Count > 0)
            {
                foreach (TreeNode item in treeView1.Nodes)
                {
                    item.Checked = true;
                }
                if (GetConfigKeyValue("AutoRunService") == "true")
                {
                    btnStartService_Click(null, null);
                }
            }
        }

        private void FrmWcfHost_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideFrom();
            }
        }

        private void HideFrom()
        {
            //notifyIcon1.Icon = _ico;
            ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ItemRestart_Click(object sender, EventArgs e)
        {
            if (_lstServiceHost.Count == 0 || _lstServiceHost[0].State == CommunicationState.Closed)
            {
                btnStartService_Click(null, null);
            }
            else if (_lstServiceHost[0].State == CommunicationState.Opened)
            {
                rcbState.Text = string.Empty;
                foreach (ServiceHost item in _lstServiceHost)
                {
                    item.Close();
                }
                btnStartService_Click(null, null);
            }
            ShowTip("重启服务成功。", "提示", 2000);
        }

        private void ItemStart_Click(object sender, EventArgs e)
        {
            btnStartService_Click(null, null);
            ShowTip("启动服务成功。", "提示", 2000);
        }

        private void ItemStop_Click(object sender, EventArgs e)
        {
            if (_lstServiceHost[0].State != CommunicationState.Closed)
            {
                btnStopService_Click(null, null);
            }
            ShowTip("停止服务成功。", "提示", 2000);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //判断是否已经最小化于托盘
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                Activate();
                //任务栏区显示图标
                ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
                Visible = true;
            }
        }

        #region 获取勾选的所有TreeNode

        /// <summary>获取勾选的所有TreeNode
        ///
        /// </summary>
        /// <param name="tvwView"></param>
        /// <returns></returns>
        public static List<TreeNode> GetAllCheckNodes(TreeView tvwView)
        {
            _lstCheckTreeNodes = new List<TreeNode>();
            foreach (TreeNode note in tvwView.Nodes)
            {
                if (note.Checked)
                {
                    _lstCheckTreeNodes.Add(note);
                }
                CheckNode(note);
            }
            return _lstCheckTreeNodes;
        }

        private static void CheckNode(TreeNode note1)
        {
            foreach (TreeNode note in note1.Nodes)
            {
                if (note.Checked)
                {
                    _lstCheckTreeNodes.Add(note);
                    CheckNode(note);
                }
            }
        }

        #endregion 获取勾选的所有TreeNode

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                WcfConfigInfo wcfInfo = e.Node.Tag as WcfConfigInfo;
                if (wcfInfo != null) rcbAddress.Text = wcfInfo.EnpointBindUrl;
            }
        }
    }
}