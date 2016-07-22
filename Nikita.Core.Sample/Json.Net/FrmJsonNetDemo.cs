using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using Nikita.Core.Sample.Json.Net;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Core.Sample
{
    public partial class FrmJsonNetDemo : DockContentEx
    {
        public FrmJsonNetDemo()
        {
            InitializeComponent();
            SetUiDefault();
        }

        List<JsonNetDemo> _jsonNetDemos;

        class JsonNetDemo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void FrmJsonNetDemo_Load(object sender, EventArgs e)
        {
            _jsonNetDemos = InitJsonNetDemos();
            olvFast.SetObjects(_jsonNetDemos);
        }

        private void textBoxFilterFast_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(olvFast, textBoxFilterFast.Text, comboBox16.SelectedIndex);
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
            olv.DefaultRenderer = filter == null ? null : new HighlightTextRenderer(filter);
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
                toolStripStatusLabel1.Text =
                    String.Format("Filtered in {0}ms", stopWatch.ElapsedMilliseconds);
            else
                toolStripStatusLabel1.Text =
                    String.Format("在 {0} 条数据中过滤出符合条件的 {1} 数据，耗时{2}ms",
                                  objects.Count,
                                  olv.Items.Count,
                                  stopWatch.ElapsedMilliseconds);
        }



        /// <summary>获取关键代码
        /// 
        /// </summary>
        private void GetCode()
        {
            string strCodePath = Application.StartupPath + "\\SampleFile\\JsonNet\\" + btnDemo.Text + ".txt";
            if (File.Exists(strCodePath))
            {
                rtxCode.Text = File.ReadAllText(strCodePath);
            }
            else
            {
                MessageBox.Show("关键代码不存在");
            }
        }

        private JsonNetDemo GetSelectJsonNetDemo()
        {
            OLVListItem item = olvFast.SelectedItem;
            JsonNetDemo demo = item.RowObject as JsonNetDemo;
            return demo;
        }

        private void SetUi(JsonNetDemo demo)
        {
            btnDemo.Text = demo.Name;
            btnDemo.Name = demo.Id.ToString();
            splitContainer3.Visible = true;
        }

        private void SetUiDefault()
        {
            btnDemo.Name = "btnDemo";
            btnDemo.Text = "测试";
            splitContainer3.Visible = false;
            rtxCode.Text = rtxResult.Text = string.Empty;
        }

        private void olvFast_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUiDefault();
        }

        #region 系列化一个对象
        private void DoTest1()
        {
            rtxResult.Text = SerializeAnObject.DoSerializeAnObject();
        }
        #endregion

        #region 系列化一个Collection
        private void DoTest2()
        {
            rtxResult.Text = SerializeACollection.DoSerializeACollection();
        }

        #endregion

        #region 系列化一个Dictionary

        private void DoTest3()
        {
            rtxResult.Text = SerializeADictionary.DoSerializeADictionary();
        }

        #endregion

        private List<JsonNetDemo> InitJsonNetDemos()
        {
            if (_jsonNetDemos == null)
            {
                _jsonNetDemos = new List<JsonNetDemo>();
            }
            _jsonNetDemos.Clear();
            _jsonNetDemos.Add(new JsonNetDemo()
            {
                Id = 1,
                Name = "系列化一个对象"
            });

            _jsonNetDemos.Add(new JsonNetDemo()
            {
                Id = 2,
                Name = "系列化一个Collection"
            });


            _jsonNetDemos.Add(new JsonNetDemo()
            {
                Id = 3,
                Name = "系列化一个Dictionary"
            });
            return _jsonNetDemos;
        }

        private void olvFast_DoubleClick(object sender, EventArgs e)
        {
            JsonNetDemo demo = GetSelectJsonNetDemo();
            if (demo != null)
                switch (demo.Id)
                {
                    case 1: //系列化一个对象 
                    case 2: //系列化一个Collection
                    case 3: //系列化一个Dictionary
                        SetUi(demo);
                        break;
                }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            switch (btnDemo.Name)
            {
                case "1": //系列化一个对象 
                    DoTest1();
                    break;
                case "2"://系列化一个Collection
                    DoTest2();
                    break;
                case "3"://系列化一个Dictionary
                    DoTest3();
                    break;

            }
            GetCode();

        }
    }
}
