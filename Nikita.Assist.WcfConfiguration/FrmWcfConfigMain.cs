using Nikita.Assist.WcfConfiguration.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.WcfConfiguration
{
    public partial class FrmWcfConfigMain : Form
    {
        public FrmWcfConfigMain()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new WcfConfigInfoDAL().GetListArray("");
        }
    }
}
