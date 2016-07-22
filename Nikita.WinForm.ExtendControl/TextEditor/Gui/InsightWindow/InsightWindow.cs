// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Gui.InsightWindow.InsightWindow
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Gui.CompletionWindow;
using Nikita.WinForm.ExtendControl.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Gui.InsightWindow
{
  public class InsightWindow : AbstractCompletionWindow
  {
    private Stack<InsightWindow.InsightDataProviderStackElement> insightDataProviderStack = new Stack<InsightWindow.InsightDataProviderStackElement>();

    private int CurrentData
    {
      get
      {
        return this.insightDataProviderStack.Peek().currentData;
      }
      set
      {
        this.insightDataProviderStack.Peek().currentData = value;
      }
    }

    private IInsightDataProvider DataProvider
    {
      get
      {
        if (this.insightDataProviderStack.Count == 0)
          return (IInsightDataProvider) null;
        return this.insightDataProviderStack.Peek().dataProvider;
      }
    }

    public InsightWindow(Form parentForm, TextEditorControl control, string fileName)
      : base(parentForm, control, fileName)
    {
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    }

    public void ShowInsightWindow()
    {
      if (!this.Visible)
      {
        if (this.insightDataProviderStack.Count <= 0)
          return;
        this.ShowCompletionWindow();
      }
      else
        this.Refresh();
    }

    protected override bool ProcessTextAreaKey(Keys keyData)
    {
      if (!this.Visible)
        return false;
      switch (keyData)
      {
        case Keys.Up:
          if (this.DataProvider != null && this.DataProvider.InsightDataCount > 0)
          {
            this.CurrentData = (this.CurrentData + this.DataProvider.InsightDataCount - 1) % this.DataProvider.InsightDataCount;
            this.Refresh();
          }
          return true;
        case Keys.Down:
          if (this.DataProvider != null && this.DataProvider.InsightDataCount > 0)
          {
            this.CurrentData = (this.CurrentData + 1) % this.DataProvider.InsightDataCount;
            this.Refresh();
          }
          return true;
        default:
          return base.ProcessTextAreaKey(keyData);
      }
    }

    protected override void CaretOffsetChanged(object sender, EventArgs e)
    {
      Point position = this.control.ActiveTextAreaControl.Caret.Position;
      int y1 = position.Y;
      int fontHeight = this.control.ActiveTextAreaControl.TextArea.TextView.FontHeight;
      int y2 = this.control.ActiveTextAreaControl.TextArea.VirtualTop.Y;
      int y3 = this.control.ActiveTextAreaControl.TextArea.TextView.DrawingPosition.Y;
      Point point = this.control.ActiveTextAreaControl.PointToScreen(new Point(this.control.ActiveTextAreaControl.TextArea.TextView.GetDrawingXPos(position.Y, position.X), (this.control.ActiveTextAreaControl.Document.GetVisibleLine(position.Y) + 1) * this.control.ActiveTextAreaControl.TextArea.TextView.FontHeight - this.control.ActiveTextAreaControl.TextArea.VirtualTop.Y + (this.control.TextEditorProperties.ShowHorizontalRuler ? this.control.ActiveTextAreaControl.TextArea.TextView.FontHeight : 0)));
      if (point.Y != this.Location.Y)
        this.Location = point;
      while (this.DataProvider != null && this.DataProvider.CaretOffsetChanged())
        this.CloseCurrentDataProvider();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      this.control.ActiveTextAreaControl.TextArea.Focus();
      if (TipPainterTools.DrawingRectangle1.Contains(e.X, e.Y))
      {
        this.CurrentData = (this.CurrentData + this.DataProvider.InsightDataCount - 1) % this.DataProvider.InsightDataCount;
        this.Refresh();
      }
      if (!TipPainterTools.DrawingRectangle2.Contains(e.X, e.Y))
        return;
      this.CurrentData = (this.CurrentData + 1) % this.DataProvider.InsightDataCount;
      this.Refresh();
    }

    public void HandleMouseWheel(MouseEventArgs e)
    {
      if (this.DataProvider == null || this.DataProvider.InsightDataCount <= 0)
        return;
      if (e.Delta > 0)
        this.CurrentData = !this.control.TextEditorProperties.MouseWheelScrollDown ? (this.CurrentData + this.DataProvider.InsightDataCount - 1) % this.DataProvider.InsightDataCount : (this.CurrentData + 1) % this.DataProvider.InsightDataCount;
      if (e.Delta < 0)
        this.CurrentData = !this.control.TextEditorProperties.MouseWheelScrollDown ? (this.CurrentData + 1) % this.DataProvider.InsightDataCount : (this.CurrentData + this.DataProvider.InsightDataCount - 1) % this.DataProvider.InsightDataCount;
      this.Refresh();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      string countMessage = (string) null;
      string description;
      if (this.DataProvider == null || this.DataProvider.InsightDataCount < 1)
      {
        description = "Unknown Method";
      }
      else
      {
        if (this.DataProvider.InsightDataCount > 1)
          countMessage = this.control.GetRangeDescription(this.CurrentData + 1, this.DataProvider.InsightDataCount);
        description = this.DataProvider.GetInsightData(this.CurrentData);
      }
      this.drawingSize = TipPainterTools.GetDrawingSizeHelpTipFromCombinedDescription((Control) this, pe.Graphics, this.Font, countMessage, description);
      if (this.drawingSize != this.Size)
        this.SetLocation();
      else
        TipPainterTools.DrawHelpTipFromCombinedDescription((Control) this, pe.Graphics, this.Font, countMessage, description);
    }

    protected override void OnPaintBackground(PaintEventArgs pe)
    {
      pe.Graphics.FillRectangle(SystemBrushes.Info, pe.ClipRectangle);
    }

    public void AddInsightDataProvider(IInsightDataProvider provider)
    {
      provider.SetupDataProvider(this.fileName, this.control.ActiveTextAreaControl.TextArea);
      if (provider.InsightDataCount <= 0)
        return;
      this.insightDataProviderStack.Push(new InsightWindow.InsightDataProviderStackElement(provider));
    }

    private void CloseCurrentDataProvider()
    {
      this.insightDataProviderStack.Pop();
      if (this.insightDataProviderStack.Count == 0)
        this.Close();
      else
        this.Refresh();
    }

    private class InsightDataProviderStackElement
    {
      public int currentData;
      public IInsightDataProvider dataProvider;

      public InsightDataProviderStackElement(IInsightDataProvider dataProvider)
      {
        this.currentData = Math.Max(dataProvider.DefaultIndex, 0);
        this.dataProvider = dataProvider;
      }
    }
  }
}
