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
    public partial class FrmWebServiceTest : DockContentEx

    {
        public FrmWebServiceTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object aa;
            if (textBox3.Text.Trim()==string.Empty)
            {

                aa =WebServiceHelper.InvokeWebService(textBox1.Text, textBox2.Text, null);
            }
            else
            {

                aa =WebServiceHelper.InvokeWebService(textBox1.Text, textBox2.Text, new object[]{textBox3.Text.Trim()});       
            }
            MessageBox.Show(aa.ToString());
        }
    }
}
