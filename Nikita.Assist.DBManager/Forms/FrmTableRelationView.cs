
using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Assist.DBManager
{
    public partial class FrmTableRelationView : Form
    {
        public FrmTableRelationView()
        {
            InitializeComponent();
        }

        private void AddNode(DataTable dtAll, int ParentId, CTreeNode treeNodeParent)
        {
            DataRow[] drs = dtAll.Select("ParentID=" + ParentId + "");
            if (drs.Length > 0)
            {
                foreach (DataRow item in drs)
                {
                    if (item["TableNameRel"].ToString() == "Key")
                    {
                        CTreeNode treeNode = new CTreeNode(new Label());
                        ((Label)treeNode.Control).Text = item["TableName"].ToString();
                        ((Label)treeNode.Control).Width = 100;
                        ((Label)treeNode.Control).AutoSize = true;
                        ((Label)treeNode.Control).TextAlign = ContentAlignment.MiddleCenter;
                        treeNodeParent.Nodes.Add(treeNode);
                        AddNode(dtAll, int.Parse(item["Id"].ToString()), treeNode);
                    }
                    else
                    {
                        CTreeNode treeNode = new CTreeNode(new DataGridView());
                        ((DataGridView)treeNode.Control).Columns.Add("1", "1");
                        ((DataGridView)treeNode.Control).Columns.Add("2", "2");
                        ((DataGridView)treeNode.Control).Rows.Add(new string[] { "a", "b" });
                        treeNodeParent.Nodes.Add(treeNode);
                        AddNode(dtAll, int.Parse(item["Id"].ToString()), treeNode);
                    }
                }
            }
        }

        private void FrmTableRelationView_Load(object sender, EventArgs e)
        {
            IDBHelper helper = DataBaseManager.GetDbHelper(SqlType.SqlServer, GlobalHelp.ConfigConn);
            helper.CreateCommand("Select * from TableView order by ParentID");
            DataTable dt = helper.ExecuteQuery();
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count == null || dt.Rows.Count == 0)
            {
                return;
            }
            cTreeView1.DrawStyle = CTreeViewDrawStyle.VerticalDiagram;
            cTreeView1.ShowRootLines = false;

            DataTable dtParent = dt.Select("ParentId=0").CopyToDataTable();
            for (int i = 0; i < dtParent.Rows.Count; i++)
            {
                CTreeNode treeNode = new CTreeNode(new Label());
                ((Label)treeNode.Control).Text = dtParent.Rows[i]["TableName"].ToString();
                ((Label)treeNode.Control).Width = 100;
                ((Label)treeNode.Control).AutoSize = true;
                ((Label)treeNode.Control).TextAlign = ContentAlignment.MiddleCenter;
                cTreeView1.Nodes.Add(treeNode);
                AddNode(dt, int.Parse(dtParent.Rows[i]["Id"].ToString()), treeNode);
            }

            //cTreeView1.Nodes.Add(new CTreeNode(new Label()));
            //((Label)cTreeView1.Nodes[0].Control).Text = "附属设施关系";
            //((Label)cTreeView1.Nodes[0].Control).Width = 100;
            //((Label)cTreeView1.Nodes[0].Control).AutoSize = true;
            //((Label)cTreeView1.Nodes[0].Control).TextAlign = ContentAlignment.MiddleCenter;

            //cTreeView1.Nodes[0].Nodes.Add(new CTreeNode(new Label()));
            //((Label)cTreeView1.Nodes[0].Nodes[0].Control).Text = "RuleId_DetailId";
            //((Label)cTreeView1.Nodes[0].Nodes[0].Control).Width = 100;
            //((Label)cTreeView1.Nodes[0].Nodes[0].Control).AutoSize = true;
            //((Label)cTreeView1.Nodes[0].Nodes[0].Control).TextAlign = ContentAlignment.MiddleCenter;

            ////下面添加两个GridView
            //cTreeView1.Nodes[0].Nodes[0].Nodes.Add(new CTreeNode(new DataGridView()));
            //((DataGridView)cTreeView1.Nodes[0].Nodes[0].Nodes[0].Control).Columns.Add("1", "1");
            //((DataGridView)cTreeView1.Nodes[0].Nodes[0].Nodes[0].Control).Columns.Add("2", "2");
            //((DataGridView)cTreeView1.Nodes[0].Nodes[0].Nodes[0].Control).Rows.Add(new string[] { "a", "b" });

            //cTreeView1.Nodes[0].Nodes[0].Nodes.Add(new CTreeNode(new DataGridView()));
            //((DataGridView)cTreeView1.Nodes[0].Nodes[0].Nodes[1].Control).Columns.Add("1", "1");
            //((DataGridView)cTreeView1.Nodes[0].Nodes[0].Nodes[1].Control).Columns.Add("2", "2");
            //((DataGridView)cTreeView1.Nodes[0].Nodes[0].Nodes[1].Control).Rows.Add(new string[] { "a", "b" });

            //cTreeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add(new CTreeNode(new Label()));
            //((Label)cTreeView1.Nodes[0].Nodes[0].Nodes[1].Nodes[0].Control).Text = "RuleId_DetailId";
            //((Label)cTreeView1.Nodes[0].Nodes[0].Nodes[1].Nodes[0].Control).Width = 100;
            //((Label)cTreeView1.Nodes[0].Nodes[0].Nodes[1].Nodes[0].Control).AutoSize = true;
            //((Label)cTreeView1.Nodes[0].Nodes[0].Nodes[1].Nodes[0].Control).TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}