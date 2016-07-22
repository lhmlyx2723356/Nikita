using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;

namespace Nikita.Assist.CodeMaker
{
    public class BseUIManager
    {
        public static List<Bse_UI> GetListUI(string strTableName)
        {
            StringBuilder sb = new StringBuilder();
            Bse_UIDAL bseUidal = GlobalHelp.GetUiHelper();
            if (bseUidal == null)
            {
                throw new Exception("Bse_UIDAL 为NULL");
            }
            List<Bse_UI> lstBseUis = bseUidal.GetListArray("TableName = '" + strTableName + "'").OrderBy(t => int.Parse(t.ControlSort)).ToList(); ;
            return lstBseUis;
        }

        public static List<Bse_UI> GetListUIQuery(string strTableName)
        {
            List<Bse_UI> lstBseUis = GetListUI(strTableName).Where(t => t.PanelName == "Query").OrderBy(t => int.Parse(t.ControlSort)).ToList();
            return lstBseUis;
        }
        public static List<Bse_UI> GetListUIShow(string strTableName)
        {
            List<Bse_UI> lstBseUis = GetListUI(strTableName).Where(t => t.PanelName == "Show").OrderBy(t => int.Parse(t.ControlSort)).ToList();
            return lstBseUis;
        }


        public static List<Bse_UI> GetListUIEdit(string strTableName)
        {
            List<Bse_UI> lstBseUis = GetListUI(strTableName).Where(t => t.PanelName == "Edit").OrderBy(t => int.Parse(t.ControlSort)).ToList();
            return lstBseUis;
        }
        /// <summary>根据控件类型获取控件的宽度
        /// 
        /// </summary> 
        /// <param name="strCtlType"></param>
        /// <returns></returns>
        public static int GetCtlWidth(string strCtlType)
        {
            List<Bse_ControlType> lstControlTypes = GetControlTypeInfo("");
            var bseControlType = lstControlTypes.FirstOrDefault(t => t.ControlType == strCtlType);
            if (bseControlType != null)
            {
                return bseControlType.Ctl_Width;
            }
            return 30;
        }

        /// <summary>获取所有控件信息
        /// 
        /// </summary>
        /// <param name="strCtlType"></param>
        /// <returns></returns>
        private static List<Bse_ControlType> GetControlTypeInfo(string strCtlType)
        {
            Bse_ControlTypeDAL controlTypeDal = new Bse_ControlTypeDAL();
            return controlTypeDal.GetListArray("");
        }

    }

}
