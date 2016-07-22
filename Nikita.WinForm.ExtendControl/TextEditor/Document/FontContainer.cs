// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.FontContainer
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class FontContainer
  {
    private static Font defaultfont;
    private static Font boldfont;
    private static Font italicfont;
    private static Font bolditalicfont;

    public static Font BoldFont
    {
      get
      {
        return FontContainer.boldfont;
      }
    }

    public static Font ItalicFont
    {
      get
      {
        return FontContainer.italicfont;
      }
    }

    public static Font BoldItalicFont
    {
      get
      {
        return FontContainer.bolditalicfont;
      }
    }

    public static Font DefaultFont
    {
      get
      {
        return FontContainer.defaultfont;
      }
      set
      {
        FontContainer.defaultfont = value;
        FontContainer.boldfont = new Font(FontContainer.defaultfont, FontStyle.Bold);
        FontContainer.italicfont = new Font(FontContainer.defaultfont, FontStyle.Italic);
        FontContainer.bolditalicfont = new Font(FontContainer.defaultfont, FontStyle.Bold | FontStyle.Italic);
      }
    }

    static FontContainer()
    {
      FontContainer.DefaultFont = new Font("Courier New", 10f);
    }

    public static Font ParseFont(string font)
    {
      string[] strArray = font.Split(new char[2]
      {
        ',',
        '='
      });
      return new Font(strArray[1], float.Parse(strArray[3]));
    }
  }
}
