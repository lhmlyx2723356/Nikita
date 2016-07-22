// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextAreaControl
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  [ToolboxItem(false)]
  public class TextAreaControl : Panel
  {
    private VScrollBar vScrollBar = new VScrollBar();
    private HScrollBar hScrollBar = new HScrollBar();
    private bool doHandleMousewheel = true;
    private int scrollMarginHeight = 3;
    private TextEditorControl motherTextEditorControl;
    private HRuler hRuler;
    private TextArea textArea;
    private bool disposed;

    public TextArea TextArea
    {
      get
      {
        return this.textArea;
      }
    }

    public SelectionManager SelectionManager
    {
      get
      {
        return this.textArea.SelectionManager;
      }
    }

    public Caret Caret
    {
      get
      {
        return this.textArea.Caret;
      }
    }

    [Browsable(false)]
    public IDocument Document
    {
      get
      {
        if (this.motherTextEditorControl != null)
          return this.motherTextEditorControl.Document;
        return (IDocument) null;
      }
    }

    public ITextEditorProperties TextEditorProperties
    {
      get
      {
        if (this.motherTextEditorControl != null)
          return this.motherTextEditorControl.TextEditorProperties;
        return (ITextEditorProperties) null;
      }
    }

    public VScrollBar VScrollBar
    {
      get
      {
        return this.vScrollBar;
      }
    }

    public HScrollBar HScrollBar
    {
      get
      {
        return this.hScrollBar;
      }
    }

    public bool DoHandleMousewheel
    {
      get
      {
        return this.doHandleMousewheel;
      }
      set
      {
        this.doHandleMousewheel = value;
      }
    }

    public TextAreaControl(TextEditorControl motherTextEditorControl)
    {
      this.motherTextEditorControl = motherTextEditorControl;
      this.textArea = new TextArea(motherTextEditorControl, this);
      this.Controls.Add((Control) this.textArea);
      this.vScrollBar.ValueChanged += new EventHandler(this.VScrollBarValueChanged);
      this.Controls.Add((Control) this.vScrollBar);
      this.hScrollBar.ValueChanged += new EventHandler(this.HScrollBarValueChanged);
      this.Controls.Add((Control) this.hScrollBar);
      this.ResizeRedraw = true;
      this.Document.DocumentChanged += new DocumentEventHandler(this.AdjustScrollBars);
      this.SetStyle(ControlStyles.Selectable, true);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && !this.disposed)
      {
        this.disposed = true;
        this.Document.DocumentChanged -= new DocumentEventHandler(this.AdjustScrollBars);
        this.motherTextEditorControl = (TextEditorControl) null;
        if (this.vScrollBar != null)
        {
          this.vScrollBar.Dispose();
          this.vScrollBar = (VScrollBar) null;
        }
        if (this.hScrollBar != null)
        {
          this.hScrollBar.Dispose();
          this.hScrollBar = (HScrollBar) null;
        }
        if (this.hRuler != null)
        {
          this.hRuler.Dispose();
          this.hRuler = (HRuler) null;
        }
      }
      base.Dispose(disposing);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      this.ResizeTextArea();
    }

    public void ResizeTextArea()
    {
      int y = 0;
      int num = 0;
      if (this.hRuler != null)
      {
        this.hRuler.Bounds = new Rectangle(0, 0, this.Width - SystemInformation.HorizontalScrollBarArrowWidth, this.textArea.TextView.FontHeight);
        y = this.hRuler.Bounds.Bottom;
        num = this.hRuler.Bounds.Height;
      }
      this.textArea.Bounds = new Rectangle(0, y, this.Width - SystemInformation.HorizontalScrollBarArrowWidth, this.Height - SystemInformation.VerticalScrollBarArrowHeight - num);
      this.SetScrollBarBounds();
    }

    public void SetScrollBarBounds()
    {
      this.vScrollBar.Bounds = new Rectangle(this.textArea.Bounds.Right, 0, SystemInformation.HorizontalScrollBarArrowWidth, this.Height - SystemInformation.VerticalScrollBarArrowHeight);
      this.hScrollBar.Bounds = new Rectangle(0, this.textArea.Bounds.Bottom, this.Width - SystemInformation.HorizontalScrollBarArrowWidth, SystemInformation.VerticalScrollBarArrowHeight);
    }

    public void AdjustScrollBars(object sender, DocumentEventArgs e)
    {
      this.vScrollBar.Minimum = 0;
      this.vScrollBar.Maximum = this.textArea.MaxVScrollValue;
      int val1 = 0;
      foreach (LineSegment line in this.Document.LineSegmentCollection)
      {
        if (this.Document.FoldingManager.IsLineVisible(this.Document.GetLineNumberForOffset(line.Offset)))
          val1 = Math.Max(val1, this.textArea.TextView.GetVisualColumnFast(line, line.Length));
      }
      this.hScrollBar.Minimum = 0;
      this.hScrollBar.Maximum = Math.Max(0, val1 + this.textArea.TextView.VisibleColumnCount - 1);
      this.vScrollBar.LargeChange = Math.Max(0, this.textArea.TextView.DrawingPosition.Height);
      this.vScrollBar.SmallChange = Math.Max(0, this.textArea.TextView.FontHeight);
      this.hScrollBar.LargeChange = Math.Max(0, this.textArea.TextView.VisibleColumnCount - 1);
      this.hScrollBar.SmallChange = Math.Max(0, (int) this.textArea.TextView.SpaceWidth);
    }

    public void OptionsChanged()
    {
      this.textArea.OptionsChanged();
      if (this.textArea.TextEditorProperties.ShowHorizontalRuler)
      {
        if (this.hRuler == null)
        {
          this.hRuler = new HRuler(this.textArea);
          this.Controls.Add((Control) this.hRuler);
          this.ResizeTextArea();
        }
      }
      else if (this.hRuler != null)
      {
        this.Controls.Remove((Control) this.hRuler);
        this.hRuler.Dispose();
        this.hRuler = (HRuler) null;
        this.ResizeTextArea();
      }
      this.AdjustScrollBars((object) null, (DocumentEventArgs) null);
    }

    private void VScrollBarValueChanged(object sender, EventArgs e)
    {
      this.textArea.VirtualTop = new Point(this.textArea.VirtualTop.X, this.vScrollBar.Value);
      this.textArea.Invalidate();
    }

    private void HScrollBarValueChanged(object sender, EventArgs e)
    {
      this.textArea.VirtualTop = new Point(this.hScrollBar.Value, this.textArea.VirtualTop.Y);
      this.textArea.Invalidate();
    }

    public void HandleMouseWheel(MouseEventArgs e)
    {
      if ((Control.ModifierKeys & Keys.Control) != Keys.None && this.TextEditorProperties.MouseWheelTextZoom)
      {
        if (e.Delta > 0)
          this.motherTextEditorControl.Font = new Font(this.motherTextEditorControl.Font.Name, this.motherTextEditorControl.Font.Size + 1f);
        else
          this.motherTextEditorControl.Font = new Font(this.motherTextEditorControl.Font.Name, Math.Max(6f, this.motherTextEditorControl.Font.Size - 1f));
      }
      else
      {
        int num1 = 120;
        int num2 = Math.Abs(e.Delta) / num1;
        this.vScrollBar.Value = Math.Max(this.vScrollBar.Minimum, Math.Min(this.vScrollBar.Maximum, SystemInformation.MouseWheelScrollLines <= 0 ? this.vScrollBar.Value - (this.TextEditorProperties.MouseWheelScrollDown ? 1 : -1) * Math.Sign(e.Delta) * this.vScrollBar.LargeChange : this.vScrollBar.Value - (this.TextEditorProperties.MouseWheelScrollDown ? 1 : -1) * Math.Sign(e.Delta) * SystemInformation.MouseWheelScrollLines * this.vScrollBar.SmallChange * num2));
      }
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);
      if (!this.DoHandleMousewheel)
        return;
      this.HandleMouseWheel(e);
    }

    public void ScrollToCaret()
    {
      int num1 = this.hScrollBar.Value - this.hScrollBar.Minimum;
      int num2 = num1 + this.textArea.TextView.VisibleColumnCount;
      int visualColumn = this.textArea.TextView.GetVisualColumn(this.textArea.Caret.Line, this.textArea.Caret.Column);
      if (this.textArea.TextView.VisibleColumnCount < 0)
        this.hScrollBar.Value = 0;
      else if (visualColumn < num1)
        this.hScrollBar.Value = Math.Max(0, visualColumn - this.scrollMarginHeight);
      else if (visualColumn > num2)
        this.hScrollBar.Value = Math.Max(0, Math.Min(this.hScrollBar.Maximum, visualColumn - this.textArea.TextView.VisibleColumnCount + this.scrollMarginHeight));
      this.ScrollTo(this.textArea.Caret.Line);
    }

    public void ScrollTo(int line)
    {
      line = Math.Max(0, Math.Min(this.Document.TotalNumberOfLines - 1, line));
      line = this.Document.GetVisibleLine(line);
      int firstPhysicalLine = this.textArea.TextView.FirstPhysicalLine;
      if (this.textArea.TextView.LineHeightRemainder > 0)
        ++firstPhysicalLine;
      if (line - this.scrollMarginHeight + 3 < firstPhysicalLine)
      {
        this.vScrollBar.Value = Math.Max(0, Math.Min(this.vScrollBar.Maximum, (line - this.scrollMarginHeight + 3) * this.textArea.TextView.FontHeight));
        this.VScrollBarValueChanged((object) this, EventArgs.Empty);
      }
      else
      {
        int num = firstPhysicalLine + this.textArea.TextView.VisibleLineCount;
        if (line + this.scrollMarginHeight - 1 <= num)
          return;
        if (this.textArea.TextView.VisibleLineCount == 1)
          this.vScrollBar.Value = Math.Max(0, Math.Min(this.vScrollBar.Maximum, (line - this.scrollMarginHeight - 1) * this.textArea.TextView.FontHeight));
        else
          this.vScrollBar.Value = Math.Min(this.vScrollBar.Maximum, (line - this.textArea.TextView.VisibleLineCount + this.scrollMarginHeight - 1) * this.textArea.TextView.FontHeight);
        this.VScrollBarValueChanged((object) this, EventArgs.Empty);
      }
    }

    public void JumpTo(int line, int column)
    {
      this.textArea.Focus();
      this.textArea.SelectionManager.ClearSelection();
      this.textArea.Caret.Position = new Point(column, line);
      this.textArea.SetDesiredColumn();
      this.ScrollToCaret();
    }
  }
}
