// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.HighlightColor
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class HighlightColor
  {
    private Color backgroundcolor = Color.WhiteSmoke;
    private bool systemColor;
    private string systemColorName;
    private bool systemBgColor;
    private string systemBgColorName;
    private Color color;
    private bool bold;
    private bool italic;
    private bool hasForgeground;
    private bool hasBackground;

    public bool HasForgeground
    {
      get
      {
        return this.hasForgeground;
      }
    }

    public bool HasBackground
    {
      get
      {
        return this.hasBackground;
      }
    }

    public bool Bold
    {
      get
      {
        return this.bold;
      }
    }

    public bool Italic
    {
      get
      {
        return this.italic;
      }
    }

    public Color BackgroundColor
    {
      get
      {
        if (!this.systemBgColor)
          return this.backgroundcolor;
        return this.ParseColorString(this.systemBgColorName);
      }
    }

    public Color Color
    {
      get
      {
        if (!this.systemColor)
          return this.color;
        return this.ParseColorString(this.systemColorName);
      }
    }

    public Font Font
    {
      get
      {
        if (this.Bold)
        {
          if (!this.Italic)
            return FontContainer.BoldFont;
          return FontContainer.BoldItalicFont;
        }
        if (!this.Italic)
          return FontContainer.DefaultFont;
        return FontContainer.ItalicFont;
      }
    }

    public HighlightColor(XmlElement el)
    {
      if (el.Attributes["bold"] != null)
        this.bold = bool.Parse(el.Attributes["bold"].InnerText);
      if (el.Attributes["italic"] != null)
        this.italic = bool.Parse(el.Attributes["italic"].InnerText);
      if (el.Attributes["color"] != null)
      {
        string innerText = el.Attributes["color"].InnerText;
        if ((int) innerText[0] == 35)
          this.color = HighlightColor.ParseColor(innerText);
        else if (innerText.StartsWith("SystemColors."))
        {
          this.systemColor = true;
          this.systemColorName = innerText.Substring("SystemColors.".Length);
        }
        else
          this.color = (Color) this.Color.GetType().InvokeMember(innerText, BindingFlags.GetProperty, (Binder) null, (object) this.Color, new object[0]);
        this.hasForgeground = true;
      }
      else
        this.color = Color.Transparent;
      if (el.Attributes["bgcolor"] == null)
        return;
      string innerText1 = el.Attributes["bgcolor"].InnerText;
      if ((int) innerText1[0] == 35)
        this.backgroundcolor = HighlightColor.ParseColor(innerText1);
      else if (innerText1.StartsWith("SystemColors."))
      {
        this.systemBgColor = true;
        this.systemBgColorName = innerText1.Substring("SystemColors.".Length);
      }
      else
        this.backgroundcolor = (Color) this.Color.GetType().InvokeMember(innerText1, BindingFlags.GetProperty, (Binder) null, (object) this.Color, new object[0]);
      this.hasBackground = true;
    }

    public HighlightColor(XmlElement el, HighlightColor defaultColor)
    {
      this.bold = el.Attributes["bold"] == null ? defaultColor.Bold : bool.Parse(el.Attributes["bold"].InnerText);
      this.italic = el.Attributes["italic"] == null ? defaultColor.Italic : bool.Parse(el.Attributes["italic"].InnerText);
      if (el.Attributes["color"] != null)
      {
        string innerText = el.Attributes["color"].InnerText;
        if ((int) innerText[0] == 35)
          this.color = HighlightColor.ParseColor(innerText);
        else if (innerText.StartsWith("SystemColors."))
        {
          this.systemColor = true;
          this.systemColorName = innerText.Substring("SystemColors.".Length);
        }
        else
          this.color = (Color) this.Color.GetType().InvokeMember(innerText, BindingFlags.GetProperty, (Binder) null, (object) this.Color, new object[0]);
        this.hasForgeground = true;
      }
      else
        this.color = defaultColor.color;
      if (el.Attributes["bgcolor"] != null)
      {
        string innerText = el.Attributes["bgcolor"].InnerText;
        if ((int) innerText[0] == 35)
          this.backgroundcolor = HighlightColor.ParseColor(innerText);
        else if (innerText.StartsWith("SystemColors."))
        {
          this.systemBgColor = true;
          this.systemBgColorName = innerText.Substring("SystemColors.".Length);
        }
        else
          this.backgroundcolor = (Color) this.Color.GetType().InvokeMember(innerText, BindingFlags.GetProperty, (Binder) null, (object) this.Color, new object[0]);
        this.hasBackground = true;
      }
      else
        this.backgroundcolor = defaultColor.BackgroundColor;
    }

    public HighlightColor(Color color, bool bold, bool italic)
    {
      this.hasForgeground = true;
      this.color = color;
      this.bold = bold;
      this.italic = italic;
    }

    public HighlightColor(Color color, Color backgroundcolor, bool bold, bool italic)
    {
      this.hasForgeground = true;
      this.hasBackground = true;
      this.color = color;
      this.backgroundcolor = backgroundcolor;
      this.bold = bold;
      this.italic = italic;
    }

    public HighlightColor(string systemColor, string systemBackgroundColor, bool bold, bool italic)
    {
      this.hasForgeground = true;
      this.hasBackground = true;
      this.systemColor = true;
      this.systemColorName = systemColor;
      this.systemBgColor = true;
      this.systemBgColorName = systemBackgroundColor;
      this.bold = bold;
      this.italic = italic;
    }

    private Color ParseColorString(string colorName)
    {
      string[] strArray = colorName.Split('*');
      Color color = (Color) typeof (SystemColors).GetProperty(strArray[0], BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public).GetValue((object) null, (object[]) null);
      if (strArray.Length == 2)
      {
        double num = double.Parse(strArray[1]) / 100.0;
        color = Color.FromArgb((int) ((double) color.R * num), (int) ((double) color.G * num), (int) ((double) color.B * num));
      }
      return color;
    }

    private static Color ParseColor(string c)
    {
      int alpha = (int) byte.MaxValue;
      int num = 0;
      if (c.Length > 7)
      {
        num = 2;
        alpha = int.Parse(c.Substring(1, 2), NumberStyles.HexNumber);
      }
      int red = int.Parse(c.Substring(1 + num, 2), NumberStyles.HexNumber);
      int green = int.Parse(c.Substring(3 + num, 2), NumberStyles.HexNumber);
      int blue = int.Parse(c.Substring(5 + num, 2), NumberStyles.HexNumber);
      return Color.FromArgb(alpha, red, green, blue);
    }

    public override string ToString()
    {
      return "[HighlightColor: Bold = " +  (this.Bold ? 1 : 0) + ", Italic = " + (string) (object)   (this.Italic ? 1 : 0) + ", Color = " + (string) (object) this.Color + ", BackgroundColor = " + (string) (object) this.BackgroundColor + "]";
    }
  }
}
