using Nikita.Assist.WcfService;
using Nikita.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;  

namespace Nikita.Base.Services
{
    public class PermissionService
    {
        public static DataTable GetPermission(string strUserName, string strPassword, bool blnWithCheckPermission)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int intSystemId = int.Parse(ConfigHelper.GetConfigKeyValue("SystemId"));
            ChannelFactory<IPermissionService> factory = new ChannelFactory<IPermissionService>(new NetTcpBinding(), "net.tcp://localhost:13125/PermissionService/PermissionService");

            var channel = factory.CreateChannel();
            DataTable dt = channel.GetPermission(strUserName, strPassword, intSystemId, blnWithCheckPermission);
            stopwatch.Stop();
            //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
            //for (int i = 0; i < 5; i++)
            //{
            //    stopwatch.Reset();
            //    stopwatch.Start();
            //    int intSystemId2 = int.Parse(ConfigHelper.GetConfigKeyValue("SystemId"));
            //    ChannelFactory<IPermissionService> factory2 = new ChannelFactory<IPermissionService>(new NetTcpBinding(), "net.tcp://localhost:13125/PermissionService/PermissionService");
            //    var channel2 = factory.CreateChannel();
            //    DataTable dt2 = channel.GetPermission(strUserName, strPassword, intSystemId, false);
            //    stopwatch.Stop();
            //    MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());

            //}
            return dt;
        }
         
    }
}