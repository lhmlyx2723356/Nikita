// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.TextMarker
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class TextMarker : AbstractSegment
  {
    private TextMarkerType textMarkerType;
    private Color color;
    private Color foreColor;
    private string toolTip;
    private bool overrideForeColor;

    public TextMarkerType TextMarkerType
    {
      get
      {
        return this.textMarkerType;
      }
    }

    public Color Color
    {
      get
      {
        return this.color;
      }
    }

    public Color ForeColor
    {
      get
      {
        return this.foreColor;
      }
    }

    public bool OverrideForeColor
    {
      get
      {
        return this.overrideForeColor;
      }
    }

    public string ToolTip
    {
      get
      {
        return this.toolTip;
      }
      set
      {
        this.toolTip = value;
      }
    }

    public TextMarker(int offset, int length, TextMarkerType textMarkerType)
      : this(offset, length, textMarkerType, Color.Red)
    {
    }

    public TextMarker(int offset, int length, TextMarkerType textMarkerType, Color color)
    {
      this.offset = offset;
      this.length = length;
      this.textMarkerType = textMarkerType;
      this.color = color;
    }

    public TextMarker(int offset, int length, TextMarkerType textMarkerType, Color color, Color foreColor)
    {
      this.offset = offset;
      this.length = length;
      this.textMarkerType = textMarkerType;
      this.color = color;
      this.foreColor = foreColor;
      this.overrideForeColor = true;
    }
  }
}
