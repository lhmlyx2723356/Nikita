// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.Backspace
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class Backspace : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      if (textArea.Document.ReadOnly)
        return;
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        textArea.BeginUpdate();
        textArea.Caret.Position = textArea.SelectionManager.SelectionCollection[0].StartPosition;
        textArea.SelectionManager.RemoveSelectedText();
        textArea.ScrollToCaret();
        textArea.EndUpdate();
      }
      else
      {
        if (textArea.Caret.Offset <= 0)
          return;
        textArea.BeginUpdate();
        int lineNumberForOffset = textArea.Document.GetLineNumberForOffset(textArea.Caret.Offset);
        int offset1 = textArea.Document.GetLineSegment(lineNumberForOffset).Offset;
        if (offset1 == textArea.Caret.Offset)
        {
          LineSegment lineSegment = textArea.Document.GetLineSegment(lineNumberForOffset - 1);
          int totalNumberOfLines = textArea.Document.TotalNumberOfLines;
          int offset2 = lineSegment.Offset + lineSegment.Length;
          int length = lineSegment.Length;
          textArea.Document.Remove(offset2, offset1 - offset2);
          textArea.Caret.Position = new Point(length, lineNumberForOffset - 1);
          textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.PositionToEnd, new Point(0, lineNumberForOffset - 1)));
          textArea.EndUpdate();
        }
        else
        {
          int offset2 = textArea.Caret.Offset - 1;
          textArea.Caret.Position = textArea.Document.OffsetToPosition(offset2);
          textArea.Document.Remove(offset2, 1);
          textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.PositionToLineEnd, new Point(textArea.Caret.Offset - textArea.Document.GetLineSegment(lineNumberForOffset).Offset, lineNumberForOffset)));
          textArea.EndUpdate();
        }
      }
    }
  }
}
