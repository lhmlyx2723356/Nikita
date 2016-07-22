// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.CaretLeft
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Collections.Generic;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class CaretLeft : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      Point point = textArea.Caret.Position;
      List<FoldMarker> foldedFoldingsWithEnd = textArea.Document.FoldingManager.GetFoldedFoldingsWithEnd(point.Y);
      FoldMarker foldMarker1 = (FoldMarker) null;
      foreach (FoldMarker foldMarker2 in foldedFoldingsWithEnd)
      {
        if (foldMarker2.EndColumn == point.X)
        {
          foldMarker1 = foldMarker2;
          break;
        }
      }
      if (foldMarker1 != null)
      {
        point.Y = foldMarker1.StartLine;
        point.X = foldMarker1.StartColumn;
      }
      else if (point.X > 0)
        --point.X;
      else if (point.Y > 0)
        point = new Point(textArea.Document.GetLineSegment(point.Y - 1).Length, point.Y - 1);
      textArea.Caret.Position = point;
      textArea.SetDesiredColumn();
    }
  }
}
