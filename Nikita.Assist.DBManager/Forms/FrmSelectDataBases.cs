using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public partial class FrmSelectDataBases : Form
    {
        private DataTable m_dtDbs;
        public DataTable LoadDataBase
        {
            get;
            set;
        }
         

        public FrmSelectDataBases(DataTable dtDbs)
        {
            InitializeComponent();
            this.m_dtDbs = dtDbs;
            tvwDBList.Nodes.Clear();
            foreach (DataRow drDb in m_dtDbs.Rows)
            {
                tvwDBList.Nodes.Add(drDb[0].ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<TreeNode> lstTreeNodeCheck = TreeViewHelper.GetAllCheckNodes(this.tvwDBList);

            LoadDataBase = new DataTable();
            LoadDataBase.Columns.Add("name", typeof(string));
            foreach (TreeNode node in lstTreeNodeCheck)
            {
                DataRow dr = LoadDataBase.NewRow();
                dr["name"] = node.Text;
                LoadDataBase.Rows.Add(dr);
            }
            this.DialogResult = DialogResult.OK;

        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (tvwDBList.Nodes.Count == 0)
            {
                return;
            }

            foreach (TreeNode node in tvwDBList.Nodes)
            {
                if (chkSelectAll.Checked == true)
                {

                    node.Checked = true;
                }
                else
                {
                    node.Checked = !node.Checked;
                }
            }
        }

        private void tvwDBList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewHelper.CheckControl(e);
        }

    }
}
