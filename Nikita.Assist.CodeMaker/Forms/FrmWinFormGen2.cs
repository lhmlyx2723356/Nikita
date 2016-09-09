using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Assist.CodeMaker.Template.ClassTemplate;
using Nikita.Base.Define;
using Nikita.Core.WinForm;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmWinFormGen2 : DockContentEx
    {
        #region 常量、变量
        /// <summary>数据库结构
        /// 数据库结构
        /// </summary>
        private readonly DbSchema m_dbSchema;
        private readonly CodeGenType m_codeGenType;
        private DatabaseTable m_databaseTable;
        private DatabaseTable m_databaseTableDetail;
        private BaseParameter m_baseParameter;
        private string m_strQueryColumns;
        private string m_strShowColumns;
        private string m_strEditColumns;
        private string m_strCheckInputColumns;
        private string m_strDontRepeatColumns;

        private string m_strShowColumnsDetail;
        private string m_strEditColumnsDetail;
        private string m_strCheckInputColumnsDetail;
        private string m_strDontRepeatColumnsDetail;
        private FrameworkType m_frameworkType;
        UiStyle m_uiStyle;
        ListBindType m_listBindType;
        #endregion

        #region 构造函数
        public FrmWinFormGen2()
        {
            InitializeComponent();
            lstCheckInputFileds.MouseEnter += ListMouseEnter;
            lstEditShowFileds.MouseEnter += ListMouseEnter;
            lstQueryFileds.MouseEnter += ListMouseEnter;
            lstShowFileds.MouseEnter += ListMouseEnter;
            lstDontRepeatFileds.MouseEnter += ListMouseEnter;

            lstCheckInputFiledsDetail.MouseEnter += ListMouseEnter;
            lstEditShowFiledsDetail.MouseEnter += ListMouseEnter;
            lstShowFiledsDetail.MouseEnter += ListMouseEnter;
            lstDontRepeatFiledsDetail.MouseEnter += ListMouseEnter;
        }

        public FrmWinFormGen2(DbSchema dbSchema, CodeGenType codeGenType)
        {
            InitializeComponent();
            lstCheckInputFileds.MouseEnter += ListMouseEnter;
            lstEditShowFileds.MouseEnter += ListMouseEnter;
            lstQueryFileds.MouseEnter += ListMouseEnter;
            lstShowFileds.MouseEnter += ListMouseEnter;
            lstDontRepeatFileds.MouseEnter += ListMouseEnter;

            if (codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                lstCheckInputFiledsDetail.MouseEnter += ListMouseEnter;
                lstEditShowFiledsDetail.MouseEnter += ListMouseEnter;
                lstShowFiledsDetail.MouseEnter += ListMouseEnter;
                lstDontRepeatFiledsDetail.MouseEnter += ListMouseEnter;
            }

            m_dbSchema = dbSchema;
            m_codeGenType = codeGenType;
            SetVisible();
        }
        #endregion

        #region 事件

        /// <summary>界面生成
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnUIGen_Click(object sender, EventArgs e)
        {
            bool blnCheck = CheckInput();
            if (!blnCheck)
            {
                return;
            }
            m_baseParameter = GetBaseParameter();
            FrmControlSetting frmEditSetting = new FrmControlSetting(m_baseParameter);
            frmEditSetting.ShowDialog();
        }

        /// <summary>生成CS
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdGenCode_Click(object sender, EventArgs e)
        {
            CodeMakeDirector director = new CodeMakeDirector();
            BasicParameter basicParameter = ParameterManager.GetBasicParameter(cboTable.Text.Trim());
            basicParameter.Conn = m_dbSchema.DatabaseSchema.ConnectionString;
            m_baseParameter = GetBaseParameter();
            switch (m_codeGenType)
            {
                #region WinFromSimpleQuery/WinFromEditWithDialog
                case CodeGenType.WinFromSimpleQuery:
                case CodeGenType.WinFromEditWithDialog:
                    if (m_codeGenType == CodeGenType.WinFromEditWithDialog)
                    {
                        CodeMakeBulider bulider = new TemplateWinFromEditWithDialog();
                        string[] strArray = director.Construct(bulider, basicParameter, m_baseParameter);
                        string strFrmDialogClassName = "Frm" + basicParameter.ClassName + "SimpleDialog.cs";
                        string strFrmDialogClassNameDesigner = "Frm" + basicParameter.ClassName + "SimpleDialog.Designer.cs";
                        FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmDialogClassName, strArray[0], false);
                        FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmDialogClassNameDesigner, strArray[1], false);
                    }
                    CodeMakeBulider buliderSimple = new TemplateWinFormSimpleQuery();
                    string[] strArraySimple = director.Construct(buliderSimple, basicParameter, m_baseParameter);
                    string strFrmClassName = "Frm" + basicParameter.ClassName + "SimpleQuery.cs";
                    string strFrmClassNameDesigner = "Frm" + basicParameter.ClassName + "SimpleQuery.Designer.cs";
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmClassName, strArraySimple[0], false);
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmClassNameDesigner, strArraySimple[1]);
                    break;
                #endregion

                #region WinFromTreeEditWithDialog
                case CodeGenType.WinFromTreeEditWithDialog:

                    CodeMakeBulider buliderTree = new TemplateWinFromTreeEditWithDialog();
                    string[] strArrayTree = director.Construct(buliderTree, basicParameter, m_baseParameter);
                    string strFrmTreeDialogClassName = "Frm" + basicParameter.ClassName + "TreeDialog.cs";
                    string strFrmTreeDialogClassNameDesigner = "Frm" + basicParameter.ClassName + "TreeDialog.Designer.cs";
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmTreeDialogClassName, strArrayTree[0], false);
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmTreeDialogClassNameDesigner, strArrayTree[1], false);

                    CodeMakeBulider buliderTreeQuery = new TemplateWinFormTreeQuery();
                    string[] strArrayTreeQuery = director.Construct(buliderTreeQuery, basicParameter, m_baseParameter);
                    string strFrmTreeClassName = "Frm" + basicParameter.ClassName + "TreeQuery.cs";
                    string strFrmTreeClassNameDesigner = "Frm" + basicParameter.ClassName + "TreeQuery.Designer.cs";
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmTreeClassName, strArrayTreeQuery[0], false);
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmTreeClassNameDesigner, strArrayTreeQuery[1]);

                    break;
                #endregion
                     
                #region WinFromParentChildEditWithDialog
                case CodeGenType.WinFromParentChildEditWithDialog:
                    CodeMakeBulider buliderParentChild = new   TemplateWinFromParentChildEditWithDialog() ;
                    string[] strArrayParentChild = director.Construct(buliderParentChild, basicParameter, m_baseParameter);
                    string strFrmParentChildDialogClassName = "Frm" + basicParameter.ClassName + "MasterDetailDialog.cs";
                    string strFrmParentChildDialogClassNameDesigner = "Frm" + basicParameter.ClassName + "MasterDetailDialog.Designer.cs";
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmParentChildDialogClassName, strArrayParentChild[0], false);
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmParentChildDialogClassNameDesigner, strArrayParentChild[1], false);

                    CodeMakeBulider buliderParentChildQuery = new TemplateWinFormParentChildQuery();
                    string[] strArrayParentChildQuery = director.Construct(buliderParentChildQuery, basicParameter, m_baseParameter);
                    string strFrmParentChildClassName = "Frm" + basicParameter.ClassName + "MasterDetailQuery.cs";
                    string strFrmParentChildClassNameDesigner = "Frm" + basicParameter.ClassName + "MasterDetailQuery.Designer.cs";
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmParentChildClassName, strArrayParentChildQuery[0], false);
                    FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmParentChildClassNameDesigner, strArrayParentChildQuery[1]);
                    break;
                #endregion
            }
        }

        /// <summary>生成Model
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdGenModel_Click(object sender, EventArgs e)
        {
            IModelMaker modelMaker = ModelMakerManager.GetModelMaker(m_dbSchema.SqlType);
            if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                BasicParameter basicParameterDetail = ParameterManager.GetBasicParameter(cboTableDetail.Text.Trim());
                string strContentDetail = modelMaker.GenModelCode(basicParameterDetail.NameSpace, cboTableDetail.Text,
                    basicParameterDetail.ClassName, m_dbSchema.DatabaseSchema.ConnectionString, basicParameterDetail.Author);
                string strFolderDetail = basicParameterDetail.OutFolderPath + "\\Model\\";
                FileHelper.GenFile(strFolderDetail, basicParameterDetail.ClassName + ".cs", strContentDetail, false);
            }
            BasicParameter basicParameter = ParameterManager.GetBasicParameter(cboTable.Text.Trim());
            string strContent = modelMaker.GenModelCode(basicParameter.NameSpace, basicParameter.TableName, basicParameter.ClassName, m_dbSchema.DatabaseSchema.ConnectionString, basicParameter.Author);
            string strFolder = basicParameter.OutFolderPath + "\\Model\\";
            FileHelper.GenFile(strFolder, basicParameter.ClassName + ".cs", strContent);

        }

        /// <summary>生成DAL
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdGenDAL_Click(object sender, EventArgs e)
        {
            IDalMaker dalMaker = DalMakerManager.GetDalMaker(m_dbSchema.SqlType);
            if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                BasicParameter basicParameterDetail = ParameterManager.GetBasicParameter(cboTableDetail.Text.Trim());
                string strContentDetail = dalMaker.GenDalCode(basicParameterDetail.NameSpace, basicParameterDetail.TableName, basicParameterDetail.ClassName, m_dbSchema.DatabaseSchema.ConnectionString);
                string strFolderDetail = basicParameterDetail.OutFolderPath + "\\DAL\\";
                FileHelper.GenFile(strFolderDetail, basicParameterDetail.ClassName + "DAL.cs", strContentDetail, false);
            }
            BasicParameter basicParameter = ParameterManager.GetBasicParameter(cboTable.Text.Trim());
            string strContent = dalMaker.GenDalCode(basicParameter.NameSpace, basicParameter.TableName, basicParameter.ClassName, m_dbSchema.DatabaseSchema.ConnectionString);
            string strFolder = basicParameter.OutFolderPath + "\\DAL\\";
            FileHelper.GenFile(strFolder, basicParameter.ClassName + "DAL.cs", strContent);

        }

        #region 基本事件
        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTable.Text == string.Empty)
            {
                return;
            }
            BindListBox();
        }

        private void cboTableDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTableDetail.Text == string.Empty)
            {
                return;
            }
            BindListBoxDetail();
        }
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedListBox ctListBox = contextMenuStrip1.Tag as CheckedListBox;
            if (ctListBox == null) return;
            for (int i = 0; i < ctListBox.Items.Count; i++)
            {
                ctListBox.SetItemChecked(i, true);
            }
        }

        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedListBox ctListBox = contextMenuStrip1.Tag as CheckedListBox;
            if (ctListBox == null) return;
            for (int i = 0; i < ctListBox.Items.Count; i++)
            {
                ctListBox.SetItemChecked(i, !ctListBox.GetItemChecked(i));
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedListBox ctListBox = contextMenuStrip1.Tag as CheckedListBox;
            if (ctListBox == null) return;
            for (int i = 0; i < ctListBox.Items.Count; i++)
            {
                ctListBox.SetItemChecked(i, false);
            }
        }

        private void ListMouseEnter(object sender, EventArgs e)
        {
            CheckedListBox ctListBox = sender as CheckedListBox;
            if (ctListBox != null) SetContextMenuStrip(ctListBox.Name);
        }

        private void FrmWinFormGen_Load(object sender, EventArgs e)
        {
            BindComboBox();
            BindListBox();
            if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                BindListBoxDetail();
            }
        }
        #endregion

        #endregion

        #region 基本方法
        /// <summary>获取基础设置参数
        /// 
        /// </summary>
        /// <returns></returns>
        private BaseParameter GetBaseParameter()
        {
            #region 获取参数
            GetFileds(out m_strQueryColumns, lstQueryFileds);
            GetFileds(out m_strShowColumns, lstShowFileds);
            GetFileds(out m_strEditColumns, lstEditShowFileds);
            GetFileds(out m_strCheckInputColumns, lstCheckInputFileds);
            GetFileds(out m_strDontRepeatColumns, lstDontRepeatFileds);
            m_frameworkType = GetFrameworkType();
            m_uiStyle = GetUiStyle();
            m_listBindType = GetListBindType();
            #endregion

            switch (m_codeGenType)
            {
                #region WinFromSimpleQuery
                case CodeGenType.WinFromSimpleQuery:
                    m_baseParameter = new SimpleQueryParameter
                    {
                        QueryColumns = m_strQueryColumns,
                        ShowColumns = m_strShowColumns,
                        CodeGenType = m_codeGenType,
                        DatabaseTable = m_databaseTable,
                        FrameworkType = m_frameworkType,
                        UiStyle = m_uiStyle,
                        ListBindType = m_listBindType
                    };
                    break;
                #endregion

                #region WinFromEditWithDialog
                case CodeGenType.WinFromEditWithDialog:
                    m_baseParameter = new EditDialogParameter
                    {
                        QueryColumns = m_strQueryColumns,
                        ShowColumns = m_strShowColumns,
                        CodeGenType = m_codeGenType,
                        DatabaseTable = m_databaseTable,
                        FrameworkType = m_frameworkType,
                        DontRepeatColumns = m_strDontRepeatColumns,
                        CheckInputColumns = m_strCheckInputColumns,
                        EditColumns = m_strEditColumns,
                        UiStyle = m_uiStyle,
                        ListBindType = m_listBindType
                    };
                    break;
                #endregion

                #region WinFromTreeEditWithDialog
                case CodeGenType.WinFromTreeEditWithDialog:
                    m_baseParameter = new TreeEditDialogParameter
                    {
                        QueryColumns = m_strQueryColumns,
                        ShowColumns = m_strShowColumns,
                        CodeGenType = m_codeGenType,
                        DatabaseTable = m_databaseTable,
                        FrameworkType = m_frameworkType,
                        DontRepeatColumns = m_strDontRepeatColumns,
                        CheckInputColumns = m_strCheckInputColumns,
                        EditColumns = m_strEditColumns,
                        UiStyle = m_uiStyle,
                        ListBindType = m_listBindType,
                        KeyId = txtKey.Text.Trim(),
                        ParentId = txtParentKey.Text.Trim()
                    };
                    break;
                #endregion

                #region WinFromParentChildEditWithDialog
                case CodeGenType.WinFromParentChildEditWithDialog:
                    GetFileds(out m_strShowColumnsDetail, lstShowFiledsDetail);
                    GetFileds(out m_strEditColumnsDetail, lstEditShowFiledsDetail);
                    GetFileds(out m_strCheckInputColumnsDetail, lstCheckInputFiledsDetail);
                    GetFileds(out m_strDontRepeatColumnsDetail, lstDontRepeatFiledsDetail);
                    m_baseParameter = new ParentChildEditDialogParameter()
                    {
                        QueryColumns = m_strQueryColumns,
                        ShowColumns = m_strShowColumns,
                        CodeGenType = m_codeGenType,
                        DatabaseTable = m_databaseTable,
                        FrameworkType = m_frameworkType,
                        DontRepeatColumns = m_strDontRepeatColumns,
                        CheckInputColumns = m_strCheckInputColumns,
                        EditColumns = m_strEditColumns,
                        UiStyle = m_uiStyle,
                        ListBindType = m_listBindType,
                        //明细表设置
                        ShowColumnsDetail = m_strShowColumnsDetail,
                        DontRepeatColumnsDetail = m_strDontRepeatColumnsDetail,
                        CheckInputColumnsDetail = m_strCheckInputColumnsDetail,
                        EditColumnsDetail = m_strEditColumnsDetail,
                        DatabaseTableDetail = m_databaseTableDetail,
                        KeyMaster = txtKeyMaster.Text.Trim(),
                        KeyDetail = txtKeyDetail.Text.Trim(),
                    };
                    break;
                #endregion
            }
            return m_baseParameter;
        }

        /// <summary>根据代码生成类型，设置某些控件显示/隐藏
        /// 
        /// </summary>
        private void SetVisible()
        {
            switch (m_codeGenType)
            {
                case CodeGenType.WinFromSimpleQuery:
                    //隐藏编辑选项
                    groupBox3.Visible = false;
                    grpTree.Visible = false;
                    break;
                case CodeGenType.WinFromTreeEditWithDialog:
                    groupBox3.Visible = true;
                    grpTree.Visible = true;
                    break;
                case CodeGenType.WinFromEditWithDialog:
                    groupBox3.Visible = true;
                    grpTree.Visible = false;
                    break;
                case CodeGenType.WinFromParentChildEditWithDialog:
                    groupBox3.Visible = true;
                    grpTree.Visible = false;
                    break;
            }
            if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                tabPage2.Parent = tabControl1;
                tabPage2.Show();
                tabPage1.Text = @"主表设置";
            }
            else
            {
                tabPage2.Parent = null;
                tabPage2.Hide();
                tabPage1.Text = @"基本设置";
            }
        }

        /// <summary>检查输入是否满足要求
        /// 
        /// </summary>
        /// <returns>true :满足</returns>
        private bool CheckInput()
        {
            const bool blnFalg = true;
            string strTable = cboTable.Text.Trim();
            int intCheckQueryCount = this.lstQueryFileds.CheckedItems.Count;
            int intCheckShowCount = this.lstShowFileds.CheckedItems.Count;
            int intCheckEditShowCount = this.lstEditShowFileds.CheckedItems.Count;
            int intCheckInputCount = this.lstCheckInputFileds.CheckedItems.Count;
            if (strTable == string.Empty)
            {
                MessageBox.Show(@"请选择操作表");
                cboTable.Select();
                return false;
            }
            if (intCheckQueryCount == 0)
            {
                MessageBox.Show(@"请选择查询条件字段");
                lstQueryFileds.Select();
                return false;
            }
            if (intCheckShowCount == 0)
            {
                MessageBox.Show(@"请选择显示字段");
                lstShowFileds.Select();
                return false;
            }
            switch (m_codeGenType)
            {
                case CodeGenType.WinFromSimpleQuery:
                    break;
                case CodeGenType.WinFromEditWithDialog:
                case CodeGenType.WinFromParentChildEditWithDialog:
                case CodeGenType.WinFromEdit:
                    if (intCheckEditShowCount == 0)
                    {
                        MessageBox.Show(@"请选择数据显示字段");
                        lstEditShowFileds.Select();
                        return false;
                    }
                    break;
                case CodeGenType.WinFromTreeEditWithDialog:
                    if (intCheckEditShowCount == 0)
                    {
                        MessageBox.Show(@"请选择数据显示字段");
                        lstEditShowFileds.Select();
                        return false;
                    }
                    if (txtKey.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show(@"请输入子键字段");
                        txtKey.Select();
                        return false;
                    }
                    if (txtParentKey.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show(@"请输入父键字段");
                        txtParentKey.Select();
                        return false;
                    }
                    break;
            }

            if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                int intCheckShowCountDetail = this.lstShowFiledsDetail.CheckedItems.Count;
                int intEditShowFiledsCountDetail = this.lstEditShowFiledsDetail.CheckedItems.Count;
                if (intCheckShowCountDetail == 0)
                {
                    MessageBox.Show(@"请选择明细表查询界面显示字段");
                    lstShowFiledsDetail.Select();
                    return false;
                }
                if (intEditShowFiledsCountDetail == 0)
                {
                    MessageBox.Show(@"请选择编辑界面明细表编辑字段");
                    lstEditShowFiledsDetail.Select();
                    return false;
                }
                if (txtKeyMaster.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(@"请输入主子表父键字段");
                    txtKeyMaster.Select();
                    return false;
                }
                if (txtKeyDetail.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(@"请输入主子表子键字段");
                    txtKeyDetail.Select();
                    return false;
                }
            }

            return blnFalg;
        }

        /// <summary>ListBox设置右键功能
        /// 
        /// </summary>
        /// <param name="strRightName"></param>
        private void SetContextMenuStrip(string strRightName)
        {
            List<CheckedListBox> lstBoxs = new List<CheckedListBox>
            {
                lstCheckInputFileds,
                lstEditShowFileds,
                lstQueryFileds,
                lstShowFileds, 
                lstDontRepeatFileds, 

                lstCheckInputFiledsDetail,
                lstEditShowFiledsDetail, 
                lstShowFiledsDetail, 
                lstDontRepeatFiledsDetail,
            };

            foreach (CheckedListBox lstBox in lstBoxs)
            {
                if (lstBox.Name == strRightName)
                {
                    lstBox.ContextMenuStrip = contextMenuStrip1;
                    contextMenuStrip1.Tag = lstBox;
                }
                else
                {
                    lstBox.ContextMenuStrip = null;
                }
            }
        }

        /// <summary>绑定ComboBox
        /// 
        /// </summary>
        private void BindComboBox()
        {
            List<DatabaseTable> tables = m_dbSchema.DatabaseSchema.Tables;
            if (tables != null)
            {
                ComboBoxHelper.BindComboBox(cboTable, tables, "Name", "Name");

                if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
                {
                    DataTable databaseTable = new DataTable();
                    databaseTable.Columns.Add("Name", typeof(string));
                    foreach (DatabaseTable item in tables)
                    {
                        DataRow dr = databaseTable.NewRow();
                        dr[0] = item.Name;
                        databaseTable.Rows.Add(dr);
                    }
                    ComboBoxHelper.BindComboBox(cboTableDetail, databaseTable, "Name", "Name");
                    cboTableDetail.Text = GlobalHelp.TreeView.SelectedNode.Text;
                }
            }
            cboTable.Text = GlobalHelp.TreeView.SelectedNode.Text;
        }

        /// <summary>绑定ListBox
        /// 
        /// </summary>
        private void BindListBox()
        {
            if (cboTable.Text.Trim() == string.Empty)
            {
                return;
            }
            m_databaseTable = m_dbSchema.DatabaseSchema.Tables.FirstOrDefault(t => t.Name == cboTable.Text);
            if (m_databaseTable != null)
            {
                List<DatabaseColumn> databaseColumn = m_databaseTable.Columns;
                CheckedListBoxHelper.BindCheckedListBox(lstCheckInputFileds, databaseColumn, "Name", "Name");
                CheckedListBoxHelper.BindCheckedListBox(lstEditShowFileds, databaseColumn, "Name", "Name");
                CheckedListBoxHelper.BindCheckedListBox(lstQueryFileds, databaseColumn, "Name", "Name");
                CheckedListBoxHelper.BindCheckedListBox(lstShowFileds, databaseColumn, "Name", "Name");
                CheckedListBoxHelper.BindCheckedListBox(lstDontRepeatFileds, databaseColumn, "Name", "Name");
            }
        }

        /// <summary>绑定ListBox
        /// 
        /// </summary>
        private void BindListBoxDetail()
        {
            if (cboTableDetail.Text.Trim() == string.Empty)
            {
                return;
            }
            m_databaseTableDetail = m_dbSchema.DatabaseSchema.Tables.FirstOrDefault(t => t.Name == cboTableDetail.Text);
            if (m_databaseTableDetail != null)
            {
                List<DatabaseColumn> databaseColumn = m_databaseTableDetail.Columns;
                CheckedListBoxHelper.BindCheckedListBox(lstCheckInputFiledsDetail, databaseColumn, "Name", "Name");
                CheckedListBoxHelper.BindCheckedListBox(lstEditShowFiledsDetail, databaseColumn, "Name", "Name");
                CheckedListBoxHelper.BindCheckedListBox(lstShowFiledsDetail, databaseColumn, "Name", "Name");
                CheckedListBoxHelper.BindCheckedListBox(lstDontRepeatFiledsDetail, databaseColumn, "Name", "Name");
            }
        }

        /// <summary>获取FrameworkType
        /// 
        /// </summary>
        /// <returns></returns>
        private FrameworkType GetFrameworkType()
        {
            foreach (Control ctlControl in this.groupBox4.Controls)
            {
                if (ctlControl.GetType().ToString() != "System.Windows.Forms.CheckBox") continue;
                CheckBox item = ctlControl as CheckBox;
                if (item == null || !item.Checked) continue;
                var name = Enum.GetName(typeof(FrameworkType), item.Text);
                if (name != null)
                {
                    return (FrameworkType)Enum.Parse(typeof(FrameworkType), name);
                }
            }
            return FrameworkType.简易两层;
        }

        /// <summary>获取UiStyle
        /// 
        /// </summary>
        /// <returns></returns>
        private UiStyle GetUiStyle()
        {
            foreach (Control ctlControl in this.groupBox5.Controls)
            {
                if (ctlControl.GetType().ToString() != "System.Windows.Forms.CheckBox") continue;
                CheckBox item = ctlControl as CheckBox;
                if (item == null || !item.Checked) continue;
                var name = Enum.GetName(typeof(UiStyle), item.Text);
                if (name != null)
                {
                    return (UiStyle)Enum.Parse(typeof(UiStyle), name);
                }
            }
            return UiStyle.传统WinForm;
        }

        /// <summary>获取ListBindType
        /// 
        /// </summary>
        /// <returns></returns>
        private ListBindType GetListBindType()
        {
            foreach (Control ctlControl in this.groupBox7.Controls)
            {
                if (ctlControl.GetType().ToString() != "System.Windows.Forms.CheckBox") continue;
                CheckBox item = ctlControl as CheckBox;
                if (item == null || !item.Checked) continue;
                var name = Enum.GetName(typeof(ListBindType), item.Text);
                if (name != null)
                {
                    return (ListBindType)Enum.Parse(typeof(ListBindType), name);
                }
            }
            return ListBindType.DataTable;
        }

        private void GetFileds(out string strColumns, CheckedListBox lstFileds)
        {
            strColumns = string.Empty;
            foreach (var item in lstFileds.CheckedItems)
            {
                var parameter = item as DatabaseColumn;
                if (parameter != null)
                    strColumns = strColumns + parameter.Name + ",";
            }
            strColumns = strColumns.TrimEnd(',');
        }

        #endregion 
    }
}
