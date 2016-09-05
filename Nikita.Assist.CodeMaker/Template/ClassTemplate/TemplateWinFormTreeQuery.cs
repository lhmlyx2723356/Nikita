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
    public class TemplateWinFormTreeQuery :CodeMakeBulider
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
            TreeEditDialogParameter treeParameter = baseParameter as TreeEditDialogParameter;
            string strFrmClassName = "Frm" + parameter.ClassName + "TreeQuery";
            string strFrmDialogClassName = "Frm" + parameter.ClassName + "TreeDialog";
            string strDalName = parameter.TableName + "DAL";
            string strModelName = parameter.TableName;
            string strKeyId = Tools.GetPKey_MSSQL(parameter.TableName, parameter.Conn);
            string strRetrunList = "List" + strModelName + " ";
            string strGlobalList = "m_lst" + strModelName.Replace("_", "");
            string strParentID = treeParameter.ParentId;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/// <summary>说明:" + strFrmClassName + "文件");
            sb.AppendLine("/// 作者:" + parameter.Author + "");
            sb.AppendLine("/// 创建时间:" + DateTime.Now + "");
            sb.AppendLine("/// </summary>");
            sb.AppendLine("using " + parameter.NameSpace + ".DAL;");
            sb.AppendLine("using " + parameter.NameSpace + ".Model;");
            sb.AppendLine("using Nikita.Core;");
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
            sb.AppendLine("using Nikita.Core.WinForm;");
            sb.AppendLine("using Nikita.Core.NPOIs;");
            sb.AppendLine("using Nikita.Core.Images;");
            sb.AppendLine("using Nikita.Core.Autofac;");
            sb.AppendLine("using Nikita.Core.XML;");
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
            sb.AppendLine("  /// <summary>DataGridView下拉框绑定数据源");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private DataSet m_dsGridSource;");
            sb.AppendLine("        /// <summary>操作类");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        private " + strDalName + " m_" + strDalName + "; "); 
            sb.AppendLine("        private IBseDAL<" + strModelName + "> m_" + strDalName + "; ");

            sb.AppendLine("        /// <summary>绑定集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private List<" + strModelName + ">  " + strGlobalList + "  ;");
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
            //sb.AppendLine("            m_" + strDalName + "= new  " + strDalName + "();"); 
            sb.AppendLine(" m_" + strDalName + " = GlobalHelp.GetResolve<IBseDAL<" + strModelName + ">>();");
            sb.AppendLine("            this.dataTreeListView.RootKeyValue = 0u;");
            sb.AppendLine("            DoInitData();");
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
            sb.AppendLine("       try");
            sb.AppendLine("            {");
            sb.AppendLine("                btnQuery.Enabled = false;");
            sb.AppendLine("                DoQueryData();");
            sb.AppendLine("            }");
            sb.AppendLine("            finally");
            sb.AppendLine("            {");
            sb.AppendLine("                btnQuery.Enabled = true;");
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
            sb.AppendLine("            this.dataTreeListView.TimedFilter(txtFilter.Text);");
            sb.AppendLine("        }");
            #endregion
            #region Command_Click
            sb.AppendLine("        /// <summary>执行命令");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void Command_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("    ToolStripItem cmdItem = sender as ToolStripItem;");
            sb.AppendLine("            if (cmdItem != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                try");
            sb.AppendLine("                {");
            sb.AppendLine("                    cmdItem.Enabled = false;");
            sb.AppendLine("                    switch (cmdItem.Name.Trim())");
            sb.AppendLine("                    {");
            sb.AppendLine("                        case \"cmdRefresh\":");
            sb.AppendLine("                            DoQueryData();");
            sb.AppendLine("                            break;");
            sb.AppendLine("                        case \"cmdNewSameLevel\":");
            sb.AppendLine("                        case \"cmdNewNextLevel\":");
            sb.AppendLine("                            DoNew(cmdItem.Name.Trim());");
            sb.AppendLine("                            break;");
            sb.AppendLine("                        case \"cmdEdit\":");
            sb.AppendLine("                            DoEdit();");
            sb.AppendLine("                            break;");
            sb.AppendLine("                        case \"cmdDelete\":");
            sb.AppendLine("                            DoDeleteOrCancel(\"删除\");");
            sb.AppendLine("                            break;");
            sb.AppendLine("                        case \"cmdCancel\":");
            sb.AppendLine("                            DoDeleteOrCancel(\"作废\");");
            sb.AppendLine("                            break;");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("                finally");
            sb.AppendLine("                {");
            sb.AppendLine("                    cmdItem.Enabled = true;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("         ");
            #endregion
            //#region  grdData_CellDoubleClick
            //if (baseParameter.CodeGenType == CodeGenType.WinFromTreeEditWithDialog)
            //{
            //    sb.AppendLine("  private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)");
            //    sb.AppendLine("        {");
            //    sb.AppendLine("            Command_Click(cmdEdit, null);");
            //    sb.AppendLine("        }");
            //    sb.AppendLine("        ");
            //}
            //#endregion
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
            #region MouseDoubleClick
            sb.AppendLine("        /// <summary>双击修改");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void dataTreeListView_MouseDoubleClick(object sender, MouseEventArgs e)");
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
            #region DoInitData
            sb.AppendLine("        /// <summary>初始化绑定下拉框等");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitData()");
            sb.AppendLine("        { ");
            string strBindSql = GenControlHelper.GetBindSourceSqlByTableName(parameter.TableName);
            if (!string.IsNullOrEmpty(strBindSql))
            {
                sb.AppendLine(" const string strBindSql=\"" + strBindSql + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("DataSet ds =BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn); ");
                sb.AppendLine(GenControlHelper.GenBindDataSouce(parameter.TableName,PanelType.查询面板));
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
            #region DoQueryData
            sb.AppendLine("        /// <summary>执行查询");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoQueryData()");
            sb.AppendLine("        {");
            sb.AppendLine("    try");
            sb.AppendLine("            {");
            sb.AppendLine("                btnQuery.Enabled = false;");
            sb.AppendLine("            string strWhere = GetSearchSql();");
            sb.AppendLine("        " + strGlobalList + " =   m_" + strDalName + ".GetListArray(\"*\", \"" + strKeyId + "\", \"ASC\", Pager.PageSize, Pager.PageIndex, strWhere);");
            sb.AppendLine("            Pager.RecordCount = m_" + strDalName + ".CalcCount(strWhere);");
            sb.AppendLine("            Pager.InitPageInfo();");
            sb.AppendLine("            dataTreeListView.DataSource =    " + strGlobalList + ";");
            sb.AppendLine("            }");
            sb.AppendLine("       catch (Exception)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw;");
            sb.AppendLine("            }");
            sb.AppendLine("            finally");
            sb.AppendLine("            { ");
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
            sb.AppendLine(SearchConditionHelper.GetSearchCondition(parameter.TableName));
            //sb.AppendLine("            SearchCondition condition = new SearchCondition();");
            //sb.AppendLine("            condition.AddCondition(\"UserName\", this.txtQueryUserName.Text, SqlOperator.Like)");
            //sb.AppendLine("                .AddCondition(\"TrueName\", cboQueryTrueName.Text, SqlOperator.Like)");
            //sb.AppendLine("                .AddCondition(\"User_Id\",  cbkID.CheckedItemValues.TrimEnd(','), SqlOperator.In);");
            //sb.AppendLine("            return condition.BuildConditionSql().Replace(\"Where\", \"\");");
            sb.AppendLine("        }");
            #endregion

            if (baseParameter.CodeGenType == CodeGenType.WinFromTreeEditWithDialog)
            {
                #region DoDeleteOrCancel
                sb.AppendLine("        /// <summary>删除/作废");
                sb.AppendLine("        /// ");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        /// <param name=\"strOperation\">操作类型</param>");
                sb.AppendLine("        private void DoDeleteOrCancel(string strOperation)");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = CheckSelect(strOperation);");
                sb.AppendLine("            if (strMsg != string.Empty)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(strMsg);");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("     if (MessageBox.Show(string.Format(\"选中的对象如果存在下级，也会一起{0}，是否继续操作？\", strOperation), @\"提示\", MessageBoxButtons.YesNo) != DialogResult.Yes)");
                sb.AppendLine("            {");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("            IList objList = this.dataTreeListView.SelectedObjects;");
                sb.AppendLine("            List<" + strModelName + "> lstModels = new List<" + strModelName + ">();");
                sb.AppendLine("            dataTreeListView.GetAllChildrensWithSelfByCollection(objList, ref lstModels);");
                sb.AppendLine("            string strIds = lstModels.Aggregate(string.Empty, (current, item) => current + item." + strKeyId + " + \";\");");
                sb.AppendLine("            strIds = strIds.TrimEnd(',');");
                sb.AppendLine("            var blnReturn = strOperation.Trim() == \"删除\" ?   m_" + strDalName + ".DeleteByCond(\" " + strKeyId + " in (\" + strIds + \")\") :    m_" + strDalName + ".Update(\"Status =0\", \" " + strKeyId + " in (\" + strIds + \")\");");
                sb.AppendLine("            if (blnReturn)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(string.Format(\"{0}成功\", strOperation)); ");
                sb.AppendLine("               dataTreeListView.RemoveObjects(objList);");
                sb.AppendLine("            }");
                sb.AppendLine("            else");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(string.Format(\"{0}失败\", strOperation));");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                #endregion
                #region DoEdit
                sb.AppendLine("        /// <summary>编辑");
                sb.AppendLine("        ///");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        private void DoEdit()");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = CheckSelect(\"修改\");");
                sb.AppendLine("            if (strMsg != string.Empty)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(strMsg);");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("    " + strModelName + " model = dataTreeListView.SelectedObjects[0] as  " + strModelName + ";");
                sb.AppendLine("            if (model != null)");
                sb.AppendLine("            {");
                sb.AppendLine("                " + strFrmDialogClassName + " frmDialog = new       " + strFrmDialogClassName + "(model, 0,  " + strGlobalList + ");");
                sb.AppendLine("                if (frmDialog.ShowDialog() == DialogResult.OK)");
                sb.AppendLine("                {");
                sb.AppendLine("                       " + strGlobalList + " = frmDialog." + strRetrunList + ";");
                sb.AppendLine("                    dataTreeListView.DataSource =   " + strGlobalList + ";");
                sb.AppendLine("                    dataTreeListView.Refresh();");
                sb.AppendLine("                }");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                #endregion
                #region DoNew
                sb.AppendLine("        /// <summary>新增");
                sb.AppendLine("        ///");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        private void DoNew(string strOperation)");
                sb.AppendLine("        {");
                sb.AppendLine("    string strMsg = CheckSelect(\"新增等级\");");
                sb.AppendLine("            if (strMsg != string.Empty)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(strMsg);");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("            int intParentId = 0;");
                sb.AppendLine("             " + strModelName + " model = dataTreeListView.SelectedObjects[0] as " + strModelName + ";");
                sb.AppendLine("            if (model != null)");
                sb.AppendLine("            {");
                sb.AppendLine("                intParentId = strOperation == \"cmdNewSameLevel\" ? model." + strParentID + " : model." + strKeyId + ";");
                sb.AppendLine("            }");
                sb.AppendLine("              " + strFrmDialogClassName + " frmDialog = new   " + strFrmDialogClassName + "(null,intParentId," + strGlobalList + ");");
                sb.AppendLine("            if (frmDialog.ShowDialog() == DialogResult.OK)");
                sb.AppendLine("            {");
                sb.AppendLine("                " + strGlobalList + " = frmDialog." + strRetrunList + ";");
                sb.AppendLine("                dataTreeListView.DataSource = " + strGlobalList + ";");
                sb.AppendLine("                dataTreeListView.Refresh();");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                #endregion
                #region CheckSelect
                sb.AppendLine("         ");
                sb.AppendLine("        /// <summary>检查选择");
                sb.AppendLine("        /// ");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        /// <param name=\"strOperation\">操作说明</param>");
                sb.AppendLine("        /// <returns>返回提示信息</returns>");
                sb.AppendLine("        private string CheckSelect(string strOperation)");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = string.Empty;");
                sb.AppendLine("        if (dataTreeListView.SelectedObjects.Count == 0 && " + strGlobalList + " != null && " + strGlobalList + ".Count>0)");
                sb.AppendLine("            {");
                sb.AppendLine("                strMsg = string.Format(\"请选择要{0}的行数据\", strOperation);");
                sb.AppendLine("            }");
                sb.AppendLine("            return strMsg;");
                sb.AppendLine("        }");
                #endregion
            }

            sb.AppendLine("        #endregion");
            #endregion
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string GenWinFormDesign(BasicParameter parameter, BaseParameter baseParameter)
        {
            TreeEditDialogParameter treeParameter = baseParameter as TreeEditDialogParameter;
            string strFrmClassName = "Frm" + parameter.ClassName + "TreeQuery";
            List<Bse_UI> lstBseUiQuery = BseUIManager.GetListUIQuery(parameter.TableName);
            List<Bse_UI> lstBseUiShow = BseUIManager.GetListUIShow(parameter.TableName);
            int lblWidth = BseUIManager.GetCtlWidth("Label");
            string strKeyId = Tools.GetPKey_MSSQL(parameter.TableName, parameter.Conn);
            string strParentId = treeParameter.ParentId;
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
            sb.AppendLine("            this.components = new System.ComponentModel.Container();");
            sb.AppendLine("            this.sptContainer = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.sptQuery = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.grpFilter = new System.Windows.Forms.GroupBox();");
            sb.AppendLine("            this.txtFilter = new System.Windows.Forms.TextBox();");
            sb.AppendLine("            this.btnQuery = new System.Windows.Forms.Button();");
            sb.AppendLine("            this.sptView = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.dataTreeListView = new Nikita.WinForm.ExtendControl.DataTreeListView();");
            //sb.AppendLine("            this.olvColumn1 = ((Nikita.WinForm.ExtendControl.OLVColumn)(new Nikita.WinForm.ExtendControl.OLVColumn()));");
            #region DataGridView显示列

            foreach (Bse_UI ui in lstBseUiShow)
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
            sb.AppendLine("            this.tspCommand = new System.Windows.Forms.ToolStrip();");
            sb.AppendLine("            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdCancel = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdDelete = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdEdit = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdNewSameLevel = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdNewNextLevel = new System.Windows.Forms.ToolStripButton();");
            //sb.AppendLine("            this.lblQueryName = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.txtQueryName = new System.Windows.Forms.TextBox();");
            #region 查询面板控件

            foreach (Bse_UI ui in lstBseUiQuery)
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
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).BeginInit();");
            sb.AppendLine("            this.sptContainer.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptContainer.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptContainer.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();");
            sb.AppendLine("            this.sptQuery.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptQuery.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptQuery.SuspendLayout();");
            sb.AppendLine("            this.grpFilter.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptView)).BeginInit();");
            sb.AppendLine("            this.sptView.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptView.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptView.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.dataTreeListView)).BeginInit();");
            sb.AppendLine("            this.tspCommand.SuspendLayout();");
            foreach (Bse_UI ui in lstBseUiQuery)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("       ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).BeginInit();");
                }
            }
            sb.AppendLine("            this.SuspendLayout();");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptContainer");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptContainer.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;");
            sb.AppendLine("            this.sptContainer.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.sptContainer.Location = new System.Drawing.Point(0, 25);");
            sb.AppendLine("            this.sptContainer.Name = \"sptContainer\";");
            sb.AppendLine("            this.sptContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptContainer.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptContainer.Panel1.Controls.Add(this.sptQuery);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptContainer.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptContainer.Panel2.Controls.Add(this.sptView);");
            sb.AppendLine("            this.sptContainer.Size = new System.Drawing.Size(784, 536);");
            sb.AppendLine("            this.sptContainer.SplitterDistance = 47;");
            sb.AppendLine("            this.sptContainer.TabIndex = 0;");
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
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.txtQueryName);");
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.lblQueryName);");

            #region 查询区控件

            foreach (Bse_UI ui in lstBseUiQuery)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this." + ui.LabelName + ");");
                }
                sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this." + ui.ControlName + ");");
            }

            #endregion
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptQuery.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptQuery.Panel2.Controls.Add(this.grpFilter);");
            sb.AppendLine("            this.sptQuery.Panel2.Controls.Add(this.btnQuery);");
            sb.AppendLine("            this.sptQuery.Size = new System.Drawing.Size(784, 47);");
            sb.AppendLine("            this.sptQuery.SplitterDistance = 592;");
            sb.AppendLine("            this.sptQuery.TabIndex = 1;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // grpFilter");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));");
            sb.AppendLine("            this.grpFilter.Controls.Add(this.txtFilter);");
            sb.AppendLine("            this.grpFilter.Location = new System.Drawing.Point(5, 3);");
            sb.AppendLine("            this.grpFilter.Name = \"grpFilter\";");
            sb.AppendLine("            this.grpFilter.Size = new System.Drawing.Size(117, 41);");
            sb.AppendLine("            this.grpFilter.TabIndex = 18;");
            sb.AppendLine("            this.grpFilter.TabStop = false;");
            sb.AppendLine("            this.grpFilter.Text = \"通用过滤\";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // txtFilter");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.txtFilter.Location = new System.Drawing.Point(11, 14);");
            sb.AppendLine("            this.txtFilter.Name = \"txtFilter\";");
            sb.AppendLine("            this.txtFilter.Size = new System.Drawing.Size(100, 23);");
            sb.AppendLine("            this.txtFilter.TabIndex = 0;");
            sb.AppendLine("            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // btnQuery");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
            sb.AppendLine("            this.btnQuery.Location = new System.Drawing.Point(128, 12);");
            sb.AppendLine("            this.btnQuery.Name = \"btnQuery\";");
            sb.AppendLine("            this.btnQuery.Size = new System.Drawing.Size(55, 28);");
            sb.AppendLine("            this.btnQuery.TabIndex = 0;");
            sb.AppendLine("            this.btnQuery.Text = \"查询\";");
            sb.AppendLine("            this.btnQuery.UseVisualStyleBackColor = true;");
            sb.AppendLine("            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptView");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptView.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptView.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.sptView.Name = \"sptView\";");
            sb.AppendLine("            this.sptView.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptView.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptView.Panel1.Controls.Add(this.dataTreeListView);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptView.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptView.Panel2.Controls.Add(this.Pager);");
            sb.AppendLine("            this.sptView.Size = new System.Drawing.Size(784, 485);");
            sb.AppendLine("            this.sptView.SplitterDistance = 434;");
            sb.AppendLine("            this.sptView.TabIndex = 2;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // dataTreeListView");
            sb.AppendLine("            // ");
            //sb.AppendLine("            this.dataTreeListView.AllColumns.Add(this.olvColumn1);");
            #region DataGridView显示列
            foreach (Bse_UI ui in lstBseUiShow)
            {
                if (string.IsNullOrEmpty(ui.ControlNameSpace))
                {
                    sb.AppendLine("            this.dataTreeListView.AllColumns.Add(this." + ui.ControlName + ");");
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
            sb.AppendLine("            this.dataTreeListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.dataTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {");
            //sb.AppendLine("             this.olvColumn1 ");
            #region 显示列
            for (int i = 0; i < lstBseUiShow.Count; i++)
            {
                if (i == lstBseUiShow.Count - 1)
                {
                    sb.AppendLine("            this." + lstBseUiShow[i].ControlName + "");
                }
                else
                {
                    sb.AppendLine("            this." + lstBseUiShow[i].ControlName + ",");
                }
            }
            //sb.AppendLine("            this.colUser_Id,");
            //sb.AppendLine("            this.colTrueName");
            #endregion
            sb.AppendLine("     });");
            sb.AppendLine("            this.dataTreeListView.DataSource = null;");
            sb.AppendLine("            this.dataTreeListView.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.dataTreeListView.FullRowSelect = true;");
            //sb.AppendLine("            this.dataTreeListView.KeyAspectName = "Id";");
            sb.AppendLine("            this.dataTreeListView.KeyAspectName = \"" + strKeyId + "\";");
            sb.AppendLine("            this.dataTreeListView.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.dataTreeListView.Name = \"dataTreeListView\";");
            sb.AppendLine("            this.dataTreeListView.OwnerDraw = true;");
            //sb.AppendLine("            this.dataTreeListView.ParentKeyAspectName = "ParentId";");
            sb.AppendLine("            this.dataTreeListView.ParentKeyAspectName = \"" + strParentId + "\";");
            sb.AppendLine("            this.dataTreeListView.RootKeyValueString = \"\";");
            sb.AppendLine("            this.dataTreeListView.ShowGroups = false;");
            sb.AppendLine("            this.dataTreeListView.ShowKeyColumns = false;");
            sb.AppendLine("            this.dataTreeListView.Size = new System.Drawing.Size(784, 434);");
            sb.AppendLine("            this.dataTreeListView.TabIndex = 3;");
            sb.AppendLine("            this.dataTreeListView.UseCompatibleStateImageBehavior = false;");
            sb.AppendLine("            this.dataTreeListView.UseFilterIndicator = true;");
            sb.AppendLine("            this.dataTreeListView.UseFiltering = true;");
            sb.AppendLine("            this.dataTreeListView.View = System.Windows.Forms.View.Details;");
            sb.AppendLine("            this.dataTreeListView.VirtualMode = true;");
            sb.AppendLine("            this.dataTreeListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataTreeListView_MouseDoubleClick);");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // olvColumn1");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.olvColumn1.AspectName = "Name";");
            //sb.AppendLine("            this.olvColumn1.Text = "名称";");
            #region 显示区列

            foreach (Bse_UI ui in lstBseUiShow)
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
            sb.AppendLine("            // ");
            sb.AppendLine("            // Pager");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.Pager.Cursor = System.Windows.Forms.Cursors.Hand;");
            sb.AppendLine("            this.Pager.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.Pager.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.Pager.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.Pager.Name = \"Pager\";");
            sb.AppendLine("            this.Pager.PageIndex = 1;");
            sb.AppendLine("            this.Pager.RecordCount = 0;");
            sb.AppendLine("            this.Pager.Size = new System.Drawing.Size(784, 47);");
            sb.AppendLine("            this.Pager.TabIndex = 1;");
            sb.AppendLine("            this.Pager.PageChanged += new Nikita.WinForm.ExtendControl.PageChangedEventHandler(this.Pager_PageChanged);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tspCommand");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tspCommand.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("     this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;");
            sb.AppendLine("            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {");
            sb.AppendLine("            this.cmdRefresh,");
            sb.AppendLine("            this.cmdCancel,");
            sb.AppendLine("            this.cmdDelete,");
            sb.AppendLine("            this.cmdEdit,");
            sb.AppendLine("            this.cmdNewSameLevel,");
            sb.AppendLine("            this.cmdNewNextLevel});");
            sb.AppendLine("            this.tspCommand.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.tspCommand.Name = \"tspCommand\";");
            sb.AppendLine("            this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;");
            sb.AppendLine("            this.tspCommand.Size = new System.Drawing.Size(784, 25);");
            sb.AppendLine("            this.tspCommand.TabIndex = 6;");
            sb.AppendLine("            this.tspCommand.Text = \"toolStrip1 \";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdRefresh");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdRefresh.Name = \"cmdRefresh\";");
            sb.AppendLine("            this.cmdRefresh.Size = new System.Drawing.Size(45, 22);");
            sb.AppendLine("            this.cmdRefresh.Text = \"刷新 \";");
            sb.AppendLine("            this.cmdRefresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;");
            sb.AppendLine("            this.cmdRefresh.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdCancel");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdCancel.Name = \"cmdCancel\";");
            sb.AppendLine("            this.cmdCancel.Size = new System.Drawing.Size(45, 22);");
            sb.AppendLine("            this.cmdCancel.Text = \"作废 \";");
            sb.AppendLine("            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdDelete");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdDelete.Name = \"cmdDelete\";");
            sb.AppendLine("            this.cmdDelete.Size = new System.Drawing.Size(42, 22);");
            sb.AppendLine("            this.cmdDelete.Text = \"删除\";");
            sb.AppendLine("            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdEdit");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdEdit.Name = \"cmdEdit\";");
            sb.AppendLine("            this.cmdEdit.Size = new System.Drawing.Size(42, 22);");
            sb.AppendLine("            this.cmdEdit.Text =\"修改\";");
            sb.AppendLine("            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdNewSameLevel");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdNewSameLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdNewSameLevel.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdNewSameLevel.Name = \"cmdNewSameLevel\";");
            sb.AppendLine("            this.cmdNewSameLevel.Size = new System.Drawing.Size(72, 22);");
            sb.AppendLine("            this.cmdNewSameLevel.Text = \"新增同级\";");
            sb.AppendLine("            this.cmdNewSameLevel.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdNewNextLevel");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdNewNextLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdNewNextLevel.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdNewNextLevel.Name = \"cmdNewNextLevel\";");
            sb.AppendLine("            this.cmdNewNextLevel.Size = new System.Drawing.Size(72, 22);");
            sb.AppendLine("            this.cmdNewNextLevel.Text = \"新增下级\";");
            sb.AppendLine("            this.cmdNewNextLevel.Click += new System.EventHandler(this.Command_Click);");
            #region 查询区控件明细位置

            BeginWidth = 15;
            foreach (Bse_UI ui in lstBseUiQuery)
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
            //sb.AppendLine("            // lblQueryName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblQueryName.AutoSize = true;");
            //sb.AppendLine("            this.lblQueryName.Location = new System.Drawing.Point(13, 17);");
            //sb.AppendLine("            this.lblQueryName.Name = "lblQueryName";");
            //sb.AppendLine("            this.lblQueryName.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblQueryName.TabIndex = 0;");
            //sb.AppendLine("            this.lblQueryName.Text = "名称";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtQueryName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtQueryName.Location = new System.Drawing.Point(62, 14);");
            //sb.AppendLine("            this.txtQueryName.Name = "txtQueryName";");
            //sb.AppendLine("            this.txtQueryName.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtQueryName.TabIndex = 1;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strFrmClassName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);");
            sb.AppendLine("            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
            sb.AppendLine("            this.ClientSize = new System.Drawing.Size(784, 561);");
            sb.AppendLine("            this.Controls.Add(this.sptContainer);");
            sb.AppendLine("            this.Controls.Add(this.tspCommand);");
            sb.AppendLine("            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;");
            sb.AppendLine("            this.Name = \"" + strFrmClassName + "\";");
            sb.AppendLine("            this.ShowIcon = false;");
            sb.AppendLine("            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;");
            sb.AppendLine("            this.Text =  \"" + strFrmClassName + "\";");
            sb.AppendLine("            this.sptContainer.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptContainer.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptContainer)).EndInit();");
            sb.AppendLine("            this.sptContainer.ResumeLayout(false);");
            sb.AppendLine("            this.sptQuery.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptQuery.Panel1.PerformLayout();");
            sb.AppendLine("            this.sptQuery.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();");
            sb.AppendLine("            this.sptQuery.ResumeLayout(false);");
            sb.AppendLine("            this.grpFilter.ResumeLayout(false);");
            sb.AppendLine("            this.grpFilter.PerformLayout();");
            sb.AppendLine("            this.sptView.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptView.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptView)).EndInit();");
            sb.AppendLine("            this.sptView.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.dataTreeListView)).EndInit();");
            sb.AppendLine("            this.tspCommand.ResumeLayout(false);");
            sb.AppendLine("            this.tspCommand.PerformLayout();");
            foreach (Bse_UI ui in lstBseUiQuery)
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

            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptContainer;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptQuery;");
            sb.AppendLine("        private System.Windows.Forms.Button btnQuery;");
            sb.AppendLine("        private System.Windows.Forms.GroupBox grpFilter;");
            sb.AppendLine("        private System.Windows.Forms.TextBox txtFilter;");
            sb.AppendLine("        private System.Windows.Forms.ToolStrip tspCommand;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdRefresh;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdCancel;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdDelete;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdEdit;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdNewSameLevel;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdNewNextLevel;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptView;");
            sb.AppendLine("        private WinForm.ExtendControl.DataTreeListView dataTreeListView;");
            #region 显示区列
            foreach (Bse_UI ui in lstBseUiShow)
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
            sb.AppendLine("        private WinForm.ExtendControl.Pager Pager;");
            #region 查询区控件
            foreach (Bse_UI uiQuery in lstBseUiQuery)
            {
                if (uiQuery.IsAddLable == "True")
                {
                    sb.Append("        public  System.Windows.Forms.Label " + uiQuery.LabelName + ";\r\n");
                }
                sb.Append("        public " + uiQuery.ControlNameSpace + "  " + uiQuery.ControlName + ";\r\n");
            }
            #endregion
            //sb.AppendLine("        private System.Windows.Forms.Label lblQueryName;");
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtQueryName;");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();

        }

    }
}