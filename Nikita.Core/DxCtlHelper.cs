using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using CustomDrawEventArgs = DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs;
using SummaryItemType = DevExpress.Data.SummaryItemType;

namespace Nikita.Core
{
    public class DxCtlHelper
    {
        /// <summary>判断子窗体是否在父窗体中已经打开(true为已打开，false为未打开)
        /// 
        /// </summary>
        /// <param name="FrmParent">父窗体</param>
        /// <param name="ChildName">子窗体名称</param>
        /// <returns>返回bool值</returns>
        public static bool HaveOpenedFrom(Form FrmParent, string ChildName)
        {
            bool Result = false;
            for (int i = 0; i < FrmParent.MdiChildren.Length; i++)
            {
                if (FrmParent.MdiChildren[i].Name == ChildName)
                {
                    FrmParent.MdiChildren[i].BringToFront();
                    Result = true;
                    break;
                }
            }
            return Result;
        }

        public static bool HaveOpenedFromBs(Form FrmParent, string ChildName, string Caption)
        {
            bool Result = false;
            for (int i = 0; i < FrmParent.MdiChildren.Length; i++)
            {
                if (FrmParent.MdiChildren[i].Name == ChildName && Caption == FrmParent.MdiChildren[i].Text)
                {
                    FrmParent.MdiChildren[i].BringToFront();
                    Result = true;
                    break;
                }
            }
            return Result;
        }

        /// <summary>根据上面HaveOpenedFrom方法判断后来决定是否打开窗体
        /// 
        /// </summary>
        /// <param name="FrmParent">父窗体</param>
        /// <param name="FrmChid">子窗体</param>
        public static void OpenChildFrom(Form FrmParent, Form FrmChid)
        {
            if (HaveOpenedFrom(FrmParent, FrmChid.Name))
            {
                FrmChid.Activate();
            }
            else
            {

                FrmChid.MdiParent = FrmParent;
                FrmChid.Show();
                FrmChid.Activate();
            }
        }

        public static void OpenChildFromBs(Form FrmParent, Form FrmChid, string Capation, string NavigateUrl)
        {
            if (HaveOpenedFromBs(FrmParent, FrmChid.Name, FrmChid.Text))
            {
                FrmChid.Activate();
            }
            else
            {
                FrmChid.MdiParent = FrmParent;
                FrmChid.Tag = NavigateUrl;
                FrmChid.Show();
                FrmChid.Activate();
            }
        }

        /// <summary>绑定GridControl控件
        /// 
        /// </summary>
        /// <param name="GridControl">GridControl控件</param>
        /// <param name="Grid">GridView控件</param>
        /// <param name="dt">传入的表</param>
        public static void BindGridControl(GridControl GridControl, GridView Grid, DataTable dt)
        {
            GridControl.DataSource = dt;
            Grid.BestFitColumns();
        }

        public static void BindGridControlWithImg(GridControl GridControl, GridView Grid, DataTable dt)
        {
            DataColumn newColumn = dt.Columns.Add("Icon", Type.GetType("System.Byte[]"));
            newColumn.AllowDBNull = true;
            GridControl.DataSource = dt.DefaultView;
            Grid.BestFitColumns();
        }

        /// <summary>LookUpEdit绑定
        /// 
        /// </summary>
        /// <param name="LookUpEdit">LookUpEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="strTxtField">显示字段</param>
        /// <param name="strValueField">有效值字段</param>
        /// <param name="strfieldNames">显示字段数组</param>
        /// <param name="strHeadTexts">显示名称数组</param>
        /// <param name="blShowHeader">是否显示头</param>
        /// <param name="strSort">排序</param>
        /// <param name="strFilter">过滤dt</param>
        /// <param name="blAddNone">是否显示空</param>
        /// <param name="NullText">NullText的显示文本替换</param>
        /// <param name="TextEditStyle">是否可以填写</param>
        public static void BindLookUpEdit(LookUpEdit LookUpEdit, DataTable dt, string strTxtField, string strValueField, string[] strfieldNames, string[] strHeadTexts, bool blShowHeader, string strSort, string strFilter, bool blAddNone, string NullText, bool TextEditStyle, int ItemIndex)
        {
            LookUpEdit.Properties.DataSource = null;
            DataView dv = dt.Copy().DefaultView;
            dv.RowFilter = strFilter;
            dv.Sort = strSort;
            LookUpEdit.Properties.Columns.Clear();
            LookUpEdit.Properties.NullText = NullText;
            if (TextEditStyle == true)
            {
                LookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                LookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }
            for (int i = 0; i < strfieldNames.Length; i++)
            {
                LookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(strfieldNames[i], strHeadTexts[i]));
            }
            LookUpEdit.Properties.ShowHeader = blShowHeader;
            LookUpEdit.Properties.ValueMember = strValueField;
            LookUpEdit.Properties.DisplayMember = strTxtField;
            if (blAddNone)
            {
                DataRowView dr = dv.AddNew();
                if (dv.Table.Columns.IndexOf("Number") != -1)
                {
                    dr["Number"] = " ";
                }
                dr[strTxtField] = "空";
                dr[strValueField] = "-1";
            }

