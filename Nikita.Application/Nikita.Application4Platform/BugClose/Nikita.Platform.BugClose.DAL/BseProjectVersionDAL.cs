using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.DataAccess4DBHelper;
using Nikita.Base.IDAL;
using Nikita.Platform.BugClose.Model;

namespace Nikita.Platform.BugClose.DAL
{
    /// <summary>BseProjectVersion表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-06-04 17:21:29
    /// </summary>
    public partial class BseProjectVersionDAL : IBseDAL<BseProjectVersion>
    {
        public BseProjectVersionDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Platform.BugClose.Model.BseProjectVersion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BseProjectVersion(");
            strSql.Append("ProjectID, Name, Status, Remark, Sort, DeptId, CompanyID, CreateDate, CreateUser, EditDate, EditUser  )");
            strSql.Append(" values (");
            strSql.Append("@ProjectID, @Name, @Status, @Remark, @Sort, @DeptId, @CompanyID, @CreateDate, @CreateUser, @EditDate, @EditUser  )");
            strSql.Append(";select @@IDENTITY");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.ProjectID == null)
            {
                 h.AddParameter("@ProjectID", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ProjectID", model.ProjectID);
            }
            if (model.Name == null)
            {
                 h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Name", model.Name);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Sort == null)
            {
                 h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Sort", model.Sort);
            }
            if (model.DeptId == null)
            {
                 h.AddParameter("@DeptId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DeptId", model.DeptId);
            }
            if (model.CompanyID == null)
            {
                 h.AddParameter("@CompanyID", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CompanyID", model.CompanyID);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.CreateUser == null)
            {
                 h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.EditDate == null)
            {
                 h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditDate", model.EditDate);
            }
            if (model.EditUser == null)
            {
                 h.AddParameter("@EditUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditUser", model.EditUser);
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
        public bool Update(Nikita.Platform.BugClose.Model.BseProjectVersion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BseProjectVersion set ");
            strSql.Append("ProjectID=@ProjectID, Name=@Name, Status=@Status, Remark=@Remark, Sort=@Sort, DeptId=@DeptId, CompanyID=@CompanyID, CreateDate=@CreateDate, CreateUser=@CreateUser, EditDate=@EditDate, EditUser=@EditUser  ");
            strSql.Append(" where VersionID=@VersionID ");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.VersionID == null)
            {
                 h.AddParameter("@VersionID", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@VersionID", model.VersionID);
            }
            if (model.ProjectID == null)
            {
                 h.AddParameter("@ProjectID", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ProjectID", model.ProjectID);
            }
            if (model.Name == null)
            {
                 h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Name", model.Name);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Sort == null)
            {
                 h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Sort", model.Sort);
            }
            if (model.DeptId == null)
            {
                 h.AddParameter("@DeptId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DeptId", model.DeptId);
            }
            if (model.CompanyID == null)
            {
                 h.AddParameter("@CompanyID", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CompanyID", model.CompanyID);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.CreateUser == null)
            {
                 h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.EditDate == null)
            {
                 h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditDate", model.EditDate);
            }
            if (model.EditUser == null)
            {
                 h.AddParameter("@EditUser", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@EditUser", model.EditUser);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BseProjectVersion set ");
            strSql.Append(strFieldWithValue);
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond );
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString()); 
            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int VersionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BseProjectVersion ");
            strSql.Append(" where VersionID=@VersionID ");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@VersionID", VersionID);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BseProjectVersion ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Platform.BugClose.Model.BseProjectVersion GetModel(int VersionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BseProjectVersion ");
            strSql.Append(" where VersionID=@VersionID ");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@VersionID", VersionID);
            Nikita.Platform.BugClose.Model.BseProjectVersion model = null;
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
        public Nikita.Platform.BugClose.Model.BseProjectVersion GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from BseProjectVersion ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Platform.BugClose.Model.BseProjectVersion model = null;
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
            strSql.Append(" FROM BseProjectVersion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
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
            strSql.Append(" FROM BseProjectVersion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
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
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "BseProjectVersion");
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
        public List<Nikita.Platform.BugClose.Model.BseProjectVersion> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BseProjectVersion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Platform.BugClose.Model.BseProjectVersion> list = new List<Nikita.Platform.BugClose.Model.BseProjectVersion>();
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
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
        public List<Nikita.Platform.BugClose.Model.BseProjectVersion> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "BseProjectVersion");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Platform.BugClose.Model.BseProjectVersion> list = new List<Nikita.Platform.BugClose.Model.BseProjectVersion>();
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
        public Nikita.Platform.BugClose.Model.BseProjectVersion ReaderBind(IDataReader dataReader)
        {
            Nikita.Platform.BugClose.Model.BseProjectVersion model = new Nikita.Platform.BugClose.Model.BseProjectVersion();
            object ojb;
            ojb = dataReader["VersionID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.VersionID = int.Parse(ojb.ToString());
            }
            ojb = dataReader["ProjectID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProjectID = int.Parse(ojb.ToString());
            }
            model.Name = dataReader["Name"].ToString();
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = int.Parse(ojb.ToString());
            }
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["Sort"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Sort = int.Parse(ojb.ToString());
            }
            ojb = dataReader["DeptId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DeptId = int.Parse(ojb.ToString());
            }
            ojb = dataReader["CompanyID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CompanyID = int.Parse(ojb.ToString());
            }
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }
            model.CreateUser = dataReader["CreateUser"].ToString();
            ojb = dataReader["EditDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EditDate = DateTime.Parse(ojb.ToString());
            }
            model.EditUser = dataReader["EditUser"].ToString();

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from BseProjectVersion";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

