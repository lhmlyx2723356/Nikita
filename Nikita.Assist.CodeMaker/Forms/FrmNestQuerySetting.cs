using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.Assist.CodeMaker.Template.ClassTemplate;
using Nikita.DataAccess4DBHelper;
using Nikita.WinForm.ExtendControl;
using DbHelper = Nikita.DataAccess4DBHelper.DbHelper;
using Nikita.Base.Define;
using WeifenLuo.WinFormsUI.Docking;


namespace Nikita.Assist.CodeMaker
{
    public partial class FrmNestQuerySetting : DockContentEx
    {

        private CodeGenType m_codeGenType;
        private DbSchema m_dbSchema;
        private DataTable m_dtQuery;

        public FrmNestQuerySetting(DbSchema dbSchema, CodeGenType codeGenType)
        {
            InitializeComponent();
            m_codeGenType = codeGenType;
            m_dbSchema = dbSchema;
            grdQuery.AutoGenerateColumns = false;
            if (codeGenType == CodeGenType.WinFromNestQuery)
            {
                cboNestType.SelectedIndex = 0;
                txtSql.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
                txtSql1.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
                txtSql2.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            }
        }

        private void cboNestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNestType.Text == string.Empty)
            {
                return;
            }
            if (cboNestType.Text == @"两层")
            {
                txtSql2.Visible = false;
                lblInfo.Visible = false;
                txtSql2.Text = string.Empty;
                txtKey2.Visible = false;
                lblKey2.Visible = false;
                txtKey2.Text = string.Empty;
            }
            else
            {
                txtSql2.Visible = true;
                lblInfo.Visible = true;
                txtKey2.Visible = true;
                lblKey2.Visible = true;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string strReturnMsg = CheckInput(m_codeGenType);
            if (strReturnMsg != string.Empty)
            {
                MessageBox.Show(strReturnMsg);
                return;
            }

            BasicParameter basicParameter = ParameterManager.GetBasicParameter(string.Empty);

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("\"");
            sbSql.Append(txtSql.Text.Replace("\r\n", " "));
            sbSql.Append(" WHERE  \" + strWhere + \"  ");
            sbSql.Append(txtSql1.Text.Replace("\r\n", " "));
            sbSql.Append("    ");
            sbSql.Append(txtSql2.Text.Replace("\r\n", " "));
            sbSql.Append("\"");

            NestQueryParameter nestQueryParameter = new NestQueryParameter
            {
                CodeGenType = CodeGenType.WinFromNestQuery,
                Key1 = txtKey.Text.Trim(),
                Key2 = txtKey1.Text.Trim(),
                Key3 = txtKey2.Text.Trim(),
                Sql = sbSql.ToString(),
                DataTableQuery = m_dtQuery,
                FormClassName = txtClassName.Text.Trim()
            };
            CodeMakeDirector director = new CodeMakeDirector();
            CodeMakeBulider bulider = new TemplateWinFormNestQuery();
            string[] strArray = director.Construct(bulider, basicParameter, nestQueryParameter);
            string strFrmDialogClassName = txtClassName.Text.Trim() + ".cs";
            string strContentCS = strArray[0];
            FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmDialogClassName, strContentCS, false);
            string strFrmDialogClassNameDesigner = txtClassName.Text.Trim() + ".Designer.cs";
            string strContentDesigner = strArray[1];
            FileHelper.GenFile(basicParameter.OutFolderPath + "\\Code\\", strFrmDialogClassNameDesigner, strContentDesigner);
        }

        private string CheckInput(CodeGenType mCodeGenType)
        {
            string strRetrunMsg = string.Empty;
            if (mCodeGenType == CodeGenType.WinFromNestQuery)
            {
                if (txtClassName.Text.Trim() == string.Empty)
                {
                    txtClassName.Select();
                    return "请输入窗体类名";
                }
                if (txtSql.Text.Trim() == string.Empty)
                {
                    txtSql.Select();
                    return "请输入主表查询语句";
                }
                if (txtKey.Text.Trim() == string.Empty)
                {
                    txtKey.Select();
                    return "请输入关联键";
                }
                if (txtSql1.Text.Trim() == string.Empty)
                {
                    txtSql1.Select();
                    return "请输入子表查询语句";
                }
                if (txtKey1.Text.Trim() == string.Empty)
                {
                    txtKey.Select();
                    return "请输入主表关联键";
                }
                if (cboNestType.Text == @"三层")
                {
                    if (txtSql2.Text.Trim() == string.Empty)
                    {
                        txtSql2.Select();
                        return "请输入明细表查询语句";
                    }
                    if (txtKey2.Text.Trim() == string.Empty)
                    {
                        txtKey.Select();
                        return "请输入子表关联键";
                    }
                }
            }
            return strRetrunMsg;
        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            string strReturnMsg = CheckInput(m_codeGenType);
            if (strReturnMsg != string.Empty)
            {
                MessageBox.Show(strReturnMsg);
                return;
            }
            DataSet ds = GetData();
            FrmNestQueryPreview frmPreview = new FrmNestQueryPreview(ds);
            if (frmPreview.ShowDialog() == DialogResult.OK)
            {
                m_dtQuery = frmPreview.QueryDataTable;
                grdQuery.DataSource = m_dtQuery;
            }
        }



        /// <summary> 获取数据源
        /// 
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetData()
        {
            IDbHelper dbHelper = DbHelper.GetDbHelper(SqlType.SqlServer, m_dbSchema.DatabaseSchema.ConnectionString);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(txtSql.Text);
            sb.AppendLine(txtSql1.Text);
            sb.AppendLine(txtSql2.Text);
            dbHelper.CreateCommand(sb.ToString());
            DataSet dataSet = dbHelper.ExecuteQueryDataSet();
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                dataSet.Tables[i].TableName = "T" + (i + 1);
            }
            //这是对应关系的时候主键必须唯一 
            string strPK = txtKey.Text.Trim();
            string strForign = txtKey1.Text.Trim();
            string strKey2 = txtKey2.Text.Trim();
            if (dataSet.Tables.Count == 3)
            {
                dataSet.Relations.Add("1", dataSet.Tables["T1"].Columns[strPK], dataSet.Tables["T2"].Columns[strForign]);
                dataSet.Relations.Add("2", dataSet.Tables["T2"].Columns[strForign], dataSet.Tables["T3"].Columns[strKey2]);
            }
            else if (dataSet.Tables.Count == 2)
            {
                dataSet.Relations.Add("1", dataSet.Tables["T1"].Columns[strPK], dataSet.Tables["T2"].Columns[strForign]);
            }
            return dataSet;
        }
    }
}
