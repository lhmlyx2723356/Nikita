using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nikita.Core
{
    public class ConfigHelper
    {
        /// <summary>获取所有配置文件(AppSettings)
        ///
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAppSettings()
        {
            return ConfigurationManager.AppSettings.AllKeys.ToDictionary(key => key, key => ConfigurationManager.AppSettings[key]);
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
        /// <param name="setKey">App.config里设置的key值</param>
        /// <returns></returns>
        public static string GetConfigKeyValue(string setKey)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(setKey))
            {
                val = ConfigurationManager.AppSettings[setKey];
            }
            return val;
            //方法二
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //return config.AppSettings.Settings[SetKey].Value.ToString();
        }
    }
}