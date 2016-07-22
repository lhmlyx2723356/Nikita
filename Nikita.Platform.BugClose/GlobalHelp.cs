using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.Define; 
using Autofac; 
using Nikita.Core.Autofac;
namespace Nikita.Platform.BugClose
{
    public class GlobalHelp
    {
        public static string Conn = "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=BugClose";
        private static Dictionary<string, object> m_dicResolve = new Dictionary<string, object>();

        public static Autofac.IContainer Container
        {
            get;
            set;
        }
         

        public static T GetResolve<T>()
        {
            if (m_dicResolve.ContainsKey(typeof(T).FullName))
            {
                return (T)m_dicResolve[typeof(T).FullName];
            }
            IocResolver iocResolver = new IocResolver(Container);
            T it = iocResolver.Resolve<T>();
            m_dicResolve.Add(typeof(T).FullName, it);
            return it;
        }


    }
}
