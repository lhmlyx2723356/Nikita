using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int dgvBind()
        {
            PageData pageData = new PageData();
            pageData.TableName = "Has_Charging";
            pageData.PrimaryKey = "ID";
            pageData.OrderStr = "ID desc";
            pageData.PageIndex = this.pager1.PageCurrent;
            pageData.PageSize = this.pager1.PageSize;
            pageData.QueryFieldName = "*";

            this.pager1.bindingSource.DataSource = pageData.QueryDataTable().Tables[0];
            this.pager1.bindingNavigator.BindingSource = pager1.bindingSource;
            this.dataGridView1.DataSource = this.pager1.bindingSource;
            return pageData.TotalCount;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pager1.PageCurrent = 1;
            this.pager1.Bind();
        }

        private int pager1_EventPaging(EventPagingArg e)
        {
            return dgvBind();
        }
    }
}