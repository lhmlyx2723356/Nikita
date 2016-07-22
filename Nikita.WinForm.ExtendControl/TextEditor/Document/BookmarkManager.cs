// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.BookmarkManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections.Generic;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class BookmarkManager
  {
    private List<Bookmark> bookmark = new List<Bookmark>();
    private IDocument document;
    private IBookmarkFactory factory;

    public List<Bookmark> Marks
    {
      get
      {
        return this.bookmark;
      }
    }

    public IDocument Document
    {
      get
      {
        return this.document;
      }
    }

    public IBookmarkFactory Factory
    {
      get
      {
        return this.factory;
      }
      set
      {
        this.factory = value;
      }
    }

    public event BookmarkEventHandler Removed;

    public event BookmarkEventHandler Added;

    public event EventHandler Changed;

    public BookmarkManager(IDocument document, ILineManager lineTracker)
    {
      this.document = document;
      lineTracker.LineCountChanged += new LineManagerEventHandler(this.MoveIndices);
    }

    public void ToggleMarkAt(int lineNr)
    {
      for (int index = 0; index < this.bookmark.Count; ++index)
      {
        Bookmark bookmark = this.bookmark[index];
        if (bookmark.LineNumber == lineNr && bookmark.CanToggle)
        {
          this.bookmark.RemoveAt(index);
          this.OnRemoved(new BookmarkEventArgs(bookmark));
          this.OnChanged(EventArgs.Empty);
          return;
        }
      }
      Bookmark bookmark1 = this.factory == null ? new Bookmark(this.document, lineNr) : this.factory.CreateBookmark(this.document, lineNr);
      this.bookmark.Add(bookmark1);
      this.OnAdded(new BookmarkEventArgs(bookmark1));
      this.OnChanged(EventArgs.Empty);
    }

    public void AddMark(Bookmark mark)
    {
      this.bookmark.Add(mark);
      this.OnAdded(new BookmarkEventArgs(mark));
      this.OnChanged(EventArgs.Empty);
    }

    public void RemoveMark(Bookmark mark)
    {
      this.bookmark.Remove(mark);
      this.OnRemoved(new BookmarkEventArgs(mark));
      this.OnChanged(EventArgs.Empty);
    }

    public void RemoveMarks(Predicate<Bookmark> predicate)
    {
      for (int index = 0; index < this.bookmark.Count; ++index)
      {
        Bookmark bookmark = this.bookmark[index];
        if (predicate(bookmark))
        {
          this.bookmark.RemoveAt(index--);
          this.OnRemoved(new BookmarkEventArgs(bookmark));
        }
      }
      this.OnChanged(EventArgs.Empty);
    }

    public bool IsMarked(int lineNr)
    {
      for (int index = 0; index < this.bookmark.Count; ++index)
      {
        if (this.bookmark[index].LineNumber == lineNr)
          return true;
      }
      return false;
    }

    private void MoveIndices(object sender, LineManagerEventArgs e)
    {
      bool flag = false;
      for (int index = 0; index < this.bookmark.Count; ++index)
      {
        Bookmark bookmark = this.bookmark[index];
        if (e.LinesMoved < 0 && bookmark.LineNumber == e.LineStart)
        {
          this.bookmark.RemoveAt(index);
          this.OnRemoved(new BookmarkEventArgs(bookmark));
          --index;
          flag = true;
        }
        else if (bookmark.LineNumber > e.LineStart + 1 || e.LinesMoved < 0 && bookmark.LineNumber > e.LineStart)
        {
          flag = true;
          int num = bookmark.LineNumber + e.LinesMoved;
          if (num >= 0)
          {
            this.bookmark[index].LineNumber = num;
          }
          else
          {
            this.bookmark.RemoveAt(index);
            this.OnRemoved(new BookmarkEventArgs(bookmark));
            --index;
          }
        }
      }
      if (!flag)
        return;
      this.OnChanged(EventArgs.Empty);
    }

    public void Clear()
    {
      foreach (Bookmark bookmark in this.bookmark)
        this.OnRemoved(new BookmarkEventArgs(bookmark));
      this.bookmark.Clear();
      this.OnChanged(EventArgs.Empty);
    }

    public Bookmark GetFirstMark(Predicate<Bookmark> predicate)
    {
      if (this.bookmark.Count < 1)
        return (Bookmark) null;
      Bookmark bookmark = (Bookmark) null;
      for (int index = 0; index < this.bookmark.Count; ++index)
      {
        if (predicate(this.bookmark[index]) && this.bookmark[index].IsEnabled && (bookmark == null || this.bookmark[index].LineNumber < bookmark.LineNumber))
          bookmark = this.bookmark[index];
      }
      return bookmark;
    }

    public Bookmark GetLastMark(Predicate<Bookmark> predicate)
    {
      if (this.bookmark.Count < 1)
        return (Bookmark) null;
      Bookmark bookmark = (Bookmark) null;
      for (int index = 0; index < this.bookmark.Count; ++index)
      {
        if (predicate(this.bookmark[index]) && this.bookmark[index].IsEnabled && (bookmark == null || this.bookmark[index].LineNumber > bookmark.LineNumber))
          bookmark = this.bookmark[index];
      }
      return bookmark;
    }

    private bool AcceptAnyMarkPredicate(Bookmark mark)
    {
      return true;
    }

    public Bookmark GetNextMark(int curLineNr)
    {
      return this.GetNextMark(curLineNr, new Predicate<Bookmark>(this.AcceptAnyMarkPredicate));
    }

    public Bookmark GetNextMark(int curLineNr, Predicate<Bookmark> predicate)
    {
      if (this.bookmark.Count == 0)
        return (Bookmark) null;
      Bookmark bookmark1 = this.GetFirstMark(predicate);
      foreach (Bookmark bookmark2 in this.bookmark)
      {
        if (predicate(bookmark2) && bookmark2.IsEnabled && bookmark2.LineNumber > curLineNr && (bookmark2.LineNumber < bookmark1.LineNumber || bookmark1.LineNumber <= curLineNr))
          bookmark1 = bookmark2;
      }
      return bookmark1;
    }

    public Bookmark GetPrevMark(int curLineNr)
    {
      return this.GetPrevMark(curLineNr, new Predicate<Bookmark>(this.AcceptAnyMarkPredicate));
    }

    public Bookmark GetPrevMark(int curLineNr, Predicate<Bookmark> predicate)
    {
      if (this.bookmark.Count == 0)
        return (Bookmark) null;
      Bookmark bookmark1 = this.GetLastMark(predicate);
      foreach (Bookmark bookmark2 in this.bookmark)
      {
        if (predicate(bookmark2) && bookmark2.IsEnabled && bookmark2.LineNumber < curLineNr && (bookmark2.LineNumber > bookmark1.LineNumber || bookmark1.LineNumber >= curLineNr))
          bookmark1 = bookmark2;
      }
      return bookmark1;
    }

    protected virtual void OnChanged(EventArgs e)
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, e);
    }

    protected virtual void OnRemoved(BookmarkEventArgs e)
    {
      if (this.Removed == null)
        return;
      this.Removed((object) this, e);
    }

    protected virtual void OnAdded(BookmarkEventArgs e)
    {
      if (this.Added == null)
        return;
      this.Added((object) this, e);
    }
  }
}
