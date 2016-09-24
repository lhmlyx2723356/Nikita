using Nikita.Assist.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Core.Sample
{
    public partial class FrmLogger : Form
    {
        public FrmLogger()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception("hhhhh");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLoggerInfo frmInfo = new FrmLoggerInfo();
            frmInfo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (!File.Exists(Application.StartupPath + "\\" + "Log1.ini"))
            //{
            //    File.Create(Application.StartupPath + "\\" + "Log1.ini");
            //} 
             string file = Application.StartupPath + "\\" + "Log.ini";
           
            ////写入/更新键值

             //INIOperationClass.INIWriteValue(file, "LogConnection", "Connection", "abc");

             //INIOperationClass.INIWriteValue(file, "LogType", "Type", "bbc");
            //INIOperationClass.INIWriteValue(file, "Desktop", "Width", "3270");

            //INIOperationClass.INIWriteValue(file, "Toolbar", "Items", "Save,Delete,Open");
            ////INIOperationClass.INIWriteValue(file, "Toolbar", "Dock", "True");
             //string value = INIOperationClass.INIGetStringValue(file, "LogConnection", "Connection", null);
             //string value1 = INIOperationClass.INIGetStringValue(file, "LogType", "Type", null);
        }
        ////写入一批键值
        //INIWriteItems(file, "Menu", "File=文件\0View=视图\0Edit=编辑");

        ////获取文件中所有的节点
        //string[] sections = INIGetAllSectionNames(file);

        ////获取指定节点中的所有项
        //string[] items = INIGetAllItems(file, "Menu");

        ////获取指定节点中所有的键
        //string[] keys = INIGetAllItemKeys(file, "Menu");

        ////获取指定KEY的值

        ////删除指定的KEY
        //INIDeleteKey(file, "desktop", "color");

        ////删除指定的节点
        //INIDeleteSection(file, "desktop");

        ////清空指定的节点
        //INIEmptySection(file, "toolbar");
 
    }
}
