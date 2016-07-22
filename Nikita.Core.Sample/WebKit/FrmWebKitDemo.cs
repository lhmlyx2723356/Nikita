using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebKit;
using WeifenLuo.WinFormsUI;

namespace Nikita.Core.Sample
{
    public partial class FrmWebKitDemo : DockContentEx
    {
        public FrmWebKitDemo()
        {
            InitializeComponent();
        }

        private void FrmWebKitDemo_Load(object sender, EventArgs e)
        { 
            WebKit.WebKitBrowser browser = new WebKitBrowser();
            browser.Dock = DockStyle.Fill; 
            this.Controls.Add(browser);
            browser.Navigate("http://www.baidu.com");
        } 
    }
}
