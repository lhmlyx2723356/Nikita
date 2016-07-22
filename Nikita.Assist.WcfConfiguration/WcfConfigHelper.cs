using Nikita.Assist.WcfConfiguration.DAL;
using Nikita.Assist.WcfConfiguration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.WcfConfiguration
{
    public class WcfConfigHelper
    {

        private static List<string> Services
        {
            get;
            set;
        }

        /// <summary>
        /// 如果集群的时候根据WCF设置表（WcfConfigInfo）设置的群组ID对应的百分比权重生成随机数组服务(要求：百分比加起来是百分之一百)
        /// 集群的时候，有可能某些服务器比较好，有些配置比较低。
        /// 集群需要考虑：数据库主从复制等问题。
        /// </summary>
        /// <param name="strWcfGroup"></param>
        public static List<string> GenServiceArrayByPercentage(string strWcfGroup)
        {
            List<WcfConfigInfo> lstWcfConfigInfo = new WcfConfigInfoDAL().GetListArray("WcfGroup='" + strWcfGroup + "'");
            List<string> lstInfo = new List<string>();
            if (lstWcfConfigInfo.Count == 1)
            {
                lstInfo.Add(lstWcfConfigInfo[0].EnpointBindUrl);
                return lstInfo;
            }
            string[] strArray = new string[100];
            foreach (WcfConfigInfo item in lstWcfConfigInfo)
            {
                int intPercentage;
                if (int.TryParse(item.Percentage.ToString(), out intPercentage) == false)
                {
                    throw new Exception("百分比输入不合法，请输入整数");
                }
                for (int i = 0; i < intPercentage; i++)
                {
                    lstInfo.Add(item.EnpointBindUrl.TrimEnd('/') + "/" + item.WcfServiceClassName);
                }
            }
            RandomList.Random(ref lstInfo);
            Services = lstInfo;
            return lstInfo;
        }


        public static string ReturnOneService(string strWcfGroup)
        {
            if (Services == null || Services.Count == 0)
            {
                GenServiceArrayByPercentage(strWcfGroup);
            }
            Random ran = new Random();
            int intRan = ran.Next(0, Services.Count-1);
            return Services[intRan];
        }

    }
}
