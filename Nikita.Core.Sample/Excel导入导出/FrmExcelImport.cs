using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NiKita.Core.Sample.Support;
using Nikita.WinForm.ExtendControl;
using Nikita.Core.NPOIs;

namespace Nikita.Core.Sample
{
    public partial class FrmExcelImport : DockContentEx
    {
        public FrmExcelImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds =NPOIHelper.ImportFromExcel(Application.StartupPath + "\\123.xls", 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           NPOIHelper.ExportToExcel(dataGridView1, "测试");
        }

        private void FrmExcelImport_Load(object sender, EventArgs e)
        {
            DataTable dt = DataTableSupport.InitDataTable(5, 20);
            dataGridView1.DataSource = dt;
        }
    }
}
