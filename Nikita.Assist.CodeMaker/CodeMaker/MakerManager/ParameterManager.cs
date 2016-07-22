using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public class ParameterManager
    {
        public static BasicParameter GetBasicParameter(string strTableName)
        {
            BasicParameter basicPara = new BasicParameter();
            SetDal setDal = new SetDal();
            //12,代码生成路径 ,13,默认数据库连接字符串
            List<Set> lstSet = setDal.GetListArray("  SetKey in ('12','13','14','15','16')");
            //输出路径
            if (lstSet.FirstOrDefault(t => t.SetKey == "12") != null)
            {
                var firstOrDefault = lstSet.FirstOrDefault(t => t.SetKey == "12");
                if (firstOrDefault != null) basicPara.OutFolderPath = firstOrDefault.SetValue;
            }
            //默认数据库连接字符串
            if (lstSet.FirstOrDefault(t => t.SetKey == "13") != null)
            {
                var orDefault = lstSet.FirstOrDefault(t => t.SetKey == "13");
                if (orDefault != null) basicPara.Conn = orDefault.SetValue;
            }
            //默认作者
            if (lstSet.FirstOrDefault(t => t.SetKey == "14") != null)
            {
                var @default = lstSet.FirstOrDefault(t => t.SetKey == "14");
                if (@default != null) basicPara.Author = @default.SetValue;
            }
            //主命名空间
            if (lstSet.FirstOrDefault(t => t.SetKey == "15") != null)
            {
                var firstOrDefault1 = lstSet.FirstOrDefault(t => t.SetKey == "15");
                if (firstOrDefault1 != null) basicPara.NameSpace = firstOrDefault1.SetValue;
            }
            //去除表前缀
            if (lstSet.FirstOrDefault(t => t.SetKey == "16") != null)
            {
                var firstOrDefault2 = lstSet.FirstOrDefault(t => t.SetKey == "16");
                if (firstOrDefault2 != null) basicPara.TablePrefix = firstOrDefault2.SetValue;
            }
            if (strTableName != string.Empty)
            {
                //表名
                basicPara.TableName = strTableName;
                //类名
                string strClassName = strTableName;
                if (basicPara.TablePrefix !=string.Empty)
                {
                    strClassName = strTableName.Replace(basicPara.TablePrefix, "");
                }
                basicPara.ClassName = strClassName.Substring(0, 1).ToUpper() + strClassName.Substring(1);
            }
            return basicPara;
        }
    }
}