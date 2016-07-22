using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExfSoft.EntityFramework.Extension;
using EntityFramework.Extensions;
using Nikita.DataAccess4EF;
using System.Diagnostics;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
namespace Nikita.DataAccess.EF.Test
{
    public partial class FrmMainPager : Form
    {
        public FrmMainPager()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            using (var db = new PermissionEntities())
            {
                var query = db.tb.Where(t => true).OrderBy(t => t.name);
                //用skip之前必须OrderBy
                PagerResultModel<tb> tbs = PagerExtension.ToPager<tb>(query, 1000, int.Parse(textBox1.Text.Trim()));

                label1.Text = tbs.Count.ToString();
                dataGridView1.DataSource = tbs.List;
            } watch.Stop();
            MessageBox.Show("ExfSoft.EntityFramework.Extension耗时：" + watch.ElapsedMilliseconds);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            using (var db = new PermissionEntities())
            {
                //看看EF EL怎么解决
                // 复用的查询 
                // base query
                var q = db.tb.Where(t => true);
                // get total count
                var q1 = q.FutureCount();
                // get page
                var q2 = q.OrderBy(t => t.name).Skip((int.Parse(textBox1.Text.Trim()) - 1) * 1000).Take(1000).Future();
                // triggers execute as a batch
                int total = q1.Value;
                var tasks = q2.ToList();

                label1.Text = total.ToString();
                dataGridView1.DataSource = tasks;
            } watch.Stop();
            MessageBox.Show("EntityFramework.Extension耗时：" + watch.ElapsedMilliseconds);
        }

        private void FrmMainPager_Load(object sender, EventArgs e)
        {
            //using (var dbcontext = new PermissionEntities())
            //{
            //    var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
            //    var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            //    mappingCollection.GenerateViews(new List<EdmSchemaError>());
            //}
        }
    }
}
