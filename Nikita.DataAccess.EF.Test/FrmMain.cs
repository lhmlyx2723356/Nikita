using Nikita.DataAccess4EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Nikita.DataAccess.EF.Test
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EF一定要有主键，否则报错
            using (var enty = new PermissionEntities())
            {
                for (int i = 0; i < 200; i++)
                {
                    tb aa = new tb();
                    aa.name = (200 + i).ToString();
                    aa.password = "ProvinceName" + aa.name;
                    enty.tb.Add(aa);
                }
                enty.SaveChanges();
            }

            MessageBox.Show("成功");
        }

        private void FrmMain_Load(object sender, EventArgs e)
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


        private List<tb> DoQuery1()
        {
            using (var db = new PermissionEntities())
            {
                var tbs = from tbContext in db.tb
                          where tbContext.name.Contains("2")
                          orderby tbContext.name
                          select tbContext;
                List<tb> lstTb = tbs.ToList();
                return lstTb;
            }
        }

        private List<tb> DoQuery2()
        {
            using (var db = new PermissionEntities())
            {
                var tbs = db.Database.SqlQuery<tb>("select * from tb");
                List<tb> lstTb = tbs.ToList();

                return lstTb;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DoQuery1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new PermissionEntities())
            {
                var tbs = db.tb.Where(t => t.name == "100").FirstOrDefault();
                tbs.password = "abcdefg";
                db.SaveChanges();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DoQuery2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //原生支持
            using (var db = new PermissionEntities())
            {
                //db.tb.SqlQuery
                //db.Database.SqlQuery
                var tbs = db.Database.ExecuteSqlCommand("update tb set password='12345' where name='100'");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //EF一定要有主键，否则报错
            using (var enty = new PermissionEntities())
            {
                tb aa = new tb();
                aa.name = "10000";
                aa.password = "ProvinceName" + aa.name;
                enty.tb.Add(aa);
                enty.tb.Attach(aa);
                enty.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //在上面的方法中 会调用自动检测功能。  这个功能默认是开启的  当我们在做批量操作时 可以关闭这个来提高性能 .例如
            //List<tb> tbs = new List<tb>();
            //using (var context = new PermissionEntities())
            //{
            //    try
            //    {
            //        context.Configuration.AutoDetectChangesEnabled = false;

            //        foreach (var unicorn in tbs)
            //        {
            //            context.tb.Add(unicorn);
            //        }
            //        //  context.tb.AddRange(tbs);
            //    }
            //    finally
            //    {
            //        context.Configuration.AutoDetectChangesEnabled = true;
            //    }
            //}

            using (var db = new PermissionEntities())
            {

                string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                var tbs = db.tb.Where(t => t.name == name).FirstOrDefault();
                db.tb.Remove(tbs);
                //db.Entry(tbs).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            using (var db = new PermissionEntities())
            {
                db.tb.Where(t => t.name.Contains("2")).OrderBy(t => t.name).AsNoTracking().ToList();

            } watch.Stop();
            MessageBox.Show("耗时：" + watch.ElapsedMilliseconds);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            using (var db = new PermissionEntities())
            {
                db.tb.Where(t => t.name.Contains("2")).OrderBy(t => t.name).ToList();

            } watch.Stop();
            MessageBox.Show("AsNoTrackingn耗时：" + watch.ElapsedMilliseconds);
            //测试接近快一倍
        }

        // EF状态 
        // DbSet.Find 
        //  DbSet.Local  
        //  DbSet.Remove 
        // DbSet.Add 
        //  DbSet.Attach 
        //  DbContext.SaveChanges 
        //  DbContext.GetValidationErrors 
        //  DbContext.Entry 
        //  DbChangeTracker.Entries 
        //并不是所有的时候我们都需要EF自动发现状态改变，设置 “DbContext.Configuration.AutoDetectChangesEnabled”属性为“false”可以禁用自动发现功能。
    }
}
