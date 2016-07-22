using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public enum FileType
    {
        jpg,    //jpg格式图片
        png,  //png格式图片
        bmp,  //bmp格式图片
        jpeg,  //jpeg格式图片
        gif,    //gif格式图片 

        doc,    //Word文档
        docx,    //Word文档
        ppt,    //Ponwerpoint文档
       xls, // excel
       xlsx, // excel

       pdf,    //PDF文档
       txt,    //文本文档

        mp3,    //mp3音频文件 
        avi,    //avi视频文件
        mpeg,//mpeg视频文件
        all     //所有类型文件
    }
}
