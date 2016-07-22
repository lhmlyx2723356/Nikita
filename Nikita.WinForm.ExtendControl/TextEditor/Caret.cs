// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Caret
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Nikita.WinForm.ExtendControl
{
  public class Caret : IDisposable
  {
    private bool hidden = true;
    private Point currentPos = new Point(-1, -1);
    private int oldLine = -1;
    private int line;
    private int column;
    private int desiredXPos;
    private CaretMode caretMode;
    private static bool caretCreated;
    private TextArea textArea;
    private Ime ime;

    public int DesiredColumn
    {
      get
      {
        return this.desiredXPos;
      }
      set
      {
        this.desiredXPos = value;
      }
    }

    public CaretMode CaretMode
    {
      get
      {
        return this.caretMode;
      }
      set
      {
        this.caretMode = value;
        this.OnCaretModeChanged(EventArgs.Empty);
      }
    }

    public int Line
    {
      get
      {
        return this.line;
      }
      set
      {
        this.line = value;
        this.ValidateCaretPos();
        this.UpdateCaretPosition();
        this.OnPositionChanged(EventArgs.Empty);
      }
    }

    public int Column
    {
      get
      {
        return this.column;
      }
      set
      {
        this.column = value;
        this.ValidateCaretPos();
        this.UpdateCaretPosition();
        this.OnPositionChanged(EventArgs.Empty);
      }
    }

    public Point Position
    {
      get
      {
        return new Point(this.column, this.line);
      }
      set
      {
        this.line = value.Y;
        this.column = value.X;
        this.ValidateCaretPos();
        this.UpdateCaretPosition();
        this.OnPositionChanged(EventArgs.Empty);
      }
    }

    public int Offset
    {
      get
      {
        return this.textArea.Document.PositionToOffset(this.Position);
      }
    }

    public Point ScreenPosition
    {
      get
      {
        return new Point(this.textArea.TextView.DrawingPosition.X + this.textArea.TextView.GetDrawingXPos(this.line, this.column), this.textArea.TextView.DrawingPosition.Y + this.textArea.Document.GetVisibleLine(this.line) * this.textArea.TextView.FontHeight - this.textArea.TextView.TextArea.VirtualTop.Y);
      }
    }

    public event EventHandler PositionChanged;

    public event EventHandler CaretModeChanged;

    public Caret(TextArea textArea)
    {
      this.textArea = textArea;
      textArea.GotFocus += new EventHandler(this.GotFocus);
      textArea.LostFocus += new EventHandler(this.LostFocus);
    }

    public void Dispose()
    {
      this.textArea.GotFocus -= new EventHandler(this.GotFocus);
      this.textArea.LostFocus -= new EventHandler(this.LostFocus);
      this.textArea = (TextArea) null;
    }

    public Point ValidatePosition(Point pos)
    {
      int num1 = Math.Max(0, Math.Min(this.textArea.Document.TotalNumberOfLines - 1, pos.Y));
      int num2 = Math.Max(0, pos.X);
      if (!this.textArea.TextEditorProperties.AllowCaretBeyondEOL)
      {
        LineSegment lineSegment = this.textArea.Document.GetLineSegment(num1);
        num2 = Math.Min(num2, lineSegment.Length);
      }
      return new Point(num2, num1);
    }

    public void ValidateCaretPos()
    {
      this.line = Math.Max(0, Math.Min(this.textArea.Document.TotalNumberOfLines - 1, this.line));
      this.column = Math.Max(0, this.column);
      if (this.textArea.TextEditorProperties.AllowCaretBeyondEOL)
        return;
      this.column = Math.Min(this.column, this.textArea.Document.GetLineSegment(this.line).Length);
    }

    private void CreateCaret()
    {
      while (!Caret.caretCreated)
      {
        switch (this.caretMode)
        {
          case CaretMode.InsertMode:
            Caret.caretCreated = Caret.CreateCaret(this.textArea.Handle, 0, 2, this.textArea.TextView.FontHeight);
            continue;
          case CaretMode.OverwriteMode:
            Caret.caretCreated = Caret.CreateCaret(this.textArea.Handle, 0, (int) this.textArea.TextView.SpaceWidth, this.textArea.TextView.FontHeight);
            continue;
          default:
            continue;
        }
      }
      if (this.currentPos.X < 0)
      {
        this.ValidateCaretPos();
        this.currentPos = this.ScreenPosition;
      }
      Caret.SetCaretPos(this.currentPos.X, this.currentPos.Y);
      Caret.ShowCaret(this.textArea.Handle);
    }

    public void RecreateCaret()
    {
      this.DisposeCaret();
      if (this.hidden)
        return;
      this.CreateCaret();
    }

    private void DisposeCaret()
    {
      Caret.caretCreated = false;
      Caret.HideCaret(this.textArea.Handle);
      Caret.DestroyCaret();
    }

    private void GotFocus(object sender, EventArgs e)
    {
      this.hidden = false;
      if (this.textArea.MotherTextEditorControl.IsUpdating)
        return;
      this.CreateCaret();
      this.UpdateCaretPosition();
    }

    private void LostFocus(object sender, EventArgs e)
    {
      this.hidden = true;
      this.DisposeCaret();
    }

    public void UpdateCaretPosition()
    {
      if (this.textArea.MotherTextAreaControl.TextEditorProperties.LineViewerStyle == LineViewerStyle.FullRow && this.oldLine != this.line)
      {
        this.textArea.UpdateLine(this.oldLine);
        this.textArea.UpdateLine(this.line);
      }
      this.oldLine = this.line;
      if (this.hidden || this.textArea.MotherTextEditorControl.IsUpdating)
        return;
      if (!Caret.caretCreated)
        this.CreateCaret();
      if (!Caret.caretCreated)
        return;
      this.ValidateCaretPos();
      int drawingXpos = this.textArea.TextView.GetDrawingXPos(this.line, this.column);
      Point screenPosition = this.ScreenPosition;
      if (drawingXpos >= 0 && !Caret.SetCaretPos(screenPosition.X, screenPosition.Y))
      {
        Caret.DestroyCaret();
        Caret.caretCreated = false;
        this.UpdateCaretPosition();
      }
      if (this.ime == null)
      {
        this.ime = new Ime(this.textArea.Handle, this.textArea.Document.TextEditorProperties.Font);
      }
      else
      {
        this.ime.HWnd = this.textArea.Handle;
        this.ime.Font = this.textArea.Document.TextEditorProperties.Font;
      }
      this.ime.SetIMEWindowLocation(screenPosition.X, screenPosition.Y);
      this.currentPos = screenPosition;
    }

    [DllImport("User32.dll")]
    private static extern bool CreateCaret(IntPtr hWnd, int hBitmap, int nWidth, int nHeight);

    [DllImport("User32.dll")]
    private static extern bool SetCaretPos(int x, int y);

    [DllImport("User32.dll")]
    private static extern bool DestroyCaret();

    [DllImport("User32.dll")]
    private static extern bool ShowCaret(IntPtr hWnd);

    [DllImport("User32.dll")]
    private static extern bool HideCaret(IntPtr hWnd);

    protected virtual void OnPositionChanged(EventArgs e)
    {
      List<FoldMarker> foldingsFromPosition = this.textArea.Document.FoldingManager.GetFoldingsFromPosition(this.line, this.column);
      bool flag = false;
      foreach (FoldMarker foldMarker in foldingsFromPosition)
      {
        flag |= foldMarker.IsFolded;
        foldMarker.IsFolded = false;
      }
      if (flag)
        this.textArea.Document.FoldingManager.NotifyFoldingsChanged(EventArgs.Empty);
      if (this.PositionChanged != null)
        this.PositionChanged((object) this, e);
      this.textArea.ScrollToCaret();
    }

    protected virtual void OnCaretModeChanged(EventArgs e)
    {
      if (this.CaretModeChanged != null)
        this.CaretModeChanged((object) this, e);
      Caret.HideCaret(this.textArea.Handle);
      Caret.DestroyCaret();
      Caret.caretCreated = false;
      this.CreateCaret();
      Caret.ShowCaret(this.textArea.Handle);
    }
  }
}
