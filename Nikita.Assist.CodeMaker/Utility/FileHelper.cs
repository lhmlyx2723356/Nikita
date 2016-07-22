using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.CodeMaker
{
 public   class FileHelper
    {
     public  static void GenFile(string strOutFolderPath, string strFrmClassName, string strContent, bool blnAlert = true)
     {
         if (!Directory.Exists(strOutFolderPath))
         {
             Directory.CreateDirectory(strOutFolderPath);
         }
         string strFilePath = strOutFolderPath + strFrmClassName;
         StreamWriter sw = new StreamWriter(strFilePath, false);
         sw.Write(strContent);
         sw.Flush();
         sw.Close();
         sw.Dispose();
         if (blnAlert)
         {
             MessageBox.Show(@"代码生成成功");
             System.Diagnostics.Process.Start(strOutFolderPath);
         }
     }
    }
}
