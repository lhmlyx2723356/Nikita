using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Core;

namespace Nikita.Base.ConnectionManager
{
   public class SQLiteConfigConnection
    {
        public  static string CodeMakerDBConnection= "Data Source=" + Application.StartupPath + "\\Database\\CodeMakerDB.db";

        public static string DatabaseManagerDBConnection = "Data Source=" + Application.StartupPath + "\\Database\\DataBaseManagerDB.db ; Pooling=true;FailIfMissing=false";
         

        public static string SynchronizationDBConnection = "Data Source=" + Application.StartupPath + "\\Database\\SynchronizationDB.db; Pooling=true;FailIfMissing=false";

        public static string EmailLocalDBConnection = "Data Source=" + Application.StartupPath + "\\EmailLocalDB.db";

        public static string LogLocalDBConnection = "Data Source=" + Application.StartupPath + "\\LogLocalDB.db ; Pooling=true;FailIfMissing=false" ;

        public  static string CacheStoreDBConnection=  "Data Source=" +  Application.StartupPath + "\\Database\\CacheStore.db ; Pooling=true;FailIfMissing=false";
    }
}
