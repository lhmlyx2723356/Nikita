using Nikita.Assist.WcfService;
using Nikita.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Nikita.Applications.WinFramework
{
    public class PermissionHelper
    {
        public static DataTable GetPermission(string strUserName, string strPassword)
        {
            int intSystemId = int.Parse(ConfigHelper.GetConfigKeyValue("SystemId"));
            ChannelFactory<IPermissionService> factory = new ChannelFactory<IPermissionService>(new NetTcpBinding(), "net.tcp://localhost:13125/PermissionService/PermissionService");
            var channel = factory.CreateChannel();
            return channel.GetPermission(strUserName, strPassword, intSystemId,true);
        }
    }
}