// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.BrushRegistry
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Nikita.WinForm.ExtendControl
{
  public class BrushRegistry
  {
    private static Hashtable brushes = new Hashtable();
    private static Hashtable pens = new Hashtable();
    private static Hashtable dotPens = new Hashtable();

    public static Brush GetBrush(Color color)
    {
      if (BrushRegistry.brushes.Contains((object) color))
        return BrushRegistry.brushes[(object) color] as Brush;
      Brush brush = (Brush) new SolidBrush(color);
      BrushRegistry.brushes.Add((object) color, (object) brush);
      return brush;
    }

    public static Pen GetPen(Color color)
    {
      if (BrushRegistry.pens.Contains((object) color))
        return BrushRegistry.pens[(object) color] as Pen;
      Pen pen = new Pen(color);
      BrushRegistry.pens.Add((object) color, (object) pen);
      return pen;
    }

    public static Pen GetDotPen(Color bgColor, Color fgColor)
    {
      bool flag = BrushRegistry.dotPens.Contains((object) bgColor);
      if (flag && ((Hashtable) BrushRegistry.dotPens[(object) bgColor]).Contains((object) fgColor))
        return ((Hashtable) BrushRegistry.dotPens[(object) bgColor])[(object) fgColor] as Pen;
      if (!flag)
        BrushRegistry.dotPens[(object) bgColor] = (object) new Hashtable();
      Pen pen = new Pen((Brush) new HatchBrush(HatchStyle.Percent50, bgColor, fgColor));
      ((Hashtable) BrushRegistry.dotPens[(object) bgColor])[(object) fgColor] = (object) pen;
      return pen;
    }
  }
}