            LookUpEdit.Properties.DataSource = dv;
            LookUpEdit.EditValue = "-1";
            if (ItemIndex >= 0)
            {
                LookUpEdit.ItemIndex = ItemIndex;
            }

        }

        /// <summary>LookUpEdit绑定
        /// 
        /// </summary>
        /// <param name="LookUpEdit">LookUpEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="strTxtField">显示字段</param>
        /// <param name="strValueField">有效值字段</param> 
        public static void BindLookUpEditWithEmpty(LookUpEdit LookUpEdit, DataTable dt, string strTxtField, string strValueField)
        {
            try
            {
                LookUpEdit.Properties.DataSource = null;
                DataView dv = dt.Copy().DefaultView;
                LookUpEdit.Properties.Columns.Clear();
                LookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                LookUpEdit.Properties.ShowHeader = false;
                LookUpEdit.Properties.ValueMember = strValueField;
                LookUpEdit.Properties.DisplayMember = strTxtField;
                LookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(strTxtField));

                DataRowView dr = dv.AddNew();
                if (dv.Table.Columns.IndexOf("Number") != -1)
                {
                    dr["Number"] = " ";
                }
                dr[strTxtField] = "空";
                dr[strValueField] = "";

                LookUpEdit.Properties.DataSource = dv;
                LookUpEdit.EditValue = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>LookUpEdit绑定
        /// 
        /// </summary>
        /// <param name="LookUpEdit">LookUpEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="strTxtField">显示字段</param>
        /// <param name="strValueField">有效值字段</param> 
        public static void BindLookUpEditWithInt(LookUpEdit LookUpEdit, DataTable dt, string strTxtField, string strValueField)
        {
            LookUpEdit.Properties.DataSource = null;
            DataView dv = dt.Copy().DefaultView;
            LookUpEdit.Properties.Columns.Clear();
            LookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            LookUpEdit.Properties.ShowHeader = false;
            LookUpEdit.Properties.ValueMember = strValueField;
            LookUpEdit.Properties.DisplayMember = strTxtField;
            LookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(strTxtField));
            //if (blAddNone)
            //{
            DataRowView dr = dv.AddNew();
            if (dv.Table.Columns.IndexOf("Number") != -1)
            {
                dr["Number"] = " ";
            }
            dr[strTxtField] = "空";
            dr[strValueField] = "-1";
            //}   
            LookUpEdit.Properties.DataSource = dv;
            LookUpEdit.EditValue = "-1";
        }

