using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public class DalMakerManager
    {
        /// <summary>获取DalMaker对象
        ///
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>DalMaker对象</returns>
        public static IDalMaker GetDalMaker(SqlType dbType)
        {
            IDalMaker maker = null;
            switch (dbType)
            {
                case SqlType.MySql:
                    maker = new GenDalMySQL();
                    break;

                case SqlType.SqlServer:
                    maker = new GenDalMSSQL();
                    break;

                case SqlType.SQLite:
                    maker = new GenDalSQLite();
                    break;

                case SqlType.Accesss:
                    maker = new GenDalAccess();
                    break;
            }
            return maker;
        }
    }
}