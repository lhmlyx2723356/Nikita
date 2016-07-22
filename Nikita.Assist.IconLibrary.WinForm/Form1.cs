// Code are under MIT License
// http://ciconlibrary.codeplex.com/license
// Copyright (c) 2014 Jonathan Magnan. All rights reserved.
// http://www.zzzportal.com
// 
// All icons are licensed under a Creative Commons Attribution 3.0 License.
// http://creativecommons.org/licenses/by/3.0/us/
// Copyright 2009-2013 FatCow Web Hosting. All rights reserved.
// http://www.fatcow.com/free-icons

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//using Icon = Z.IconLibrary.FarmFresh32.Icon;
 using Icon = Z.IconLibrary.Fugue.Icon;
//using Icon = a2.Icon;

namespace Nikita.Assist.IconLibrary.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            uiIcon.DataSource = Enum.GetValues(typeof (Icon));

            // SET static icon
            //uiImage16.Image = IconLibrary.FarmFresh.Icon.AcceptButton.GetImage16();
            //uiImage32.Image = IconLibrary.FarmFresh.Icon.AcceptButton.GetImage32();
            //uiIcon16.Image = IconLibrary.FarmFresh.Icon.AcceptButton.GetIcon16().ToBitmap();
            //uiIcon32.Image = IconLibrary.FarmFresh.Icon.AcceptButton.GetIcon32().ToBitmap();
            //uiBitmap16.Image = IconLibrary.FarmFresh.Icon.AcceptButton.GetBitmap16();
            //uiBitmap32.Image = IconLibrary.FarmFresh.Icon.AcceptButton.GetBitmap32();
            //using (Stream stream = IconLibrary.FarmFresh.Icon.AcceptButton.GetStream16())
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}
            //using (Stream stream = IconLibrary.FarmFresh.Icon.AcceptButton.GetStream32())
            //{
            //    uiStream32.Image = new Bitmap(stream);
            //}

            //uiImage16.Image = IconLibrary.FarmFresh.IconExtensions.GetImage16(IconLibrary.FarmFresh.Icon.AcceptButton);
            //uiImage32.Image = IconLibrary.FarmFresh.IconExtensions.GetImage16(IconLibrary.FarmFresh.Icon.AcceptButton);
            //uiIcon16.Image = IconLibrary.FarmFresh.IconExtensions.GetIcon16(IconLibrary.FarmFresh.Icon.AcceptButton).ToBitmap();
            //uiIcon32.Image = IconLibrary.FarmFresh.IconExtensions.GetIcon32(IconLibrary.FarmFresh.Icon.AcceptButton).ToBitmap();
            //uiBitmap16.Image = IconLibrary.FarmFresh.IconExtensions.GetBitmap16(IconLibrary.FarmFresh.Icon.AcceptButton);
            //uiBitmap32.Image = IconLibrary.FarmFresh.IconExtensions.GetBitmap32(IconLibrary.FarmFresh.Icon.AcceptButton);
            //using (Stream stream = IconLibrary.FarmFresh.IconExtensions.GetStream16(IconLibrary.FarmFresh.Icon.AcceptButton))
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}
            //using (Stream stream = IconLibrary.FarmFresh.IconExtensions.GetStream32(IconLibrary.FarmFresh.Icon.AcceptButton))
            //{
            //    uiStream32.Image = new Bitmap(stream);
            //}

            //uiImage16.Image = IconLibrary.FarmFresh16.Icon.AcceptButton.GetImage();
            //uiIcon16.Image = IconLibrary.FarmFresh16.Icon.AcceptButton.GetIcon().ToBitmap();
            //uiBitmap16.Image = IconLibrary.FarmFresh16.Icon.AcceptButton.GetBitmap();
            //using (Stream stream = IconLibrary.FarmFresh16.Icon.AcceptButton.GetStream())
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}

            //uiImage16.Image = IconLibrary.FarmFresh16.IconExtensions.GetImage(IconLibrary.FarmFresh16.Icon.AcceptButton);
            //uiIcon16.Image = IconLibrary.FarmFresh16.IconExtensions.GetIcon(IconLibrary.FarmFresh16.Icon.AcceptButton).ToBitmap();
            //uiBitmap16.Image = IconLibrary.FarmFresh16.IconExtensions.GetBitmap(IconLibrary.FarmFresh16.Icon.AcceptButton);
            //using (Stream stream = IconLibrary.FarmFresh16.IconExtensions.GetStream(IconLibrary.FarmFresh16.Icon.AcceptButton))
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}

            //uiImage32.Image = IconLibrary.FarmFresh32.Icon.AcceptButton.GetImage();
            //uiIcon32.Image = IconLibrary.FarmFresh32.Icon.AcceptButton.GetIcon().ToBitmap();
            //uiBitmap32.Image = IconLibrary.FarmFresh32.Icon.AcceptButton.GetBitmap();
            //using (Stream stream = IconLibrary.FarmFresh32.Icon.AcceptButton.GetStream())
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}

            //uiImage32.Image = IconLibrary.FarmFresh32.IconExtensions.GetImage(IconLibrary.FarmFresh32.Icon.AcceptButton);
            //uiIcon32.Image = IconLibrary.FarmFresh32.IconExtensions.GetIcon(IconLibrary.FarmFresh32.Icon.AcceptButton).ToBitmap();
            //uiBitmap32.Image = IconLibrary.FarmFresh32.IconExtensions.GetBitmap(IconLibrary.FarmFresh32.Icon.AcceptButton);
            //using (Stream stream = IconLibrary.FarmFresh32.IconExtensions.GetStream(IconLibrary.FarmFresh32.Icon.AcceptButton))
            //{
            //    uiStream32.Image = new Bitmap(stream);
            //}

            uiImage16.Image = Z.IconLibrary.Fugue.Icon.Abacus.GetImage();
            uiIcon16.Image = Z.IconLibrary.Fugue.Icon.Abacus.GetIcon().ToBitmap();
            uiBitmap16.Image = Z.IconLibrary.Fugue.Icon.Abacus.GetBitmap();
            using (Stream stream = Z.IconLibrary.Fugue.Icon.Abacus.GetStream())
            {
                uiStream16.Image = new Bitmap(stream);
            }

            //uiImage16.Image = IconLibrary.Fugue.IconExtensions.GetImage(IconLibrary.Fugue.Icon.Abacus);
            //uiIcon16.Image = IconLibrary.Fugue.IconExtensions.GetIcon(IconLibrary.Fugue.Icon.Abacus).ToBitmap();
            //uiBitmap16.Image = IconLibrary.Fugue.IconExtensions.GetBitmap(IconLibrary.Fugue.Icon.Abacus);
            //using (Stream stream = IconLibrary.Fugue.IconExtensions.GetStream(IconLibrary.Fugue.Icon.Abacus))
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}

            //uiImage16.Image = IconLibrary.Silk.Icon.Accept.GetImage();
            //uiIcon16.Image = IconLibrary.Silk.Icon.Accept.GetIcon().ToBitmap();
            //uiBitmap16.Image = IconLibrary.Silk.Icon.Accept.GetBitmap();
            //using (Stream stream = IconLibrary.Silk.Icon.Accept.GetStream())
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}

            //uiImage16.Image = a2.IconExtensions.GetImage(a2.Icon.Ae);
            //uiIcon16.Image = a2.IconExtensions.GetIcon(a2.Icon.Ae).ToBitmap();
            //uiBitmap16.Image = a2.IconExtensions.GetBitmap(a2.Icon.Ae);
            //using (Stream stream = a2.IconExtensions.GetStream(a2.Icon.Ae))
            //{
            //    uiStream16.Image = new Bitmap(stream);
            //}
        }

        private void uiIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dynamicIcon = (Icon) Enum.Parse(typeof (Icon), uiIcon.SelectedValue.ToString());

            //if (dynamicIcon != Z.IconLibrary.FarmFresh.Icon.None)
            //{
            //    uiDynamicImage16.Image = dynamicIcon.GetImage16();
            //    uiDynamicImage32.Image = dynamicIcon.GetImage32();
            //    uiDynamicIcon16.Image = dynamicIcon.GetIcon16().ToBitmap();
            //    uiDynamicIcon32.Image = dynamicIcon.GetIcon32().ToBitmap();
            //    uiDynamicBitmap16.Image = dynamicIcon.GetBitmap16();
            //    uiDynamicBitmap32.Image = dynamicIcon.GetBitmap32();
            //    using (Stream stream = dynamicIcon.GetStream16())
            //    {
            //        uiDynamicStream16.Image = new Bitmap(stream);
            //    }
            //    using (Stream stream = dynamicIcon.GetStream32())
            //    {
            //        uiDynamicStream32.Image = new Bitmap(stream);
            //    }
            //}

            //if (dynamicIcon != Z.IconLibrary.FarmFresh.Icon.None)
            //{
            //    uiDynamicImage16.Image = IconLibrary.FarmFresh.IconExtensions.GetImage16(dynamicIcon);
            //    uiDynamicImage32.Image = IconLibrary.FarmFresh.IconExtensions.GetImage32(dynamicIcon);
            //    uiDynamicIcon16.Image = IconLibrary.FarmFresh.IconExtensions.GetIcon16(dynamicIcon).ToBitmap();
            //    uiDynamicIcon32.Image = IconLibrary.FarmFresh.IconExtensions.GetIcon32(dynamicIcon).ToBitmap();
            //    uiDynamicBitmap16.Image = IconLibrary.FarmFresh.IconExtensions.GetBitmap16(dynamicIcon);
            //    uiDynamicBitmap32.Image = IconLibrary.FarmFresh.IconExtensions.GetBitmap32(dynamicIcon);
            //    using (Stream stream = IconLibrary.FarmFresh.IconExtensions.GetStream16(dynamicIcon))
            //    {
            //        uiDynamicStream16.Image = new Bitmap(stream);
            //    }
            //    using (Stream stream = IconLibrary.FarmFresh.IconExtensions.GetStream32(dynamicIcon))
            //    {
            //        uiDynamicStream32.Image = new Bitmap(stream);
            //    }
            //}

            //if (dynamicIcon != Z.IconLibrary.FarmFresh16.Icon.None)
            //{
            //    uiDynamicImage16.Image = dynamicIcon.GetImage();
            //    uiDynamicIcon16.Image = dynamicIcon.GetIcon().ToBitmap();
            //    uiDynamicBitmap16.Image = dynamicIcon.GetBitmap();
            //    using (Stream stream = dynamicIcon.GetStream())
            //    {
            //        uiDynamicStream16.Image = new Bitmap(stream);
            //    }
            //}

            //if (dynamicIcon != Z.IconLibrary.FarmFresh16.Icon.None)
            //{
            //    uiDynamicImage16.Image = IconLibrary.FarmFresh16.IconExtensions.GetImage(dynamicIcon);
            //    uiDynamicIcon16.Image = IconLibrary.FarmFresh16.IconExtensions.GetIcon(dynamicIcon).ToBitmap();
            //    uiDynamicBitmap16.Image = IconLibrary.FarmFresh16.IconExtensions.GetBitmap(dynamicIcon);
            //    using (Stream stream = IconLibrary.FarmFresh16.IconExtensions.GetStream(dynamicIcon))
            //    {
            //        uiDynamicStream16.Image = new Bitmap(stream);
            //    }
            //}

            //if (dynamicIcon != Z.IconLibrary.FarmFresh32.Icon.None)
            //{
            //    uiDynamicImage32.Image = dynamicIcon.GetImage();
            //    uiDynamicIcon32.Image = dynamicIcon.GetIcon().ToBitmap();
            //    uiDynamicBitmap32.Image = dynamicIcon.GetBitmap();
            //    using (Stream stream = dynamicIcon.GetStream())
            //    {
            //        uiDynamicStream32.Image = new Bitmap(stream);
            //    }
            //}

            //if (dynamicIcon != Z.IconLibrary.FarmFresh32.Icon.None)
            //{
            //    uiDynamicImage32.Image = IconLibrary.FarmFresh32.IconExtensions.GetImage(dynamicIcon);
            //    uiDynamicIcon32.Image = IconLibrary.FarmFresh32.IconExtensions.GetIcon(dynamicIcon).ToBitmap();
            //    uiDynamicBitmap32.Image = IconLibrary.FarmFresh32.IconExtensions.GetBitmap(dynamicIcon);
            //    using (Stream stream = IconLibrary.FarmFresh32.IconExtensions.GetStream(dynamicIcon))
            //    {
            //        uiDynamicStream32.Image = new Bitmap(stream);
            //    }
            //}

            if (dynamicIcon != Z.IconLibrary.Fugue.Icon.None)
            {
                uiDynamicImage16.Image = dynamicIcon.GetImage();
                uiDynamicIcon16.Image = dynamicIcon.GetIcon().ToBitmap();
                uiDynamicBitmap16.Image = dynamicIcon.GetBitmap();
                using (Stream stream = dynamicIcon.GetStream())
                {
                    uiDynamicStream16.Image = new Bitmap(stream);
                }
            }

            //if (dynamicIcon != Z.IconLibrary.Fugue.Icon.None)
            //{
            //    uiDynamicImage16.Image = IconLibrary.Fugue.IconExtensions.GetImage(dynamicIcon);
            //    uiDynamicIcon16.Image = IconLibrary.Fugue.IconExtensions.GetIcon(dynamicIcon).ToBitmap();
            //    uiDynamicBitmap16.Image = IconLibrary.Fugue.IconExtensions.GetBitmap(dynamicIcon);
            //    using (Stream stream = IconLibrary.Fugue.IconExtensions.GetStream(dynamicIcon))
            //    {
            //        uiDynamicStream16.Image = new Bitmap(stream);
            //    }
            //}

            //if (dynamicIcon != Z.IconLibrary.Silk.Icon.None)
            //{
            //    uiDynamicImage16.Image = dynamicIcon.GetImage();
            //    uiDynamicIcon16.Image = dynamicIcon.GetIcon().ToBitmap();
            //    uiDynamicBitmap16.Image = dynamicIcon.GetBitmap();
            //    using (Stream stream = dynamicIcon.GetStream())
            //    {
            //        uiDynamicStream16.Image = new Bitmap(stream);
            //    }
            //}

            //if (dynamicIcon != a2.Icon.None)
            //{
            //    uiDynamicImage16.Image = a2.IconExtensions.GetImage(dynamicIcon);
            //    uiDynamicIcon16.Image = a2.IconExtensions.GetIcon(dynamicIcon).ToBitmap();
            //    uiDynamicBitmap16.Image = a2.IconExtensions.GetBitmap(dynamicIcon);
            //    using (Stream stream = a2.IconExtensions.GetStream(dynamicIcon))
            //    {
            //        uiDynamicStream16.Image = new Bitmap(stream);
            //    }
            //}
        }
    }
}