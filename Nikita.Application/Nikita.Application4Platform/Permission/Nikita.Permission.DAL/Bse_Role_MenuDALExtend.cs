using Nikita.Assist.WcfService;
using System.Collections.Generic;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_Role_Menu表数据访问拓展类
    ///
    /// </summary>
    public class Bse_Role_MenuDALExtend
    {
        public bool AddMenuToRole(Dictionary<string, string> moduleIds, string roleId, string createUserId, string deptId, string companyId, string blocId, string systemId)
        {
            IMsSqlDataAccessService _h = ServiceHelper.GetMsSqlDataAccessService();

            StringBuilder strSql = new StringBuilder();
            foreach (KeyValuePair<string, string> item in moduleIds)
            {
                strSql.AppendLine(" insert into Bse_Role_Menu([Module_Id]   ,[Role_Id],CreateUserId,Dept_Id,Company_Id,Bloc_Id,SystemId,[Allowed_Operator])Values (" + item.Key + ",'" + roleId + "','" + createUserId + "' ,'" + deptId + "' ,'" + companyId + "' ,'" + blocId + "' ,'" + systemId + "',+'" + item.Value + "') ");
            }
            _h.CreateCommand(strSql.ToString());
            bool flag = _h.ExecuteNonQuery();
            return flag;
        }
    }
}