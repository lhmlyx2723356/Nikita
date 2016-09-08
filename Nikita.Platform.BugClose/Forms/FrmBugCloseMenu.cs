using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.WinControls; 
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Platform.BugClose
{
    public partial class FrmBugCloseMenu : DockContentEx
    { 
        public OutlookBar OutlookBarMenu
        {
            get
            {
                return OutLookBarMenu;
            }
        }

        public FrmBugCloseMenu()
        { 
            InitializeComponent(); 
            OutlookBarBand outlookMenu = new OutlookBarBand("基础设置")
            {
                SmallImageList = imageList1,
                LargeImageList = imageList1
            };
            outlookMenu.Items.Add(new OutlookBarItem("缺陷字典管理", 0));
            outlookMenu.Items.Add(new OutlookBarItem("基础项目", 0));
            outlookMenu.Items.Add(new OutlookBarItem("项目版本", 0));
            outlookMenu.Items.Add(new OutlookBarItem("项目模块", 0));

            OutlookBarBand outlookMenu2 = new OutlookBarBand("Bug管理")
            {
                SmallImageList = imageList1,
                LargeImageList = imageList1
            };

            outlookMenu2.Items.Add(new OutlookBarItem("活动Bug", 1));
            outlookMenu2.Items.Add(new OutlookBarItem("所有Bug", 2));
            outlookMenu2.Items.Add(new OutlookBarItem("我的代办", 3));
            outlookMenu2.Items.Add(new OutlookBarItem("分配给我", 4));
            outlookMenu2.Items.Add(new OutlookBarItem("我的分配", 5));
            outlookMenu2.Items.Add(new OutlookBarItem("Bug统计", 5));
            OutlookBarBand outlookMenu3 = new OutlookBarBand("缓存管理")
            {
                SmallImageList = imageList1,
                LargeImageList = imageList1
            };


            outlookMenu3.Items.Add(new OutlookBarItem("基础表设置", 1));
            outlookMenu3.Items.Add(new OutlookBarItem("缓存设置", 2));
            
            OutLookBarMenu.Bands.Add(outlookMenu);
            OutLookBarMenu.Bands.Add(outlookMenu2);
            OutLookBarMenu.Bands.Add(outlookMenu3);
        }

        void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            string message = "Item : " + item.Text + " was clicked...";
            MessageBox.Show(message);
        }

         
    }
}