// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.End
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Collections.Generic;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class End : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      Point point = textArea.Caret.Position;
      bool flag;
      do
      {
        LineSegment lineSegment = textArea.Document.GetLineSegment(point.Y);
        point.X = lineSegment.Length;
        List<FoldMarker> foldingsFromPosition = textArea.Document.FoldingManager.GetFoldingsFromPosition(point.Y, point.X);
        flag = false;
        foreach (FoldMarker foldMarker in foldingsFromPosition)
        {
          if (foldMarker.IsFolded)
          {
            point = new Point(foldMarker.EndColumn, foldMarker.EndLine);
            flag = true;
            break;
          }
        }
      }
      while (flag);
      if (!(point != textArea.Caret.Position))
        return;
      textArea.Caret.Position = point;
      textArea.SetDesiredColumn();
    }
  }
}
