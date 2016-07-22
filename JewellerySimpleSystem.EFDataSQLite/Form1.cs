using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using EntityFramework.BulkInsert.Extensions;
using System.Data.SqlClient;

namespace JewellerySimpleSystem.EFDataSQLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dbsqlite = new EFSQLiteDEMOEntities())
            {
                User user = new User();
                user.Name = textBox1.Text.Trim();
                user.PassWord = textBox2.Text.Trim();
                dbsqlite.User.Add(user);
                dbsqlite.SaveChanges();
            } DoQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        private void DoQuery()
        {
            using (var dbsqlite = new EFSQLiteDEMOEntities())
            {
                List<User> lstUser = dbsqlite.User.Where(t => true).ToList();
                dataGridView1.DataSource = lstUser;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (var dbsqlite = new EFSQLiteDEMOEntities())
            {
                User user = dbsqlite.User.Where(t => t.Id == id).FirstOrDefault();
                user.Name = "hah" + user.Id;
                dbsqlite.SaveChanges();
            } DoQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (var dbsqlite = new EFSQLiteDEMOEntities())
            {
                User user = dbsqlite.User.Where(t => t.Id == id).FirstOrDefault();
                dbsqlite.User.Remove(user);
                dbsqlite.SaveChanges();
            } DoQuery();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            List<User> tbs = new List<User>();
            for (int i = 0; i < 10000; i++)
            {
                User entity = new User();
                entity.Name = "10000" + i;
                entity.PassWord = "pwd" + entity.Name;
                tbs.Add(entity);
            }
            using (var db = new EFSQLiteDEMOEntities())
            {
                //db.BulkInsert(tbs,SqlBulkCopyOptions.KeepIdentity);
            }
            watch.Stop();
            MessageBox.Show("插入成功:耗时：" + watch.ElapsedMilliseconds);
        }
    }
}
