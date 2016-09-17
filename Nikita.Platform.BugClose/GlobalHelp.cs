using Nikita.Base.ConnectionManager;
using Nikita.Core.Autofac;
using System.Collections.Generic;

namespace Nikita.Platform.BugClose
{
    public class GlobalHelp
    {
        public static string Conn = ConfigConnection.BugCloseConnection;
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