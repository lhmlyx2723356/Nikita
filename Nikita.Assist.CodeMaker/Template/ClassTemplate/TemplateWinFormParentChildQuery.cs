using Nikita.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker.Template.ClassTemplate
{
    public class TemplateWinFormParentChildQuery : CodeMakeBulider
    {
        public static int SumWidth = 800;
        public static int BeginWidth = 15;
        public static int LocationX = 15;
        public static int CtlSpace = 11;
        public static int LocationY = 15;
        public static int HighSeed = 30;

        public static int SumWidthEdit = 800;
        public static int BeginWidthEdit = 15;
        public static int LocationXEdit = 15;
        public static int LocationYEdit = 15;
        public static int HighSeedEdit = 25;

        public static int QueryHeight = 1;
        public static int EditHeight = 1;

        public override string GenWinFormCS(BasicParameter parameter, BaseParameter baseParameter)
        {
            ParentChildEditDialogParameter parentChildParameter = baseParameter as ParentChildEditDialogParameter;
            if (parentChildParameter == null)
            {
                throw new Exception("parentChildParameter 为 Null");
            }
            string strFrmClassName = "Frm" + parentChildParameter.DatabaseTable.Name + "MasterDetailQuery";
            string strFrmDialogClassName = "Frm" + parentChildParameter.DatabaseTable.Name + "MasterDetailDialog";
            string strMasterDalName = parentChildParameter.DatabaseTable.Name + "DAL";
            string strDetailDalName = parentChildParameter.DatabaseTableDetail.Name + "DAL";
            string strMasterModelName = parentChildParameter.DatabaseTable.Name;
            string strDetailModelName = parentChildParameter.DatabaseTableDetail.Name;
            //string strMasterKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTable.Name, parameter.Conn);
            //string strDetailKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTableDetail.Name, parameter.Conn);
            string strRetrunListMaster = "List" + strMasterModelName + " ";
            string strRetrunListDetail = "List" + strDetailModelName + " ";
            string strGlobalListMaster = "m_lst" + strMasterModelName.Replace("_", "");
            string strGlobalListDetail = "m_lst" + strDetailModelName.Replace("_", "");
            string strParentId = parentChildParameter.KeyMaster;
            string strChildId = parentChildParameter.KeyDetail;
            //List<Bse_UI> lstBseUiQueryMaster = BseUIManager.GetListUIQuery(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiShowMaster = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTable.Name);
            //List<Bse_UI> lstBseUiEditDetail = BseUIManager.GetListUIEdit(parentChildParameter.DatabaseTableDetail.Name);
            List<Bse_UI> lstBseUiShowDetail = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTableDetail.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/// <summary>说明:" + strFrmClassName + "文件");
            sb.AppendLine("/// 作者:" + parameter.Author + "");
            sb.AppendLine("/// 创建时间:" + DateTime.Now + "");
            sb.AppendLine("/// </summary>");
            sb.AppendLine("using " + parameter.NameSpace + ".DAL;");
            sb.AppendLine("using " + parameter.NameSpace + ".Model;");
            sb.AppendLine("using Nikita.Core;");
            sb.AppendLine("using Nikita.Core.WinForm;");
            sb.AppendLine("using Nikita.Core.NPOIs;");
            sb.AppendLine("using Nikita.Core.Images;");
            sb.AppendLine("using Nikita.Core.Autofac;");
            sb.AppendLine("using Nikita.Core.XML;");
            sb.AppendLine("using Nikita.WinForm.ExtendControl;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.ComponentModel;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Diagnostics;");
            sb.AppendLine("using System.Drawing;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Windows.Forms;");
            sb.AppendLine("using Nikita.Base.Define;");
            sb.AppendLine("using Nikita.Base.IDAL;");

            sb.AppendLine("namespace " + parameter.NameSpace + "");
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>说明:" + strFrmClassName + "");
            sb.AppendLine("    /// 作者:Luhm");
            sb.AppendLine("    /// 最后修改人:");
            sb.AppendLine("    /// 最后修改时间:");
            sb.AppendLine("    /// 创建时间:" + DateTime.Now + "");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class " + strFrmClassName + " : Form");
            sb.AppendLine("    {");

            #region 常量、变量

            sb.AppendLine("        #region 常量、变量");
            sb.AppendLine("      /// <summary>主表操作类");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        private " + strMasterDalName + " m_" + strMasterDalName + ";"); 
            sb.AppendLine("        private IBseDAL<" + strMasterModelName + "> m_" + strMasterDalName + "; ");
            sb.AppendLine("        /// <summary>子表操作类");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        private " + strDetailDalName + "  m_" + strDetailDalName + ";"); 
            sb.AppendLine("        private IBseDAL<" + strDetailModelName + "> m_" + strDetailDalName + "; ");
            sb.AppendLine("        /// <summary>主表绑定集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private List<" + strMasterModelName + ">  " + strGlobalListMaster + ";");
            sb.AppendLine("        /// <summary>子表绑定集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private List<" + strDetailModelName + "> " + strGlobalListDetail + ";");
            sb.AppendLine("        /// <summary>Master列表下拉框绑定数据源");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private DataSet m_dsMasterGridSource;");
            sb.AppendLine("        /// <summary>Detail列表下拉框绑定数据源");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private DataSet m_dsDetailGridSource;");
            sb.AppendLine("        #endregion");
            sb.AppendLine("          ");

            #endregion

            #region 构造函数

            sb.AppendLine("        #region 构造函数");
            sb.AppendLine("        /// <summary>构造函数");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public " + strFrmClassName + "()");
            sb.AppendLine("        {");
            sb.AppendLine("            InitializeComponent();");
            sb.AppendLine("            cboFilterType.SelectedIndex = 2;");
            //sb.AppendLine("            m_" + strMasterDalName + " = new " +strMasterDalName + "();"); 
            sb.AppendLine(" m_" + strMasterDalName + " = GlobalHelp.GetResolve<IBseDAL<" + strMasterModelName + ">>();");
            //sb.AppendLine("            m_" + strDetailDalName + "  = new " + strDetailDalName + " ();"); 
            sb.AppendLine(" m_" + strDetailDalName + " = GlobalHelp.GetResolve<IBseDAL<" + strDetailModelName + ">>();");
            sb.AppendLine("            " + strGlobalListMaster + " = new List<" + strMasterModelName + ">();");

            sb.AppendLine("            DoInitData();");
            sb.AppendLine("            DoInitMasterGridSource();");
            sb.AppendLine("            DoInitDetailGridSource();");

            sb.AppendLine("            #region 主表列表绑定字段");
            foreach (Bse_UI itemUi in lstBseUiShowMaster)
            {
                if (itemUi.DataSourse == string.Empty)
                {
                    sb.AppendLine("              this." + itemUi.ControlName + ".AspectGetter = x => ((" + strMasterModelName + ")x)." + itemUi.ColumnName + ";");
                }
                else
                {
                    sb.AppendLine("            this." + itemUi.ControlName + ".AspectGetter = delegate(object x) { return GetMaster" + itemUi.ColumnName + "(((" + strMasterModelName + ")x)." + itemUi.ColumnName + "); };");
                }
            }
            //sb.AppendLine("            this.olvColumn1.AspectGetter = delegate(object x) { return ((OrderMaster)x).OrderId; };");
            //sb.AppendLine("            this.olvColumn2.AspectGetter = delegate(object x) { return ((OrderMaster)x).OrderNumber; };");
            //sb.AppendLine("            this.olvColumn3.AspectGetter = delegate(object x) { return GetMasterStatus(((OrderMaster)x).Status); };");
            //sb.AppendLine("            this.olvColumn4.AspectGetter = delegate(object x) { return ((OrderMaster)x).CreateDate; };");
            sb.AppendLine("            #endregion");

            sb.AppendLine("            #region 明细表列表绑定字段");
            foreach (Bse_UI itemUi in lstBseUiShowDetail)
            {
                if (itemUi.DataSourse == string.Empty)
                {
                    sb.AppendLine("              this." + itemUi.ControlName + ".AspectGetter = x => ((" + strDetailModelName + ")x)." + itemUi.ColumnName + ";");
                }
                else
                {
                    sb.AppendLine("            this." + itemUi.ControlName + ".AspectGetter = delegate(object x) { return GetDetail" + itemUi.ColumnName + "(((" + strDetailModelName + ")x)." + itemUi.ColumnName + "); };");
                }
            }
            //sb.AppendLine("            this.olvColumn5.AspectGetter = delegate(object x) { return ((OrderDetail)x).DetailId; };");
            //sb.AppendLine("            this.olvColumn6.AspectGetter = delegate(object x) { return ((OrderDetail)x).OrderId; };");
            //sb.AppendLine("            this.olvColumn7.AspectGetter = delegate(object x) { return ((OrderDetail)x).Customer; };");
            //sb.AppendLine("            this.olvColumn8.AspectGetter = delegate(object x) { return ((OrderDetail)x).ProductName; };");
            //sb.AppendLine("            this.olvColumn9.AspectGetter = delegate(object x) { return ((OrderDetail)x).Amount; };");
            //sb.AppendLine("            this.olvColumn10.AspectGetter = delegate(object x) { return ((OrderDetail)x).SumMoney; };");
            //sb.AppendLine("            this.olvColumn11.AspectGetter = delegate(object x) { return GetDetailStatus(((OrderDetail)x).Status); };");
            sb.AppendLine("            #endregion");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            #endregion

            #region 基础事件

            sb.AppendLine("          ");
            sb.AppendLine("        #region 基础事件");

            #region btnQuery_Click

            sb.AppendLine("        /// <summary>查询");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void btnQuery_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("                DoQueryData();");
            sb.AppendLine("        }");

            #endregion

            #region Command_Click

            sb.AppendLine("        /// <summary>执行命令");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine(" private void Command_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            ToolStripItem cmdItem = sender as ToolStripItem;");
            sb.AppendLine("            if (cmdItem != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                switch (cmdItem.Name.Trim())");
            sb.AppendLine("                {");
            sb.AppendLine("                    case \"cmdRefresh\":");
            sb.AppendLine("                        DoQueryData();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case  \"cmdNew\":");
            sb.AppendLine("                        DoNew();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case  \"cmdEdit\":");
            sb.AppendLine("                        DoEdit();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case  \"cmdDelete\":");
            sb.AppendLine("                        DoDeleteOrCancel(EntityOperationType.删除);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case  \"cmdCancel\":");
            sb.AppendLine("                        DoDeleteOrCancel(EntityOperationType.作废);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("         ");

            #endregion

            #region  Pager_PageChanged

            sb.AppendLine("        /// <summary>分页事件");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void Pager_PageChanged(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            DoQueryData();");
            sb.AppendLine("        }");

            #endregion

            #region objListViewMaster_SelectedIndexChanged
            sb.AppendLine("        /// <summary>主表选中事件");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void objListViewMaster_SelectedIndexChanged(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (objListViewMaster.SelectedObjects.Count == 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            " + strMasterModelName + " model = objListViewMaster.SelectedObjects[0] as  " + strMasterModelName + ";");
            sb.AppendLine("            if (model != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                 " + strGlobalListDetail + " = m_" + strDetailDalName + ".GetListArray(\"" + strChildId + "=\" + model." + strParentId + " + \"\");");
            sb.AppendLine("                objListViewDetail.SetObjects( " + strGlobalListDetail + " );");
            sb.AppendLine("                objListViewDetail.Refresh();");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            #endregion

            #region txtFilter

            sb.AppendLine("        /// <summary>通用查询");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void txtFilter_TextChanged(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.objListViewMaster.TimedFilter(txtFilter.Text);");
            sb.AppendLine("        }");

            #endregion

            #region objListViewMaster_MouseDoubleClick

            sb.AppendLine("        /// <summary>双击修改");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void objListViewMaster_MouseDoubleClick(object sender, MouseEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (e.Button != MouseButtons.Left)");
            sb.AppendLine("            {");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            Command_Click(cmdEdit, null);");
            sb.AppendLine("        }");

            #endregion

            sb.AppendLine("        #endregion");

            #endregion

            #region 基础方法

            sb.AppendLine("          ");
            sb.AppendLine("        #region 基础方法");
            #region DoQueryData

            sb.AppendLine("        /// <summary>执行查询");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoQueryData()");
            sb.AppendLine("        {");
            sb.AppendLine("  try");
            sb.AppendLine("            {");
            sb.AppendLine("                btnQuery.Enabled = false;");
            sb.AppendLine("                string strWhere = GetSearchSql();");
            sb.AppendLine("                " + strGlobalListMaster + " = m_" + strMasterDalName + ".GetListArray(\"*\", \"" + strParentId + "\", \"ASC\", Pager.PageSize, Pager.PageIndex, strWhere);");
            sb.AppendLine("                Pager.RecordCount = m_" + strMasterDalName + ".CalcCount(strWhere);");
            sb.AppendLine("                Pager.InitPageInfo();");
            sb.AppendLine("                objListViewMaster.SetObjects(  " + strGlobalListMaster + " );");
            sb.AppendLine("                if (  " + strGlobalListMaster + " .Count > 0)");
            sb.AppendLine("                {");
            sb.AppendLine("                    objListViewMaster.SelectedIndex = 0;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            finally");
            sb.AppendLine("            {");
            sb.AppendLine("                btnQuery.Enabled = true;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            #endregion

            #region GetSearchSql

            sb.AppendLine("        /// <summary>根据查询条件构造查询语句");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>查询条件</returns>");
            sb.AppendLine("        private string GetSearchSql()");
            sb.AppendLine("        {");
            sb.AppendLine(SearchConditionHelper.GetSearchCondition(parentChildParameter.DatabaseTable.Name));
            //sb.AppendLine("            SearchCondition condition = new SearchCondition();");
            //sb.AppendLine("            condition.AddCondition(\"UserName\", this.txtQueryUserName.Text, SqlOperator.Like)");
            //sb.AppendLine("                .AddCondition(\"TrueName\", cboQueryTrueName.Text, SqlOperator.Like)");
            //sb.AppendLine("                .AddCondition(\"User_Id\",  cbkID.CheckedItemValues.TrimEnd(','), SqlOperator.In);");
            //sb.AppendLine("            return condition.BuildConditionSql().Replace(\"Where\", \"\");");
            sb.AppendLine("        }");

            #endregion

            if (baseParameter.CodeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                #region DoDeleteOrCancel

                sb.AppendLine("        /// <summary>删除/作废");
                sb.AppendLine("        /// ");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        /// <param name=\"operationType\">操作类型</param>");
                sb.AppendLine("    private void DoDeleteOrCancel(EntityOperationType operationType)");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = CheckSelect(operationType);");
                sb.AppendLine("            if (strMsg != string.Empty)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(strMsg);");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("            DialogResult diaComfirmResult = MessageBox.Show(string.Format(\"{0}主表信息，会连同明细一起{0}\", operationType), @\"警告\",");
                sb.AppendLine("                MessageBoxButtons.YesNo);");
                sb.AppendLine("            if (diaComfirmResult != DialogResult.Yes)");
                sb.AppendLine("            {");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");

                sb.AppendLine("            IList objList = objListViewMaster.SelectedObjects;");
                sb.AppendLine("            IList lstSelectionIds = objList.Cast<" + strMasterModelName + ">().Select(t => t." + strParentId + ").ToList();");
                sb.AppendLine("            string strIds = lstSelectionIds.Cast<string>().Aggregate(string.Empty, (current, strId) => current + (strId + \",\"));");
                sb.AppendLine("            strIds = strIds.TrimEnd(',');");
                sb.AppendLine("            var blnReturn = operationType == EntityOperationType.删除");
                sb.AppendLine("                ? m_" + strMasterDalName + ".DeleteByCond(\"" + strParentId + " in (\" + strIds + \")\")");
                sb.AppendLine("                : m_" + strMasterDalName + ".Update(\"Status =0\", \"" + strParentId + " in (\" + strIds + \")\");");
                sb.AppendLine("            if (blnReturn)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(string.Format(\"{0}成功\", operationType));");
                sb.AppendLine("                objListViewMaster.RemoveObjects(objList);");
                sb.AppendLine("            }");
                sb.AppendLine("            else");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(string.Format(\"{0}失败\", operationType));");
                sb.AppendLine("            }");
                sb.AppendLine("        }");

                #endregion

                #region DoEdit

                sb.AppendLine("        /// <summary>编辑");
                sb.AppendLine("        ///");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        private void DoEdit()");
                sb.AppendLine("        {");
                sb.AppendLine("       string strMsg = CheckSelect(EntityOperationType.修改);");
                sb.AppendLine("            if (strMsg != string.Empty)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(strMsg);");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("            " + strMasterModelName + " model = objListViewMaster.SelectedObjects[0] as " + strMasterModelName + ";");
                sb.AppendLine("            if (model != null)");
                sb.AppendLine("            {");
                sb.AppendLine("                " + strFrmDialogClassName + " frmDialog = new  " + strFrmDialogClassName + "(model, " + strGlobalListMaster + ", " + strGlobalListDetail + ",m_dsDetailGridSource);");
                sb.AppendLine("                if (frmDialog.ShowDialog() == DialogResult.OK)");
                sb.AppendLine("                {");
                sb.AppendLine("                    " + strGlobalListMaster + " = frmDialog." + strRetrunListMaster + ";");
                sb.AppendLine("                    " + strGlobalListDetail + " = frmDialog." + strRetrunListDetail + ";");
                sb.AppendLine("                    if ( " + strGlobalListMaster + " != null)");
                sb.AppendLine("                    {");
                sb.AppendLine("                        objListViewMaster.SetObjects( " + strGlobalListMaster + ");");
                sb.AppendLine("                        objListViewMaster.Refresh();");
                sb.AppendLine("                    }");
                sb.AppendLine("                    if (  " + strGlobalListDetail + " != null)");
                sb.AppendLine("                    {");
                sb.AppendLine("                        objListViewDetail.SetObjects(  " + strGlobalListDetail + ");");
                sb.AppendLine("                        objListViewDetail.Refresh();");
                sb.AppendLine("                    }");
                sb.AppendLine("                }");
                sb.AppendLine("            }");
                sb.AppendLine("        }");

                #endregion

                #region DoNew

                sb.AppendLine("        /// <summary>新增");
                sb.AppendLine("        ///");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        private void DoNew()");
                sb.AppendLine("        {");
                sb.AppendLine("   " + strFrmDialogClassName + " frmDialog = new " + strFrmDialogClassName + " (null, " + strGlobalListMaster + ", " + strGlobalListDetail + ",m_dsDetailGridSource);");
                sb.AppendLine("            if (frmDialog.ShowDialog() == DialogResult.OK)");
                sb.AppendLine("            {");
                sb.AppendLine("                " + strGlobalListMaster + " = frmDialog." + strRetrunListMaster + ";");
                sb.AppendLine("                " + strGlobalListDetail + " = frmDialog." + strRetrunListDetail + ";");
                sb.AppendLine("                if (" + strGlobalListMaster + " != null)");
                sb.AppendLine("                {");
                sb.AppendLine("                    objListViewMaster.SetObjects(" + strGlobalListMaster + ");");
                sb.AppendLine("                    objListViewMaster.Refresh();");
                sb.AppendLine("                }");
                sb.AppendLine("                if (" + strGlobalListDetail + " != null)");
                sb.AppendLine("                {");
                sb.AppendLine("                    objListViewDetail.SetObjects(" + strGlobalListDetail + ");");
                sb.AppendLine("                    objListViewDetail.Refresh();");
                sb.AppendLine("                }");
                sb.AppendLine("            }");
                sb.AppendLine("        }");

                #endregion

                #region CheckSelect

                sb.AppendLine("         ");
                sb.AppendLine("        /// <summary>检查选择");
                sb.AppendLine("        /// ");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        /// <param name=\"operationType\">操作说明</param>");
                sb.AppendLine("        /// <returns>返回提示信息</returns>");
                sb.AppendLine(" private string CheckSelect(EntityOperationType operationType)");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = string.Empty;");
                sb.AppendLine("            if (objListViewMaster.SelectedObjects.Count == 0)");
                sb.AppendLine("            {");
                sb.AppendLine("                strMsg = string.Format(\"请选择要{0}的行数据\", operationType);");
                sb.AppendLine("            }");
                sb.AppendLine("            return strMsg;");
                sb.AppendLine("        }");

                #endregion
            }

            #region DoInitData

            sb.AppendLine("        /// <summary>初始化绑定下拉框等");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitData()");
            sb.AppendLine("        { ");
            string strBindSql = GenControlHelper.GetBindSourceSqlByTableName(parentChildParameter.DatabaseTable.Name);
            if (!string.IsNullOrEmpty(strBindSql))
            {
                sb.AppendLine(" const string strBindSql=\"" + strBindSql + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("DataSet ds =BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn); ");
                sb.AppendLine(GenControlHelper.GenBindDataSouce(parentChildParameter.DatabaseTable.Name,PanelType.查询面板));
            }
            //sb.AppendLine("            DataTable dt=new DataTable();");
            //sb.AppendLine("            dt.Columns.Add(\"Name\", typeof(string));");
            //sb.AppendLine("            dt.Columns.Add(\"Value\", typeof(string));");
            //sb.AppendLine("            foreach (string strItem in LoadTypeAry)");
            //sb.AppendLine("            {");
            //sb.AppendLine("                DataRow dr = dt.NewRow();");
            //sb.AppendLine("                dr[0] = strItem;");
            //sb.AppendLine("                dr[1] = strItem;");
            //sb.AppendLine("                dt.Rows.Add(dr);");
            //sb.AppendLine("            }");
            //sb.AppendLine("            CheckedComboBoxHelper.BindCheckedComboBox(cbkID, dt, \"Name\", \"Value\");");
            sb.AppendLine("        }");

            #endregion

            #region DoInitMasterGridSource
            sb.AppendLine("        /// <summary>初始主表数据源");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitMasterGridSource()");
            sb.AppendLine("        {");
            string strBindSqlMaster = GenControlHelper.GetBindSourceSqlByTableNameForGrid(parentChildParameter.DatabaseTable.Name);
            if (!string.IsNullOrEmpty(strBindSqlMaster))
            {
                sb.AppendLine(" const string strBindSql=\"" + strBindSqlMaster + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("            m_dsMasterGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn);");
            }
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            #endregion

            #region DoInitDetailGridSource
            sb.AppendLine("/// <summary>初始化明细数据源");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitDetailGridSource()");
            sb.AppendLine("        {");
            string strBindSqlDetail = GenControlHelper.GetBindSourceSqlByTableNameForGrid(parentChildParameter.DatabaseTableDetail.Name);
            if (!string.IsNullOrEmpty(strBindSqlDetail))
            {
                sb.AppendLine(" const string strBindSql=\"" + strBindSqlDetail + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("            m_dsDetailGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn);");
            }
            sb.AppendLine("        }");
            #endregion

            #region 主表绑定方法
            sb.AppendLine("     #region 主表绑定方法");
            foreach (Bse_UI ui in lstBseUiShowMaster)
            {
                if (ui.DataSourse.Trim().Length==0)
                {
                    continue;
                }
                sb.AppendLine("        private string GetMaster" + ui.ColumnName + "(object obj" + ui.ColumnName + ")");
                sb.AppendLine("        {");
                sb.AppendLine("            return m_dsMasterGridSource.Tables[\"" + ui.ControlName + "\"].Select(\"" + ui.FiledValue + " = '\" + obj" + ui.ColumnName + " + \"'\")[0][\"" + ui.FiledText + "\"].ToString();");
                sb.AppendLine("        }");
            }

            sb.AppendLine("        #endregion");
            #endregion

            #region 明细绑定方法
            sb.AppendLine("#region 明细绑定方法");
            foreach (Bse_UI ui in lstBseUiShowDetail)
            {
                if (ui.DataSourse.Trim().Length == 0)
                {
                    continue;
                }
                sb.AppendLine("        private string GetDetail" + ui.ColumnName + "(object obj" + ui.ColumnName + ")");
                sb.AppendLine("        {");
                sb.AppendLine("            return m_dsDetailGridSource.Tables[\"" + ui.ControlName + "\"].Select(\"" + ui.FiledValue + " = '\" + obj" + ui.ColumnName + " + \"'\")[0][\"" + ui.FiledText + "\"].ToString();");
                sb.AppendLine("        }");
            }
            sb.AppendLine("        #endregion ");
            #endregion
            #endregion

            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string GenWinFormDesign(BasicParameter parameter, BaseParameter baseParameter)
        {
            ParentChildEditDialogParameter parentChildParameter = baseParameter as ParentChildEditDialogParameter;
            if (parentChildParameter == null)
            {
                throw new Exception("parentChildParameter 为 Null");
            }
            string strFrmClassName = "Frm" + parentChildParameter.DatabaseTable.Name + "MasterDetailQuery";
            List<Bse_UI> lstBseUiQueryMaster = BseUIManager.GetListUIQuery(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiShowMaster = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiEditDetail = BseUIManager.GetListUIEdit(parentChildParameter.DatabaseTableDetail.Name);
            List<Bse_UI> lstBseUiShowDetail = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTableDetail.Name);
            int lblWidth = BseUIManager.GetCtlWidth("Label");
            //string strMasterKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTable.Name, parameter.Conn);
            //string strDetailKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTableDetail.Name, parameter.Conn);
            string strParentId = parentChildParameter.KeyMaster;
            string strChildId = parentChildParameter.KeyDetail;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace " + parameter.NameSpace + "");
            sb.AppendLine("{");
            sb.AppendLine("    partial class " + strFrmClassName + "");
            sb.AppendLine("    {");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Required designer variable.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private System.ComponentModel.IContainer components = null;");

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Clean up any resources being used.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine(
                "        /// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>");
            sb.AppendLine("        protected override void Dispose(bool disposing)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (disposing && (components != null))");
            sb.AppendLine("            {");
            sb.AppendLine("                components.Dispose();");
            sb.AppendLine("            }");
            sb.AppendLine("            base.Dispose(disposing);");
            sb.AppendLine("        }");



            sb.AppendLine("        #region Windows Form Designer generated code");

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Required method for Designer support - do not modify");
            sb.AppendLine("        /// the contents of this method with the code editor.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void InitializeComponent()");
            sb.AppendLine("        {");

            sb.AppendLine("           this.sptAll = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.sptQuery = new System.Windows.Forms.SplitContainer();");
            //sb.AppendLine("            this.txtQueryOrderNumber = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblQueryName = new System.Windows.Forms.Label();");
            #region 查询面板控件

            foreach (Bse_UI ui in lstBseUiQueryMaster)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("this." + ui.LabelName + " = new System.Windows.Forms.Label();");
                    sb.AppendLine("            this." + ui.ControlName + " = new " + ui.ControlNameSpace + "();");
                }
                else
                {
                    sb.AppendLine("            this." + ui.ControlName + " = new " + ui.ControlNameSpace + "();");
                }
            }

            #endregion
            sb.AppendLine("            this.grpFilter = new System.Windows.Forms.GroupBox();");
            sb.AppendLine("            this.cboFilterType = new System.Windows.Forms.ComboBox();");
            sb.AppendLine("            this.txtFilter = new System.Windows.Forms.TextBox();");
            sb.AppendLine("            this.btnQuery = new System.Windows.Forms.Button();");
            sb.AppendLine("            this.sptMasterDetail = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.sptMaster = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.grpMaster = new System.Windows.Forms.GroupBox();");
            sb.AppendLine("            this.objListViewMaster = new Nikita.WinForm.ExtendControl.FastObjectListView();");
            //sb.AppendLine("            this.olvColumn1 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn2 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn3 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn4 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            #region Master显示列

            foreach (Bse_UI ui in lstBseUiShowMaster)
            {
                if (string.IsNullOrEmpty(ui.ControlNameSpace))
                {
                    sb.AppendLine("            this." + ui.ControlName + " = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
                }
                else
                {
                    //Dx控件
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {
                        //sb.AppendLine("            this." + ui.ControlName +
                        //              " = newSystem.Windows.Forms.DataGridViewTextBoxColumn();");
                    }
                    sb.AppendLine("            this." + ui.ControlName + " = new " + ui.ControlNameSpace + "();");
                }
            }

            #endregion
            sb.AppendLine("            this.Pager = new Nikita.WinForm.ExtendControl.Pager();");
            sb.AppendLine("            this.grpDetail = new System.Windows.Forms.GroupBox();");
            sb.AppendLine("            this.objListViewDetail = new Nikita.WinForm.ExtendControl.FastObjectListView();");
            //sb.AppendLine("            this.olvColumn5 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn6 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn7 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn8 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn9 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn10 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn11 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            #region Detail显示列

            foreach (Bse_UI ui in lstBseUiShowDetail)
            {
                if (string.IsNullOrEmpty(ui.ControlNameSpace))
                {
                    sb.AppendLine("            this." + ui.ControlName + " = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
                }
                else
                {
                    //Dx控件
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {
                        //sb.AppendLine("            this." + ui.ControlName +
                        //              " = newSystem.Windows.Forms.DataGridViewTextBoxColumn();");
                    }
                    sb.AppendLine("            this." + ui.ControlName + " = new " + ui.ControlNameSpace + "();");
                }
            }

            #endregion
            sb.AppendLine("            this.tspCommand = new System.Windows.Forms.ToolStrip();");
            sb.AppendLine("            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdCancel = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdDelete = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdEdit = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdNew = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).BeginInit();");
            sb.AppendLine("            this.sptAll.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptAll.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptAll.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();");
            sb.AppendLine("            this.sptQuery.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptQuery.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptQuery.SuspendLayout();");
            sb.AppendLine("            this.grpFilter.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptMasterDetail)).BeginInit();");
            sb.AppendLine("            this.sptMasterDetail.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptMasterDetail.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptMasterDetail.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptMaster)).BeginInit();");
            sb.AppendLine("            this.sptMaster.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptMaster.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptMaster.SuspendLayout();");
            sb.AppendLine("            this.grpMaster.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.objListViewMaster)).BeginInit();");
            sb.AppendLine("            this.grpDetail.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).BeginInit();");
            sb.AppendLine("            this.tspCommand.SuspendLayout();");

            foreach (Bse_UI ui in lstBseUiQueryMaster)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("       ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).BeginInit();");
                }
            }
            sb.AppendLine("            this.SuspendLayout();");

            sb.AppendLine("   // ");
            sb.AppendLine("            // sptAll");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.sptAll.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;");
            sb.AppendLine("            this.sptAll.Location = new System.Drawing.Point(0, 26);");
            sb.AppendLine("            this.sptAll.Name = \"sptAll\";");
            sb.AppendLine("            this.sptAll.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Panel1.Controls.Add(this.sptQuery);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Panel2.Controls.Add(this.sptMasterDetail);");
            sb.AppendLine("            this.sptAll.Size = new System.Drawing.Size(784, 535);");
            sb.AppendLine("            this.sptAll.SplitterDistance = 57;");
            sb.AppendLine("            this.sptAll.TabIndex = 0;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptQuery");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.sptQuery.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;");
            sb.AppendLine("            this.sptQuery.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.sptQuery.Name = \"sptQuery\";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptQuery.Panel1");
            sb.AppendLine("            // ");
            #region 查询区控件

            foreach (Bse_UI ui in lstBseUiQueryMaster)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this." + ui.LabelName + ");");
                }
                sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this." + ui.ControlName + ");");
            }

            #endregion

            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.txtQueryOrderNumber);");
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.lblQueryName);");

            sb.AppendLine("            // ");
            sb.AppendLine("            // sptQuery.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptQuery.Panel2.Controls.Add(this.grpFilter);");
            sb.AppendLine("            this.sptQuery.Panel2.Controls.Add(this.btnQuery);");
            sb.AppendLine("            this.sptQuery.Size = new System.Drawing.Size(784, 57);");
            sb.AppendLine("            this.sptQuery.SplitterDistance = 489;");
            sb.AppendLine("            this.sptQuery.TabIndex = 2;");
            #region 查询区控件明细位置

            BeginWidth = 15;
            foreach (Bse_UI ui in lstBseUiQueryMaster)
            {
                int intCurrCtlWidth = BseUIManager.GetCtlWidth(ui.ControlType);
                if (ui.IsAddLable == "True")
                {
                    //控制位置
                    if (BeginWidth + lblWidth + intCurrCtlWidth > SumWidth)
                    {
                        QueryHeight += 1;
                        LocationX = 15;
                        LocationY = LocationY + HighSeed;
                        BeginWidth = 15;
                        BeginWidth += lblWidth + CtlSpace;
                    }
                    else
                    {
                        LocationX = BeginWidth;
                        BeginWidth += lblWidth + CtlSpace;
                    }
                    sb.Append(GenControlHelper.CreateLabelControl(ui.LabelName, ui.LabelText, LocationX, LocationY));
                }

                //控制位置
                if (BeginWidth + intCurrCtlWidth > SumWidth)
                {
                    QueryHeight += 1;
                    LocationX = 15;
                    LocationY = LocationY + HighSeed;
                    BeginWidth = 15;
                    BeginWidth += intCurrCtlWidth + CtlSpace;
                }
                else
                {
                    LocationX = BeginWidth;
                    BeginWidth += intCurrCtlWidth + CtlSpace;
                }
                sb.Append(GenControlHelper.CreateControl(ui.Ctl_Simple, ui.ControlName, LocationX, LocationY,
                    ui.ControlSort));

            }
            int hight = QueryHeight * (HighSeed + 5) + 30;
            if (hight < 87)
            {
                hight = 87;
            }
            sb.Replace("@QueryHeight@", hight.ToString());

            #endregion
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtQueryOrderNumber");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtQueryOrderNumber.Location = new System.Drawing.Point(62, 14);");
            //sb.AppendLine("            this.txtQueryOrderNumber.Name = "txtQueryOrderNumber";");
            //sb.AppendLine("            this.txtQueryOrderNumber.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtQueryOrderNumber.TabIndex = 1;");
            //sb.AppendLine("            this.txtQueryOrderNumber.Click += new System.EventHandler(this.Command_Click);");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblQueryName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblQueryName.AutoSize = true;");
            //sb.AppendLine("            this.lblQueryName.Location = new System.Drawing.Point(13, 17);");
            //sb.AppendLine("            this.lblQueryName.Name = "lblQueryName";");
            //sb.AppendLine("            this.lblQueryName.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblQueryName.TabIndex = 0;");
            //sb.AppendLine("            this.lblQueryName.Text = "单号";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // grpFilter");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));");
            sb.AppendLine("            this.grpFilter.Controls.Add(this.cboFilterType);");
            sb.AppendLine("            this.grpFilter.Controls.Add(this.txtFilter);");
            sb.AppendLine("            this.grpFilter.Location = new System.Drawing.Point(7, 3);");
            sb.AppendLine("            this.grpFilter.Name = \"grpFilter\";");
            sb.AppendLine("            this.grpFilter.Size = new System.Drawing.Size(214, 50);");
            sb.AppendLine("            this.grpFilter.TabIndex = 21;");
            sb.AppendLine("            this.grpFilter.TabStop = false;");
            sb.AppendLine("            this.grpFilter.Text =\"通用查询\";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cboFilterType");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;");
            sb.AppendLine("            this.cboFilterType.FlatStyle = System.Windows.Forms.FlatStyle.System;");
            sb.AppendLine("            this.cboFilterType.FormattingEnabled = true;");
            sb.AppendLine("            this.cboFilterType.Items.AddRange(new object[] {");
            sb.AppendLine("            \"Any text\",");
            sb.AppendLine("            \"Prefix\",");
            sb.AppendLine("            \"Regex\"});");
            sb.AppendLine("            this.cboFilterType.Location = new System.Drawing.Point(114, 17);");
            sb.AppendLine("            this.cboFilterType.Name = \"cboFilterType\";");
            sb.AppendLine("            this.cboFilterType.Size = new System.Drawing.Size(94, 25);");
            sb.AppendLine("            this.cboFilterType.TabIndex = 1;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // txtFilter");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.txtFilter.Location = new System.Drawing.Point(7, 17);");
            sb.AppendLine("            this.txtFilter.Name = \"txtFilter\";");
            sb.AppendLine("            this.txtFilter.Size = new System.Drawing.Size(100, 23);");
            sb.AppendLine("            this.txtFilter.TabIndex = 0;");
            sb.AppendLine("            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // btnQuery");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
            sb.AppendLine("            this.btnQuery.Location = new System.Drawing.Point(227, 17);");
            sb.AppendLine("            this.btnQuery.Name = \"btnQuery\";");
            sb.AppendLine("            this.btnQuery.Size = new System.Drawing.Size(55, 28);");
            sb.AppendLine("            this.btnQuery.TabIndex = 0;");
            sb.AppendLine("            this.btnQuery.Text = \"查询\";");
            sb.AppendLine("            this.btnQuery.UseVisualStyleBackColor = true;");
            sb.AppendLine("            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptMasterDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptMasterDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.sptMasterDetail.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptMasterDetail.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.sptMasterDetail.Name = \"sptMasterDetail\";");
            sb.AppendLine("            this.sptMasterDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptMasterDetail.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptMasterDetail.Panel1.Controls.Add(this.sptMaster);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptMasterDetail.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptMasterDetail.Panel2.Controls.Add(this.grpDetail);");
            sb.AppendLine("            this.sptMasterDetail.Size = new System.Drawing.Size(784, 474);");
            sb.AppendLine("            this.sptMasterDetail.SplitterDistance = 271;");
            sb.AppendLine("            this.sptMasterDetail.TabIndex = 0;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptMaster");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.sptMaster.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptMaster.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;");
            sb.AppendLine("            this.sptMaster.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.sptMaster.Name = \"sptMaster\";");
            sb.AppendLine("            this.sptMaster.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptMaster.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptMaster.Panel1.Controls.Add(this.grpMaster);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptMaster.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptMaster.Panel2.Controls.Add(this.Pager);");
            sb.AppendLine("            this.sptMaster.Size = new System.Drawing.Size(784, 271);");
            sb.AppendLine("            this.sptMaster.SplitterDistance = 226;");
            sb.AppendLine("            this.sptMaster.TabIndex = 0;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // grpMaster");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.grpMaster.Controls.Add(this.objListViewMaster);");
            sb.AppendLine("            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.grpMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
            sb.AppendLine("            this.grpMaster.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.grpMaster.Name = \"grpMaster\";");
            sb.AppendLine("            this.grpMaster.Size = new System.Drawing.Size(782, 224);");
            sb.AppendLine("            this.grpMaster.TabIndex = 0;");
            sb.AppendLine("            this.grpMaster.TabStop = false;");
            sb.AppendLine("            this.grpMaster.Text = \"主表信息\";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // objListViewMaster");
            sb.AppendLine("            // ");
            //sb.AppendLine("            this.objListViewMaster.AllColumns.Add(this.olvColumn1);");
            //sb.AppendLine("            this.objListViewMaster.AllColumns.Add(this.olvColumn2);");
            //sb.AppendLine("            this.objListViewMaster.AllColumns.Add(this.olvColumn3);");
            //sb.AppendLine("            this.objListViewMaster.AllColumns.Add(this.olvColumn4);");
            #region Master显示列
            foreach (Bse_UI ui in lstBseUiShowMaster)
            {
                if (string.IsNullOrEmpty(ui.ControlNameSpace))
                {
                    sb.AppendLine("            this.objListViewMaster.AllColumns.Add(this." + ui.ControlName + ");");
                }
                else
                {
                    //Dx控件
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {
                    }
                }
            }
            #endregion
            sb.AppendLine("            this.objListViewMaster.AllowColumnReorder = true;");
            sb.AppendLine("            this.objListViewMaster.BackColor = System.Drawing.SystemColors.Control;");
            sb.AppendLine("            this.objListViewMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.objListViewMaster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {");
            #region Master显示列
            for (int i = 0; i < lstBseUiShowMaster.Count; i++)
            {
                if (i == lstBseUiShowMaster.Count - 1)
                {
                    sb.AppendLine("            this." + lstBseUiShowMaster[i].ControlName + "");
                }
                else
                {
                    sb.AppendLine("            this." + lstBseUiShowMaster[i].ControlName + ",");
                }
            }
            //sb.AppendLine("            this.colUser_Id,");
            //sb.AppendLine("            this.colTrueName");
            #endregion
            //sb.AppendLine("            this.olvColumn1,");
            //sb.AppendLine("            this.olvColumn2,");
            //sb.AppendLine("            this.olvColumn3,");
            //sb.AppendLine("            this.olvColumn4"   );
            sb.AppendLine("});");
            sb.AppendLine("            this.objListViewMaster.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.objListViewMaster.FullRowSelect = true;");
            sb.AppendLine("            this.objListViewMaster.GridLines = true;");
            sb.AppendLine("            this.objListViewMaster.HideSelection = false;");
            sb.AppendLine("            this.objListViewMaster.Location = new System.Drawing.Point(3, 19);");
            sb.AppendLine("            this.objListViewMaster.Name = \"objListViewMaster\";");
            sb.AppendLine("            this.objListViewMaster.OwnerDraw = true;");
            sb.AppendLine("            this.objListViewMaster.SelectColumnsOnRightClickBehaviour = Nikita.WinForm.ExtendControl.ObjectListView.ColumnSelectBehaviour.Submenu;");
            sb.AppendLine("            this.objListViewMaster.ShowCommandMenuOnRightClick = true;");
            sb.AppendLine("            this.objListViewMaster.ShowGroups = false;");
            sb.AppendLine("            this.objListViewMaster.Size = new System.Drawing.Size(776, 202);");
            sb.AppendLine("            this.objListViewMaster.TabIndex = 0;");
            sb.AppendLine("            this.objListViewMaster.UseCompatibleStateImageBehavior = false;");
            sb.AppendLine("            this.objListViewMaster.UseFilterIndicator = true;");
            sb.AppendLine("            this.objListViewMaster.UseFiltering = true;");
            sb.AppendLine("            this.objListViewMaster.View = System.Windows.Forms.View.Details;");
            sb.AppendLine("            this.objListViewMaster.VirtualMode = true;");
            sb.AppendLine("            this.objListViewMaster.SelectedIndexChanged += new System.EventHandler(this.objListViewMaster_SelectedIndexChanged);");
            sb.AppendLine("            this.objListViewMaster.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objListViewMaster_MouseDoubleClick);");
            #region Master显示区列

            foreach (Bse_UI ui in lstBseUiShowMaster)
            {
                //sb.Append(GenControlHelper.CreateGridColumn(ui.ControlName, ui.LabelText,
                //    ui.ColumnName, ui.ControlSort, ui.ControlNameSpace,
                //    ui.Ctl_Simple, ui.GridSpeicalCtlName));

                sb.AppendLine("            // ");
                sb.AppendLine("            // " + ui.ControlName + "");
                sb.AppendLine("            // ");
                sb.AppendLine("            this." + ui.ControlName + ".AspectName = \"" + ui.ColumnName + "\";");
                sb.AppendLine("            this." + ui.ControlName + ".Text = \"" + ui.LabelText + "\";");
            }

            #endregion
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn1");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn1.AspectName = "";");
            //sb.AppendLine("            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            //sb.AppendLine("            this.olvColumn1.Text = "ID";");
            //sb.AppendLine("            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn2");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn2.AspectName = "";");
            //sb.AppendLine("            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            //sb.AppendLine("            this.olvColumn2.Text = "单号";");
            //sb.AppendLine("            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn3");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn3.AspectName = "";");
            //sb.AppendLine("            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            //sb.AppendLine("            this.olvColumn3.Text = "状态";");
            //sb.AppendLine("            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn4");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn4.AspectName = "";");
            //sb.AppendLine("            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            //sb.AppendLine("            this.olvColumn4.Text = "创建时间";");
            //sb.AppendLine("            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // Pager");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.Pager.Cursor = System.Windows.Forms.Cursors.Hand;");
            sb.AppendLine("            this.Pager.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.Pager.Location = new System.Drawing.Point(13, 3);");
            sb.AppendLine("            this.Pager.Name = \"Pager\";");
            sb.AppendLine("            this.Pager.PageIndex = 1;");
            sb.AppendLine("            this.Pager.RecordCount = 0;");
            sb.AppendLine("            this.Pager.Size = new System.Drawing.Size(735, 34);");
            sb.AppendLine("            this.Pager.TabIndex = 1;");
            sb.AppendLine("            this.Pager.PageChanged += new Nikita.WinForm.ExtendControl.PageChangedEventHandler(this.Pager_PageChanged);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // grpDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.grpDetail.Controls.Add(this.objListViewDetail);");
            sb.AppendLine("            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.grpDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
            sb.AppendLine("            this.grpDetail.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.grpDetail.Name = \"grpDetail\";");
            sb.AppendLine("            this.grpDetail.Size = new System.Drawing.Size(782, 197);");
            sb.AppendLine("            this.grpDetail.TabIndex = 2;");
            sb.AppendLine("            this.grpDetail.TabStop = false;");
            sb.AppendLine("            this.grpDetail.Text = \"明细信息\";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // objListViewDetail");
            sb.AppendLine("            // ");
            #region Detail显示列
            foreach (Bse_UI ui in lstBseUiShowDetail)
            {
                if (string.IsNullOrEmpty(ui.ControlNameSpace))
                {
                    sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this." + ui.ControlName + ");");
                }
                else
                {
                    //Dx控件
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {
                    }
                }
            }
            #endregion
            //sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this.olvColumn5);");
            //sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this.olvColumn6);");
            //sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this.olvColumn7);");
            //sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this.olvColumn8);");
            //sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this.olvColumn9);");
            //sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this.olvColumn10);");
            //sb.AppendLine("            this.objListViewDetail.AllColumns.Add(this.olvColumn11);");
            sb.AppendLine("            this.objListViewDetail.AllowColumnReorder = true;");
            sb.AppendLine("            this.objListViewDetail.BackColor = System.Drawing.SystemColors.Control;");
            sb.AppendLine("            this.objListViewDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.objListViewDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {");
            #region Detail显示列
            for (int i = 0; i < lstBseUiShowDetail.Count; i++)
            {
                if (i == lstBseUiShowDetail.Count - 1)
                {
                    sb.AppendLine("            this." + lstBseUiShowDetail[i].ControlName + "");
                }
                else
                {
                    sb.AppendLine("            this." + lstBseUiShowDetail[i].ControlName + ",");
                }
            }
            //sb.AppendLine("            this.colUser_Id,");
            //sb.AppendLine("            this.colTrueName");
            #endregion
            //sb.AppendLine("            this.olvColumn5,");
            //sb.AppendLine("            this.olvColumn6,");
            //sb.AppendLine("            this.olvColumn7,");
            //sb.AppendLine("            this.olvColumn8,");
            //sb.AppendLine("            this.olvColumn9,");
            //sb.AppendLine("            this.olvColumn10,");
            //sb.AppendLine("            this.olvColumn11");
            sb.AppendLine("});");
            sb.AppendLine("            this.objListViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.objListViewDetail.FullRowSelect = true;");
            sb.AppendLine("            this.objListViewDetail.GridLines = true;");
            sb.AppendLine("            this.objListViewDetail.HideSelection = false;");
            sb.AppendLine("            this.objListViewDetail.Location = new System.Drawing.Point(3, 19);");
            sb.AppendLine("            this.objListViewDetail.Name = \"objListViewDetail\";");
            sb.AppendLine("            this.objListViewDetail.OwnerDraw = true;");
            sb.AppendLine("            this.objListViewDetail.SelectColumnsOnRightClickBehaviour = Nikita.WinForm.ExtendControl.ObjectListView.ColumnSelectBehaviour.Submenu;");
            sb.AppendLine("            this.objListViewDetail.ShowCommandMenuOnRightClick = true;");
            sb.AppendLine("            this.objListViewDetail.ShowGroups = false;");
            sb.AppendLine("            this.objListViewDetail.ShowItemToolTips = true;");
            sb.AppendLine("            this.objListViewDetail.Size = new System.Drawing.Size(776, 175);");
            sb.AppendLine("            this.objListViewDetail.TabIndex = 1;");
            sb.AppendLine("            this.objListViewDetail.UseCompatibleStateImageBehavior = false;");
            sb.AppendLine("            this.objListViewDetail.UseFilterIndicator = true;");
            sb.AppendLine("            this.objListViewDetail.UseFiltering = true;");
            sb.AppendLine("            this.objListViewDetail.View = System.Windows.Forms.View.Details;");
            sb.AppendLine("            this.objListViewDetail.VirtualMode = true;");
            #region Detail显示区列

            foreach (Bse_UI ui in lstBseUiShowDetail)
            {
                //sb.Append(GenControlHelper.CreateGridColumn(ui.ControlName, ui.LabelText,
                //    ui.ColumnName, ui.ControlSort, ui.ControlNameSpace,
                //    ui.Ctl_Simple, ui.GridSpeicalCtlName));

                sb.AppendLine("            // ");
                sb.AppendLine("            // " + ui.ControlName + "");
                sb.AppendLine("            // ");
                sb.AppendLine("            this." + ui.ControlName + ".AspectName = \"" + ui.ColumnName + "\";");
                sb.AppendLine("            this." + ui.ControlName + ".Text = \"" + ui.LabelText + "\";");
            }

            #endregion
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn5");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn5.AspectName = \"\";");
            //sb.AppendLine("            this.olvColumn5.Text = \"明细ID\";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn6");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn6.AspectName = "";");
            //sb.AppendLine("            this.olvColumn6.Text = "主表ID";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn7");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn7.AspectName = "";");
            //sb.AppendLine("            this.olvColumn7.Text = "客户";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn8");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn8.AspectName = "";");
            //sb.AppendLine("            this.olvColumn8.Text = "产品";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn9");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn9.AspectName = "";");
            //sb.AppendLine("            this.olvColumn9.Text = "数量";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn10");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn10.AspectName = "";");
            //sb.AppendLine("            this.olvColumn10.Text = "金额";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn11");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn11.AspectName = "";");
            //sb.AppendLine("            this.olvColumn11.Text = "状态";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tspCommand");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tspCommand.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;");
            sb.AppendLine("            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {");
            sb.AppendLine("            this.cmdRefresh,");
            sb.AppendLine("            this.cmdCancel,");
            sb.AppendLine("            this.cmdDelete,");
            sb.AppendLine("            this.cmdEdit,");
            sb.AppendLine("            this.cmdNew});");
            sb.AppendLine("            this.tspCommand.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.tspCommand.Name = \"tspCommand\";");
            sb.AppendLine("            this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;");
            sb.AppendLine("            this.tspCommand.Size = new System.Drawing.Size(784, 26);");
            sb.AppendLine("            this.tspCommand.TabIndex = 7;");
            sb.AppendLine("            this.tspCommand.Text = \"toolStrip1 \";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdRefresh");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdRefresh.Name = \"cmdRefresh\";");
            sb.AppendLine("            this.cmdRefresh.Size = new System.Drawing.Size(43, 23);");
            sb.AppendLine("            this.cmdRefresh.Text = \"刷新 \";");
            sb.AppendLine("            this.cmdRefresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;");
            sb.AppendLine("            this.cmdRefresh.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdCancel");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdCancel.Name = \"cmdCancel\";");
            sb.AppendLine("            this.cmdCancel.Size = new System.Drawing.Size(43, 23);");
            sb.AppendLine("            this.cmdCancel.Text = \"作废 \";");
            sb.AppendLine("            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdDelete");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdDelete.Name = \"cmdDelete\";");
            sb.AppendLine("            this.cmdDelete.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdDelete.Text = \"删除\";");
            sb.AppendLine("            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdEdit");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdEdit.Name = \"cmdEdit\";");
            sb.AppendLine("            this.cmdEdit.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdEdit.Text = \"修改\";");
            sb.AppendLine("            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdNew");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdNew.Name = \"cmdNew\";");
            sb.AppendLine("            this.cmdNew.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdNew.Text = \"新增\";");
            sb.AppendLine("            this.cmdNew.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strFrmClassName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);");
            sb.AppendLine("            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
            sb.AppendLine("            this.ClientSize = new System.Drawing.Size(784, 561);");
            sb.AppendLine("            this.Controls.Add(this.sptAll);");
            sb.AppendLine("            this.Controls.Add(this.tspCommand);");
            sb.AppendLine("            this.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;");
            sb.AppendLine("            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.Name = \"" + strFrmClassName + "\";");
            sb.AppendLine("            this.ShowIcon = false;");
            sb.AppendLine("            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;");
            sb.AppendLine("            this.Text = \"" + strFrmClassName + "\";");
            sb.AppendLine("            this.sptAll.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptAll.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).EndInit();");
            sb.AppendLine("            this.sptAll.ResumeLayout(false);");
            sb.AppendLine("            this.sptQuery.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptQuery.Panel1.PerformLayout();");
            sb.AppendLine("            this.sptQuery.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();");
            sb.AppendLine("            this.sptQuery.ResumeLayout(false);");
            sb.AppendLine("            this.grpFilter.ResumeLayout(false);");
            sb.AppendLine("            this.grpFilter.PerformLayout();");
            sb.AppendLine("            this.sptMasterDetail.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptMasterDetail.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptMasterDetail)).EndInit();");
            sb.AppendLine("            this.sptMasterDetail.ResumeLayout(false);");
            sb.AppendLine("            this.sptMaster.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptMaster.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptMaster)).EndInit();");
            sb.AppendLine("            this.sptMaster.ResumeLayout(false);");
            sb.AppendLine("            this.grpMaster.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.objListViewMaster)).EndInit();");
            sb.AppendLine("            this.grpDetail.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).EndInit();");
            sb.AppendLine("            this.tspCommand.ResumeLayout(false);");
            sb.AppendLine("            this.tspCommand.PerformLayout();");
            foreach (Bse_UI ui in lstBseUiQueryMaster)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).EndInit();");
                }
            }
            sb.AppendLine("            this.ResumeLayout(false);");
            sb.AppendLine("            this.PerformLayout();");

            sb.AppendLine("        }");

            sb.AppendLine("        #endregion");


            sb.AppendLine("private System.Windows.Forms.SplitContainer sptAll;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptMasterDetail;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptMaster;");
            sb.AppendLine("        private System.Windows.Forms.GroupBox grpMaster;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptQuery;");
            #region 查询区控件
            foreach (Bse_UI uiQuery in lstBseUiQueryMaster)
            {
                if (uiQuery.IsAddLable == "True")
                {
                    sb.Append("        public  System.Windows.Forms.Label " + uiQuery.LabelName + ";\r\n");
                }
                sb.Append("        public " + uiQuery.ControlNameSpace + "  " + uiQuery.ControlName + ";\r\n");
            }
            #endregion
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtQueryOrderNumber;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblQueryName;");
            sb.AppendLine("        private System.Windows.Forms.Button btnQuery;");
            sb.AppendLine("        private System.Windows.Forms.ToolStrip tspCommand;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdRefresh;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdCancel;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdDelete;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdEdit;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdNew;");
            sb.AppendLine("        private WinForm.ExtendControl.Pager Pager;");
            sb.AppendLine("        private System.Windows.Forms.GroupBox grpDetail;");
            sb.AppendLine("        private WinForm.ExtendControl.FastObjectListView objListViewMaster;");
            sb.AppendLine("        private System.Windows.Forms.GroupBox grpFilter;");
            sb.AppendLine("        private System.Windows.Forms.ComboBox cboFilterType;");
            sb.AppendLine("        private System.Windows.Forms.TextBox txtFilter;");
            #region Master显示区列
            foreach (Bse_UI ui in lstBseUiShowMaster)
            {
                if (ui.ControlNameSpace == string.Empty)
                {
                    sb.Append("        public WinForm.ExtendControl.OLVColumn  " + ui.ControlName + ";\r\n");
                }
                else
                {
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {

                    }
                    else
                    {
                        //sb.Append("        public  System.Windows.Forms.DataGridViewTextBoxColumn   " + ui.ControlName + ";\r\n");
                        sb.Append("        public " + ui.ControlNameSpace + "  " + ui.ControlName + ";\r\n");
                    }
                }
            }
            #endregion
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn1;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn2;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn3;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn4;");
            sb.AppendLine("        private WinForm.ExtendControl.FastObjectListView objListViewDetail;");
            #region Detail显示区列
            foreach (Bse_UI ui in lstBseUiShowDetail)
            {
                if (ui.ControlNameSpace == string.Empty)
                {
                    sb.Append("        public WinForm.ExtendControl.OLVColumn  " + ui.ControlName + ";\r\n");
                }
                else
                {
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {

                    }
                    else
                    {
                        //sb.Append("        public  System.Windows.Forms.DataGridViewTextBoxColumn   " + ui.ControlName + ";\r\n");
                        sb.Append("        public " + ui.ControlNameSpace + "  " + ui.ControlName + ";\r\n");
                    }
                }
            }
            #endregion
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn5;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn6;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn7;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn8;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn9;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn10;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn11;"); 
            sb.AppendLine("    }");
            sb.AppendLine("}"); 
            return sb.ToString(); 
        }

    }
}