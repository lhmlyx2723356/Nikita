using System;
using System.Data;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

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