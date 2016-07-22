using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Core.Sample
{
    public partial class FrmPrintLable : DockContentEx
    {
        public FrmPrintLable()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int res;
            if (int.TryParse(txtPrint.Text.Trim(), out res) == false)
            {
                MessageBox.Show("请输入正确的打印份数");
                return;
            }

            if (txtPrint.Text.Trim() == string.Empty || txtPrint.Text.Trim() == "1")
            {
                PrintMb(false);
                GC.Collect();
            }
            else
            {
                for (int i = 0; i < int.Parse(txtPrint.Text.Trim()); i++)
                {
                    PrintMb(false);
                    GC.Collect();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PrintMb(true);
            GC.Collect();
        }

        /// <summary>
        /// 预览打印
        /// </summary>
        /// <param name="yl">True为预览 False为打印</param>
        void PrintMb(bool yl)
        {
            VBprinter.EasyReport er1 = new VBprinter.EasyReport();
            er1.SetReportFile(Application.StartupPath + "\\label.mb");

            er1.SetReportVar("tel", txttel.Text);
            er1.SetReportVar("客户全称", txtallname.Text);
            er1.SetReportVar("客户", cbCust.Text);
            er1.SetReportVar("型号", cbmodel.Text);
            er1.SetReportVar("数量", cbamount.Text);
            er1.SetReportVar("QC", cbclass.Text);
            er1.SetReportVar("日期", dateTimePicker1.Text);
            er1.SetReportVar("备注", txtremark.Text);
            er1.SetReportVar("条码", "12345678");
            if (yl)
            {
                er1.PrintReport(false, false, false, true);
            }
            else
            {
                er1.PrintReport(false, true, false, false);
            }
            er1.Dispose();
            GC.Collect();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //frmNumber number = new frmNumber();
            //if (number.ShowDialog() == DialogResult.OK)
            //{
            //    txtPrint.Text = number.pwd;
            //}
        }

    }
}
