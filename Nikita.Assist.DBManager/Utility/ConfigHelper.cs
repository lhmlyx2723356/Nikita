using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace Nikita.Assist.DBManager
{
    public class ConfigHelper
    {
 
        /// <summary>获取所有配置文件(AppSettings)
        ///
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAppSettings()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
                dict.Add(key, ConfigurationManager.AppSettings[key]);
            return dict;
        }

 
        /// <summary>根据键值获取配置文件
        ///
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetConfig(string key, string defaultValue)
        {
            string val = defaultValue;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                val = ConfigurationManager.AppSettings[key];
            return val ?? (defaultValue);
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
            //方法二
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //return config.AppSettings.Settings[SetKey].Value.ToString();
        }
       
        /// <summary>设置当前运行项目所对应的config里的Setting里Key为'SetKey'
        /// 所对应的value值
        /// </summary>
        /// <param name="strSetKey">App.config里设置的key值</param>
        /// <param name="strNewValue">设置后的Value值</param>
        /// <returns></returns>
        public static void SetConfigKeyValue(string strSetKey, string strNewValue)
        { 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[strSetKey].Value = strNewValue;
            config.Save();
        }

        /// <summary>获取当前运行项目所对应的config信息
        ///
        /// </summary>
        /// <returns></returns>
        public static string GetConfig(string connStr)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.ConnectionStrings.ConnectionStrings[connStr].ConnectionString;
        }

    }
}