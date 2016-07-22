using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public class ApplicationInstallHelper
    {
        //判断本机是否安装Excel文件方法
        public static bool IsExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }


        //判断本机是否安装Excel文件方法
        public static bool IsWordInstalled()
        {
            Type type = Type.GetTypeFromProgID("Word.Application");
            return type != null;
        }

        //判断本机是否安装Excel文件方法
        public static bool IsPPTInstalled()
        {
            Type type = Type.GetTypeFromProgID("PowerPoint.Application");
            return type != null;
        }
    }
}
