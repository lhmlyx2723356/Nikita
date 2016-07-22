// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.SelectionManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class SelectionManager : IDisposable
  {
    private List<ISelection> selectionCollection = new List<ISelection>();
    private IDocument document;

    public List<ISelection> SelectionCollection
    {
      get
      {
        return this.selectionCollection;
      }
    }

    public bool HasSomethingSelected
    {
      get
      {
        return this.selectionCollection.Count > 0;
      }
    }

    public string SelectedText
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ISelection selection in this.selectionCollection)
          stringBuilder.Append(selection.SelectedText);
        return stringBuilder.ToString();
      }
    }

    public event EventHandler SelectionChanged;

    public SelectionManager(IDocument document)
    {
      this.document = document;
      document.DocumentChanged += new DocumentEventHandler(this.DocumentChanged);
    }

    public void Dispose()
    {
      if (this.document == null)
        return;
      this.document.DocumentChanged -= new DocumentEventHandler(this.DocumentChanged);
      this.document = (IDocument) null;
    }

    private void DocumentChanged(object sender, DocumentEventArgs e)
    {
      if (e.Text == null)
        this.Remove(e.Offset, e.Length);
      else if (e.Length < 0)
        this.Insert(e.Offset, e.Text);
      else
        this.Replace(e.Offset, e.Length, e.Text);
    }

    public void SetSelection(ISelection selection)
    {
      if (selection != null)
      {
        if (this.SelectionCollection.Count == 1 && selection.StartPosition == this.SelectionCollection[0].StartPosition && selection.EndPosition == this.SelectionCollection[0].EndPosition)
          return;
        this.ClearWithoutUpdate();
        this.selectionCollection.Add(selection);
        this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.LinesBetween, selection.StartPosition.Y, selection.EndPosition.Y));
        this.document.CommitUpdate();
        this.OnSelectionChanged(EventArgs.Empty);
      }
      else
        this.ClearSelection();
    }

    public void SetSelection(Point startPosition, Point endPosition)
    {
      this.SetSelection((ISelection) new DefaultSelection(this.document, startPosition, endPosition));
    }

    public bool GreaterEqPos(Point p1, Point p2)
    {
      if (p1.Y > p2.Y)
        return true;
      if (p1.Y == p2.Y)
        return p1.X >= p2.X;
      return false;
    }

    public void ExtendSelection(Point oldPosition, Point newPosition)
    {
      if (oldPosition == newPosition)
        return;
      bool flag1 = this.GreaterEqPos(oldPosition, newPosition);
      Point startPosition;
      Point endPosition;
      if (flag1)
      {
        startPosition = newPosition;
        endPosition = oldPosition;
      }
      else
      {
        startPosition = oldPosition;
        endPosition = newPosition;
      }
      if (!this.HasSomethingSelected)
      {
        this.SetSelection((ISelection) new DefaultSelection(this.document, startPosition, endPosition));
      }
      else
      {
        ISelection selection = this.selectionCollection[0];
        bool flag2 = false;
        if (selection.ContainsPosition(newPosition))
        {
          if (flag1)
          {
            if (selection.EndPosition != newPosition)
            {
              selection.EndPosition = newPosition;
              flag2 = true;
            }
          }
          else if (selection.StartPosition != newPosition)
          {
            selection.StartPosition = newPosition;
            flag2 = true;
          }
        }
        else if (oldPosition == selection.StartPosition)
        {
          if (this.GreaterEqPos(newPosition, selection.EndPosition))
          {
            if (selection.StartPosition != selection.EndPosition || selection.EndPosition != newPosition)
            {
              selection.StartPosition = selection.EndPosition;
              selection.EndPosition = newPosition;
              flag2 = true;
            }
          }
          else if (selection.StartPosition != newPosition)
          {
            selection.StartPosition = newPosition;
            flag2 = true;
          }
        }
        else if (this.GreaterEqPos(selection.StartPosition, newPosition))
        {
          if (selection.EndPosition != selection.StartPosition || selection.StartPosition != newPosition)
            ;
          selection.EndPosition = selection.StartPosition;
          selection.StartPosition = newPosition;
          flag2 = true;
        }
        else if (selection.EndPosition != newPosition)
        {
          selection.EndPosition = newPosition;
          flag2 = true;
        }
        if (!flag2)
          return;
        this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.LinesBetween, startPosition.Y, endPosition.Y));
        this.document.CommitUpdate();
        this.OnSelectionChanged(EventArgs.Empty);
      }
    }

    private void ClearWithoutUpdate()
    {
      while (this.selectionCollection.Count > 0)
      {
        ISelection selection = this.selectionCollection[this.selectionCollection.Count - 1];
        this.selectionCollection.RemoveAt(this.selectionCollection.Count - 1);
        this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.LinesBetween, selection.StartPosition.Y, selection.EndPosition.Y));
        this.OnSelectionChanged(EventArgs.Empty);
      }
    }

    public void ClearSelection()
    {
      this.ClearWithoutUpdate();
      this.document.CommitUpdate();
    }

    public void RemoveSelectedText()
    {
      List<int> list = new List<int>();
      int num = -1;
      bool flag = true;
      foreach (ISelection selection in this.selectionCollection)
      {
        if (flag)
        {
          int y = selection.StartPosition.Y;
          if (y != selection.EndPosition.Y)
            flag = false;
          else
            list.Add(y);
        }
        num = selection.Offset;
        this.document.Remove(selection.Offset, selection.Length);
      }
      this.ClearSelection();
      if (num == -1)
        return;
      if (flag)
      {
        foreach (int singleLine in list)
          this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.SingleLine, singleLine));
      }
      else
        this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
      this.document.CommitUpdate();
    }

    private bool SelectionsOverlap(ISelection s1, ISelection s2)
    {
      if (s1.Offset <= s2.Offset && s2.Offset <= s1.Offset + s1.Length || s1.Offset <= s2.Offset + s2.Length && s2.Offset + s2.Length <= s1.Offset + s1.Length)
        return true;
      if (s1.Offset >= s2.Offset)
        return s1.Offset + s1.Length <= s2.Offset + s2.Length;
      return false;
    }

    public bool IsSelected(int offset)
    {
      return this.GetSelectionAt(offset) != null;
    }

    public ISelection GetSelectionAt(int offset)
    {
      foreach (ISelection selection in this.selectionCollection)
      {
        if (selection.ContainsOffset(offset))
          return selection;
      }
      return (ISelection) null;
    }

    public void Insert(int offset, string text)
    {
    }

    public void Remove(int offset, int length)
    {
    }

    public void Replace(int offset, int length, string text)
    {
    }

    public ColumnRange GetSelectionAtLine(int lineNumber)
    {
      foreach (ISelection selection in this.selectionCollection)
      {
        int y1 = selection.StartPosition.Y;
        int y2 = selection.EndPosition.Y;
        if (y1 < lineNumber && lineNumber < y2)
          return ColumnRange.WholeColumn;
        if (y1 == lineNumber)
        {
          LineSegment lineSegment = this.document.GetLineSegment(y1);
          return new ColumnRange(selection.StartPosition.X, y2 == lineNumber ? selection.EndPosition.X : lineSegment.Length + 1);
        }
        if (y2 == lineNumber)
          return new ColumnRange(0, selection.EndPosition.X);
      }
      return ColumnRange.NoColumn;
    }

    public void FireSelectionChanged()
    {
      this.OnSelectionChanged(EventArgs.Empty);
    }

    protected virtual void OnSelectionChanged(EventArgs e)
    {
      if (this.SelectionChanged == null)
        return;
      this.SelectionChanged((object) this, e);
    }
  }
}
