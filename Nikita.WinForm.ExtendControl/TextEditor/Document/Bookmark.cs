// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.Bookmark
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class Bookmark
  {
    private bool isEnabled = true;
    private IDocument document;
    private int lineNumber;

    public IDocument Document
    {
      get
      {
        return this.document;
      }
      set
      {
        if (this.document == value)
          return;
        this.document = value;
        this.OnDocumentChanged(EventArgs.Empty);
      }
    }

    public bool IsEnabled
    {
      get
      {
        return this.isEnabled;
      }
      set
      {
        this.isEnabled = value;
        if (this.document == null)
          return;
        this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.SingleLine, this.lineNumber));
        this.document.CommitUpdate();
      }
    }

    public int LineNumber
    {
      get
      {
        return this.lineNumber;
      }
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException("value", (object) value, "line number must be >= 0");
        if (this.lineNumber == value)
          return;
        this.lineNumber = value;
        this.OnLineNumberChanged(EventArgs.Empty);
      }
    }

    public virtual bool CanToggle
    {
      get
      {
        return true;
      }
    }

    public event EventHandler DocumentChanged;

    public event EventHandler LineNumberChanged;

    public Bookmark(IDocument document, int lineNumber)
      : this(document, lineNumber, true)
    {
    }

    public Bookmark(IDocument document, int lineNumber, bool isEnabled)
    {
      if (lineNumber < 0)
        throw new ArgumentOutOfRangeException("lineNumber", (object) lineNumber, "line number must be >= 0");
      this.document = document;
      this.lineNumber = lineNumber;
      this.isEnabled = isEnabled;
    }

    protected virtual void OnDocumentChanged(EventArgs e)
    {
      if (this.DocumentChanged == null)
        return;
      this.DocumentChanged((object) this, e);
    }

    protected virtual void OnLineNumberChanged(EventArgs e)
    {
      if (this.LineNumberChanged == null)
        return;
      this.LineNumberChanged((object) this, e);
    }

    public virtual void Click(Control parent, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left || !this.CanToggle)
        return;
      this.document.BookmarkManager.RemoveMark(this);
    }

    public virtual void Draw(IconBarMargin margin, Graphics g, Point p)
    {
      margin.DrawBookmark(g, p.Y, this.isEnabled);
    }
  }
}
