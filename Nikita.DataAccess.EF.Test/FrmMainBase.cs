using Nikita.DataAccess4EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikita.DataAccess.EF.Test
{
    public partial class FrmMainBase : Form
    {
        public FrmMainBase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMainBulkInsert frm = new FrmMainBulkInsert();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMainExtend frm = new FrmMainExtend();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMainPager frm = new FrmMainPager();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain(); frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMainCache frm = new FrmMainCache(); frm.Show();
        }
         
        private void button7_Click(object sender, EventArgs e)
        {
            FrmLambdaBuilderTest bulider = new FrmLambdaBuilderTest();
            bulider.Show();
        }

    }
}
