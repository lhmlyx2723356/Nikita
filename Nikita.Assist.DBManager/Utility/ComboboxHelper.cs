using System.Data;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public class ComboboxHelper
    {
        public static void BindCombobox(ComboBox combobox, DataTable dtSource, string strValueMember, string strDisplayMember, bool blnSelectFirst)
        {
            combobox.DataSource = dtSource;
            combobox.ValueMember = strValueMember;
            combobox.DisplayMember = strDisplayMember;
            if (blnSelectFirst && dtSource.Rows.Count > 0)
            {
                combobox.SelectedIndex = 0;
            }
            else
            {
                combobox.SelectedIndex = -1;
            }
        }

        public static void BindCombobox(ToolStripComboBox combobox, DataTable dtSource, string strValueMember, string strDisplayMember, bool blnSelectFirst)
        {
            if (combobox.ComboBox != null)
            {
                combobox.ComboBox.DataSource = dtSource;
                combobox.ComboBox.ValueMember = strValueMember;
                combobox.ComboBox.DisplayMember = strDisplayMember;
            }
            if (blnSelectFirst && dtSource.Rows.Count > 0)
            {
                combobox.SelectedIndex = 0;
            }
            else
            {
                combobox.SelectedIndex = -1;
            }
        }
    }
}