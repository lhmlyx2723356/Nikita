using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityFramework.BulkInsert.Extensions;
using Nikita.DataAccess4EF;
using System.Diagnostics;
using System.Transactions;

namespace Nikita.DataAccess.EF.Test
{
    public partial class FrmMainBulkInsert : Form
    {
        public FrmMainBulkInsert()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            List<tb> tbs = new List<tb>();
            for (int i = 0; i < 10000; i++)
            {
                tb entity = new tb();
                entity.name = "10000" + i;
                entity.password = "pwd" + entity.name;
                tbs.Add(entity);
            }
            using (var db = new PermissionEntities())
            {
                db.BulkInsert(tbs);
            }
            watch.Stop();
            MessageBox.Show("插入成功:耗时："+watch.ElapsedMilliseconds);
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            List<tb> entities = new List<tb>();
            using (var db = new PermissionEntities())
            {
                using (var transactionScope = new TransactionScope())
                {
                    // some stuff in dbcontext
                    for (int i = 0; i < 20000; i++)
                    {
                        tb entity = new tb();
                        entity.name = "40000" + i;
                        entity.password = "pwd" + entity.name;
                        entities.Add(entity);
                    }
                    db.BulkInsert(entities);

                     //db.SaveChanges();
                    transactionScope.Complete();
                }
            } watch.Stop();
            MessageBox.Show("插入成功:耗时：" + watch.ElapsedMilliseconds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            //只有.net 4.5 才行
            var options = new BulkInsertOptions
            {
                EnableStreaming = true,
            };
            List<tb> entities = new List<tb>(); 
            for (int i = 0; i < 50000; i++)
            {
                tb entity = new tb();
                entity.name = "60000" + i;
                entity.password = "pwd" + entity.name;
                entities.Add(entity);
            }
            using (var db = new PermissionEntities())
            {
                db.BulkInsert(entities, options);
            } watch.Stop();
            MessageBox.Show("插入成功:耗时：" + watch.ElapsedMilliseconds);
        }
    }
}
