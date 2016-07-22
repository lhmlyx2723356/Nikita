using Nikita.Base.DbSchemaReader.DataSchema;
using System.Collections.Generic;
using System.Data;

namespace Nikita.Assist.DBManager
{
    public class ServerTag
    {
        /// <summary>服务器下所有数据库结构
        /// 服务器下所有数据库结构
        /// </summary>
        public Dictionary<string, DatabaseSchema> AllDatabaseSchema
        {
            get;
            set;
        }

        public SqlType DBType
        {
            get;
            set;
        }

        public string MasterConn
        {
            get;
            set;
        }

        /// <summary>服务器登录端口号
        /// 服务器登录端口号
        /// </summary>
        public string Port
        {
            get;
            set;
        }

        /// <summary>服务器登录密码
        /// 服务器登录密码
        /// </summary>
        public string PWD
        {
            get;
            set;
        }

        /// <summary>服务器名称
        /// 服务器名称
        /// </summary>
        public string Server
        {
            get;
            set;
        }

        /// <summary>服务器下所有数据库名集合表
        /// 服务器下所有数据库名集合表
        /// </summary>
        public DataTable ServerDBNames
        {
            get;
            set;
        }

        /// <summary>服务器登录名
        /// 服务器登录名
        /// </summary>
        public string UID
        {
            get;
            set;
        }

        /// <summary>加载类型
        /// 加载类型
        /// </summary>
        public List<string>  LoadType
        {
            get;
            set;
        }
    }
}