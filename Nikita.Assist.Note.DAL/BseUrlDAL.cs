using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.Assist.Note.Model;
using Nikita.DataAccess4DBHelper; 
using Nikita.Base.IDAL;

namespace Nikita.Assist.Note.DAL
{
    /// <summary>BseUrl表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-06-19 11:46:12
    /// </summary>
    public partial class BseUrlDAL :IBseDAL<BseUrl>
    {
        public BseUrlDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Assist.Note.Model.BseUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BseUrl(");
            strSql.Append("Type, UrlTitle, Url, UrlContent, Remark, Status, CreateDate  )");
            strSql.Append(" values (");
            strSql.Append("@Type, @UrlTitle, @Url, @UrlContent, @Remark, @Status, @CreateDate  )");
            strSql.Append(";select @@IDENTITY");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.Type == null)
            {
                 h.AddParameter("@Type", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Type", model.Type);
            }
            if (model.UrlTitle == null)
            {
                 h.AddParameter("@UrlTitle", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@UrlTitle", model.UrlTitle);
            }
            if (model.Url == null)
            {
                 h.AddParameter("@Url", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Url", model.Url);
            }
            if (model.UrlContent == null)
            {
                 h.AddParameter("@UrlContent", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@UrlContent", model.UrlContent);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }

            int intResult;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out intResult))
            {
                return 0;
            }
            return   intResult;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Nikita.Assist.Note.Model.BseUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BseUrl set ");
            strSql.Append("Type=@Type, UrlTitle=@UrlTitle, Url=@Url, UrlContent=@UrlContent, Remark=@Remark, Status=@Status, CreateDate=@CreateDate  ");
            strSql.Append(" where Id=@Id ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.Id == null)
            {
                 h.AddParameter("@Id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Id", model.Id);
            }
            if (model.Type == null)
            {
                 h.AddParameter("@Type", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Type", model.Type);
            }
            if (model.UrlTitle == null)
            {
                 h.AddParameter("@UrlTitle", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@UrlTitle", model.UrlTitle);
            }
            if (model.Url == null)
            {
                 h.AddParameter("@Url", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Url", model.Url);
            }
            if (model.UrlContent == null)
            {
                 h.AddParameter("@UrlContent", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@UrlContent", model.UrlContent);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BseUrl set ");
            strSql.Append(strFieldWithValue);
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond );
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString()); 
            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BseUrl ");
            strSql.Append(" where Id=@Id ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BseUrl ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.Note.Model.BseUrl GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BseUrl ");
            strSql.Append(" where Id=@Id ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            Nikita.Assist.Note.Model.BseUrl model = null;
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
        public Nikita.Assist.Note.Model.BseUrl GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from BseUrl ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.Note.Model.BseUrl model = null;
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

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BseUrl ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

		
        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere, string strFields)
        {
            StringBuilder strSql = new StringBuilder(); 
			  strSql.Append("select " +strFields + " ");
            strSql.Append(" FROM BseUrl ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "BseUrl");
            h.AddParameter("@strFields",strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Nikita.Assist.Note.Model.BseUrl> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BseUrl ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.Note.Model.BseUrl> list = new List<Nikita.Assist.Note.Model.BseUrl>();
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
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
        public List<Nikita.Assist.Note.Model.BseUrl> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "BseUrl");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.Note.Model.BseUrl> list = new List<Nikita.Assist.Note.Model.BseUrl>();
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

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public Nikita.Assist.Note.Model.BseUrl ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.Note.Model.BseUrl model = new Nikita.Assist.Note.Model.BseUrl();
            object ojb;
            ojb = dataReader["Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            model.Type = dataReader["Type"].ToString();
            model.UrlTitle = dataReader["UrlTitle"].ToString();
            model.Url = dataReader["Url"].ToString();
            model.UrlContent = dataReader["UrlContent"].ToString();
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = int.Parse(ojb.ToString());
            }
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from BseUrl";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

