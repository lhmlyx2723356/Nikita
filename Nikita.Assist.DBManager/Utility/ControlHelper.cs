using System.Linq;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public class ControlHelper
    {
        public static void SetFormControlEnable(Form form, bool blnEnable, string[] strExceptContrlName)
        {
            foreach (Control item in form.Controls)
            {
                if (!strExceptContrlName.Contains(item.Name))
                {
                    item.Enabled = blnEnable;
                }
            }
        }
    }
}