using Nikita.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker.Template.ClassTemplate
{
    public class TemplateWinFromParentChildEditWithDialog : CodeMakeBulider
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
        private int SumWidthDetail = 330;
        public override string GenWinFormCS(BasicParameter parameter, BaseParameter baseParameter)
        {
            ParentChildEditDialogParameter parentChildParameter = baseParameter as ParentChildEditDialogParameter;
            if (parentChildParameter == null)
            {
                throw new Exception("parentChildParameter 为 Null");
            }
            string strFrmClassName = "Frm" + parentChildParameter.DatabaseTable.Name + "MasterDetailDialog";
            string strMasterDalName = parentChildParameter.DatabaseTable.Name + "DAL";
            string strDetailDalName = parentChildParameter.DatabaseTableDetail.Name + "DAL";
            string strMasterModelName = parentChildParameter.DatabaseTable.Name;
            string strDetailModelName = parentChildParameter.DatabaseTableDetail.Name;
            string strMasterKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTable.Name, parameter.Conn);
            string strDetailKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTableDetail.Name, parameter.Conn);
            string strRetrunListMaster = "List" + strMasterModelName + " ";
            string strRetrunListDetail = "List" + strDetailModelName + " ";
            string strGlobalListMaster = "m_lst" + strMasterModelName.Replace("_", "");
            string strGlobalListDetail = "m_lst" + strDetailModelName.Replace("_", "");
            string strParentId = parentChildParameter.KeyMaster;
            string strChildId = parentChildParameter.KeyDetail;
            //string strKeyId = Tools.GetPKey_MSSQL(parameter.TableName, parameter.Conn); 
            string strGlobalMasterModelName = " m_" + strMasterModelName + " ";
            string strGlobalDetailModelName = " m_" + strDetailModelName + " ";
            List<Bse_UI> lstBseUiQueryMaster = BseUIManager.GetListUIQuery(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiShowMaster = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiEditMaster = BseUIManager.GetListUIEdit(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiEditDetail = BseUIManager.GetListUIEdit(parentChildParameter.DatabaseTableDetail.Name);
            List<Bse_UI> lstBseUiShowDetail = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTableDetail.Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/// <summary>说明:" + strFrmClassName + "文件");
            sb.AppendLine("/// 作者:" + parameter.Author + "");
            sb.AppendLine("/// 创建时间:" + DateTime.Now + "");
            sb.AppendLine("/// </summary>");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.ComponentModel;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Drawing;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Windows.Forms;");
            sb.AppendLine("using Nikita.Base.Define;");
            sb.AppendLine("using Nikita.Core;");
            sb.AppendLine("using Nikita.Core.WinForm;");
            sb.AppendLine("using Nikita.Core.NPOIs;");
            sb.AppendLine("using Nikita.Core.Images;");
            sb.AppendLine("using Nikita.Core.Autofac;");
            sb.AppendLine("using Nikita.Core.XML;");
            sb.AppendLine("using " + parameter.NameSpace + ".DAL;");
            sb.AppendLine("using " + parameter.NameSpace + ".Model;");
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
            sb.AppendLine("        /// <summary>主表对象");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private " + strMasterModelName + "  " + strGlobalMasterModelName + ";");
            sb.AppendLine("        /// <summary>主表集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private List< " + strMasterModelName + ">  " + strGlobalListMaster + ";");
            sb.AppendLine("        /// <summary>明细集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private List< " + strDetailModelName + ">  " + strGlobalListDetail + ";");
            sb.AppendLine("        /// <summary>主表操作类");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        private " + strMasterDalName + " m_" + strMasterDalName + ";"); 
            sb.AppendLine("        private IBseDAL<" + strMasterModelName + "> m_" + strMasterDalName + "; ");
            sb.AppendLine("        /// <summary>子表操作类");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        private  " + strDetailDalName + " m_" + strDetailDalName + " ;");
            sb.AppendLine("        private IBseDAL<" + strDetailModelName + "> m_" + strDetailDalName + "; ");
            sb.AppendLine("        /// <summary>主表编辑状态");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        private EntityOperationType m_masterStatus;");
            sb.AppendLine("        /// <summary>明细编辑状态");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        private EntityOperationType m_detailStatus;");
            sb.AppendLine("        /// <summary>返回主表对象集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        public List<" + strMasterModelName + "> " + strRetrunListMaster + " { get; private set; }");
            sb.AppendLine("        /// <summary>返回子表对象集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        public List<" + strDetailModelName + "> " + strRetrunListDetail + " { get; private set; }");
            sb.AppendLine("        /// <summary>Detail列表下拉框绑定数据源");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private DataSet m_dsDetailGridSource;");
            sb.AppendLine("  #endregion        ");
            sb.AppendLine("          ");
            #endregion

            #region 构造函数
            sb.AppendLine("        #region 构造函数");

            sb.AppendLine("      /// <summary>构造函数");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"modelMaster\">modelMaster</param>");
            sb.AppendLine("        /// <param name=\"lst" + strMasterModelName + "\">lst" + strMasterModelName + "</param>");
            sb.AppendLine("        /// <param name=\"lst" + strDetailModelName + "\">lst" + strDetailModelName + "</param>");
            sb.AppendLine("        /// <param name=\"dsDetailGridSource\">dsDetailGridSource</param>");
            sb.AppendLine("        public  " + strFrmClassName + "(" + strMasterModelName + " modelMaster,");
            sb.AppendLine("                                                                          List<" + strMasterModelName + "> lst" + strMasterModelName + ",");
            sb.AppendLine("                                                                          List<" + strDetailModelName + "> lst" + strDetailModelName + ",");
            sb.AppendLine("                                                                          DataSet  dsDetailGridSource )");
            sb.AppendLine("        {");
            sb.AppendLine("            InitializeComponent();");
            sb.AppendLine("             DoInitMasterData();");
            sb.AppendLine("             DoInitDetailData();");
            //sb.AppendLine("             DoInitDetailGridSource();");
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
            //sb.AppendLine("            this.m_" + strMasterDalName + " = new " + strMasterDalName + "();"); 
            sb.AppendLine(" m_" + strMasterDalName + " = GlobalHelp.GetResolve<IBseDAL<" + strMasterModelName + ">>();");
            //sb.AppendLine("            this.m_" + strDetailDalName + " = new " + strDetailDalName + " ();"); 
            sb.AppendLine(" m_" + strDetailDalName + " = GlobalHelp.GetResolve<IBseDAL<" + strDetailModelName + ">>();");
            sb.AppendLine("            this.m_" + strMasterModelName + " = modelMaster;");
            sb.AppendLine("            this." + strGlobalListMaster + " = lst" + strMasterModelName + "?? new List<" + strMasterModelName + ">();");
            sb.AppendLine("            this." + strGlobalListDetail + " = lst" + strDetailModelName + "?? new List<" + strDetailModelName + ">();");
            sb.AppendLine("        this.m_dsDetailGridSource=dsDetailGridSource;");
            sb.AppendLine("            //修改");
            sb.AppendLine("            if (modelMaster != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                m_" + strMasterModelName + "  = modelMaster;");
            sb.AppendLine("                DisplayData(" + strGlobalMasterModelName + ");");
            sb.AppendLine("                if (" + strGlobalListDetail + " != null && " + strGlobalListDetail + ".Count > 0)");
            sb.AppendLine("                {");
            sb.AppendLine("                    objListViewDetail.SetObjects(" + strGlobalListDetail + ");");
            sb.AppendLine("                    objListViewDetail.Refresh();");
            sb.AppendLine("                    objListViewDetail.SelectedIndex = 0;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            Command_Click(modelMaster == null ? cmdNew : cmdEdit, null);");
            sb.AppendLine("        }");
            sb.AppendLine("  #endregion        ");
            #endregion

            #region 基础事件
            sb.AppendLine("          ");
            sb.AppendLine("        #region 基础事件");
            sb.AppendLine("       /// <summary>执行命令");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void Command_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            ToolStripItem cmdItem = sender as ToolStripItem;");
            sb.AppendLine("            if (cmdItem != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                switch (cmdItem.Name)");
            sb.AppendLine("                {");
            sb.AppendLine("                    case \"cmdNew\":");
            sb.AppendLine("                        DoNewOrEdit(EntityOperationType.新增);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdEdit\":");
            sb.AppendLine("                        DoNewOrEdit(EntityOperationType.修改);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdDelete\":");
            sb.AppendLine("                        DoDelete();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdSave\":");
            sb.AppendLine("                        DoSave();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdCancel\":");
            sb.AppendLine("                        DoCancel();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdNewDetail\":");
            sb.AppendLine("                        DoNewOrEditDetail(EntityOperationType.新增明细);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdEditDetail\":");
            sb.AppendLine("                        DoNewOrEditDetail(EntityOperationType.修改明细);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdDeleteDetail\":");
            sb.AppendLine("                        DoDeleteDetail();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdSaveDetail\":");
            sb.AppendLine("                        DoSaveDetail();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdCancelDetail\":");
            sb.AppendLine("                        DoCancelDetail();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>明细表行变化事件");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void objListViewDetail_SelectedIndexChanged(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (objListViewDetail.SelectedObjects.Count == 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            " + strDetailModelName + " model = objListViewDetail.SelectedObjects[0] as   " + strDetailModelName + ";");
            sb.AppendLine("            if (model != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                EntityOperateManager.BindAll(this.grpDetail, model);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine("        #endregion");
            #endregion

            #region 基础方法
            sb.AppendLine("          ");
            sb.AppendLine("        #region 基本方法");

            #region 主表操作
            sb.AppendLine("#region 主表操作");

            sb.AppendLine("        /// <summary>新增或者修改主表");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"operationType\">操作类型</param>");
            sb.AppendLine("        private void DoNewOrEdit(EntityOperationType operationType)");
            sb.AppendLine("        {");
            sb.AppendLine("            SetMode(operationType);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>保存主表");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoSave()");
            sb.AppendLine("        {");
            sb.AppendLine("            string strMsg = DoCheckMaster();");
            sb.AppendLine("            if (strMsg!=string.Empty)");
            sb.AppendLine("            {");
            sb.AppendLine("                MessageBox.Show(strMsg);");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            switch (m_masterStatus)");
            sb.AppendLine("            {");
            sb.AppendLine("                case EntityOperationType.新增:");

            if (parentChildParameter.DontRepeatColumns.Trim() != string.Empty)
            {
                string[] strColumnArray = parentChildParameter.DontRepeatColumns.Split(',');
                if (strColumnArray.Length > 0)
                {
                    foreach (Bse_UI ui in lstBseUiEditMaster)
                    {
                        if (strColumnArray.Contains(ui.ColumnName))
                        {
                            string strExistInfo = GenControlHelper.CreateExistInfo("m_" + strMasterDalName, ui.ColumnName,
                                ui.LabelText, ui.ControlName, ui.ColumnType, ui.ControlNameSpace, OperationType.新增, strMasterKeyId, strGlobalMasterModelName);
                            sb.AppendLine(strExistInfo);
                        }
                    }
                }
            }

            sb.AppendLine("                    " + strMasterModelName + " model = EntityOperateManager.AddEntity<" + strMasterModelName + ">(this.grpMaster);");
            sb.AppendLine("                    int intReturn = m_" + strMasterDalName + ".Add(model);");
            sb.AppendLine("                    if (intReturn > 0)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        " + strGlobalMasterModelName + "  = model;");
            sb.AppendLine("                        model." + strMasterKeyId + " = intReturn;");
            sb.AppendLine("                        " + strGlobalListMaster + ".Add(model);");
            sb.AppendLine("                        " + strRetrunListMaster + " = " + strGlobalListMaster + ";");
            sb.AppendLine("                        //清空明细列表");
            sb.AppendLine("                          " + strGlobalListDetail + ".Clear();");
            sb.AppendLine("                        objListViewDetail.SetObjects( " + strGlobalListDetail + ");");
            sb.AppendLine("                        objListViewDetail.Refresh();");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");
            sb.AppendLine("                case EntityOperationType.修改:");
            if (parentChildParameter.DontRepeatColumns.Trim() != string.Empty)
            {
                string[] strColumnArray = parentChildParameter.DontRepeatColumns.Split(',');
                if (strColumnArray.Length > 0)
                {
                    foreach (Bse_UI ui in lstBseUiEditMaster)
                    {
                        if (strColumnArray.Contains(ui.ColumnName))
                        {
                            string strExistInfo = GenControlHelper.CreateExistInfo("m_" + strMasterDalName, ui.ColumnName,
                                ui.LabelText, ui.ControlName, ui.ColumnType, ui.ControlNameSpace, OperationType.修改, strMasterKeyId, strGlobalMasterModelName);
                            sb.AppendLine(strExistInfo);
                        }
                    }
                }
            }
            sb.AppendLine("                    " + strGlobalMasterModelName + "  = EntityOperateManager.EditEntity(this.grpMaster,       " + strGlobalMasterModelName + "  );");
            sb.AppendLine("                    bool blnReturn = m_" + strMasterDalName + ".Update( " + strGlobalMasterModelName + ");");
            sb.AppendLine("                    if (blnReturn)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        " + strRetrunListMaster + " = " + strGlobalListMaster + ";");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");
            sb.AppendLine("            }");
            sb.AppendLine("            SetMode(EntityOperationType.只读);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>删除主表，连同明细一起删除");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        private void DoDelete()");
            sb.AppendLine("        {");
            sb.AppendLine("           m_" + strDetailDalName + ".DeleteByCond(\"" + strChildId + "=\" + " + strGlobalMasterModelName + "." + strParentId + " + \"\");");
            sb.AppendLine("            m_" + strMasterDalName + ".Delete(" + strGlobalMasterModelName + "." + strParentId + ");");
            sb.AppendLine("            " + strGlobalListMaster + ".Remove(" + strGlobalMasterModelName + ");");
            sb.AppendLine("             " + strGlobalMasterModelName + " = null;");
            sb.AppendLine("            if ( " + strGlobalListDetail + " != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                " + strGlobalListDetail + ".Clear();");
            sb.AppendLine("                objListViewDetail.SetObjects(" + strGlobalListDetail + ");");
            sb.AppendLine("                objListViewDetail.Refresh();");
            sb.AppendLine("            }");
            sb.AppendLine("            SetMode(EntityOperationType.只读);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>撤销操作");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        private void DoCancel()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (" + strGlobalMasterModelName + " != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                DisplayData(" + strGlobalMasterModelName + ");");
            sb.AppendLine("                SetMode(EntityOperationType.只读);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            #endregion

            #region 明细表操作
            sb.AppendLine("#region 明细表操作");

            sb.AppendLine("        /// <summary>新增或者修改明细表");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"operationType\">操作类型</param>");
            sb.AppendLine("        private void DoNewOrEditDetail(EntityOperationType operationType)");
            sb.AppendLine("        {");
            sb.AppendLine("            string strMsg = DoCheckDetail(operationType);");
            sb.AppendLine("            if (strMsg != string.Empty)");
            sb.AppendLine("            {");
            sb.AppendLine("                MessageBox.Show(strMsg);");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            SetMode(operationType);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>保存明细表");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoSaveDetail()");
            sb.AppendLine("        {");
            sb.AppendLine("            string strMsg = DoCheckDetail(EntityOperationType.只读明细);");
            sb.AppendLine("            if (strMsg!=string.Empty)");
            sb.AppendLine("            {");
            sb.AppendLine("                MessageBox.Show(strMsg);");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            switch (m_detailStatus)");
            sb.AppendLine("            {");
            sb.AppendLine("                case EntityOperationType.新增明细:");
            if (parentChildParameter.DontRepeatColumnsDetail.Trim() != string.Empty)
            {
                string[] strColumnArray = parentChildParameter.DontRepeatColumns.Split(',');
                if (strColumnArray.Length > 0)
                {
                    foreach (Bse_UI ui in lstBseUiEditDetail)
                    {
                        if (strColumnArray.Contains(ui.ColumnName))
                        {
                            string strExistInfo = GenControlHelper.CreateExistInfo("m_" + strDetailDalName, ui.ColumnName,
                                ui.LabelText, ui.ControlName, ui.ColumnType, ui.ControlNameSpace, OperationType.新增, strDetailKeyId, strGlobalMasterModelName);
                            sb.AppendLine(strExistInfo);
                        }
                    }
                }
            }
            sb.AppendLine("                    " + strDetailModelName + " model = EntityOperateManager.AddEntity< " + strDetailModelName + ">(this.grpDetail);");
            sb.AppendLine("                    model." + strChildId + " = " + strGlobalMasterModelName + "." + strParentId + ";");
            sb.AppendLine("                    int intReturn = m_" + strDetailDalName + ".Add(model);");
            sb.AppendLine("                    if (intReturn > 0)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        model." + strDetailKeyId + " = intReturn;");
            sb.AppendLine("                        " + strGlobalListDetail + ".Add(model);");
            sb.AppendLine("                        " + strRetrunListDetail + " = " + strGlobalListDetail + ";");
            sb.AppendLine("                        objListViewDetail.SetObjects(" + strGlobalListDetail + ");");
            sb.AppendLine("                        objListViewDetail.Refresh();");
            sb.AppendLine("                        objListViewDetail.SelectedIndex = " + strGlobalListDetail + ".Count - 1;");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");
            sb.AppendLine("                case EntityOperationType.修改明细:");
            if (parentChildParameter.DontRepeatColumnsDetail.Trim() != string.Empty)
            {
                string[] strColumnArray = parentChildParameter.DontRepeatColumns.Split(',');
                if (strColumnArray.Length > 0)
                {
                    foreach (Bse_UI ui in lstBseUiEditDetail)
                    {
                        if (strColumnArray.Contains(ui.ColumnName))
                        {
                            string strExistInfo = GenControlHelper.CreateExistInfo("m_" + strDetailDalName, ui.ColumnName,
                                ui.LabelText, ui.ControlName, ui.ColumnType, ui.ControlNameSpace, OperationType.修改, strDetailKeyId, strGlobalMasterModelName);
                            sb.AppendLine(strExistInfo);
                        }
                    }
                }
            }
            sb.AppendLine("                    " + strDetailModelName + " modelDetail = this.objListViewDetail.SelectedObjects[0] as  " + strDetailModelName + ";");
            sb.AppendLine("                    EntityOperateManager.EditEntity(this.grpDetail, modelDetail);");
            sb.AppendLine("                    bool blnReturn = m_" + strDetailDalName + ".Update(modelDetail);");
            sb.AppendLine("                    if (blnReturn)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        " + strRetrunListDetail + " = " + strGlobalListDetail + ";");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");
            sb.AppendLine("            }");
            sb.AppendLine("            SetMode(EntityOperationType.只读明细);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>删除明细表，允许选中多个进行删除");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoDeleteDetail()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (" + strGlobalListDetail + " != null && this.objListViewDetail.SelectedObjects.Count > 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                IList listObjects = this.objListViewDetail.SelectedObjects;");
            sb.AppendLine("                string strIds = listObjects.Cast<" + strDetailModelName + ">().Aggregate(string.Empty, (current, modelDetail) => current + modelDetail." + strDetailKeyId + " + \",\");");
            sb.AppendLine("                strIds = strIds.TrimEnd(',');");
            sb.AppendLine("                if (strIds.Length > 0)");
            sb.AppendLine("                {");
            sb.AppendLine("                    m_" + strDetailDalName + ".DeleteByCond(\"" + strDetailKeyId + " in(\" + strIds + \")\");");
            sb.AppendLine("                    " + strGlobalListDetail + ".RemoveAll(t => strIds.Split(',').Contains(t." + strDetailKeyId + " .ToString()));");
            sb.AppendLine("                    " + strRetrunListDetail + " =  " + strGlobalListDetail + ";");
            sb.AppendLine("                    objListViewDetail.SetObjects( " + strGlobalListDetail + ");");
            sb.AppendLine("                    objListViewDetail.Refresh();");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            SetMode(EntityOperationType.只读明细);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>撤销明细表操作");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoCancelDetail()");
            sb.AppendLine("        {");
            sb.AppendLine("            objListViewDetail_SelectedIndexChanged(null, null);");
            sb.AppendLine("            SetMode(EntityOperationType.只读明细);");
            sb.AppendLine("        }");

            sb.AppendLine("        #endregion");
            #endregion

            #region 设置按钮跟面板控件的可用性
            sb.AppendLine("        /// <summary>设置按钮跟面板控件的可用性");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"operationType\">操作类型</param>");
            sb.AppendLine("        public void SetMode(EntityOperationType operationType)");
            sb.AppendLine("        {");
            sb.AppendLine("            switch (operationType)");
            sb.AppendLine("            {");
            sb.AppendLine("                case EntityOperationType.新增:");
            sb.AppendLine("                case EntityOperationType.修改:");
            sb.AppendLine("                    m_masterStatus = operationType;");
            sb.AppendLine("                    if (operationType == EntityOperationType.新增)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        ControlManager.ClearAll(grpMaster);");
            sb.AppendLine("                    }");
            sb.AppendLine("                    ControlManager.SetControlEnabled(grpMaster, false);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdSave, cmdCancel }, true);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdNew, cmdDelete, cmdEdit }, false);");
            sb.AppendLine("                    ControlManager.SetControlEnabled(grpMaster, true);");
            sb.AppendLine("                    //新增或者修改主表是，明细不可用，只有保存完主表信息才能操作明细信息");
            sb.AppendLine("                    ControlManager.SetControlEnabled(grpDetail, false);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdSaveDetail, cmdCancelDetail, cmdNewDetail, cmdDeleteDetail, cmdEditDetail }, false);");
            sb.AppendLine("                    break;");

            sb.AppendLine("                case EntityOperationType.只读:");
            sb.AppendLine("                    m_masterStatus = operationType;");
            sb.AppendLine("                    ControlManager.SetControlEnabled(grpMaster, false);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdSave, cmdCancel }, false);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdNew, cmdDelete, cmdEdit }, true);");
            sb.AppendLine("                    SetMode(EntityOperationType.只读明细);");
            sb.AppendLine("                    break;");

            sb.AppendLine("                case EntityOperationType.新增明细:");
            sb.AppendLine("                case EntityOperationType.修改明细:");
            sb.AppendLine("                    m_detailStatus = operationType;");
            sb.AppendLine("                    if (operationType == EntityOperationType.新增明细)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        ControlManager.ClearAll(grpDetail);");
            sb.AppendLine("                    }");
            sb.AppendLine("                    ControlManager.SetControlEnabled(grpDetail, false);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdSaveDetail, cmdCancelDetail }, true);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdNewDetail, cmdDeleteDetail, cmdEditDetail }, false);");
            sb.AppendLine("                    ControlManager.SetControlEnabled(grpDetail, true);");
            sb.AppendLine("                    break;");

            sb.AppendLine("                case EntityOperationType.只读明细:");
            sb.AppendLine("                    m_detailStatus = operationType;");
            sb.AppendLine("                    ControlManager.SetControlEnabled(grpDetail, false);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdSaveDetail, cmdCancelDetail }, false);");
            sb.AppendLine("                    ControlManager.SetBtnEnabled(new Component[] { cmdNewDetail, cmdDeleteDetail, cmdEditDetail }, true);");
            sb.AppendLine("                    break;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            #endregion

            #region 检查合法性
            sb.AppendLine("        /// <summary>检查合法性");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"operationType\">操作类型</param>");
            sb.AppendLine("        /// <returns>错误信息</returns>");
            sb.AppendLine("        private string DoCheckDetail(EntityOperationType operationType)");
            sb.AppendLine("        {");
            sb.AppendLine("            string strMsg = string.Empty;");
            sb.AppendLine("            if (" + strGlobalMasterModelName + " == null || m_masterStatus != EntityOperationType.只读)");
            sb.AppendLine("            {");
            sb.AppendLine("                return \"请先保存主表信息\";");
            sb.AppendLine("            }");
            sb.AppendLine("            if (operationType == EntityOperationType.修改明细)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (this.objListViewDetail.SelectedObjects.Count == 0)");
            sb.AppendLine("                {");
            sb.AppendLine("                    return @\"请先选择要修改的明细\";");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            if (operationType == EntityOperationType.只读明细)");
            sb.AppendLine("              {");
            if (parentChildParameter.CheckInputColumnsDetail.Trim() != string.Empty)
            {
                string[] strColumnArray = parentChildParameter.CheckInputColumnsDetail.Split(',');
                if (strColumnArray.Length > 0)
                {
                    foreach (Bse_UI ui in lstBseUiEditDetail)
                    {
                        if (strColumnArray.Contains(ui.ColumnName))
                        {
                            string strAlertInfo = GenControlHelper.CreateAlertInfo(ui.ColumnName, ui.LabelText, ui.ControlNameSpace,
                                    ui.ControlName);
                            sb.AppendLine(strAlertInfo);
                        }
                    }
                }
            }
            sb.AppendLine("              }");
            sb.AppendLine("            return strMsg;");
            sb.AppendLine("        }");


            sb.AppendLine("        /// <summary>检查合法性");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>错误信息</returns>");
            sb.AppendLine("        private string DoCheckMaster()");
            sb.AppendLine("        {");
            sb.AppendLine("            string strMsg = string.Empty;");
            if (parentChildParameter.CheckInputColumns.Trim() != string.Empty)
            {
                string[] strColumnArray = parentChildParameter.CheckInputColumns.Split(',');
                if (strColumnArray.Length > 0)
                {
                    foreach (Bse_UI ui in lstBseUiEditMaster)
                    {
                        if (strColumnArray.Contains(ui.ColumnName))
                        {
                            string strAlertInfo = GenControlHelper.CreateAlertInfo(ui.ColumnName, ui.LabelText, ui.ControlNameSpace,
                                    ui.ControlName);
                            sb.AppendLine(strAlertInfo);
                        }
                    }
                }
            }
            sb.AppendLine("            return strMsg;");
            sb.AppendLine("        }");



            #endregion

            #region 实体对象值显示至控件
            sb.AppendLine("        /// <summary>实体对象值显示至控件");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"model\">model</param>");
            sb.AppendLine("        private void DisplayData(" + strMasterModelName + " model)");
            sb.AppendLine("        {");
            sb.AppendLine("            EntityOperateManager.BindAll(this.grpMaster, model);");
            sb.AppendLine("        }");

            #endregion

            #region 初始化绑定
            sb.AppendLine("        /// <summary>初始化Master绑定");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitMasterData()");
            sb.AppendLine("        {");
            //sb.AppendLine("            const string strBindSql = "SELECT 2 AS  Name , '管理员' AS  value UNION ALL  SELECT 3 AS  Name , '功城队' AS  value;SELECT 'cbkRemark '";");
            //sb.AppendLine("            BindClass bindClass = new BindClass()");
            //sb.AppendLine("            {");
            //sb.AppendLine("                SqlType = SqlType.SqlServer,");
            //sb.AppendLine("                BindSql = strBindSql");
            //sb.AppendLine("            };");
            //sb.AppendLine("            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn);");
            //sb.AppendLine("            CheckedComboBoxHelper.BindCheckedComboBox(cbkRemark, ds.Tables["cbkRemark"], "value", "Name");");
            string strBindSql = GenControlHelper.GetBindSourceEditSqlByTableName(parentChildParameter.DatabaseTable.Name);
            if (!string.IsNullOrEmpty(strBindSql))
            {
                sb.AppendLine(" const string strBindEditSql=\"" + strBindSql + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindEditSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("DataSet ds =BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn); ");
                sb.AppendLine(GenControlHelper.GenBindDataSouce(parentChildParameter.DatabaseTable.Name, PanelType.编辑面板));
            }
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>初始化Detail绑定");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitDetailData()");
            sb.AppendLine("        {");
            //sb.AppendLine("            const string strBindSql = "SELECT 2 AS  Name , '管理员' AS  value UNION ALL  SELECT 3 AS  Name , '功城队' AS  value;SELECT 'cbkRemark '";");
            //sb.AppendLine("            BindClass bindClass = new BindClass()");
            //sb.AppendLine("            {");
            //sb.AppendLine("                SqlType = SqlType.SqlServer,");
            //sb.AppendLine("                BindSql = strBindSql");
            //sb.AppendLine("            };");
            //sb.AppendLine("            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn);");
            //sb.AppendLine("            CheckedComboBoxHelper.BindCheckedComboBox(cbkRemark, ds.Tables["cbkRemark"], "value", "Name");");
            string strBindSqlDetail = GenControlHelper.GetBindSourceEditSqlByTableName(parentChildParameter.DatabaseTableDetail.Name);
            if (!string.IsNullOrEmpty(strBindSqlDetail))
            {
                sb.AppendLine(" const string strBindEditSql=\"" + strBindSqlDetail + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindEditSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("DataSet ds =BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn); ");
                sb.AppendLine(GenControlHelper.GenBindDataSouce(parentChildParameter.DatabaseTableDetail.Name, PanelType.编辑面板));
            }
            sb.AppendLine("        }");

            //#region DoInitDetailGridSource
            //sb.AppendLine("/// <summary>初始化明细数据源");
            //sb.AppendLine("        ///");
            //sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        private void DoInitDetailGridSource()");
            //sb.AppendLine("        {");
            //string strBindSqlDetailBind = GenControlHelper.GetBindSourceSqlByTableNameForGrid(parentChildParameter.DatabaseTableDetail.Name);
            //if (!string.IsNullOrEmpty(strBindSqlDetailBind))
            //{
            //    sb.AppendLine(" const string strBindSql=\"" + strBindSqlDetailBind + "\";");
            //    sb.AppendLine("  BindClass bindClass = new BindClass()");
            //    sb.AppendLine("  {");
            //    sb.AppendLine("     SqlType = SqlType.SqlServer,");
            //    sb.AppendLine("      BindSql =strBindSql");
            //    sb.AppendLine("   }; ");
            //    sb.AppendLine("            m_dsDetailGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn);");
            //}
            //sb.AppendLine("        }");
            //#endregion

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

            sb.AppendLine("        #endregion");
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
            string strFrmClassName = "Frm" + parentChildParameter.DatabaseTable.Name + "MasterDetailDialog";
            string strMasterDalName = parentChildParameter.DatabaseTable.Name + "DAL";
            string strDetailDalName = parentChildParameter.DatabaseTableDetail.Name + "DAL";
            string strMasterModelName = parentChildParameter.DatabaseTable.Name;
            string strDetailModelName = parentChildParameter.DatabaseTableDetail.Name;
            string strMasterKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTable.Name, parameter.Conn);
            string strDetailKeyId = Tools.GetPKey_MSSQL(parentChildParameter.DatabaseTableDetail.Name, parameter.Conn);
            string strRetrunListMaster = "List" + strMasterModelName + " ";
            string strRetrunListDetail = "List" + strDetailModelName + " ";
            string strGlobalListMaster = "m_lst" + strMasterModelName.Replace("_", "");
            string strGlobalListDetail = "m_lst" + strDetailModelName.Replace("_", "");
            string strParentId = parentChildParameter.KeyMaster;
            string strChildId = parentChildParameter.KeyDetail;
            string strGlobalMasterModelName = " m_" + strMasterModelName + " ";
            string strGlobalDetailModelName = " m_" + strDetailModelName + " ";
            List<Bse_UI> lstBseUiQueryMaster = BseUIManager.GetListUIQuery(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiShowMaster = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiEditMaster = BseUIManager.GetListUIEdit(parentChildParameter.DatabaseTable.Name);
            List<Bse_UI> lstBseUiEditDetail = BseUIManager.GetListUIEdit(parentChildParameter.DatabaseTableDetail.Name);
            List<Bse_UI> lstBseUiShowDetail = BseUIManager.GetListUIShow(parentChildParameter.DatabaseTableDetail.Name);
            int lblWidth = BseUIManager.GetCtlWidth("Label");
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
            sb.AppendLine("            this.tspCommand = new System.Windows.Forms.ToolStrip();");
            sb.AppendLine("            this.cmdNew = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdEdit = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdSave = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdDelete = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdCancel = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.sptAll = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.grpMaster = new System.Windows.Forms.GroupBox();");
            #region 编辑面板控件
            foreach (Bse_UI ui in lstBseUiEditMaster)
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
            //sb.AppendLine("            this.txtEditOrderNumber = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblQueryName = new System.Windows.Forms.Label();");
            sb.AppendLine("            this.tabControl1 = new System.Windows.Forms.TabControl();");
            sb.AppendLine("            this.tabPage = new System.Windows.Forms.TabPage();");
            sb.AppendLine("            this.sptDetail = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.objListViewDetail = new Nikita.WinForm.ExtendControl.FastObjectListView();");
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
            //sb.AppendLine("            this.olvColumn5 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn6 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn7 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn8 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn9 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn10 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            //sb.AppendLine("            this.olvColumn11 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            sb.AppendLine("            this.grpDetail = new System.Windows.Forms.GroupBox();");
            #region 编辑面板控件
            foreach (Bse_UI ui in lstBseUiEditDetail)
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
            //sb.AppendLine("            this.txtDetailSumMoney = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblDetailSumMoney = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.txtDetailAmount = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblDetailAmount = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.txtDetailProductName = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblDetailProductName = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.txtDetailCustomer = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblDetailCustomer = new System.Windows.Forms.Label();");
            sb.AppendLine("            this.tspCommandDetail = new System.Windows.Forms.ToolStrip();");
            sb.AppendLine("            this.cmdNewDetail = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdEditDetail = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdSaveDetail = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdDeleteDetail = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdCancelDetail = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.tspCommand.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).BeginInit();");
            sb.AppendLine("            this.sptAll.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptAll.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptAll.SuspendLayout();");
            sb.AppendLine("            this.grpMaster.SuspendLayout();");
            sb.AppendLine("            this.tabControl1.SuspendLayout();");
            sb.AppendLine("            this.tabPage.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptDetail)).BeginInit();");
            sb.AppendLine("            this.sptDetail.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptDetail.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptDetail.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).BeginInit();");
            sb.AppendLine("            this.grpDetail.SuspendLayout();");
            sb.AppendLine("            this.tspCommandDetail.SuspendLayout();");
            foreach (Bse_UI ui in lstBseUiEditMaster)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).BeginInit();");
                }
            }
            foreach (Bse_UI ui in lstBseUiEditDetail)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).BeginInit();");
                }
            }
            sb.AppendLine("            this.SuspendLayout();");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tspCommand");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tspCommand.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;");
            sb.AppendLine("            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {");
            sb.AppendLine("            this.cmdNew,");
            sb.AppendLine("            this.cmdEdit,");
            sb.AppendLine("            this.cmdSave,");
            sb.AppendLine("            this.cmdDelete,");
            sb.AppendLine("            this.cmdCancel});");
            sb.AppendLine("            this.tspCommand.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.tspCommand.Name = \"tspCommand\";");
            sb.AppendLine("            this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;");
            sb.AppendLine("            this.tspCommand.Size = new System.Drawing.Size(784, 26);");
            sb.AppendLine("            this.tspCommand.TabIndex = 8;");
            sb.AppendLine("            this.tspCommand.Text = \"toolStrip1 \";");
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
            sb.AppendLine("            // cmdEdit");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdEdit.Name = \"cmdEdit\";");
            sb.AppendLine("            this.cmdEdit.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdEdit.Text = \"修改\";");
            sb.AppendLine("            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdSave");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdSave.Name = \"cmdSave\";");
            sb.AppendLine("            this.cmdSave.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdSave.Text = \"保存\";");
            sb.AppendLine("            this.cmdSave.Click += new System.EventHandler(this.Command_Click);");
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
            sb.AppendLine("            // cmdCancel");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdCancel.Name = \"cmdCancel\";");
            sb.AppendLine("            this.cmdCancel.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdCancel.Text = \"撤销\";");
            sb.AppendLine("            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;");
            sb.AppendLine("            this.sptAll.Location = new System.Drawing.Point(0, 26);");
            sb.AppendLine("            this.sptAll.Name = \"sptAll\";");
            sb.AppendLine("            this.sptAll.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Panel1.Controls.Add(this.grpMaster);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Panel2.Controls.Add(this.tabControl1);");
            sb.AppendLine("            this.sptAll.Size = new System.Drawing.Size(784, 535);");
            sb.AppendLine("            this.sptAll.SplitterDistance = 134;");
            sb.AppendLine("            this.sptAll.TabIndex = 9;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // grpMaster");
            sb.AppendLine("            // ");
            foreach (Bse_UI ui in lstBseUiEditMaster)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("  this.grpMaster.Controls.Add(this." + ui.LabelName + ");");
                    sb.AppendLine("         this.grpMaster.Controls.Add(this." + ui.ControlName + ");");
                }
                else
                {
                    sb.AppendLine("         this.grpMaster.Controls.Add(this." + ui.ControlName + ");");
                }
            }
            //sb.AppendLine("            this.grpMaster.Controls.Add(this.txtEditOrderNumber);");
            //sb.AppendLine("            this.grpMaster.Controls.Add(this.lblQueryName);");
            sb.AppendLine("            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.grpMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
            sb.AppendLine("            this.grpMaster.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.grpMaster.Name = \"grpMaster\";");
            sb.AppendLine("            this.grpMaster.Size = new System.Drawing.Size(784, 134);");
            sb.AppendLine("            this.grpMaster.TabIndex = 0;");
            sb.AppendLine("            this.grpMaster.TabStop = false;");
            sb.AppendLine("            this.grpMaster.Text = \"主表信息\";");
            #region 编辑区控件明细位置

            BeginWidth = 15;
            foreach (Bse_UI ui in lstBseUiEditMaster)
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
            int hightMaster = QueryHeight * (HighSeed + 5) + 30;
            if (hightMaster < 87)
            {
                hightMaster = 87;
            }
            sb.Replace("@QueryHeight@", hightMaster.ToString());

            #endregion
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtEditOrderNumber");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtEditOrderNumber.Location = new System.Drawing.Point(65, 22);");
            //sb.AppendLine("            this.txtEditOrderNumber.Name = "txtEditOrderNumber";");
            //sb.AppendLine("            this.txtEditOrderNumber.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtEditOrderNumber.TabIndex = 3;");
            //sb.AppendLine("            this.txtEditOrderNumber.Tag = "OrderNumber";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblQueryName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblQueryName.AutoSize = true;");
            //sb.AppendLine("            this.lblQueryName.Location = new System.Drawing.Point(16, 25);");
            //sb.AppendLine("            this.lblQueryName.Name = "lblQueryName";");
            //sb.AppendLine("            this.lblQueryName.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblQueryName.TabIndex = 2;");
            //sb.AppendLine("            this.lblQueryName.Text = "单号";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tabControl1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tabControl1.Controls.Add(this.tabPage);");
            sb.AppendLine("            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.tabControl1.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.tabControl1.Name = \"tabControl1\";");
            sb.AppendLine("            this.tabControl1.SelectedIndex = 0;");
            sb.AppendLine("            this.tabControl1.Size = new System.Drawing.Size(784, 397);");
            sb.AppendLine("            this.tabControl1.TabIndex = 0;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tabPage");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tabPage.Controls.Add(this.sptDetail);");
            sb.AppendLine("            this.tabPage.Location = new System.Drawing.Point(4, 26);");
            sb.AppendLine("            this.tabPage.Name = \"tabPage\";");
            sb.AppendLine("            this.tabPage.Padding = new System.Windows.Forms.Padding(3);");
            sb.AppendLine("            this.tabPage.Size = new System.Drawing.Size(776, 367);");
            sb.AppendLine("            this.tabPage.TabIndex = 0;");
            sb.AppendLine("            this.tabPage.Text = \"明细表信息\";");
            sb.AppendLine("            this.tabPage.UseVisualStyleBackColor = true;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.sptDetail.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptDetail.Location = new System.Drawing.Point(3, 3);");
            sb.AppendLine("            this.sptDetail.Name = \"sptDetail\";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptDetail.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptDetail.Panel1.Controls.Add(this.objListViewDetail);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptDetail.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptDetail.Panel2.Controls.Add(this.grpDetail);");
            sb.AppendLine("            this.sptDetail.Panel2.Controls.Add(this.tspCommandDetail);");
            sb.AppendLine("            this.sptDetail.Size = new System.Drawing.Size(770, 361);");
            sb.AppendLine("            this.sptDetail.SplitterDistance = 436;");
            sb.AppendLine("            this.sptDetail.TabIndex = 1;");
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
            #endregion
            //sb.AppendLine("            this.olvColumn5,");
            //sb.AppendLine("            this.olvColumn6,");
            //sb.AppendLine("            this.olvColumn7,");
            //sb.AppendLine("            this.olvColumn8,");
            //sb.AppendLine("            this.olvColumn9,");
            //sb.AppendLine("            this.olvColumn10,");
            //sb.AppendLine("            this.olvColumn11" );
            sb.AppendLine("});");
            sb.AppendLine("            this.objListViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.objListViewDetail.FullRowSelect = true;");
            sb.AppendLine("            this.objListViewDetail.GridLines = true;");
            sb.AppendLine("            this.objListViewDetail.HideSelection = false;");
            sb.AppendLine("            this.objListViewDetail.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.objListViewDetail.Name = \"objListViewDetail\";");
            sb.AppendLine("            this.objListViewDetail.OwnerDraw = true;");
            sb.AppendLine("            this.objListViewDetail.SelectColumnsOnRightClickBehaviour = Nikita.WinForm.ExtendControl.ObjectListView.ColumnSelectBehaviour.Submenu;");
            sb.AppendLine("            this.objListViewDetail.ShowCommandMenuOnRightClick = true;");
            sb.AppendLine("            this.objListViewDetail.ShowGroups = false;");
            sb.AppendLine("            this.objListViewDetail.ShowItemToolTips = true;");
            sb.AppendLine("            this.objListViewDetail.Size = new System.Drawing.Size(434, 359);");
            sb.AppendLine("            this.objListViewDetail.TabIndex = 2;");
            sb.AppendLine("            this.objListViewDetail.UseCompatibleStateImageBehavior = false;");
            sb.AppendLine("            this.objListViewDetail.UseFilterIndicator = true;");
            sb.AppendLine("            this.objListViewDetail.UseFiltering = true;");
            sb.AppendLine("            this.objListViewDetail.View = System.Windows.Forms.View.Details;");
            sb.AppendLine("            this.objListViewDetail.VirtualMode = true;");
            sb.AppendLine("            this.objListViewDetail.SelectedIndexChanged += new System.EventHandler(this.objListViewDetail_SelectedIndexChanged);");
            #region Detail显示区列
            foreach (Bse_UI ui in lstBseUiShowDetail)
            {
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
            //sb.AppendLine("            this.olvColumn5.AspectName = "";");
            //sb.AppendLine("            this.olvColumn5.Text = "明细ID";");
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
            sb.AppendLine("            // grpDetail");
            sb.AppendLine("            // ");
            foreach (Bse_UI ui in lstBseUiEditDetail)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("  this.grpDetail.Controls.Add(this." + ui.LabelName + ");");
                    sb.AppendLine("         this.grpDetail.Controls.Add(this." + ui.ControlName + ");");
                }
                else
                {
                    sb.AppendLine("         this.grpDetail.Controls.Add(this." + ui.ControlName + ");");
                }
            }
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.txtDetailSumMoney);");
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.lblDetailSumMoney);");
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.txtDetailAmount);");
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.lblDetailAmount);");
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.txtDetailProductName);");
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.lblDetailProductName);");
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.txtDetailCustomer);");
            //sb.AppendLine("            this.grpDetail.Controls.Add(this.lblDetailCustomer);");
            sb.AppendLine("            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.grpDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
            sb.AppendLine("            this.grpDetail.Location = new System.Drawing.Point(0, 26);");
            sb.AppendLine("            this.grpDetail.Margin = new System.Windows.Forms.Padding(0);");
            sb.AppendLine("            this.grpDetail.Name = \"grpDetail\";");
            sb.AppendLine("            this.grpDetail.Padding = new System.Windows.Forms.Padding(0);");
            sb.AppendLine("            this.grpDetail.Size = new System.Drawing.Size(328, 333);");
            sb.AppendLine("            this.grpDetail.TabIndex = 1;");
            sb.AppendLine("            this.grpDetail.TabStop = false;");
            #region 编辑区控件明细位置

            BeginWidth = 15;
            foreach (Bse_UI ui in lstBseUiEditDetail)
            {
                int intCurrCtlWidth = BseUIManager.GetCtlWidth(ui.ControlType);
                if (ui.IsAddLable == "True")
                {
                    //控制位置
                    if (BeginWidth + lblWidth + intCurrCtlWidth > SumWidthDetail)
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
            int hightDetail = QueryHeight * (HighSeed + 5) + 30;
            if (hightDetail < 87)
            {
                hightDetail = 87;
            }
            sb.Replace("@QueryHeight@", hightDetail.ToString());

            #endregion
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtDetailSumMoney");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtDetailSumMoney.Location = new System.Drawing.Point(211, 54);");
            //sb.AppendLine("            this.txtDetailSumMoney.Name = "txtDetailSumMoney";");
            //sb.AppendLine("            this.txtDetailSumMoney.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtDetailSumMoney.TabIndex = 11;");
            //sb.AppendLine("            this.txtDetailSumMoney.Tag = "SumMoney";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblDetailSumMoney");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblDetailSumMoney.AutoSize = true;");
            //sb.AppendLine("            this.lblDetailSumMoney.Location = new System.Drawing.Point(170, 54);");
            //sb.AppendLine("            this.lblDetailSumMoney.Name = "lblDetailSumMoney";");
            //sb.AppendLine("            this.lblDetailSumMoney.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblDetailSumMoney.TabIndex = 10;");
            //sb.AppendLine("            this.lblDetailSumMoney.Text = "金额";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtDetailAmount");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtDetailAmount.Location = new System.Drawing.Point(52, 57);");
            //sb.AppendLine("            this.txtDetailAmount.Name = "txtDetailAmount";");
            //sb.AppendLine("            this.txtDetailAmount.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtDetailAmount.TabIndex = 9;");
            //sb.AppendLine("            this.txtDetailAmount.Tag = "Amount";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblDetailAmount");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblDetailAmount.AutoSize = true;");
            //sb.AppendLine("            this.lblDetailAmount.Location = new System.Drawing.Point(11, 57);");
            //sb.AppendLine("            this.lblDetailAmount.Name = "lblDetailAmount";");
            //sb.AppendLine("            this.lblDetailAmount.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblDetailAmount.TabIndex = 8;");
            //sb.AppendLine("            this.lblDetailAmount.Text = "数量";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtDetailProductName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtDetailProductName.Location = new System.Drawing.Point(211, 17);");
            //sb.AppendLine("            this.txtDetailProductName.Name = "txtDetailProductName";");
            //sb.AppendLine("            this.txtDetailProductName.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtDetailProductName.TabIndex = 7;");
            //sb.AppendLine("            this.txtDetailProductName.Tag = "ProductName";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblDetailProductName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblDetailProductName.AutoSize = true;");
            //sb.AppendLine("            this.lblDetailProductName.Location = new System.Drawing.Point(170, 17);");
            //sb.AppendLine("            this.lblDetailProductName.Name = "lblDetailProductName";");
            //sb.AppendLine("            this.lblDetailProductName.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblDetailProductName.TabIndex = 6;");
            //sb.AppendLine("            this.lblDetailProductName.Text = "产品";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtDetailCustomer");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtDetailCustomer.Location = new System.Drawing.Point(52, 17);");
            //sb.AppendLine("            this.txtDetailCustomer.Name = "txtDetailCustomer";");
            //sb.AppendLine("            this.txtDetailCustomer.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtDetailCustomer.TabIndex = 5;");
            //sb.AppendLine("            this.txtDetailCustomer.Tag = "Customer";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblDetailCustomer");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblDetailCustomer.AutoSize = true;");
            //sb.AppendLine("            this.lblDetailCustomer.Location = new System.Drawing.Point(11, 17);");
            //sb.AppendLine("            this.lblDetailCustomer.Name = "lblDetailCustomer";");
            //sb.AppendLine("            this.lblDetailCustomer.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblDetailCustomer.TabIndex = 4;");
            //sb.AppendLine("            this.lblDetailCustomer.Text = "客户";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tspCommandDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tspCommandDetail.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.tspCommandDetail.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;");
            sb.AppendLine("            this.tspCommandDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {");
            sb.AppendLine("            this.cmdNewDetail,");
            sb.AppendLine("            this.cmdEditDetail,");
            sb.AppendLine("            this.cmdSaveDetail,");
            sb.AppendLine("            this.cmdDeleteDetail,");
            sb.AppendLine("            this.cmdCancelDetail});");
            sb.AppendLine("            this.tspCommandDetail.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.tspCommandDetail.Name = \"tspCommandDetail\";");
            sb.AppendLine("            this.tspCommandDetail.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;");
            sb.AppendLine("            this.tspCommandDetail.Size = new System.Drawing.Size(328, 26);");
            sb.AppendLine("            this.tspCommandDetail.TabIndex = 14;");
            sb.AppendLine("            this.tspCommandDetail.Text = \"toolStrip1 \";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdNewDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdNewDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdNewDetail.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdNewDetail.Name = \"cmdNewDetail\";");
            sb.AppendLine("            this.cmdNewDetail.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdNewDetail.Text = \"新增\";");
            sb.AppendLine("            this.cmdNewDetail.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdEditDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdEditDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdEditDetail.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdEditDetail.Name = \"cmdEditDetail\";");
            sb.AppendLine("            this.cmdEditDetail.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdEditDetail.Text = \"修改\";");
            sb.AppendLine("            this.cmdEditDetail.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdSaveDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdSaveDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdSaveDetail.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdSaveDetail.Name = \"cmdSaveDetail\";");
            sb.AppendLine("            this.cmdSaveDetail.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdSaveDetail.Text = \"保存\";");
            sb.AppendLine("            this.cmdSaveDetail.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdDeleteDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdDeleteDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdDeleteDetail.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdDeleteDetail.Name = \"cmdDeleteDetail\";");
            sb.AppendLine("            this.cmdDeleteDetail.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdDeleteDetail.Text = \"删除\";");
            sb.AppendLine("            this.cmdDeleteDetail.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdCancelDetail");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdCancelDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdCancelDetail.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdCancelDetail.Name = \"cmdCancelDetail\";");
            sb.AppendLine("            this.cmdCancelDetail.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdCancelDetail.Text = \"撤销\";");
            sb.AppendLine("            this.cmdCancelDetail.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // FrmMasterDetailDemoDialog");
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
            sb.AppendLine("            this.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            this.tspCommand.ResumeLayout(false);");
            sb.AppendLine("            this.tspCommand.PerformLayout();");
            sb.AppendLine("            this.sptAll.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptAll.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).EndInit();");
            sb.AppendLine("            this.sptAll.ResumeLayout(false);");
            sb.AppendLine("            this.grpMaster.ResumeLayout(false);");
            sb.AppendLine("            this.grpMaster.PerformLayout();");
            sb.AppendLine("            this.tabControl1.ResumeLayout(false);");
            sb.AppendLine("            this.tabPage.ResumeLayout(false);");
            sb.AppendLine("            this.sptDetail.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptDetail.Panel2.ResumeLayout(false);");
            sb.AppendLine("            this.sptDetail.Panel2.PerformLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptDetail)).EndInit();");
            sb.AppendLine("            this.sptDetail.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.objListViewDetail)).EndInit();");
            sb.AppendLine("            this.grpDetail.ResumeLayout(false);");
            sb.AppendLine("            this.grpDetail.PerformLayout();");
            sb.AppendLine("            this.tspCommandDetail.ResumeLayout(false);");
            sb.AppendLine("            this.tspCommandDetail.PerformLayout();");
            sb.AppendLine("            this.ResumeLayout(false);");
            foreach (Bse_UI ui in lstBseUiEditMaster)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).EndInit();");
                }
            }
            foreach (Bse_UI ui in lstBseUiEditDetail)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).EndInit();");
                }
            }
            sb.AppendLine("            this.PerformLayout();");
            sb.AppendLine("        }");
            sb.AppendLine("     #endregion");

            sb.AppendLine("        private System.Windows.Forms.ToolStrip tspCommand;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdDelete;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdEdit;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdNew;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdSave;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptAll;");
            sb.AppendLine("        private System.Windows.Forms.GroupBox grpMaster;");
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtEditOrderNumber;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblQueryName;");
            foreach (Bse_UI ui in lstBseUiEditMaster)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("        private " + ui.ControlNameSpace + "  " + ui.ControlName + ";");
                    sb.AppendLine("        private System.Windows.Forms.Label " + ui.LabelName + ";");
                }
                else
                {
                    sb.AppendLine("        private System.Windows.Forms.TextBox " + ui.ControlName + ";");
                }
            }
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdCancel;");
            sb.AppendLine("        private System.Windows.Forms.TabControl tabControl1;");
            sb.AppendLine("        private System.Windows.Forms.TabPage tabPage;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptDetail;");
            sb.AppendLine("        private WinForm.ExtendControl.FastObjectListView objListViewDetail;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn5;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn6;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn7;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn8;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn9;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn10;");
            //sb.AppendLine("        private WinForm.ExtendControl.OLVColumn olvColumn11;");
            foreach (Bse_UI ui in lstBseUiShowDetail)
            {
                sb.AppendLine("        private WinForm.ExtendControl.OLVColumn " + ui.ControlName + ";");
            }
            sb.AppendLine("        private System.Windows.Forms.GroupBox grpDetail;");
            foreach (Bse_UI ui in lstBseUiEditDetail)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("        private " + ui.ControlNameSpace + "  " + ui.ControlName + ";");
                    sb.AppendLine("        private System.Windows.Forms.Label " + ui.LabelName + ";");
                }
                else
                {
                    sb.AppendLine("        private System.Windows.Forms.TextBox " + ui.ControlName + ";");
                }
            }
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtDetailSumMoney;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblDetailSumMoney;");
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtDetailAmount;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblDetailAmount;");
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtDetailProductName;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblDetailProductName;");
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtDetailCustomer;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblDetailCustomer;");
            sb.AppendLine("        private System.Windows.Forms.ToolStrip tspCommandDetail;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdNewDetail;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdEditDetail;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdSaveDetail;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdDeleteDetail;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdCancelDetail;");

            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();

        }

    }
}