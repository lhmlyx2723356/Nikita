using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Nikita.Assist.WcfService
{
    
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPermissionService”。
    [ServiceContract]
    /*
      * 说明：权限服务，根据用户名，密码，系统ID 获取拥有的权限
      *   1，菜单权限
      * 2，按钮权限
     * 资料：http://www.cnblogs.com/tyb1222/archive/2012/10/12/2721252.html
     */
    public interface IPermissionService
    {
        [OperationContract]
        DataTable GetPermission(string strUserName,string strPassword,int intSystemId,bool blnWithPermission);
    }
}
