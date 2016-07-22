using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Nikita.Assist.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PermissionService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PermissionService.svc 或 PermissionService.svc.cs，然后开始调试。

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false)]
    public class PermissionService : IPermissionService
    {
        public DataTable GetPermission(string strUserName, string strPassword, int intSystemId, bool blnWithPermission=true)
        {
            MsSqlDataAccessService service = new MsSqlDataAccessService();
            if (blnWithPermission)
            { 
                service.CreateStoredCommand("GetPermission");
            }
            else
            { 
                service.CreateStoredCommand("GetWithoutPermission");
            }
            service.AddParameter("@UserName", strUserName);
            service.AddParameter("@Password", strPassword);
            service.AddParameter("@SystemId", intSystemId);
            return service.ExecuteQuery();
        }
    }
}