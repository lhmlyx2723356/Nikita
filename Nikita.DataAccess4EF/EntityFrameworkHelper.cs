using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.DataAccess4EF
{
    public class EntityFrameworkHelper
    {
        public static IBseDbHelper GetEntityFrameworkHelper(string strConn, string DbType)
        { 
            IBseDbHelper helper = null;
            if (DbType=="SQLite")
            {
                  helper = new SQLiteEntityFrameworkHelper(strConn);
            }
            else if (DbType == "SqlServer")
            { 
                helper = new SqlServerEntityFrameworkHelper(strConn);
            }
            return helper;
        }
    }
}
