using Nikita.Assist.DBManager.DAL;
using Nikita.Assist.DBManager.Model;
using System;
using System.Data;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    public partial class FrmSetInfoTable : DockContentEx
    {
        private static string _setOrdKey = string.Empty;

        private static string _setOrdText = string.Empty;

        private readonly SetOrdTableDAL _orddal = new SetOrdTableDAL();

        private readonly SetTableDAL _setdal = new SetTableDAL();

        public FrmSetInfoTable()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdTableColumn.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要删除的记录");
                return;
            }
            string strIds = string.Empty;
            foreach (DataGridViewRow drRow in grdTableColumn.SelectedRows)
            {
                strIds += drRow.Cells[0].Value.ToString().Trim() + ",";
            }
            bool flag = _setdal.DeleteByCond("  id in (" + strIds.TrimEnd(',') + ")");
            if (flag)
            {
                MessageBox.Show(@"删除成功");
                ReBindColumn();
            }
        }

        private void btnDeleteOrd_Click(object sender, EventArgs e)
        {
            if (grdTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要停用的记录");
                return;
            }
            if (grdTable.CurrentRow != null)
            {
                int id = Convert.ToInt32(grdTable.CurrentRow.Cells[0].Value.ToString().Trim());
                SetOrdTable model = _orddal.GetModel(id);
                model.State = 0;
                bool flag = _orddal.Update(model);
                if (flag)
                {
                    MessageBox.Show(@"停用成功");
                    frmSetInfo_Load(null, null);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdTableColumn.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要修改的记录");
                return;
            }
            if (grdTableColumn.CurrentRow != null)
            {
                int id = Convert.ToInt32(grdTableColumn.CurrentRow.Cells[0].Value.ToString().Trim());
                FrmSetInfoEditTable edit = new FrmSetInfoEditTable(id, _setOrdKey);
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    ReBindColumn();
                }
            }
        }

        private void btnEditOrd_Click(object sender, EventArgs e)
        {
            if (grdTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要修改的记录");
                return;
            }
            if (grdTable.CurrentRow != null)
            {
                int id = Convert.ToInt32(grdTable.CurrentRow.Cells[0].Value.ToString().Trim());
                FrmSetOrdEditTable edit = new FrmSetOrdEditTable(id);
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    frmSetInfo_Load(null, null);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmSetInfoEditTable edit = new FrmSetInfoEditTable(0, _setOrdKey);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                ReBindColumn();
            }
        }

        private void btnNewOrd_Click(object sender, EventArgs e)
        {
            FrmSetOrdEditTable edit = new FrmSetOrdEditTable(0);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                frmSetInfo_Load(null, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmSetInfo_Load(null, null);
        }

        private void btnUnDelete_Click(object sender, EventArgs e)
        {
            if (grdTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要启用的记录");
                return;
            }
            if (grdTable.CurrentRow != null)
            {
                int id = Convert.ToInt32(grdTable.CurrentRow.Cells[0].Value.ToString().Trim());
                SetOrdTable model = _orddal.GetModel(id);
                model.State = 1;
                bool flag = _orddal.Update(model);
                if (flag)
                {
                    MessageBox.Show(@"启用成功");
                    frmSetInfo_Load(null, null);
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (grdTableColumn.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要删除的记录");
                return;
            }
            string strIds = string.Empty;
            foreach (DataGridViewRow drRow in grdTableColumn.SelectedRows)
            {
                strIds += drRow.Cells[0].Value.ToString().Trim() + ",";
            }
            bool flag = _setdal.DeleteByCond("  id in(" + strIds.TrimEnd(',') + ")");
            if (flag)
            {
                MessageBox.Show(@"删除成功");
                ReBindColumn();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdTable.CurrentRow != null)
            {
                _setOrdKey = grdTable.CurrentRow.Cells[0].Value.ToString();
                _setOrdText = grdTable.CurrentRow.Cells[1].Value.ToString();
            }
            btnNew.Text = @"新增" + _setOrdText;
            btnEdit.Text = @"修改" + _setOrdText;
            btnDelete.Text = @"删除" + _setOrdText;
            grdTableColumn.DataSource = _setdal.GetList("State=1 AND SetKey='" + _setOrdKey + "'", "id,SetValue,SetText,Remark,ChangLiang").Tables[0];
        }

        private void frmSetInfo_Load(object sender, EventArgs e)
        {
            DataSet ds = _orddal.GetList("", "id,SetOrdKey,SetOrdText,Remark,state");
            grdTable.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1_CellClick(null, null);
            }
        }

        private void grdTable_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1_CellClick(null, null);
        }

        private void ReBindColumn()
        {
            grdTableColumn.DataSource = _setdal.GetList("State=1 AND SetKey='" + _setOrdKey + "'", "id,SetValue,SetText,Remark,ChangLiang").Tables[0];
        }

        private void 删除选中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要删除的记录");
                return;
            }
            string strIds = string.Empty;
            foreach (DataGridViewRow drRow in grdTable.SelectedRows)
            {
                strIds += drRow.Cells[0].Value.ToString().Trim() + ",";
            }
            bool blnDelete = _orddal.DeleteByCond("  id in(" + strIds.TrimEnd(',') + ")");
            if (blnDelete)
            {
                MessageBox.Show(@"删除成功");
                frmSetInfo_Load(null, null);
            }
        }
    }
}