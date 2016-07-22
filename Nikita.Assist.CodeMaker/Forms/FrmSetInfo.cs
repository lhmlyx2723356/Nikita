using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmSetInfo : Form
    {
        private static string _setOrdKey = string.Empty;

        private static string _setOrdText = string.Empty;

        private readonly SetOrdDal _ordDal = new SetOrdDal();

        private readonly SetDal _setdal = new SetDal();

        public FrmSetInfo()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要删除的记录");
                return;
            }
            if (dataGridView2.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString().Trim()); 
                bool flag = _setdal.Delete(id);

                if (flag)
                {
                    MessageBox.Show(@"删除成功");
                    dataGridView2.DataSource = _setdal.GetList("State=1 AND SetKey='" + _setOrdKey + "'", "id,SetValue,SetText").Tables[0];
                }
            }
        }

        private void btnDeleteOrd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要删除的记录");
                return;
            }
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                SetOrd model = _ordDal.GetModel(id);
                model.State = 0;
                bool flag = _ordDal.Update(model);
                if (flag)
                {
                    MessageBox.Show(@"删除成功");
                    frmSetInfo_Load(null, null);
                    dataGridView1_CellClick(null, null);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要修改的记录");
                return;
            }
            if (dataGridView2.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString().Trim());
                FrmSetInfoEdit edit = new FrmSetInfoEdit(id, _setOrdKey);
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    dataGridView2.DataSource = _setdal.GetList("State=1 AND SetKey='" + _setOrdKey + "'", "id,SetValue,SetText").Tables[0];
                }
            }
        }

        private void btnEditOrd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"请选择要修改的记录");
                return;
            }
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                FrmSetOrdEdit edit = new FrmSetOrdEdit(id);
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    frmSetInfo_Load(null, null);
                    dataGridView1_CellClick(null, null);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmSetInfoEdit edit = new FrmSetInfoEdit(0, _setOrdKey);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                dataGridView2.DataSource = _setdal.GetList("State=1 AND SetKey='" + _setOrdKey + "'", "id,SetValue,SetText").Tables[0];
            }
        }

        private void btnNewOrd_Click(object sender, EventArgs e)
        {
            FrmSetOrdEdit edit = new FrmSetOrdEdit(0);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                frmSetInfo_Load(null, null);
                dataGridView1_CellClick(null, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmSetInfo_Load(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                _setOrdKey = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                _setOrdText = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            btnNew.Text = @"新增" + _setOrdText;
            btnEdit.Text = @"修改" + _setOrdText;
            btnDelete.Text = @"删除" + _setOrdText;
            dataGridView2.DataSource = _setdal.GetList("State=1 AND SetKey='" + _setOrdKey + "'", "id,SetValue,SetText").Tables[0];
        }

        private void frmSetInfo_Load(object sender, EventArgs e)
        {
            DataSet ds = _ordDal.GetList("state=1", "id,SetOrdKey,SetOrdText");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}