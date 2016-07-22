using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Nikita.WinForm.ExtendControl4DX
{
    public partial class MgncPager : UserControl
    {
        private int allCount = 0;
        private int pageSize = 10;
        private int curPage = 1;
        public delegate void MyPagerEvents(int curPage,int pageSize);
        public delegate void ExportEvents(bool singlePage);//单页，所有
        public event MyPagerEvents myPagerEvents;
        public event ExportEvents exportEvents;
        public MgncPager()
        {
            InitializeComponent();
        }
        //计算分页,分页大小，总记录数。
        public void RefreshPager(int pageSize,int allCount,int curPage)
        {
            this.allCount = allCount;
            this.pageSize = pageSize;
            this.curPage = curPage;
            this.textEditAllPageCount.Text = GetPageCount().ToString();
            lcStatus.Text = string.Format("(共{0}条记录，每页{1}条，共{2}页)", allCount, pageSize, GetPageCount());
            textEditCurPage.Text = curPage.ToString() ;
            textEditToPage.Text = curPage.ToString();
            comboBoxEditPageSize.Text = pageSize.ToString();

            if (curPage == 0)
            {
                if (GetPageCount() > 0)
                {
                    curPage = 1;
                    myPagerEvents(curPage, pageSize);
                }
            }
            if (curPage > GetPageCount())
            {
                curPage = GetPageCount();
                myPagerEvents(curPage, pageSize);
            }
            
        }
        //获取总记录数
        public int GetAllCount()
        {
            return allCount;
        }
        //获得当前页编号，从1开始
        public int GetCurPage()
        {
            return curPage;
        }
        //获得总页数
        public int GetPageCount()
        {
            int count = 0;
            if (allCount % pageSize == 0)
            {
                count = allCount / pageSize;
            }
            else
                count = allCount / pageSize+1;
            return count;
        }

        private void simpleButtonNext_Click(object sender, EventArgs e)
        {
            if (myPagerEvents != null)
            {
                if(curPage<GetPageCount())
                curPage += 1;
                myPagerEvents(curPage,pageSize);
            }
        }

        private void simpleButtonEnd_Click(object sender, EventArgs e)
        {
            if (myPagerEvents != null)
            {
                
                curPage = GetPageCount();
                myPagerEvents(curPage, pageSize);
            }
        }

        private void simpleButtonPre_Click(object sender, EventArgs e)
        {
            if (myPagerEvents != null)
            {
                if (curPage > 1)
                    curPage -= 1;
                myPagerEvents(curPage, pageSize);
            }
        }

        private void simpleButtonFirst_Click(object sender, EventArgs e)
        {
            if (myPagerEvents != null)
            {

                curPage = 1;
                myPagerEvents(curPage, pageSize);
            }
        }

        

        private void simpleButtonToPage_Click(object sender, EventArgs e)
        {
            try
            {
                int selPage = Convert.ToInt32(textEditToPage.Text);
                if (myPagerEvents != null)
                {
                    if ((selPage >= 1) && (selPage <= GetPageCount()))
                        curPage = selPage;
                    myPagerEvents(curPage, pageSize);
                }
            }
            catch (Exception)
            {
                
                //throw;
            }

        }

        private void simpleButtonExportCurPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (exportEvents != null)
                {
                    exportEvents(true);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void simpleButtonExportAllPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (exportEvents != null)
                {
                    exportEvents(false);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void comboBoxEditPageSize_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int pageSize = Convert.ToInt32(comboBoxEditPageSize.Text);
                if ((pageSize > 0))
                {
                    this.pageSize = pageSize;
                    myPagerEvents(curPage, pageSize);
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
