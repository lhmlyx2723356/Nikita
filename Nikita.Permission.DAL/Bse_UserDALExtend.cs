using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_User表数据访问拓展类
    ///
    /// </summary>
    public partial class Bse_UserDALExtend
    {
        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetList(string Realname, string Number, string Name, string Sex, string Role_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM  dbo.Bse_User A INNER JOIN  Bse_User_Role B ON A.User_Id=B.UserId WHERE  A.State=1 and   (  A.Realname LIKE '%" + Realname + "%'   OR '" + Realname + "'='') AND ( A.Number LIKE  '%" + Number + "%'     OR  '" + Number + "'='') AND ( A.UserName  LIKE   '%" + Name + "%'    OR  '" + Name + "'='') AND ( A.Sex  LIKE  '%" + Sex + "%'    OR  '" + Sex + "'='') AND B.RoleId=" + Role_Id + "");
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得用户所属机构
        ///
        /// </summary>
        public DataSet GetListUserOrganize(string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT b.Name as BlockName,c.Name as CompanyName ,d.Name as DeptName  FROM dbo.Bse_User a INNER JOIN dbo.Bse_Organize b ON a.Bloc_Id=b.Organize_Id INNER JOIN dbo.Bse_Organize c ON a.Company_Id=c.Organize_Id INNER JOIN dbo.Bse_Organize d ON a.Dept_Id=d.Organize_Id ");
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

        /// <summary>获得用户所属角色
        ///
        /// </summary>
        public DataSet GetListUserRole(string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT  f.Name INTO #TEMP  FROM dbo.Bse_User a  INNER JOIN  dbo.Bse_User_Role e ON e.UserId=a.User_Id INNER JOIN  dbo.Bse_Role f ON f.Role_Id=e.RoleId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("  EXEC [Sp_TableToString] 'Name','#TEMP','' DROP TABLE #TEMP");
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得用户所属角色
        ///
        /// </summary>
        public DataSet GetListUserRoleIds(string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT  CAST ( f.Role_Id as VARCHAR)  Role_Id INTO #TEMP  FROM dbo.Bse_User a  INNER JOIN  dbo.Bse_User_Role e ON e.UserId=a.User_Id INNER JOIN  dbo.Bse_Role f ON f.Role_Id=e.RoleId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("  EXEC [Sp_TableToString] 'Role_Id','#TEMP','' DROP TABLE #TEMP");
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(int State, string User_Id)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_User set state=@state ");

            strSql.Append(" where User_Id=@User_Id ");

            h.CreateCommand(strSql.ToString());

            h.AddParameter("@User_Id", User_Id);

            h.AddParameter("@State", State);

            return h.ExecuteNonQuery();
        }
    }
}