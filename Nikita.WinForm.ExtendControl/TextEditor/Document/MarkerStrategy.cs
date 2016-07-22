// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.MarkerStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class MarkerStrategy
  {
    private List<Nikita.WinForm.ExtendControl.Document.TextMarker> textMarker = new List<Nikita.WinForm.ExtendControl.Document.TextMarker>();
    private Dictionary<int, List<Nikita.WinForm.ExtendControl.Document.TextMarker>> markersTable = new Dictionary<int, List<Nikita.WinForm.ExtendControl.Document.TextMarker>>();
    private IDocument document;

    public IDocument Document
    {
      get
      {
        return this.document;
      }
    }

    public IEnumerable<Nikita.WinForm.ExtendControl.Document.TextMarker> TextMarker
    {
      get
      {
        return (IEnumerable<Nikita.WinForm.ExtendControl.Document.TextMarker>) this.textMarker;
      }
    }

    public MarkerStrategy(IDocument document)
    {
      this.document = document;
      document.DocumentChanged += new DocumentEventHandler(this.DocumentChanged);
    }

    public void AddMarker(Nikita.WinForm.ExtendControl.Document.TextMarker item)
    {
      this.markersTable.Clear();
      this.textMarker.Add(item);
    }

    public void InsertMarker(int index, Nikita.WinForm.ExtendControl.Document.TextMarker item)
    {
      this.markersTable.Clear();
      this.textMarker.Insert(index, item);
    }

    public void RemoveMarker(Nikita.WinForm.ExtendControl.Document.TextMarker item)
    {
      this.markersTable.Clear();
      this.textMarker.Remove(item);
    }

    public void RemoveAll(Predicate<Nikita.WinForm.ExtendControl.Document.TextMarker> match)
    {
      this.markersTable.Clear();
      this.textMarker.RemoveAll(match);
    }

    public List<Nikita.WinForm.ExtendControl.Document.TextMarker> GetMarkers(int offset)
    {
      if (!this.markersTable.ContainsKey(offset))
      {
        List<Nikita.WinForm.ExtendControl.Document.TextMarker> list = new List<Nikita.WinForm.ExtendControl.Document.TextMarker>();
        for (int index = 0; index < this.textMarker.Count; ++index)
        {
          Nikita.WinForm.ExtendControl.Document.TextMarker textMarker = this.textMarker[index];
          if (textMarker.Offset <= offset && offset <= textMarker.Offset + textMarker.Length)
            list.Add(textMarker);
        }
        this.markersTable[offset] = list;
      }
      return this.markersTable[offset];
    }

    public List<Nikita.WinForm.ExtendControl.Document.TextMarker> GetMarkers(int offset, int length)
    {
      List<Nikita.WinForm.ExtendControl.Document.TextMarker> list = new List<Nikita.WinForm.ExtendControl.Document.TextMarker>();
      for (int index = 0; index < this.textMarker.Count; ++index)
      {
        Nikita.WinForm.ExtendControl.Document.TextMarker textMarker = this.textMarker[index];
        if (textMarker.Offset <= offset && offset <= textMarker.Offset + textMarker.Length || textMarker.Offset <= offset + length && offset + length <= textMarker.Offset + textMarker.Length || (offset <= textMarker.Offset && textMarker.Offset <= offset + length || offset <= textMarker.Offset + textMarker.Length && textMarker.Offset + textMarker.Length <= offset + length))
          list.Add(textMarker);
      }
      return list;
    }

    public List<Nikita.WinForm.ExtendControl.Document.TextMarker> GetMarkers(Point position)
    {
      if (position.Y >= this.document.TotalNumberOfLines || position.Y < 0)
        return new List<Nikita.WinForm.ExtendControl.Document.TextMarker>();
      return this.GetMarkers(this.document.GetLineSegment(position.Y).Offset + position.X);
    }

    private void DocumentChanged(object sender, DocumentEventArgs e)
    {
      this.markersTable.Clear();
      this.document.UpdateSegmentListOnDocumentChange<Nikita.WinForm.ExtendControl.Document.TextMarker>(this.textMarker, e);
    }
  }
}
