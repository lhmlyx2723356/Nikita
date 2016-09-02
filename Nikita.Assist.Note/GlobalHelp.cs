using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Nikita.Base.Define; 
using Nikita.Base.Autofac;
using Nikita.Base.ConnectionManager;


namespace Nikita.Assist.Note
{
    public class GlobalHelp
    {
        public static string Conn = ConfigConnection.NotePadConnection; 
        private static readonly object SyncObject = new object(); 
        private static Dictionary<string, object> m_dicResolve = new Dictionary<string, object>();

        internal static Autofac.IContainer Container
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
