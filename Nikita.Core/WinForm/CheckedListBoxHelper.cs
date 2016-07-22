using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Core.WinForm
{
    public class CheckedListBoxHelper
    {
        public static void BindCheckedListBox(CheckedListBox chkListBox, DataTable dtSource, string strDisplayMember,
            string strValueMember)
        {
            chkListBox.DataSource = dtSource;
            chkListBox.DisplayMember = strDisplayMember;
            chkListBox.ValueMember = strValueMember;
        }

        public static void BindCheckedListBox<T>(CheckedListBox chkListBox, IList<T> source, string strDisplayMember,
      string strValueMember)
        {
            chkListBox.DataSource = source;
            chkListBox.DisplayMember = strDisplayMember;
            chkListBox.ValueMember = strValueMember;
        }
 

    }
}
