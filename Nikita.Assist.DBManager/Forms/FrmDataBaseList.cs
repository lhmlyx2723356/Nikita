using System;
using System.Data;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    public partial class FrmDataBaseList : DockContent
    {  
        public FrmDataBaseList()
        {
            InitializeComponent();
            GlobalHelp.TreeView = this.tvwDataBase;
        }
  
    }
}