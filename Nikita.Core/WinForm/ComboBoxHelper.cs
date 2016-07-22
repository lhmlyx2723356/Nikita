using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Core.WinForm
{
    public class ComboBoxHelper
    {
        /// <summary>ComboBox绑定
        ///
        /// </summary>
        /// <param name="cboBox">ComboBox控件</param>
        /// <param name="dtSource">DataTable数据源</param>
        /// <param name="strDisplayMember">显示字段</param>
        /// <param name="strValueMember">值字段</param>
        /// <param name="intDefaultSelectIndex">默认选择项，从0开始</param>
        public static void BindComboBox(ComboBox cboBox, DataTable dtSource, string strDisplayMember, string strValueMember, int intDefaultSelectIndex = -1)
        {
            cboBox.DataSource = dtSource;
            cboBox.DisplayMember = strDisplayMember;
            cboBox.ValueMember = strValueMember;
            cboBox.SelectedIndex = intDefaultSelectIndex;
        }

        /// <summary>ComboBox绑定
        ///
        /// </summary>
        /// <param name="cboBox">ComboBox控件</param>
        /// <param name="source">IList数据源</param>
        /// <param name="strDisplayMember">显示字段</param>
        /// <param name="strValueMember">值字段</param>
        /// <param name="intDefaultSelectIndex">默认选择项，从0开始</param>
        public static void BindComboBox<T>(ComboBox cboBox, IList<T> source, string strDisplayMember, string strValueMember, int intDefaultSelectIndex = -1)
        {
            cboBox.DataSource = source;
            cboBox.DisplayMember = strDisplayMember;
            cboBox.ValueMember = strValueMember;
            cboBox.SelectedIndex = intDefaultSelectIndex;
        }

        public static void BindDataGridViewComboBoxCell(DataGridViewComboBoxCell grdComboBoxCell, DataTable dtSource, string strDisplayMember, string strValueMember)
        {
            grdComboBoxCell.DataSource = dtSource;
            grdComboBoxCell.DisplayMember = strDisplayMember;
            grdComboBoxCell.ValueMember = strValueMember;
        }

    }
}