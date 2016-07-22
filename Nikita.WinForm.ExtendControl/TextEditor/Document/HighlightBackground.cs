// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.HighlightBackground
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;
using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class HighlightBackground : HighlightColor
  {
    private Image backgroundImage;

    public Image BackgroundImage
    {
      get
      {
        return this.backgroundImage;
      }
    }

    public HighlightBackground(XmlElement el)
      : base(el)
    {
      if (el.Attributes["image"] == null)
        return;
      this.backgroundImage = (Image) new Bitmap(el.Attributes["image"].InnerText);
    }

    public HighlightBackground(Color color, Color backgroundcolor, bool bold, bool italic)
      : base(color, backgroundcolor, bold, italic)
    {
    }

    public HighlightBackground(string systemColor, string systemBackgroundColor, bool bold, bool italic)
      : base(systemColor, systemBackgroundColor, bold, italic)
    {
    }
  }
}
