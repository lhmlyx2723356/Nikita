using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewellerySimpleSystem.EFData
{
 public   class ConnHelper
    {
        public static string GetEntityConnectionString(string edmxFullName, string server, string dadaBase, string usr, string pswd, string appName)
        {
            //<add name="PermissionEntities" connectionString="metadata=res://*/Permission.csdl|res://*/Permission.ssdl|res://*/Permission.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=UKYNDA-001\SQLSERVER2008;initial catalog=Permission;persist security info=True;user id=sa;password=12345678;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder();
            entityConnectionStringBuilder.Metadata = "res://*/" + edmxFullName + ".csdl|res://*/" + edmxFullName + ".ssdl|res://*/" + edmxFullName + ".msl";
            entityConnectionStringBuilder.Provider = "System.Data.SqlClient";
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = server;
            sqlConnectionStringBuilder.InitialCatalog = dadaBase;
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            sqlConnectionStringBuilder.UserID = usr;
            sqlConnectionStringBuilder.Password = pswd;
            sqlConnectionStringBuilder.MultipleActiveResultSets = true;
            sqlConnectionStringBuilder.ApplicationName = appName;
            entityConnectionStringBuilder.ProviderConnectionString = sqlConnectionStringBuilder.ToString();
            return entityConnectionStringBuilder.ConnectionString;
        }
    }
}
