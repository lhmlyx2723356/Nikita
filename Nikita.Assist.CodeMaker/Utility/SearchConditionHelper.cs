using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.Model;
using System.Data;

namespace Nikita.Assist.CodeMaker
{
    public class SearchConditionHelper
    {
        public static string GetSearchCondition(string strTableName)
        {
            StringBuilder sb = new StringBuilder();
            List<Bse_UI> lstBseUis = BseUIManager.GetListUIQuery(strTableName);
            if (lstBseUis.Count == 0)
            {
                return string.Empty;
            } 
            sb.AppendLine("            SearchCondition condition = new SearchCondition();");
            foreach (Bse_UI ui in lstBseUis)
            {
                switch (ui.ControlNameSpace)
                {
                    case "System.Windows.Forms.TextBox":
                        sb.AppendLine("condition.AddCondition(\"" + ui.ColumnName + "\", this." + ui.ControlName + ".Text, SqlOperator.Like);");
                        break;
                    case "Nikita.WinForm.ExtendControl.CheckedComboBox":
                        sb.AppendLine("condition.AddCondition(\"" + ui.ColumnName + "\", this." + ui.ControlName + ".CheckedItemValues.Trim(), SqlOperator.In);");
                        break;
                }
            }
            sb.AppendLine("            return condition.BuildConditionSql().Replace(\"Where\", \"\");");
            return sb.ToString();
        }


        public static string GetSearchCondition(DataTable dtQuery)
        {
            StringBuilder sb = new StringBuilder();
            if (dtQuery.Rows.Count == 0)
            {
                return string.Empty;
            }
            sb.AppendLine("            SearchCondition condition = new SearchCondition();");
            foreach (DataRow  drUiRow in dtQuery.Rows)
            {
                switch (drUiRow["ControlNameSpace"].ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        sb.AppendLine("condition.AddCondition(\"" + drUiRow["ColumnName"] + "\", this." + drUiRow["ControlName"] + ".Text, SqlOperator.Like);");
                        break;
                    case "Nikita.WinForm.ExtendControl.CheckedComboBox":
                        sb.AppendLine("condition.AddCondition(\"" + drUiRow["ColumnName"] + "\", this." + drUiRow["ControlName"] + ".CheckedItemValues.Trim(), SqlOperator.In);");
                        break;
                }
            }
            sb.AppendLine("            return condition.BuildConditionSql().Replace(\"Where\", \"\");");
            return sb.ToString();
        }
    }
}
