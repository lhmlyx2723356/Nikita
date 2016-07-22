using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Core.Images
{
    /// <summary>图片帮助类
    ///
    /// </summary>
    public class ImageHelper
    {
        ///  <summary>显示远程图片
        ///
        ///  </summary>
        /// <returns></returns>
        /// 调用方法： this.pictureBox1.Image=GetBitmapFromHttp(url);
        public static Image GetBitmapFromHttp(string url)
        {
            WebClient client = new WebClient();
            Bitmap map = new Bitmap(client.OpenRead(url));
            Image img = map;
            return img;
        }

        public static Graphics GetGraphic(Image originImage, Bitmap newImage)
        {
            newImage.SetResolution(originImage.HorizontalResolution, originImage.VerticalResolution);
            var graphic = Graphics.FromImage(newImage);
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            return graphic;
        }

        /// <summary>
        /// 读取byte[]并转化为图片
        /// </summary>
        /// <param name="bytes">byte[]</param>
        /// <returns>Image</returns>
        public static Image GetImageByBytes(byte[] bytes)
        {
            Image photo;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Write(bytes, 0, bytes.Length);
                photo = Image.FromStream(ms, true);
            }

            return photo;
        }

        /// <summary>把本地路径下的图片转换为Byte[]格式
        ///
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <returns></returns>
        public static byte[] ImageToByte(string imagePath)
        {
            FileStream files = new FileStream(imagePath, FileMode.Open);
            byte[] imgByte = new byte[files.Length];
            files.Read(imgByte, 0, imgByte.Length);
            files.Close();
            files.Dispose();
            return imgByte;
        }

        /// <summary>显示远程图片
        ///
        /// </summary>
        /// <param name="urlImage">图片地址</param>
        /// <returns></returns>
        ///调用方法： this.pictureBox1.Image=ReadURLImageToStream(imgPath);
        public static Image ReadUrlImageToStream(string urlImage)
        {
            Uri uri = new Uri(urlImage);
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream str = resp.GetResponseStream();
            if (str != null)
            {
                Image img = Image.FromStream(str);
                return img;
            }
            return null;
        }

        /// <summary>生成缩略图
        ///
        /// </summary>
        /// <param name="originBitmap">原始图片</param>
        /// <param name="width">生成后的宽度</param>
        /// <param name="height">生成后的高度</param>
        /// <param name="directory">文件夹</param>
        /// <param name="filename">文件名称</param>
        /// <param name="extension">文件格式.jpg</param>
        /// 调用方法：     Bitmap bmp = (Bitmap)Image.FromFile(path);   SaveThumbnail(bmp, 120, 100, "文件夹地址", "文件名称", ".jpg");
        public static void SaveThumbnail(Bitmap originBitmap, int width, int height, string directory, string filename, string extension)
        {
            var physicalPath = directory + filename + extension;
            using (var newImage = new Bitmap(width, height))
            {
                using (var graphic = GetGraphic(originBitmap, newImage))
                {
                    graphic.DrawImage(originBitmap, 0, 0, width, height);
                    using (var encoderParameters = new EncoderParameters(1))
                    {
                        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                        newImage.Save(physicalPath,
                                    ImageCodecInfo.GetImageEncoders()
                                        .Where(x => x.FilenameExtension.Contains(extension.ToUpperInvariant()))
                                        .FirstOrDefault(),
                                    encoderParameters);
                    }
                }
            }
        }

        /// <summary>压缩文件
        ///
        /// </summary>
        /// <param name="byImage"></param>
        /// <param name="format"></param>
        /// <param name="targetLen"></param>
        /// <returns></returns>
        /// 使用方法：把某目录下的文件全部都压缩成指定大小
        /// static void Main(string[] args)
        /// {
        ///  var dir = @"C:\Users\Public\Pictures\Sample Pictures\";
        ///  var files = Directory.GetFiles(dir, "*.jpg");
        ///  foreach (var file in files)
        ///    {
        ///        var img = Image.FromFile(file);
        ///       var name = Path.GetFileNameWithoutExtension(file);
        ///        Console.WriteLine(name);
        ///          var by = File.ReadAllBytes(file);
        ///          by = Zip(by, ImageFormat.Jpeg,50);
        ///           File.WriteAllBytes(dir + "\\1\\" + name + "_1.jpg", by);
        ///          }
        ///      }
        public static byte[] Zip(byte[] byImage, ImageFormat format, long targetLen)
        {
            var ms = new MemoryStream(byImage);
            var img = Image.FromStream(ms);
            ms = Zip(img, ImageFormat.Jpeg, 50, byImage.Length);
            return ms.ToArray();
        }

        /// <summary>压缩图片至n Kb以下
        ///
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="format">图片格式</param>
        /// <param name="targetLen">压缩后大小</param>
        /// <param name="srcLen">原始大小</param>
        /// <returns>压缩后的图片内存流</returns>
        public static MemoryStream Zip(Image img, ImageFormat format, long targetLen, long srcLen = 0)
        {
            //设置允许大小偏差幅度 默认10kb
            const long nearlyLen = 10240;
            //返回内存流  如果参数中原图大小没有传递 则使用内存流读取
            var ms = new MemoryStream();
            if (0 == srcLen)
            {
                img.Save(ms, format);
                srcLen = ms.Length;
            }
            //单位 由Kb转为byte 若目标大小高于原图大小，则满足条件退出
            targetLen *= 1024;
            if (targetLen >= srcLen)
            {
                ms.SetLength(0);
                ms.Position = 0;
                img.Save(ms, format);
                return ms;
            }
            //获取目标大小最低值
            var exitLen = targetLen - nearlyLen;
            //初始化质量压缩参数 图像 内存流等
            var quality = (long)Math.Floor(100.00 * targetLen / srcLen);
            var parms = new EncoderParameters(1);
            //获取编码器信息
            var encoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo formatInfo = encoders.FirstOrDefault(icf => icf.FormatID == format.Guid);
            //使用二分法进行查找 最接近的质量参数
            long startQuality = quality;
            long endQuality = 100;
            quality = (startQuality + endQuality) / 2;
            while (true)
            {
                //设置质量
                parms.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                //清空内存流 然后保存图片
                ms.SetLength(0);
                ms.Position = 0;
                if (formatInfo != null) img.Save(ms, formatInfo, parms);

                //若压缩后大小低于目标大小，则满足条件退出
                if (ms.Length >= exitLen && ms.Length <= targetLen)
                {
                    break;
                }
                else if (startQuality >= endQuality) //区间相等无需再次计算
                {
                    break;
                }
                else if (ms.Length < exitLen) //压缩过小,起始质量右移
                {
                    startQuality = quality;
                }
                else //压缩过大 终止质量左移
                {
                    endQuality = quality;
                }
                //重新设置质量参数 如果计算出来的质量没有发生变化，则终止查找。这样是为了避免重复计算情况{start:16,end:18} 和 {start:16,endQuality:17}
                var newQuality = (startQuality + endQuality) / 2;
                if (newQuality == quality)
                {
                    break;
                }
                quality = newQuality;
            }
            return ms;
        }
    }
}