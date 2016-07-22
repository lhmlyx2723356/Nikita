// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.GotoMatchingBrace
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class GotoMatchingBrace : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      if (textArea.TextView.Highlight == null)
        return;
      Point point1 = new Point(textArea.TextView.Highlight.CloseBrace.X + 1, textArea.TextView.Highlight.CloseBrace.Y);
      Point point2 = new Point(textArea.TextView.Highlight.OpenBrace.X + 1, textArea.TextView.Highlight.OpenBrace.Y);
      textArea.Caret.Position = !(point1 == textArea.Caret.Position) ? (textArea.Document.TextEditorProperties.BracketMatchingStyle != BracketMatchingStyle.After ? new Point(point1.X - 1, point1.Y) : point1) : (textArea.Document.TextEditorProperties.BracketMatchingStyle != BracketMatchingStyle.After ? new Point(point2.X - 1, point2.Y) : point2);
      textArea.SetDesiredColumn();
    }
  }
}
