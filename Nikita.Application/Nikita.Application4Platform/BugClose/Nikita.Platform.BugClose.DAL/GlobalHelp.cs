using Nikita.Base.ConnectionManager;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Platform.BugClose.DAL
{
    public class GlobalHelp
    {
        public static string Conn = ConfigConnection.BugCloseConnection;
        public static SqlType SqlType = SqlType.SqlServer;
        private static readonly object SyncObject = new object();
        private static IDbHelper _dbHelper;

        public static IDbHelper GetDataAccessHelper()
        {
            if (_dbHelper != null) return _dbHelper;
            lock (SyncObject)
            {
                if (_dbHelper == null)
                {
                    _dbHelper = DbHelper.GetDbHelper(SqlType, Conn);
                }
            }
            return _dbHelper;
        }
    }
}
