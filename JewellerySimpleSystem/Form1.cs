using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nikita.Core;
using System.Data.SqlClient;
using JewellerySimpleSystem.EFData; 

namespace JewellerySimpleSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string aa = CoreHelperFactory.MD5Helper.MD5Encrypt
            //    ("metadata=res://*/Permission.csdl|res://*/Permission.ssdl|res://*/Permission.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=UKYNDA-001\\SQLSERVER2008;initial catalog=Permission;persist security info=True;user id=sa;password=12345678;MultipleActiveResultSets=True;App=EntityFramework&quot;","lhmlyx27");
            //string bb = CoreHelperFactory.MD5Helper.MD5Decrypt(aa, "lhmlyx27");


            //string connstr= @"metadata=res://*/Permission.csdl|res://*/Permission.ssdl|res://*/Permission.msl;provider=System.Data.SqlClient;provider connection string= data source=UKYNDA-001\SQLSERVER2008;initial catalog=Permission;persist security info=True;user id=sa;password=12345678;MultipleActiveResultSets=True;App=EntityFramework;"   ;
            //string cc=    CoreHelperFactory.ConfigHelper.GetConfig("PermissionEntities");
            //string connstrget = GetEntityConnectionString("Permission", @"UKYNDA-001\SQLSERVER2008", "Permission", "sa", "12345678", "EntityFramework");
            //string dd = CoreHelperFactory.MD5Helper.MD5Decrypt(cc, "lhmlyx27");
            //DataAccessFactory.DbConn =  ConnHelper.GetEntityConnectionString("EFDataContext", @"UKYNDA-001\SQLSERVER2008", "Permission", "sa", "12345678", "EntityFramework");
            //List<tb> lst = DataAccessFactory.EntityFrameworkHelper.GetAll<tb>();
        }




    }
}
