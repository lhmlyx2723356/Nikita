// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.Return
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class Return : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      if (textArea.Document.ReadOnly)
        return;
      textArea.BeginUpdate();
      try
      {
        if (textArea.HandleKeyPress('\n'))
          return;
        textArea.InsertString(Environment.NewLine);
        int line = textArea.Caret.Line;
        textArea.Caret.Column = textArea.Document.FormattingStrategy.FormatLine(textArea, line, textArea.Caret.Offset, '\n');
        textArea.SetDesiredColumn();
        textArea.Document.UpdateQueue.Clear();
        textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.PositionToEnd, new Point(0, line - 1)));
      }
      finally
      {
        textArea.EndUpdate();
      }
    }
  }
}
