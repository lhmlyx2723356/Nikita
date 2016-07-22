// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.WordBackspace
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class WordBackspace : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      textArea.BeginUpdate();
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        textArea.SelectionManager.RemoveSelectedText();
        textArea.ScrollToCaret();
      }
      LineSegment segmentForOffset = textArea.Document.GetLineSegmentForOffset(textArea.Caret.Offset);
      if (textArea.Caret.Offset > segmentForOffset.Offset)
      {
        int prevWordStart = TextUtilities.FindPrevWordStart(textArea.Document, textArea.Caret.Offset);
        if (prevWordStart < textArea.Caret.Offset)
        {
          textArea.Document.Remove(prevWordStart, textArea.Caret.Offset - prevWordStart);
          textArea.Caret.Position = textArea.Document.OffsetToPosition(prevWordStart);
        }
      }
      if (textArea.Caret.Offset == segmentForOffset.Offset)
      {
        int lineNumberForOffset = textArea.Document.GetLineNumberForOffset(textArea.Caret.Offset);
        if (lineNumberForOffset > 0)
        {
          LineSegment lineSegment = textArea.Document.GetLineSegment(lineNumberForOffset - 1);
          int offset = lineSegment.Offset + lineSegment.Length;
          int length = textArea.Caret.Offset - offset;
          textArea.Document.Remove(offset, length);
          textArea.Caret.Position = textArea.Document.OffsetToPosition(offset);
        }
      }
      textArea.SetDesiredColumn();
      textArea.EndUpdate();
      textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.PositionToEnd, new Point(0, textArea.Document.GetLineNumberForOffset(textArea.Caret.Offset))));
      textArea.Document.CommitUpdate();
    }
  }
}
