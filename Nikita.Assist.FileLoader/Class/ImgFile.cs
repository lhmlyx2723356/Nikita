using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public class ImgFile : ImageFile
    {
        public ImgFile()
        { 
            FileType = FileType.jpg;
        }

        public override void Open()
        {

            FrmImagePreview frmImgView = new FrmImagePreview(this.FilePath);
            frmImgView.ShowDialog();
        }


    }
}
