// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.Delete
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class Delete : AbstractEditAction
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
        if (textArea.Caret.Offset >= textArea.Document.TextLength)
          return;
        textArea.BeginUpdate();
        int lineNumberForOffset = textArea.Document.GetLineNumberForOffset(textArea.Caret.Offset);
        LineSegment lineSegment1 = textArea.Document.GetLineSegment(lineNumberForOffset);
        if (lineSegment1.Offset + lineSegment1.Length == textArea.Caret.Offset)
        {
          if (lineNumberForOffset + 1 < textArea.Document.TotalNumberOfLines)
          {
            LineSegment lineSegment2 = textArea.Document.GetLineSegment(lineNumberForOffset + 1);
            textArea.Document.Remove(textArea.Caret.Offset, lineSegment2.Offset - textArea.Caret.Offset);
            textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.PositionToEnd, new Point(0, lineNumberForOffset)));
          }
        }
        else
          textArea.Document.Remove(textArea.Caret.Offset, 1);
        textArea.UpdateMatchingBracket();
        textArea.EndUpdate();
      }
    }
  }
}
