// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Gui.CompletionWindow.CodeCompletionWindow
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Gui.CompletionWindow
{
  public class CodeCompletionWindow : AbstractCompletionWindow
  {
    private VScrollBar vScrollBar = new VScrollBar();
    private ICompletionData[] completionData;
    private CodeCompletionListView codeCompletionListView;
    private ICompletionDataProvider dataProvider;
    private int startOffset;
    private int endOffset;
    private DeclarationViewWindow declarationViewWindow;
    private Rectangle workingScreen;

    private CodeCompletionWindow(ICompletionDataProvider completionDataProvider, ICompletionData[] completionData, Form parentForm, TextEditorControl control, string fileName)
      : base(parentForm, control, fileName)
    {
      this.dataProvider = completionDataProvider;
      this.completionData = completionData;
      this.workingScreen = Screen.GetWorkingArea(this.Location);
      this.startOffset = control.ActiveTextAreaControl.Caret.Offset + 1;
      this.endOffset = this.startOffset;
      if (completionDataProvider.PreSelection != null)
      {
        this.startOffset -= completionDataProvider.PreSelection.Length + 1;
        --this.endOffset;
      }
      this.codeCompletionListView = new CodeCompletionListView(completionData);
      this.codeCompletionListView.ImageList = completionDataProvider.ImageList;
      this.codeCompletionListView.Dock = DockStyle.Fill;
      this.codeCompletionListView.SelectedItemChanged += new EventHandler(this.CodeCompletionListViewSelectedItemChanged);
      this.codeCompletionListView.DoubleClick += new EventHandler(this.CodeCompletionListViewDoubleClick);
      this.codeCompletionListView.Click += new EventHandler(this.CodeCompletionListViewClick);
      this.Controls.Add((Control) this.codeCompletionListView);
      if (completionData.Length > 10)
      {
        this.vScrollBar.Dock = DockStyle.Right;
        this.vScrollBar.Minimum = 0;
        this.vScrollBar.Maximum = completionData.Length - 8;
        this.vScrollBar.SmallChange = 1;
        this.vScrollBar.LargeChange = 3;
        this.codeCompletionListView.FirstItemChanged += new EventHandler(this.CodeCompletionListViewFirstItemChanged);
        this.Controls.Add((Control) this.vScrollBar);
      }
      this.drawingSize = new Size(this.codeCompletionListView.ItemHeight * 10, this.codeCompletionListView.ItemHeight * Math.Min(10, completionData.Length));
      this.SetLocation();
      if (this.declarationViewWindow == null)
        this.declarationViewWindow = new DeclarationViewWindow(parentForm);
      this.SetDeclarationViewLocation();
      this.declarationViewWindow.ShowDeclarationViewWindow();
      control.Focus();
      this.CodeCompletionListViewSelectedItemChanged((object) this, EventArgs.Empty);
      if (completionDataProvider.DefaultIndex >= 0)
        this.codeCompletionListView.SelectIndex(completionDataProvider.DefaultIndex);
      if (completionDataProvider.PreSelection != null)
        this.CaretOffsetChanged((object) this, EventArgs.Empty);
      this.vScrollBar.Scroll += new ScrollEventHandler(this.DoScroll);
    }

    public static CodeCompletionWindow ShowCompletionWindow(Form parent, TextEditorControl control, string fileName, ICompletionDataProvider completionDataProvider, char firstChar)
    {
      ICompletionData[] completionData = completionDataProvider.GenerateCompletionData(fileName, control.ActiveTextAreaControl.TextArea, firstChar);
      if (completionData == null || completionData.Length == 0)
        return (CodeCompletionWindow) null;
      CodeCompletionWindow completionWindow = new CodeCompletionWindow(completionDataProvider, completionData, parent, control, fileName);
      completionWindow.ShowCompletionWindow();
      return completionWindow;
    }

    private void CodeCompletionListViewFirstItemChanged(object sender, EventArgs e)
    {
      this.vScrollBar.Value = Math.Min(this.vScrollBar.Maximum, this.codeCompletionListView.FirstItem);
    }

    private void SetDeclarationViewLocation()
    {
      Point point = (this.workingScreen.Right - this.Bounds.Right) * 2 <= this.Bounds.Left - this.workingScreen.Left ? new Point(this.Bounds.Left - this.declarationViewWindow.Width, this.Bounds.Top) : new Point(this.Bounds.Right, this.Bounds.Top);
      if (!(this.declarationViewWindow.Location != point))
        return;
      this.declarationViewWindow.Location = point;
    }

    protected override void SetLocation()
    {
      base.SetLocation();
      if (this.declarationViewWindow == null)
        return;
      this.SetDeclarationViewLocation();
    }

    public void HandleMouseWheel(MouseEventArgs e)
    {
      int num1 = 120;
      int num2 = Math.Abs(e.Delta) / num1;
      this.vScrollBar.Value = Math.Max(this.vScrollBar.Minimum, Math.Min(this.vScrollBar.Maximum, SystemInformation.MouseWheelScrollLines <= 0 ? this.vScrollBar.Value - (this.control.TextEditorProperties.MouseWheelScrollDown ? 1 : -1) * Math.Sign(e.Delta) * this.vScrollBar.LargeChange : this.vScrollBar.Value - (this.control.TextEditorProperties.MouseWheelScrollDown ? 1 : -1) * Math.Sign(e.Delta) * SystemInformation.MouseWheelScrollLines * this.vScrollBar.SmallChange * num2));
      this.DoScroll((object) this, (ScrollEventArgs) null);
    }

    private void CodeCompletionListViewSelectedItemChanged(object sender, EventArgs e)
    {
      ICompletionData selectedCompletionData = this.codeCompletionListView.SelectedCompletionData;
      if (selectedCompletionData != null && selectedCompletionData.Description != null && selectedCompletionData.Description.Length > 0)
      {
        this.declarationViewWindow.Description = selectedCompletionData.Description;
        this.SetDeclarationViewLocation();
      }
      else
        this.declarationViewWindow.Description = (string) null;
    }

    public override bool ProcessKeyEvent(char ch)
    {
      if (!char.IsLetterOrDigit(ch) && (int) ch != 95)
      {
        if ((int) ch != 32 || !this.dataProvider.InsertSpace)
          return this.InsertSelectedItem(ch);
        ++this.startOffset;
      }
      this.dataProvider.InsertSpace = false;
      ++this.endOffset;
      return base.ProcessKeyEvent(ch);
    }

    protected override void CaretOffsetChanged(object sender, EventArgs e)
    {
      int offset = this.control.ActiveTextAreaControl.Caret.Offset;
      if (offset == this.startOffset)
        return;
      if (offset < this.startOffset || offset > this.endOffset)
        this.Close();
      else
        this.codeCompletionListView.SelectItemWithStart(this.control.Document.GetText(this.startOffset, offset - this.startOffset));
    }

    protected void DoScroll(object sender, ScrollEventArgs sea)
    {
      this.codeCompletionListView.FirstItem = this.vScrollBar.Value;
      this.codeCompletionListView.Refresh();
      this.control.ActiveTextAreaControl.TextArea.Focus();
    }

    protected override bool ProcessTextAreaKey(Keys keyData)
    {
      if (!this.Visible)
        return false;
      switch (keyData)
      {
        case Keys.Back:
          --this.endOffset;
          if (this.endOffset < this.startOffset)
            this.Close();
          return false;
        case Keys.Tab:
        case Keys.Return:
          this.InsertSelectedItem(char.MinValue);
          return true;
        case Keys.Prior:
          this.codeCompletionListView.PageUp();
          return true;
        case Keys.Next:
          this.codeCompletionListView.PageDown();
          return true;
        case Keys.End:
          this.codeCompletionListView.SelectIndex(this.completionData.Length - 1);
          return true;
        case Keys.Home:
          this.codeCompletionListView.SelectIndex(0);
          return true;
        case Keys.Left:
        case Keys.Up:
          this.codeCompletionListView.SelectPrevItem();
          return true;
        case Keys.Right:
        case Keys.Down:
          this.codeCompletionListView.SelectNextItem();
          return true;
        case Keys.Delete:
          if (this.control.ActiveTextAreaControl.Caret.Offset <= this.endOffset)
            --this.endOffset;
          if (this.endOffset < this.startOffset)
            this.Close();
          return false;
        default:
          return base.ProcessTextAreaKey(keyData);
      }
    }

    private void CodeCompletionListViewDoubleClick(object sender, EventArgs e)
    {
      this.InsertSelectedItem(char.MinValue);
    }

    private void CodeCompletionListViewClick(object sender, EventArgs e)
    {
      this.control.ActiveTextAreaControl.TextArea.Focus();
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      this.Dispose();
      this.codeCompletionListView.Dispose();
      this.codeCompletionListView = (CodeCompletionListView) null;
      this.declarationViewWindow.Dispose();
      this.declarationViewWindow = (DeclarationViewWindow) null;
    }

    private bool InsertSelectedItem(char ch)
    {
      ICompletionData selectedCompletionData = this.codeCompletionListView.SelectedCompletionData;
      bool flag = false;
      if (selectedCompletionData != null)
      {
        this.control.BeginUpdate();
        if (this.endOffset - this.startOffset > 0)
          this.control.Document.Remove(this.startOffset, this.endOffset - this.startOffset);
        if (this.dataProvider.InsertSpace)
          this.control.Document.Insert(this.startOffset++, " ");
        this.control.ActiveTextAreaControl.Caret.Position = this.control.Document.OffsetToPosition(this.startOffset);
        flag = selectedCompletionData.InsertAction(this.control.ActiveTextAreaControl.TextArea, ch);
        this.control.EndUpdate();
      }
      this.Close();
      return flag;
    }
  }
}
