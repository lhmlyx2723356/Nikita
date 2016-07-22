using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.DataAccess4DBHelper;
using Nikita.WinForm.ExtendControl;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmTreeList : Form
    { 
        public FrmTreeList()
        {
            InitializeComponent(); 
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                btnQuery.Enabled = false;
                InitializeTreeDataSetExample();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                btnQuery.Enabled = true;
            }
        }

        void LoadXmlIntoTreeDataListView()
        {

            DataSet ds = LoadDatasetFromXml("FamilyTree.xml");

            if (ds.Tables.Count > 0)
            {
                // Test with various data sources
                //this.olvDataTree.DataSource = new BindingSource(ds, "Person");
                this.olvDataTree.DataSource = ds.Tables["Person"];
                //this.olvDataTree.DataSource = new DataView(ds.Tables["Person"]);
                //this.olvDataTree.DataMember = "Person"; 
                //this.olvDataTree.DataSource = ds;
                //this.olvDataTree.DataMember = "Person"; 
                //this.olvDataTree.DataSource = new DataViewManager(ds);
            }
        }

        void InitializeTreeDataSetExample()
        {
            this.olvColumn1.ImageGetter = delegate(object row) { return "user"; };
            //this.olvDataTree.RootKeyValue = 0u;

            LoadXmlIntoTreeDataListView();
        }

        DataSet LoadDatasetFromXml(string fileName)
        {
            DataSet ds = new DataSet();
            FileStream fs = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fs))
                {
                    ds.ReadXml(reader);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return ds;
        }

        private void textBoxFilterSimple_TextChanged(object sender, EventArgs e)
        {
            this.TimedFilter(this.olvDataTree, dataTlvFilterTextBox.Text);
        }


        void TimedFilter(ObjectListView olv, string txt)
        {
            this.TimedFilter(olv, txt, 0);
        }

        void TimedFilter(ObjectListView olv, string txt, int matchKind)
        {
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
            {
                switch (matchKind)
                {
                    case 0:
                    default:
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1:
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2:
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }
            // Setup a default renderer to draw the filter matches
            if (filter == null)
                olv.DefaultRenderer = null;
            else
            {
                olv.DefaultRenderer = new HighlightTextRenderer(filter);

                // Uncomment this line to see how the GDI+ rendering looks
                //olv.DefaultRenderer = new HighlightTextRenderer { Filter = filter, UseGdiTextRendering = false };
            }

            // Some lists have renderers already installed
            HighlightTextRenderer highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
            if (highlightingRenderer != null)
                highlightingRenderer.Filter = filter;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            olv.AdditionalFilter = filter;
            //olv.Invalidate();
            stopWatch.Stop();

            IList objects = olv.Objects as IList;
            if (objects == null)
                this.toolStripStatusLabel1.Text =
                    String.Format("Filtered in {0}ms", stopWatch.ElapsedMilliseconds);
            else
                this.toolStripStatusLabel1.Text =
                    String.Format("Filtered {0} items down to {1} items in {2}ms",
                                  objects.Count,
                                  olv.Items.Count,
                                  stopWatch.ElapsedMilliseconds);
        }
    }
}
