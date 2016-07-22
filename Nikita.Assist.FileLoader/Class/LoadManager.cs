using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public class LoadManager
    {
        private IList<Files> files = new List<Files>();

        public IList<Files> Files
        {
            get
            {
                return this.files;
            }
        }

        // 加载指定文件到集合中
        public void LoadFiles(Files file)
        {
            this.files.Add(file);
        }

        // 打开所有文件
        public void OpenAllFiles()
        {
            // 注意这里是通过 接口 来打开文件
            foreach (IFileOpen file in files)
            {
                file.Open();
            }
        }

        // 打开单个文件
        public void OpenFile(IFileOpen file)
        {
            file.Open();
        }

        // 获取文件类型
        public FileType GetFileType(string fileName)
        {
            // 根据指定文件路径返回文件类型
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            return (FileType)Enum.Parse(typeof(FileType), fi.Extension.Substring(1));
        }


    }
}
