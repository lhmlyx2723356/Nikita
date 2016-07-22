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
using EFSecondLevelCache;
using EntityFramework.BulkInsert.Extensions;
using Nikita.DataAccess4EF;
using EFSecondLevelCache.Contracts;

namespace Nikita.DataAccess.EF.Test
{
    public partial class FrmMainCache : Form
    {
        public FrmMainCache()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int intnum = int.Parse(textBox1.Text.Trim());
            //EF一定要有主键，否则报错
            using (var enty = new studentEntities())
            {
                for (int i = intnum; i < intnum + 100; i++)
                {
                    StudentInfo aa = new StudentInfo();
                    aa.Addess = "地址" + intnum;
                    aa.Age = i + 1;
                    aa.Cid = i;
                    aa.Name = "姓名" + i;
                    enty.StudentInfo.Add(aa);
                }
                enty.SaveChanges();
            }

            MessageBox.Show("成功");
            FrmMainCache_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (var db = new studentEntities())
            {
                var tbs = db.StudentInfo.Where(t => t.Id == id).FirstOrDefault();
                tbs.Name = "更新" + Name + DateTime.Now.ToString();
                db.SaveChanges();
            }
            MessageBox.Show("更新成功");
            FrmMainCache_Load(null, null);
        }

        private void FrmMainCache_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DoQuery1();
        }


        private List<StudentInfo> DoQuery1()
        {
            using (var db = new studentEntities())
            {
                return db.StudentInfo.OrderByDescending(t => t.Id).ToList(); ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMainCache_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (var db = new studentEntities())
            {
                var tbs = db.StudentInfo.Where(t => t.Id == id).FirstOrDefault();
                tbs.Name = "更新" + Name + DateTime.Now.ToString();
                db.StudentInfo.Remove(tbs);
                db.SaveChanges();
            }
            MessageBox.Show("删除成功");
            FrmMainCache_Load(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str1; string str2;
            Stopwatch watch = new Stopwatch();

            watch.Reset();
            watch.Start();
            List<StudentInfo> cc = DoQueryCache2();
            watch.Stop();
            str2 = watch.ElapsedMilliseconds.ToString();

            watch.Reset();
            watch.Start();
            List<StudentInfo> aa = NoCacheQuery();
            watch.Stop();
            str1 = watch.ElapsedMilliseconds.ToString();




            MessageBox.Show("耗时：" + System.Environment.NewLine + "NOCache:" + str1 + System.Environment.NewLine + "Cache1:" + str2);
            dataGridView1.DataSource = cc;


        }

        private List<StudentInfo> NoCacheQuery()
        {
            List<StudentInfo> tbs = null;
            using (var db = new studentEntities())
            {
                tbs = db.StudentInfo.OrderByDescending(t => t.Id).AsNoTracking().ToList(); ;
            }
            return tbs;
        }
        private List<StudentInfo> DoQueryCache2()
        {
            List<StudentInfo> tbs = null;
            using (var db = new studentEntities())
            {
                tbs = db.StudentInfo.Cacheable<StudentInfo>().OrderByDescending(t => t.Id).ToList();  // Async methods are supported too.
            }
            return tbs;
        }


        private void DoQueryCache3()
        {
            using (var db = new studentEntities())
            {
                string str1; string str2;
                Stopwatch watch = new Stopwatch();

                watch.Reset();
                watch.Start();
                //var  tbs1 = db.StudentInfo.OrderByDescending(t => t.Id).AsNoTracking().ToList();        
                var tbs1 = db.StudentInfo.OrderByDescending(t => t.Id); ;
                watch.Stop();
                str1 = watch.ElapsedMilliseconds.ToString();

                watch.Reset();
                watch.Start();
                //var   tbs2 = db.StudentInfo.Cacheable<StudentInfo>().OrderByDescending(t => t.Id).ToList();  // Async methods are supported too.
                var tbs2 = db.StudentInfo.Cacheable().OrderByDescending(t => t.Id); ;
                watch.Stop();
                str2 = watch.ElapsedMilliseconds.ToString();
                MessageBox.Show("耗时：" + System.Environment.NewLine + "NOCache:" + str1 + "数量：" + tbs1.ToList().Count.ToString() + System.Environment.NewLine + "Cache1:" + str2 + "数量：" + tbs2.ToList().Count.ToString());

            }
        }


        private void 原始查询()
        {
            using (var db = new studentEntities())
            {
                string str1;
                Stopwatch watch = new Stopwatch();

                watch.Reset();
                watch.Start();
                //var  tbs1 = db.StudentInfo.OrderByDescending(t => t.Id).AsNoTracking().ToList();        
                var tbs1 = db.StudentInfo.OrderByDescending(t => t.Id);
                watch.Stop();
                str1 = watch.ElapsedMilliseconds.ToString();
                MessageBox.Show("耗时：" + System.Environment.NewLine + "原始查询:" + str1 + "数量：" + tbs1.ToList().Count.ToString());

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int intnum = int.Parse(textBox1.Text.Trim());
            List<StudentInfo> tbs = new List<StudentInfo>();
            for (int i = intnum; i < intnum + 10000; i++)
            {
                StudentInfo aa = new StudentInfo();
                aa.Addess = "地址" + intnum;
                aa.Age = i + 1;
                aa.Cid = i;
                aa.Name = "姓名" + i;
                tbs.Add(aa);
            }
            using (var db = new studentEntities())
            {
                db.BulkInsert(tbs);
            }

            MessageBox.Show("批量插入成功");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DoQueryCache3();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            原始查询();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new EFCacheServiceProvider().ClearAllCachedEntries(); MessageBox.Show("清楚成功：");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (var context = new studentEntities())
            {
                var databaseLog = new StringBuilder();
                context.Database.Log = commandLine =>
                {
                    databaseLog.AppendLine(commandLine);
                    Trace.Write(commandLine);
                };

                Trace.WriteLine("a normal query");
                var product1IncludeTags = context.StudentInfo.FirstOrDefault();



                Trace.WriteLine("1st query using Include method.");
                databaseLog.Clear();
                var debugInfo1 = new EFCacheDebugInfo();
                var firstPoductIncludeTags = context.StudentInfo
                                                             .Cacheable(debugInfo1)
                                                             .FirstOrDefault();
                var hash1 = debugInfo1.EFCacheKey.KeyHash;
                var cacheDependencies1 = debugInfo1.EFCacheKey.CacheDependencies;

                Trace.WriteLine(
                    @"2nd query looks the same, but it doesn't have the Include method, so it shouldn't produce the same queryKeyHash.
                 This was the problem with just parsing the LINQ expression, without considering the produced SQL.");
                databaseLog.Clear();
                var debugInfo2 = new EFCacheDebugInfo();
                var firstPoduct = context.StudentInfo.Cacheable(debugInfo2)
                                                  .FirstOrDefault();
                var hash2 = debugInfo2.EFCacheKey.KeyHash;
                var cacheDependencies2 = debugInfo2.EFCacheKey.CacheDependencies;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new EFCacheServiceProvider().ClearAllCachedEntries();
            
            using (var context = new studentEntities())
            {
                var databaseLog = new StringBuilder();
                context.Database.Log = commandLine =>
                {
                    databaseLog.AppendLine(commandLine);
                    Trace.Write(commandLine);
                };

                Trace.WriteLine("a normal query");
                var product1IncludeTags = context.StudentInfo.Where(t=>t.Id>10);



                Trace.WriteLine("1st query using Include method.");
                databaseLog.Clear();
                var debugInfo1 = new EFCacheDebugInfo();
                var firstPoductIncludeTags = context.StudentInfo.Cacheable(debugInfo1).Where(t => t.Id > 10);
                //var hash1 = debugInfo1.EFCacheKey.KeyHash;
                //var cacheDependencies1 = debugInfo1.EFCacheKey.CacheDependencies;

                Trace.WriteLine(
                    @"2nd query looks the same, but it doesn't have the Include method, so it shouldn't produce the same queryKeyHash.
                 This was the problem with just parsing the LINQ expression, without considering the produced SQL.");
                databaseLog.Clear();
                var debugInfo2 = new EFCacheDebugInfo();
                var firstPoduct = context.StudentInfo.Cacheable(debugInfo2).Where(t => t.Id > 10);
                //var hash2 = debugInfo2.EFCacheKey.KeyHash;
                //var cacheDependencies2 = debugInfo2.EFCacheKey.CacheDependencies;
                //MessageBox.Show(product1IncludeTags.ToList().Count.ToString() + "----" + firstPoductIncludeTags.ToList().Count.ToString() + "----" + firstPoduct.ToList().Count.ToString());

            }
        }

    }
}
