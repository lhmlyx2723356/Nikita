using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Core.Sample
{
    public partial class FrmRichTxtDemo : DockContentEx
    {
        public FrmRichTxtDemo()
        {
            InitializeComponent();
            htmlEditUserControl1.Configure(new Nikita.WinForm.ExtendControl.Code.Configuration.HtmlEditControlConfiguration { AllowFontChange = true, AllowEmbeddedImages = true, AllowPrint = true });
            htmlEditUserControl1.IsToolbarVisible = true;
            htmlEditUserControl1.HtmlEditControl.DocumentText = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string s = @"<P><b>Some tests</b></P><p>Random content. <font color=green>Please edit</font>.</p><p>Use right-click for options.</p>";
            htmlEditUserControl1.HtmlEditControl.DocumentText = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            htmlEditUserControl1.IsToolbarVisible = true;
        }
    }
}
