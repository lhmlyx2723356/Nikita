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
    public class TemplateWinFromTreeEditWithDialog : CodeMakeBulider
    {
        public static int SumWidth = 450;
        public static int BeginWidth = 15;
        public static int LocationX = 15;
        public static int CtlSpace = 11;
        public static int LocationY = 15;
        public static int HighSeed = 30;

        public static int SumWidthEdit = 450;
        public static int BeginWidthEdit = 15;
        public static int LocationXEdit = 15;
        public static int LocationYEdit = 15;
        public static int HighSeedEdit = 25;

        public static int QueryHeight = 1;
        public static int EditHeight = 1;
        public override string GenWinFormCS(BasicParameter parameter, BaseParameter baseParameter)
        {
            TreeEditDialogParameter treeEditDialogParameter = baseParameter as TreeEditDialogParameter;
            if (treeEditDialogParameter==null)
            {
                throw new NoNullAllowedException("treeEditDialogParameter IS  NULL");
            }
            string strFrmClassName = "Frm" + parameter.ClassName + "TreeDialog";
            string strDalName = parameter.TableName + "DAL";
            string strModelName = parameter.TableName;
            string strGlobalModelName = " m_" + strModelName + " ";
            string strGlobalListModelName = " m_lst" + strModelName + " ";
            string strRetrunList = "List" + strModelName + " ";
            string strKeyId = Tools.GetPKey_MSSQL(parameter.TableName, parameter.Conn);
            List<Bse_UI> lstBseUiEdit = BseUIManager.GetListUIEdit(parameter.TableName);
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
            sb.AppendLine("  /// <summary>DataGridView下拉框绑定数据源");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private DataSet m_dsGridSource;");
            if (baseParameter.CodeGenType == CodeGenType.WinFromTreeEditWithDialog)
            {
                sb.AppendLine("        /// <summary>操作类");
                sb.AppendLine("        /// ");
                sb.AppendLine("        /// </summary>");
                //sb.AppendLine("        private " + strDalName + " m_" + strDalName + "; "); 
                sb.AppendLine("        private IBseDAL<" + strModelName + "> m_" + strDalName + "; ");
            }
            sb.AppendLine("        /// <summary>索引号");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private string m_strIndex;");
            sb.AppendLine("        /// <summary>当前对象");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private " + strModelName + "  " + strGlobalModelName + ";");
            sb.AppendLine("        /// <summary>当前对象集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private List<" + strModelName + "> " + strGlobalListModelName + ";"); 
            sb.AppendLine("        /// <summary>返回对象集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public List<" + strModelName + "> " + strRetrunList + " { get; private set; }");
            sb.AppendLine("   /// <summary>父级ID");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private int m_intParentId;");
            sb.AppendLine("        #endregion");
            sb.AppendLine("          ");
            #endregion

            #region 构造函数
            sb.AppendLine("        #region 构造函数");

            sb.AppendLine("        /// <summary>构造函数");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=model\" " + strModelName + "\">对象</param>");
            sb.AppendLine("        /// <param name=\"lst" + strModelName + "\">对象集合</param>");
            sb.AppendLine("        public  " + strFrmClassName + " (" + strModelName + "  model, int intParentId, List<" + strModelName + ">   lst" + strModelName + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            InitializeComponent();");
            sb.AppendLine("            DoInitData();");
            sb.AppendLine("            " + strGlobalListModelName + " =     lst" + strModelName + "?? new List<" + strModelName + ">() ;");
            sb.AppendLine("m_intParentId = intParentId;");
            //sb.AppendLine("            m_" + strDalName + " = new " + strDalName + "();"); 
            sb.AppendLine(" m_" + strDalName + " = GlobalHelp.GetResolve<IBseDAL<" + strModelName + ">>();");
            sb.AppendLine("            this.dataNavigator.Visible = false;");
            sb.AppendLine("            if (  model != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                this.dataNavigator.Visible = true;");
            sb.AppendLine("                " + strGlobalModelName + " =   model;");
            sb.AppendLine("                this.dataNavigator.ListInfo =  lst" + strModelName + ".Select(t => t." + strKeyId + ".ToString()).ToList();");
            sb.AppendLine("                m_strIndex =  lst" + strModelName + ".FindIndex(t => t." + strKeyId + " ==    " + strGlobalModelName + "." + strKeyId + ").ToString();");
            sb.AppendLine("                this.dataNavigator.CurrentIndex = int.Parse(m_strIndex);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            #endregion

            #region 基础事件
            sb.AppendLine("          ");
            sb.AppendLine("        #region 基础事件");
            sb.AppendLine("        private void btnSave_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            string strReturnMsg = CheckInput();");
            sb.AppendLine("            if (strReturnMsg != string.Empty)");
            sb.AppendLine("            {");
            sb.AppendLine("                MessageBox.Show(strReturnMsg);");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            //新增");
            sb.AppendLine("            if (" + strGlobalModelName + " == null)");
            sb.AppendLine("            {");

            if (baseParameter is TreeEditDialogParameter)
            {
                TreeEditDialogParameter para = baseParameter as TreeEditDialogParameter;
                if (para.DontRepeatColumns.Trim() != string.Empty)
                {
                    string[] strColumnArray = para.DontRepeatColumns.Split(',');
                    if (strColumnArray.Length > 0)
                    {
                        foreach (Bse_UI ui in lstBseUiEdit)
                        {
                            if (strColumnArray.Contains(ui.ColumnName))
                            {
                                string strExistInfo = GenControlHelper.CreateExistInfo("m_"+strDalName, ui.ColumnName,
                                    ui.LabelText, ui.ControlName, ui.ColumnType, ui.ControlNameSpace, OperationType.新增, strKeyId, strGlobalModelName);
                                sb.AppendLine(strExistInfo);
                            }
                        }
                    }
                }
            }
            //sb.AppendLine("                if (m_sysRolesDAL.CalcCount("RoleName='" + txtRoleName.Text.Trim() + "'") > 0)");
            //sb.AppendLine("                {");
            //sb.AppendLine("                    MessageBox.Show(@"角色名称已经存在");");
            //sb.AppendLine("                    return;");
            //sb.AppendLine("                }");
            sb.AppendLine("               " + strModelName + " model  = EntityOperateManager.AddEntity<  " + strModelName + ">(this.tabPage);");
            sb.AppendLine(" model." + treeEditDialogParameter.ParentId+ " = m_intParentId;");
            sb.AppendLine("                int intReturn = m_" + strDalName + ".Add(model);");
            sb.AppendLine("                if (intReturn > 0)");
            sb.AppendLine("                {");
            sb.AppendLine("                    MessageBox.Show(@\"添加成功\");");
            sb.AppendLine("                    model." + strKeyId + " = intReturn;");
            sb.AppendLine("                    " + strGlobalListModelName + ".Add(model);");
            sb.AppendLine("                    " + strRetrunList + " =   " + strGlobalListModelName + ";");
            sb.AppendLine("                    this.DialogResult = DialogResult.OK;");
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                {");
            sb.AppendLine("                    MessageBox.Show(@\"添加失败\");");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            //修改");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            //sb.AppendLine("                if (m_sysRolesDAL.CalcCount("RoleName='" + txtRoleName.Text.Trim() + "' and  KeyID !=" + m_sysRoles.KeyId + " ") > 0)");
            //sb.AppendLine("                {");
            //sb.AppendLine("                    MessageBox.Show(@"角色名称已经存在");");
            //sb.AppendLine("                    return;");
            //sb.AppendLine("                }");
            if (baseParameter is TreeEditDialogParameter)
            {
                TreeEditDialogParameter para = baseParameter as TreeEditDialogParameter;
                if (para.DontRepeatColumns.Trim() != string.Empty)
                {
                    string[] strColumnArray = para.DontRepeatColumns.Split(',');
                    if (strColumnArray.Length > 0)
                    {
                        foreach (Bse_UI ui in lstBseUiEdit)
                        {
                            if (strColumnArray.Contains(ui.ColumnName))
                            {
                                string strExistInfo = GenControlHelper.CreateExistInfo("m_" + strDalName, ui.ColumnName,
                                    ui.LabelText, ui.ControlName, ui.ColumnType, ui.ControlNameSpace, OperationType.修改, strKeyId, strGlobalModelName);
                                sb.AppendLine(strExistInfo);
                            }
                        }
                    }
                }
            }
            sb.AppendLine("                 " + strGlobalModelName + " = EntityOperateManager.EditEntity(this.tabPage, " + strGlobalModelName + ");");
            sb.AppendLine("                bool blnReturn = m_" + strDalName + ".Update( " + strGlobalModelName + ");");
            sb.AppendLine("                if (blnReturn)");
            sb.AppendLine("                {");
            sb.AppendLine("                    MessageBox.Show(@\"修改成功\");");
            sb.AppendLine("                    " + strRetrunList + " = " + strGlobalListModelName + ";");
            sb.AppendLine("                    this.DialogResult = DialogResult.OK;");
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                {");
            sb.AppendLine("                    MessageBox.Show(@\"修改失败\");");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        } ");

            sb.AppendLine("        private void btnClear_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            ControlManager.ClearAll(this.tabPage);");
            sb.AppendLine("        }");

            sb.AppendLine("        private void dataNavigator_PositionChanged(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (dataNavigator.ListInfo == null)");
            sb.AppendLine("            {");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            " + strGlobalModelName + " = " + strGlobalListModelName + "[this.dataNavigator.CurrentIndex];");
            sb.AppendLine("            DisplayData(  " + strGlobalModelName + ");");
            sb.AppendLine("        }");

            sb.AppendLine("        #endregion");
            #endregion

            #region 基础方法
            sb.AppendLine("          ");


            sb.AppendLine("        #region 基本方法");

            sb.AppendLine("        /// <summary>初始化绑定");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitData()");
            sb.AppendLine("        {");
            //sb.AppendLine("            const string strBindSql = "SELECT 2 AS  Name , '管理员' AS  value UNION ALL  SELECT 3 AS  Name , '功城队' AS  value;SELECT 'cbkRemark '";");
            //sb.AppendLine("            BindClass bindClass = new BindClass()");
            //sb.AppendLine("            {");
            //sb.AppendLine("                SqlType = SqlType.SqlServer,");
            //sb.AppendLine("                BindSql = strBindSql");
            //sb.AppendLine("            };");
            //sb.AppendLine("            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn);");
            //sb.AppendLine("            CheckedComboBoxHelper.BindCheckedComboBox(cbkRemark, ds.Tables["cbkRemark"], "value", "Name");");
            string strBindSql = GenControlHelper.GetBindSourceEditSqlByTableName(parameter.TableName);
            if (!string.IsNullOrEmpty(strBindSql))
            {
                sb.AppendLine(" const string strBindEditSql=\"" + strBindSql + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindEditSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("DataSet ds =BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn); ");
                sb.AppendLine(GenControlHelper.GenBindDataSouce(parameter.TableName,PanelType.编辑面板));
            }
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>实体对象值显示至控件");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine(" /// <param name=\"model\">model</param>");
            sb.AppendLine("        private void DisplayData(" + strModelName + "  model)");
            sb.AppendLine("        {");
            sb.AppendLine("            EntityOperateManager.BindAll(this.tabPage, model);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>检查输入合法性");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private string CheckInput()");
            sb.AppendLine("        {");
            //sb.AppendLine("            if (txtRoleName.Text.Trim() == string.Empty)");
            //sb.AppendLine("            {");
            //sb.AppendLine("                return "角色名称不能为空";");
            //sb.AppendLine("            }");
            if (baseParameter is TreeEditDialogParameter)
            {
                TreeEditDialogParameter para = baseParameter as TreeEditDialogParameter;
                if (para.CheckInputColumns.Trim() != string.Empty)
                {
                    string[] strColumnArray = para.CheckInputColumns.Split(',');
                    if (strColumnArray.Length > 0)
                    {
                        foreach (Bse_UI ui in lstBseUiEdit)
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
            }
            sb.AppendLine("            return string.Empty;");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            #endregion
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string GenWinFormDesign(BasicParameter parameter, BaseParameter baseParameter)
        {
            string strFrmClassName = "Frm" + parameter.ClassName + "TreeDialog";
            List<Bse_UI> lstBseUiEdit = BseUIManager.GetListUIEdit(parameter.TableName);
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
            sb.AppendLine("            this.splitContainer1 = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.tabControl = new System.Windows.Forms.TabControl();");
            sb.AppendLine("            this.tabPage = new System.Windows.Forms.TabPage();");
            //sb.AppendLine("            this.cbkRemark = new Nikita.WinForm.ExtendControl.CheckedComboBox();");
            //sb.AppendLine("            this.numSortNumber = new System.Windows.Forms.NumericUpDown();");
            //sb.AppendLine("            this.txtRoleName = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.chkisDefault = new System.Windows.Forms.CheckBox();");
            //sb.AppendLine("            this.lblRemark = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.lblSortNumber = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.lblRoleName = new System.Windows.Forms.Label();");
            #region 编辑面板控件

            foreach (Bse_UI ui in lstBseUiEdit)
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
            sb.AppendLine("            this.dataNavigator = new Nikita.WinForm.ExtendControl.DataNavigator();");
            sb.AppendLine("            this.btnClear = new System.Windows.Forms.Button();");
            sb.AppendLine("            this.btnSave = new System.Windows.Forms.Button();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();");
            sb.AppendLine("            this.splitContainer1.Panel1.SuspendLayout();");
            sb.AppendLine("            this.splitContainer1.Panel2.SuspendLayout();");
            sb.AppendLine("            this.splitContainer1.SuspendLayout();");
            sb.AppendLine("            this.tabControl.SuspendLayout();");
            sb.AppendLine("            this.tabPage.SuspendLayout();");
            foreach (Bse_UI ui in lstBseUiEdit)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("       ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).BeginInit();");
                }
            }
            sb.AppendLine("            this.SuspendLayout();");

            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;");
            sb.AppendLine("            this.splitContainer1.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.splitContainer1.Name = \"splitContainer1\";");
            sb.AppendLine("            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer1.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer1.Panel1.Controls.Add(this.tabControl);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer1.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer1.Panel2.Controls.Add(this.dataNavigator);");
            sb.AppendLine("            this.splitContainer1.Panel2.Controls.Add(this.btnClear);");
            sb.AppendLine("            this.splitContainer1.Panel2.Controls.Add(this.btnSave);");
            sb.AppendLine("            this.splitContainer1.Size = new System.Drawing.Size(434, 370);");
            sb.AppendLine("            this.splitContainer1.SplitterDistance = 317;");
            sb.AppendLine("            this.splitContainer1.TabIndex = 0;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tabControl");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tabControl.Controls.Add(this.tabPage);");
            sb.AppendLine("            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.tabControl.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.tabControl.Name = \"tabControl\";");
            sb.AppendLine("            this.tabControl.SelectedIndex = 0;");
            sb.AppendLine("            this.tabControl.Size = new System.Drawing.Size(432, 315);");
            sb.AppendLine("            this.tabControl.TabIndex = 1;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tabPage");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tabPage.BackColor = System.Drawing.SystemColors.Control;");
            //sb.AppendLine("            this.tabPage.Controls.Add(this.cbkRemark);");
            //sb.AppendLine("            this.tabPage.Controls.Add(this.numSortNumber);");
            //sb.AppendLine("            this.tabPage.Controls.Add(this.txtRoleName);");
            //sb.AppendLine("            this.tabPage.Controls.Add(this.chkisDefault);");
            //sb.AppendLine("            this.tabPage.Controls.Add(this.lblRemark);");
            //sb.AppendLine("            this.tabPage.Controls.Add(this.lblSortNumber);");
            //sb.AppendLine("            this.tabPage.Controls.Add(this.lblRoleName);");
            #region 编辑区控件

            foreach (Bse_UI ui in lstBseUiEdit)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("            this.tabPage.Controls.Add(this." + ui.LabelName + ");");
                }
                sb.AppendLine("            this.tabPage.Controls.Add(this." + ui.ControlName + ");");
            }

            #endregion
            sb.AppendLine("            this.tabPage.Location = new System.Drawing.Point(4, 26);");
            sb.AppendLine("            this.tabPage.Name = \"tabPage\";");
            sb.AppendLine("            this.tabPage.Padding = new System.Windows.Forms.Padding(3);");
            sb.AppendLine("            this.tabPage.Size = new System.Drawing.Size(424, 285);");
            sb.AppendLine("            this.tabPage.TabIndex = 0;");
            sb.AppendLine("            this.tabPage.Text = \"基本信息\";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // cbkRemark");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.cbkRemark.CheckOnClick = true;");
            //sb.AppendLine("            this.cbkRemark.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;");
            //sb.AppendLine("            this.cbkRemark.DropDownHeight = 1;");
            //sb.AppendLine("            this.cbkRemark.FormattingEnabled = true;");
            //sb.AppendLine("            this.cbkRemark.IntegralHeight = false;");
            //sb.AppendLine("            this.cbkRemark.Location = new System.Drawing.Point(84, 54);");
            //sb.AppendLine("            this.cbkRemark.Name = "cbkRemark";");
            //sb.AppendLine("            this.cbkRemark.Size = new System.Drawing.Size(100, 24);");
            //sb.AppendLine("            this.cbkRemark.TabIndex = 7;");
            //sb.AppendLine("            this.cbkRemark.Tag = "Remark";");
            //sb.AppendLine("            this.cbkRemark.ValueSeparator = ", ";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // numSortNumber");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.numSortNumber.Location = new System.Drawing.Point(257, 16);");
            //sb.AppendLine("            this.numSortNumber.Name = "numSortNumber";");
            //sb.AppendLine("            this.numSortNumber.Size = new System.Drawing.Size(102, 23);");
            //sb.AppendLine("            this.numSortNumber.TabIndex = 6;");
            //sb.AppendLine("            this.numSortNumber.Tag = "Sortnum";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtRoleName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtRoleName.Location = new System.Drawing.Point(84, 16);");
            //sb.AppendLine("            this.txtRoleName.Name = "txtRoleName";");
            //sb.AppendLine("            this.txtRoleName.Size = new System.Drawing.Size(100, 23);");
            //sb.AppendLine("            this.txtRoleName.TabIndex = 5;");
            //sb.AppendLine("            this.txtRoleName.Tag = "RoleName";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // chkisDefault");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.chkisDefault.AutoSize = true;");
            //sb.AppendLine("            this.chkisDefault.Location = new System.Drawing.Point(215, 57);");
            //sb.AppendLine("            this.chkisDefault.Name = "chkisDefault";");
            //sb.AppendLine("            this.chkisDefault.Size = new System.Drawing.Size(75, 21);");
            //sb.AppendLine("            this.chkisDefault.TabIndex = 4;");
            //sb.AppendLine("            this.chkisDefault.Tag = "isDefault";");
            //sb.AppendLine("            this.chkisDefault.Text = "是否默认";");
            //sb.AppendLine("            this.chkisDefault.UseVisualStyleBackColor = true;");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblRemark");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblRemark.AutoSize = true;");
            //sb.AppendLine("            this.lblRemark.Location = new System.Drawing.Point(27, 61);");
            //sb.AppendLine("            this.lblRemark.Name = "lblRemark";");
            //sb.AppendLine("            this.lblRemark.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblRemark.TabIndex = 3;");
            //sb.AppendLine("            this.lblRemark.Text = "备注";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblSortNumber");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblSortNumber.AutoSize = true;");
            //sb.AppendLine("            this.lblSortNumber.Location = new System.Drawing.Point(212, 18);");
            //sb.AppendLine("            this.lblSortNumber.Name = "lblSortNumber";");
            //sb.AppendLine("            this.lblSortNumber.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.lblSortNumber.TabIndex = 1;");
            //sb.AppendLine("            this.lblSortNumber.Text = "排序";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblRoleName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblRoleName.AutoSize = true;");
            //sb.AppendLine("            this.lblRoleName.Location = new System.Drawing.Point(18, 19);");
            //sb.AppendLine("            this.lblRoleName.Name = "lblRoleName";");
            //sb.AppendLine("            this.lblRoleName.Size = new System.Drawing.Size(60, 17);");
            //sb.AppendLine("            this.lblRoleName.TabIndex = 0;");
            //sb.AppendLine("            this.lblRoleName.Text = " 角色名称";");
            #region 编辑区控件明细位置

            BeginWidth = 15;
            foreach (Bse_UI ui in lstBseUiEdit)
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
            sb.AppendLine("            // ");
            sb.AppendLine("            // dataNavigator");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.dataNavigator.CurrentIndex = 0;");
            sb.AppendLine("            this.dataNavigator.Font = new System.Drawing.Font(\"微软雅黑\", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));");
            sb.AppendLine("            this.dataNavigator.ListInfo = null;");
            sb.AppendLine("            this.dataNavigator.Location = new System.Drawing.Point(5, 4);");
            sb.AppendLine("            this.dataNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.dataNavigator.Name = \"dataNavigator\";");
            sb.AppendLine("            this.dataNavigator.Size = new System.Drawing.Size(249, 32);");
            sb.AppendLine("            this.dataNavigator.TabIndex = 2;");
            sb.AppendLine("            this.dataNavigator.PositionChanged += new Nikita.WinForm.ExtendControl.DataNavigator.PostionChangedEventHandler(this.dataNavigator_PositionChanged);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // btnClear");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;");
            sb.AppendLine("            this.btnClear.Location = new System.Drawing.Point(341, 8);");
            sb.AppendLine("            this.btnClear.Name = \"btnClear\";");
            sb.AppendLine("            this.btnClear.Size = new System.Drawing.Size(75, 28);");
            sb.AppendLine("            this.btnClear.TabIndex = 1;");
            sb.AppendLine("            this.btnClear.Text = \"清空\";");
            sb.AppendLine("            this.btnClear.UseVisualStyleBackColor = true;");
            sb.AppendLine("            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // btnSave");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;");
            sb.AppendLine("            this.btnSave.Location = new System.Drawing.Point(261, 8);");
            sb.AppendLine("            this.btnSave.Name = \"btnSave\";");
            sb.AppendLine("            this.btnSave.Size = new System.Drawing.Size(75, 28);");
            sb.AppendLine("            this.btnSave.TabIndex = 0;");
            sb.AppendLine("            this.btnSave.Text = \"保存(&S)\";");
            sb.AppendLine("            this.btnSave.UseVisualStyleBackColor = true;");
            sb.AppendLine("            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strFrmClassName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);");
            sb.AppendLine("            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
            sb.AppendLine("            this.ClientSize = new System.Drawing.Size(434, 370);");
            sb.AppendLine("            this.Controls.Add(this.splitContainer1);");
            sb.AppendLine("            this.Font = new System.Drawing.Font(\"微软雅黑\", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));");
            sb.AppendLine("            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;");
            sb.AppendLine("            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.MaximizeBox = false;");
            sb.AppendLine("            this.MinimizeBox = false;");
            sb.AppendLine("            this.Name = \"" + strFrmClassName + "\";");
            sb.AppendLine("            this.ShowIcon = false;");
            sb.AppendLine("            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;");
            sb.AppendLine("            this.splitContainer1.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.splitContainer1.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();");
            sb.AppendLine("            this.splitContainer1.ResumeLayout(false);");
            sb.AppendLine("            this.tabControl.ResumeLayout(false);");
            sb.AppendLine("            this.tabPage.ResumeLayout(false);");
            sb.AppendLine("            this.tabPage.PerformLayout();");
            foreach (Bse_UI ui in lstBseUiEdit)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).EndInit();");
                }
            }
            sb.AppendLine("            this.ResumeLayout(false);");
            sb.AppendLine("        }");

            sb.AppendLine("        #endregion");

            sb.AppendLine("        private System.Windows.Forms.SplitContainer splitContainer1;");
            sb.AppendLine("        private System.Windows.Forms.TabControl tabControl;");
            sb.AppendLine("        private System.Windows.Forms.TabPage tabPage;");
            sb.AppendLine("        private System.Windows.Forms.Button btnClear;");
            sb.AppendLine("        private System.Windows.Forms.Button btnSave;");
            sb.AppendLine("        private WinForm.ExtendControl.DataNavigator dataNavigator;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblSortNumber;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblRoleName;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblRemark;");
            //sb.AppendLine("        private System.Windows.Forms.CheckBox chkisDefault;");
            //sb.AppendLine("        private System.Windows.Forms.NumericUpDown numSortNumber;");
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtRoleName;");
            //sb.AppendLine("        private WinForm.ExtendControl.CheckedComboBox cbkRemark;");
            #region 编辑区控件
            foreach (Bse_UI uiQuery in lstBseUiEdit)
            {
                if (uiQuery.IsAddLable == "True")
                {
                    sb.Append("        public  System.Windows.Forms.Label " + uiQuery.LabelName + ";\r\n");
                }
                sb.Append("        public " + uiQuery.ControlNameSpace + "  " + uiQuery.ControlName + ";\r\n");
            }
            #endregion
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();

        }

    }
}