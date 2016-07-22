// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.WordLeft
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class WordLeft : CaretLeft
  {
    public override void Execute(TextArea textArea)
    {
      Point position = textArea.Caret.Position;
      if (textArea.Caret.Column == 0)
      {
        base.Execute(textArea);
      }
      else
      {
        textArea.Document.GetLineSegment(textArea.Caret.Position.Y);
        int prevWordStart = TextUtilities.FindPrevWordStart(textArea.Document, textArea.Caret.Offset);
        Point point = textArea.Document.OffsetToPosition(prevWordStart);
        foreach (FoldMarker foldMarker in textArea.Document.FoldingManager.GetFoldingsFromPosition(point.Y, point.X))
        {
          if (foldMarker.IsFolded)
          {
            point = position.X != foldMarker.EndColumn || position.Y != foldMarker.EndLine ? new Point(foldMarker.EndColumn, foldMarker.EndLine) : new Point(foldMarker.StartColumn, foldMarker.StartLine);
            break;
          }
        }
        textArea.Caret.Position = point;
        textArea.SetDesiredColumn();
      }
    }
  }
}
