using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikita.DataAccess.EF.Test
{
    public partial class FrmLambdaBuilderTest : Form
    {
        public FrmLambdaBuilderTest()
        {
            InitializeComponent();
        }

        private void FrmLambdaBuilderTest_Load(object sender, EventArgs e)
        {
            using (var enty = new PermissionEntities())
            {
                var users = enty.Bse_User.ToList();
                dataGridView1.DataSource = users;
            }
            lambdaBuilder1.Init<Bse_User>(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lambda = lambdaBuilder1.BuildLambda<Bse_User>();
            textBox1.Text = lambda.Body.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var enty = new PermissionEntities())
            {
                var lambda = lambdaBuilder1.BuildLambda<Bse_User>();
                var users = enty.Bse_User.AsQueryable().Where(lambda).ToList();
                dataGridView1.DataSource = users;
            }
        }
    }
}
