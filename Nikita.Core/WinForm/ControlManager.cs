using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Core.WinForm
{
    public class ControlManager
    {
        /// <summary>清空面板容器上的控件输入
        /// 
        /// </summary>
        /// <param name="controlContainer">面板容器</param>
        /// <param name="blnAll">是否清空所有，默认true</param>
        /// <param name="strNotClearCtrlNames">个别不清空的控件名称</param>
        public static void ClearAll(Control controlContainer, bool blnAll = true, string[] strNotClearCtrlNames = null)
        {
            if (blnAll)
            {
                foreach (Control control in controlContainer.Controls)
                {
                    if (control is System.Windows.Forms.Label)
                    {
                        continue;
                    }
                    ClearOne(control);
                    //其它控件类似以上操作即可
                }
            }
            else
            {
                foreach (Control control in controlContainer.Controls)
                {
                    if (strNotClearCtrlNames != null && strNotClearCtrlNames.Contains(control.Name))
                    {
                        continue;
                    }
                    ClearOne(control);
                }
            }
        }
        /// <summary>清空单个控件输入
        /// 
        /// </summary>
        /// <param name="control">控件</param>
        private static void ClearOne(Control control)
        {
            if (control.GetType().ToString() == "Nikita.WinForm.ExtendControl.CheckedComboBox")
            {
                Nikita.WinForm.ExtendControl.CheckedComboBox cbkControlBox = (control as Nikita.WinForm.ExtendControl.CheckedComboBox);
                cbkControlBox.ClearChecked();
            }
            else if (control is System.Windows.Forms.TextBox)
            {
                (control as System.Windows.Forms.TextBox).Text = string.Empty;
            }
            else if (control is System.Windows.Forms.CheckBox)
            {
                (control as System.Windows.Forms.CheckBox).Checked = false;
            }
            else if (control is System.Windows.Forms.ComboBox)
            {
                (control as System.Windows.Forms.ComboBox).SelectedIndex = -1;
            }
            else if (control is System.Windows.Forms.NumericUpDown)
            {
                (control as System.Windows.Forms.NumericUpDown).Value = 0;
            }
            else if (control is System.Windows.Forms.RadioButton)
            {
                (control as System.Windows.Forms.RadioButton).Checked = false;
            }
            else if (control is System.Windows.Forms.RichTextBox)
            {
                (control as System.Windows.Forms.RichTextBox).Text = string.Empty;
            }
            else if (control is System.Windows.Forms.CheckedListBox)
            {
                CheckedListBox chkListBox = (control as System.Windows.Forms.CheckedListBox);
                for (int i = 0; i < chkListBox.Items.Count; i++)
                {
                    chkListBox.SetItemChecked(i, false);
                }
            }
            //else if (control is System.Windows.Forms.DataGridView)
            //{
            //    DataGridView grdData = (control as System.Windows.Forms.DataGridView);
            //    grdData.Rows.Clear();
            //    grdData.DataSource = null;
            //}
            //else if (control is System.Windows.Forms.TreeView)
            //{
            //    TreeView treeView = (control as System.Windows.Forms.TreeView);
            //    treeView.Nodes.Clear();
            //}
        }

        /// <summary>为控件绑定值
        /// 
        /// </summary>
        /// <param name="control">控件名称</param>
        /// <param name="objValue">值</param>
        public static void BindOne(Control control, object objValue)
        {
            if (control.GetType().ToString() == "Nikita.WinForm.ExtendControl.CheckedComboBox")
            {
                Nikita.WinForm.ExtendControl.CheckedComboBox cbkControlBox = (control as Nikita.WinForm.ExtendControl.CheckedComboBox);
                if (cbkControlBox != null && objValue != null)
                {
                    cbkControlBox.SetItemCheckByValues(objValue.ToString());
                }
            }
            else if (control is System.Windows.Forms.TextBox)
            {
                (control as System.Windows.Forms.TextBox).Text = objValue.ToString();
            }
            else if (control is System.Windows.Forms.CheckBox)
            {
                bool blnValue = false;
                if (objValue != null)
                {
                    if ((objValue.ToString() == "1" || objValue.ToString().ToLower() == "true"))
                    {
                        blnValue = true;
                    }
                }
                (control as System.Windows.Forms.CheckBox).Checked = blnValue;
            }
            else if (control is System.Windows.Forms.ComboBox)
            {
                (control as System.Windows.Forms.ComboBox).SelectedValue = objValue;
            }
            else if (control is System.Windows.Forms.NumericUpDown)
            {
                if (objValue!=null)
                { 
                    (control as System.Windows.Forms.NumericUpDown).Value = decimal.Parse(objValue.ToString());
                }
                else
                {
                    (control as System.Windows.Forms.NumericUpDown).Value = 0;
                }
            }
            else if (control is System.Windows.Forms.RadioButton)
            {
                bool blnValue = false;
                if (objValue != null)
                {
                    if ((objValue.ToString() == "1" || objValue.ToString().ToLower() == "true"))
                    {
                        blnValue = true;
                    }
                }
                (control as System.Windows.Forms.RadioButton).Checked = blnValue;
            }
            else if (control is System.Windows.Forms.RichTextBox)
            {
                if (objValue==null)
                {
                    objValue = string.Empty;
                }
                (control as System.Windows.Forms.RichTextBox).Text = objValue.ToString();
            }
            else if (control is System.Windows.Forms.CheckedListBox)
            {
                CheckedListBox chkListBox = (control as System.Windows.Forms.CheckedListBox);
                for (int i = 0; i < chkListBox.Items.Count; i++)
                {
                    chkListBox.SetItemChecked(i, false);
                }
            }
            //else if (control is System.Windows.Forms.DataGridView)
            //{
            //    DataGridView grdData = (control as System.Windows.Forms.DataGridView);
            //    grdData.Rows.Clear();
            //    grdData.DataSource = null;
            //}
            //else if (control is System.Windows.Forms.TreeView)
            //{
            //    TreeView treeView = (control as System.Windows.Forms.TreeView);
            //    treeView.Nodes.Clear();
            //}
        }

        /// <summary>获取控件的值
        /// 
        /// </summary>
        /// <param name="control">控件名称</param>
        /// <returns>值</returns>
        public static object GetOneValue(Control control)
        {
            if (control.GetType().ToString() == "Nikita.WinForm.ExtendControl.CheckedComboBox")
            {
                Nikita.WinForm.ExtendControl.CheckedComboBox cbkControlBox = (control as Nikita.WinForm.ExtendControl.CheckedComboBox);
                if (cbkControlBox != null)
                {
                    return cbkControlBox.CheckedItemValues;
                }
            }
            else if (control is System.Windows.Forms.TextBox)
            {
                return (control as System.Windows.Forms.TextBox).Text;
            }
            else if (control is System.Windows.Forms.CheckBox)
            {
                return (control as System.Windows.Forms.CheckBox).Checked;
            }
            else if (control is System.Windows.Forms.ComboBox)
            {
                return (control as System.Windows.Forms.ComboBox).SelectedValue;
            }
            else if (control is System.Windows.Forms.NumericUpDown)
            {
                return (control as System.Windows.Forms.NumericUpDown).Value;
            }
            else if (control is System.Windows.Forms.RadioButton)
            {
                return (control as System.Windows.Forms.RadioButton).Checked;
            }
            else if (control is System.Windows.Forms.RichTextBox)
            {
                return (control as System.Windows.Forms.RichTextBox).Text;
            }
            else if (control is System.Windows.Forms.CheckedListBox)
            {
                //CheckedListBox chkListBox = (control as System.Windows.Forms.CheckedListBox);
                //for (int i = 0; i < chkListBox.Items.Count; i++)
                //{ 

                //}
            }
            //else if (control is System.Windows.Forms.DataGridView)
            //{
            //    DataGridView grdData = (control as System.Windows.Forms.DataGridView);
            //    grdData.Rows.Clear();
            //    grdData.DataSource = null;
            //}
            //else if (control is System.Windows.Forms.TreeView)
            //{
            //    TreeView treeView = (control as System.Windows.Forms.TreeView);
            //    treeView.Nodes.Clear();
            //}
            return null;
        }


        ///  <summary> 设置面板部分控件的可编辑性
        /// 
        ///  </summary> 
        /// <param name="blnEnable">可编辑为true，只读为false</param>
        /// <param name="ctlContainerControl">承载控件的面板</param>
        /// <param name="strNoCluIds">控件ID列表，逗号分隔，此列表中的的对应ID的控件的可编辑性将不会被设置</param>
        public static void SetControlEnabled(Control ctlContainerControl, bool blnEnable, string[] strNoCluIds =null)
        {
            foreach (Control control in ctlContainerControl.Controls)
            {
                if (control is System.Windows.Forms.Label)
                {
                    continue;
                }
                if (strNoCluIds!=null)
                { 
                    if (strNoCluIds.Contains(control.Name) == false)
                        continue;
                } 
                control.Enabled = blnEnable; 
            }
        }


        /// <summary>设置按钮可用性
        /// 
        /// </summary>
        /// <param name="ctrls"></param>
        /// <param name="blnEnabled"></param>
        public static void SetBtnEnabled(Component[] ctrls, bool blnEnabled)
        {
            foreach (Component ctr in ctrls)
            {
                switch (ctr.GetType().ToString())
                {
                    case "System.Windows.Forms.ToolStripButton":
                        var toolStripButton = ctr as System.Windows.Forms.ToolStripItem;
                        if (toolStripButton != null)
                            toolStripButton.Enabled = blnEnabled;
                        break; 
                    case "System.Windows.Forms.Button":
                        var button = ctr as System.Windows.Forms.Button;
                        if (button != null)
                            button.Enabled = blnEnabled;
                        break; 
                }
            }
        }


        ///  <summary> 获取面板中Tag有设置的控件
        /// 
        ///  </summary> 
        /// <param name="blnEnable">可编辑为true，只读为false</param>
        /// <param name="ctlContainerControl">承载控件的面板</param>
        /// <param name="strNoCluIds">控件ID列表，逗号分隔，此列表中的的对应ID的控件的可编辑性将不会被设置</param>
        public static string[] GetControlTagWithValue(Control ctlContainerControl)
        {
            string strNames = string.Empty;
            foreach (Control control in ctlContainerControl.Controls)
            {
                if (control is System.Windows.Forms.Label)
                {
                    continue;
                }
                if (control.Tag == null || control.Tag.ToString().Trim()==string.Empty)
                {
                    continue;
                }
                strNames += strNames + ",";
            }
            return strNames.Split(',');
        }
    }
}
