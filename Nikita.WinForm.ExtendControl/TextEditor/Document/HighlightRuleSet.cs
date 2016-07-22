// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.HighlightRuleSet
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Util;
using System.Collections;
using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class HighlightRuleSet
  {
    private ArrayList spans = new ArrayList();
    private bool[] delimiters = new bool[256];
    private LookupTable keyWords;
    private LookupTable prevMarkers;
    private LookupTable nextMarkers;
    private IHighlightingStrategy highlighter;
    private bool noEscapeSequences;
    private bool ignoreCase;
    private string name;
    private string reference;

    public ArrayList Spans
    {
      get
      {
        return this.spans;
      }
    }

    internal IHighlightingStrategy Highlighter
    {
      get
      {
        return this.highlighter;
      }
      set
      {
        this.highlighter = value;
      }
    }

    public LookupTable KeyWords
    {
      get
      {
        return this.keyWords;
      }
    }

    public LookupTable PrevMarkers
    {
      get
      {
        return this.prevMarkers;
      }
    }

    public LookupTable NextMarkers
    {
      get
      {
        return this.nextMarkers;
      }
    }

    public bool[] Delimiters
    {
      get
      {
        return this.delimiters;
      }
    }

    public bool NoEscapeSequences
    {
      get
      {
        return this.noEscapeSequences;
      }
    }

    public bool IgnoreCase
    {
      get
      {
        return this.ignoreCase;
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    public string Reference
    {
      get
      {
        return this.reference;
      }
    }

    public HighlightRuleSet()
    {
      this.keyWords = new LookupTable(false);
      this.prevMarkers = new LookupTable(false);
      this.nextMarkers = new LookupTable(false);
    }

    public HighlightRuleSet(XmlElement el)
    {
      XmlNodeList elementsByTagName = el.GetElementsByTagName("KeyWords");
      if (el.Attributes["name"] != null)
        this.Name = el.Attributes["name"].InnerText;
      if (el.Attributes["noescapesequences"] != null)
        this.noEscapeSequences = bool.Parse(el.Attributes["noescapesequences"].InnerText);
      if (el.Attributes["reference"] != null)
        this.reference = el.Attributes["reference"].InnerText;
      if (el.Attributes["ignorecase"] != null)
        this.ignoreCase = bool.Parse(el.Attributes["ignorecase"].InnerText);
      for (int index = 0; index < this.Delimiters.Length; ++index)
        this.Delimiters[index] = false;
      if (el["Delimiters"] != null)
      {
        foreach (int index in el["Delimiters"].InnerText)
          this.Delimiters[index] = true;
      }
      this.keyWords = new LookupTable(!this.IgnoreCase);
      this.prevMarkers = new LookupTable(!this.IgnoreCase);
      this.nextMarkers = new LookupTable(!this.IgnoreCase);
      foreach (XmlElement el1 in elementsByTagName)
      {
        HighlightColor highlightColor = new HighlightColor(el1);
        foreach (XmlNode xmlNode in el1.GetElementsByTagName("Key"))
          this.keyWords[xmlNode.Attributes["word"].InnerText] = (object) highlightColor;
      }
      foreach (XmlElement span in el.GetElementsByTagName("Span"))
        this.Spans.Add((object) new Span(span));
      foreach (XmlElement mark in el.GetElementsByTagName("MarkPrevious"))
      {
        PrevMarker prevMarker = new PrevMarker(mark);
        this.prevMarkers[prevMarker.What] = (object) prevMarker;
      }
      foreach (XmlElement mark in el.GetElementsByTagName("MarkFollowing"))
      {
        NextMarker nextMarker = new NextMarker(mark);
        this.nextMarkers[nextMarker.What] = (object) nextMarker;
      }
    }
  }
}
