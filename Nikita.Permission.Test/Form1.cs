using Nikita.Assist.WcfConfiguration;
using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nikita.Permission.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void Random(ref string[] arr)
        {
            Random ran = new Random();
            int k = 0;
            string strtmp = "";
            for (int i = 0; i < arr.Length; i++)
            {
                k = ran.Next(0, 20);
                if (k != i)
                {
                    strtmp = arr[i];
                    arr[i] = arr[k];
                    arr[k] = strtmp;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PermissionServiceReference.PermissionServiceClient client = new PermissionServiceReference.PermissionServiceClient();
            dataGridView1.DataSource = client.GetPermission(textBox1.Text.Trim(), textBox2.Text.Trim(), int.Parse(textBox3.Text.Trim()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richDisplayMessage.Text = string.Empty;
            int intCOunt = int.Parse(textBox4.Text.Trim());
            ThreadPool.QueueUserWorkItem(p =>
            {
                for (int i = 0; i < intCOunt; i++)
                {
                    InvokeTestMethods(i.ToString());   //这个方法就是开启线程，调用WCF服务
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChannelFactory<IPermissionService> factory = new ChannelFactory<IPermissionService>(new NetTcpBinding(), "net.tcp://localhost:13125/PermissionService/PermissionService");

            var channel = factory.CreateChannel();

            var result = channel.GetPermission("lhm", "1", 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] strarr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            Random(ref strarr);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            List<string> lst = WcfConfigHelper.GenServiceArrayByPercentage("3");
            int count = lst.Where(t => t.Equals("net.tcp://localhost:13125/MsSqlDataAccessService")).Count();
            int count1 = lst.Where(t => t.Equals("net.tcp://localhost:13125/MsSqlDataAccessService1")).Count();
            StringBuilder sb = new StringBuilder();
            foreach (var item in lst)
            {
                sb.AppendLine(item);
            }
            richTextBox1.Text = sb.ToString();
        }

        private void InvokeTestMethods(string clientName)
        {
            Thread thread = new Thread(p =>
          {
              Stopwatch stopwatch = new Stopwatch();
              stopwatch.Start();
              string connectionName = clientName;
              //PermissionServiceReference.PermissionServiceClient testClient = new PermissionServiceReference.PermissionServiceClient(); //线程每次调用都创建一个客户端实例
              //testClient.Open(); //打开
              //testClient.GetPermission(textBox1.Text.Trim(), textBox2.Text.Trim(), int.Parse(textBox3.Text.Trim()));
              //stopwatch.Stop();
              //testClient.Close(); //关闭
              ChannelFactory<IPermissionService> factory = new ChannelFactory<IPermissionService>(new NetTcpBinding(), "net.tcp://localhost:13125/PermissionService/PermissionService");
              factory.Open();
              var channel = factory.CreateChannel();
              channel.GetPermission("lhm", "1", 1);
              stopwatch.Stop();
              factory.Close();
              int threadID = Thread.CurrentThread.ManagedThreadId;
              Action action = () => this.richDisplayMessage.Text += connectionName + " 连接成功 - " + stopwatch.ElapsedMilliseconds + ". ||ThreadID: " + threadID + Environment.NewLine;
              this.BeginInvoke(action);
          });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}