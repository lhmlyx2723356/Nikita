// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.TextWord
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class TextWord
  {
    private static TextWord spaceWord = (TextWord) new TextWord.SpaceTextWord();
    private static TextWord tabWord = (TextWord) new TextWord.TabTextWord();
    private HighlightColor color;
    private LineSegment line;
    private IDocument document;
    private int offset;
    private int length;
    public bool hasDefaultColor;

    public static TextWord Space
    {
      get
      {
        return TextWord.spaceWord;
      }
    }

    public static TextWord Tab
    {
      get
      {
        return TextWord.tabWord;
      }
    }

    public int Offset
    {
      get
      {
        return this.offset;
      }
    }

    public int Length
    {
      get
      {
        return this.length;
      }
    }

    public bool HasDefaultColor
    {
      get
      {
        return this.hasDefaultColor;
      }
    }

    public virtual TextWordType Type
    {
      get
      {
        return TextWordType.Word;
      }
    }

    public string Word
    {
      get
      {
        if (this.document == null)
          return string.Empty;
        return this.document.GetText(this.line.Offset + this.offset, this.length);
      }
    }

    public virtual Font Font
    {
      get
      {
        return this.color.Font;
      }
    }

    public Color Color
    {
      get
      {
        return this.color.Color;
      }
    }

    public HighlightColor SyntaxColor
    {
      get
      {
        return this.color;
      }
      set
      {
        this.color = value;
      }
    }

    public virtual bool IsWhiteSpace
    {
      get
      {
        return false;
      }
    }

    protected TextWord()
    {
    }

    public TextWord(IDocument document, LineSegment line, int offset, int length, HighlightColor color, bool hasDefaultColor)
    {
      this.document = document;
      this.line = line;
      this.offset = offset;
      this.length = length;
      this.color = color;
      this.hasDefaultColor = hasDefaultColor;
    }

    public override string ToString()
    {
      return "[TextWord: Word = " + (object) this.Word + ", Font = " + (string) (object) this.Font + ", Color = " + (string) (object) this.Color + "]";
    }

    public sealed class SpaceTextWord : TextWord
    {
      public override Font Font
      {
        get
        {
          return (Font) null;
        }
      }

      public override TextWordType Type
      {
        get
        {
          return TextWordType.Space;
        }
      }

      public override bool IsWhiteSpace
      {
        get
        {
          return true;
        }
      }

      public SpaceTextWord()
      {
        this.length = 1;
      }

      public SpaceTextWord(HighlightColor color)
      {
        this.length = 1;
        this.SyntaxColor = color;
      }
    }

    public sealed class TabTextWord : TextWord
    {
      public override Font Font
      {
        get
        {
          return (Font) null;
        }
      }

      public override TextWordType Type
      {
        get
        {
          return TextWordType.Tab;
        }
      }

      public override bool IsWhiteSpace
      {
        get
        {
          return true;
        }
      }

      public TabTextWord()
      {
        this.length = 1;
      }

      public TabTextWord(HighlightColor color)
      {
        this.length = 1;
        this.SyntaxColor = color;
      }
    }
  }
}
