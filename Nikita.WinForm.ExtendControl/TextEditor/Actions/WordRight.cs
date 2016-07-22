// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.WordRight
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class WordRight : CaretRight
  {
    public override void Execute(TextArea textArea)
    {
      LineSegment lineSegment = textArea.Document.GetLineSegment(textArea.Caret.Position.Y);
      Point position = textArea.Caret.Position;
      Point point;
      if (textArea.Caret.Column >= lineSegment.Length)
      {
        point = new Point(0, textArea.Caret.Line + 1);
      }
      else
      {
        int nextWordStart = TextUtilities.FindNextWordStart(textArea.Document, textArea.Caret.Offset);
        point = textArea.Document.OffsetToPosition(nextWordStart);
      }
      foreach (FoldMarker foldMarker in textArea.Document.FoldingManager.GetFoldingsFromPosition(point.Y, point.X))
      {
        if (foldMarker.IsFolded)
        {
          point = position.X != foldMarker.StartColumn || position.Y != foldMarker.StartLine ? new Point(foldMarker.StartColumn, foldMarker.StartLine) : new Point(foldMarker.EndColumn, foldMarker.EndLine);
          break;
        }
      }
      textArea.Caret.Position = point;
      textArea.SetDesiredColumn();
    }
  }
}
