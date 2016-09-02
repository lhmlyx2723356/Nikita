using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.ConnectionManager;
using Nikita.DataAccess4DBHelper;
using  Nikita.Base.Define;
 

namespace Nikita.Assist.CodeMaker.CodeMakerDemoForm
{
    public class GlobalHelpDemoForm
    {
        public static string DemoConn = ConfigConnection.CodeMgrDemoConnection;
        public static string DemoConn1 = ConfigConnection.BPMDemoConnection; 
        public static SqlType SqlType = SqlType.SqlServer;

        private static readonly object SyncObject = new object();
        private static Nikita.DataAccess4DBHelper.IDbHelper _dbHelper;

        public static Nikita.DataAccess4DBHelper.IDbHelper GetDataAccessHelper()
        {
            if (_dbHelper == null)
            {
                lock (SyncObject)
                {
                    if (_dbHelper == null)
                    {
                        _dbHelper = DbHelper.GetDbHelper(SqlType, DemoConn); 
                    }
                }
            }
            return _dbHelper; 
        }


        public static Nikita.DataAccess4DBHelper.IDbHelper GetDataAccessHelperDemo()
        {
            if (_dbHelper == null)
            {
                lock (SyncObject)
                {
                    if (_dbHelper == null)
                    {
                        _dbHelper = DbHelper.GetDbHelper(SqlType, DemoConn1);
                    }
                }
            }
            return _dbHelper;
        }
    }
}
