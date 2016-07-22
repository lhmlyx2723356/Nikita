using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_User_Role表数据访问拓展类
    ///
    /// </summary>
    public partial class Bse_User_RoleDALExtend
    {
        public Bse_User_RoleDALExtend()
        {
        }

        /// <summary>批量插入
        ///
        /// </summary>
        public bool AddUserToRole(string UserIds, string RoleId, string CreateUserId, string Dept_Id, string Company_Id, string Bloc_Id, string SystemId, string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into Bse_User_Role([UserId]  ,[RoleId],CreateUserId,Dept_Id,Company_Id,Bloc_Id,SystemId) " +
                          "Select  B.Id,'" + RoleId + "','" + CreateUserId + "' ,'" + Dept_Id + "' ,'" + Company_Id + "' ,'" + Bloc_Id + "' ,'" + SystemId + "'  FROM    Fun_StringSplitToTable('" + UserIds + "',',') B  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            h.CreateCommand(strSql.ToString());
            bool flag = h.ExecuteNonQuery();
            return flag;
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetUserByRoleId(string strWhere)
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.User_Role_Id,b.* ");
            strSql.Append(" FROM Bse_User_Role  a inner join Bse_User b on a.UserId=B.User_Id");
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
    }
}