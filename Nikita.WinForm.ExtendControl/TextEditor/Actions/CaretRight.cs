// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.CaretRight
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Collections.Generic;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class CaretRight : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      LineSegment lineSegment = textArea.Document.GetLineSegment(textArea.Caret.Line);
      Point position = textArea.Caret.Position;
      List<FoldMarker> foldingsWithStart = textArea.Document.FoldingManager.GetFoldedFoldingsWithStart(position.Y);
      FoldMarker foldMarker1 = (FoldMarker) null;
      foreach (FoldMarker foldMarker2 in foldingsWithStart)
      {
        if (foldMarker2.StartColumn == position.X)
        {
          foldMarker1 = foldMarker2;
          break;
        }
      }
      if (foldMarker1 != null)
      {
        position.Y = foldMarker1.EndLine;
        position.X = foldMarker1.EndColumn;
      }
      else if (position.X < lineSegment.Length || textArea.TextEditorProperties.AllowCaretBeyondEOL)
        ++position.X;
      else if (position.Y + 1 < textArea.Document.TotalNumberOfLines)
      {
        ++position.Y;
        position.X = 0;
      }
      textArea.Caret.Position = position;
      textArea.SetDesiredColumn();
    }
  }
}
