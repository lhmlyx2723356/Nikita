using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Nikita.Base.Define; 
using Nikita.DataAccess4DBHelper;
using System.Windows.Forms;
using Nikita.Base.ConnectionManager;


namespace Nikita.Base.Aop
{
    public class GlobalHelp
    {
        internal static readonly string CacheStoreConn = SQLiteConfigConnection.CacheStoreDBConnection;
        private static readonly object SyncObject = new object();
        //private static readonly Dictionary<string, object> m_dicResolve = new Dictionary<string, object>();  
        private static IDbHelper _dbHelperSqlite;
         

        internal static IDbHelper GetDataAccessSqliteHelper()
        {
            if (_dbHelperSqlite == null)
            {
                lock (SyncObject)
                {
                    if (_dbHelperSqlite == null)
                    {
                        _dbHelperSqlite = DbHelper.GetDbHelper(SqlType.SQLite, CacheStoreConn);
                    }
                }
            }
            return _dbHelperSqlite;
        }


        //private static IContainer container;
        //internal static IContainer Container
        //{
        //    get {

        //        if (container == null)
        //        {
        //            var builder = new ContainerBuilder();
        //            var assembly2 = Assembly.LoadFile(Application.StartupPath + "\\Nikita.Base.CacheStore.dll"); 
        //            builder.RegisterAssemblyTypes(assembly2).AsImplementedInterfaces();
        //            container = builder.Build();
        //        }
        //        return container;
        //    } 
        //}

        //internal static T GetResolve<T>()
        //{
        //    if (m_dicResolve.ContainsKey(typeof(T).FullName))
        //    {
        //        return (T)m_dicResolve[typeof(T).FullName];
        //    }
        //    IocResolver iocResolver = new IocResolver(Container);
        //    T it = iocResolver.Resolve<T>();
        //    m_dicResolve.Add(typeof(T).FullName, it);
        //    return it;
        //}
    }
}
