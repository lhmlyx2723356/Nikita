// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Highlight
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
  public class Highlight
  {
    private Point openBrace;
    private Point closeBrace;

    public Point OpenBrace
    {
      get
      {
        return this.openBrace;
      }
      set
      {
        this.openBrace = value;
      }
    }

    public Point CloseBrace
    {
      get
      {
        return this.closeBrace;
      }
      set
      {
        this.closeBrace = value;
      }
    }

    public Highlight(Point openBrace, Point closeBrace)
    {
      this.openBrace = openBrace;
      this.closeBrace = closeBrace;
    }
  }
}
