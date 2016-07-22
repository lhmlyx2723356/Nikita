using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.DataAccess4DBHelper;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker
{
    internal class CodeMakerHelper
    {
        private DataTable GenTableByCheckColumns(CodeGenType genType)
        {
            DataTable dt = new DataTable();
            switch (genType)
            {
                case CodeGenType.WinFromSimpleQuery:
                    break;
            }
            return dt;
        }

        public static DataTable GetColumnByTbName(string tbName, string strConn)
        {
            IDbHelper helper = DbHelper.GetDbHelper(SqlType.SqlServer, strConn);
            //MSSQLHelper helper = new MSSQLHelper(strConn); 
            const string strSql = " SELECT 字段名 = a.name, 主键 = CASE WHEN EXISTS ( SELECT  1 FROM    sysobjects WHERE   xtype='PK' AND parent_obj=a.id AND name IN ( SELECT  name  FROM    sysindexes WHERE   indid IN ( SELECT  indid FROM    sysindexkeys WHERE   id=a.id AND colid=a.colid)) ) THEN '√' ELSE ''  END,类型 = b.name,允许空 = CASE WHEN a.isnullable=1 THEN '√'  ELSE '' END,默认值 = ISNULL(e.text,''), 字段说明 = ISNULL(g.value,''),  标识 = CASE WHEN COLUMNPROPERTY(a.id,a.name,'IsIdentity')=1 THEN '√'  ELSE '' END,字段序号 = a.colorder,长度 = COLUMNPROPERTY(a.id,a.name,'PRECISION'), 小数位数 = ISNULL(COLUMNPROPERTY(a.id,a.name,'Scale'),0)FROM   syscolumns a LEFT JOIN systypes b ON a.xusertype=b.xusertype INNER JOIN sysobjects d ON a.id=d.id  AND d.xtype='U' AND d.name<>'dtproperties' AND d.name<>'sysdiagrams'LEFT JOIN syscomments e ON a.cdefault=e.id LEFT JOIN sys.extended_properties g ON a.id=G.major_id  AND a.colid=g.minor_id LEFT JOIN sys.extended_properties f ON d.id=f.major_id AND f.minor_id=0 WHERE d.name=@name  ORDER BY a.id,a.colorder";
            helper.CreateCommand(strSql);
            helper.AddParameter("@name", tbName);
            DataTable dt = helper.ExecuteQuery();
            return dt;
        }

    }
}
