using Nikita.Assist.WcfService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission.DAL
{
    /// <summary>Bse_Menu表数据访问拓展类
    ///
    /// </summary>
    public partial class Bse_MenuDALExtend
    {
        public Bse_MenuDALExtend()
        {
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetMenusRibbon()
        {
            IMsSqlDataAccessService h = ServiceHelper.GetMsSqlDataAccessService();
            h.CreateStoredCommand("Sp_GetMenus_Ribbon");
            DataSet ds = h.ExecuteQueryDataSet();
            return ds;
        }
    }
}