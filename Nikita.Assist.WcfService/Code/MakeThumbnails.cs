using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nikita.Assist.WcfService
{
    /// <summary>
    /// MakeThumbnails 的摘要说明
    /// </summary>
    public class MakeThumbnails
    {
        /// <summary>
        /// 生成缩略图(最终图片固定大小,图片按比例缩小,并为缩略图加上边框,以jpg格式保存)
        /// </summary>
        /// <param name="sourceImg">原图片(物理路径)</param>
        /// <param name="toPath">缩略图存放地址(物理路径,带文件名)</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="backColor">如果图片按比例缩小后不能填充满缩略图,则使用此颜色填充(比如"#FFFFFF")</param>
        /// <param name="borderColor">边框颜色(比如"#999999")</param>
        public void MakePic(string sourceImg, string toPath, int width, int height, string backColor, string borderColor)
        {
            var originalImage = Image.FromFile(sourceImg);

            int towidth = width;
            int toheight = height;

            const int x = 0;
            const int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if (ow < towidth && oh < toheight)
            {
                towidth = ow;
                toheight = oh;
            }
            else
            {
                string mode;
                if (originalImage.Width / originalImage.Height >= width / height)
                {
                    mode = "W";
                }
                else
                {
                    mode = "H";
                }
                switch (mode)
                {
                    case "W"://指定宽，高按比例
                        toheight = originalImage.Height * width / originalImage.Width;
                        break;

                    case "H"://指定高，宽按比例
                        towidth = originalImage.Width * height / originalImage.Height;
                        break;
                }
            }

            //新建一个bmp图片
            Image bitmap = new Bitmap(width, height);

            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以指定颜色填充
            g.Clear(ColorTranslator.FromHtml(backColor));

            //在指定位置并且按指定大小绘制原图片的指定部分
            int top = (height - toheight) / 2;
            int left = (width - towidth) / 2;
            g.DrawImage(originalImage, new Rectangle(left, top, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

            Pen pen = new Pen(ColorTranslator.FromHtml(borderColor));
            g.DrawRectangle(pen, 0, 0, width - 1, height - 1);
            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(toPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
    }
}