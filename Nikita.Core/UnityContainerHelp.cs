using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Nikita.Core
{
    public class UnityContainerHelp
    {
        private readonly IUnityContainer _container;
        public UnityContainerHelp()
        {
              
            // section.Containers["containerOne"].Configure(container);
            _container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //container.LoadConfiguration(section, "containerOne");

            section.Configure(_container, "containerOne"); 
        }

        public T GetServer<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configName">配置文件中指定的文字</param>
        /// <returns></returns>
        public T GetServer<T>(string configName)
        {
            return _container.Resolve<T>(configName);
        }
        /// <summary>
        /// 返回构结函数带参数
        /// </summary>
        /// <typeparam name="T">依赖对象</typeparam>
        /// <param name="parameterList">参数集合（参数名，参数值）</param>
        /// <returns></returns>
        public T GetServer<T>(Dictionary<string, object> parameterList)
        {
            var list = new ParameterOverrides();
            foreach (var item in parameterList)
            {
                list.Add(item.Key, item.Value);
            }
            return _container.Resolve<T>(list);
        }
        /// <summary>
        /// 返回构结函数带参数
        /// </summary>
        /// <typeparam name="T">依赖对象</typeparam>
        /// <param name="configName">配置文件中指定的文字(没写会报异常)</param>
        /// <param name="parameterList">参数集合（参数名，参数值）</param>
        /// <returns></returns>
        public T GetServer<T>(string configName,Dictionary<string,object> parameterList)
        {
            var list = new ParameterOverrides();
            foreach (var item in parameterList) 
            {
                list.Add(item.Key, item.Value);
            }
            return _container.Resolve<T>(configName,list);
        }
    }
}
