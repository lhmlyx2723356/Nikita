using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using NVelocity.Runtime;
using System.IO;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    /// <summary>
    ///     NVelocity模板工具类 NVelocityHelper
    /// </summary>
    internal class NVelocityHelper
    {
        private IContext m_context;
        private VelocityEngine m_velocity;

        /// <summary>
        ///     给模板变量赋值
        /// </summary>
        /// <param name="key">模板变量</param>
        /// <param name="value">模板变量值</param>
        public void Add(string key, object value)
        {
            if (m_context == null)
                m_context = new VelocityContext();
            m_context.Put(key, value);
        }

        public string GetStringFromSource(string strSource)
        {
            var writer = new StringWriter();
            m_velocity.Evaluate(m_context, writer, "log", strSource);
            //输出
            var retValue = writer.GetStringBuilder().ToString();
            writer.Flush();
            writer.Close();
            writer.Dispose();
            return retValue;
        }

        /// <summary>
        ///     通过获得模板文件生成结果字符串
        /// </summary>
        /// <param name="strTemplateFileName">模板文件名，为从模板目录开始的完整路径。即相对路径。如cms/news_view.htm</param>
        public string GetStringFromVm(string strTemplateFileName)
        {
            //从文件中读取模板
            var template = m_velocity.GetTemplate(strTemplateFileName);
            //合并模板
            var writer = new StringWriter();
            template.Merge(m_context, writer);
            //输出
            var retValue = writer.GetStringBuilder().ToString();
            writer.Flush();
            writer.Close();
            writer.Dispose();
            return retValue;
        }

        #region 构造函数及初始化函数

        /// <summary>
        ///     无参数构造函数
        /// </summary>
        public NVelocityHelper()
        {
            Init();
        }

        /// <summary>
        ///     初始化NVelocity模块
        /// </summary>
        private void Init()
        {
            //创建VelocityEngine实例对象
            m_velocity = new VelocityEngine();

            //使用设置初始化VelocityEngine
            var props = new ExtendedProperties();
            props.AddProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, Application.StartupPath + "\\Template");
            props.AddProperty(RuntimeConstants.INPUT_ENCODING, "gb2312");
            props.AddProperty(RuntimeConstants.OUTPUT_ENCODING, "gb2312");
            m_velocity.Init(props);

            //为模板变量赋值
            m_context = new VelocityContext();
        }

        #endregion 构造函数及初始化函数

        #region 静态封装

        private static NVelocityHelper _ve;

        /// <summary>
        ///     静态模板类
        /// </summary>
        public static NVelocityHelper Nve
        {
            get { return _ve ?? (_ve = new NVelocityHelper()); }
        }

        /// <summary>
        ///     通过获得模板文件生成结果字符串(静态方法）
        /// </summary>
        /// <param name="strTemplateFileName"></param>
        /// <returns>模板文件名，包括相对路径。如cms/news_view.htm</returns>
        public static string GetStringFromVmStatic(string strTemplateFileName)
        {
            return _ve.GetStringFromVm(strTemplateFileName);
        }

        /// <summary>
        ///     生成字符串内容
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public string GetStringFromSourceStatic(string strSource)
        {
            return _ve.GetStringFromSource(strSource);
        }

        #endregion 静态封装
    }
}