// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.LineSegment
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public sealed class LineSegment : AbstractSegment
  {
    private int delimiterLength;
    private List<TextWord> words;
    private Stack<Span> highlightSpanStack;

    public override int Length
    {
      get
      {
        return this.length - this.delimiterLength;
      }
      set
      {
        throw new NotSupportedException();
      }
    }

    public int TotalLength
    {
      get
      {
        return this.length;
      }
      set
      {
        this.length = value;
      }
    }

    public int DelimiterLength
    {
      get
      {
        return this.delimiterLength;
      }
      set
      {
        this.delimiterLength = value;
      }
    }

    public List<TextWord> Words
    {
      get
      {
        return this.words;
      }
      set
      {
        this.words = value;
      }
    }

    public Stack<Span> HighlightSpanStack
    {
      get
      {
        return this.highlightSpanStack;
      }
      set
      {
        this.highlightSpanStack = value;
      }
    }

    public LineSegment(int offset, int end, int delimiterLength)
    {
      this.offset = offset;
      this.delimiterLength = delimiterLength;
      this.TotalLength = end - offset + 1;
    }

    public LineSegment(int offset, int length)
    {
      this.offset = offset;
      this.length = length;
      this.delimiterLength = 0;
    }

    public TextWord GetWord(int column)
    {
      int num = 0;
      foreach (TextWord textWord in this.words)
      {
        if (column < num + textWord.Length)
          return textWord;
        num += textWord.Length;
      }
      return (TextWord) null;
    }

    public HighlightColor GetColorForPosition(int x)
    {
      if (this.Words != null)
      {
        int num = 0;
        foreach (TextWord textWord in this.Words)
        {
          if (x < num + textWord.Length)
            return textWord.SyntaxColor;
          num += textWord.Length;
        }
      }
      return new HighlightColor(Color.Black, false, false);
    }

    public override string ToString()
    {
      return "[LineSegment: Offset = " + (object) this.offset + ", Length = " + (string) (object) this.Length + ", TotalLength = " + (string) (object) this.TotalLength + ", DelimiterLength = " + (string) (object) this.delimiterLength + "]";
    }

    internal string GetRegString(char[] expr, int index, IDocument document)
    {
      int num = 0;
      StringBuilder stringBuilder1 = new StringBuilder();
      for (int index1 = 0; index1 < expr.Length && index + num < this.Length; ++num)
      {
        if ((int) expr[index1] == 64)
        {
          ++index1;
          switch (expr[index1])
          {
            case '!':
              StringBuilder stringBuilder2 = new StringBuilder();
              ++index1;
              while (index1 < expr.Length && (int) expr[index1] != 64)
                stringBuilder2.Append(expr[index1++]);
              break;
            case '@':
              stringBuilder1.Append(document.GetCharAt(this.Offset + index + num));
              break;
          }
        }
        else
        {
          if ((int) expr[index1] != (int) document.GetCharAt(this.Offset + index + num))
            return stringBuilder1.ToString();
          stringBuilder1.Append(document.GetCharAt(this.Offset + index + num));
        }
        ++index1;
      }
      return stringBuilder1.ToString();
    }

    internal bool MatchExpr(char[] expr, int index, IDocument document)
    {
      int index1 = 0;
      int num = 0;
      while (index1 < expr.Length)
      {
        if ((int) expr[index1] == 64)
        {
          ++index1;
          if (index1 < expr.Length)
          {
            switch (expr[index1])
            {
              case '!':
                StringBuilder stringBuilder1 = new StringBuilder();
                ++index1;
                while (index1 < expr.Length && (int) expr[index1] != 64)
                  stringBuilder1.Append(expr[index1++]);
                if (this.Offset + index + num + stringBuilder1.Length < document.TextLength)
                {
                  int index2 = 0;
                  while (index2 < stringBuilder1.Length && (int) document.GetCharAt(this.Offset + index + num + index2) == (int) stringBuilder1[index2])
                    ++index2;
                  if (index2 >= stringBuilder1.Length)
                    return false;
                  break;
                }
                break;
              case '-':
                StringBuilder stringBuilder2 = new StringBuilder();
                ++index1;
                while (index1 < expr.Length && (int) expr[index1] != 64)
                  stringBuilder2.Append(expr[index1++]);
                if (index - stringBuilder2.Length >= 0)
                {
                  int index2 = 0;
                  while (index2 < stringBuilder2.Length && (int) document.GetCharAt(this.Offset + index - stringBuilder2.Length + index2) == (int) stringBuilder2[index2])
                    ++index2;
                  if (index2 >= stringBuilder2.Length)
                    return false;
                  break;
                }
                break;
              case '@':
                if (index + num >= this.Length || 64 != (int) document.GetCharAt(this.Offset + index + num))
                  return false;
                break;
            }
          }
        }
        else if (index + num >= this.Length || (int) expr[index1] != (int) document.GetCharAt(this.Offset + index + num))
          return false;
        ++index1;
        ++num;
      }
      return true;
    }
  }
}
