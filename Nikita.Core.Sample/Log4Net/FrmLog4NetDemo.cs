using System;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Core.Sample
{
    public partial class FrmLog4NetDemo : DockContentEx
    {
        public FrmLog4NetDemo()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        { 
            throw new Exception("aaa");
        }

        private void btnSqlite_Click(object sender, EventArgs e)
        { 
            throw new Exception("测试sqlite");
        }
 
    }
}
