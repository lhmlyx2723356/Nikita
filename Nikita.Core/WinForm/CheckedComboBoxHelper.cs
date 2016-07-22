using Nikita.WinForm.ExtendControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Core.WinForm
{
    public class CheckedComboBoxHelper
    {
        /// <summary>绑定自定义控件CheckedComboBox
        ///
        /// </summary>
        /// <param name="cbkCheckedComboBox">控件</param>
        /// <param name="dtSource">DataTable数据源</param>
        /// <param name="strDisplayMember">显示字段</param>
        /// <param name="strValueMember">值字段</param>
        /// <param name="intCheckedIndex">默认勾选项数组,从0开始</param>
        /// <param name="intMaxDropDownItems">最大项数</param>
        /// <param name="strValueSeparator">分隔符</param>
        public static void BindCheckedComboBox(CheckedComboBox cbkCheckedComboBox, DataTable dtSource, string strDisplayMember, string strValueMember, int[] intCheckedIndex = null, int intMaxDropDownItems = 5, string strValueSeparator = ",")
        {
            foreach (DataRow drRow in dtSource.Rows)
            {
                CCBoxItem item = new CCBoxItem(drRow[strDisplayMember].ToString(), drRow[strValueMember].ToString());
                cbkCheckedComboBox.Items.Add(item);
            }
            cbkCheckedComboBox.MaxDropDownItems = intMaxDropDownItems;
            cbkCheckedComboBox.DisplayMember = strDisplayMember;
            cbkCheckedComboBox.ValueMember = strValueMember;
            cbkCheckedComboBox.ValueSeparator = strValueSeparator;
            if (intCheckedIndex != null)
            {
                for (int i = 0; i < intCheckedIndex.Length; i++)
                {
                    cbkCheckedComboBox.SetItemChecked(i, true);
                }
            }
        }
    }
}