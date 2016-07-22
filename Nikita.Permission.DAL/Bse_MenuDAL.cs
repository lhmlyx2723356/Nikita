using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_Menu表数据访问类
    ///
    /// </summary>
    public partial class Bse_MenuDAL
    {
        public Bse_MenuDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Permission.Model.Bse_Menu model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_Menu(");
            strSql.Append("ParentId, Number, Name, Category, GroupTxt, ImagUrl, ImageIndex, SelectedImageIndex, NavigateUrl, Target, FormName, DeletionStateCode, IsPublic, Expand, AllowEdit, AllowDelete, PY, Sort, Dept_Id, DeptName, Company_Id, CompanyName, Bloc_Id, BlocName, CreateUserId, CreateName, CreateDate, EditUserId, EditUserName, EditDate, Remark, State, TileItemSize, SystemId,ControlPower  )");
            strSql.Append(" values (");
            strSql.Append("@ParentId, @Number, @Name, @Category, @GroupTxt, @ImagUrl, @ImageIndex, @SelectedImageIndex, @NavigateUrl, @Target, @FormName, @DeletionStateCode, @IsPublic, @Expand, @AllowEdit, @AllowDelete, @PY, @Sort, @Dept_Id, @DeptName, @Company_Id, @CompanyName, @Bloc_Id, @BlocName, @CreateUserId, @CreateName, @CreateDate, @EditUserId, @EditUserName, @EditDate, @Remark, @State, @TileItemSize, @SystemId  , @ControlPower)");
            strSql.Append(";select @@IDENTITY");

            h.CreateCommand(strSql.ToString());
            if (model.ParentId == null)
            {
                h.AddParameter("@ParentId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ParentId", model.ParentId);
            }
            if (model.Number == null)
            {
                h.AddParameter("@Number", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Number", model.Number);
            }
            if (model.Name == null)
            {
                h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Name", model.Name);
            }
            if (model.Category == null)
            {
                h.AddParameter("@Category", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Category", model.Category);
            }
            if (model.GroupTxt == null)
            {
                h.AddParameter("@GroupTxt", DBNull.Value);
            }
            else
            {
                h.AddParameter("@GroupTxt", model.GroupTxt);
            }
            if (model.ImagUrl == null)
            {
                h.AddParameter("@ImagUrl", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ImagUrl", model.ImagUrl);
            }
            if (model.ImageIndex == null)
            {
                h.AddParameter("@ImageIndex", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ImageIndex", model.ImageIndex);
            }
            if (model.SelectedImageIndex == null)
            {
                h.AddParameter("@SelectedImageIndex", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SelectedImageIndex", model.SelectedImageIndex);
            }
            if (model.NavigateUrl == null)
            {
                h.AddParameter("@NavigateUrl", DBNull.Value);
            }
            else
            {
                h.AddParameter("@NavigateUrl", model.NavigateUrl);
            }
            if (model.Target == null)
            {
                h.AddParameter("@Target", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Target", model.Target);
            }
            if (model.FormName == null)
            {
                h.AddParameter("@FormName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@FormName", model.FormName);
            }
            if (model.DeletionStateCode == null)
            {
                h.AddParameter("@DeletionStateCode", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DeletionStateCode", model.DeletionStateCode);
            }
            if (model.IsPublic == null)
            {
                h.AddParameter("@IsPublic", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsPublic", model.IsPublic);
            }
            if (model.Expand == null)
            {
                h.AddParameter("@Expand", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Expand", model.Expand);
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
            if (model.TileItemSize == null)
            {
                h.AddParameter("@TileItemSize", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TileItemSize", model.TileItemSize);
            }
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
            }
            if (model.ControlPower == null)
            {
                h.AddParameter("@ControlPower", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ControlPower", model.ControlPower);
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
            string sql = "select count(1) from Bse_Menu";
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
        public bool Delete(int Module_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_Menu ");
            strSql.Append(" where Module_Id=@Module_Id ");

            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Module_Id", Module_Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        ///
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_Menu ");
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
            DataSet ds = new DataSet();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * ");
                strSql.Append(" FROM Bse_Menu ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }

                h.CreateCommand(strSql.ToString());
                DataTable dt = h.ExecuteQuery();
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            strSql.Append(" FROM Bse_Menu ");
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
            h.AddParameter("@tblName", "Bse_Menu");
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
        public bool Update(Nikita.Permission.Model.Bse_Menu model)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_Menu set ");
            strSql.Append("ParentId=@ParentId, Number=@Number, Name=@Name, Category=@Category, GroupTxt=@GroupTxt, ImagUrl=@ImagUrl, ImageIndex=@ImageIndex, SelectedImageIndex=@SelectedImageIndex, NavigateUrl=@NavigateUrl, Target=@Target, FormName=@FormName, DeletionStateCode=@DeletionStateCode, IsPublic=@IsPublic, Expand=@Expand, AllowEdit=@AllowEdit, AllowDelete=@AllowDelete, PY=@PY, Sort=@Sort, Dept_Id=@Dept_Id, DeptName=@DeptName, Company_Id=@Company_Id, CompanyName=@CompanyName, Bloc_Id=@Bloc_Id, BlocName=@BlocName, CreateUserId=@CreateUserId, CreateName=@CreateName, CreateDate=@CreateDate, EditUserId=@EditUserId, EditUserName=@EditUserName, EditDate=@EditDate, Remark=@Remark, State=@State, TileItemSize=@TileItemSize, SystemId=@SystemId , ControlPower=@ControlPower  ");
            strSql.Append(" where Module_Id=@Module_Id ");

            h.CreateCommand(strSql.ToString());
            if (model.Module_Id == null)
            {
                h.AddParameter("@Module_Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Module_Id", model.Module_Id);
            }
            if (model.ParentId == null)
            {
                h.AddParameter("@ParentId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ParentId", model.ParentId);
            }
            if (model.Number == null)
            {
                h.AddParameter("@Number", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Number", model.Number);
            }
            if (model.Name == null)
            {
                h.AddParameter("@Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Name", model.Name);
            }
            if (model.Category == null)
            {
                h.AddParameter("@Category", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Category", model.Category);
            }
            if (model.GroupTxt == null)
            {
                h.AddParameter("@GroupTxt", DBNull.Value);
            }
            else
            {
                h.AddParameter("@GroupTxt", model.GroupTxt);
            }
            if (model.ImagUrl == null)
            {
                h.AddParameter("@ImagUrl", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ImagUrl", model.ImagUrl);
            }
            if (model.ImageIndex == null)
            {
                h.AddParameter("@ImageIndex", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ImageIndex", model.ImageIndex);
            }
            if (model.SelectedImageIndex == null)
            {
                h.AddParameter("@SelectedImageIndex", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SelectedImageIndex", model.SelectedImageIndex);
            }
            if (model.NavigateUrl == null)
            {
                h.AddParameter("@NavigateUrl", DBNull.Value);
            }
            else
            {
                h.AddParameter("@NavigateUrl", model.NavigateUrl);
            }
            if (model.Target == null)
            {
                h.AddParameter("@Target", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Target", model.Target);
            }
            if (model.FormName == null)
            {
                h.AddParameter("@FormName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@FormName", model.FormName);
            }
            if (model.DeletionStateCode == null)
            {
                h.AddParameter("@DeletionStateCode", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DeletionStateCode", model.DeletionStateCode);
            }
            if (model.IsPublic == null)
            {
                h.AddParameter("@IsPublic", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsPublic", model.IsPublic);
            }
            if (model.Expand == null)
            {
                h.AddParameter("@Expand", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Expand", model.Expand);
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
            if (model.TileItemSize == null)
            {
                h.AddParameter("@TileItemSize", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TileItemSize", model.TileItemSize);
            }
            if (model.SystemId == null)
            {
                h.AddParameter("@SystemId", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SystemId", model.SystemId);
            }
            if (model.ControlPower == null)
            {
                h.AddParameter("@ControlPower", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ControlPower", model.ControlPower);
            }
            return h.ExecuteNonQuery();
        }
    }
}