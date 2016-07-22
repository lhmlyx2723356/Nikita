// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.Span
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class Span
  {
    private bool stopEOL;
    private HighlightColor color;
    private HighlightColor beginColor;
    private HighlightColor endColor;
    private char[] begin;
    private char[] end;
    private string name;
    private string rule;
    private HighlightRuleSet ruleSet;
    private bool noEscapeSequences;

    internal HighlightRuleSet RuleSet
    {
      get
      {
        return this.ruleSet;
      }
      set
      {
        this.ruleSet = value;
      }
    }

    public bool StopEOL
    {
      get
      {
        return this.stopEOL;
      }
    }

    public HighlightColor Color
    {
      get
      {
        return this.color;
      }
    }

    public HighlightColor BeginColor
    {
      get
      {
        if (this.beginColor != null)
          return this.beginColor;
        return this.color;
      }
    }

    public HighlightColor EndColor
    {
      get
      {
        if (this.endColor == null)
          return this.color;
        return this.endColor;
      }
    }

    public char[] Begin
    {
      get
      {
        return this.begin;
      }
    }

    public char[] End
    {
      get
      {
        return this.end;
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }
    }

    public string Rule
    {
      get
      {
        return this.rule;
      }
    }

    public bool NoEscapeSequences
    {
      get
      {
        return this.noEscapeSequences;
      }
    }

    public Span(XmlElement span)
    {
      this.color = new HighlightColor(span);
      if (span.Attributes["rule"] != null)
        this.rule = span.Attributes["rule"].InnerText;
      if (span.Attributes["noescapesequences"] != null)
        this.noEscapeSequences = bool.Parse(span.Attributes["noescapesequences"].InnerText);
      this.name = span.Attributes["name"].InnerText;
      this.stopEOL = bool.Parse(span.Attributes["stopateol"].InnerText);
      this.begin = span["Begin"].InnerText.ToCharArray();
      this.beginColor = new HighlightColor(span["Begin"], this.color);
      if (span["End"] == null)
        return;
      this.end = span["End"].InnerText.ToCharArray();
      this.endColor = new HighlightColor(span["End"], this.color);
    }
  }
}
