// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.DefaultHighlightingStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class DefaultHighlightingStrategy : IHighlightingStrategy
  {
    private List<HighlightRuleSet> rules = new List<HighlightRuleSet>();
    private Dictionary<string, HighlightColor> environmentColors = new Dictionary<string, HighlightColor>();
    private Dictionary<string, string> properties = new Dictionary<string, string>();
    private string name;
    private string[] extensions;
    private HighlightColor digitColor;
    private HighlightRuleSet defaultRuleSet;
    private LineSegment currentLine;
    private Stack<Span> currentSpanStack;
    private bool inSpan;
    private Span activeSpan;
    private HighlightRuleSet activeRuleSet;
    private int currentOffset;
    private int currentLength;

    public HighlightColor DigitColor
    {
      get
      {
        return this.digitColor;
      }
      set
      {
        this.digitColor = value;
      }
    }

    public Dictionary<string, string> Properties
    {
      get
      {
        return this.properties;
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }
    }

    public string[] Extensions
    {
      get
      {
        return this.extensions;
      }
      set
      {
        this.extensions = value;
      }
    }

    public List<HighlightRuleSet> Rules
    {
      get
      {
        return this.rules;
      }
    }

    public DefaultHighlightingStrategy()
      : this("Default")
    {
    }

    public DefaultHighlightingStrategy(string name)
    {
      this.name = name;
      this.digitColor = (HighlightColor) new HighlightBackground("WindowText", "Window", false, false);
      this.environmentColors["DefaultBackground"] = (HighlightColor) new HighlightBackground("WindowText", "Window", false, false);
      this.environmentColors["Selection"] = new HighlightColor("HighlightText", "Highlight", false, false);
      this.environmentColors["VRuler"] = new HighlightColor("ControlLight", "Window", false, false);
      this.environmentColors["InvalidLines"] = new HighlightColor(Color.Red, false, false);
      this.environmentColors["CaretMarker"] = new HighlightColor(Color.Yellow, false, false);
      this.environmentColors["LineNumbers"] = (HighlightColor) new HighlightBackground("ControlDark", "Window", false, false);
      this.environmentColors["FoldLine"] = new HighlightColor(Color.FromArgb(128, 128, 128), Color.Black, false, false);
      this.environmentColors["FoldMarker"] = new HighlightColor(Color.FromArgb(128, 128, 128), Color.White, false, false);
      this.environmentColors["SelectedFoldLine"] = new HighlightColor(Color.Black, false, false);
      this.environmentColors["EOLMarkers"] = new HighlightColor("ControlLight", "Window", false, false);
      this.environmentColors["SpaceMarkers"] = new HighlightColor("ControlLight", "Window", false, false);
      this.environmentColors["TabMarkers"] = new HighlightColor("ControlLight", "Window", false, false);
    }

    public HighlightRuleSet FindHighlightRuleSet(string name)
    {
      foreach (HighlightRuleSet highlightRuleSet in this.rules)
      {
        if (highlightRuleSet.Name == name)
          return highlightRuleSet;
      }
      return (HighlightRuleSet) null;
    }

    public void AddRuleSet(HighlightRuleSet aRuleSet)
    {
      this.rules.Add(aRuleSet);
    }

    internal void ResolveReferences()
    {
      this.ResolveRuleSetReferences();
      this.ResolveExternalReferences();
    }

    private void ResolveRuleSetReferences()
    {
      foreach (HighlightRuleSet highlightRuleSet1 in this.Rules)
      {
        if (highlightRuleSet1.Name == null)
          this.defaultRuleSet = highlightRuleSet1;
        foreach (Span span in highlightRuleSet1.Spans)
        {
          if (span.Rule != null)
          {
            bool flag = false;
            foreach (HighlightRuleSet highlightRuleSet2 in this.Rules)
            {
              if (highlightRuleSet2.Name == span.Rule)
              {
                flag = true;
                span.RuleSet = highlightRuleSet2;
                break;
              }
            }
            if (!flag)
            {
              int num = (int) MessageBox.Show("The RuleSet " + span.Rule + " could not be found in mode definition " + this.Name, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
              span.RuleSet = (HighlightRuleSet) null;
            }
          }
          else
            span.RuleSet = (HighlightRuleSet) null;
        }
      }
      if (this.defaultRuleSet != null)
        return;
      int num1 = (int) MessageBox.Show("No default RuleSet is defined for mode definition " + this.Name, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
    }

    private void ResolveExternalReferences()
    {
      foreach (HighlightRuleSet highlightRuleSet in this.Rules)
      {
        if (highlightRuleSet.Reference != null)
        {
          IHighlightingStrategy highlighter = HighlightingManager.Manager.FindHighlighter(highlightRuleSet.Reference);
          if (highlighter != null)
          {
            highlightRuleSet.Highlighter = highlighter;
          }
          else
          {
            int num = (int) MessageBox.Show("The mode defintion " + highlightRuleSet.Reference + " which is refered from the " + this.Name + " mode definition could not be found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            highlightRuleSet.Highlighter = (IHighlightingStrategy) this;
          }
        }
        else
          highlightRuleSet.Highlighter = (IHighlightingStrategy) this;
      }
    }

    internal void SetColorFor(string name, HighlightColor color)
    {
      this.environmentColors[name] = color;
    }

    public HighlightColor GetColorFor(string name)
    {
      if (!this.environmentColors.ContainsKey(name))
        throw new Exception("Color : " + name + " not found!");
      return this.environmentColors[name];
    }

    public HighlightColor GetColor(IDocument document, LineSegment currentSegment, int currentOffset, int currentLength)
    {
      return this.GetColor(this.defaultRuleSet, document, currentSegment, currentOffset, currentLength);
    }

    private HighlightColor GetColor(HighlightRuleSet ruleSet, IDocument document, LineSegment currentSegment, int currentOffset, int currentLength)
    {
      if (ruleSet == null)
        return (HighlightColor) null;
      if (ruleSet.Reference != null)
        return ruleSet.Highlighter.GetColor(document, currentSegment, currentOffset, currentLength);
      return (HighlightColor) ruleSet.KeyWords[document, currentSegment, currentOffset, currentLength];
    }

    public HighlightRuleSet GetRuleSet(Span aSpan)
    {
      if (aSpan == null)
        return this.defaultRuleSet;
      if (aSpan.RuleSet == null)
        return (HighlightRuleSet) null;
      if (aSpan.RuleSet.Reference != null)
        return aSpan.RuleSet.Highlighter.GetRuleSet((Span) null);
      return aSpan.RuleSet;
    }

    public void MarkTokens(IDocument document)
    {
      if (this.Rules.Count == 0)
        return;
      for (int index = 0; index < document.TotalNumberOfLines; ++index)
      {
        LineSegment lineSegment = index > 0 ? document.GetLineSegment(index - 1) : (LineSegment) null;
        if (index < document.LineSegmentCollection.Count)
        {
          this.currentSpanStack = lineSegment == null || lineSegment.HighlightSpanStack == null ? (Stack<Span>) null : new Stack<Span>((IEnumerable<Span>) lineSegment.HighlightSpanStack.ToArray());
          if (this.currentSpanStack != null)
          {
            while (this.currentSpanStack.Count > 0 && this.currentSpanStack.Peek().StopEOL)
              this.currentSpanStack.Pop();
            if (this.currentSpanStack.Count == 0)
              this.currentSpanStack = (Stack<Span>) null;
          }
          this.currentLine = document.LineSegmentCollection[index];
          if (this.currentLine.Length == -1)
            return;
          List<TextWord> list = this.ParseLine(document);
          if (this.currentLine.Words != null)
            this.currentLine.Words.Clear();
          this.currentLine.Words = list;
          this.currentLine.HighlightSpanStack = this.currentSpanStack == null || this.currentSpanStack.Count == 0 ? (Stack<Span>) null : this.currentSpanStack;
        }
        else
          break;
      }
      document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
      document.CommitUpdate();
      this.currentLine = (LineSegment) null;
    }

    private bool MarkTokensInLine(IDocument document, int lineNumber, ref bool spanChanged)
    {
      bool flag1 = false;
      LineSegment lineSegment = lineNumber > 0 ? document.GetLineSegment(lineNumber - 1) : (LineSegment) null;
      this.currentSpanStack = lineSegment == null || lineSegment.HighlightSpanStack == null ? (Stack<Span>) null : new Stack<Span>((IEnumerable<Span>) lineSegment.HighlightSpanStack.ToArray());
      if (this.currentSpanStack != null)
      {
        while (this.currentSpanStack.Count > 0 && this.currentSpanStack.Peek().StopEOL)
          this.currentSpanStack.Pop();
        if (this.currentSpanStack.Count == 0)
          this.currentSpanStack = (Stack<Span>) null;
      }
      this.currentLine = document.LineSegmentCollection[lineNumber];
      if (this.currentLine.Length == -1)
        return false;
      List<TextWord> list = this.ParseLine(document);
      if (this.currentSpanStack != null && this.currentSpanStack.Count == 0)
        this.currentSpanStack = (Stack<Span>) null;
      if (this.currentLine.HighlightSpanStack != this.currentSpanStack)
      {
        if (this.currentLine.HighlightSpanStack == null)
        {
          flag1 = false;
          foreach (Span span in this.currentSpanStack)
          {
            if (!span.StopEOL)
            {
              spanChanged = true;
              flag1 = true;
              break;
            }
          }
        }
        else if (this.currentSpanStack == null)
        {
          flag1 = false;
          foreach (Span span in this.currentLine.HighlightSpanStack)
          {
            if (!span.StopEOL)
            {
              spanChanged = true;
              flag1 = true;
              break;
            }
          }
        }
        else
        {
          IEnumerator<Span> enumerator1 = (IEnumerator<Span>) this.currentSpanStack.GetEnumerator();
          IEnumerator<Span> enumerator2 = (IEnumerator<Span>) this.currentLine.HighlightSpanStack.GetEnumerator();
          bool flag2 = false;
          while (!flag2)
          {
            bool flag3 = false;
            while (enumerator1.MoveNext())
            {
              if (!enumerator1.Current.StopEOL)
              {
                flag3 = true;
                break;
              }
            }
            bool flag4 = false;
            while (enumerator2.MoveNext())
            {
              if (!enumerator2.Current.StopEOL)
              {
                flag4 = true;
                break;
              }
            }
            if (flag3 || flag4)
            {
              if (flag3 && flag4)
              {
                if (enumerator1.Current != enumerator2.Current)
                {
                  flag2 = true;
                  flag1 = true;
                  spanChanged = true;
                }
              }
              else
              {
                spanChanged = true;
                flag2 = true;
                flag1 = true;
              }
            }
            else
            {
              flag2 = true;
              flag1 = false;
            }
          }
        }
      }
      else
        flag1 = false;
      if (this.currentLine.Words != null)
        this.currentLine.Words.Clear();
      this.currentLine.Words = list;
      this.currentLine.HighlightSpanStack = this.currentSpanStack == null || this.currentSpanStack.Count <= 0 ? (Stack<Span>) null : this.currentSpanStack;
      return flag1;
    }

    public void MarkTokens(IDocument document, List<LineSegment> inputLines)
    {
      if (this.Rules.Count == 0)
        return;
      Dictionary<LineSegment, bool> dictionary = new Dictionary<LineSegment, bool>();
      bool spanChanged = false;
      using (List<LineSegment>.Enumerator enumerator = inputLines.GetEnumerator())
      {
label_7:
        while (enumerator.MoveNext())
        {
          LineSegment current = enumerator.Current;
          if (!dictionary.ContainsKey(current))
          {
            int lineNumberForOffset = document.GetLineNumberForOffset(current.Offset);
            bool flag = true;
            if (lineNumberForOffset != -1)
            {
              while (true)
              {
                if (flag && lineNumberForOffset < document.TotalNumberOfLines && lineNumberForOffset < document.LineSegmentCollection.Count)
                {
                  flag = this.MarkTokensInLine(document, lineNumberForOffset, ref spanChanged);
                  dictionary[this.currentLine] = true;
                  ++lineNumberForOffset;
                }
                else
                  goto label_7;
              }
            }
          }
        }
      }
      if (spanChanged)
      {
        document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
      }
      else
      {
        foreach (LineSegment lineSegment in inputLines)
          document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.SingleLine, document.GetLineNumberForOffset(lineSegment.Offset)));
      }
      document.CommitUpdate();
      this.currentLine = (LineSegment) null;
    }

    private void UpdateSpanStateVariables()
    {
      this.inSpan = this.currentSpanStack != null && this.currentSpanStack.Count > 0;
      this.activeSpan = this.inSpan ? this.currentSpanStack.Peek() : (Span) null;
      this.activeRuleSet = this.GetRuleSet(this.activeSpan);
    }

    private List<TextWord> ParseLine(IDocument document)
    {
      List<TextWord> words = new List<TextWord>();
      HighlightColor markNext = (HighlightColor) null;
      this.currentOffset = 0;
      this.currentLength = 0;
      this.UpdateSpanStateVariables();
label_60:
      for (int index = 0; index < this.currentLine.Length; ++index)
      {
        char charAt = document.GetCharAt(this.currentLine.Offset + index);
        switch (charAt)
        {
          case '\t':
            this.PushCurWord(document, ref markNext, words);
            if (this.activeSpan != null && this.activeSpan.Color.HasBackground)
              words.Add((TextWord) new TextWord.TabTextWord(this.activeSpan.Color));
            else
              words.Add(TextWord.Tab);
            ++this.currentOffset;
            break;
          case '\n':
          case '\r':
            this.PushCurWord(document, ref markNext, words);
            ++this.currentOffset;
            break;
          case ' ':
            this.PushCurWord(document, ref markNext, words);
            if (this.activeSpan != null && this.activeSpan.Color.HasBackground)
              words.Add((TextWord) new TextWord.SpaceTextWord(this.activeSpan.Color));
            else
              words.Add(TextWord.Space);
            ++this.currentOffset;
            break;
          case '\\':
            if ((this.activeRuleSet == null || !this.activeRuleSet.NoEscapeSequences) && (this.activeSpan == null || !this.activeSpan.NoEscapeSequences))
            {
              ++this.currentLength;
              if (index + 1 < this.currentLine.Length)
                ++this.currentLength;
              this.PushCurWord(document, ref markNext, words);
              ++index;
              break;
            }
            goto default;
          default:
            if (!this.inSpan && (char.IsDigit(charAt) || (int) charAt == 46 && index + 1 < this.currentLine.Length && char.IsDigit(document.GetCharAt(this.currentLine.Offset + index + 1))) && this.currentLength == 0)
            {
              bool flag1 = false;
              bool flag2 = false;
              if ((int) charAt == 48 && index + 1 < this.currentLine.Length && (int) char.ToUpper(document.GetCharAt(this.currentLine.Offset + index + 1)) == 88)
              {
                ++this.currentLength;
                ++index;
                ++this.currentLength;
                flag1 = true;
                while (index + 1 < this.currentLine.Length && "0123456789ABCDEF".IndexOf(char.ToUpper(document.GetCharAt(this.currentLine.Offset + index + 1))) != -1)
                {
                  ++index;
                  ++this.currentLength;
                }
              }
              else
              {
                ++this.currentLength;
                while (index + 1 < this.currentLine.Length && char.IsDigit(document.GetCharAt(this.currentLine.Offset + index + 1)))
                {
                  ++index;
                  ++this.currentLength;
                }
              }
              if (!flag1 && index + 1 < this.currentLine.Length && (int) document.GetCharAt(this.currentLine.Offset + index + 1) == 46)
              {
                flag2 = true;
                ++index;
                ++this.currentLength;
                while (index + 1 < this.currentLine.Length && char.IsDigit(document.GetCharAt(this.currentLine.Offset + index + 1)))
                {
                  ++index;
                  ++this.currentLength;
                }
              }
              if (index + 1 < this.currentLine.Length && (int) char.ToUpper(document.GetCharAt(this.currentLine.Offset + index + 1)) == 69)
              {
                flag2 = true;
                ++index;
                ++this.currentLength;
                if (index + 1 < this.currentLine.Length && ((int) document.GetCharAt(this.currentLine.Offset + index + 1) == 43 || (int) document.GetCharAt(this.currentLine.Offset + index + 1) == 45))
                {
                  ++index;
                  ++this.currentLength;
                }
                while (index + 1 < this.currentLine.Length && char.IsDigit(document.GetCharAt(this.currentLine.Offset + index + 1)))
                {
                  ++index;
                  ++this.currentLength;
                }
              }
              if (index + 1 < this.currentLine.Length)
              {
                switch (char.ToUpper(document.GetCharAt(this.currentLine.Offset + index + 1)))
                {
                  case 'F':
                  case 'M':
                  case 'D':
                    flag2 = true;
                    ++index;
                    ++this.currentLength;
                    break;
                }
              }
              if (!flag2)
              {
                bool flag3 = false;
                if (index + 1 < this.currentLine.Length && (int) char.ToUpper(document.GetCharAt(this.currentLine.Offset + index + 1)) == 85)
                {
                  ++index;
                  ++this.currentLength;
                  flag3 = true;
                }
                if (index + 1 < this.currentLine.Length && (int) char.ToUpper(document.GetCharAt(this.currentLine.Offset + index + 1)) == 76)
                {
                  ++index;
                  ++this.currentLength;
                  if (!flag3 && index + 1 < this.currentLine.Length && (int) char.ToUpper(document.GetCharAt(this.currentLine.Offset + index + 1)) == 85)
                  {
                    ++index;
                    ++this.currentLength;
                  }
                }
              }
              words.Add(new TextWord(document, this.currentLine, this.currentOffset, this.currentLength, this.DigitColor, false));
              this.currentOffset += this.currentLength;
              this.currentLength = 0;
              break;
            }
            if (this.inSpan && this.activeSpan.End != null && (!this.activeSpan.End.Equals((object) "") && this.currentLine.MatchExpr(this.activeSpan.End, index, document)))
            {
              this.PushCurWord(document, ref markNext, words);
              string regString = this.currentLine.GetRegString(this.activeSpan.End, index, document);
              this.currentLength += regString.Length;
              words.Add(new TextWord(document, this.currentLine, this.currentOffset, this.currentLength, this.activeSpan.EndColor, false));
              this.currentOffset += this.currentLength;
              this.currentLength = 0;
              index += regString.Length - 1;
              this.currentSpanStack.Pop();
              this.UpdateSpanStateVariables();
              break;
            }
            if (this.activeRuleSet != null)
            {
              foreach (Span span in this.activeRuleSet.Spans)
              {
                if (this.currentLine.MatchExpr(span.Begin, index, document))
                {
                  this.PushCurWord(document, ref markNext, words);
                  string regString = this.currentLine.GetRegString(span.Begin, index, document);
                  this.currentLength += regString.Length;
                  words.Add(new TextWord(document, this.currentLine, this.currentOffset, this.currentLength, span.BeginColor, false));
                  this.currentOffset += this.currentLength;
                  this.currentLength = 0;
                  index += regString.Length - 1;
                  if (this.currentSpanStack == null)
                    this.currentSpanStack = new Stack<Span>();
                  this.currentSpanStack.Push(span);
                  this.UpdateSpanStateVariables();
                  goto label_60;
                }
              }
            }
            if (this.activeRuleSet != null && (int) charAt < 256 && this.activeRuleSet.Delimiters[(int) charAt])
            {
              this.PushCurWord(document, ref markNext, words);
              if (this.currentOffset + this.currentLength + 1 < this.currentLine.Length)
              {
                ++this.currentLength;
                this.PushCurWord(document, ref markNext, words);
                break;
              }
            }
            ++this.currentLength;
            break;
        }
      }
      this.PushCurWord(document, ref markNext, words);
      return words;
    }

    private void PushCurWord(IDocument document, ref HighlightColor markNext, List<TextWord> words)
    {
      if (this.currentLength <= 0)
        return;
      if (words.Count > 0 && this.activeRuleSet != null)
      {
        for (int index = words.Count - 1; index >= 0; --index)
        {
          if (!words[index].IsWhiteSpace)
          {
            TextWord textWord = words[index];
            if (textWord.HasDefaultColor)
            {
              PrevMarker prevMarker = (PrevMarker) this.activeRuleSet.PrevMarkers[document, this.currentLine, this.currentOffset, this.currentLength];
              if (prevMarker != null)
              {
                textWord.SyntaxColor = prevMarker.Color;
                break;
              }
              break;
            }
            break;
          }
        }
      }
      if (this.inSpan)
      {
        bool hasDefaultColor = true;
        HighlightColor highlightColor;
        if (this.activeSpan.Rule == null)
        {
          highlightColor = this.activeSpan.Color;
        }
        else
        {
          highlightColor = this.GetColor(this.activeRuleSet, document, this.currentLine, this.currentOffset, this.currentLength);
          hasDefaultColor = false;
        }
        if (highlightColor == null)
        {
          highlightColor = this.activeSpan.Color;
          if (highlightColor.Color == Color.Transparent)
            highlightColor = this.GetColorFor("DefaultBackground");
          hasDefaultColor = true;
        }
        words.Add(new TextWord(document, this.currentLine, this.currentOffset, this.currentLength, markNext != null ? markNext : highlightColor, hasDefaultColor));
      }
      else
      {
        HighlightColor color = markNext != null ? markNext : this.GetColor(this.activeRuleSet, document, this.currentLine, this.currentOffset, this.currentLength);
        if (color == null)
          words.Add(new TextWord(document, this.currentLine, this.currentOffset, this.currentLength, this.GetColorFor("DefaultBackground"), true));
        else
          words.Add(new TextWord(document, this.currentLine, this.currentOffset, this.currentLength, color, false));
      }
      if (this.activeRuleSet != null)
      {
        NextMarker nextMarker = (NextMarker) this.activeRuleSet.NextMarkers[document, this.currentLine, this.currentOffset, this.currentLength];
        if (nextMarker != null)
        {
          if (nextMarker.MarkMarker && words.Count > 0)
            words[words.Count - 1].SyntaxColor = nextMarker.Color;
          markNext = nextMarker.Color;
        }
        else
          markNext = (HighlightColor) null;
      }
      this.currentOffset += this.currentLength;
      this.currentLength = 0;
    }
  }
}
