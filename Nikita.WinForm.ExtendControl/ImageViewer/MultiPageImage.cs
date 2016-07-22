using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Nikita.WinForm.ExtendControl
{
    public class MultiPageImage
    {
        private Bitmap bmp;

        private int currentPage = 0;

        private Bitmap image;

        private int rotation = 0;

        public MultiPageImage(Bitmap image)
        {
            this.Image = image;

            this.currentPage = 0;
        }

        public Bitmap Image
        {
            get { return bmp; }
            set
            {
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }

                image = value;

                if (bmp != null)
                {
                    bmp.Dispose();
                    bmp = null;
                }

                bmp = new Bitmap(image);
            }
        }

        public Bitmap Page
        {
            get
            {
                if (bmp == null)
                {
                    bmp = new Bitmap(image);
                }

                return bmp;
            }
        }

        public int Rotation
        {
            get { return rotation; }
        }

        public void Dispose()
        {
            if (this.Image != null)
            {
                this.image.Dispose();
                this.image = null;
            }

            if (this.bmp != null)
            {
                this.bmp.Dispose();
                this.bmp = null;
            }
        }

        public Bitmap GetBitmap(int pageNumber)
        {
            if (image == null)
            {
                return null;
            }

            if (currentPage != pageNumber)
            {
                int pages = image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                if (pages > pageNumber && pageNumber >= 0)
                {
                    currentPage = pageNumber;

                    image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, pageNumber);

                    if (bmp != null)
                    {
                        bmp.Dispose();
                        bmp = null;
                    }

                    bmp = new Bitmap(image);
                }
            }

            return bmp;
        }

        public void Rotate(int rotation)
        {
            if (rotation == 90 || rotation == 180 || rotation == 270 || rotation == 0)
            {
                this.rotation = rotation;

                if (this.rotation == 90) { bmp.RotateFlip(RotateFlipType.Rotate90FlipNone); }
                else if (this.rotation == 180) { bmp.RotateFlip(RotateFlipType.Rotate180FlipNone); }
                else if (this.rotation == 270) { bmp.RotateFlip(RotateFlipType.Rotate270FlipNone); }
            }
        }

        public void SetPage(int pageNumber)
        {
            if (image != null)
            {
                if (currentPage != pageNumber)
                {
                    int pages = image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                    if (pages > pageNumber && pageNumber >= 0)
                    {
                        currentPage = pageNumber;

                        image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, pageNumber);

                        if (bmp != null)
                        {
                            bmp.Dispose();
                            bmp = null;
                        }

                        bmp = new Bitmap(image);
                    }
                }
            }
        }
    }
}