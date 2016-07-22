// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.DefaultFormattingStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class DefaultFormattingStrategy : IFormattingStrategy
  {
    protected string GetIndentation(TextArea textArea, int lineNumber)
    {
      if (lineNumber < 0 || lineNumber > textArea.Document.TotalNumberOfLines)
        throw new ArgumentOutOfRangeException("lineNumber");
      string lineAsString = TextUtilities.GetLineAsString(textArea.Document, lineNumber);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (char c in lineAsString)
      {
        if (char.IsWhiteSpace(c))
          stringBuilder.Append(c);
        else
          break;
      }
      return stringBuilder.ToString();
    }

    protected virtual int AutoIndentLine(TextArea textArea, int lineNumber)
    {
      string str = lineNumber != 0 ? this.GetIndentation(textArea, lineNumber - 1) : "";
      if (str.Length > 0)
      {
        string text = str + TextUtilities.GetLineAsString(textArea.Document, lineNumber).Trim();
        LineSegment lineSegment = textArea.Document.GetLineSegment(lineNumber);
        textArea.Document.Replace(lineSegment.Offset, lineSegment.Length, text);
      }
      return str.Length;
    }

    protected virtual int SmartIndentLine(TextArea textArea, int line)
    {
      return this.AutoIndentLine(textArea, line);
    }

    public virtual int FormatLine(TextArea textArea, int line, int cursorOffset, char ch)
    {
      if ((int) ch == 10)
        return this.IndentLine(textArea, line);
      return 0;
    }

    public int IndentLine(TextArea textArea, int line)
    {
      switch (textArea.Document.TextEditorProperties.IndentStyle)
      {
        case IndentStyle.Auto:
          return this.AutoIndentLine(textArea, line);
        case IndentStyle.Smart:
          return this.SmartIndentLine(textArea, line);
        default:
          return 0;
      }
    }

    public virtual void IndentLines(TextArea textArea, int begin, int end)
    {
      int x = 0;
      for (int line = begin; line <= end; ++line)
      {
        if (this.IndentLine(textArea, line) > 0)
          ++x;
      }
      if (x <= 0)
        return;
      textArea.Document.UndoStack.UndoLast(x);
    }

    public virtual int SearchBracketBackward(IDocument document, int offset, char openBracket, char closingBracket)
    {
      int num = -1;
      for (int offset1 = offset; offset1 > 0; --offset1)
      {
        char charAt = document.GetCharAt(offset1);
        if ((int) charAt == (int) openBracket)
        {
          ++num;
          if (num == 0)
            return offset1;
        }
        else if ((int) charAt == (int) closingBracket)
          --num;
        else if ((int) charAt == 34 || (int) charAt == 39 || (int) charAt == 47 && offset1 > 0 && ((int) document.GetCharAt(offset1 - 1) == 47 || (int) document.GetCharAt(offset1 - 1) == 42))
          break;
      }
      return -1;
    }

    public virtual int SearchBracketForward(IDocument document, int offset, char openBracket, char closingBracket)
    {
      int num = 1;
      for (int offset1 = offset; offset1 < document.TextLength; ++offset1)
      {
        char charAt = document.GetCharAt(offset1);
        if ((int) charAt == (int) openBracket)
          ++num;
        else if ((int) charAt == (int) closingBracket)
        {
          --num;
          if (num == 0)
            return offset1;
        }
        else if ((int) charAt != 34 && (int) charAt != 39)
        {
          if ((int) charAt == 47 && offset1 > 0)
          {
            if ((int) document.GetCharAt(offset1 - 1) == 47)
              break;
          }
          else if ((int) charAt == 42 && offset1 > 0 && (int) document.GetCharAt(offset1 - 1) == 47)
            break;
        }
        else
          break;
      }
      return -1;
    }
  }
}
