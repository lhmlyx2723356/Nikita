using Nikita.Base.DbSchemaReader.DataSchema;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.DataAccess4DBHelper;
using Nikita.WinForm.ExtendControl; 

namespace Nikita.Assist.CodeMaker
{
    public static class GlobalHelp
    {
        public static string CodeMakerSettingConn = "Data Source=" + Application.StartupPath + "\\Database\\CodeMakerDB.db";

        public static DockPanel DockPanel
        {
            get;
            set;
        }

        public static TreeView TreeView
        {
            get;
            set;
        }

        private static readonly object SyncObject = new object();
        private static Bse_UIDAL _bseUidal;
        private static Bse_ControlTypeDAL _bseControlTypeDal;

        public static Bse_UIDAL GetUiHelper()
        {
            if (_bseUidal == null)
            {
                lock (SyncObject)
                {
                    if (_bseUidal == null)
                    {
                        _bseUidal = new Bse_UIDAL();
                    }
                }
            }
            return _bseUidal;
        }

        public static Bse_ControlTypeDAL GetControlTypeHelper()
        {
            if (_bseControlTypeDal == null)
            {
                lock (SyncObject)
                {
                    if (_bseControlTypeDal == null)
                    {
                        _bseControlTypeDal = new Bse_ControlTypeDAL();
                    }
                }
            }
            return _bseControlTypeDal;
        }



        private static SQLiteHelper _sqliteHelper;
        public static SQLiteHelper GetSQLiteHelper()
        {
            if (_sqliteHelper == null)
            {
                lock (SyncObject)
                {
                    if (_sqliteHelper == null)
                    {
                        _sqliteHelper = new SQLiteHelper(CodeMakerSettingConn);
                    }
                }
            }
            return _sqliteHelper;
        }

    }
}