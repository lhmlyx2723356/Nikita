using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Core.Sample
{
    public partial class FrmPort : DockContentEx
    {
        public FrmPort()
        {
            InitializeComponent();
        }

        static CommPortHelper sc = new CommPortHelper();

        static void sc_DataReceived(object sender, SerialDataReceivedEventArgs e, byte[] bits)
        {
            //bits为接收到的数据
        }
         

        private void FrmPort_Load(object sender, EventArgs e)
        {

            sc.DataReceived += new CommPortHelper.SerialPortDataReceiveEventArgs(sc_DataReceived);
            sc.WriteData("at");
            Console.ReadLine();

            sc.WriteData("123");

            while (true)
            {

            }
            sc.ClosePort();
        }
    }
}
