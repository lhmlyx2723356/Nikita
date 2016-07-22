﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    /// <summary>Access数据库生成实体类的类
    ///
    /// </summary>
    internal class GenModelAccess : IModelMaker
    {
        ///  <summary>生成Model代码
        ///
        ///  </summary>
        ///  <param name="strNameSpace">命名空间</param>
        ///  <param name="strTableName">表名</param>
        ///  <param name="strClassName">类名</param>
        ///  <param name="strConn">数据库连接字符串</param>
        /// <param name="strAnthor">作者</param>
        /// <returns></returns>
        public string GenModelCode(string strNameSpace, string strTableName, string strClassName, string strConn, string strAnthor)
        {
            StringBuilder sb = new StringBuilder(); 
            sb.Append("using System;\r\n");
            sb.Append("namespace " + strNameSpace + ".Model\r\n");
            sb.Append("{\r\n");
            sb.Append("	/// <summary>" + strTableName + "表实体类\r\n");
            sb.Append("	/// 作者:" + strAnthor + "\r\n");
            sb.Append("	/// 创建时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            sb.Append("	/// </summary>\r\n");
            sb.Append("	[Serializable]\r\n");
            sb.Append("	public class " + strClassName + "\r\n");
            sb.Append("	{\r\n");
            sb.Append("		public " + strClassName + "()\r\n");
            sb.Append("		{}\r\n");

            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);

            if (dt != null)
            {
                var q = from a in dt.AsEnumerable()
                        where a.Field<string>("TABLE_NAME") == strTableName
                        orderby a.Field<Int64>("ORDINAL_POSITION")
                        select new
                        {
                            字段名 = a.Field<string>("COLUMN_NAME"),
                            类型 = a.Field<int>("DATA_TYPE"),
                            字段说明 = a.Field<string>("DESCRIPTION"),
                            默认值 = a.Field<string>("COLUMN_DEFAULT"),
                        };

                for (int i = 0; i < q.Count(); i++)
                {
                    var row = q.ElementAt(i);
                    sb.Append("		private " + Tools.DbTypeToCSharpType_Access(row.类型) + " _" + row.字段名 + " " + Tools.DbDefaultToCSharp_Access(row.默认值) + ";\r\n");
                    sb.Append("		/// <summary>" + row.字段说明 + "\r\n");
                    sb.Append("		/// \r\n");
                    sb.Append("		/// </summary>\r\n");
                    sb.Append("		public " + Tools.DbTypeToCSharpType_Access(row.类型) + " " + row.字段名 + "\r\n");
                    sb.Append("		{\r\n");
                    sb.Append("			set{ _" + row.字段名 + "=value;}\r\n");
                    sb.Append("			get{return _" + row.字段名 + ";}\r\n");
                    sb.Append("		}\r\n");
                }
            } 
            conn.Close(); 
            sb.Append("	}\r\n");
            sb.Append("}\r\n");

            return sb.ToString();
        }
    }
}