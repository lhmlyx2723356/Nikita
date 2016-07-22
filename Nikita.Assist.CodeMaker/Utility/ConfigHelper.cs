using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace Nikita.Assist.CodeMaker
{
    public class ConfigHelper
    {
        /// <summary>对Config进行写操作
        ///
        /// </summary>
        /// <param name="strExecutablePath">运行项目路径</param>
        /// <param name="AppKey">设置项</param>
        /// <param name="AppValue">设置值</param>
        public static void ConfigSetValue(string strExecutablePath, string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();
            //获取可执行文件的路径和名称
            xDoc.Load(strExecutablePath + ".config");
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//connectionStrings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@name='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("connectionString", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("name", AppKey);
                xElem2.SetAttribute("connectionString", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(strExecutablePath + ".config");
        }

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
            if (val == null)
                val = defaultValue;
            return val;
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

        /// <summary>对本地项目代码的Config进行写操作
        ///
        /// </summary>
        /// <param name="strExecutablePath">本地项目路径</param>
        /// <param name="AppKey">设置项</param>
        /// <param name="AppValue">设置值</param>
        public static void LocalConfigSetValue(string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();
            //获取可执行文件的路径和名称
            string strExecutablePath = System.Windows.Forms.Application.ExecutablePath.Substring(0, System.Windows.Forms.Application.ExecutablePath.LastIndexOf("bin")) + "App.config";
            xDoc.Load(strExecutablePath);
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//connectionStrings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@name='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("connectionString", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("name", AppKey);
                xElem2.SetAttribute("connectionString", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(strExecutablePath + ".config");
        }

        /// <summary>写配置文件,如果节点不存在则自动创建(AppSettings)
        ///
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool SetConfig(string key, string value)
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (!conf.AppSettings.Settings.AllKeys.Contains(key))
                    conf.AppSettings.Settings.Add(key, value);
                else
                    conf.AppSettings.Settings[key].Value = value;
                conf.Save();
                return true;
            }
            catch { return false; }
        }

        /// <summary>写配置文件(用键值创建),如果节点不存在则自动创建
        ///
        /// </summary>
        /// <param name="dict">键值集合</param>
        /// <returns></returns>
        public static bool SetConfig(Dictionary<string, string> dict)
        {
            try
            {
                if (dict == null || dict.Count == 0)
                    return false;
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                foreach (string key in dict.Keys)
                {
                    if (!conf.AppSettings.Settings.AllKeys.Contains(key))
                        conf.AppSettings.Settings.Add(key, dict[key]);
                    else
                        conf.AppSettings.Settings[key].Value = dict[key];
                }
                conf.Save();
                return true;
            }
            catch { return false; }
        }

        /// <summary>设置当前运行项目所对应的config里的Setting里Key为'SetKey'
        /// 所对应的value值
        /// </summary>
        /// <param name="SetKey">App.config里设置的key值</param>
        /// <param name="SetKey">设置后的Value值</param>
        /// <returns></returns>
        public static void SetConfigKeyValue(string SetKey, string NewValue)
        {
            //ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings.AllKeys.Contains(SetKey))
            {
                ConfigurationManager.AppSettings.Set(SetKey, NewValue);
            }
            else
            {
                ConfigurationManager.AppSettings.Add(SetKey, NewValue);
            }
        }
    }
}