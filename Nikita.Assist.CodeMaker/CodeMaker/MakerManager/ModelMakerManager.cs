using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public class ModelMakerManager
    {
        /// <summary>获取ModelMaker对象
        ///
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>ModelMaker对象</returns>
        public static IModelMaker GetModelMaker(SqlType dbType)
        {
            IModelMaker maker = null;
            switch (dbType)
            {
                case SqlType.MySql:
                    maker = new GenModelMySql();
                    break;

                case SqlType.SqlServer:
                    maker = new GenModelMssql();
                    break;

                case SqlType.SQLite:
                    maker = new GenModelSqLite();
                    break;

                case SqlType.Accesss:
                    maker = new GenModelAccess();
                    break;
            }
            return maker;
        }
    }
}