using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_Role_Menu表数据访问类
    ///
    /// </summary>
    public partial class Bse_Role_MenuDAL
    {
        public Bse_Role_MenuDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Permission.Model.Bse_Role_Menu model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_Role_Menu(");
            strSql.Append("Module_Id, Role_Id, Allowed_Operator, Dept_Id, DeptName, Company_Id, CompanyName, Bloc_Id, BlocName, CreateUserId, CreateName, CreateDate, EditUserId, EditUserName, EditDate, State, SystemId  )");
            strSql.Append(" values (");
            strSql.Append("@Module_Id, @Role_Id, @Allowed_Operator, @Dept_Id, @DeptName, @Company_Id, @CompanyName, @Bloc_Id, @BlocName, @CreateUserId, @CreateName, @CreateDate, @EditUserId, @EditUserName, @EditDate, @State, @SystemId  )");
            strSql.Append(";select @@IDENTITY");

            h.CreateCommand(strSql.ToString());
            if (model.Module_Id == null)
            {
                h.AddParameter("@Module_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Module_Id", model.Module_Id);
            }
            if (model.Role_Id == null)
            {
                h.AddParameter("@Role_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Role_Id", model.Role_Id);
            }
            if (model.Allowed_Operator == null)
            {
                h.AddParameter("@Allowed_Operator", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Allowed_Operator", model.Allowed_Operator);
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
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
            }
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
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
            string sql = "select count(1) from Bse_Role_Menu";
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
        public bool Delete(int Account_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_Role_Menu ");
            strSql.Append(" where Account_Id=@Account_Id ");

            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Account_Id", Account_Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        ///
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_Role_Menu ");
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
            strSql.Append(" FROM Bse_Role_Menu ");
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
            strSql.Append(" FROM Bse_Role_Menu ");
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
            h.AddParameter("@tblName", "Bse_Role_Menu");
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
        public bool Update(Nikita.Permission.Model.Bse_Role_Menu model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_Role_Menu set ");
            strSql.Append("Module_Id=@Module_Id, Role_Id=@Role_Id, Allowed_Operator=@Allowed_Operator, Dept_Id=@Dept_Id, DeptName=@DeptName, Company_Id=@Company_Id, CompanyName=@CompanyName, Bloc_Id=@Bloc_Id, BlocName=@BlocName, CreateUserId=@CreateUserId, CreateName=@CreateName, CreateDate=@CreateDate, EditUserId=@EditUserId, EditUserName=@EditUserName, EditDate=@EditDate, State=@State, SystemId=@SystemId  ");
            strSql.Append(" where Account_Id=@Account_Id ");

            h.CreateCommand(strSql.ToString());
            if (model.Account_Id == null)
            {
                h.AddParameter("@Account_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Account_Id", model.Account_Id);
            }
            if (model.Module_Id == null)
            {
                h.AddParameter("@Module_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Module_Id", model.Module_Id);
            }
            if (model.Role_Id == null)
            {
                h.AddParameter("@Role_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Role_Id", model.Role_Id);
            }
            if (model.Allowed_Operator == null)
            {
                h.AddParameter("@Allowed_Operator", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Allowed_Operator", model.Allowed_Operator);
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
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
            }
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
            }

            return h.ExecuteNonQuery();
        }
    }
}