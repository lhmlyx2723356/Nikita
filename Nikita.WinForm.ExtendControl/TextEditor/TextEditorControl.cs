// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextEditorControl
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  [ToolboxItem(true)]
  [ToolboxBitmap("Nikita.WinForm.ExtendControl.TextEditor.Resources.TextEditorControl.bmp")]
  public class TextEditorControl : TextEditorControlBase
  {
    protected Panel textAreaPanel = new Panel();
    private TextAreaControl primaryTextArea;
    private Splitter textAreaSplitter;
    private TextAreaControl secondaryTextArea;
    private PrintDocument printDocument;
    private int curLineNr;
    private float curTabIndent;
    private StringFormat printingStringFormat;

    public PrintDocument PrintDocument
    {
      get
      {
        if (this.printDocument == null)
        {
          this.printDocument = new PrintDocument();
          this.printDocument.BeginPrint += new PrintEventHandler(this.BeginPrint);
          this.printDocument.PrintPage += new PrintPageEventHandler(this.PrintPage);
        }
        return this.printDocument;
      }
    }

    public override TextAreaControl ActiveTextAreaControl
    {
      get
      {
        return this.primaryTextArea;
      }
    }

    public bool EnableUndo
    {
      get
      {
        return this.Document.UndoStack.CanUndo;
      }
    }

    public bool EnableRedo
    {
      get
      {
        return this.Document.UndoStack.CanRedo;
      }
    }

    public TextEditorControl()
    {
      this.SetStyle(ControlStyles.ContainerControl, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.textAreaPanel.Dock = DockStyle.Fill;
      this.Document = new DocumentFactory().CreateDocument();
      this.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy();
      this.primaryTextArea = new TextAreaControl(this);
      this.primaryTextArea.Dock = DockStyle.Fill;
      this.textAreaPanel.Controls.Add((Control) this.primaryTextArea);
      this.InitializeTextAreaControl(this.primaryTextArea);
      this.Controls.Add((Control) this.textAreaPanel);
      this.ResizeRedraw = true;
      this.Document.UpdateCommited += new EventHandler(this.CommitUpdateRequested);
      this.OptionsChanged();
    }

    protected virtual void InitializeTextAreaControl(TextAreaControl newControl)
    {
    }

    public override void OptionsChanged()
    {
      this.primaryTextArea.OptionsChanged();
      if (this.secondaryTextArea == null)
        return;
      this.secondaryTextArea.OptionsChanged();
    }

    public void Split()
    {
      if (this.secondaryTextArea == null)
      {
        this.secondaryTextArea = new TextAreaControl(this);
        this.secondaryTextArea.Dock = DockStyle.Bottom;
        this.secondaryTextArea.Height = this.Height / 2;
        this.textAreaSplitter = new Splitter();
        this.textAreaSplitter.BorderStyle = BorderStyle.FixedSingle;
        this.textAreaSplitter.Height = 8;
        this.textAreaSplitter.Dock = DockStyle.Bottom;
        this.textAreaPanel.Controls.Add((Control) this.textAreaSplitter);
        this.textAreaPanel.Controls.Add((Control) this.secondaryTextArea);
        this.InitializeTextAreaControl(this.secondaryTextArea);
        this.secondaryTextArea.OptionsChanged();
      }
      else
      {
        this.textAreaPanel.Controls.Remove((Control) this.secondaryTextArea);
        this.textAreaPanel.Controls.Remove((Control) this.textAreaSplitter);
        this.secondaryTextArea.Dispose();
        this.textAreaSplitter.Dispose();
        this.secondaryTextArea = (TextAreaControl) null;
        this.textAreaSplitter = (Splitter) null;
      }
    }

    public void Undo()
    {
      if (this.Document.ReadOnly || !this.Document.UndoStack.CanUndo)
        return;
      this.BeginUpdate();
      this.Document.UndoStack.Undo();
      this.Document.UpdateQueue.Clear();
      this.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
      this.primaryTextArea.TextArea.UpdateMatchingBracket();
      if (this.secondaryTextArea != null)
        this.secondaryTextArea.TextArea.UpdateMatchingBracket();
      this.EndUpdate();
    }

    public void Redo()
    {
      if (this.Document.ReadOnly || !this.Document.UndoStack.CanRedo)
        return;
      this.BeginUpdate();
      this.Document.UndoStack.Redo();
      this.Document.UpdateQueue.Clear();
      this.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
      this.primaryTextArea.TextArea.UpdateMatchingBracket();
      if (this.secondaryTextArea != null)
        this.secondaryTextArea.TextArea.UpdateMatchingBracket();
      this.EndUpdate();
    }

    public void SetHighlighting(string name)
    {
      this.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(name);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.printDocument != null)
        {
          this.printDocument.BeginPrint -= new PrintEventHandler(this.BeginPrint);
          this.printDocument.PrintPage -= new PrintPageEventHandler(this.PrintPage);
          this.printDocument = (PrintDocument) null;
        }
        this.Document.UndoStack.ClearAll();
        this.Document.UpdateCommited -= new EventHandler(this.CommitUpdateRequested);
        if (this.textAreaPanel != null)
        {
          if (this.secondaryTextArea != null)
          {
            this.secondaryTextArea.Dispose();
            this.textAreaSplitter.Dispose();
            this.secondaryTextArea = (TextAreaControl) null;
            this.textAreaSplitter = (Splitter) null;
          }
          if (this.primaryTextArea != null)
            this.primaryTextArea.Dispose();
          this.textAreaPanel.Dispose();
          this.textAreaPanel = (Panel) null;
        }
      }
      base.Dispose(disposing);
    }

    public override void EndUpdate()
    {
      base.EndUpdate();
      this.Document.CommitUpdate();
    }

    private void CommitUpdateRequested(object sender, EventArgs e)
    {
      if (this.IsUpdating)
        return;
      foreach (TextAreaUpdate textAreaUpdate in this.Document.UpdateQueue)
      {
        switch (textAreaUpdate.TextAreaUpdateType)
        {
          case TextAreaUpdateType.WholeTextArea:
            this.primaryTextArea.TextArea.Invalidate();
            if (this.secondaryTextArea != null)
            {
              this.secondaryTextArea.TextArea.Invalidate();
              continue;
            }
            continue;
          case TextAreaUpdateType.SingleLine:
          case TextAreaUpdateType.PositionToLineEnd:
            this.primaryTextArea.TextArea.UpdateLine(textAreaUpdate.Position.Y);
            if (this.secondaryTextArea != null)
            {
              this.secondaryTextArea.TextArea.UpdateLine(textAreaUpdate.Position.Y);
              continue;
            }
            continue;
          case TextAreaUpdateType.SinglePosition:
            this.primaryTextArea.TextArea.UpdateLine(textAreaUpdate.Position.Y, textAreaUpdate.Position.X, textAreaUpdate.Position.X);
            if (this.secondaryTextArea != null)
            {
              this.secondaryTextArea.TextArea.UpdateLine(textAreaUpdate.Position.Y, textAreaUpdate.Position.X, textAreaUpdate.Position.X);
              continue;
            }
            continue;
          case TextAreaUpdateType.PositionToEnd:
            this.primaryTextArea.TextArea.UpdateToEnd(textAreaUpdate.Position.Y);
            if (this.secondaryTextArea != null)
            {
              this.secondaryTextArea.TextArea.UpdateToEnd(textAreaUpdate.Position.Y);
              continue;
            }
            continue;
          case TextAreaUpdateType.LinesBetween:
            this.primaryTextArea.TextArea.UpdateLines(textAreaUpdate.Position.X, textAreaUpdate.Position.Y);
            if (this.secondaryTextArea != null)
            {
              this.secondaryTextArea.TextArea.UpdateLines(textAreaUpdate.Position.X, textAreaUpdate.Position.Y);
              continue;
            }
            continue;
          default:
            continue;
        }
      }
      this.Document.UpdateQueue.Clear();
      this.primaryTextArea.TextArea.Update();
      if (this.secondaryTextArea == null)
        return;
      this.secondaryTextArea.TextArea.Update();
    }

    private void BeginPrint(object sender, PrintEventArgs ev)
    {
      this.curLineNr = 0;
      this.printingStringFormat = (StringFormat) StringFormat.GenericTypographic.Clone();
      float[] tabStops = new float[100];
      for (int index = 0; index < tabStops.Length; ++index)
        tabStops[index] = (float) this.TabIndent * this.primaryTextArea.TextArea.TextView.WideSpaceWidth;
      this.printingStringFormat.SetTabStops(0.0f, tabStops);
    }

    private void Advance(ref float x, ref float y, float maxWidth, float size, float fontHeight)
    {
      if ((double) x + (double) size < (double) maxWidth)
      {
        x += size;
      }
      else
      {
        x = this.curTabIndent;
        y += fontHeight;
      }
    }

    private float MeasurePrintingHeight(Graphics g, LineSegment line, float maxWidth)
    {
      float x = 0.0f;
      float y = 0.0f;
      float height = this.Font.GetHeight(g);
      this.curTabIndent = 0.0f;
      foreach (TextWord textWord in line.Words)
      {
        switch (textWord.Type)
        {
          case TextWordType.Word:
            SizeF sizeF = g.MeasureString(textWord.Word, textWord.Font, new SizeF(maxWidth, height * 100f), this.printingStringFormat);
            this.Advance(ref x, ref y, maxWidth, sizeF.Width, height);
            continue;
          case TextWordType.Space:
            this.Advance(ref x, ref y, maxWidth, this.primaryTextArea.TextArea.TextView.SpaceWidth, height);
            continue;
          case TextWordType.Tab:
            this.Advance(ref x, ref y, maxWidth, (float) this.TabIndent * this.primaryTextArea.TextArea.TextView.WideSpaceWidth, height);
            continue;
          default:
            continue;
        }
      }
      return y + height;
    }

    private void DrawLine(Graphics g, LineSegment line, float yPos, RectangleF margin)
    {
      float x = 0.0f;
      float height = this.Font.GetHeight(g);
      this.curTabIndent = 0.0f;
      foreach (TextWord textWord in line.Words)
      {
        switch (textWord.Type)
        {
          case TextWordType.Word:
            g.DrawString(textWord.Word, textWord.Font, BrushRegistry.GetBrush(textWord.Color), x + margin.X, yPos);
            SizeF sizeF = g.MeasureString(textWord.Word, textWord.Font, new SizeF(margin.Width, height * 100f), this.printingStringFormat);
            this.Advance(ref x, ref yPos, margin.Width, sizeF.Width, height);
            continue;
          case TextWordType.Space:
            this.Advance(ref x, ref yPos, margin.Width, this.primaryTextArea.TextArea.TextView.SpaceWidth, height);
            continue;
          case TextWordType.Tab:
            this.Advance(ref x, ref yPos, margin.Width, (float) this.TabIndent * this.primaryTextArea.TextArea.TextView.WideSpaceWidth, height);
            continue;
          default:
            continue;
        }
      }
    }

    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
      Graphics graphics = ev.Graphics;
      float yPos = (float) ev.MarginBounds.Top;
      for (; this.curLineNr < this.Document.TotalNumberOfLines; ++this.curLineNr)
      {
        LineSegment lineSegment = this.Document.GetLineSegment(this.curLineNr);
        if (lineSegment.Words != null)
        {
          float num = this.MeasurePrintingHeight(graphics, lineSegment, (float) ev.MarginBounds.Width);
          if ((double) num + (double) yPos <= (double) ev.MarginBounds.Bottom)
          {
            this.DrawLine(graphics, lineSegment, yPos, (RectangleF) ev.MarginBounds);
            yPos += num;
          }
          else
            break;
        }
      }
      ev.HasMorePages = this.curLineNr < this.Document.TotalNumberOfLines;
    }
  }
}
