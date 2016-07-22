using Nikita.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.Model;

namespace Nikita.Assist.CodeMaker.Template.ClassTemplate
{
    public class TemplateWinFormNestQuery : CodeMakeBulider
    {
        public static int SumWidth = 1000;
        public static int BeginWidth = 15;
        public static int LocationX = 15;
        public static int CtlSpace = 11;
        public static int LocationY = 15;
        public static int HighSeed = 33;

        public static int SumWidthEdit = 1000;
        public static int BeginWidthEdit = 15;
        public static int LocationXEdit = 15;
        public static int LocationYEdit = 15;
        public static int HighSeedEdit = 25;

        public static int QueryHeight = 1;
        public static int EditHeight = 1;
        public override  string GenWinFormCS(BasicParameter parameter,
        BaseParameter baseParameter )
        {
            NestQueryParameter nestQuerySetting = baseParameter as NestQueryParameter;
            string strFrmClassName = nestQuerySetting.FormClassName;
            string strModelName = parameter.TableName;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/// <summary>说明:" + strFrmClassName + "文件");
            sb.AppendLine("/// 作者:" + parameter.Author + "");
            sb.AppendLine("/// 创建时间:" + DateTime.Now + "");
            sb.AppendLine("/// </summary>");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Drawing;");
            sb.AppendLine("using System.Diagnostics;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Xml.Linq;");
            sb.AppendLine("using Microsoft.VisualBasic;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Windows.Forms;");
            sb.AppendLine("using Nikita.WinForm.ExtendControl;");
            sb.AppendLine("using System.Reflection;");
            sb.AppendLine("using Nikita.Core;");
            sb.AppendLine("using Nikita.DataAccess4DBHelper;");
            sb.AppendLine("using Nikita.Base.Define;"); 

            sb.AppendLine("namespace " + parameter.NameSpace + "");
            sb.AppendLine("{");
            sb.AppendLine("    public partial class " + strFrmClassName + "");
            sb.AppendLine("    {");
            #region   变量、常量
            sb.AppendLine("        #region 变量、常量");
            sb.AppendLine("        /// <summary>显示控件");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        MasterControl _masterDetail;");
            sb.AppendLine("        #endregion");
            #endregion
            #region 构造函数
            sb.AppendLine("        #region 构造函数");
            sb.AppendLine("        public " + strFrmClassName + "()");
            sb.AppendLine("        {");
            sb.AppendLine("            InitializeComponent();");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            #endregion
            #region 基本事件
            sb.AppendLine("        #region 基本事件");
            sb.AppendLine("        public void btnLoad_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                btnLoad.Enabled = false;");
            sb.AppendLine("                 LoadData();");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {"); 
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("            finally");
            sb.AppendLine("            { ");
            sb.AppendLine("                btnLoad.Enabled = true;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            #endregion
            #region 基本方法
            sb.AppendLine("        #region 基本方法");

            sb.AppendLine("        /// <summary>加载数据");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void LoadData()");
            sb.AppendLine("        {");
            sb.AppendLine("            Clear();");
            sb.AppendLine("            CreateMasterDetailView();");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>清空");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Clear()");
            sb.AppendLine("        {");
            sb.AppendLine("            panelView.Controls.Clear();");
            sb.AppendLine("            _masterDetail = null;");
            sb.AppendLine("            Refresh();");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>创建主从关系");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void CreateMasterDetailView()");
            sb.AppendLine("        {");
            sb.AppendLine("            var oDataSet = GetData();");
            sb.AppendLine("            _masterDetail = new MasterControl(oDataSet, ControlType.Middle);");
            sb.AppendLine("            panelView.Controls.Add(_masterDetail);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary> 获取数据源");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>DataSet</returns>");
            sb.AppendLine("        public DataSet GetData()");
            sb.AppendLine("        {");
            sb.AppendLine("            IDbHelper dbHelper = GlobalHelpDemoForm.GetDataAccessHelperDemo();");
            sb.AppendLine("            string strWhere = GetSearchSql();");
            sb.AppendLine("            string strSql =" + nestQuerySetting.Sql + " ");
            sb.AppendLine(";");
            sb.AppendLine("            dbHelper.CreateCommand(strSql);");
            sb.AppendLine("            DataSet dataSet = dbHelper.ExecuteQueryDataSet();");
            if (nestQuerySetting.Key3 != string.Empty)
            {
                sb.AppendLine("         string[] strKeyArray = {\"" + nestQuerySetting.Key1 + "\",\"" + nestQuerySetting.Key2 + "\", \"" + nestQuerySetting.Key3 + "\"};");
            }
            else
            {
                sb.AppendLine("         string[] strKeyArray = {\"" + nestQuerySetting.Key1 + "\",\"" + nestQuerySetting.Key2 + "\" };");
            }
            sb.AppendLine("            for (int i = 0; i < dataSet.Tables.Count; i++)");
            sb.AppendLine("            {");
            sb.AppendLine(" dataSet.Tables[i].TableName = \"T\" + (i + 1);");
            sb.AppendLine("                HashSet<string> hsSet = new HashSet<string>();");
            sb.AppendLine("                foreach (DataRow drRow in dataSet.Tables[i].Rows)");
            sb.AppendLine("                {");
            sb.AppendLine("                    string strKey = strKeyArray[i];");
            sb.AppendLine("                    string strValue = drRow[strKey].ToString();");
            sb.AppendLine("                    if (!hsSet.Contains(strValue))");
            sb.AppendLine("                    {");
            sb.AppendLine("                        hsSet.Add(strValue);");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("                if (i < dataSet.Tables.Count - 1)");
            sb.AppendLine("                {");
            sb.AppendLine("                    for (int j = 0; j < dataSet.Tables[i + 1].Rows.Count; j++)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        string strKey2 = strKeyArray[i + 1];");
            sb.AppendLine("                        string strValue2 = dataSet.Tables[i + 1].Rows[j][strKey2].ToString();");
            sb.AppendLine("                        if (!hsSet.Contains(strValue2))");
            sb.AppendLine("                        {");
            sb.AppendLine("                            dataSet.Tables[i + 1].Rows.RemoveAt(j);");
            sb.AppendLine("                            j--;");
            sb.AppendLine("                        }");
            sb.AppendLine("                    }");
            sb.AppendLine("            }");
            sb.AppendLine("     }");
            sb.AppendLine("            //这是对应关系的时候主键必须唯一");
            if (nestQuerySetting.Key3 != string.Empty)
            {
                sb.AppendLine("            dataSet.Relations.Add(\"1\", dataSet.Tables[\"T1\"].Columns[\"" + nestQuerySetting.Key1 + "\"], dataSet.Tables[\"T2\"].Columns[\"" + nestQuerySetting.Key2 + "\"]);");
                sb.AppendLine("             dataSet.Relations.Add(\"2\", dataSet.Tables[\"T2\"].Columns[\"" + nestQuerySetting.Key2 + "\"], dataSet.Tables[\"T3\"].Columns[\"" + nestQuerySetting.Key3 + "\"]);");
            }
            else
            {
                sb.AppendLine("            dataSet.Relations.Add(\"1\", dataSet.Tables[\"T1\"].Columns[\"" + nestQuerySetting.Key1 + "\"], dataSet.Tables[\"T2\"].Columns[\"" + nestQuerySetting.Key2 + "\"]);");
            }
            sb.AppendLine("            return dataSet;");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>根据查询条件构造查询语句");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>查询条件</returns>");
            sb.AppendLine("        private string GetSearchSql()");
            sb.AppendLine("        {");
            sb.AppendLine(SearchConditionHelper.GetSearchCondition(nestQuerySetting.DataTableQuery));
            //sb.AppendLine("            SearchCondition condition = new SearchCondition();");
            //sb.AppendLine("            condition.AddCondition("UserName", this.txtDepartmentName.Text, SqlOperator.Like);");
            //sb.AppendLine("            return condition.BuildConditionSql().Replace("Where", "");");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            #endregion
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        public  override string GenWinFormDesign(BasicParameter parameter,
        BaseParameter baseParameter)
        {
            NestQueryParameter nestQuerySetting = baseParameter as NestQueryParameter;
            string strFrmClassName = nestQuerySetting.FormClassName;
            int lblWidth = BseUIManager.GetCtlWidth("Label");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Drawing;");
            sb.AppendLine("using System.Diagnostics;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Xml.Linq;");
            sb.AppendLine("using Microsoft.VisualBasic;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Windows.Forms;");
            sb.AppendLine(" ");
            sb.AppendLine("namespace  " + parameter.NameSpace + "");
            sb.AppendLine("{");
            sb.AppendLine("    partial class  " + strFrmClassName + " : System.Windows.Forms.Form");
            sb.AppendLine("    { ");
            sb.AppendLine("        [System.Diagnostics.DebuggerNonUserCode()]");
            sb.AppendLine("        protected override void Dispose(bool disposing)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                if (disposing && components != null)");
            sb.AppendLine("                {");
            sb.AppendLine("                    components.Dispose();");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            finally");
            sb.AppendLine("            {");
            sb.AppendLine("                base.Dispose(disposing);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine("        private System.ComponentModel.Container components = null;");

            sb.AppendLine("        [System.Diagnostics.DebuggerStepThrough()]");
            sb.AppendLine("        private void InitializeComponent()");
            sb.AppendLine("        {");
            sb.AppendLine("            this.splitContainer1 = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.splitContainer2 = new System.Windows.Forms.SplitContainer();");
            //sb.AppendLine("            this.txtDepartmentName = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblQueryDepartmentName = new System.Windows.Forms.Label();");
            #region 查询面板控件

            foreach (DataRow drRow in nestQuerySetting.DataTableQuery.Rows)
            {
                if (drRow["IsAddLable"].ToString() == "True")
                {
                    sb.AppendLine("this." + drRow["LabelName"] + " = new System.Windows.Forms.Label();");
                    sb.AppendLine("            this." + drRow["ControlName"] + " = new " + drRow["ControlNameSpace"] + "();");
                }
                else
                {
                    sb.AppendLine("            this." + drRow["ControlName"] + " = new " + drRow["ControlNameSpace"] + "();");
                }
            }

            #endregion
            sb.AppendLine("            this.btnLoad = new System.Windows.Forms.Button();");
            sb.AppendLine("            this.panelView = new System.Windows.Forms.Panel();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();");
            sb.AppendLine("            this.splitContainer1.Panel1.SuspendLayout();");
            sb.AppendLine("            this.splitContainer1.Panel2.SuspendLayout();");
            sb.AppendLine("            this.splitContainer1.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();");
            sb.AppendLine("            this.splitContainer2.Panel1.SuspendLayout();");
            sb.AppendLine("            this.splitContainer2.Panel2.SuspendLayout();");
            sb.AppendLine("            this.splitContainer2.SuspendLayout();");
            sb.AppendLine("            this.SuspendLayout();");
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.splitContainer1.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.splitContainer1.Name = \"splitContainer1\";");
            sb.AppendLine("            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer1.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer1.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer1.Panel2.Controls.Add(this.panelView);");
            sb.AppendLine("            this.splitContainer1.Size = new System.Drawing.Size(784, 561);");
            sb.AppendLine("            this.splitContainer1.SplitterDistance = 51;");
            sb.AppendLine("            this.splitContainer1.TabIndex = 24;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;");
            sb.AppendLine("            this.splitContainer2.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.splitContainer2.Name = \"splitContainer2\";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer2.Panel1");
            sb.AppendLine("            // ");
            //sb.AppendLine("            this.splitContainer2.Panel1.Controls.Add(this.txtDepartmentName);");
            //sb.AppendLine("            this.splitContainer2.Panel1.Controls.Add(this.lblQueryDepartmentName);");
            #region 查询区控件

            foreach (DataRow drRow in nestQuerySetting.DataTableQuery.Rows)
            {
                if (drRow["IsAddLable"].ToString() == "True")
                {
                    sb.AppendLine("            this.splitContainer2.Panel1.Controls.Add(this." + drRow["LabelName"] + ");");
                }
                sb.AppendLine("            this.splitContainer2.Panel1.Controls.Add(this." + drRow["ControlName"] + ");");
            }

            #endregion
            sb.AppendLine("            // ");
            sb.AppendLine("            // splitContainer2.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.splitContainer2.Panel2.Controls.Add(this.btnLoad);");
            sb.AppendLine("            this.splitContainer2.Size = new System.Drawing.Size(784, 51);");
            sb.AppendLine("            this.splitContainer2.SplitterDistance = 706;");
            sb.AppendLine("            this.splitContainer2.TabIndex = 0;");
            #region 查询区控件明细位置

            BeginWidth = 15;
            foreach (DataRow drRow in nestQuerySetting.DataTableQuery.Rows)
            {
                int intCurrCtlWidth = BseUIManager.GetCtlWidth(drRow["ControlType"].ToString());
                if (drRow["IsAddLable"].ToString() == "True")
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
                    sb.Append(GenControlHelper.CreateLabelControl(drRow["LabelName"].ToString(), drRow["LabelText"].ToString(), LocationX, LocationY));
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
                sb.Append(GenControlHelper.CreateControl(drRow["Ctl_Simple"].ToString(), drRow["ControlName"].ToString(),
                    LocationX, LocationY, drRow["ControlSort"].ToString()));

            }
            int hight = QueryHeight * (HighSeed + 5) + 30;
            if (hight < 87)
            {
                hight = 87;
            }
            sb.Replace("@QueryHeight@", hight.ToString());

            #endregion
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtDepartmentName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtDepartmentName.Location = new System.Drawing.Point(74, 16);");
            //sb.AppendLine("            this.txtDepartmentName.Name = "txtDepartmentName";");
            //sb.AppendLine("            this.txtDepartmentName.Size = new System.Drawing.Size(143, 23);");
            //sb.AppendLine("            this.txtDepartmentName.TabIndex = 1;");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblQueryDepartmentName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblQueryDepartmentName.AutoSize = true;");
            //sb.AppendLine("            this.lblQueryDepartmentName.Location = new System.Drawing.Point(12, 19);");
            //sb.AppendLine("            this.lblQueryDepartmentName.Name = "lblQueryDepartmentName";");
            //sb.AppendLine("            this.lblQueryDepartmentName.Size = new System.Drawing.Size(56, 17);");
            //sb.AppendLine("            this.lblQueryDepartmentName.TabIndex = 0;");
            //sb.AppendLine("            this.lblQueryDepartmentName.Text = "部门名称";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // btnLoad");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));");
            sb.AppendLine("            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;");
            sb.AppendLine("            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
            sb.AppendLine("            this.btnLoad.Location = new System.Drawing.Point(8, 7);");
            sb.AppendLine("            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.btnLoad.Name = \"btnLoad\";");
            sb.AppendLine("            this.btnLoad.Size = new System.Drawing.Size(55, 33);");
            sb.AppendLine("            this.btnLoad.TabIndex = 23;");
            sb.AppendLine("            this.btnLoad.Text = \"查询\";");
            sb.AppendLine("            this.btnLoad.UseVisualStyleBackColor = true;");
            sb.AppendLine("            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // panelView");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.panelView.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.panelView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.panelView.Name = \"panelView\";");
            sb.AppendLine("            this.panelView.RightToLeft = System.Windows.Forms.RightToLeft.No;");
            sb.AppendLine("            this.panelView.Size = new System.Drawing.Size(784, 506);");
            sb.AppendLine("            this.panelView.TabIndex = 24;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // FrmNestQuery");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);");
            sb.AppendLine("            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
            sb.AppendLine("            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));");
            sb.AppendLine("            this.ClientSize = new System.Drawing.Size(784, 561);");
            sb.AppendLine("            this.Controls.Add(this.splitContainer1);");
            sb.AppendLine("            this.Font = new System.Drawing.Font(\"微软雅黑\", 9F);");
            sb.AppendLine("            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;");
            sb.AppendLine("            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.Name = \"" + strFrmClassName + "\";");
            sb.AppendLine("            this.ShowIcon = false;");
            sb.AppendLine("            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;");
            sb.AppendLine("            this.Text = \"Master-Detail\";");
            sb.AppendLine("            this.splitContainer1.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.splitContainer1.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();");
            sb.AppendLine("            this.splitContainer1.ResumeLayout(false);");
            sb.AppendLine("            this.splitContainer2.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.splitContainer2.Panel1.PerformLayout();");
            sb.AppendLine("            this.splitContainer2.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();");
            sb.AppendLine("            this.splitContainer2.ResumeLayout(false);");
            sb.AppendLine("            this.ResumeLayout(false);");
            sb.AppendLine("        }");
            sb.AppendLine("        private SplitContainer splitContainer1;");
            sb.AppendLine("        internal Panel panelView;");
            sb.AppendLine("        private SplitContainer splitContainer2;");
            sb.AppendLine("        internal Button btnLoad;");
            #region 查询区控件
            foreach (DataRow drRow in nestQuerySetting.DataTableQuery.Rows)
            {
                if (drRow["IsAddLable"].ToString() == "True")
                {
                    sb.Append("        public  System.Windows.Forms.Label " + drRow["LabelName"] + ";\r\n");
                }
                sb.Append("        public " + drRow["ControlNameSpace"] + "  " + drRow["ControlName"] + ";\r\n");
            }
            #endregion
            //sb.AppendLine("        private TextBox txtDepartmentName;");
            //sb.AppendLine("        private Label lblQueryDepartmentName;");
            sb.AppendLine("    } ");
            sb.AppendLine("}");

            return sb.ToString();

        }

    }
}