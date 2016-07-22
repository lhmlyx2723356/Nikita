using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nikita.Assist.DBManager.DAL
{
    /// <summary>Bse_DataDictionary表数据访问类
    ///
    /// 创建时间:2015-12-14 20:34:53
    /// </summary>
    public partial class Bse_DataDictionaryDAL
    {
        public Bse_DataDictionaryDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Assist.DBManager.Model.Bse_DataDictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_DataDictionary(");
            strSql.Append("ServerName, DatabaseName, TableName, TableHistoryName, TableRemark, ColumnName, ColumnIdentity, ColumnPK, ColumnType, ColumnSpace, ColumnLength, ColumnScale, ColumnAllowNull, ColumnDefaultValue, ColumnRemark, ColumnHistory, DbType, OperationType, CreateUser, CreateTime, LastEditUser, LastEditTime, Status  )");
            strSql.Append(" values (");
            strSql.Append("@ServerName, @DatabaseName, @TableName, @TableHistoryName, @TableRemark, @ColumnName, @ColumnIdentity, @ColumnPK, @ColumnType, @ColumnSpace, @ColumnLength, @ColumnScale, @ColumnAllowNull, @ColumnDefaultValue, @ColumnRemark, @ColumnHistory, @DbType, @OperationType, @CreateUser, @CreateTime, @LastEditUser, @LastEditTime, @Status  )");
            strSql.Append(";select @@IDENTITY");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            if (model.ServerName == null)
            {
                h.AddParameter("@ServerName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ServerName", model.ServerName);
            }
            if (model.DatabaseName == null)
            {
                h.AddParameter("@DatabaseName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DatabaseName", model.DatabaseName);
            }
            if (model.TableName == null)
            {
                h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableName", model.TableName);
            }
            if (model.TableHistoryName == null)
            {
                h.AddParameter("@TableHistoryName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableHistoryName", model.TableHistoryName);
            }
            if (model.TableRemark == null)
            {
                h.AddParameter("@TableRemark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableRemark", model.TableRemark);
            }
            if (model.ColumnName == null)
            {
                h.AddParameter("@ColumnName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnName", model.ColumnName);
            }
            if (model.ColumnIdentity == null)
            {
                h.AddParameter("@ColumnIdentity", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnIdentity", model.ColumnIdentity);
            }
            if (model.ColumnPK == null)
            {
                h.AddParameter("@ColumnPK", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnPK", model.ColumnPK);
            }
            if (model.ColumnType == null)
            {
                h.AddParameter("@ColumnType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnType", model.ColumnType);
            }
            if (model.ColumnSpace == null)
            {
                h.AddParameter("@ColumnSpace", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnSpace", model.ColumnSpace);
            }
            if (model.ColumnLength == null)
            {
                h.AddParameter("@ColumnLength", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnLength", model.ColumnLength);
            }
            if (model.ColumnScale == null)
            {
                h.AddParameter("@ColumnScale", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnScale", model.ColumnScale);
            }
            if (model.ColumnAllowNull == null)
            {
                h.AddParameter("@ColumnAllowNull", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnAllowNull", model.ColumnAllowNull);
            }
            if (model.ColumnDefaultValue == null)
            {
                h.AddParameter("@ColumnDefaultValue", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnDefaultValue", model.ColumnDefaultValue);
            }
            if (model.ColumnRemark == null)
            {
                h.AddParameter("@ColumnRemark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnRemark", model.ColumnRemark);
            }
            if (model.ColumnHistory == null)
            {
                h.AddParameter("@ColumnHistory", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnHistory", model.ColumnHistory);
            }
            if (model.DbType == null)
            {
                h.AddParameter("@DbType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DbType", model.DbType);
            }
            if (model.OperationType == null)
            {
                h.AddParameter("@OperationType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@OperationType", model.OperationType);
            }
            if (model.CreateUser == null)
            {
                h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.CreateTime == null)
            {
                h.AddParameter("@CreateTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateTime", model.CreateTime);
            }
            if (model.LastEditUser == null)
            {
                h.AddParameter("@LastEditUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LastEditUser", model.LastEditUser);
            }
            if (model.LastEditTime == null)
            {
                h.AddParameter("@LastEditTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LastEditTime", model.LastEditTime);
            }
            if (model.Status == null)
            {
                h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Status", model.Status);
            }

            int result;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out result))
            {
                return 0;
            }
            return result;
        }

        /// <summary>计算记录数
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from Bse_DataDictionary";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>删除一条数据
        ///
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_DataDictionary ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        ///
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_DataDictionary ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_DataDictionary ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetList(string strWhere, string Filds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Filds + " ");
            strSql.Append(" FROM Bse_DataDictionary ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>分页获取数据列表
        ///
        /// </summary>
        public DataSet GetList(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_DataDictionary");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", PageSize);
            h.AddParameter("@PageIndex", PageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        ///
        /// </summary>
        public List<Nikita.Assist.DBManager.Model.Bse_DataDictionary> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_DataDictionary ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.DBManager.Model.Bse_DataDictionary> list = new List<Nikita.Assist.DBManager.Model.Bse_DataDictionary>();
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            using (IDataReader dataReader = h.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
                h.CloseConn();
            }
            return list;
        }

        /// <summary>分页获取数据列表
        ///
        /// </summary>
        public List<Nikita.Assist.DBManager.Model.Bse_DataDictionary> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_DataDictionary");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", PageSize);
            h.AddParameter("@PageIndex", PageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.DBManager.Model.Bse_DataDictionary> list = new List<Nikita.Assist.DBManager.Model.Bse_DataDictionary>();
            using (IDataReader dataReader = h.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
                h.CloseConn();
            }
            return list;
        }

        /// <summary>得到一个对象实体
        ///
        /// </summary>
        public Nikita.Assist.DBManager.Model.Bse_DataDictionary GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Bse_DataDictionary ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.DBManager.Model.Bse_DataDictionary model = null;
            using (IDataReader dataReader = h.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
                h.CloseConn();
            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        ///
        /// </summary>
        public Nikita.Assist.DBManager.Model.Bse_DataDictionary GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Bse_DataDictionary ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.DBManager.Model.Bse_DataDictionary model = null;
            using (IDataReader dataReader = h.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
                h.CloseConn();
            }
            return model;
        }

        /// <summary>对象实体绑定数据
        ///
        /// </summary>
        public Nikita.Assist.DBManager.Model.Bse_DataDictionary ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.DBManager.Model.Bse_DataDictionary model = new Nikita.Assist.DBManager.Model.Bse_DataDictionary();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            model.ServerName = dataReader["ServerName"].ToString();
            model.DatabaseName = dataReader["DatabaseName"].ToString();
            model.TableName = dataReader["TableName"].ToString();
            model.TableHistoryName = dataReader["TableHistoryName"].ToString();
            model.TableRemark = dataReader["TableRemark"].ToString();
            model.ColumnName = dataReader["ColumnName"].ToString();
            model.ColumnIdentity = dataReader["ColumnIdentity"].ToString();
            model.ColumnPK = dataReader["ColumnPK"].ToString();
            model.ColumnType = dataReader["ColumnType"].ToString();
            model.ColumnSpace = dataReader["ColumnSpace"].ToString();
            model.ColumnLength = dataReader["ColumnLength"].ToString();
            model.ColumnScale = dataReader["ColumnScale"].ToString();
            model.ColumnAllowNull = dataReader["ColumnAllowNull"].ToString();
            model.ColumnDefaultValue = dataReader["ColumnDefaultValue"].ToString();
            model.ColumnRemark = dataReader["ColumnRemark"].ToString();
            model.ColumnHistory = dataReader["ColumnHistory"].ToString();
            model.DbType = dataReader["DbType"].ToString();
            model.OperationType = dataReader["OperationType"].ToString();
            model.CreateUser = dataReader["CreateUser"].ToString();
            ojb = dataReader["CreateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateTime = DateTime.Parse(ojb.ToString());
            }
            model.LastEditUser = dataReader["LastEditUser"].ToString();
            ojb = dataReader["LastEditTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastEditTime = DateTime.Parse(ojb.ToString());
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = int.Parse(ojb.ToString());
            }

            return model;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Nikita.Assist.DBManager.Model.Bse_DataDictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_DataDictionary set ");
            strSql.Append("ServerName=@ServerName, DatabaseName=@DatabaseName, TableName=@TableName, TableHistoryName=@TableHistoryName, TableRemark=@TableRemark, ColumnName=@ColumnName, ColumnIdentity=@ColumnIdentity, ColumnPK=@ColumnPK, ColumnType=@ColumnType, ColumnSpace=@ColumnSpace, ColumnLength=@ColumnLength, ColumnScale=@ColumnScale, ColumnAllowNull=@ColumnAllowNull, ColumnDefaultValue=@ColumnDefaultValue, ColumnRemark=@ColumnRemark, ColumnHistory=@ColumnHistory, DbType=@DbType, OperationType=@OperationType, CreateUser=@CreateUser, CreateTime=@CreateTime, LastEditUser=@LastEditUser, LastEditTime=@LastEditTime, Status=@Status  ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            if (model.id == null)
            {
                h.AddParameter("@id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@id", model.id);
            }
            if (model.ServerName == null)
            {
                h.AddParameter("@ServerName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ServerName", model.ServerName);
            }
            if (model.DatabaseName == null)
            {
                h.AddParameter("@DatabaseName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DatabaseName", model.DatabaseName);
            }
            if (model.TableName == null)
            {
                h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableName", model.TableName);
            }
            if (model.TableHistoryName == null)
            {
                h.AddParameter("@TableHistoryName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableHistoryName", model.TableHistoryName);
            }
            if (model.TableRemark == null)
            {
                h.AddParameter("@TableRemark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableRemark", model.TableRemark);
            }
            if (model.ColumnName == null)
            {
                h.AddParameter("@ColumnName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnName", model.ColumnName);
            }
            if (model.ColumnIdentity == null)
            {
                h.AddParameter("@ColumnIdentity", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnIdentity", model.ColumnIdentity);
            }
            if (model.ColumnPK == null)
            {
                h.AddParameter("@ColumnPK", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnPK", model.ColumnPK);
            }
            if (model.ColumnType == null)
            {
                h.AddParameter("@ColumnType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnType", model.ColumnType);
            }
            if (model.ColumnSpace == null)
            {
                h.AddParameter("@ColumnSpace", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnSpace", model.ColumnSpace);
            }
            if (model.ColumnLength == null)
            {
                h.AddParameter("@ColumnLength", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnLength", model.ColumnLength);
            }
            if (model.ColumnScale == null)
            {
                h.AddParameter("@ColumnScale", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnScale", model.ColumnScale);
            }
            if (model.ColumnAllowNull == null)
            {
                h.AddParameter("@ColumnAllowNull", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnAllowNull", model.ColumnAllowNull);
            }
            if (model.ColumnDefaultValue == null)
            {
                h.AddParameter("@ColumnDefaultValue", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnDefaultValue", model.ColumnDefaultValue);
            }
            if (model.ColumnRemark == null)
            {
                h.AddParameter("@ColumnRemark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnRemark", model.ColumnRemark);
            }
            if (model.ColumnHistory == null)
            {
                h.AddParameter("@ColumnHistory", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ColumnHistory", model.ColumnHistory);
            }
            if (model.DbType == null)
            {
                h.AddParameter("@DbType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DbType", model.DbType);
            }
            if (model.OperationType == null)
            {
                h.AddParameter("@OperationType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@OperationType", model.OperationType);
            }
            if (model.CreateUser == null)
            {
                h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.CreateTime == null)
            {
                h.AddParameter("@CreateTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateTime", model.CreateTime);
            }
            if (model.LastEditUser == null)
            {
                h.AddParameter("@LastEditUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LastEditUser", model.LastEditUser);
            }
            if (model.LastEditTime == null)
            {
                h.AddParameter("@LastEditTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LastEditTime", model.LastEditTime);
            }
            if (model.Status == null)
            {
                h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Status", model.Status);
            }

            return h.ExecuteNonQuery();
        }
    }
}