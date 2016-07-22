using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Core.Sample.DAL;
using Nikita.Core.Sample.Model;

namespace Nikita.Core.Sample
{
    public partial class FrmMenuMgrEdit : Form
    {

        private TreeNode node;
        private string strType; 

        public FrmMenuMgrEdit()
        {
            InitializeComponent();
        }
        T_Sample_MenuDAL dal = new T_Sample_MenuDAL();
        public FrmMenuMgrEdit(TreeNode node, string strType)
        {
            InitializeComponent();
            this.node = node;
            this.strType = strType;
            if (strType == "btnEdit")
            {
                txtMenuName.Text = (node.Tag as DataRow)["MenuName"].ToString();
                txtMenuClass.Text = (node.Tag as DataRow)["MenuClass"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMenuClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入菜单类名");
                txtMenuClass.Select();
                return;
            }
            if (txtMenuName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入菜单名称");
                txtMenuName.Select();
                return;
            }
             
            if (txtNameSpace.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入命名空间");
                txtNameSpace.Select();
                return;
            }

            if (strType == "btnEdit")
            {
                DataRow dr = node.Tag as DataRow;
                if (dr != null)
                {
                    T_Sample_Menu model = dal.GetModel(int.Parse(dr["id"].ToString()));
                    model.MenuClass = txtMenuClass.Text.Trim();
                    model.MenuName = txtMenuName.Text.Trim();
                    model.Fileld1 = txtNameSpace.Text.Trim();
                    bool blnflag = dal.Update(model);
                    if (blnflag  )
                    {
                        MessageBox.Show("修改成功"); 
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {

                T_Sample_Menu model = new T_Sample_Menu();
                DataRow dr = node.Tag as DataRow;
                if (dr != null)
                    if (strType == "btnAdd")
                    {
                        model.ParentId = int.Parse(dr["ParentId"].ToString());
                    }
                    else
                    {
                        model.ParentId = int.Parse(dr["Id"].ToString());
                    }

                model.MenuClass = txtMenuClass.Text.Trim();
                model.MenuName = txtMenuName.Text.Trim();
                model.Fileld1 = txtNameSpace.Text.Trim();
                int intflag = dal.Add(model);
                if (intflag > 0)
                {
                    MessageBox.Show("添加成功"); 
                    this.DialogResult = DialogResult.OK;
                }
            }


        }

        private void FrmMenuMgrEdit_Load(object sender, EventArgs e)
        {
            txtMenuClass.Select();
        }
    }
}
