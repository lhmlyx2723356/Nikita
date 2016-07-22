// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.DrawableLine
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
  public class DrawableLine
  {
    private static StringFormat sf = (StringFormat) StringFormat.GenericTypographic.Clone();
    private List<DrawableLine.SimpleTextWord> words = new List<DrawableLine.SimpleTextWord>();
    private SizeF spaceSize;
    private Font monospacedFont;
    private Font boldMonospacedFont;

    public int LineLength
    {
      get
      {
        int num = 0;
        foreach (DrawableLine.SimpleTextWord simpleTextWord in this.words)
          num += simpleTextWord.Word.Length;
        return num;
      }
    }

    public DrawableLine(IDocument document, LineSegment line, Font monospacedFont, Font boldMonospacedFont)
    {
      this.monospacedFont = monospacedFont;
      this.boldMonospacedFont = boldMonospacedFont;
      if (line.Words != null)
      {
        foreach (TextWord textWord in line.Words)
        {
          if (textWord.Type == TextWordType.Space)
            this.words.Add(DrawableLine.SimpleTextWord.Space);
          else if (textWord.Type == TextWordType.Tab)
            this.words.Add(DrawableLine.SimpleTextWord.Tab);
          else
            this.words.Add(new DrawableLine.SimpleTextWord(TextWordType.Word, textWord.Word, textWord.Font.Bold, textWord.Color));
        }
      }
      else
        this.words.Add(new DrawableLine.SimpleTextWord(TextWordType.Word, document.GetText((ISegment) line), false, Color.Black));
    }

    public void SetBold(int startIndex, int endIndex, bool bold)
    {
      if (startIndex < 0)
        throw new ArgumentException("startIndex must be >= 0");
      if (startIndex > endIndex)
        throw new ArgumentException("startIndex must be <= endIndex");
      if (startIndex == endIndex)
        return;
      int num1 = 0;
      for (int index = 0; index < this.words.Count; ++index)
      {
        DrawableLine.SimpleTextWord simpleTextWord1 = this.words[index];
        if (num1 >= endIndex)
          break;
        int num2 = num1 + simpleTextWord1.Word.Length;
        if (startIndex <= num1 && endIndex >= num2)
          simpleTextWord1.Bold = bold;
        else if (startIndex <= num1)
        {
          int num3 = endIndex - num1;
          DrawableLine.SimpleTextWord simpleTextWord2 = new DrawableLine.SimpleTextWord(simpleTextWord1.Type, simpleTextWord1.Word.Substring(num3), simpleTextWord1.Bold, simpleTextWord1.Color);
          this.words.Insert(index + 1, simpleTextWord2);
          simpleTextWord1.Bold = bold;
          simpleTextWord1.Word = simpleTextWord1.Word.Substring(0, num3);
        }
        else if (startIndex < num2)
        {
          int num3 = startIndex - num1;
          DrawableLine.SimpleTextWord simpleTextWord2 = new DrawableLine.SimpleTextWord(simpleTextWord1.Type, simpleTextWord1.Word.Substring(num3), simpleTextWord1.Bold, simpleTextWord1.Color);
          this.words.Insert(index + 1, simpleTextWord2);
          simpleTextWord1.Word = simpleTextWord1.Word.Substring(0, num3);
        }
        num1 = num2;
      }
    }

    public static float DrawDocumentWord(Graphics g, string word, PointF position, Font font, Color foreColor)
    {
      if (word == null || word.Length == 0)
        return 0.0f;
      SizeF sizeF = g.MeasureString(word, font, 32768, DrawableLine.sf);
      g.DrawString(word, font, BrushRegistry.GetBrush(foreColor), position, DrawableLine.sf);
      return sizeF.Width;
    }

    public SizeF GetSpaceSize(Graphics g)
    {
      if (this.spaceSize.IsEmpty)
        this.spaceSize = g.MeasureString("-", this.boldMonospacedFont, new PointF(0.0f, 0.0f), DrawableLine.sf);
      return this.spaceSize;
    }

    public void DrawLine(Graphics g, ref float xPos, float xOffset, float yPos)
    {
      SizeF spaceSize = this.GetSpaceSize(g);
      foreach (DrawableLine.SimpleTextWord simpleTextWord in this.words)
      {
        switch (simpleTextWord.Type)
        {
          case TextWordType.Word:
            xPos += DrawableLine.DrawDocumentWord(g, simpleTextWord.Word, new PointF(xPos + xOffset, yPos), simpleTextWord.Bold ? this.boldMonospacedFont : this.monospacedFont, simpleTextWord.Color);
            continue;
          case TextWordType.Space:
            xPos += spaceSize.Width;
            continue;
          case TextWordType.Tab:
            float num = spaceSize.Width * 4f;
            xPos += num;
            xPos = (float) (int) (((double) xPos + 2.0) / (double) num) * num;
            continue;
          default:
            continue;
        }
      }
    }

    public float MeasureWidth(Graphics g, float xPos)
    {
      SizeF spaceSize = this.GetSpaceSize(g);
      foreach (DrawableLine.SimpleTextWord simpleTextWord in this.words)
      {
        switch (simpleTextWord.Type)
        {
          case TextWordType.Word:
            if (simpleTextWord.Word != null && simpleTextWord.Word.Length > 0)
            {
              xPos += g.MeasureString(simpleTextWord.Word, simpleTextWord.Bold ? this.boldMonospacedFont : this.monospacedFont, 32768, DrawableLine.sf).Width;
              continue;
            }
            continue;
          case TextWordType.Space:
            xPos += spaceSize.Width;
            continue;
          case TextWordType.Tab:
            float num = spaceSize.Width * 4f;
            xPos += num;
            xPos = (float) (int) (((double) xPos + 2.0) / (double) num) * num;
            continue;
          default:
            continue;
        }
      }
      return xPos;
    }

    private class SimpleTextWord
    {
      internal static readonly DrawableLine.SimpleTextWord Space = new DrawableLine.SimpleTextWord(TextWordType.Space, " ", false, Color.Black);
      internal static readonly DrawableLine.SimpleTextWord Tab = new DrawableLine.SimpleTextWord(TextWordType.Tab, "\t", false, Color.Black);
      internal TextWordType Type;
      internal string Word;
      internal bool Bold;
      internal Color Color;

      public SimpleTextWord(TextWordType Type, string Word, bool Bold, Color Color)
      {
        this.Type = Type;
        this.Word = Word;
        this.Bold = Bold;
        this.Color = Color;
      }
    }
  }
}
