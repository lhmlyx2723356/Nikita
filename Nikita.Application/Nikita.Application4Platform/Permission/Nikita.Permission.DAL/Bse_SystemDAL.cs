using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_System表数据访问类
    ///
    /// </summary>
    public partial class Bse_SystemDAL
    {
        public Bse_SystemDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Permission.Model.Bse_System model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_System(");
            strSql.Append("System_Name, System_Type, System_Version, System_Language, CustNumber, LimitNumber, PY, Sort, Dept_Id, DeptName, Company_Id, CompanyName, Bloc_Id, BlocName, CreateUserId, CreateName, CreateDate, EditUserId, EditUserName, EditDate, Remark, State  )");
            strSql.Append(" values (");
            strSql.Append("@System_Name, @System_Type, @System_Version, @System_Language, @CustNumber, @LimitNumber, @PY, @Sort, @Dept_Id, @DeptName, @Company_Id, @CompanyName, @Bloc_Id, @BlocName, @CreateUserId, @CreateName, @CreateDate, @EditUserId, @EditUserName, @EditDate, @Remark, @State  )");
            strSql.Append(";select @@IDENTITY");

            h.CreateCommand(strSql.ToString());
            if (model.System_Name == null)
            {
                h.AddParameter("@System_Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Name", model.System_Name);
            }
            if (model.System_Type == null)
            {
                h.AddParameter("@System_Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Type", model.System_Type);
            }
            if (model.System_Version == null)
            {
                h.AddParameter("@System_Version", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Version", model.System_Version);
            }
            if (model.System_Language == null)
            {
                h.AddParameter("@System_Language", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Language", model.System_Language);
            }
            if (model.CustNumber == null)
            {
                h.AddParameter("@CustNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CustNumber", model.CustNumber);
            }
            if (model.LimitNumber == null)
            {
                h.AddParameter("@LimitNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LimitNumber", model.LimitNumber);
            }
            if (model.PY == null)
            {
                h.AddParameter("@PY", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PY", model.PY);
            }
            if (model.Sort == null)
            {
                h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sort", model.Sort);
            }
            if (model.Dept_Id == null)
            {
                h.AddParameter("@Dept_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Dept_Id", model.Dept_Id);
            }
            if (model.DeptName == null)
            {
                h.AddParameter("@DeptName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DeptName", model.DeptName);
            }
            if (model.Company_Id == null)
            {
                h.AddParameter("@Company_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Company_Id", model.Company_Id);
            }
            if (model.CompanyName == null)
            {
                h.AddParameter("@CompanyName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CompanyName", model.CompanyName);
            }
            if (model.Bloc_Id == null)
            {
                h.AddParameter("@Bloc_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Bloc_Id", model.Bloc_Id);
            }
            if (model.BlocName == null)
            {
                h.AddParameter("@BlocName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@BlocName", model.BlocName);
            }
            if (model.CreateUserId == null)
            {
                h.AddParameter("@CreateUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUserId", model.CreateUserId);
            }
            if (model.CreateName == null)
            {
                h.AddParameter("@CreateName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateName", model.CreateName);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.EditUserId == null)
            {
                h.AddParameter("@EditUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserId", model.EditUserId);
            }
            if (model.EditUserName == null)
            {
                h.AddParameter("@EditUserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserName", model.EditUserName);
            }
            if (model.EditDate == null)
            {
                h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditDate", model.EditDate);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
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
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            string sql = "select count(1) from Bse_System";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }

            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>删除一条数据
        ///
        /// </summary>
        public bool Delete(int System_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_System ");
            strSql.Append(" where System_Id=@System_Id ");

            h.CreateCommand(strSql.ToString());
            h.AddParameter("@System_Id", System_Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        ///
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_System ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }

            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_System ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

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
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Filds + " ");
            strSql.Append(" FROM Bse_System ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

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
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_System");
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

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Nikita.Permission.Model.Bse_System model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_System set ");
            strSql.Append("System_Name=@System_Name, System_Type=@System_Type, System_Version=@System_Version, System_Language=@System_Language, CustNumber=@CustNumber, LimitNumber=@LimitNumber, PY=@PY, Sort=@Sort, Dept_Id=@Dept_Id, DeptName=@DeptName, Company_Id=@Company_Id, CompanyName=@CompanyName, Bloc_Id=@Bloc_Id, BlocName=@BlocName, CreateUserId=@CreateUserId, CreateName=@CreateName, CreateDate=@CreateDate, EditUserId=@EditUserId, EditUserName=@EditUserName, EditDate=@EditDate, Remark=@Remark, State=@State  ");
            strSql.Append(" where System_Id=@System_Id ");

            h.CreateCommand(strSql.ToString());
            if (model.System_Id == null)
            {
                h.AddParameter("@System_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Id", model.System_Id);
            }
            if (model.System_Name == null)
            {
                h.AddParameter("@System_Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Name", model.System_Name);
            }
            if (model.System_Type == null)
            {
                h.AddParameter("@System_Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Type", model.System_Type);
            }
            if (model.System_Version == null)
            {
                h.AddParameter("@System_Version", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Version", model.System_Version);
            }
            if (model.System_Language == null)
            {
                h.AddParameter("@System_Language", DBNull.Value);
            }
            else
            {
                h.AddParameter("@System_Language", model.System_Language);
            }
            if (model.CustNumber == null)
            {
                h.AddParameter("@CustNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CustNumber", model.CustNumber);
            }
            if (model.LimitNumber == null)
            {
                h.AddParameter("@LimitNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LimitNumber", model.LimitNumber);
            }
            if (model.PY == null)
            {
                h.AddParameter("@PY", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PY", model.PY);
            }
            if (model.Sort == null)
            {
                h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sort", model.Sort);
            }
            if (model.Dept_Id == null)
            {
                h.AddParameter("@Dept_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Dept_Id", model.Dept_Id);
            }
            if (model.DeptName == null)
            {
                h.AddParameter("@DeptName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DeptName", model.DeptName);
            }
            if (model.Company_Id == null)
            {
                h.AddParameter("@Company_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Company_Id", model.Company_Id);
            }
            if (model.CompanyName == null)
            {
                h.AddParameter("@CompanyName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CompanyName", model.CompanyName);
            }
            if (model.Bloc_Id == null)
            {
                h.AddParameter("@Bloc_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Bloc_Id", model.Bloc_Id);
            }
            if (model.BlocName == null)
            {
                h.AddParameter("@BlocName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@BlocName", model.BlocName);
            }
            if (model.CreateUserId == null)
            {
                h.AddParameter("@CreateUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUserId", model.CreateUserId);
            }
            if (model.CreateName == null)
            {
                h.AddParameter("@CreateName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateName", model.CreateName);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.EditUserId == null)
            {
                h.AddParameter("@EditUserId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserId", model.EditUserId);
            }
            if (model.EditUserName == null)
            {
                h.AddParameter("@EditUserName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditUserName", model.EditUserName);
            }
            if (model.EditDate == null)
            {
                h.AddParameter("@EditDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EditDate", model.EditDate);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
            }

            return h.ExecuteNonQuery();
        }
    }
}