using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Core;
using Nikita.Assist.CodeMaker;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmControlSetting : Form
    {
        //1，查询区域: LabelControl :lbl+Query+数据库列名，其它控件：如TextEdit ： txt+Query+列名;
        //2，显示区域:没有特殊设置控件的列：grid+控件类型（mrz）+列名,有特殊设置控件的列：如：RepositoryItemImageComboBox ：grid+控件类型（rib）+列名，同时要生成一个单独的RepositoryItemImageComboBox 控件，命名规则为ctlShow+控件类型(rib)+列名;
        //3，编辑区域:LabelControl :lbl+Edit+数据库列名,其它控件：如TextEdit ： txt+Edit+列名;
        private DataTable m_dtQuery;
        private DataTable m_dtShow;
        private DataTable m_dtEdit;
        private DataTable m_dtEditControlType;
        private DataTable m_dtShowControlType;
        private string m_strQueryColumns;
        private string m_strShowColumns;
        private string m_strEditColumns;
        private string m_strCheckInputColumns;
        private string m_strDontRepeatColumns;
        private DataTable m_dtColumns;
        private DatabaseTable m_databaseTable;

        //主子表 
        private DataTable m_dtShowDetail;
        private DataTable m_dtEditDetail;
        private string m_strShowColumnsDetail;
        private string m_strEditColumnsDetail;
        private string m_strCheckInputColumnsDetail;
        private string m_strDontRepeatColumnsDetail;
        private DataTable m_dtColumnsDetail;
        private DatabaseTable m_databaseTableDetail;
        private string m_strKeyMaster;
        private string m_strKeyDetail;

        private CodeGenType m_codeGenType;
        private FrameworkType m_frameworkType;
        private UiStyle m_uiStyle;
        private ListBindType m_listBindType;

        private Bse_ControlTypeDAL m_bseControlTypeDal;
        private Bse_UIDAL m_bseUiDal;
        public DataTable QueryDataTable { get; private set; }

        public FrmControlSetting(BaseParameter baseParameter)
        {
            InitializeComponent();

            SetGlobal(baseParameter);

            //嵌套查询
            if (baseParameter.CodeGenType != CodeGenType.WinFromNestQuery)
            {
                m_dtColumns = CodeMakerHelper.GetColumnByTbName(m_databaseTable.Name, m_databaseTable.DatabaseSchema.ConnectionString);
            }

            m_bseControlTypeDal = GlobalHelp.GetControlTypeHelper();
            m_bseUiDal = GlobalHelp.GetUiHelper();

            m_dtEditControlType = m_bseControlTypeDal.GetList(" Ctl_Type ='Common' and State=1").Tables[0];
            colQueryControlType.DataSource = m_dtEditControlType;
            colQueryControlType.ValueMember = "ControlType";
            colQueryControlType.DisplayMember = "ControlType";


            colEditControlType.DataSource = m_dtEditControlType.Copy();
            colEditControlType.ValueMember = "ControlType";
            colEditControlType.DisplayMember = "ControlType";

            m_dtShowControlType = m_bseControlTypeDal.GetList("Ctl_Type ='GridView' and State=1 ").Tables[0];
            colShowControlType.DataSource = m_dtShowControlType;
            colShowControlType.ValueMember = "ControlType";
            colShowControlType.DisplayMember = "ControlType";


            //主子表
            if (baseParameter.CodeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                gridVEditDetail.CellValueChanged += grdVEditDetail_CellValueChanged;
                gridVShowDetail.CellValueChanged += grdVShowDetail_CellValueChanged;
                colEditControlTypeDetail.DataSource = m_dtEditControlType.Copy();
                colEditControlTypeDetail.ValueMember = "ControlType";
                colEditControlTypeDetail.DisplayMember = "ControlType";

                colShowControlTypeDetail.DataSource = m_dtShowControlType.Copy();
                colShowControlTypeDetail.ValueMember = "ControlType";
                colShowControlTypeDetail.DisplayMember = "ControlType";

                m_dtColumnsDetail = CodeMakerHelper.GetColumnByTbName(m_databaseTableDetail.Name, m_databaseTableDetail.DatabaseSchema.ConnectionString);
            }

            gridVQuery.AutoGenerateColumns = false;
            gridVShow.AutoGenerateColumns = false;
            gridVEdit.AutoGenerateColumns = false;
            gridVShowDetail.AutoGenerateColumns = false;
            gridVEditDetail.AutoGenerateColumns = false;

        }

        private void SetGlobal(BaseParameter baseParameter)
        {
            switch (baseParameter.CodeGenType)
            {
                #region WinFromSimpleQuery
                case CodeGenType.WinFromSimpleQuery:
                    SimpleQueryParameter simpleQueryParameter = baseParameter as SimpleQueryParameter;
                    if (simpleQueryParameter != null)
                    {
                        m_strQueryColumns = simpleQueryParameter.QueryColumns;
                        m_strShowColumns = simpleQueryParameter.ShowColumns;
                        m_databaseTable = simpleQueryParameter.DatabaseTable;
                        m_codeGenType = simpleQueryParameter.CodeGenType;
                        m_frameworkType = simpleQueryParameter.FrameworkType;
                        m_uiStyle = simpleQueryParameter.UiStyle;
                        m_listBindType = simpleQueryParameter.ListBindType;
                        gridVEdit.Visible = false;
                        tabPageEdit.Parent = null;
                        tabPageEdit.Hide();

                        gridVShow.Visible = true;
                        tabPageShow.Parent = tabControl1;
                        tabPageShow.Show();
                    }
                    break;
                #endregion
                #region WinFromEditWithDialog/WinFromTreeEditWithDialog
                case CodeGenType.WinFromEditWithDialog:
                case CodeGenType.WinFromTreeEditWithDialog:
                    EditDialogParameter editDialogParameter = baseParameter as EditDialogParameter;
                    if (editDialogParameter != null)
                    {
                        m_strQueryColumns = editDialogParameter.QueryColumns;
                        m_strShowColumns = editDialogParameter.ShowColumns;
                        m_databaseTable = editDialogParameter.DatabaseTable;
                        m_codeGenType = editDialogParameter.CodeGenType;
                        m_frameworkType = editDialogParameter.FrameworkType;
                        m_uiStyle = editDialogParameter.UiStyle;
                        m_listBindType = editDialogParameter.ListBindType;
                        m_strEditColumns = editDialogParameter.EditColumns;
                        m_strCheckInputColumns = editDialogParameter.CheckInputColumns;
                        m_strDontRepeatColumns = editDialogParameter.DontRepeatColumns;
                        gridVEdit.Visible = true;
                        tabPageEdit.Parent = tabControl1;
                        tabPageEdit.Show();

                        gridVShow.Visible = true;
                        tabPageShow.Parent = tabControl1;
                        tabPageShow.Show();
                    }
                    break;
                #endregion
                #region WinFromNestQuery
                case CodeGenType.WinFromNestQuery:
                    NestQueryParameter nestQueryParameter = baseParameter as NestQueryParameter;
                    if (nestQueryParameter != null)
                    {
                        m_strQueryColumns = nestQueryParameter.QueryColumns;
                        m_codeGenType = nestQueryParameter.CodeGenType;
                        gridVEdit.Visible = false;
                        tabPageShow.Parent = null;
                        tabPageShow.Hide();
                        gridVShow.Visible = false;
                        tabPageEdit.Parent = null;
                        tabPageEdit.Hide();
                    }
                    break;
                #endregion
                #region WinFromParentChildEditWithDialog
                case CodeGenType.WinFromParentChildEditWithDialog:
                    ParentChildEditDialogParameter parentChildDialogParameter = baseParameter as ParentChildEditDialogParameter;
                    if (parentChildDialogParameter != null)
                    {
                        m_databaseTable = parentChildDialogParameter.DatabaseTable;
                        m_codeGenType = parentChildDialogParameter.CodeGenType;
                        m_frameworkType = parentChildDialogParameter.FrameworkType;
                        m_uiStyle = parentChildDialogParameter.UiStyle;
                        m_listBindType = parentChildDialogParameter.ListBindType;

                        m_strQueryColumns = parentChildDialogParameter.QueryColumns;
                        m_strShowColumns = parentChildDialogParameter.ShowColumns;
                        m_strEditColumns = parentChildDialogParameter.EditColumns;
                        m_strCheckInputColumns = parentChildDialogParameter.CheckInputColumns;
                        m_strDontRepeatColumns = parentChildDialogParameter.DontRepeatColumns;

                        m_strShowColumnsDetail = parentChildDialogParameter.ShowColumnsDetail;
                        m_strEditColumnsDetail = parentChildDialogParameter.EditColumnsDetail;
                        m_strCheckInputColumnsDetail = parentChildDialogParameter.CheckInputColumnsDetail;
                        m_strDontRepeatColumnsDetail = parentChildDialogParameter.DontRepeatColumnsDetail;
                        m_databaseTableDetail = parentChildDialogParameter.DatabaseTableDetail;
                        m_strKeyMaster = parentChildDialogParameter.KeyMaster;
                        m_strKeyDetail = parentChildDialogParameter.KeyDetail;

                        gridVEdit.Visible = true;
                        tabPageEdit.Parent = tabControl1;
                        tabPageEdit.Show();

                        gridVShow.Visible = true;
                        tabPageShow.Parent = tabControl1;
                        tabPageShow.Show();
                    }
                    break;
                #endregion
            }
            if (baseParameter.CodeGenType != CodeGenType.WinFromParentChildEditWithDialog)
            {
                tabPageEditDetail.Parent = null;
                tabPageShowDetail.Parent = null;
                tabPageEditDetail.Hide();
                tabPageShowDetail.Hide();
            }
            else
            {
                tabPageEditDetail.Parent = tabControl1;
                tabPageShowDetail.Parent = tabControl1;
                tabPageEditDetail.Show();
                tabPageShowDetail.Show();
            }
        }

        private void FrmControlSetting_Load(object sender, EventArgs e)
        {
            m_dtQuery = GenTableByCheckColumns(m_dtColumns, "OneQuery", m_strQueryColumns);
            gridVQuery.DataSource = m_dtQuery;
            m_dtShow = GenTableByCheckColumns(m_dtColumns, "OneShow", m_strShowColumns);
            gridVShow.DataSource = m_dtShow;
            m_dtEdit = GenTableByCheckColumns(m_dtColumns, "OneEdit", m_strEditColumns);
            gridVEdit.DataSource = m_dtEdit;
            if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                m_dtShowDetail = GenTableByCheckColumns(m_dtColumnsDetail, "OneShow", m_strShowColumnsDetail);
                gridVShowDetail.DataSource = m_dtShowDetail;
                m_dtEditDetail = GenTableByCheckColumns(m_dtColumnsDetail, "OneEdit", m_strEditColumnsDetail);
                gridVEditDetail.DataSource = m_dtEditDetail;
            }
        }

        /// <summary>确定设置
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            #if   !DEBUG
            m_bseUiDal.DeleteByCond("1=1");  
            #endif
            try
            {
                btnOK.Enabled = false;
                if (m_codeGenType == CodeGenType.WinFromNestQuery)
                {
                    this.DialogResult = DialogResult.OK;
                    QueryDataTable = m_dtQuery;
                }
                else
                {
                    #region 查询

                    if (DataTableHelper.IsHaveRows(m_dtQuery))
                    {
                        for (int i = 0; i < m_dtQuery.Rows.Count; i++)
                        {
                            InsertControl("Query",
                                m_dtQuery.Rows[i]["ColumnName"].ToString(),
                                m_dtQuery.Rows[i]["ColumnType"].ToString(),
                                m_dtQuery.Rows[i]["ControlNameSpace"].ToString(),
                                m_dtQuery.Rows[i]["ControlType"].ToString(),
                                m_dtQuery.Rows[i]["Ctl_Simple"].ToString(),
                                m_dtQuery.Rows[i]["ControlName"].ToString(),
                                m_dtQuery.Rows[i]["GridSpeicalCtlName"].ToString(),
                                m_dtQuery.Rows[i]["ControlSort"].ToString(),
                                m_dtQuery.Rows[i]["DefaultValue"].ToString(),
                                m_dtQuery.Rows[i]["IsAddLable"].ToString(),
                                m_dtQuery.Rows[i]["LabelName"].ToString(),
                                m_dtQuery.Rows[i]["LabelText"].ToString(),
                                m_dtQuery.Rows[i]["IsNeed"].ToString(),
                                m_dtQuery.Rows[i]["FiledText"].ToString(),
                                m_dtQuery.Rows[i]["FiledValue"].ToString(),
                                m_dtQuery.Rows[i]["DataSourse"].ToString());
                        }
                    }

                    #endregion

                    #region 编辑

                    if (DataTableHelper.IsHaveRows(m_dtEdit))
                    {
                        for (int i = 0; i < m_dtEdit.Rows.Count; i++)
                        {
                            InsertControl("Edit",
                                m_dtEdit.Rows[i]["ColumnName"].ToString(),
                                m_dtEdit.Rows[i]["ColumnType"].ToString(),
                                m_dtEdit.Rows[i]["ControlNameSpace"].ToString(),
                                m_dtEdit.Rows[i]["ControlType"].ToString(),
                                m_dtEdit.Rows[i]["Ctl_Simple"].ToString(),
                                m_dtEdit.Rows[i]["ControlName"].ToString(),
                                m_dtEdit.Rows[i]["GridSpeicalCtlName"].ToString(),
                                m_dtEdit.Rows[i]["ControlSort"].ToString(),
                                m_dtEdit.Rows[i]["DefaultValue"].ToString(),
                                m_dtEdit.Rows[i]["IsAddLable"].ToString(),
                                m_dtEdit.Rows[i]["LabelName"].ToString(),
                                m_dtEdit.Rows[i]["LabelText"].ToString(),
                                m_dtEdit.Rows[i]["IsNeed"].ToString(),
                                m_dtEdit.Rows[i]["FiledText"].ToString(),
                                m_dtEdit.Rows[i]["FiledValue"].ToString(),
                                m_dtEdit.Rows[i]["DataSourse"].ToString() );
                        }
                    }

                    #endregion

                    #region 显示

                    if (DataTableHelper.IsHaveRows(m_dtShow))
                    {
                        for (int i = 0; i < m_dtShow.Rows.Count; i++)
                        {
                            InsertControl("Show",
                                m_dtShow.Rows[i]["ColumnName"].ToString(),
                                m_dtShow.Rows[i]["ColumnType"].ToString(),
                                m_dtShow.Rows[i]["ControlNameSpace"].ToString(),
                                m_dtShow.Rows[i]["ControlType"].ToString(),
                                m_dtShow.Rows[i]["Ctl_Simple"].ToString(),
                                m_dtShow.Rows[i]["ControlName"].ToString(),
                                m_dtShow.Rows[i]["GridSpeicalCtlName"].ToString(),
                                m_dtShow.Rows[i]["ControlSort"].ToString(),
                                m_dtShow.Rows[i]["DefaultValue"].ToString(),
                                m_dtShow.Rows[i]["IsAddLable"].ToString(),
                                m_dtShow.Rows[i]["LabelName"].ToString(),
                                m_dtShow.Rows[i]["LabelText"].ToString(),
                                m_dtShow.Rows[i]["IsNeed"].ToString(),
                                m_dtShow.Rows[i]["FiledText"].ToString(),
                                m_dtShow.Rows[i]["FiledValue"].ToString(),
                                m_dtShow.Rows[i]["DataSourse"].ToString());
                        }
                    }

                    #endregion

                    if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
                    {

                        #region 编辑明细

                        if (DataTableHelper.IsHaveRows(m_dtEditDetail))
                        {
                            for (int i = 0; i < m_dtEditDetail.Rows.Count; i++)
                            {
                                InsertControl("Edit",
                                    m_dtEditDetail.Rows[i]["ColumnName"].ToString(),
                                    m_dtEditDetail.Rows[i]["ColumnType"].ToString(),
                                    m_dtEditDetail.Rows[i]["ControlNameSpace"].ToString(),
                                    m_dtEditDetail.Rows[i]["ControlType"].ToString(),
                                    m_dtEditDetail.Rows[i]["Ctl_Simple"].ToString(),
                                    m_dtEditDetail.Rows[i]["ControlName"].ToString(),
                                    m_dtEditDetail.Rows[i]["GridSpeicalCtlName"].ToString(),
                                    m_dtEditDetail.Rows[i]["ControlSort"].ToString(),
                                    m_dtEditDetail.Rows[i]["DefaultValue"].ToString(),
                                    m_dtEditDetail.Rows[i]["IsAddLable"].ToString(),
                                    m_dtEditDetail.Rows[i]["LabelName"].ToString(),
                                    m_dtEditDetail.Rows[i]["LabelText"].ToString(),
                                    m_dtEditDetail.Rows[i]["IsNeed"].ToString(),
                                    m_dtEditDetail.Rows[i]["FiledText"].ToString(),
                                    m_dtEditDetail.Rows[i]["FiledValue"].ToString(),
                                    m_dtEditDetail.Rows[i]["DataSourse"].ToString(),
                                strTableName: m_databaseTableDetail.Name);
                            }
                        }

                        #endregion

                        #region 显示明细

                        if (DataTableHelper.IsHaveRows(m_dtShowDetail))
                        {
                            for (int i = 0; i < m_dtShowDetail.Rows.Count; i++)
                            {
                                InsertControl("Show",
                                    m_dtShowDetail.Rows[i]["ColumnName"].ToString(),
                                    m_dtShowDetail.Rows[i]["ColumnType"].ToString(),
                                    m_dtShowDetail.Rows[i]["ControlNameSpace"].ToString(),
                                    m_dtShowDetail.Rows[i]["ControlType"].ToString(),
                                    m_dtShowDetail.Rows[i]["Ctl_Simple"].ToString(),
                                    m_dtShowDetail.Rows[i]["ControlName"].ToString(),
                                    m_dtShowDetail.Rows[i]["GridSpeicalCtlName"].ToString(),
                                    m_dtShowDetail.Rows[i]["ControlSort"].ToString(),
                                    m_dtShowDetail.Rows[i]["DefaultValue"].ToString(),
                                    m_dtShowDetail.Rows[i]["IsAddLable"].ToString(),
                                    m_dtShowDetail.Rows[i]["LabelName"].ToString(),
                                    m_dtShowDetail.Rows[i]["LabelText"].ToString(),
                                    m_dtShowDetail.Rows[i]["IsNeed"].ToString(),
                                    m_dtShowDetail.Rows[i]["FiledText"].ToString(),
                                    m_dtShowDetail.Rows[i]["FiledValue"].ToString(),
                                    m_dtShowDetail.Rows[i]["DataSourse"].ToString(),
                                strTableName:m_databaseTableDetail.Name);
                            }
                        }

                        #endregion

                    }

                }
                MessageBox.Show(@"设置成功");
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                btnOK.Enabled = true;
            }

        }

        private void grdVQuery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dtQuery == null || e.RowIndex == -1)
                return;
            if (this.gridVQuery.Columns[e.ColumnIndex].DataPropertyName == "ControlType")
            {
                var dataRowView = this.gridVQuery.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    string controlType = this.gridVQuery.Rows[e.RowIndex].Cells[colQueryControlType.Name].Value.ToString();
                    DataTable dt = GetControlInfoByCtrlType(controlType);
                    string ctlSimple = dt.Rows[0]["Ctl_Simple"].ToString();
                    string ctlNameSpace = dt.Rows[0]["Ctl_NameSpace"].ToString();
                    if (dr != null)
                    {
                        dr["ControlNameSpace"] = ctlNameSpace;
                        dr["Ctl_Simple"] = ctlSimple;
                        //编辑区域:LabelControl :lab+Edit+数据库列名,其它控件：如TextEdit ： txt+Edit+列名 
                        string columnName = this.gridVQuery.Rows[e.RowIndex].Cells[colQueryColumnName.Name].Value.ToString();
                        string labelName = GenLableControlName("Query", columnName);
                        dr["LabelName"] = labelName;
                        string ctlName = GenCtrlNameByCtlSimple("Query", ctlSimple, columnName);
                        dr["ControlName"] = ctlName;
                    }
                }
            }
        }
        private void grdVEdit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dtEdit == null || e.RowIndex == -1)
                return;
            if (this.gridVEdit.Columns[e.ColumnIndex].DataPropertyName == "ControlType")
            {
                var dataRowView = this.gridVEdit.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    string controlType = this.gridVEdit.Rows[e.RowIndex].Cells[colEditControlType.Name].Value.ToString();
                    DataTable dt = GetControlInfoByCtrlType(controlType);
                    string ctlSimple = dt.Rows[0]["Ctl_Simple"].ToString();
                    if (dr != null)
                    {
                        dr["Ctl_Simple"] = ctlSimple;
                        string ctlNameSpace = dt.Rows[0]["Ctl_NameSpace"].ToString();
                        dr["ControlNameSpace"] = ctlNameSpace;
                        //编辑区域:LabelControl :lbl+Edit+数据库列名,其它控件：如TextEdit ： txt+Edit+列名
                        string columnName = this.gridVEdit.Rows[e.RowIndex].Cells[colEditColumnName.Name].Value.ToString();
                        string labelName = GenLableControlName("Edit", columnName);
                        dr["LabelName"] = labelName;
                        string ctlName = GenCtrlNameByCtlSimple("Edit", ctlSimple, columnName);
                        dr["ControlName"] = ctlName;
                    }
                }
            }
        }

        private void grdVShow_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dtShow == null || e.RowIndex == -1)
                return;
            if (this.gridVShow.Columns[e.ColumnIndex].DataPropertyName == "ControlType")
            {
                var dataRowView = this.gridVShow.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    string controlType = this.gridVShow.Rows[e.RowIndex].Cells[colShowControlType.Name].Value.ToString();
                    DataTable dt = GetShowControlInfoByCtrlType(controlType);
                    string ctlSimple = dt.Rows[0]["Ctl_Simple"].ToString();
                    string ctlNameSpace = dt.Rows[0]["Ctl_NameSpace"].ToString();
                    if (dr != null)
                    {
                        dr["ControlNameSpace"] = ctlNameSpace;
                        dr["Ctl_Simple"] = ctlSimple;
                        //编辑区域:LabelControl :lab+Show+数据库列名,其它控件：如TextEdit ： txt+Show+列名
                        string columnName = this.gridVShow.Rows[e.RowIndex].Cells[colShowColumnName.Name].Value.ToString();
                        string labelName = GenLableControlName("Show", columnName);
                        dr["LabelName"] = labelName;
                        string ctlName = GenCtrlNameByCtlSimple("Show", ctlSimple, columnName);
                        dr["ControlName"] = ctlName;
                        if (ctlNameSpace != string.Empty)
                        {
                            dr["GridSpeicalCtlName"] = "CtrlShow" + ctlSimple + columnName;
                        }
                    }
                }
            }
        }

        #region 父子表编辑

        private void grdVEditDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dtEditDetail == null || e.RowIndex == -1)
                return;
            if (this.gridVEditDetail.Columns[e.ColumnIndex].DataPropertyName == "ControlType")
            {
                var dataRowView = this.gridVEditDetail.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    string controlType = this.gridVEditDetail.Rows[e.RowIndex].Cells[colEditControlTypeDetail.Name].Value.ToString();
                    DataTable dt = GetControlInfoByCtrlType(controlType);
                    string ctlSimple = dt.Rows[0]["Ctl_Simple"].ToString();
                    if (dr != null)
                    {
                        dr["Ctl_Simple"] = ctlSimple;
                        string ctlNameSpace = dt.Rows[0]["Ctl_NameSpace"].ToString();
                        dr["ControlNameSpace"] = ctlNameSpace;
                        //编辑区域:LabelControl :lbl+Edit+数据库列名,其它控件：如TextEdit ： txt+Edit+列名
                        string columnName = this.gridVEditDetail.Rows[e.RowIndex].Cells[colEditColumnNameDetail.Name].Value.ToString();
                        string labelName = GenLableControlName("DetailEdit", columnName);
                        dr["LabelName"] = labelName;
                        string ctlName = GenCtrlNameByCtlSimple("DetailEdit", ctlSimple, columnName);
                        dr["ControlName"] = ctlName;
                    }
                }
            }
        }

        private void grdVShowDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dtShowDetail == null || e.RowIndex == -1)
                return;
            if (this.gridVShowDetail.Columns[e.ColumnIndex].DataPropertyName == "ControlType")
            {
                var dataRowView = this.gridVShowDetail.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    string controlType = this.gridVShowDetail.Rows[e.RowIndex].Cells[colShowControlTypeDetail.Name].Value.ToString();
                    DataTable dt = GetShowControlInfoByCtrlType(controlType);
                    string ctlSimple = dt.Rows[0]["Ctl_Simple"].ToString();
                    string ctlNameSpace = dt.Rows[0]["Ctl_NameSpace"].ToString();
                    if (dr != null)
                    {
                        dr["ControlNameSpace"] = ctlNameSpace;
                        dr["Ctl_Simple"] = ctlSimple;
                        //编辑区域:LabelControl :lab+Show+数据库列名,其它控件：如TextEdit ： txt+Show+列名
                        string columnName = this.gridVShowDetail.Rows[e.RowIndex].Cells[colShowColumnNameDetail.Name].Value.ToString();
                        string labelName = GenLableControlName("DetailShow", columnName);
                        dr["LabelName"] = labelName;
                        string ctlName = GenCtrlNameByCtlSimple("DetailShow", ctlSimple, columnName);
                        dr["ControlName"] = ctlName;
                        if (ctlNameSpace != string.Empty)
                        {
                            dr["GridSpeicalCtlName"] = "CtrlShow" + ctlSimple + columnName;
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>单表生成根据控件的缩写和列名生成控件名称
        /// 
        /// </summary>
        /// <param name="strPanel">控件区域：Query,Show,Edit</param>
        /// <param name="strCtlSimple">控件缩写</param>
        /// <param name="strColumnName">列名</param>
        /// <returns></returns>
        private string GenCtrlNameByCtlSimple(string strPanel, string strCtlSimple, string strColumnName)
        {
            string strCtlName = string.Empty;
            if (strPanel == "Query")
            {
                strCtlName = strCtlSimple + strPanel + strColumnName;
            }
            if (strPanel == "Show" || strPanel == "DetailShow")
            {
                if (strPanel == "DetailShow")
                {
                    strCtlName = "gridDetail" + strCtlSimple + strColumnName;
                }
                else
                { 
                    strCtlName = "grid" + strCtlSimple + strColumnName;
                }
            }
            if (strPanel == "Edit" || strPanel == "DetailEdit")
            {
                // 编辑区域:LabelControl :lab+Edit+数据库列名,其它控件：如TextEdit ： txt+Edit+列名
                strCtlName = strCtlSimple + strPanel + strColumnName;
            }
            return strCtlName;
        }

        /// <summary>单表生成根据控件的列名生成Label控件名称
        /// 
        /// </summary>
        /// <param name="strPanel">控件区域：Query,Show,Edit</param> 
        /// <param name="strColumnName">列名</param>
        /// <returns></returns>
        private string GenLableControlName(string strPanel, string strColumnName)
        {
            //编辑区域:LabelControl :lbl+Edit+数据库列名,其它控件：如TextEdit ： txt+Edit+列名
            var strCtlName = "lbl" + strPanel + strColumnName;
            return strCtlName;
        }

        /// <summary>根据Common和GridView获取控件信息
        /// 
        /// </summary>
        /// <param name="strCtrlType">Common:编辑区和查询区所用控件列表，GridView：显示区域所用控件列表</param>
        /// <returns></returns>
        private DataTable GetControlInfo(string strCtrlType)
        {
            Bse_ControlTypeDAL controlTypeDal = new Bse_ControlTypeDAL();
            return controlTypeDal.GetList("State=1 and ([Ctl_Type]='" + strCtrlType + "' OR '" + strCtrlType + "'='')").Tables[0];
        }

        /// <summary>根据控件类型，从控件信息表中获取该类型的信息
        /// 
        /// </summary>
        /// <param name="strControlType">控件类型：TxtEdit等</param>
        /// <returns></returns>
        private DataTable GetControlInfoByCtrlType(string strControlType)
        {
            DataTable dt = m_dtEditControlType.Select("ControlType = '" + strControlType + "'").CopyToDataTable();
            return dt;
        }

        /// <summary>根据控件类型，从控件信息表中获取该类型的信息
        /// 
        /// </summary>
        /// <param name="strControlType">控件类型：TxtEdit等</param>
        /// <returns></returns>
        private DataTable GetShowControlInfoByCtrlType(string strControlType)
        {
            if (m_dtShowControlType == null)
                return null;
            DataTable dt = m_dtShowControlType.Select("ControlType = '" + strControlType + "'").CopyToDataTable();
            return dt;
        }

        /// <summary>根据列名获取列类型
        /// 
        /// </summary>
        /// <param name="dtColumns">列集合</param>
        /// <param name="strColumnName">列名</param>
        /// <returns></returns>
        private string GetColumnTypeByColumnName(DataTable dtColumns, string strColumnName)
        {
            string strColumnType = dtColumns.Select("字段名 ='" + strColumnName + "' ")[0]["类型"].ToString();
            return strColumnType;
        }

        private DataTable GenTableByCheckColumns(DataTable dtColumns, string strType, string strColumns)
        {
            DataTable dt = new DataTable();
            switch (strType)
            {
                case "OneQuery":
                case "OneShow":
                case "OneEdit":
                    dt = GenTable(dtColumns, strColumns);
                    break;
            }
            return dt;
        }

        /// <summary>根据列生成默认数据
        /// 
        /// </summary>
        /// <param name="dtColumns"></param>
        /// <param name="strColumns"></param>
        /// <returns></returns>
        private DataTable GenTable(DataTable dtColumns, string strColumns)
        {
            if (string.IsNullOrEmpty(strColumns))
            {
                return null;
            }

            var dt = m_bseUiDal.GetList("1=2").Tables[0];
            string[] columnsAry = strColumns.Split(',');
            if (columnsAry.Length > 0)
            {
                for (int i = 0; i < columnsAry.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ColumnName"] = columnsAry[i];
                    if (i == 0)
                    {
                        dr["ControlSort"] = 1;
                    }
                    else
                    {
                        dr["ControlSort"] = i * 5;
                    }
                    dr["IsAddLable"] = "True";
                    if (m_codeGenType == CodeGenType.WinFromNestQuery)
                    {
                        dr["ColumnType"] = string.Empty;
                    }
                    else
                    {
                        string strColumnType = GetColumnTypeByColumnName(dtColumns, columnsAry[i]);
                        dr["ColumnType"] = strColumnType;
                    }
                    dr["Remark"] = string.Empty;
                    dr["State"] = 1;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void InsertControl(string strPanelName, string strColumnName, string strColumnType,
            string strControlNameSpace, string strControlType, string strCtl_Simple,
            string strControlName, string strGridSpeicalCtlName, string strControlSort,
            string strDefaultValue, string strIsAddLable, string strLabelName,
            string strLabelText, string strIsNeed, string strFiledText,
            string strFiledValue, string strDataSourse, string strDefaultFiledText = "",
            string strDefaultFiledValue = "", string strDefaultDataSourse = "", string strTableName = "")
        {
            Bse_UI modelUi = new Bse_UI
            {
                TableName = strTableName == string.Empty ? m_databaseTable.Name : strTableName,
                PanelName = strPanelName,
                ColumnName = strColumnName,
                ColumnType = strColumnType,
                ControlNameSpace = strControlNameSpace,
                ControlType = strControlType,
                Ctl_Simple = strCtl_Simple,
                ControlName = strControlName,
                GridSpeicalCtlName = strGridSpeicalCtlName,
                ControlSort = strControlSort,
                DefaultValue = strDefaultValue,
                IsAddLable = strIsAddLable,
                LabelName = strLabelName,
                LabelText = strLabelText,
                IsNeed = strIsNeed,
                FiledText = strFiledText,
                FiledValue = strFiledValue,
                DataSourse = strDataSourse,
                DefaultFiledText = strDefaultFiledText,
                DefaultFiledValue = strDefaultFiledValue,
                DefaultDataSourse = strDefaultDataSourse,
                Remark = string.Empty,
                State = 1
            };
            m_bseUiDal.Add(modelUi);
        }

        private void btnSetDefaultControl_Click(object sender, EventArgs e)
        {
            if (m_codeGenType != CodeGenType.WinFromSimpleQuery)
            {
                for (int i = 0; i < gridVEdit.RowCount; i++)
                {
                    this.gridVEdit.Rows[i].Selected = true;
                    var dataGridViewColumn = this.gridVEdit.Columns[colEditControlType.Name];
                    if (dataGridViewColumn != null)
                        dataGridViewColumn.Selected = true;
                    this.gridVEdit.Rows[i].Cells[colEditControlType.Name].Value = "TextBox";
                }
            }

            for (int i = 0; i < gridVQuery.RowCount; i++)
            {
                this.gridVQuery.Rows[i].Selected = true;
                var dataGridViewColumn = this.gridVQuery.Columns[colQueryControlType.Name];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.Selected = true;
                this.gridVQuery.Rows[i].Cells[colQueryControlType.Name].Value = "TextBox";
            }

            for (int i = 0; i < gridVShow.RowCount; i++)
            {
                this.gridVShow.Rows[i].Selected = true;
                var dataGridViewColumn = this.gridVShow.Columns[colShowControlType.Name];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.Selected = true;
                this.gridVShow.Rows[i].Cells[colShowControlType.Name].Value = "默认";
            }

            if (m_codeGenType == CodeGenType.WinFromParentChildEditWithDialog)
            {
                for (int i = 0; i < gridVEditDetail.RowCount; i++)
                {
                    this.gridVEditDetail.Rows[i].Selected = true;
                    var dataGridViewColumn = this.gridVEditDetail.Columns[colEditControlTypeDetail.Name];
                    if (dataGridViewColumn != null)
                        dataGridViewColumn.Selected = true;
                    this.gridVEditDetail.Rows[i].Cells[colEditControlTypeDetail.Name].Value = "TextBox";
                }

                for (int i = 0; i < gridVShowDetail.RowCount; i++)
                {
                    this.gridVShowDetail.Rows[i].Selected = true;
                    var dataGridViewColumn = this.gridVShowDetail.Columns[colShowControlTypeDetail.Name];
                    if (dataGridViewColumn != null)
                        dataGridViewColumn.Selected = true;
                    this.gridVShowDetail.Rows[i].Cells[colShowControlTypeDetail.Name].Value = "默认";
                }
            }
        }

    }
}
