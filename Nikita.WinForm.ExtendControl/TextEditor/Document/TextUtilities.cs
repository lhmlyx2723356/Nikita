// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.TextUtilities
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public sealed class TextUtilities
  {
    public static string LeadingWhiteSpaceToTabs(string line, int tabIndent)
    {
      StringBuilder stringBuilder = new StringBuilder(line.Length);
      int num = 0;
      int index;
      for (index = 0; index < line.Length; ++index)
      {
        if ((int) line[index] == 32)
        {
          ++num;
          if (num == tabIndent)
          {
            stringBuilder.Append('\t');
            num = 0;
          }
        }
        else if ((int) line[index] == 9)
        {
          stringBuilder.Append('\t');
          num = 0;
        }
        else
          break;
      }
      if (index < line.Length)
        stringBuilder.Append(line.Substring(index - num));
      return stringBuilder.ToString();
    }

    public static bool IsLetterDigitOrUnderscore(char c)
    {
      if (!char.IsLetterOrDigit(c))
        return (int) c == 95;
      return true;
    }

    public static string GetExpressionBeforeOffset(TextArea textArea, int initialOffset)
    {
      IDocument document = textArea.Document;
      int offset1 = initialOffset;
      while (offset1 - 1 > 0)
      {
        switch (document.GetCharAt(offset1 - 1))
        {
          case ']':
            offset1 = TextUtilities.SearchBracketBackward(document, offset1 - 2, '[', ']');
            continue;
          case '}':
          case '\n':
          case '\r':
            goto label_22;
          case '.':
            --offset1;
            continue;
          case '>':
            if ((int) document.GetCharAt(offset1 - 2) == 45)
            {
              offset1 -= 2;
              continue;
            }
            goto label_22;
          case '"':
            if (offset1 < initialOffset - 1)
              return (string) null;
            return "\"\"";
          case '\'':
            if (offset1 < initialOffset - 1)
              return (string) null;
            return "'a'";
          case ')':
            offset1 = TextUtilities.SearchBracketBackward(document, offset1 - 2, '(', ')');
            continue;
          default:
            if (char.IsWhiteSpace(document.GetCharAt(offset1 - 1)))
            {
              --offset1;
              continue;
            }
            int offset2 = offset1 - 1;
            if (TextUtilities.IsLetterDigitOrUnderscore(document.GetCharAt(offset2)))
            {
              while (offset2 > 0 && TextUtilities.IsLetterDigitOrUnderscore(document.GetCharAt(offset2 - 1)))
                --offset2;
              string str = document.GetText(offset2, offset1 - offset2).Trim();
              switch (str)
              {
                case "ref":
                case "out":
                case "in":
                case "return":
                case "throw":
                case "case":
                  goto label_22;
                default:
                  if (str.Length <= 0 || TextUtilities.IsLetterDigitOrUnderscore(str[0]))
                  {
                    offset1 = offset2;
                    continue;
                  }
                  goto label_22;
              }
            }
            else
              goto label_22;
        }
      }
label_22:
      int num = document.GetText(offset1, textArea.Caret.Offset - offset1).Trim().LastIndexOf('\n');
      if (num >= 0)
        offset1 += num + 1;
      return document.GetText(offset1, textArea.Caret.Offset - offset1).Trim();
    }

    public static TextUtilities.CharacterType GetCharacterType(char c)
    {
      if (TextUtilities.IsLetterDigitOrUnderscore(c))
        return TextUtilities.CharacterType.LetterDigitOrUnderscore;
      return char.IsWhiteSpace(c) ? TextUtilities.CharacterType.WhiteSpace : TextUtilities.CharacterType.Other;
    }

    public static int GetFirstNonWSChar(IDocument document, int offset)
    {
      while (offset < document.TextLength && char.IsWhiteSpace(document.GetCharAt(offset)))
        ++offset;
      return offset;
    }

    public static int FindWordEnd(IDocument document, int offset)
    {
      LineSegment segmentForOffset = document.GetLineSegmentForOffset(offset);
      int num = segmentForOffset.Offset + segmentForOffset.Length;
      while (offset < num && TextUtilities.IsLetterDigitOrUnderscore(document.GetCharAt(offset)))
        ++offset;
      return offset;
    }

    public static int FindWordStart(IDocument document, int offset)
    {
      LineSegment segmentForOffset = document.GetLineSegmentForOffset(offset);
      while (offset > segmentForOffset.Offset && !TextUtilities.IsLetterDigitOrUnderscore(document.GetCharAt(offset - 1)))
        --offset;
      return offset;
    }

    public static int FindNextWordStart(IDocument document, int offset)
    {
      LineSegment segmentForOffset = document.GetLineSegmentForOffset(offset);
      int num = segmentForOffset.Offset + segmentForOffset.Length;
      TextUtilities.CharacterType characterType = TextUtilities.GetCharacterType(document.GetCharAt(offset));
      while (offset < num && TextUtilities.GetCharacterType(document.GetCharAt(offset)) == characterType)
        ++offset;
      while (offset < num && TextUtilities.GetCharacterType(document.GetCharAt(offset)) == TextUtilities.CharacterType.WhiteSpace)
        ++offset;
      return offset;
    }

    public static int FindPrevWordStart(IDocument document, int offset)
    {
      if (offset > 0)
      {
        LineSegment segmentForOffset = document.GetLineSegmentForOffset(offset);
        TextUtilities.CharacterType characterType1 = TextUtilities.GetCharacterType(document.GetCharAt(offset - 1));
        while (offset > segmentForOffset.Offset && TextUtilities.GetCharacterType(document.GetCharAt(offset - 1)) == characterType1)
          --offset;
        if (characterType1 == TextUtilities.CharacterType.WhiteSpace && offset > segmentForOffset.Offset)
        {
          TextUtilities.CharacterType characterType2 = TextUtilities.GetCharacterType(document.GetCharAt(offset - 1));
          while (offset > segmentForOffset.Offset && TextUtilities.GetCharacterType(document.GetCharAt(offset - 1)) == characterType2)
            --offset;
        }
      }
      return offset;
    }

    public static string GetLineAsString(IDocument document, int lineNumber)
    {
      LineSegment lineSegment = document.GetLineSegment(lineNumber);
      return document.GetText(lineSegment.Offset, lineSegment.Length);
    }

    public static int SearchBracketBackward(IDocument document, int offset, char openBracket, char closingBracket)
    {
      return document.FormattingStrategy.SearchBracketBackward(document, offset, openBracket, closingBracket);
    }

    public static int SearchBracketForward(IDocument document, int offset, char openBracket, char closingBracket)
    {
      return document.FormattingStrategy.SearchBracketForward(document, offset, openBracket, closingBracket);
    }

    public static bool IsEmptyLine(IDocument document, int lineNumber)
    {
      return TextUtilities.IsEmptyLine(document, document.GetLineSegment(lineNumber));
    }

    public static bool IsEmptyLine(IDocument document, LineSegment line)
    {
      for (int offset = line.Offset; offset < line.Offset + line.Length; ++offset)
      {
        if (!char.IsWhiteSpace(document.GetCharAt(offset)))
          return false;
      }
      return true;
    }

    private static bool IsWordPart(char ch)
    {
      if (!TextUtilities.IsLetterDigitOrUnderscore(ch))
        return (int) ch == 46;
      return true;
    }

    public static string GetWordAt(IDocument document, int offset)
    {
      if (offset < 0 || offset >= document.TextLength - 1 || !TextUtilities.IsWordPart(document.GetCharAt(offset)))
        return string.Empty;
      int offset1 = offset;
      int num = offset;
      while (offset1 > 0 && TextUtilities.IsWordPart(document.GetCharAt(offset1 - 1)))
        --offset1;
      while (num < document.TextLength - 1 && TextUtilities.IsWordPart(document.GetCharAt(num + 1)))
        ++num;
      return document.GetText(offset1, num - offset1 + 1);
    }

    public enum CharacterType
    {
      LetterDigitOrUnderscore,
      WhiteSpace,
      Other,
    }
  }
}
