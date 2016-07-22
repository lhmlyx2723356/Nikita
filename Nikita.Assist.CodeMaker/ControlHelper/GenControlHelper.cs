using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker
{
    public class GenControlHelper
    {
        public static int intAllWidth = 800;
        public static int intBeginWidth = 23;
        public static int intLocationX = 23;
        public static int intLocationY = 33;
        public static int intHighSeed = 25;

        /// <summary>控件生成汇总
        /// 
        /// </summary>
        /// <param name="strCtlType"></param>
        /// <param name="strCtlName"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param>
        /// <param name="strSort"></param>
        /// <returns></returns>
        public static string CreateControl(string strCtlType, string strCtlName, int intLocationX, int intLocationY, string strSort)
        {
            StringBuilder sb = new StringBuilder();
            switch (strCtlType)
            {
                case "txt":  //TextEdit
                    sb.AppendLine(CreateTextEdit(strCtlName, intLocationX, intLocationY, strSort));
                    break;
                case "cbe"://ComboBoxEdit
                    sb.AppendLine(CreateComboBoxEdit(strCtlName, intLocationX, intLocationY, strSort));
                    break;

                case "lue"://LookUpEdit
                    sb.AppendLine(CreateLookUpEdit(strCtlName, intLocationX, intLocationY, strSort));
                    break;
                case "chk"://CheckEdit 或者 CheckBox
                    sb.AppendLine(CreateCheckEdit(strCtlName, intLocationX, intLocationY, strSort));
                    break;
                case "cbk"://Nikita.WinForm.ExtendControl.CheckedComboBox
                    sb.AppendLine(CreateCheckedComboBox(strCtlName, intLocationX, intLocationY, strSort));
                    break;
                case "num"://NumericUpDown
                    sb.AppendLine(CreateNumericUpDown(strCtlName, intLocationX, intLocationY, strSort));
                    break;

                case "cbo"://传统WinFormCombobox
                    sb.AppendLine(CreateComboBox(strCtlName, intLocationX, intLocationY, strSort));
                    break;
            }
            return sb.ToString();
        }

        /// <summary>传统WinForm   Combobox
        /// 
        /// </summary>
        /// <param name="strCtlName"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param>
        /// <param name="strSort"></param>
        /// <returns></returns>
        private static string CreateComboBox(string strCtlName, int intLocationX, int intLocationY, string strSort)
        {

            int intComboBoxEditWidth = 130;
            int intComboBoxEditHeight = 20;
            StringBuilder sb = new StringBuilder();
            //// 
            //// cboEditCategory
            //// 
            //this.cboEditCategory.Location = new System.Drawing.Point(70, 9);
            //this.cboEditCategory.Name = "cboEditCategory";
            //this.cboEditCategory.Size = new System.Drawing.Size(121, 25);
            //this.cboEditCategory.TabIndex = 2;
            //// 
            sb.AppendLine("           // ");
            sb.AppendLine("            // " + strCtlName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strCtlName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
            sb.AppendLine("            this." + strCtlName + ".Name = \"" + strCtlName + "\";");
            sb.AppendLine("            this." + strCtlName + ".Size = new System.Drawing.Size(" + intComboBoxEditWidth + ", " + 20 + ");");
            sb.AppendLine("            this." + strCtlName + ".TabIndex = 2;");
            sb.AppendLine("            // ");
            if (strCtlName.Substring(3, 4) == "Edit")//如果是编辑区控件则要添加Tag
            {
                sb.AppendLine("            this." + strCtlName + ".Tag = \"" + strCtlName.Substring(7, strCtlName.Length - 7) + "\";");
            }

            else if (strCtlName.Contains("Edit") && strCtlName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
            {
                sb.AppendLine("            this." + strCtlName + ".Tag = \"" + strCtlName.Substring(13, strCtlName.Length - 13) + "\";");
            }
            return sb.ToString();
        }

        #region 生成常用控件
        /// <summary>生成LabelControl
        /// 
        /// </summary>
        /// <param name="strLabelControlName"></param>
        /// <param name="strLabelControlTxt"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param>
        /// <param name="strIsNeed"></param>
        /// <returns></returns>
        public static string CreateLabelControl(string strLabelControlName, string strLabelControlTxt, int intLocationX, int intLocationY, string strIsNeed)
        {
            int intLabelControlWidth = 60;
            int intLabelControlHeight = 16;
            StringBuilder sb = new StringBuilder();
            if (strIsNeed == "True")
            {
                sb.AppendLine("  this." + strLabelControlName + ".Appearance.ForeColor = System.Drawing.Color.Red;");
            }
            sb.AppendLine("     this." + strLabelControlName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
            sb.AppendLine("            this." + strLabelControlName + ".Name = \"" + strLabelControlName + "\";");
            sb.AppendLine("            this." + strLabelControlName + ".Size = new System.Drawing.Size(" + intLabelControlWidth + ", " + intLabelControlHeight + ");");
            sb.AppendLine("            this." + strLabelControlName + ".TabIndex = 1;");
            sb.AppendLine("            this." + strLabelControlName + ".Text =\"" + strLabelControlTxt + "\";");
            return sb.ToString();
        }

        /// <summary>生成LabelControl
        /// 
        /// </summary>
        /// <param name="strLabelControlName"></param>
        /// <param name="strLabelControlTxt"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param> 
        /// <returns></returns>
        public static string CreateLabelControl(string strLabelControlName, string strLabelControlTxt, int intLocationX, int intLocationY)
        {
            int intLabelControlWidth = 60;
            int intLabelControlHeight = 16;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     this." + strLabelControlName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
            sb.AppendLine("            this." + strLabelControlName + ".Name = \"" + strLabelControlName + "\";");
            sb.AppendLine("            this." + strLabelControlName + ".Size = new System.Drawing.Size(" + intLabelControlWidth + ", " + intLabelControlHeight + ");");
            sb.AppendLine("            this." + strLabelControlName + ".TabIndex = 1;");
            sb.AppendLine("            this." + strLabelControlName + ".Text =\"" + strLabelControlTxt + "\";");
            return sb.ToString();
        }

        /// <summary>生成TextEdit
        /// 
        /// </summary>
        /// <param name="strTextEditName"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param>
        /// <param name="Enable"></param>
        /// <returns></returns>
        private static string CreateTextEdit(string strTextEditName, int intLocationX, int intLocationY, string strSort)
        {
            int intTextEditWidth = 130;
            int intTextEditHeight = 20;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strTextEditName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strTextEditName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
            sb.AppendLine("            this." + strTextEditName + ".Name =  \"" + strTextEditName + "\";");
            sb.AppendLine("            this." + strTextEditName + ".Size = new System.Drawing.Size(" + intTextEditWidth + ", " + intTextEditHeight + ");");
            sb.AppendLine("            this." + strTextEditName + ".TabIndex = " + strSort + ";");
            if (strTextEditName.Substring(3, 4) == "Edit")//如果是编辑区控件则要添加Tag
            {
                sb.AppendLine("            this." + strTextEditName + ".Tag = \"" + strTextEditName.Substring(7, strTextEditName.Length - 7) + "\";");
            }
            else if (strTextEditName.Contains("Edit") && strTextEditName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
            {
                sb.AppendLine("            this." + strTextEditName + ".Tag = \"" + strTextEditName.Substring(13, strTextEditName.Length - 13) + "\";");
            }
            return sb.ToString();
        }

        /// <summary>生成CreateCheckEdit
        /// 
        /// </summary>
        /// <param name="strCheckEditName"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param>
        /// <param name="strSort"></param>
        /// <param name="uiStyle"></param>
        /// <returns></returns>
        private static string CreateCheckEdit(string strCheckEditName, int intLocationX, int intLocationY, string strSort, UiStyle uiStyle = UiStyle.传统WinForm)
        {
            int intCheckEditWidth = 130;
            int intCheckEditHeight = 20;
            StringBuilder sb = new StringBuilder();

            if (uiStyle == UiStyle.传统WinForm)
            {
                sb.AppendLine("            // ");
                sb.AppendLine("            // " + strCheckEditName + "");
                sb.AppendLine("            // ");
                sb.AppendLine("            this." + strCheckEditName + ".AutoSize = true;");
                sb.AppendLine("            this." + strCheckEditName + ".Location = new System.Drawing.Point(" +
                              intLocationX + ", " + intLocationY + ");");
                sb.AppendLine("            this." + strCheckEditName + ".Name =  \"" + strCheckEditName + "\";");
                sb.AppendLine("            this." + strCheckEditName + ".Size = new System.Drawing.Size(" +
                              intCheckEditWidth + ", " + intCheckEditHeight + ");");
                sb.AppendLine("            this." + strCheckEditName + ".TabIndex = 4;");
                if (strCheckEditName.Substring(3, 4) == "Edit") //如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strCheckEditName + ".Tag = \"" +
                                  strCheckEditName.Substring(7, strCheckEditName.Length - 7) + "\";");
                }

                else if (strCheckEditName.Contains("Edit") && strCheckEditName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strCheckEditName + ".Tag = \"" + strCheckEditName.Substring(13, strCheckEditName.Length - 13) + "\";");
                }
                //sb.AppendLine("            this." + strCheckEditName + ".Text = "是否默认";");
                sb.AppendLine("            this." + strCheckEditName + ".UseVisualStyleBackColor = true;");
            }
            else if (uiStyle == UiStyle.DevExpress)
            {
                sb.AppendLine("            // ");
                sb.AppendLine("            // " + strCheckEditName + "");
                sb.AppendLine("            // ");
                sb.AppendLine("            this." + strCheckEditName + ".Location = new System.Drawing.Point(" +
                              intLocationX + ", " + intLocationY + ");");
                sb.AppendLine("            this." + strCheckEditName + ".Name = \"" + strCheckEditName + "\";");
                sb.AppendLine("            this." + strCheckEditName + ".Properties.Caption = \"\";");
                sb.AppendLine("            this." + strCheckEditName + ".Size = new System.Drawing.Size(" +
                              intCheckEditWidth + ", " + intCheckEditHeight + ");");
                sb.AppendLine("            this." + strCheckEditName + ".TabIndex = " + strSort + ";");
                if (strCheckEditName.Substring(3, 4) == "Edit") //如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strCheckEditName + ".Tag = \"" +
                                  strCheckEditName.Substring(7, strCheckEditName.Length - 7) + "\";");
                }
                else if (strCheckEditName.Contains("Edit") && strCheckEditName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strCheckEditName + ".Tag = \"" + strCheckEditName.Substring(13, strCheckEditName.Length - 13) + "\";");
                }
            }
            return sb.ToString();
        }

        private static string CreateCheckedComboBox(string strCheckEditName, int intLocationX, int intLocationY, string strSort, UiStyle uiStyle = UiStyle.传统WinForm)
        {
            int intCheckedComboBoxWidth = 130;
            int intCheckedComboBoxHeight = 20;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("             // ");
            sb.AppendLine("            //  " + strCheckEditName + "");
            sb.AppendLine("            // ");
            if (uiStyle == UiStyle.传统WinForm)
            {
                sb.AppendLine("            this." + strCheckEditName + ".CheckOnClick = true;");
                sb.AppendLine("            this." + strCheckEditName + ".DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;");
                sb.AppendLine("            this." + strCheckEditName + ".DropDownHeight = 1;");
                sb.AppendLine("            this." + strCheckEditName + ".IntegralHeight = false;");
                sb.AppendLine("            this." + strCheckEditName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
                sb.AppendLine("            this." + strCheckEditName + ".Name = \" " + strCheckEditName + "\";");
                sb.AppendLine("            this." + strCheckEditName + ".Size = new System.Drawing.Size(" + intCheckedComboBoxWidth + ", " + intCheckedComboBoxHeight + ");");
                sb.AppendLine("            this." + strCheckEditName + ".TabIndex =  " + strSort + ";");
                sb.AppendLine("            this." + strCheckEditName + ".ValueSeparator = \",\";");
                if (strCheckEditName.Substring(3, 4) == "Edit")//如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strCheckEditName + ".Tag = \"" + strCheckEditName.Substring(7, strCheckEditName.Length - 7) + "\";");
                }

                else if (strCheckEditName.Contains("Edit") && strCheckEditName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strCheckEditName + ".Tag = \"" + strCheckEditName.Substring(13, strCheckEditName.Length - 13) + "\";");
                }
            }
            else if (uiStyle == UiStyle.DevExpress)
            {

            }
            return sb.ToString();
        }

        /// <summary>生成ComboBoxEdit
        /// 
        /// </summary>
        /// <param name="strComboBoxEditName"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param>
        /// <param name="strSort"></param>
        /// <returns></returns>
        private static string CreateComboBoxEdit(string strComboBoxEditName, int intLocationX, int intLocationY, string strSort)
        {
            int intComboBoxEditWidth = 130;
            int intComboBoxEditHeight = 20;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strComboBoxEditName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strComboBoxEditName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
            sb.AppendLine("            this." + strComboBoxEditName + ".Name = \"" + strComboBoxEditName + "\";");
            sb.AppendLine("            this." + strComboBoxEditName + ".Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {");
            sb.AppendLine("            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});");
            sb.AppendLine("            this." + strComboBoxEditName + ".Size = new System.Drawing.Size(" + intComboBoxEditWidth + ", " + intComboBoxEditHeight + ");");
            sb.AppendLine("            this." + strComboBoxEditName + ".TabIndex = " + strSort + ";");
            if (strComboBoxEditName.Substring(3, 4) == "Edit")//如果是编辑区控件则要添加Tag
            {
                sb.AppendLine("            this." + strComboBoxEditName + ".Tag = \"" + strComboBoxEditName.Substring(7, strComboBoxEditName.Length - 7) + "\";");
            }

            else if (strComboBoxEditName.Contains("Edit") && strComboBoxEditName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
            {
                sb.AppendLine("            this." + strComboBoxEditName + ".Tag = \"" + strComboBoxEditName.Substring(13, strComboBoxEditName.Length - 13) + "\";");
            }
            return sb.ToString();
        }

        /// <summary>生成LookUpEdit
        /// 
        /// </summary>
        /// <param name="strLookUpEditName"></param>
        /// <param name="intLocationX"></param>
        /// <param name="intLocationY"></param>
        /// <returns></returns>
        private static string CreateLookUpEdit(string strLookUpEditName, int intLocationX, int intLocationY, string strSort)
        {
            int intLookUpEditWidth = 130;
            int intLookUpEditHeight = 20;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strLookUpEditName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strLookUpEditName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
            sb.AppendLine("            this." + strLookUpEditName + ".Name = \"" + strLookUpEditName + "\";");
            sb.AppendLine("            this." + strLookUpEditName + ".Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {");
            sb.AppendLine("            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});");
            sb.AppendLine("            this." + strLookUpEditName + ".Properties.NullText = \"\";");
            sb.AppendLine("            this." + strLookUpEditName + ".Size = new System.Drawing.Size(" + intLookUpEditWidth + ", " + intLookUpEditHeight + ");");
            sb.AppendLine("            this." + strLookUpEditName + ".TabIndex = " + strSort + ";");
            if (strLookUpEditName.Substring(3, 4) == "Edit")
            {
                sb.AppendLine("            this." + strLookUpEditName + ".Tag = \"" + strLookUpEditName.Substring(7, strLookUpEditName.Length - 7) + "\";");
            }

            else if (strLookUpEditName.Contains("Edit") && strLookUpEditName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
            {
                sb.AppendLine("            this." + strLookUpEditName + ".Tag = \"" + strLookUpEditName.Substring(13, strLookUpEditName.Length - 13) + "\";");
            }
            return sb.ToString();
        }

        private static string CreateNumericUpDown(string strNumericUpDownName, int intLocationX, int intLocationY, string strSort, UiStyle uiStyle = UiStyle.传统WinForm)
        {
            int intNumericUpDownNameWidth = 130;
            int intNumericUpDownNameHeight = 20;
            StringBuilder sb = new StringBuilder();

            if (uiStyle == UiStyle.传统WinForm)
            {
                sb.AppendLine("            // ");
                sb.AppendLine("            // " + strNumericUpDownName + "");
                sb.AppendLine("            // ");
                sb.AppendLine("            this." + strNumericUpDownName + ".Location = new System.Drawing.Point(" + intLocationX + ", " + intLocationY + ");");
                sb.AppendLine("            this." + strNumericUpDownName + ".Name = \"" + strNumericUpDownName + "\";");
                sb.AppendLine("            this." + strNumericUpDownName + ".Size = new System.Drawing.Size(" + intNumericUpDownNameWidth + ", " + intNumericUpDownNameHeight + ");");
                sb.AppendLine("            this." + strNumericUpDownName + ".TabIndex = " + strSort + ";");
                if (strNumericUpDownName.Substring(3, 4) == "Edit") //如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strNumericUpDownName + ".Tag = \"" +
                                  strNumericUpDownName.Substring(7, strNumericUpDownName.Length - 7) + "\";");
                }

                else if (strNumericUpDownName.Contains("Edit") && strNumericUpDownName.Substring(3, 10) == "DetailEdit")//如果是编辑区控件则要添加Tag
                {
                    sb.AppendLine("            this." + strNumericUpDownName + ".Tag = \""
                        + strNumericUpDownName.Substring(13, strNumericUpDownName.Length - 13) + "\";");
                }
            }
            else if (uiStyle == UiStyle.DevExpress)
            {
            }
            return sb.ToString();
        }

        #endregion

        #region 生成GridView
        /// <summary>生成GridView的GridColumn
        /// 
        /// </summary>
        /// <param name="strGridColumnName"></param>
        /// <param name="strCaption"></param>
        /// <param name="strFieldName"></param>
        /// <param name="strVisibleIndex"></param>
        /// <param name="strSpecial"></param>
        /// <param name="strControlType"></param>
        /// <returns></returns>
        public static string CreateGridColumn_Bak(string strGridColumnName, string strCaption, string strFieldName, string strVisibleIndex, string strSpecial, string strControlType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            // grid" + strGridColumnName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.grid" + strGridColumnName + ".Caption = \"" + strCaption + "\";");
            sb.AppendLine("            this.grid" + strGridColumnName + ".FieldName = \"" + strFieldName + "\";");
            sb.AppendLine("            this.grid" + strGridColumnName + ".Name = \"grid" + strGridColumnName + "\";");
            if (strSpecial.Trim() != string.Empty)
            {
                sb.AppendLine("   this.grid" + strGridColumnName + ".ColumnEdit = this.ctlShow" + strGridColumnName + ";");
            }
            sb.AppendLine("            this.grid" + strGridColumnName + ".Visible = true;");
            sb.AppendLine("            this.grid" + strGridColumnName + ".VisibleIndex = " + strVisibleIndex + ";");
            if (strSpecial != "")
            {
                sb.AppendLine(CreateGridControl(strGridColumnName, strControlType));
            }
            return sb.ToString();
        }

        /// <summary>生成GridView的GridColumn
        /// 
        /// </summary>
        /// <param name="strControlName"></param>
        /// <param name="strCaption"></param>
        /// <param name="strFieldName"></param>
        /// <param name="strVisibleIndex"></param>
        /// <param name="strNameSpace"></param>
        /// <param name="strControlType"></param>
        /// <param name="strGridSpeicalCtlName"></param>
        /// <returns></returns>
        public static string CreateGridColumnDev(string strControlName, string strCaption, string strFieldName, string strVisibleIndex, string strNameSpace, string strControlType, string strGridSpeicalCtlName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            //  " + strControlName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strControlName + ".Caption = \"" + strCaption + "\";");
            sb.AppendLine("            this." + strControlName + ".FieldName = \"" + strFieldName + "\";");
            sb.AppendLine("            this." + strControlName + ".Name = \"" + strControlName + "\";");
            if (strNameSpace.Trim() != string.Empty)
            {
                sb.AppendLine("   this." + strControlName + ".ColumnEdit = this." + strGridSpeicalCtlName + ";");
            }
            sb.AppendLine("            this." + strControlName + ".Visible = true;");
            sb.AppendLine("            this." + strControlName + ".VisibleIndex = " + strVisibleIndex + ";");
            if (strNameSpace != string.Empty)
            {
                sb.AppendLine(CreateGridControl(strGridSpeicalCtlName, strControlType));
            }
            return sb.ToString();
        }
        /// <summary>生成GridView的GridColumn
        /// 
        /// </summary>
        /// <param name="strControlName"></param>
        /// <param name="strCaption"></param>
        /// <param name="strFieldName"></param>
        /// <param name="strVisibleIndex"></param>
        /// <param name="strNameSpace"></param>
        /// <param name="strControlType"></param>
        /// <param name="strGridSpeicalCtlName"></param>
        /// <returns></returns>
        public static string CreateGridColumn(string strControlName, string strCaption, string strFieldName, string strVisibleIndex, string strNameSpace, string strControlType, string strGridSpeicalCtlName)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            //  " + strControlName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strControlName + ".DataPropertyName = \"" + strFieldName + "\";");
            sb.AppendLine("            this." + strControlName + ".HeaderText = \"" + strCaption + "\";");
            sb.AppendLine("            this." + strControlName + ".Name = \"" + strControlName + "\";");
            //Dx控件
            if (strNameSpace.Trim() != string.Empty)
            {
                if (strNameSpace.Contains("Devexpress"))
                {
                    sb.AppendLine("   this." + strControlName + ".ColumnEdit = this." + strGridSpeicalCtlName + ";");
                }
                else
                {
                    sb.AppendLine("      this." + strControlName + ".Resizable = System.Windows.Forms.DataGridViewTriState.True;");
                    sb.AppendLine("            this." + strControlName + ".SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;");
                }
            }


            sb.AppendLine("            this." + strControlName + ".Visible = true;");
            //sb.AppendLine("            this." + ControlName + ".DisplayIndex = " + VisibleIndex + ";");
            if (strNameSpace != string.Empty)
            {
                if (strNameSpace.Contains("Devexpress"))
                {
                    sb.AppendLine(CreateGridControl(strGridSpeicalCtlName, strControlType));
                }
            }
            return sb.ToString();
        }


        public static string CreateGridControl(string strCtlName, string strCtlType)
        {
            StringBuilder sb = new StringBuilder();
            switch (strCtlType)
            {
                case "rcb"://RepositoryItemComboBox
                    sb.AppendLine(CreateGridRepositoryItemComboBox(strCtlName));
                    break;
                case "rck"://RepositoryItemCheckEdit
                    sb.AppendLine(CreateGridRepositoryItemCheckEdit(strCtlName));
                    break;
            }
            return sb.ToString();
        }

        /// <summary>生成GridView的RepositoryItemCheckEdit
        /// 
        /// </summary>
        /// <param name="strCheckEditName"></param>
        /// <returns></returns>
        public static string CreateGridRepositoryItemCheckEdit(string strCheckEditName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strCheckEditName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strCheckEditName + ".AutoHeight = false;");
            sb.AppendLine("            this." + strCheckEditName + ".Name = \"" + strCheckEditName + "\";");
            return sb.ToString();
        }

        /// <summary>生成GridView的RepositoryItemComboBox
        /// 
        /// </summary>
        /// <param name="strComboBoxName"></param>
        /// <returns></returns>
        public static string CreateGridRepositoryItemComboBox(string strComboBoxName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strComboBoxName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this." + strComboBoxName + ".AutoHeight = false;");
            sb.AppendLine("            this." + strComboBoxName + ".Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {");
            sb.AppendLine("            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});");
            sb.AppendLine("            this." + strComboBoxName + ".Name = \"" + strComboBoxName + "\";");
            sb.AppendLine("            // ");
            return sb.ToString();
        }

        #endregion

        #region 生成FineUI Aspx上常用控件
        public static string CreateFineUIControl(string strControlType, string strControlName, string strLabelName, string strIsNeed, string strIsSelf)
        {

            StringBuilder sb = new StringBuilder();
            if (strIsSelf == "True")//FineUI自带
            {
                if (strControlType == "RadioButtonList")
                {
                    sb.AppendLine("                    <x:RadioButtonList ID=\"" + strControlName + "\" Label=\"" + strLabelName + "\" ColumnNumber=\"3\" runat=\"server\">");
                    sb.AppendLine("                    </x:RadioButtonList>");
                }

                if (strControlType == "TextBox")
                {
                    if (strIsNeed == "False")
                    {
                        sb.AppendLine(" <x:TextBox ID=\"" + strControlName + "\" runat=\"server\"  Label=\"" + strLabelName + "\">");
                        sb.AppendLine("            </x:TextBox> ");
                    }
                    else
                    {
                        sb.AppendLine(" <x:TextBox ID=\"" + strControlName + "\" runat=\"server\" Label=\"" + strLabelName + "\" Required=\"true\" ShowRedStar=\"true\">");
                        sb.AppendLine("            </x:TextBox> ");
                    }
                }

                if (strControlType == "NumberBox")
                {
                    if (strIsNeed == "False")
                    {
                        sb.AppendLine("         <x:NumberBox ID=\"" + strControlName + "\" Label=\"" + strLabelName + "\" runat=\"server\">");
                        sb.AppendLine("            </x:NumberBox>");
                    }
                    else
                    {
                        sb.AppendLine("         <x:NumberBox ID=\"" + strControlName + "\" Label=\"" + strLabelName + "\" Required=\"true\" ShowRedStar=\"true\" runat=\"server\">");
                        sb.AppendLine("            </x:NumberBox>");
                    }
                }

                if (strControlType == "TextArea")
                {
                    if (strIsNeed == "False")
                    {
                        sb.AppendLine("       <x:TextArea ID=\"" + strControlName + "\" Label=\"" + strLabelName + "\" runat=\"server\">");
                        sb.AppendLine("            </x:TextArea>");

                    }
                    else
                    {
                        sb.AppendLine("       <x:TextArea ID=\"" + strControlName + "\" Label=\"" + strLabelName + "\" Required=\"true\" ShowRedStar=\"true\" runat=\"server\">");
                        sb.AppendLine("            </x:TextArea>");

                    }
                }

                if (strControlType == "TwinTriggerBox")
                {
                    sb.AppendLine("                    <x:TwinTriggerBox ID=\"" + strControlName + "\" runat=\"server\" ShowLabel=\"false\" EmptyText=\"" + strLabelName + "\"");
                    sb.AppendLine("                        Trigger1Icon=\"Clear\" Trigger2Icon=\"Search\" ShowTrigger1=\"false\" OnTrigger2Click=\"" + strControlName + "_Trigger2Click\"");
                    sb.AppendLine("                        OnTrigger1Click=\"" + strControlName + "_Trigger1Click\">");
                    sb.AppendLine("                    </x:TwinTriggerBox>");
                }

                if (strControlType == "DropDownList")
                {
                    if (strIsNeed == "False")
                    {
                        sb.AppendLine("             <x:DropDownList ID=\"" + strControlName + "\" runat=\"server\" Label=\"" + strLabelName + "\"  ForceSelection=\"false\">");
                        sb.AppendLine("             </x:DropDownList>  ");
                    }
                    else
                    {
                        sb.AppendLine("             <x:DropDownList ID=\"" + strControlName + "\" runat=\"server\" Label=\"" + strLabelName + "\" Required=\"true\" ShowRedStar=\"true\" ForceSelection=\"false\">");
                        sb.AppendLine("             </x:DropDownList>  ");
                    }
                }

                if (strControlType == "DatePicker")
                {
                    if (strIsNeed == "False")
                    {
                        if (strLabelName == string.Empty)//如果没有Label文本，则隐藏Label--》ShowLabel="false"
                        {
                            sb.AppendLine("                    <x:DatePicker runat=\"server\" Label=\"" + strLabelName + "\" ID=\"" + strControlName + "\"  ShowLabel=\"false\"   EnableEdit=\"false\" DateFormatString=\"yyyy-MM-dd\">");
                            sb.AppendLine("                    </x:DatePicker>");
                        }
                        else
                        {
                            sb.AppendLine("                    <x:DatePicker runat=\"server\" Label=\"" + strLabelName + "\" ID=\"" + strControlName + "\"  EnableEdit=\"false\" DateFormatString=\"yyyy-MM-dd\">");
                            sb.AppendLine("                    </x:DatePicker>");

                        }
                    }
                    else
                    {
                        if (strLabelName == string.Empty) //如果没有Label文本，则隐藏Label--》ShowLabel="false"
                        {

                            sb.AppendLine("                    <x:DatePicker runat=\"server\" Label=\"" + strLabelName + "\" ID=\"" + strControlName + "\" Required=\"true\"  ShowLabel=\"false\"   EnableEdit=\"false\" ShowRedStar=\"true\" DateFormatString=\"yyyy-MM-dd\">");
                            sb.AppendLine("                    </x:DatePicker>");
                        }
                        else
                        {

                            sb.AppendLine("                    <x:DatePicker runat=\"server\" Label=\"" + strLabelName + "\" ID=\"" + strControlName + "\" Required=\"true\"  EnableEdit=\"false\" ShowRedStar=\"true\" DateFormatString=\"yyyy-MM-dd\">");
                            sb.AppendLine("                    </x:DatePicker>");
                        }

                    }
                }
            }
            else //非FineUI自带，自己封装例如 MultiSelect 下拉多选
            {
                if (strControlType == "MultiSelect")
                {
                    sb.AppendLine("                  <x:ContentPanel runat=\"server\" ID=\"ContentPanel" + strControlName + "\" EnableBackgroundColor=\"true\" Width=\"300px\"");
                    sb.AppendLine("                                ShowBorder=\"false\" ShowHeader=\"false\" AutoHeight=\"true\">");
                    sb.AppendLine("                                <input type=\"text\" value=\"" + strLabelName + ":\" style=\"border: none; width: 50px; color: #808080; margin-left:5px;");
                    sb.AppendLine("                                    background-color: transparent\" />");
                    sb.AppendLine("                                <%= SelectJson" + strControlName + " %> ");
                    sb.AppendLine("                            </x:ContentPanel>");
                }
            }


            return sb.ToString();
        }

        public static string CreateFineUIGridColumn(string strControlType, string strControlName, string strLabelName, string strColumnName)
        {
            StringBuilder sb = new StringBuilder();
            if (strControlType == "默认")
            {
                sb.AppendLine("            <x:BoundField DataField=\"" + strColumnName + "\" SortField=\"" + strColumnName + "\" ColumnID=\"" + strColumnName + "\" ExpandUnusedSpace=\"true\"");
                sb.AppendLine("                HeaderText=\"" + strLabelName + "\" />");
            }
            if (strControlType == "CheckBoxField")
            {
                sb.AppendLine("            <x:CheckBoxField DataField=\"" + strColumnName + "\" SortField=\"" + strColumnName + "\" HeaderText=\"" + strLabelName + "\" RenderAsStaticField=\"true\"");
                sb.AppendLine("                Width=\"50px\" />");
            }
            return sb.ToString();
        }

        public static string CreateFineUIDesignControl(string strControlType, string strControlName, string strLabelName, string strIsSelf)
        {
            StringBuilder sb = new StringBuilder();
            if (strIsSelf == "True")//FineUI自带
            {
                if (strControlType == "RadioButtonList")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::FineUI.RadioButtonList " + strControlName + ";");
                    sb.AppendLine("        ");
                }
                if (strControlType == "TwinTriggerBox")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::FineUI.TwinTriggerBox " + strControlName + ";");
                    sb.AppendLine("        ");
                }

                if (strControlType == "NumberBox")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::FineUI.NumberBox " + strControlName + ";");
                    sb.AppendLine("        ");
                }


                if (strControlType == "TextBox")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::FineUI.TextBox " + strControlName + ";");
                    sb.AppendLine("        ");
                }



                if (strControlType == "TextArea")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::FineUI.TextArea " + strControlName + ";");
                    sb.AppendLine("        ");
                }

                if (strControlType == "DropDownList")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::FineUI.DropDownList " + strControlName + ";");
                    sb.AppendLine("        ");
                }
                if (strControlType == "DatePicker")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::FineUI.DatePicker " + strControlName + ";");
                }

            }
            else //非FineUI自带，自己封装例如 MultiSelect 下拉多选
            {
                if (strControlType == "MultiSelect")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// MultiSelectValues" + strControlName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::System.Web.UI.HtmlControls.HtmlInputText MultiSelectValues" + strControlName + ";");
                }
            }

            return sb.ToString();
        }

        public static string CreateFineUICSBindDataSource(string ControlType, string ControlName, string valuename, string txtname, string IsSelf, string ColumnName)
        {
            StringBuilder sb = new StringBuilder();
            if (IsSelf == "True")//FineUI自带
            {
                if (ControlType == "RadioButtonList")
                {
                    sb.AppendLine("ControlHelper.BindDataTable2RadioButtonList(" + ControlName + ", ds.Tables[\"" + ControlName + "\"], \"" + txtname + "\", \"" + valuename + "\");");
                }

                if (ControlType == "DropDownList")
                {
                    sb.AppendLine("    ControlHelper.BindDataTable2DropDownList(" + ControlName + ", ds.Tables[\"" + ControlName + "\"], \"" + txtname + "\", \"" + valuename + "\", -1);");
                }
            }
            else//非FineUI自带，例如MultiSelect
            {
                if (ControlType == "MultiSelect")
                {
                    sb.AppendLine("            SelectJson" + ControlName + "= GetMultiSelectDataSoruce(ds.Tables[\"" + ControlName + "\"], \"Select" + ColumnName + "\",\"" + txtname + "\", \"" + valuename + "\");");
                }

            }

            return sb.ToString();
        }

        public static string CreateFineUIQueryParameters(string ControlType, string ColumnName, string ControlName, string IsSelf)
        {
            StringBuilder sb = new StringBuilder();
            if (IsSelf == "True")//FineUI自带
            {
                if (ControlType == "TwinTriggerBox" || ControlType == "TextBox")
                {
                    sb.AppendLine("            helper.AddParameter(\"@" + ColumnName + "\", " + ControlName + ".Text.Trim());");
                }
                if (ControlType == "RadioButtonList" || ControlType == "DropDownList")
                {
                    sb.AppendLine("            helper.AddParameter(\"@" + ColumnName + "\", " + ControlName + ".SelectedValue);");
                }
                if (ControlType == "DatePicker")
                {
                    sb.AppendLine("            helper.AddParameter(\"@" + ControlName.Substring(8, ControlName.Length - 8) + "\", " + ControlName + ".Text.Trim());");
                }
            }
            else//不是FineUI自带，例如自己封装的MultiSelect等
            {
                if (ControlType == "MultiSelect")
                {
                    sb.AppendLine("            helper.AddParameter(\"@SelectJson" + ColumnName + "\", MultiSelectValues" + ControlName + ".Value);");
                }
            }
            return sb.ToString();
        }

        public static string CreateFineUIAddParameters(string ControlType, string ColumnName, string ControlName, string IsReadonly, string ColumnType)
        {
            StringBuilder sb = new StringBuilder();
            if (ControlType == "TwinTriggerBox" || ControlType == "TextBox" || ControlType == "TextArea" || ControlType == "NumberBox" || ControlType == "DatePicker")
            {
                if (IsReadonly == "True" && (ColumnType == "int" || ColumnType == "bigint" || ColumnType == "tinyint" || ColumnType == "decimal"))
                {
                    sb.AppendLine("            helper.AddParameter(\"@" + ColumnName + "\", " + ControlName + ".Text.Trim()== string.Empty ? 0 : Decimal.Parse(" + ControlName + ".Text.Trim()));");
                }
                else
                {
                    sb.AppendLine("            helper.AddParameter(\"@" + ColumnName + "\", " + ControlName + ".Text.Trim());");
                }
            }
            if (ControlType == "RadioButtonList" || ControlType == "DropDownList")
            {
                if (IsReadonly == "True" && (ColumnType == "int" || ColumnType == "bigint" || ColumnType == "tinyint" || ColumnType == "decimal"))
                {
                    sb.AppendLine("            helper.AddParameter(\"@" + ColumnName + "\", " + ControlName + ".SelectedValue== null ? -1 : Decimal.Parse(" + ControlName + ".SelectedValue.ToString().Trim()));");
                }
                else
                {
                    sb.AppendLine("            helper.AddParameter(\"@" + ColumnName + "\", " + ControlName + ".SelectedValue);");
                }
            }

            return sb.ToString();
        }

        //跳转到编辑区的赋值
        public static string CreateFineUIEditSetValue(string strTabName, string strControlType, string strColumnName, string strControlName)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("            tbxSetOrd_Name.Text = dtRole.Rows[0]["SetOrd_Name"].ToString();");
            //sb.AppendLine("            tbxSort.Text = dtRole.Rows[0]["Sort"].ToString();");
            //sb.AppendLine("            tbxRemark.Text = dtRole.Rows[0]["Remark"].ToString(); ");
            if (strControlType == "TwinTriggerBox" || strControlType == "TextBox" || strControlType == "TextArea" || strControlType == "NumberBox" || strControlType == "DatePicker")
            {
                sb.AppendLine("            " + strControlName + ".Text = dt" + strTabName + ".Rows[0][\"" + strColumnName + "\"].ToString();");
            }
            if (strControlType == "RadioButtonList" || strControlType == "DropDownList")
            {
                sb.AppendLine("            " + strControlName + ".SelectedValue = dt" + strTabName + ".Rows[0][\"" + strColumnName + "\"].ToString();");
            }
            return sb.ToString();
        }


        private static string GenBindSourceSql(List<Bse_UI> lstBseUis)
        {
            string strSql = string.Empty;
            string strContrlNameSql = string.Empty;
            if (lstBseUis.Any(t => t.DataSourse != string.Empty))
            {
                foreach (var bseUi in lstBseUis)
                {
                    if (bseUi.DataSourse == string.Empty)
                    {
                        continue;
                    }
                    strSql += bseUi.DataSourse + ";";
                    strContrlNameSql += "'" + bseUi.ControlName + " ',";
                }
                return strSql + "SELECT " + strContrlNameSql.TrimEnd(',');
            }
            return string.Empty;
        }

        public static string GetBindSourceSqlByTableName(string strTableName)
        {
            List<Bse_UI> lstBseUis = BseUIManager.GetListUIQuery(strTableName);
            if (lstBseUis.Count == 0)
            {
                return string.Empty;
            }
            string strBindSourceSql = GenBindSourceSql(lstBseUis);
            return strBindSourceSql;
        }

        public static string GetBindSourceEditSqlByTableName(string strTableName)
        {
            List<Bse_UI> lstBseUis = BseUIManager.GetListUIEdit(strTableName);
            if (lstBseUis.Count == 0)
            {
                return string.Empty;
            }
            string strBindSourceSql = GenBindSourceSql(lstBseUis);
            return strBindSourceSql;
        }

        public static string GetBindSourceSqlByTableNameForGrid(string strTableName)
        {
            List<Bse_UI> lstBseUis = BseUIManager.GetListUIShow(strTableName);
            if (lstBseUis.Count == 0)
            {
                return string.Empty;
            }
            string strBindSourceSql = GenBindSourceSql(lstBseUis);
            return strBindSourceSql;
        }

        /// <summary>生成下拉绑定代码
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenBindDataSouce(string strTableName, PanelType panelType)
        {
            StringBuilder sb = new StringBuilder();
            List<Bse_UI> lstBseUis = new List<Bse_UI>();
            if (panelType == PanelType.查询面板)
            {
                lstBseUis = BseUIManager.GetListUIQuery(strTableName);
            }
            else if (panelType == PanelType.编辑面板)
            {
                lstBseUis = BseUIManager.GetListUIEdit(strTableName);
            }
            foreach (Bse_UI ui in lstBseUis)
            {
                string strCtrlNameSpace = ui.ControlNameSpace;
                if (strCtrlNameSpace == "Nikita.WinForm.ExtendControl.CheckedComboBox")
                {
                    sb.AppendLine("CheckedComboBoxHelper.BindCheckedComboBox(" + ui.ControlName + ", ds.Tables[\"" + ui.ControlName + "\"], \"" + ui.FiledText + "\", \"" + ui.FiledValue + "\");");
                }
                else if (strCtrlNameSpace == "System.Windows.Forms.ComboBox")
                {
                    sb.AppendLine("ComboBoxHelper.BindComboBox(" + ui.ControlName + ", ds.Tables[\"" + ui.ControlName + "\"], \"" + ui.FiledText + "\", \"" + ui.FiledValue + "\");");
                }
            }
            return sb.ToString();
        }

        /// <summary>生成下拉绑定代码
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenBindDataSouceForGrid(string strTableName)
        {
            StringBuilder sb = new StringBuilder();
            List<Bse_UI> lstBseUis = BseUIManager.GetListUIShow(strTableName);
            foreach (Bse_UI ui in lstBseUis)
            {
                string strCtrlNameSpace = ui.ControlNameSpace;
                if (strCtrlNameSpace == "System.Windows.Forms.DataGridViewComboBoxColumn")
                {
                    sb.AppendLine("  DataGridViewComboBoxCell " + ui.ControlName + "Cell = this.grdData.Rows[e.RowIndex].Cells[" + ui.ControlName + ".Name] as DataGridViewComboBoxCell; ");
                    sb.AppendLine("            ComboBoxHelper.BindDataGridViewComboBoxCell(" + ui.ControlName + "Cell, m_dsGridSource.Tables[\"" + ui.ControlName + "\"], \"" + ui.FiledText + "\", \"" + ui.FiledValue + "\");");
                    //sb.AppendLine("CheckedComboBoxHelper.BindCheckedComboBox(" + ui.ControlName + ", ds.Tables[\"" + ui.ControlName + "\"], \"" + ui.FiledText + "\", \"" + ui.FiledValue + "\");");
                }
            }
            return sb.ToString();
        }

        #endregion

        public static string CreateAlertInfo(string strColumnName, string strLabelText, string strControlNameSpace, string strControlName)
        {
            StringBuilder sb = new StringBuilder();
            switch (strControlNameSpace)
            {
                case "System.Windows.Forms.TextBox":
                    sb.AppendLine("  if ( " + strControlName + ".Text.Trim() == string.Empty)");
                    sb.AppendLine("            {");
                    sb.AppendLine("         " + strControlName + ".Select();");
                    sb.AppendLine("                return \"" + strLabelText + "不能为空\";");
                    sb.AppendLine("            }");
                    break;
                case "System.Windows.Forms.CheckedListBox":
                    sb.AppendLine("  if ( " + strControlName + ".CheckedItems.Count==0)");
                    sb.AppendLine("            {");
                    sb.AppendLine("         " + strControlName + ".Select();");
                    sb.AppendLine("                return \"请选择" + strLabelText + "\";");
                    sb.AppendLine("            }");
                    break;
                case "System.Windows.Forms.ComboBox":
                    sb.AppendLine("  if ( " + strControlName + ".Text.Trim() == string.Empty)");
                    sb.AppendLine("            {");
                    sb.AppendLine("         " + strControlName + ".Select();");
                    sb.AppendLine("                return \"请选择" + strLabelText + "\";");
                    sb.AppendLine("            }");
                    break;

                case "Nikita.WinForm.ExtendControl.CheckedComboBox":
                    sb.AppendLine("  if ( " + strControlName + ".CheckedItemValues.Trim() == string.Empty)");
                    sb.AppendLine("            {");
                    sb.AppendLine("         " + strControlName + ".Select();");
                    sb.AppendLine("                return \"请选择" + strLabelText + "\";");
                    sb.AppendLine("            }");
                    break;
                case "System.Windows.Forms.NumericUpDown":
                    sb.AppendLine("  if ( " + strControlName + ".Text.Trim() == string.Empty)");
                    sb.AppendLine("            {");
                    sb.AppendLine("         " + strControlName + ".Select();");
                    sb.AppendLine("                return \"请输入" + strLabelText + "\";");
                    sb.AppendLine("            }");
                    break;
                case "System.Windows.Forms.DateTimePicker":
                    sb.AppendLine("  if ( " + strControlName + ".Text.Trim() == string.Empty)");
                    sb.AppendLine("            {");
                    sb.AppendLine("         " + strControlName + ".Select();");
                    sb.AppendLine("                return \"请选择" + strLabelText + "\";");
                    sb.AppendLine("            }");
                    break;
                case "System.Windows.Forms.ListBox":
                    sb.AppendLine("  if ( " + strControlName + ".SelectedItems.Count == 0)");
                    sb.AppendLine("            {");
                    sb.AppendLine("         " + strControlName + ".Select();");
                    sb.AppendLine("                return \"请选择" + strLabelText + "\";");
                    sb.AppendLine("            }");
                    break;
                case "System.Windows.Forms.TreeView":
                    break;
                case "System.Windows.Forms.RadioButton":
                    break;
                case "System.Windows.Forms.CheckBox":
                    break;
            }
            return sb.ToString();
        }


        public static string CreateExistInfo(string strDalName,
            string strColumnName,
            string strLabelText,
            string strControlName,
            string strColumnType,
            string strControlNameSpace,
            OperationType type,
            string strKeyID,
            string strGlobalModelName)
        {
            StringBuilder sb = new StringBuilder();
            switch (strColumnType)
            {
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                case "nchar":
                case "xml":
                case "char":
                case "date":
                case "datetime":
                    if (type == OperationType.新增)
                    {
                        sb.AppendLine("       string str" + strColumnName + "ValueNew = " + GetControlValue(strControlNameSpace, strControlName) + "; ");
                        sb.AppendLine("                if (" + strDalName + ".CalcCount(\"" + strColumnName + "='\" + str" + strColumnName + "ValueNew + \"'\") > 0)");
                    }
                    else if (type == OperationType.修改)
                    {
                        sb.AppendLine("       string str" + strColumnName + "ValueEdit = " + GetControlValue(strControlNameSpace, strControlName) + "; ");
                        sb.AppendLine("                if (" + strDalName + ".CalcCount(\" " + strKeyID + " !=\" + " + strGlobalModelName.Trim() + "." + strKeyID.Trim() + "+ \"   and  " + strColumnName + "='\" + str" + strColumnName + "ValueEdit + \"'\") > 0)");
                    }
                    sb.AppendLine("                {");
                    sb.AppendLine("                    MessageBox.Show(@\"" + strLabelText + "已经存在\");");
                    sb.AppendLine("                    return;");
                    sb.AppendLine("                }");
                    break;
                case "int":
                case "bigint":
                case "smallint":
                case "tinyint":
                case "numeric":
                case "decimal":
                case "float":
                case "double":
                    if (type == OperationType.新增)
                    {
                        sb.AppendLine("       string str" + strColumnName + "ValueNew = " + GetControlValue(strControlNameSpace, strControlName) + " ");
                        sb.AppendLine("                if (" + strDalName + ".CalcCount(\"" + strColumnName + "=\" + str" + strColumnName + "ValueNew + \"\") > 0)");
                    }
                    else if (type == OperationType.修改)
                    {
                        sb.AppendLine("       string str" + strColumnName + "ValueEdit = " + GetControlValue(strControlNameSpace, strControlName) + " ");
                        sb.AppendLine("                if (" + strDalName + ".CalcCount(\" " + strKeyID + " != " + strGlobalModelName + "." + strKeyID + "   and  " + strColumnName + "=\" + str" + strColumnName + "ValueEdit + \"\") > 0)");
                    }
                    sb.AppendLine("                {");
                    sb.AppendLine("                    MessageBox.Show(@\"" + strLabelText + "已经存在\");");
                    sb.AppendLine("                    return;");
                    sb.AppendLine("                }");
                    break;

            }
            return sb.ToString();
        }


        public static string GetControlValue(string strControlNameSpace, string strControlName)
        {
            StringBuilder sb = new StringBuilder();
            switch (strControlNameSpace)
            {
                case "System.Windows.Forms.TextBox":
                    sb.Append("   " + strControlName + ".Text.Trim()  ");
                    break;
                case "System.Windows.Forms.ComboBox":
                    sb.Append("  " + strControlName + ".SelectedValue.ToString().Trim()  ");
                    break;
                case "Nikita.WinForm.ExtendControl.CheckedComboBox":
                    sb.Append(" " + strControlName + ".CheckedItemValues.Trim()  ");
                    break;
                case "System.Windows.Forms.NumericUpDown":
                    sb.Append("  " + strControlName + ".Text.Trim()  ");
                    break;
                case "System.Windows.Forms.DateTimePicker":
                    sb.Append("  " + strControlName + ".Value.ToString().Trim() ");
                    break;
                case "System.Windows.Forms.ListBox":
                    break;
                case "System.Windows.Forms.CheckedListBox":
                    break;
                case "System.Windows.Forms.TreeView":
                    break;
                case "System.Windows.Forms.RadioButton":
                    break;
                case "System.Windows.Forms.CheckBox":
                    break;
            }
            return sb.ToString();
        }

    }
}
