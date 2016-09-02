using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.ConnectionManager;

namespace Nikita.Assist.IDBuilder
{
    public partial class FrmIDBuilder : Form
    {
        private readonly string strConn = ConfigConnection.IDBuilderConnection;

        public FrmIDBuilder()
        {
            InitializeComponent();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FrmIDBuilder_Load(null, null);
        }

        private void FrmIDBuilder_Load(object sender, EventArgs e)
        {
            IDBuilderHelper helper = new IDBuilderHelper();
          dataGridView1.DataSource=      helper.GetInfo(Nikita.Assist.IDBuilder.IDBuilderHelper.SqlType.SqlServer, strConn, "Bse_TableKey");
        dataGridView2.DataSource=    helper.GetInfo(Nikita.Assist.IDBuilder.IDBuilderHelper.SqlType.SqlServer,strConn, "Bse_Series_Number");
        }
    }
}
