using System;
using System.IO;

namespace Nikita.Assist.WcfService
{
    public class FileHelper
    {
        private string _bigPicFile;
        private string _inFile;
        private string _recentBigFName;
        private string _recentOrgFName;
        private string _recentSmallFileName;
        private string _smallPicFile;

        public byte[] FileRead(string fileName)
        {
            if (File.Exists(fileName) != true)
            {
                return null;
            }
            FileStream tpFs = File.OpenRead(fileName);
            byte[] retBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                int b;
                while ((b = tpFs.ReadByte()) != -1)
                {
                    ms.WriteByte((byte)b);
                }
                retBytes = ms.ToArray();
            }
            tpFs.Close();
            tpFs.Dispose();
            GC.Collect();
            return retBytes;
        }

        public void FileRename(string srcFileName, string disFileName)
        {
            if (File.Exists(srcFileName) != true)
            {
                return;
            }
            File.Move(srcFileName, disFileName);
        }

        public void FileSave(byte[] retBytes, string inFile, string bigFileName, string smallFileName, string recentOrgFName, string recentSmallFileName, string recentBigFName)
        {
            File.WriteAllBytes(inFile, retBytes);
            _inFile = inFile;
            _bigPicFile = bigFileName;
            _smallPicFile = smallFileName;
            _recentOrgFName = recentOrgFName;
            _recentSmallFileName = recentSmallFileName;
            _recentBigFName = recentBigFName;
            ThreadHelper.StartThread(FileThread);
        }

        private void FileThread()
        {
            ImageFile(_inFile, _bigPicFile, _smallPicFile, _recentOrgFName, _recentSmallFileName, _recentBigFName);
        }

        private void ImageFile(string fileName, string bigFileName, string smallFileName, string recentOrgFName, string recentSmallFileName, string recentBigFName)
        {
            MakeThumbnails picHleper = new MakeThumbnails();
            if (File.Exists(recentOrgFName))
            {
                File.SetAttributes(recentOrgFName, FileAttributes.Normal);
                File.Delete(recentOrgFName);
                File.Copy(fileName, recentOrgFName);
            }
            if (File.Exists(bigFileName))
            {
                File.SetAttributes(bigFileName, FileAttributes.Normal);
                File.Delete(bigFileName);
            }
            if (File.Exists(smallFileName))
            {
                File.SetAttributes(smallFileName, FileAttributes.Normal);
                File.Delete(smallFileName);
            }

            picHleper.MakePic(fileName, bigFileName, 1600, 1200, "#FFFFFF", "#999999");
            if (File.Exists(recentBigFName))
            {
                File.SetAttributes(recentBigFName, FileAttributes.Normal);
                File.Delete(recentBigFName);
                File.Copy(bigFileName, recentBigFName);
            }
            picHleper.MakePic(fileName, smallFileName, 400, 300, "#FFFFFF", "#999999");
            if (File.Exists(recentSmallFileName))
            {
                File.SetAttributes(recentSmallFileName, FileAttributes.Normal);
                File.Delete(recentSmallFileName);
                File.Copy(smallFileName, recentSmallFileName);
            }
        }
    }
}