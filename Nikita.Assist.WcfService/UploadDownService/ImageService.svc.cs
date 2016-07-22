using System.Configuration;

namespace Nikita.Assist.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ImageService”。
    public class ImageService : IImageService
    {
        public byte[] FileRead(string strUrl, string fileName)
        {
            FileHelper fileHelper = new FileHelper();
            fileName = (ConfigurationManager.AppSettings[strUrl] + "\\" + fileName);
            byte[] tpBys = fileHelper.FileRead(fileName);
            return tpBys;
        }

        public byte[] FileReadImage( string fileName)
        {
            FileHelper fileHelper = new FileHelper();
            fileName = ConfigurationManager.AppSettings["ReadFile"] + "\\" + fileName;
            byte[] tpBys = fileHelper.FileRead(fileName);
            return tpBys;
        }


        public void FileSave(byte[] retBytes, string fileName,
            string imgUrl, string bigImgUrl, string smallImgUrl,
            string recentSmallImgUrl, string recentBigImgUrl, string recentOrgImgUrl)
        {
            FileHelper fileHelper = new FileHelper();
            string inFile = (ConfigurationManager.AppSettings[imgUrl] + "\\" + fileName);
            string bigFileName = (ConfigurationManager.AppSettings[bigImgUrl] + "\\" + fileName);
            string smallFileName = (ConfigurationManager.AppSettings[smallImgUrl] + "\\" + fileName);
            string recentSmallFName = (ConfigurationManager.AppSettings[recentSmallImgUrl] + "\\" + fileName);
            string recentBigFName = (ConfigurationManager.AppSettings[recentBigImgUrl] + "\\" + fileName);
            string recentOrgFName = (ConfigurationManager.AppSettings[recentOrgImgUrl] + "\\" + fileName);
            fileHelper.FileSave(retBytes, inFile, bigFileName, smallFileName, recentOrgFName, recentSmallFName, recentBigFName);
        }

      
         
        public void FileSaveImage(byte[] retBytes, string fileName)
        {
            FileHelper fileHelper = new FileHelper(); 
            string inFile = ConfigurationManager.AppSettings["ImgFile"] + "\\" + fileName;
            string bigFileName = ConfigurationManager.AppSettings["ProdImgFile"] + "\\" + fileName;
            string smallFileName = ConfigurationManager.AppSettings["SmallPic"] + "\\" + fileName;
            string recentOrgFName = ConfigurationManager.AppSettings["RecentOrgFile"] + "\\" + fileName;
            string recentSmallFName = ConfigurationManager.AppSettings["RecentSmallFile"] + "\\" + fileName;
            string recentBigFName = ConfigurationManager.AppSettings["RecentBigFile"] + "\\" + fileName;
            fileHelper.FileSave(retBytes, inFile, bigFileName, smallFileName, recentOrgFName, recentSmallFName, recentBigFName);
        }


     
    }
}
