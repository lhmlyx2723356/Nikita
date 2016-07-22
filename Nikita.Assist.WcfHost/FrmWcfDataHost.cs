
using System;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Windows.Forms;
using DevExpress.XtraEditors; 
using H.M.WcfDataLayer;
using System.Configuration;
using System.Linq;

namespace Nikita.Assist.WcfHost
{
    public partial class FrmWcfDataHost : XtraForm
    {
        public FrmWcfDataHost()
        {
            InitializeComponent();
        }
        ServiceHost _host;
        ServiceHost _hostImage;
        ServiceHost _hostMsSqlDataAccess;
        private void btnStartService_Click(object sender, EventArgs e)
        {
            if (listBoxControl1.Items.Count > 0)
            {
                if (listBoxControl1.Items[0].ToString().Contains("启动成功"))
                {
                    MessageBox.Show(@"服务已经在开启中了！");
                    return;
                }
            }

            listBoxControl1.Items.Clear();
            _host = new ServiceHost(typeof(Service1));
            _host.Open();
            _hostImage = new ServiceHost(typeof(ImageService));
            _hostImage.Open();
            _hostMsSqlDataAccess = new ServiceHost(typeof(MsSqlDataAccessService));
            _hostMsSqlDataAccess.Open();


            foreach (var channelDispatcherBase in _host.ChannelDispatchers)
            {
                var cd = (ChannelDispatcher)channelDispatcherBase;
                foreach (var ed in cd.Endpoints)
                {
                    listBoxControl1.Items.Add(ed.EndpointAddress.Uri + "---启动成功," + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                }
            }

            foreach (var channelDispatcherBase in _hostImage.ChannelDispatchers)
            {
                var cd = (ChannelDispatcher)channelDispatcherBase;
                foreach (var ed in cd.Endpoints)
                {
                    listBoxControl1.Items.Add(ed.EndpointAddress.Uri + "---启动成功," + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                }
            }


            foreach (var channelDispatcherBase in _hostMsSqlDataAccess.ChannelDispatchers)
            {
                var cd = (ChannelDispatcher)channelDispatcherBase;
                foreach (var ed in cd.Endpoints)
                {
                    listBoxControl1.Items.Add(ed.EndpointAddress.Uri + "---启动成功," + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            if (_host == null)
            {
                MessageBox.Show("服务不存在，要停止也无从停起");
                return;
            }
            //判断服务是否关闭 
            listBoxControl1.Items.Clear();
            if (_host.State != CommunicationState.Closed)
            {
                _host.Close();
                _hostImage.Close();
                _hostMsSqlDataAccess.Close();
            }
            listBoxControl1.Items.Add("所有服务已经被关闭---" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        private void frmWcfDataHost_Load(object sender, EventArgs e)
        {
            if (GetConfigKeyValue("AutoRun") == "true")
            {
                chkAutoRun.Visible = true;
            }
            else
            { 
                chkAutoRun.Visible = false;
            }      

            if (GetConfigKeyValue("AutoRunService") == "true")
            {
                btnStartService_Click(null, null);
            }
        }

        private void frmWcfDataHost_SizeChanged(object sender, EventArgs e)
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
        private void frmWcfDataHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideFrom();
            ShowTip("服务在这休息休息。", "提示", 2000);
            notifyIcon1.ShowBalloonTip(2000);//显示气泡提示，参数为显示时间
            e.Cancel = true;
        }

        public void ShowTip(string txt, string caption, int time)
        {
            notifyIcon1.BalloonTipText = txt;
            notifyIcon1.BalloonTipTitle = caption;
            notifyIcon1.ShowBalloonTip(time);//显示气泡提示，参数为显示时间
        }

        private void ItemRestart_Click(object sender, EventArgs e)
        {
            if (_host == null)
            {
                _host = new ServiceHost(typeof(Service1));

                _hostImage = new ServiceHost(typeof(ImageService));
                btnStartService_Click(null, null);
            }
            if (_host.State == CommunicationState.Opened)
            {
                listBoxControl1.Items.Clear();
                _host.Close();
                _hostImage.Close();
                _hostMsSqlDataAccess.Close();
                btnStartService_Click(null, null);
            }
            if (_host.State == CommunicationState.Closed)
            {
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
            if (_host.State != CommunicationState.Closed)
            {
                btnStopService_Click(null, null);
            }
            ShowTip("停止服务成功。", "提示", 2000);
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            try
            { 
                if (chkAutoRun.Checked)
                { 
                    AutoRunHelper.SetAutoRun(Application.StartupPath + "\\H.M.WcfDataHost.exe", true);
                    MessageBox.Show(@"开启启动设置成功，下次开机后会自动启动服务！");
                }
                if (!chkAutoRun.Checked)
                { 
                    AutoRunHelper.SetAutoRun(Application.StartupPath + "\\H.M.WcfDataHost.exe", false); MessageBox.Show(@"取消开机启动成功！");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>获取当前运行项目所对应的config里的Setting里Key为'SetKey'
        /// 所对应的value值 
        /// </summary>
        /// <param name="SetKey">App.config里设置的key值</param>
        /// <returns></returns>
        public static string GetConfigKeyValue(string SetKey)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(SetKey))
            {
                val = ConfigurationManager.AppSettings[SetKey];
            }
            return val;
            //方法二
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //return config.AppSettings.Settings[SetKey].Value.ToString();
        }
    }
}