        /// <summary>LookUpEdit绑定
        /// 
        /// </summary>
        /// <param name="LookUpEdit">LookUpEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="strTxtField">显示字段</param>
        /// <param name="strValueField">有效值字段</param> 
        public static void BindLookUpEdit(LookUpEdit LookUpEdit, DataTable dt, string strTxtField, string strValueField)
        {
            LookUpEdit.Properties.DataSource = null;
            DataView dv = dt.Copy().DefaultView;
            LookUpEdit.Properties.Columns.Clear();
            LookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            LookUpEdit.Properties.ShowHeader = false;
            LookUpEdit.Properties.ValueMember = strValueField;
            LookUpEdit.Properties.DisplayMember = strTxtField;
            LookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(strTxtField));
            LookUpEdit.Properties.DataSource = dv;
            LookUpEdit.ItemIndex = 0;//默认选中第一行
        }

        public static void BindTreeListLookUpEdit(TreeListLookUpEdit txtCompany, DataTable dt, string KeyFieldName, string ParentFieldName, string ValueMember, string DisplayMember)
        {
            //设置图形序号
            //treeListLookUpEdit1TreeList.SelectImageList = imageList2;
            //treeListLookUpEdit1TreeList.StateImageList = imageList2;
            //txtCompany.Properties.TreeList.SelectImageList
            txtCompany.Properties.TreeList.KeyFieldName = KeyFieldName;
            txtCompany.Properties.TreeList.ParentFieldName = ParentFieldName;
            txtCompany.Properties.DataSource = dt;
            txtCompany.Properties.ValueMember = ValueMember;
            txtCompany.Properties.DisplayMember = DisplayMember;
        }

        /// <summary>ComboBoxEdit绑定
        /// 
        /// </summary>
        /// <param name="ComboBoxEdit">ComboBoxEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="FirstRowText">除了数据源之外显示在第一行的文本（可写：请选择）</param>
        /// <param name="bSelectFirstItem">是否选中第一行</param>
        /// <param name="TextEditStyle">是否可以写</param>
        public static void BindComboBoxEdit(ComboBoxEdit ComboBoxEdit, DataTable dt, string FirstRowText, bool bSelectFirstItem, bool TextEditStyle)
        {
            ComboBoxEdit.Properties.Items.Clear();
            if (!string.IsNullOrEmpty(FirstRowText))
            {
                ComboBoxEdit.Properties.Items.Add(FirstRowText);
            }

            if (TextEditStyle == true)
            {
                ComboBoxEdit.Properties.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                ComboBoxEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }

            int intCount = (dt != null) ? dt.Rows.Count : 0;
            if (intCount > 0)
            {
                for (int i = 0; i < intCount; i++)
                {
                    ComboBoxEdit.Properties.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            if (bSelectFirstItem)
            {
                ComboBoxEdit.SelectedIndex = 0; // 设置选中第1项  
            }
        }

        /// <summary>设置CheckedComboboxEdit模糊搜索(不成功)
        /// 
        /// </summary>
        /// <param name="CheckCombobox"></param>
        /// <param name="dt"></param>
        /// <param name="FilterValue"></param>
        public static void CheckedComboboxSearchMode(CheckedComboBoxEdit CheckCombobox, DataTable dt, string FilterValue)
        {
            try
            {
                string str = CheckCombobox.Text.ToString();
                CheckCombobox.Properties.Items.Clear();//无论有没有过滤，都要清空原来的值
                string Filter = "" + FilterValue + "  like '%" + str + "%' ";
                DataView View = dt.DefaultView;
                View.RowFilter = Filter; ;
                DataTable dtView = View.ToTable();
                if (dtView.Rows.Count > 0)//如果输入的值过滤后有满足的值，则加载满足条件的值,否则加载全部
                {
                    for (int i = 0; i < dtView.Rows.Count; i++)
                    {
                        CheckCombobox.Properties.Items.Add(dtView.Rows[i][FilterValue].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CheckCombobox.Properties.Items.Add(dt.Rows[i][FilterValue].ToString());
                    }
                }
                CheckCombobox.ShowPopup();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>ComboBoxEdit 模仿LookUpEdit，但可以模糊搜索。LookUpEdit只能首字母搜索（在comboBoxEdit1_KeyUp事件添加）
        /// 
        /// </summary>
        /// <param name="ComboBoxEdit">ComboBoxEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="FilterValue">ComboBoxEdit绑定值</param>
        public static void ComboBoxEditSerachMode(ComboBoxEdit ComboBoxEdit, DataTable dt, string FilterValue)
        {
            try
            {
                string str = ComboBoxEdit.Text.ToString();
                ComboBoxEdit.Properties.Items.Clear();//无论有没有过滤，都要清空原来的值
                string Filter = "" + FilterValue + " like '%" + str + "%'";
                DataView View = dt.DefaultView;
                View.RowFilter = Filter;
                DataTable dtView = View.ToTable();
                if (dtView.Rows.Count > 0)//如果输入的值过滤后有满足的值，则加载满足条件的值,否则加载全部
                {
                    for (int i = 0; i < dtView.Rows.Count; i++)
                    {
                        ComboBoxEdit.Properties.Items.Add(dtView.Rows[i][FilterValue].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ComboBoxEdit.Properties.Items.Add(dt.Rows[i][FilterValue].ToString());
                    }
                }
                ComboBoxEdit.ShowPopup();
            }
            catch (Exception)
            {
                //TODO
            }
        }

        /// <summary>ImageCombox 绑定
        /// 
        /// </summary>
        /// <param name="dplX">ImageCombox控件名称</param>
        /// <param name="dt">数据源DataTable</param>
        /// <param name="strTxtField">显示值</param>
        /// <param name="strValueField">有效值</param>
        /// <param name="strSort">排序</param>
        /// <param name="strFilter">过滤</param>
        /// <param name="blAddNone">是否添加一行空白行</param>
        public static void BindImageComboByTable(ImageComboBoxEdit dplX, DataTable dt, string strTxtField, string strValueField, string strSort, string strFilter, bool blAddNone)
        {
            dplX.Properties.Items.Clear();
            if (blAddNone)
            {
                dplX.Properties.Items.Add(new ImageComboBoxItem("", ""));
            }
            DataView dv = dt.Copy().DefaultView;
            dv.Sort = strSort;
            dv.RowFilter = strFilter;
            foreach (DataRowView row in dv)
            {
                dplX.Properties.Items.Add(new ImageComboBoxItem(row[strTxtField].ToString().Trim(), row[strValueField].ToString().Trim()));
            }
            if (dplX.Properties.Items.Count > 0)
            {
                dplX.SelectedIndex = 0;
            }
        }

        /// <summary>绑定GridControl列里的控件RepositoryItemImageComboBox
        /// 
        /// </summary>
        /// <param name="dplX">RepositoryItemImageComboBox控件名称</param>
        /// <param name="dt">数据源</param>
        /// <param name="strTxtField">显示字段</param>
        /// <param name="strValueField">有效值</param>
        /// <param name="strSort">排序</param>
        /// <param name="strFilter">过滤</param>
        /// <param name="blAddNone">是否添加一个空</param>
        public static void BindDplComboByTable(RepositoryItemImageComboBox dplX,
        DataTable dt,
        string strTxtField,
        string strValueField,
        string strSort,
        string strFilter,
        bool blAddNone)
        {
            dplX.Items.Clear();
            if (blAddNone)
            {
                dplX.Items.Add(new ImageComboBoxItem("", ""));
            }
            DataView dv = dt.Copy().DefaultView;
            dv.Sort = strSort;
            dv.RowFilter = strFilter;
            foreach (DataRowView row in dv)
            {
                dplX.Items.Add(new ImageComboBoxItem(row[strTxtField].ToString().Trim(), row[strValueField].ToString().Trim()));
            }
            //if (dplX.Items.Count > 0)
            //{
            //    dplX.te = 0;
            //}
        }

        /// <summary>绑定CheckedComboBoxEdit
        /// 
        /// </summary>
        /// <param name="ckb">CheckedComboBoxEdit</param>
        /// <param name="dt">数据源DataTable</param>
        /// <param name="strTxtFiled">显示值</param>
        /// <param name="strValueFiled">有效值</param>
        /// <param name="strSort">排序</param>
        /// <param name="strFilter">过滤</param>
        public static void BindCheckedComboBoxEdit(CheckedComboBoxEdit ckb, DataTable dt, string strTxtFiled, string strValueFiled, string strSort, string strFilter)
        {
            ckb.Properties.Items.Clear();
            if (dt != null)
            {
                DataView dv = dt.Copy().DefaultView;
                dv.Sort = strSort;
                dv.RowFilter = strFilter;
                foreach (DataRowView row in dv)
                {
                    ckb.Properties.Items.Add(new CheckedListBoxItem(row[strValueFiled].ToString().Trim(), row[strTxtFiled].ToString().Trim()));
                }
            }
        }

        /// <summary>设置面板所有控件的可编辑性
        /// 
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        /// <param name="blEnable">可编辑为true，只读为false</param>
        public static void SetControlEnabled(Control oContainerOfControls, bool blEnable)
        {
            SetControlEnabled(oContainerOfControls, blEnable, string.Empty);
        }

        /// <summary> 设置面板部分控件的可编辑性
        ///
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        /// <param name="blEnable">可编辑为true，只读为false</param>
        /// <param name="strNoCluIds">控件ID列表，逗号分隔，此列表中的的对应ID的控件的可编辑性将不会被设置</param>
        public static void SetControlEnabled(Control oContainerOfControls, bool blEnable, string strNoCluIds)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (strNoCluIds != string.Empty && ("," + strNoCluIds + ",").IndexOf("," + c.Name + ",") == -1)
                    continue;

                if (c is BaseEdit)
                {
                    ((BaseEdit)c).Properties.ReadOnly = !blEnable;
                }
            }
        }


        /// <summary> 设置面板部分控件的可编辑性
        ///
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        /// <param name="blEnable">可编辑为true，只读为false</param>
        /// <param name="strNoCluIds">控件ID列表，逗号分隔，此列表中的的对应ID的控件的可编辑性将不会被设置</param>
        public static void SetControlEnabled(Control oContainerOfControls, bool blEnable, string[] strNoCluIds)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (strNoCluIds.Contains(c.Name) == false)
                    continue;

                var edit = c as BaseEdit;
                if (edit != null)
                {
                    edit.Properties.ReadOnly = !blEnable;
                }
            }
        }

        /// <summary>设置按钮可用性
        /// 
        /// </summary>
        /// <param name="ctrs"></param>
        /// <param name="blEnabled"></param>
        public static void SetBtnEnabled(Component[] ctrs, bool blEnabled)
        {
            foreach (Component ctr in ctrs)
            {
                switch (ctr.GetType().ToString())
                {
                    case "DevExpress.XtraBars.BarButtonItem":
                        (ctr as BarButtonItem).Enabled = blEnabled;
                        break;
                    case "DevExpress.XtraEditors.SimpleButton":
                        (ctr as SimpleButton).Enabled = blEnabled;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>清空面板中所有控件的值
        ///
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        public static void SetControlEmpty(Control oContainerOfControls)
        {
            SetControlEmpty(oContainerOfControls, string.Empty);
        }

        /// <summary>清空面板中部分控件的值
        /// 
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        /// <param name="strNoCluIds">控件ID列表，逗号分隔，此列表中的的对应ID的控件的值将不会被清空</param>
        public static void SetControlEmpty(Control oContainerOfControls, string strNoCluIds)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (strNoCluIds != string.Empty && ("," + strNoCluIds + ",").IndexOf("," + c.Name + ",") != -1)
                    continue;

                switch (c.GetType().ToString())
                {
                    case "DevExpress.XtraEditors.LookUpEdit":
                        ((LookUpEdit)c).EditValue = null;
                        break;
                    case "DevExpress.XtraEditors.TreeListLookUpEdit":
                        ((TreeListLookUpEdit)c).EditValue = null;
                        break;
                    case "DevExpress.XtraEditors.DateEdit":
                        ((DateEdit)c).EditValue = null;
                        break;
                    case "DevExpress.XtraEditors.TextEdit":
                        ((TextEdit)c).EditValue = string.Empty;
                        break;
                    case "DevExpress.XtraEditors.ImageComboBoxEdit":
                        ((ImageComboBoxEdit)c).EditValue = string.Empty;
                        break;
                    case "DevExpress.XtraEditors.CheckEdit":
                        ((CheckEdit)c).Checked = false;
                        break;
                    case "DevExpress.XtraEditors.MemoEdit":
                        ((MemoEdit)c).EditValue = string.Empty;
                        break;
                    case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                        CheckedComboBoxEdit chb = c as CheckedComboBoxEdit;
                        if (chb != null)
                        {
                            chb.Text = string.Empty;
                            chb.EditValue = null;
                            chb.RefreshEditValue();
                        }
                        break;
                    //case "ExtendControl.ExtPopupTree":
                    //    ExtendControl.ExtPopupTree ext = c as ExtendControl.ExtPopupTree;
                    //    ext.EditValue = null;
                    //    break;
                    //case "ProduceManager.UcTxtPopup":
                    //    ProduceManager.UcTxtPopup ucp = c as ProduceManager.UcTxtPopup;
                    //    ucp.EditValue = string.Empty;
                    //    break;

                    default:
                        break;
                }
            }
        }

        public static void SetControlBindings(XtraTabControl oContainerOfControls, DataView dv)
        {
            foreach (XtraTabPage tpage in oContainerOfControls.TabPages)
            {
                foreach (Control c in tpage.Controls)
                {
                    if (Convert.ToString(c.Tag) == string.Empty)
                        continue;
                    c.DataBindings.Clear();
                    c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
                }
            }
        }
        public static void SetControlBindings(GroupControl oContainerOfControls, DataView dv)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
            }
        }
        public static void SetControlBindings(PanelControl oContainerOfControls, DataView dv)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
            }
        }
        public static void SetControlBindings(GroupControl oContainerOfControls, DataTable dt)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dt, c.Tag.ToString());
            }
        }

        public static void SetControlBindings(LayoutControl oContainerOfControls, DataTable dt)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dt, c.Tag.ToString());
            }
        }

        /// <summary>根据表名绑定控件内容
        /// 
        /// </summary>
        /// <param name="layoutCtl">LayoutControl</param>
        /// <param name="dt">表名</param>
        public static void SetControlBindLayout(LayoutControl layoutCtl, DataTable dt)
        {
            foreach (Control c in layoutCtl.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;
                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dt, c.Tag.ToString());
            }
        }
        /// <summary>绑定TreeList
        /// 
        /// </summary>
        /// <param name="TreeList"></param>
        /// <param name="dt"></param>
        /// <param name="KeyFieldName"></param>
        /// <param name="ParentFieldName"></param>
        /// <param name="Filed"></param>
        /// <param name="Caption"></param>
        public static void BindTreeList(TreeList TreeList, DataTable dt, string KeyFieldName, string ParentFieldName, string Filed, string Caption )
        {
            TreeList.BeginInit();
            TreeList.Nodes.Clear();
            TreeList.DataSource = dt;
            TreeList.KeyFieldName = KeyFieldName;
            TreeList.Columns[Filed].Caption = Caption;
            TreeList.ParentFieldName = ParentFieldName;
            TreeList.EndInit(); }

        /// <summary>绑定TreeList
        /// 
        /// </summary>
        /// <param name="TreeList"></param>
        /// <param name="dt"></param>
        /// <param name="KeyFieldName"></param>
        /// <param name="ParentFieldName"></param>
        /// <param name="Filed"></param>
        /// <param name="Caption"></param>
        public static void BindTreeList(TreeList TreeList, DataTable dt, string KeyFieldName, string ParentFieldName, string Filed, string Caption, bool expend)
        {
            TreeList.BeginInit();
            TreeList.Nodes.Clear();
            TreeList.DataSource = dt;
            TreeList.KeyFieldName = KeyFieldName;
            TreeList.Columns[Filed].Caption = Caption;
            TreeList.ParentFieldName = ParentFieldName;
            TreeList.EndInit();
            if (expend)
            {
                TreeList.ExpandAll();
            }
        }

        /// <summary>
        /// 选择某一节点时,该节点的子节点全部选择  取消某一节点时,该节点的子节点全部取消选择
        /// </summary>
        /// <param name="node"></param>
        /// <param name="state"></param>
        public static void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 某节点的子节点全部选择时,该节点选择   某节点的子节点未全部选择时,该节点不选择
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        public static void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {

                CheckState parentCheckState = node.ParentNode.CheckState;
                CheckState nodeCheckState;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    nodeCheckState = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(nodeCheckState))//只要任意一个与其选中状态不一样即父节点状态不全选
                    {
                        parentCheckState = CheckState.Unchecked;
                        break;
                    }
                    parentCheckState = check;//否则（该节点的兄弟节点选中状态都相同），则父节点选中状态为该节点的选中状态
                }

                node.ParentNode.CheckState = parentCheckState;
                SetCheckedParentNodes(node.ParentNode, check);//遍历上级节点
            }
        }

        public static string GetSelectTreeNodeValues(TreeList TreeListMain,string FileName,char split)
        {
            List<TreeListNode> nodes = TreeListMain.GetAllCheckedNodes();
            string ids = string.Empty;
            foreach (TreeListNode currentNode in nodes)
            {
                ids = ids + currentNode[FileName] + split;
            }
           return  ids.TrimEnd(',');
        }

        /// <summary>获取gridview选中行的某个字段的值，用逗号隔开
        /// 
        /// </summary>
        /// <param name="gridVMain"></param>
        /// <param name="fileName"></param>
        /// <param name="spilt"></param>
        /// <returns></returns>
        public static string GetSelectRowsFileValue(GridView gridVMain, string fileName, char spilt)
        {

            string roleIds = string.Empty;
            for (int i = 0; i < gridVMain.SelectedRowsCount; i++)
            {
                roleIds = roleIds + gridVMain.GetDataRow(gridVMain.GetSelectedRows()[i])[fileName] + spilt;
            }
            return roleIds.TrimEnd(spilt);
        }

        /// <summary>绑定GridView里的RepositoryItemComboBox控件
        /// 
        /// </summary>
        /// <param name="rcb"></param>
        /// <param name="dt"></param>
        /// <param name="FirstRowText"></param>
        /// <param name="TextEditStyle"></param>
        public static void BindRptComboBox(RepositoryItemComboBox rcb, DataTable dt, string FirstRowText, bool TextEditStyle)
        {
            rcb.Items.Clear();
            if (!string.IsNullOrEmpty(FirstRowText))
            {
                rcb.Items.Add(FirstRowText);
            }

            if (TextEditStyle == true)
            {
                rcb.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                rcb.TextEditStyle = TextEditStyles.DisableTextEditor;
            }

            int intCount = (dt != null) ? dt.Rows.Count : 0;
            if (intCount > 0)
            {
                for (int i = 0; i < intCount; i++)
                {
                    rcb.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }

        /// <summary>绑定GridView里的RepositoryItemComboBox控件
        /// 
        /// </summary>
        /// <param name="rcb"></param>
        /// <param name="dt"></param>
        /// <param name="FirstRowText"></param>
        /// <param name="TextEditStyle"></param>
        public static void BindRptComboBox(RepositoryItemComboBox rcb, DataTable dt, string FirstRowText, bool TextEditStyle, string ColumnName)
        {
            rcb.Items.Clear();
            if (!string.IsNullOrEmpty(FirstRowText))
            {
                rcb.Items.Add(FirstRowText);
            }

            if (TextEditStyle == true)
            {
                rcb.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                rcb.TextEditStyle = TextEditStyles.DisableTextEditor;
            }

            int intCount = (dt != null) ? dt.Rows.Count : 0;
            if (intCount > 0)
            {
                for (int i = 0; i < intCount; i++)
                {
                    rcb.Items.Add(dt.Rows[i][ColumnName].ToString());
                }
            }
        }

        /// <summary>设置gridcontrol 隔行变色
        /// 
        /// </summary>
        /// <param name="gridVMain">GridView名称</param>
        public static void SetGridChgRowColor(GridView gridVMain)
        {
            gridVMain.OptionsView.EnableAppearanceEvenRow = true;
            gridVMain.OptionsView.EnableAppearanceOddRow = true;
            gridVMain.Appearance.EvenRow.BackColor = SystemColors.ControlLightLight;//设置GridView隔行变色
            gridVMain.Appearance.EvenRow.BackColor2 = SystemColors.ControlLight;
            gridVMain.Appearance.OddRow.BackColor = SystemColors.GradientInactiveCaption;
            gridVMain.Appearance.OddRow.BackColor2 = SystemColors.GradientActiveCaption;
        }

        /// <summary>设置gridcontrol 隔行变色
        /// 
        /// </summary>
        /// <param name="gridVMain">GridView名称</param>
        public static void SetGridChgRowColor(GridView gridVMain, string OddColor1, string OddColor2, string EvenColor1, string EvenColor2)
        {
            gridVMain.OptionsView.EnableAppearanceEvenRow = true;
            gridVMain.OptionsView.EnableAppearanceOddRow = true;
            gridVMain.Appearance.OddRow.BackColor = GetColorFromString(OddColor1);
            gridVMain.Appearance.OddRow.BackColor2 = GetColorFromString(OddColor2);
            gridVMain.Appearance.EvenRow.BackColor = GetColorFromString(EvenColor1);//设置GridView隔行变色
            gridVMain.Appearance.EvenRow.BackColor2 = GetColorFromString(EvenColor2);
        }

        /// <summary>设置窗体为最大
        /// 
        /// </summary>
        /// <param name="frm"></param>
        public static void SetFormWindowStateMax(Form frm)
        {
            if (frm.WindowState != FormWindowState.Maximized)
            {
                frm.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>设置，当查询没有数据源时，提示没有查询到数据
        /// 
        /// </summary>
        /// <param name="gridVMain"></param>
        /// <param name="e"></param>
        public static void DrawEmptyForeground(GridView gridVMain, CustomDrawEventArgs e)
        {
            if (gridVMain.RowCount == 0)
            {
                const string str = "抱歉，没有查询到你所想要的数据!";
                Font f = new Font("微软雅黑", 10, FontStyle.Bold);
                Rectangle r = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 10, e.Bounds.Width - 10, e.Bounds.Height - 10);
                e.Graphics.DrawString(str, f, Brushes.Red, r);
            }
        }

        /// <summary>设置gridview行号
        /// 
        /// </summary>
        /// <param name="gridVMain"></param>
        /// <param name="e"></param>
        public static void CustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        /// <summary>设置列的汇总格式
        /// 
        /// </summary>
        /// <param name="summaryItems"></param>
        /// <param name="gridVMain"></param>
        public static void SummaryItem(string summaryItems, GridView gridVMain)
        {
            gridVMain.OptionsView.ShowFooter = true;
            string[] summaryColumn = summaryItems.Split(',');
            foreach (string t1 in summaryColumn)
            {
                string[] summaryColumnInfo = t1.Split('|');
                foreach (string t in summaryColumnInfo)
                {
                    switch (summaryColumnInfo[1])
                    {
                        case "Sum":
                            gridVMain.Columns[summaryColumnInfo[0]].SummaryItem.SummaryType = SummaryItemType.Sum;
                            break;
                        case "Average":
                            gridVMain.Columns[summaryColumnInfo[0]].SummaryItem.SummaryType = SummaryItemType.Average;
                            break;
                        case "Count":
                            gridVMain.Columns[summaryColumnInfo[0]].SummaryItem.SummaryType = SummaryItemType.Count;
                            break;
                        case "Max":
                            gridVMain.Columns[summaryColumnInfo[0]].SummaryItem.SummaryType = SummaryItemType.Max;
                            break;
                        case "Min":
                            gridVMain.Columns[summaryColumnInfo[0]].SummaryItem.SummaryType = SummaryItemType.Min;
                            break;
                        case "None":
                            gridVMain.Columns[summaryColumnInfo[0]].SummaryItem.SummaryType = SummaryItemType.None;
                            break;
                        default:
                            break;
                    }
                    gridVMain.Columns[summaryColumnInfo[0]].SummaryItem.DisplayFormat = summaryColumnInfo[2];
                }
            }
        }

        /// <summary>设置列的汇总格式
        /// 
        /// </summary>
        /// <param name="summaryItems"></param>
        /// <param name="gridVMain"></param>
        public static void SummaryItem(DataTable summaryItems, GridView gridVMain)
        {
            gridVMain.OptionsView.ShowFooter = true;

            for (int i = 0; i < summaryItems.Rows.Count; i++)
            {
                string conditionType = summaryItems.Rows[i]["ConditionType"].ToString();
                string columnName = summaryItems.Rows[i]["ColumnName"].ToString();
                string DisplayFormat = summaryItems.Rows[i]["DisplayFormat"].ToString();
                switch (conditionType)
                {
                    case "Sum":
                        gridVMain.Columns[columnName].SummaryItem.SummaryType = SummaryItemType.Sum;
                        break;
                    case "Average":
                        gridVMain.Columns[columnName].SummaryItem.SummaryType = SummaryItemType.Average;
                        break;
                    case "Count":
                        gridVMain.Columns[columnName].SummaryItem.SummaryType = SummaryItemType.Count;
                        break;
                    case "Max":
                        gridVMain.Columns[columnName].SummaryItem.SummaryType = SummaryItemType.Max;
                        break;
                    case "Min":
                        gridVMain.Columns[columnName].SummaryItem.SummaryType = SummaryItemType.Min;
                        break;
                    case "None":
                        gridVMain.Columns[columnName].SummaryItem.SummaryType = SummaryItemType.None;
                        break;
                }
                gridVMain.Columns[columnName].SummaryItem.DisplayFormat = DisplayFormat;
            }
        }

        /// <summary>根据列值设置单元格或者行的颜色
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="strCondition"></param>
        /// <param name="isApplyToRow"></param>
        /// <param name="columnName"></param>
        /// <param name="colorName"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="backColor1"></param>
        /// <param name="backColor2"></param>
        public static void SetStyle(GridView gridView, string strCondition, bool isApplyToRow, string columnName, string colorName, string value1, string value2, string backColor1, string backColor2)
        {
            StyleFormatCondition cn;
            switch (strCondition)
            {
                case "Equal":
                    cn = new StyleFormatCondition(FormatConditionEnum.Equal, gridView.Columns[columnName], null, value1)
                    {
                        ApplyToRow = isApplyToRow
                    };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;
                case "NotEqual":
                    cn = new StyleFormatCondition(FormatConditionEnum.NotEqual, gridView.Columns[columnName], null,
                        value1) { ApplyToRow = isApplyToRow };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;
                case "Between":
                    cn = new StyleFormatCondition(FormatConditionEnum.Between, gridView.Columns[columnName], null,
                        value1, value2) { ApplyToRow = isApplyToRow };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;
                case "NotBetween":
                    cn = new StyleFormatCondition(FormatConditionEnum.NotBetween, gridView.Columns[columnName], null,
                        value1, value2) { ApplyToRow = isApplyToRow };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;
                case "Less":
                    cn = new StyleFormatCondition(FormatConditionEnum.Less, gridView.Columns[columnName], null, value1)
                    {
                        ApplyToRow = isApplyToRow
                    };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;
                case "LessOrEqual":
                    cn = new StyleFormatCondition(FormatConditionEnum.LessOrEqual, gridView.Columns[columnName], null,
                        value1) { ApplyToRow = isApplyToRow };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;
                case "Greater":
                    cn = new StyleFormatCondition(FormatConditionEnum.Greater, gridView.Columns[columnName], null,
                        value1) { ApplyToRow = isApplyToRow };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;
                case "GreaterOrEqual":
                    cn = new StyleFormatCondition(FormatConditionEnum.GreaterOrEqual, gridView.Columns[columnName], null,
                        value1) { ApplyToRow = isApplyToRow };
                    //false只对列其作用。 
                    cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
                    if (backColor1 != string.Empty)
                    {
                        cn.Appearance.BackColor = GetColorFromString(backColor1);
                    }
                    if (backColor2 != string.Empty)
                    {

                        cn.Appearance.BackColor2 = GetColorFromString(backColor2);
                    }
                    if (colorName != string.Empty)
                    {
                        cn.Appearance.ForeColor = GetColorFromString(colorName);
                    }
                    gridView.FormatConditions.Add(cn);
                    break;

                //    case "None": 
                //cn = new StyleFormatCondition(FormatConditionEnum.None, gridView.Columns[ColumnName], null, value);
                //        break;
                //case "Expression":
                //    cn = new StyleFormatCondition(FormatConditionEnum.GreaterOrEqual, gridView.Columns[ColumnName], null, value);
                //    break;
            }
        }

        /// <summary>根据列值设置单元格或者行的颜色
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="gridView"></param>
        public static void SetGridViewStyle(DataTable dt, GridView gridView)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SetStyle(gridView, dt.Rows[i]["ConditionType"].ToString(), bool.Parse(dt.Rows[i]["ApplyType"].ToString()), dt.Rows[i]["ColumnName"].ToString(), dt.Rows[i]["Colors"].ToString(), dt.Rows[i]["Value1"].ToString(), dt.Rows[i]["Value2"].ToString(), dt.Rows[i]["BackColor1"].ToString(), dt.Rows[i]["BackColor2"].ToString());
            }
        }

        /// <summary>根据字符串名称获取颜色
        /// 
        /// </summary>
        /// <param name="colorString"></param>
        /// <returns></returns>
        public static Color GetColorFromString(string colorString)
        {
            Color color;
            if (string.IsNullOrEmpty(colorString))
            {
                color = Color.LightBlue;
            }
            else
            {
                ColorConverter converter = new ColorConverter();
                color = (Color)converter.ConvertFromString(colorString);
            }
            return color;
        }

        /// <summary> 复制选中的行到粘贴板
        /// 
        /// </summary>
        /// <param name="gridVMain">要复制的GridVMain</param>
        public static void CopyTitle(GridView gridVMain)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            foreach (GridColumn gridColumn in gridVMain.Columns)
            {
                if (gridColumn.Visible)
                {
                    stringBuilder.AppendFormat("{0} ", gridColumn.Caption);
                }
            }
            int[] selectedRows = gridVMain.GetSelectedRows();
            int[] array = selectedRows;
            foreach (int rowHandle in array)
            {
                foreach (GridColumn gridColumn in gridVMain.Columns)
                {
                    if (gridColumn.Visible)
                    {
                        stringBuilder2.AppendFormat("{0} ", gridVMain.GetRowCellDisplayText(rowHandle, gridColumn.FieldName));
                    }
                }
                stringBuilder2.AppendLine();
            }
            Clipboard.SetText(stringBuilder + "\r\n" + stringBuilder2);
        }
    }
}
