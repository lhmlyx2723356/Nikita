// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.BracketHighlightingSheme
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
  public class BracketHighlightingSheme
  {
    private char opentag;
    private char closingtag;

    public char OpenTag
    {
      get
      {
        return this.opentag;
      }
      set
      {
        this.opentag = value;
      }
    }

    public char ClosingTag
    {
      get
      {
        return this.closingtag;
      }
      set
      {
        this.closingtag = value;
      }
    }

    public BracketHighlightingSheme(char opentag, char closingtag)
    {
      this.opentag = opentag;
      this.closingtag = closingtag;
    }

    public Highlight GetHighlight(IDocument document, int offset)
    {
      int val2 = document.TextEditorProperties.BracketMatchingStyle != BracketMatchingStyle.After ? offset + 1 : offset;
      char charAt = document.GetCharAt(Math.Max(0, Math.Min(document.TextLength - 1, val2)));
      Point closeBrace = document.OffsetToPosition(offset);
      if ((int) charAt == (int) this.opentag)
      {
        if (offset < document.TextLength)
        {
          int offset1 = TextUtilities.SearchBracketForward(document, val2 + 1, this.opentag, this.closingtag);
          if (offset1 >= 0)
            return new Highlight(document.OffsetToPosition(offset1), closeBrace);
        }
      }
      else if ((int) charAt == (int) this.closingtag && offset > 0)
      {
        int offset1 = TextUtilities.SearchBracketBackward(document, val2 - 1, this.opentag, this.closingtag);
        if (offset1 >= 0)
          return new Highlight(document.OffsetToPosition(offset1), closeBrace);
      }
      return (Highlight) null;
    }
  }
}
