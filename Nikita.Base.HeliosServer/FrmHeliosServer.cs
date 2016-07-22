using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Collections.Concurrent;
using System.Net;
using System.Windows.Forms;
using Helios.Net;
using Helios.Reactor.Bootstrap;
using Helios.Topology;
using Nikita.Base.HeliosCommon;
using Message = Nikita.Base.HeliosCommon.Message;

namespace Nikita.Base.HeliosServer
{
    public partial class FrmHeliosServer : System.Windows.Forms.Form
    {
        private static readonly ConcurrentDictionary<string, IConnection> Clients =
            new ConcurrentDictionary<string, IConnection>();

        public FrmHeliosServer()
        {
            InitializeComponent();
        }

        private Helios.Reactor.IReactor server;
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            var host = IPAddress.Any;
            var port = 9991; 
            lblTxt.Text=string.Format("开启服务 {0}:{1}", host, port) ;

            var serverFactory =
                new ServerBootstrap()
                    .SetTransport(TransportType.Tcp)
                    .Build();
              server = serverFactory.NewReactor(NodeBuilder.BuildNode().Host(host).WithPort(port));
            server.OnConnection += (address, connection) =>
            { 
                connection.BeginReceive(Receive);
            };
            server.OnDisconnection += (reason, address) => { };  
                 //MessageBox.Show(string.Format("断开连接: {0}; 原因: {1}", address.RemoteHost, reason.Type));
            server.Start(); 
        }

        /// <summary>
        /// 处理接受到的消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="channel"></param>
        public static void Receive(NetworkData data, IConnection channel)
        {
            var message = MessageConverter.ToMessage(data);
            switch (message.Command)
            {
                case Command.Join:
                    JoinGroup(message.Content, channel);
                    break;
                case Command.Send: 
                        Broadcast(message.Content); 
                    break;
            }
        }

        public static void JoinGroup(string clientName, IConnection channel)
        { 
            Clients.TryAdd(clientName, channel);
            //if (Clients.TryAdd(clientName, channel))
            //{
            //    Broadcast(string.Format("{0} join group successful .", clientName));
            //}
            //else
            //{
            //    var errMsg = new Message()
            //    {
            //        Command = Command.Send,
            //        Content = "client name is used."
            //    };
            //    SendMessage(channel, errMsg);
            //}
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="clientMessage"></param>
        public static void Broadcast(string clientMessage)
        {
            //Console.WriteLine(clientMessage);
            //var clientName = clientMessage.Split(':')[0];
            var message = new Message
            {
                Command = Command.Send,
                Content = clientMessage
            };
            foreach (var client in Clients)
            {
                //if (client.Key != clientName)
                //{
                    SendMessage(client.Value, message);
                //}
            }
        }

        public static void SendMessage(IConnection connection, Message message)
        {
            var messageBytes = MessageConverter.ToBytes(message);
            connection.Send(new NetworkData { Buffer = messageBytes, Length = messageBytes.Length });
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            { 
                if (server != null)
                {
                    server.Stop();
                    lblTxt.Text = @"服务停止成功";
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
