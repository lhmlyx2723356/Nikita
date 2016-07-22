using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
  public class BasicParameter
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get;
            set;
        }

        /// <summary>类名
        ///
        /// </summary>
        public string ClassName
        {
            get;
            set;
        }

        /// <summary>数据库连接字符串
        ///
        /// </summary>
        public string Conn
        {
            get;
            set;
        }

        /// <summary>命名空间
        /// 命名空间
        /// </summary>
        public string NameSpace
        {
            get;
            set;
        }

        /// <summary>代码生成路径
        ///
        /// </summary>
        public string OutFolderPath
        {
            get;
            set;
        }

        /// <summary>表名
        ///
        /// </summary>
        public string TableName
        {
            get;
            set;
        }

        /// <summary>
        /// 表名前缀
        /// </summary>
        public  string  TablePrefix
        {
            get;
            set;
        }
    }
}