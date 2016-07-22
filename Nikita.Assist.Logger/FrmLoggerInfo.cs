using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.Logger
{
    public partial class FrmLoggerInfo : Form
    {
        public FrmLoggerInfo()
        {
            InitializeComponent();
        }
        LoggerHelper helper = new LoggerHelper();
        private void grdLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grdLog.CurrentRow == null)
            {
                return;
            }
            txtLogInfo.Text = this.grdLog.CurrentRow.Cells["Column4"].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = " Date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "' order by id desc ";
            DoQuery(strWhere);
        }

        private void 初始化日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoggerInit frmInit = new FrmLoggerInit();
            if (frmInit.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("初始化成功"); 
            }
        }

        private void FrmLogger_Load(object sender, EventArgs e)
        {
            this.grdLog.AutoGenerateColumns = false;
            dateTimePicker2.Value = dateTimePicker2.Value.AddDays(1);
        }

        private void DoQuery(string strWhere)
        {
            DataSet ds = LoggerHelper.GetLogInfo(strWhere);
            if (ds != null && ds.Tables.Count > 0)
            {
                grdLog.DataSource = ds.Tables[0];
            }
        } 

    }
}
