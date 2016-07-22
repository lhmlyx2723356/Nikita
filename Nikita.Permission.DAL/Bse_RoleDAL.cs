using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_Role表数据访问类
    ///
    /// </summary>
    public partial class Bse_RoleDAL
    {
        public Bse_RoleDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Permission.Model.Bse_Role model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_Role(");
            strSql.Append("SystemId, RoleNumber, Name, Type, AllowEdit, AllowDelete, IsVisible, OwnerCompany, PY, Sort, Dept_Id, DeptName, Company_Id, CompanyName, Bloc_Id, BlocName, CreateUserId, CreateName, CreateDate, EditUserId, EditUserName, EditDate, Remark, State  )");
            strSql.Append(" values (");
            strSql.Append("@SystemId, @RoleNumber, @Name, @Type, @AllowEdit, @AllowDelete, @IsVisible, @OwnerCompany, @PY, @Sort, @Dept_Id, @DeptName, @Company_Id, @CompanyName, @Bloc_Id, @BlocName, @CreateUserId, @CreateName, @CreateDate, @EditUserId, @EditUserName, @EditDate, @Remark, @State  )");
            strSql.Append(";select @@IDENTITY");

            h.CreateCommand(strSql.ToString());
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
            }
            if (model.RoleNumber == null)
            {
                h.AddParameter("@RoleNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@RoleNumber", model.RoleNumber);
            }
            if (model.Name == null)
            {
                h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Name", model.Name);
            }
            if (model.Type == null)
            {
                h.AddParameter("@Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Type", model.Type);
            }
            if (model.AllowEdit == null)
            {
                h.AddParameter("@AllowEdit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowEdit", model.AllowEdit);
            }
            if (model.AllowDelete == null)
            {
                h.AddParameter("@AllowDelete", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowDelete", model.AllowDelete);
            }
            if (model.IsVisible == null)
            {
                h.AddParameter("@IsVisible", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsVisible", model.IsVisible);
            }
            if (model.OwnerCompany == null)
            {
                h.AddParameter("@OwnerCompany", DBNull.Value);
            }
            else
            {
                h.AddParameter("@OwnerCompany", model.OwnerCompany);
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
        /// <param name="cond"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            string sql = "select count(1) from Bse_Role";
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
        public bool Delete(int Role_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_Role ");
            strSql.Append(" where Role_Id=@Role_Id ");

            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Role_Id", Role_Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        ///
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_Role ");
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
            strSql.Append(" FROM Bse_Role ");
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
            strSql.Append(" FROM Bse_Role ");
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
        public DataSet GetList(string fileds, string order, string ordertype, int pageSize, int pageIndex, string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_Role");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", pageSize);
            h.AddParameter("@PageIndex", pageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Nikita.Permission.Model.Bse_Role model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_Role set ");
            strSql.Append("SystemId=@SystemId, RoleNumber=@RoleNumber, Name=@Name, Type=@Type, AllowEdit=@AllowEdit, AllowDelete=@AllowDelete, IsVisible=@IsVisible, OwnerCompany=@OwnerCompany, PY=@PY, Sort=@Sort, Dept_Id=@Dept_Id, DeptName=@DeptName, Company_Id=@Company_Id, CompanyName=@CompanyName, Bloc_Id=@Bloc_Id, BlocName=@BlocName, CreateUserId=@CreateUserId, CreateName=@CreateName, CreateDate=@CreateDate, EditUserId=@EditUserId, EditUserName=@EditUserName, EditDate=@EditDate, Remark=@Remark, State=@State  ");
            strSql.Append(" where Role_Id=@Role_Id ");

            h.CreateCommand(strSql.ToString());
            if (model.Role_Id == null)
            {
                h.AddParameter("@Role_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Role_Id", model.Role_Id);
            }
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
            }
            if (model.RoleNumber == null)
            {
                h.AddParameter("@RoleNumber", DBNull.Value);
            }
            else
            {
                h.AddParameter("@RoleNumber", model.RoleNumber);
            }
            if (model.Name == null)
            {
                h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Name", model.Name);
            }
            if (model.Type == null)
            {
                h.AddParameter("@Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Type", model.Type);
            }
            if (model.AllowEdit == null)
            {
                h.AddParameter("@AllowEdit", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowEdit", model.AllowEdit);
            }
            if (model.AllowDelete == null)
            {
                h.AddParameter("@AllowDelete", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowDelete", model.AllowDelete);
            }
            if (model.IsVisible == null)
            {
                h.AddParameter("@IsVisible", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsVisible", model.IsVisible);
            }
            if (model.OwnerCompany == null)
            {
                h.AddParameter("@OwnerCompany", DBNull.Value);
            }
            else
            {
                h.AddParameter("@OwnerCompany", model.OwnerCompany);
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