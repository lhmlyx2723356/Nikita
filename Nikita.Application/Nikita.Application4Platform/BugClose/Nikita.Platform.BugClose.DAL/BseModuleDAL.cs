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
    /// <summary>BseModule表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-06-05 18:22:37
    /// </summary>
    public partial class BseModuleDAL : IBseDAL<BseModule>
    {
        public BseModuleDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Platform.BugClose.Model.BseModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BseModule(");
            strSql.Append("ProjectID, Name, Status, Remark, Sort, DeptId, CompanyID, CreateDate, CreateUser, EditDate, EditUser  )");
            strSql.Append(" values (");
            strSql.Append("@ProjectID, @Name, @Status, @Remark, @Sort, @DeptId, @CompanyID, @CreateDate, @CreateUser, @EditDate, @EditUser  )");
            strSql.Append(";select @@IDENTITY");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
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
        public bool Update(Nikita.Platform.BugClose.Model.BseModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BseModule set ");
            strSql.Append("ProjectID=@ProjectID, Name=@Name, Status=@Status, Remark=@Remark, Sort=@Sort, DeptId=@DeptId, CompanyID=@CompanyID, CreateDate=@CreateDate, CreateUser=@CreateUser, EditDate=@EditDate, EditUser=@EditUser  ");
            strSql.Append(" where ModuleID=@ModuleID ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.ModuleID == null)
            {
                 h.AddParameter("@ModuleID", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ModuleID", model.ModuleID);
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
            strSql.Append("update BseModule set ");
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
        public bool Delete(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BseModule ");
            strSql.Append(" where ModuleID=@ModuleID ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@ModuleID", ModuleID);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BseModule ");
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
        public Nikita.Platform.BugClose.Model.BseModule GetModel(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BseModule ");
            strSql.Append(" where ModuleID=@ModuleID ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@ModuleID", ModuleID);
            Nikita.Platform.BugClose.Model.BseModule model = null;
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
        public Nikita.Platform.BugClose.Model.BseModule GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from BseModule ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Platform.BugClose.Model.BseModule model = null;
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
            strSql.Append(" FROM BseModule ");
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
            strSql.Append(" FROM BseModule ");
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
            h.AddParameter("@tblName", "BseModule");
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
        public List<Nikita.Platform.BugClose.Model.BseModule> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BseModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Platform.BugClose.Model.BseModule> list = new List<Nikita.Platform.BugClose.Model.BseModule>();
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
        public List<Nikita.Platform.BugClose.Model.BseModule> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "BseModule");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Platform.BugClose.Model.BseModule> list = new List<Nikita.Platform.BugClose.Model.BseModule>();
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
        public Nikita.Platform.BugClose.Model.BseModule ReaderBind(IDataReader dataReader)
        {
            Nikita.Platform.BugClose.Model.BseModule model = new Nikita.Platform.BugClose.Model.BseModule();
            object ojb;
            ojb = dataReader["ModuleID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ModuleID = int.Parse(ojb.ToString());
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
            string sql = "select count(1) from BseModule";
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

