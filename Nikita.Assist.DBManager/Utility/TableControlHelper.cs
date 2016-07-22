using System;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public class TabControlHelper
    {
        public static DataGridView AddDataGridViewToTabPage(TabPage tabPage)
        {
            DataGridView grdTable = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Dock = DockStyle.Fill,
                Name = new Guid().ToString(),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            tabPage.Controls.Add(grdTable);
            return grdTable;
        }

        public static TabPage AddTabPage(TabControl tabControl)
        {
            TabPage tabPage = new TabPage
            {
                Name = ReturnTabPage(tabControl).ToString(),
                TabIndex = ReturnTabPage(tabControl),
                Text = @"结果" + ReturnTabPage(tabControl),
                UseVisualStyleBackColor = true
            };
            tabControl.TabPages.Add(tabPage);
            return tabPage;
        }

        public static int ReturnTabPage(TabControl tabControl)
        {
            return tabControl.TabPages.Count;
        }
    }
}