// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.ToolTipRequestEventArgs
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
  public class ToolTipRequestEventArgs
  {
    private Point mousePosition;
    private Point logicalPosition;
    private bool inDocument;
    internal string toolTipText;

    public Point MousePosition
    {
      get
      {
        return this.mousePosition;
      }
    }

    public Point LogicalPosition
    {
      get
      {
        return this.logicalPosition;
      }
    }

    public bool InDocument
    {
      get
      {
        return this.inDocument;
      }
    }

    public bool ToolTipShown
    {
      get
      {
        return this.toolTipText != null;
      }
    }

    public ToolTipRequestEventArgs(Point mousePosition, Point logicalPosition, bool inDocument)
    {
      this.mousePosition = mousePosition;
      this.logicalPosition = logicalPosition;
      this.inDocument = inDocument;
    }

    public void ShowToolTip(string text)
    {
      this.toolTipText = text;
    }
  }
}
