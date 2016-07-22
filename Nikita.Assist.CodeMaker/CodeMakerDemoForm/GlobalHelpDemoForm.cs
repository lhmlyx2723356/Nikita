using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.DataAccess4DBHelper;
using  Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker.CodeMakerDemoForm
{
    public class GlobalHelpDemoForm
    {
        public static string DemoConn = "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=CodeMgr";
        public static string DemoConn1 = "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=BPM";
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
