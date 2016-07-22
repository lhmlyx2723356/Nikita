// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.IFormattingStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;

namespace Nikita.WinForm.ExtendControl.Document
{
  public interface IFormattingStrategy
  {
    int FormatLine(TextArea textArea, int line, int caretOffset, char charTyped);

    int IndentLine(TextArea textArea, int line);

    void IndentLines(TextArea textArea, int begin, int end);

    int SearchBracketBackward(IDocument document, int offset, char openBracket, char closingBracket);

    int SearchBracketForward(IDocument document, int offset, char openBracket, char closingBracket);
  }
}
