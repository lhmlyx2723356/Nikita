using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    internal class GenModelMssql : IModelMaker
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
            #region 生成MODEL代码

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

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sql = "";
            sql += "SELECT a.[name] as '字段名',c.[name] '类型',e.value as '字段说明',sm.text as '默认值',a.isnullable as '是否为空' FROM syscolumns  a  ";
            sql += "left   join    systypes    b   on      a.xusertype=b.xusertype ";
            sql += "left 	join 	systypes 	c 	on  	a.xtype = c.xusertype ";
            sql += "inner   join   sysobjects  d   on      a.id=d.id     and   d.xtype='U' ";
            sql += "left join syscomments sm on a.cdefault=sm.id ";
            sql += "left join sys.extended_properties e on a.id = e.major_id and a.colid = e.minor_id and ";
            sql += "e.name='MS_Description' where d.name='" + strTableName + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                sb.Append("		private " + Tools.DbTypeToCSharpType(sdr["类型"].ToString(), sdr["是否为空"].ToString()) + " _" + sdr["字段名"] + " " + Tools.DbDefaultToCSharp(sdr["默认值"].ToString(), sdr["类型"].ToString()) + ";\r\n");
                sb.Append("		/// <summary>" + sdr["字段说明"] + "\r\n");
                sb.Append("		/// \r\n");
                sb.Append("		/// </summary>\r\n");
                sb.Append("		public " + Tools.DbTypeToCSharpType(sdr["类型"].ToString(), sdr["是否为空"].ToString()) + " " + sdr["字段名"] + "\r\n");
                sb.Append("		{\r\n");
                sb.Append("			set{ _" + sdr["字段名"] + "=value;}\r\n");
                sb.Append("			get{return _" + sdr["字段名"] + ";}\r\n");
                sb.Append("		}\r\n");
            }
            conn.Close();
            sb.Append("	}\r\n");
            sb.Append("}\r\n");
            return sb.ToString();

            #endregion 生成MODEL代码
        }
    }
}