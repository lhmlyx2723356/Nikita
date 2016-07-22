using Nikita.Assist.DBManager.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public partial class FrmTestBatchInsert : Form
    {
        public FrmTestBatchInsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strConn = GlobalHelp.DatabaseManagerDB;
            SQLiteHelper helper = new SQLiteHelper(strConn);
            DataTable dt = new DataTable();
            DataColumn column = dt.Columns.Add("id");
            column.AutoIncrement = true;
            DataColumn column1 = dt.Columns.Add("id1");
            DataColumn column2 = dt.Columns.Add("id2");
            DataColumn column3 = dt.Columns.Add("id3");
            DataColumn column4 = dt.Columns.Add("id4");
            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    dr[j] = Guid.NewGuid() + j.ToString();
                }
                dt.Rows.Add(dr);
            }
            dt.TableName = "test1";
            Stopwatch watch = new Stopwatch();
            watch.Start();
            helper.BatchInsert(dt);
            watch.Stop();
            label1.Text = "耗时：" + watch.ElapsedMilliseconds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySQLHelper helper = new MySQLHelper("server=localhost;database=test;uid=root;pwd=12345678;charset=gbk;Allow User Variables=True");
            DataTable dt = new DataTable();
            DataColumn column = dt.Columns.Add("id");
            DataColumn column1 = dt.Columns.Add("id1");
            DataColumn column2 = dt.Columns.Add("id2");
            DataColumn column3 = dt.Columns.Add("id3");
            DataColumn column4 = dt.Columns.Add("id4");
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = Guid.NewGuid() + j.ToString();
                }
                dt.Rows.Add(dr);
            }
            dt.TableName = "test1";
            Stopwatch watch = new Stopwatch();
            watch.Start();
            helper.BatchInsert(dt);
            watch.Stop();
            label1.Text = "耗时：" + watch.ElapsedMilliseconds;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}