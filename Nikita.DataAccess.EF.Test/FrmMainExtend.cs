using Nikita.DataAccess4EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityFramework.Extensions;

namespace Nikita.DataAccess.EF.Test
{
    public partial class FrmMainExtend : Form
    {
        public FrmMainExtend()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            using (var db = new PermissionEntities())
            {
                db.tb.Where(u => u.name == name).Delete();
                //或者
                // db.tb.Delete(u => u.name == "101");
                //不需要db.SaveChanges();

            }
        }

        private void FrmMainExtend_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = DoQuery();
        }

        private List<tb> DoQuery()
        {
            using (var db = new PermissionEntities())
            {
                var tbs = db.tb.Where(p => p.name.Contains("1")).OrderBy(p => p.name);
                List<tb> lstTb = tbs.ToList();
                return lstTb;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMainExtend_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var db = new PermissionEntities())
            {
             
                db.tb.Where(u => u.name.Contains("4")).Delete();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new PermissionEntities())
            { 
                db.tb.Update(
                    u => u.name.Contains("2"),
                    u2 => new tb { password = "1111" });
                //或者  db.tb.Where(u => u.name == "2").Update(u => new tb { password = "22222" });
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var db = new PermissionEntities())
            {
                //看看EF EL怎么解决
                // 复用的查询

                // base query
                var q = db.tb.Where(t => t.name.Contains( "1"));
                // get total count
                var q1 = q.FutureCount();
                // get page
                var q2 = q.OrderBy(t=>t.name).Skip((int.Parse(textBox1.Text.Trim())-1)*10 ).Take(10).Future(); 
                // triggers execute as a batch
                int total = q1.Value;
                var tasks = q2.ToList();

                label1.Text = total.ToString();
                dataGridView1.DataSource = tasks;
            }
        }
    }
}
