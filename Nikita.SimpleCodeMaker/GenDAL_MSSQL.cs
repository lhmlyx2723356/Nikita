using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Nikita.Assist.SimpleCodeMaker
{
    public class GenDAL_MSSQL
    {
        /// <summary>生成DAL代码
        /// 基于微软企业库
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tabname">表名</param>
        /// <param name="classname">类名</param>
        /// <param name="connstr">数据库连接字符串</param>
        /// <returns></returns>
        public static string GenAllCode(string ns, string tabname, string classname, string connstr)
        {
            #region 生成DAL代码
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string sql = "";
            sql += "SELECT a.[name] as '字段名',c.[name] '类型',e.value as '字段说明',sm.text as '默认值' FROM syscolumns  a  ";
            sql += "left   join    systypes    b   on      a.xusertype=b.xusertype ";
            sql += "left 	join 	systypes 	c 	on  	a.xtype = c.xusertype ";
            sql += "inner   join   sysobjects  d   on      a.id=d.id     and   d.xtype='U' ";
            sql += "left join syscomments sm on a.cdefault=sm.id ";
            sql += "left join sys.extended_properties e on a.id = e.major_id and a.colid = e.minor_id and ";
            sql += "e.name='MS_Description' where d.name='" + tabname + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            conn.Close();

            string tmp1 = ""; // 字段1,字段2,字段3,....
            string tmp2 = ""; // @字段1,@字段2,@字段3,....
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (row["字段名"].ToString() == "id")
                {
                    continue;
                }
                if (i == dt.Rows.Count - 1)
                {
                    tmp1 += row["字段名"].ToString() + " ";
                    tmp2 += "@" + row["字段名"].ToString() + " ";
                }
                else
                {
                    tmp1 += row["字段名"].ToString() + ", ";
                    tmp2 += "@" + row["字段名"].ToString() + ", ";
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("using System;\r\n");
            sb.Append("using System.Data;\r\n");
            sb.Append("using System.Text;\r\n");
            sb.Append("using System.Collections.Generic;\r\n");
            sb.Append("using Microsoft.Practices.EnterpriseLibrary.Data;\r\n");
            sb.Append("using Microsoft.Practices.EnterpriseLibrary.Data.Sql;\r\n");
            sb.Append("using System.Data.Common;\r\n");
            sb.Append("namespace " + ns + ".DAL\r\n");
            sb.Append("{\r\n");
            sb.Append("    /// <summary>" + tabname + "表数据访问类\r\n");
            sb.Append("    /// 作者:\r\n");
            sb.Append("    /// 创建时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            sb.Append("    /// </summary>\r\n");
            sb.Append("    public partial class " + classname + "DAL\r\n");
            sb.Append("    {\r\n");
            sb.Append("        public " + classname + "DAL()\r\n");
            sb.Append("        { }\r\n");

            #region Add方法
            sb.Append("        /// <summary>增加一条数据\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public int Add(" + ns + ".Model." + classname + " model)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"insert into " + tabname + "(\");\r\n");
            sb.Append("            strSql.Append(\"" + tmp1 + ")\");\r\n");
            sb.Append("            strSql.Append(\" values (\");\r\n");
            sb.Append("            strSql.Append(\"" + tmp2 + ")\");\r\n");
            sb.Append("            strSql.Append(\";select @@IDENTITY\");\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());\r\n");

            foreach (DataRow row in dt.Rows)
            {
                if (row["字段名"].ToString() == "id")
                {
                    continue;
                }
                sb.Append("            db.AddInParameter(dbCommand, \"" + row["字段名"] + "\", DbType." + Tools.DbTypeToCSharpDbType(row["类型"].ToString()) + ", model." + row["字段名"] + ");\r\n");
            }

            sb.Append("            int result;\r\n");
            sb.Append("            object obj = db.ExecuteScalar(dbCommand);\r\n");
            sb.Append("            if (!int.TryParse(obj.ToString(), out result))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return 0;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return result;\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region Update方法
            string tmp3 = ""; // 字段1=@字段1, 字段2=@字段2, .....
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (row["字段名"].ToString() == "id")
                {
                    continue;
                }
                if (i == dt.Rows.Count - 1)
                {
                    tmp3 += row["字段名"].ToString() + "=@" + row["字段名"].ToString() + " ";
                }
                else
                {
                    tmp3 += row["字段名"].ToString() + "=@" + row["字段名"].ToString() + ", ";
                }
            }

            sb.Append("        /// <summary>更新一条数据\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public bool Update(" + ns + ".Model." + classname + " model)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"update " + tabname + " set \");\r\n");
            sb.Append("            strSql.Append(\"" + tmp3 + "\");\r\n");
            sb.Append("            strSql.Append(\" where id=@id \");\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());\r\n");

            foreach (DataRow row in dt.Rows)
            {
                sb.Append("            db.AddInParameter(dbCommand, \"" + row["字段名"] + "\", DbType." + Tools.DbTypeToCSharpDbType(row["类型"].ToString()) + ", model." + row["字段名"] + ");\r\n");
            }

            sb.Append("            int rows = db.ExecuteNonQuery(dbCommand);\r\n");
            sb.Append("            if (rows > 0)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return true;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            else\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return false;\r\n");
            sb.Append("            }\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region Delete方法
            sb.Append("        /// <summary>删除一条数据\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public bool Delete(int id)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"delete from " + tabname + " \");\r\n");
            sb.Append("            strSql.Append(\" where id=@id \");\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"id\", DbType.Int32, id);\r\n");
            sb.Append("            int rows = db.ExecuteNonQuery(dbCommand);\r\n");
            sb.Append("            if (rows > 0)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return true;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            else\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return false;\r\n");
            sb.Append("            }\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region DeleteByCond方法
            sb.Append("        /// <summary>根据条件删除数据\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public bool DeleteByCond(string cond)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"delete from " + tabname + " \");\r\n");
            sb.Append("            if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                strSql.Append(\" where \" + cond);\r\n");
            sb.Append("            }\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());\r\n");
            sb.Append("            int rows = db.ExecuteNonQuery(dbCommand);\r\n");
            sb.Append("            if (rows > 0)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return true;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            else\r\n");
            sb.Append("            {\r\n");
            sb.Append("                return false;\r\n");
            sb.Append("            }\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region GetModel方法
            sb.Append("        /// <summary>得到一个对象实体\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public " + ns + ".Model." + classname + " GetModel(int id)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"select * from " + tabname + " \");\r\n");
            sb.Append("            strSql.Append(\" where id=@id \");\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"id\", DbType.Int32, id);\r\n");
            sb.Append("            " + ns + ".Model." + classname + " model = null;\r\n");
            sb.Append("            using (IDataReader dataReader = db.ExecuteReader(dbCommand))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                if (dataReader.Read())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    model = ReaderBind(dataReader);\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return model;\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region GetModelByCond方法
            sb.Append("        /// <summary>根据条件得到一个对象实体\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public " + ns + ".Model." + classname + " GetModelByCond(string cond)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"select top 1 * from " + tabname + " \");\r\n");
            sb.Append("            if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                strSql.Append(\" where \" + cond);\r\n");
            sb.Append("            }\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());\r\n");
            sb.Append("            " + ns + ".Model." + classname + " model = null;\r\n");
            sb.Append("            using (IDataReader dataReader = db.ExecuteReader(dbCommand))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                if (dataReader.Read())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    model = ReaderBind(dataReader);\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return model;\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region GetList方法
            sb.Append("        /// <summary>获得数据列表\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public DataSet GetList(string strWhere)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"select * \");\r\n");
            sb.Append("            strSql.Append(\" FROM " + tabname + " \");\r\n");
            sb.Append("            if (strWhere.Trim() != \"\")\r\n");
            sb.Append("            {\r\n");
            sb.Append("                strSql.Append(\" where \" + strWhere);\r\n");
            sb.Append("            }\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region GetList分页方法
            sb.Append("        /// <summary>分页获取数据列表\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public DataSet GetList(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetStoredProcCommand(\"[proc_SplitPage]\");\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@tblName\", DbType.AnsiString, \"" + tabname + "\");\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strFields\", DbType.AnsiString, fileds);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strOrder\", DbType.AnsiString, order);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strOrderType\", DbType.AnsiString, ordertype);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@PageSize\", DbType.Int32, PageSize);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@PageIndex\", DbType.Int32, PageIndex);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strWhere\", DbType.AnsiString, strWhere);\r\n");
            sb.Append("            return db.ExecuteDataSet(dbCommand);\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region GetListArray方法
            sb.Append("        /// <summary>获得数据列表（比DataSet效率高，推荐使用）\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public List<" + ns + ".Model." + classname + "> GetListArray(string strWhere)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("            strSql.Append(\"select * \");\r\n");
            sb.Append("            strSql.Append(\" FROM " + tabname + " \");\r\n");
            sb.Append("            if (strWhere.Trim() != \"\")\r\n");
            sb.Append("            {\r\n");
            sb.Append("                strSql.Append(\" where \" + strWhere);\r\n");
            sb.Append("            }\r\n");
            sb.Append("            List<" + ns + ".Model." + classname + "> list = new List<" + ns + ".Model." + classname + ">();\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                while (dataReader.Read())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    list.Add(ReaderBind(dataReader));\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return list;\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region GetListArray分页方法
            sb.Append("        /// <summary>分页获取数据列表\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public List<" + ns + ".Model." + classname + "> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            DbCommand dbCommand = db.GetStoredProcCommand(\"[proc_SplitPage]\");\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@tblName\", DbType.AnsiString, \"" + tabname + "\");\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strFields\", DbType.AnsiString, fileds);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strOrder\", DbType.AnsiString, order);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strOrderType\", DbType.AnsiString, ordertype);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@PageSize\", DbType.Int32, PageSize);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@PageIndex\", DbType.Int32, PageIndex);\r\n");
            sb.Append("            db.AddInParameter(dbCommand, \"@strWhere\", DbType.AnsiString, strWhere);\r\n");
            sb.Append("            List<" + ns + ".Model." + classname + "> list = new List<" + ns + ".Model." + classname + ">();\r\n");
            sb.Append("            using (IDataReader dataReader = db.ExecuteReader(dbCommand))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                while (dataReader.Read())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    list.Add(ReaderBind(dataReader));\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return list;\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region ReaderBind方法
            sb.Append("        /// <summary>对象实体绑定数据\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public " + ns + ".Model." + classname + " ReaderBind(IDataReader dataReader)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            " + ns + ".Model." + classname + " model = new " + ns + ".Model." + classname + "();\r\n");
            sb.Append("            object ojb;\r\n");

            foreach (DataRow row in dt.Rows)
            {
                if (row["类型"].ToString().Contains("char") || row["类型"].ToString().Contains("text"))
                {
                    sb.Append("            model." + row["字段名"] + " = dataReader[\"" + row["字段名"] + "\"].ToString();\r\n");
                }
                else
                {
                    sb.Append("            ojb = dataReader[\"" + row["字段名"] + "\"];\r\n");
                    sb.Append("            if (ojb != null && ojb != DBNull.Value)\r\n");
                    sb.Append("            {\r\n");
                    sb.Append("                model." + row["字段名"] + " = " + Tools.DbTypeToCSharpType(row["类型"].ToString(), "0") + ".Parse(ojb.ToString());\r\n");
                    sb.Append("            }\r\n");
                }
            }

            sb.Append("            return model;\r\n");
            sb.Append("        }\r\n\r\n");
            #endregion

            #region CalcCount方法
            sb.Append("        /// <summary>计算记录数\r\n");
            sb.Append("        /// \r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <param name=\"p\"></param>\r\n");
            sb.Append("        /// <returns></returns>\r\n");
            sb.Append("        public int CalcCount(string cond)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            string sql = \"select count(1) from " + tabname + "\";\r\n");
            sb.Append("            if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                sql += \" where \" + cond;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            Database db = DatabaseFactory.CreateDatabase();\r\n");
            sb.Append("            return int.Parse(db.ExecuteScalar(CommandType.Text, sql).ToString());\r\n");
            sb.Append("        }\r\n");
            sb.Append("    }\r\n");
            sb.Append("}\r\n\r\n");
            #endregion

            return sb.ToString();
            #endregion
        }
    }
}
