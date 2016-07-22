using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Nikita.Assist.Encryption
{
    public partial class FrmEncryptionMain : Form
    {
        public FrmEncryptionMain()
        {
            InitializeComponent();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter("config.ini", false);
            //sw.Write(this.txtString.Text);
            //sw.Close();
            this.txtEnString.Text = DESEncrypt.Encrypt(this.txtString.Text,this.txtKey.Text.Trim());
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            this.txtString.Text = DESEncrypt.Decrypt(this.txtEnString.Text, this.txtKey.Text.Trim());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (File.Exists("config.ini"))
            //{
            //    StreamReader srFile = new StreamReader("config.ini", Encoding.Default);
            //    string Contents = srFile.ReadToEnd();
            //    srFile.Close();
            //    this.txtString.Text = Contents;
            //}
        }
    }
}
