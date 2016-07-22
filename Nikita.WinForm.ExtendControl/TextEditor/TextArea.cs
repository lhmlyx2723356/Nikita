// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextArea
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Actions;
using Nikita.WinForm.ExtendControl.Document;
using Nikita.WinForm.ExtendControl.Gui.CompletionWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  [ToolboxItem(false)]
  public class TextArea : Control
  {
    public static bool HiddenMouseCursor = false;
    private Point virtualTop = new Point(0, 0);
    private List<BracketHighlightingSheme> bracketshemes = new List<BracketHighlightingSheme>();
    private List<AbstractMargin> leftMargins = new List<AbstractMargin>();
    private TextAreaControl motherTextAreaControl;
    private TextEditorControl motherTextEditorControl;
    private TextAreaClipboardHandler textAreaClipboardHandler;
    private bool autoClearSelection;
    private TextView textView;
    private GutterMargin gutterMargin;
    private FoldMargin foldMargin;
    private IconBarMargin iconBarMargin;
    private SelectionManager selectionManager;
    private Caret caret;
    private bool disposed;
    private AbstractMargin lastMouseInMargin;
    private static DeclarationViewWindow toolTip;
    private static string oldToolTip;
    private bool toolTipActive;
    private Rectangle toolTipRectangle;
    private AbstractMargin updateMargin;

    [Browsable(false)]
    public IList<AbstractMargin> LeftMargins
    {
      get
      {
        return (IList<AbstractMargin>) this.leftMargins.AsReadOnly();
      }
    }

    public TextEditorControl MotherTextEditorControl
    {
      get
      {
        return this.motherTextEditorControl;
      }
    }

    public TextAreaControl MotherTextAreaControl
    {
      get
      {
        return this.motherTextAreaControl;
      }
    }

    public SelectionManager SelectionManager
    {
      get
      {
        return this.selectionManager;
      }
    }

    public Caret Caret
    {
      get
      {
        return this.caret;
      }
    }

    public TextView TextView
    {
      get
      {
        return this.textView;
      }
    }

    public GutterMargin GutterMargin
    {
      get
      {
        return this.gutterMargin;
      }
    }

    public FoldMargin FoldMargin
    {
      get
      {
        return this.foldMargin;
      }
    }

    public IconBarMargin IconBarMargin
    {
      get
      {
        return this.iconBarMargin;
      }
    }

    public Encoding Encoding
    {
      get
      {
        return this.motherTextEditorControl.Encoding;
      }
    }

    public int MaxVScrollValue
    {
      get
      {
        return (this.Document.GetVisibleLine(this.Document.TotalNumberOfLines - 1) + 1 + this.TextView.VisibleLineCount * 2 / 3) * this.TextView.FontHeight;
      }
    }

    public Point VirtualTop
    {
      get
      {
        return this.virtualTop;
      }
      set
      {
        Point point = new Point(value.X, Math.Min(this.MaxVScrollValue, Math.Max(0, value.Y)));
        if (!(this.virtualTop != point))
          return;
        this.virtualTop = point;
        this.motherTextAreaControl.VScrollBar.Value = this.virtualTop.Y;
        this.Invalidate();
      }
    }

    public bool AutoClearSelection
    {
      get
      {
        return this.autoClearSelection;
      }
      set
      {
        this.autoClearSelection = value;
      }
    }

    [Browsable(false)]
    public IDocument Document
    {
      get
      {
        return this.motherTextEditorControl.Document;
      }
    }

    public TextAreaClipboardHandler ClipboardHandler
    {
      get
      {
        return this.textAreaClipboardHandler;
      }
    }

    public ITextEditorProperties TextEditorProperties
    {
      get
      {
        return this.motherTextEditorControl.TextEditorProperties;
      }
    }

    public bool EnableCutOrPaste
    {
      get
      {
        return this.motherTextAreaControl != null && (!this.TextEditorProperties.UseCustomLine || (!this.SelectionManager.HasSomethingSelected || !this.Document.CustomLineManager.IsReadOnly(this.SelectionManager.SelectionCollection[0], false)) && !this.Document.CustomLineManager.IsReadOnly(this.Caret.Line, false));
      }
    }

    private int FirstPhysicalLine
    {
      get
      {
        return this.VirtualTop.Y / this.textView.FontHeight;
      }
    }

    public event ToolTipRequestEventHandler ToolTipRequest;

    public event Nikita.WinForm.ExtendControl.Util.KeyEventHandler KeyEventHandler;

    public event DialogKeyProcessor DoProcessDialogKey;

    public TextArea(TextEditorControl motherTextEditorControl, TextAreaControl motherTextAreaControl)
    {
      this.motherTextAreaControl = motherTextAreaControl;
      this.motherTextEditorControl = motherTextEditorControl;
      this.caret = new Caret(this);
      this.selectionManager = new SelectionManager(this.Document);
      this.textAreaClipboardHandler = new TextAreaClipboardHandler(this);
      this.ResizeRedraw = true;
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.Opaque, false);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.textView = new TextView(this);
      this.gutterMargin = new GutterMargin(this);
      this.foldMargin = new FoldMargin(this);
      this.iconBarMargin = new IconBarMargin(this);
      this.leftMargins.AddRange((IEnumerable<AbstractMargin>) new AbstractMargin[3]
      {
        (AbstractMargin) this.iconBarMargin,
        (AbstractMargin) this.gutterMargin,
        (AbstractMargin) this.foldMargin
      });
      this.OptionsChanged();
      new TextAreaMouseHandler(this).Attach();
      new TextAreaDragDropHandler().Attach(this);
      this.bracketshemes.Add(new BracketHighlightingSheme('{', '}'));
      this.bracketshemes.Add(new BracketHighlightingSheme('(', ')'));
      this.bracketshemes.Add(new BracketHighlightingSheme('[', ']'));
      this.caret.PositionChanged += new EventHandler(this.SearchMatchingBracket);
      this.Document.TextContentChanged += new EventHandler(this.TextContentChanged);
      this.Document.FoldingManager.FoldingsChanged += new EventHandler(this.DocumentFoldingsChanged);
    }

    public void InsertLeftMargin(int index, AbstractMargin margin)
    {
      this.leftMargins.Insert(index, margin);
      this.Refresh();
    }

    public void UpdateMatchingBracket()
    {
      this.SearchMatchingBracket((object) null, (EventArgs) null);
    }

    private void TextContentChanged(object sender, EventArgs e)
    {
      this.Caret.Position = new Point(0, 0);
      this.SelectionManager.SelectionCollection.Clear();
    }

    private void SearchMatchingBracket(object sender, EventArgs e)
    {
      if (!this.TextEditorProperties.ShowMatchingBracket)
      {
        this.textView.Highlight = (Highlight) null;
      }
      else
      {
        bool flag = false;
        if (this.caret.Offset == 0)
        {
          if (this.textView.Highlight == null)
            return;
          int y1 = this.textView.Highlight.OpenBrace.Y;
          int y2 = this.textView.Highlight.CloseBrace.Y;
          this.textView.Highlight = (Highlight) null;
          this.UpdateLine(y1);
          this.UpdateLine(y2);
        }
        else
        {
          foreach (BracketHighlightingSheme highlightingSheme in this.bracketshemes)
          {
            Highlight highlight = highlightingSheme.GetHighlight(this.Document, this.Caret.Offset - 1);
            if (this.textView.Highlight != null && this.textView.Highlight.OpenBrace.Y >= 0 && this.textView.Highlight.OpenBrace.Y < this.Document.TotalNumberOfLines)
              this.UpdateLine(this.textView.Highlight.OpenBrace.Y);
            if (this.textView.Highlight != null && this.textView.Highlight.CloseBrace.Y >= 0 && this.textView.Highlight.CloseBrace.Y < this.Document.TotalNumberOfLines)
              this.UpdateLine(this.textView.Highlight.CloseBrace.Y);
            this.textView.Highlight = highlight;
            if (highlight != null)
            {
              flag = true;
              break;
            }
          }
          if (!flag && this.textView.Highlight == null)
            return;
          int y1 = this.textView.Highlight.OpenBrace.Y;
          int y2 = this.textView.Highlight.CloseBrace.Y;
          if (!flag)
            this.textView.Highlight = (Highlight) null;
          this.UpdateLine(y1);
          this.UpdateLine(y2);
        }
      }
    }

    public void SetDesiredColumn()
    {
      this.Caret.DesiredColumn = this.TextView.GetDrawingXPos(this.Caret.Line, this.Caret.Column) + (int) ((double) this.VirtualTop.X * (double) this.textView.WideSpaceWidth);
    }

    public void SetCaretToDesiredColumn(int caretLine)
    {
      this.Caret.Position = this.textView.GetLogicalColumn(this.Caret.Line, this.Caret.DesiredColumn + (int) ((double) this.VirtualTop.X * (double) this.textView.WideSpaceWidth));
    }

    public void OptionsChanged()
    {
      this.UpdateMatchingBracket();
      this.textView.OptionsChanged();
      this.caret.RecreateCaret();
      this.caret.UpdateCaretPosition();
      this.Refresh();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      this.Cursor = Cursors.Default;
      if (this.lastMouseInMargin != null)
      {
        this.lastMouseInMargin.HandleMouseLeave(EventArgs.Empty);
        this.lastMouseInMargin = (AbstractMargin) null;
      }
      this.CloseToolTip();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      this.CloseToolTip();
      foreach (AbstractMargin abstractMargin in this.leftMargins)
      {
        if (abstractMargin.DrawingPosition.Contains(e.X, e.Y))
          abstractMargin.HandleMouseDown(new Point(e.X, e.Y), e.Button);
      }
    }

    private void SetToolTip(string text, int lineNumber)
    {
      if (TextArea.toolTip == null || TextArea.toolTip.IsDisposed)
        TextArea.toolTip = new DeclarationViewWindow(this.FindForm());
      if (TextArea.oldToolTip == text)
        return;
      if (text == null)
      {
        TextArea.toolTip.Hide();
      }
      else
      {
        Point mousePosition = Control.MousePosition;
        Point point = this.PointToClient(mousePosition);
        if (lineNumber >= 0)
        {
          lineNumber = this.Document.GetVisibleLine(lineNumber);
          mousePosition.Y = mousePosition.Y - point.Y + lineNumber * this.TextView.FontHeight - this.virtualTop.Y;
        }
        mousePosition.Offset(3, 3);
        TextArea.toolTip.Location = mousePosition;
        TextArea.toolTip.Description = text;
        TextArea.toolTip.HideOnClick = true;
        TextArea.toolTip.Show();
      }
      TextArea.oldToolTip = text;
    }

    protected virtual void OnToolTipRequest(ToolTipRequestEventArgs e)
    {
      if (this.ToolTipRequest == null)
        return;
      this.ToolTipRequest((object) this, e);
    }

    private void CloseToolTip()
    {
      if (this.toolTipActive)
      {
        this.toolTipActive = false;
        this.SetToolTip((string) null, -1);
      }
      this.ResetMouseEventArgs();
    }

    protected override void OnMouseHover(EventArgs e)
    {
      base.OnMouseHover(e);
      if (Control.MouseButtons == MouseButtons.None)
        this.RequestToolTip(this.PointToClient(Control.MousePosition));
      else
        this.CloseToolTip();
    }

    protected void RequestToolTip(Point mousePos)
    {
      if (this.toolTipRectangle.Contains(mousePos))
      {
        if (this.toolTipActive)
          return;
        this.ResetMouseEventArgs();
      }
      else
      {
        this.toolTipRectangle = new Rectangle(mousePos.X - 4, mousePos.Y - 4, 8, 8);
        Point logicalPosition = this.textView.GetLogicalPosition(mousePos.X - this.textView.DrawingPosition.Left, mousePos.Y - this.textView.DrawingPosition.Top);
        bool inDocument = this.textView.DrawingPosition.Contains(mousePos) && logicalPosition.Y >= 0 && logicalPosition.Y < this.Document.TotalNumberOfLines;
        ToolTipRequestEventArgs e = new ToolTipRequestEventArgs(mousePos, logicalPosition, inDocument);
        this.OnToolTipRequest(e);
        if (e.ToolTipShown)
        {
          this.toolTipActive = true;
          this.SetToolTip(e.toolTipText, inDocument ? logicalPosition.Y + 1 : -1);
        }
        else
          this.CloseToolTip();
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (!this.toolTipRectangle.Contains(e.Location))
      {
        this.toolTipRectangle = Rectangle.Empty;
        if (this.toolTipActive)
          this.RequestToolTip(e.Location);
      }
      foreach (AbstractMargin abstractMargin in this.leftMargins)
      {
        if (abstractMargin.DrawingPosition.Contains(e.X, e.Y))
        {
          this.Cursor = abstractMargin.Cursor;
          abstractMargin.HandleMouseMove(new Point(e.X, e.Y), e.Button);
          if (this.lastMouseInMargin == abstractMargin)
            return;
          if (this.lastMouseInMargin != null)
            this.lastMouseInMargin.HandleMouseLeave(EventArgs.Empty);
          this.lastMouseInMargin = abstractMargin;
          return;
        }
      }
      if (this.lastMouseInMargin != null)
      {
        this.lastMouseInMargin.HandleMouseLeave(EventArgs.Empty);
        this.lastMouseInMargin = (AbstractMargin) null;
      }
      if (this.textView.DrawingPosition.Contains(e.X, e.Y))
        this.Cursor = this.textView.Cursor;
      else
        this.Cursor = Cursors.Default;
    }

    public void Refresh(AbstractMargin margin)
    {
      this.updateMargin = margin;
      this.Invalidate(this.updateMargin.DrawingPosition);
      this.Update();
      this.updateMargin = (AbstractMargin) null;
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      int x = 0;
      int y = 0;
      bool flag = false;
      Graphics graphics = e.Graphics;
      Rectangle clipRectangle = e.ClipRectangle;
      if (this.updateMargin != null)
        this.updateMargin.Paint(graphics, this.updateMargin.DrawingPosition);
      if (clipRectangle.Width <= 0 || clipRectangle.Height <= 0)
        return;
      graphics.TextRenderingHint = !this.TextEditorProperties.UseAntiAliasedFont ? TextRenderingHint.SystemDefault : TextRenderingHint.ClearTypeGridFit;
      foreach (AbstractMargin abstractMargin in this.leftMargins)
      {
        if (abstractMargin.IsVisible)
        {
          Rectangle rect = new Rectangle(x, y, abstractMargin.Size.Width, this.Height - y);
          if (rect != abstractMargin.DrawingPosition)
          {
            flag = true;
            abstractMargin.DrawingPosition = rect;
          }
          x += abstractMargin.DrawingPosition.Width;
          if (clipRectangle.IntersectsWith(rect))
          {
            rect.Intersect(clipRectangle);
            if (!rect.IsEmpty)
              abstractMargin.Paint(graphics, rect);
          }
        }
      }
      Rectangle rect1 = new Rectangle(x, y, this.Width - x, this.Height - y);
      if (rect1 != this.textView.DrawingPosition)
      {
        flag = true;
        this.textView.DrawingPosition = rect1;
      }
      if (clipRectangle.IntersectsWith(rect1))
      {
        rect1.Intersect(clipRectangle);
        if (!rect1.IsEmpty)
          this.textView.Paint(graphics, rect1);
      }
      if (flag)
        this.motherTextAreaControl.AdjustScrollBars((object) null, (DocumentEventArgs) null);
      this.Caret.UpdateCaretPosition();
      base.OnPaint(e);
    }

    private void DocumentFoldingsChanged(object sender, EventArgs e)
    {
      this.Invalidate();
      this.motherTextAreaControl.AdjustScrollBars((object) null, (DocumentEventArgs) null);
    }

    protected internal virtual bool HandleKeyPress(char ch)
    {
      if (this.KeyEventHandler != null)
        return this.KeyEventHandler(ch);
      return false;
    }

    public void SimulateKeyPress(char ch)
    {
      if (this.Document.ReadOnly)
        return;
      if (this.TextEditorProperties.UseCustomLine)
      {
        if (this.SelectionManager.HasSomethingSelected)
        {
          if (this.Document.CustomLineManager.IsReadOnly(this.SelectionManager.SelectionCollection[0], false))
            return;
        }
        else if (this.Document.CustomLineManager.IsReadOnly(this.Caret.Line, false))
          return;
      }
      if ((int) ch < 32)
        return;
      if (!TextArea.HiddenMouseCursor && this.TextEditorProperties.HideMouseCursor)
      {
        TextArea.HiddenMouseCursor = true;
        Cursor.Hide();
      }
      this.CloseToolTip();
      this.motherTextEditorControl.BeginUpdate();
      if (!this.HandleKeyPress(ch))
      {
        switch (this.Caret.CaretMode)
        {
          case CaretMode.InsertMode:
            this.InsertChar(ch);
            break;
          case CaretMode.OverwriteMode:
            this.ReplaceChar(ch);
            break;
        }
      }
      this.Document.FormattingStrategy.FormatLine(this, this.Caret.Line, this.Document.PositionToOffset(this.Caret.Position), ch);
      this.motherTextEditorControl.EndUpdate();
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      base.OnKeyPress(e);
      this.SimulateKeyPress(e.KeyChar);
      e.Handled = true;
    }

    public bool ExecuteDialogKey(Keys keyData)
    {
      if (this.DoProcessDialogKey != null && this.DoProcessDialogKey(keyData))
        return true;
      if ((keyData == Keys.Back || keyData == Keys.Delete || keyData == Keys.Return) && this.TextEditorProperties.UseCustomLine)
      {
        if (this.SelectionManager.HasSomethingSelected)
        {
          if (this.Document.CustomLineManager.IsReadOnly(this.SelectionManager.SelectionCollection[0], false))
            return true;
        }
        else
        {
          int lineNumberForOffset = this.Document.GetLineNumberForOffset(this.Caret.Offset);
          if (this.Document.CustomLineManager.IsReadOnly(lineNumberForOffset, false) || this.Caret.Column == 0 && lineNumberForOffset - 1 >= 0 && (keyData == Keys.Back && this.Document.CustomLineManager.IsReadOnly(lineNumberForOffset - 1, false)))
            return true;
          if (keyData == Keys.Delete)
          {
            LineSegment lineSegment = this.Document.GetLineSegment(lineNumberForOffset);
            if (lineSegment.Offset + lineSegment.Length == this.Caret.Offset && this.Document.CustomLineManager.IsReadOnly(lineNumberForOffset + 1, false))
              return true;
          }
        }
      }
      IEditAction editAction = this.motherTextEditorControl.GetEditAction(keyData);
      this.AutoClearSelection = true;
      if (editAction == null)
        return false;
      this.motherTextEditorControl.BeginUpdate();
      try
      {
        lock (this.Document)
        {
          editAction.Execute(this);
          if (this.SelectionManager.HasSomethingSelected)
          {
            if (this.AutoClearSelection)
            {
              if (this.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal)
                this.SelectionManager.ClearSelection();
            }
          }
        }
      }
      finally
      {
        this.motherTextEditorControl.EndUpdate();
        this.Caret.UpdateCaretPosition();
      }
      return true;
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
      if (!this.ExecuteDialogKey(keyData))
        return base.ProcessDialogKey(keyData);
      return true;
    }

    public void ScrollToCaret()
    {
      this.motherTextAreaControl.ScrollToCaret();
    }

    public void ScrollTo(int line)
    {
      this.motherTextAreaControl.ScrollTo(line);
    }

    public void BeginUpdate()
    {
      this.motherTextEditorControl.BeginUpdate();
    }

    public void EndUpdate()
    {
      this.motherTextEditorControl.EndUpdate();
    }

    private string GenerateWhitespaceString(int length)
    {
      return new string(' ', length);
    }

    public void InsertChar(char ch)
    {
      bool isUpdating = this.motherTextEditorControl.IsUpdating;
      if (!isUpdating)
        this.BeginUpdate();
      if (char.IsWhiteSpace(ch) && (int) ch != 9 && (int) ch != 10)
        ch = ' ';
      bool flag = false;
      if (this.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal && this.SelectionManager.SelectionCollection.Count > 0)
      {
        this.Caret.Position = this.SelectionManager.SelectionCollection[0].StartPosition;
        this.SelectionManager.RemoveSelectedText();
        flag = true;
      }
      LineSegment lineSegment = this.Document.GetLineSegment(this.Caret.Line);
      int offset = this.Caret.Offset;
      int num = Math.Min(this.Caret.Column, this.Caret.DesiredColumn);
      if (lineSegment.Length < num && (int) ch != 10)
        this.Document.Insert(offset, this.GenerateWhitespaceString(num - lineSegment.Length) + (object) ch);
      else
        this.Document.Insert(offset, ch.ToString());
      ++this.Caret.Column;
      if (flag)
        this.Document.UndoStack.UndoLast(2);
      if (isUpdating)
        return;
      this.EndUpdate();
      this.UpdateLineToEnd(this.Caret.Line, this.Caret.Column);
    }

    public void InsertString(string str)
    {
      bool isUpdating = this.motherTextEditorControl.IsUpdating;
      if (!isUpdating)
        this.BeginUpdate();
      try
      {
        bool flag = false;
        if (this.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal && this.SelectionManager.SelectionCollection.Count > 0)
        {
          this.Caret.Position = this.SelectionManager.SelectionCollection[0].StartPosition;
          this.SelectionManager.RemoveSelectedText();
          flag = true;
        }
        int offset = this.Document.PositionToOffset(this.Caret.Position);
        int line = this.Caret.Line;
        LineSegment lineSegment = this.Document.GetLineSegment(this.Caret.Line);
        if (lineSegment.Length < this.Caret.Column)
        {
          int length = this.Caret.Column - lineSegment.Length;
          this.Document.Insert(offset, this.GenerateWhitespaceString(length) + str);
          this.Caret.Position = this.Document.OffsetToPosition(offset + str.Length + length);
        }
        else
        {
          this.Document.Insert(offset, str);
          this.Caret.Position = this.Document.OffsetToPosition(offset + str.Length);
        }
        if (flag)
          this.Document.UndoStack.UndoLast(2);
        if (line != this.Caret.Line)
          this.UpdateToEnd(line);
        else
          this.UpdateLineToEnd(this.Caret.Line, this.Caret.Column);
      }
      finally
      {
        if (!isUpdating)
          this.EndUpdate();
      }
    }

    public void ReplaceChar(char ch)
    {
      bool isUpdating = this.motherTextEditorControl.IsUpdating;
      if (!isUpdating)
        this.BeginUpdate();
      if (this.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal && this.SelectionManager.SelectionCollection.Count > 0)
      {
        this.Caret.Position = this.SelectionManager.SelectionCollection[0].StartPosition;
        this.SelectionManager.RemoveSelectedText();
      }
      int line = this.Caret.Line;
      LineSegment lineSegment = this.Document.GetLineSegment(line);
      int offset = this.Document.PositionToOffset(this.Caret.Position);
      if (offset < lineSegment.Offset + lineSegment.Length)
        this.Document.Replace(offset, 1, ch.ToString());
      else
        this.Document.Insert(offset, ch.ToString());
      if (!isUpdating)
      {
        this.EndUpdate();
        this.UpdateLineToEnd(line, this.Caret.Column);
      }
      ++this.Caret.Column;
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing || this.disposed)
        return;
      this.disposed = true;
      if (this.caret != null)
      {
        this.caret.PositionChanged -= new EventHandler(this.SearchMatchingBracket);
        this.caret.Dispose();
      }
      if (this.selectionManager != null)
        this.selectionManager.Dispose();
      this.Document.TextContentChanged -= new EventHandler(this.TextContentChanged);
      this.Document.FoldingManager.FoldingsChanged -= new EventHandler(this.DocumentFoldingsChanged);
      this.motherTextAreaControl = (TextAreaControl) null;
      this.motherTextEditorControl = (TextEditorControl) null;
      foreach (AbstractMargin abstractMargin in this.leftMargins)
      {
        if (abstractMargin is IDisposable)
          (abstractMargin as IDisposable).Dispose();
      }
      this.textView.Dispose();
    }

    internal void UpdateLine(int line)
    {
      this.UpdateLines(0, line, line);
    }

    internal void UpdateLines(int lineBegin, int lineEnd)
    {
      this.UpdateLines(0, lineBegin, lineEnd);
    }

    internal void UpdateToEnd(int lineBegin)
    {
      lineBegin = Math.Min(lineBegin, this.FirstPhysicalLine);
      int y = Math.Max(0, Math.Max(0, lineBegin * this.textView.FontHeight) - this.virtualTop.Y);
      this.Invalidate(new Rectangle(0, y, this.Width, this.Height - y));
    }

    internal void UpdateLineToEnd(int lineNr, int xStart)
    {
      this.UpdateLines(xStart, lineNr, lineNr);
    }

    internal void UpdateLine(int line, int begin, int end)
    {
      this.UpdateLines(line, line);
    }

    internal void UpdateLines(int xPos, int lineBegin, int lineEnd)
    {
      this.InvalidateLines((int) ((double) xPos * (double) this.TextView.WideSpaceWidth), lineBegin, lineEnd);
    }

    private void InvalidateLines(int xPos, int lineBegin, int lineEnd)
    {
      lineBegin = Math.Max(this.Document.GetVisibleLine(lineBegin), this.FirstPhysicalLine);
      lineEnd = Math.Min(this.Document.GetVisibleLine(lineEnd), this.FirstPhysicalLine + this.textView.VisibleLineCount);
      this.Invalidate(new Rectangle(0, Math.Max(0, lineBegin * this.textView.FontHeight) - 1 - this.virtualTop.Y, this.Width, Math.Min(this.textView.DrawingPosition.Height, (1 + lineEnd - lineBegin) * (this.textView.FontHeight + 1)) + 3));
    }
  }
}
