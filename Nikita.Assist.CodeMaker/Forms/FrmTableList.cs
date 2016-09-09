using System;
using System.Data;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmTableList : DockContent
    {
        public FrmTableList()
        {
            InitializeComponent();
            GlobalHelp.TreeView = this.tvwDataBase;
        }
    }
}