using System.Drawing;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public class DatagridViewHelper
    {
        public static void GenAutoNumber(DataGridView grdView, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(grdView.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), grdView.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
    }
}