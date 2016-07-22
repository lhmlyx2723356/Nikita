using Nikita.Assist.WcfConfiguration;
using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Nikita.Permission.DAL
{
    public class ServiceHelper
    {
        public static IMsSqlDataAccessService GetMsSqlDataAccessService()
        {
            ChannelFactory<IMsSqlDataAccessService> factory = null;
            IMsSqlDataAccessService channel = null;
            try
            {
                //非负载均衡、集群
                //factory = new ChannelFactory<IMsSqlDataAccessService>(new NetTcpBinding(), "net.tcp://localhost:13125/MsSqlDataAccessService/MsSqlDataAccessService");
                //集群，考虑负载均衡的时候，按服务器配置情况，设置服务权重，随机分配服务地址
                string strRetService = WcfConfigHelper.ReturnOneService("3");
                factory = new ChannelFactory<IMsSqlDataAccessService>(new NetTcpBinding(), strRetService);
                channel = factory.CreateChannel();
            }
            catch (Exception)
            {
                if (factory != null)
                    factory.Abort();
            }
            return channel;
        }
    }
}