// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Gui.CompletionWindow.AbstractCompletionWindow
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Gui.CompletionWindow
{
  public abstract class AbstractCompletionWindow : Form
  {
    protected TextEditorControl control;
    protected string fileName;
    protected Size drawingSize;
    private Rectangle workingScreen;
    private Form parentForm;
    private static int shadowStatus;

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        AbstractCompletionWindow.AddShadowToWindow(createParams);
        return createParams;
      }
    }

    protected override bool ShowWithoutActivation
    {
      get
      {
        return true;
      }
    }

    protected AbstractCompletionWindow(Form parentForm, TextEditorControl control, string fileName)
    {
      this.workingScreen = Screen.GetWorkingArea((Control) parentForm);
      this.parentForm = parentForm;
      this.control = control;
      this.fileName = fileName;
      this.SetLocation();
      this.StartPosition = FormStartPosition.Manual;
      this.FormBorderStyle = FormBorderStyle.None;
      this.ShowInTaskbar = false;
      this.Size = new Size(1, 1);
    }

    protected virtual void SetLocation()
    {
      TextArea textArea = this.control.ActiveTextAreaControl.TextArea;
      Point position = textArea.Caret.Position;
      int drawingXpos = textArea.TextView.GetDrawingXPos(position.Y, position.X);
      int num = textArea.TextEditorProperties.ShowHorizontalRuler ? textArea.TextView.FontHeight : 0;
      Rectangle rect = new Rectangle(this.control.ActiveTextAreaControl.PointToScreen(new Point(textArea.TextView.DrawingPosition.X + drawingXpos, textArea.TextView.DrawingPosition.Y + textArea.Document.GetVisibleLine(position.Y) * textArea.TextView.FontHeight - textArea.TextView.TextArea.VirtualTop.Y + textArea.TextView.FontHeight + num)), this.drawingSize);
      if (!this.workingScreen.Contains(rect))
      {
        if (rect.Right > this.workingScreen.Right)
          rect.X = this.workingScreen.Right - rect.Width;
        if (rect.Left < this.workingScreen.Left)
          rect.X = this.workingScreen.Left;
        if (rect.Top < this.workingScreen.Top)
          rect.Y = this.workingScreen.Top;
        if (rect.Bottom > this.workingScreen.Bottom)
        {
          rect.Y = rect.Y - rect.Height - this.control.ActiveTextAreaControl.TextArea.TextView.FontHeight;
          if (rect.Bottom > this.workingScreen.Bottom)
            rect.Y = this.workingScreen.Bottom - rect.Height;
        }
      }
      this.Bounds = rect;
    }

    public static void AddShadowToWindow(CreateParams createParams)
    {
      if (AbstractCompletionWindow.shadowStatus == 0)
      {
        AbstractCompletionWindow.shadowStatus = -1;
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
          Version version = Environment.OSVersion.Version;
          if (version.Major > 5 || version.Major == 5 && version.Minor >= 1)
            AbstractCompletionWindow.shadowStatus = 1;
        }
      }
      if (AbstractCompletionWindow.shadowStatus != 1)
        return;
      createParams.ClassStyle |= 131072;
    }

    protected void ShowCompletionWindow()
    {
      this.Owner = this.parentForm;
      this.Enabled = true;
      this.Show();
      this.control.Focus();
      if (this.parentForm != null)
        this.parentForm.LocationChanged += new EventHandler(this.ParentFormLocationChanged);
      this.control.ActiveTextAreaControl.VScrollBar.ValueChanged += new EventHandler(this.ParentFormLocationChanged);
      this.control.ActiveTextAreaControl.HScrollBar.ValueChanged += new EventHandler(this.ParentFormLocationChanged);
      this.control.ActiveTextAreaControl.TextArea.DoProcessDialogKey += new DialogKeyProcessor(this.ProcessTextAreaKey);
      this.control.ActiveTextAreaControl.Caret.PositionChanged += new EventHandler(this.CaretOffsetChanged);
      this.control.ActiveTextAreaControl.TextArea.LostFocus += new EventHandler(this.TextEditorLostFocus);
      this.control.Resize += new EventHandler(this.ParentFormLocationChanged);
    }

    private void ParentFormLocationChanged(object sender, EventArgs e)
    {
      this.SetLocation();
    }

    public virtual bool ProcessKeyEvent(char ch)
    {
      return false;
    }

    protected virtual bool ProcessTextAreaKey(Keys keyData)
    {
      if (!this.Visible || keyData != Keys.Escape)
        return false;
      this.Close();
      return true;
    }

    protected virtual void CaretOffsetChanged(object sender, EventArgs e)
    {
    }

    protected void TextEditorLostFocus(object sender, EventArgs e)
    {
      if (this.control.ActiveTextAreaControl.TextArea.Focused || this.ContainsFocus)
        return;
      this.Close();
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      this.parentForm.LocationChanged -= new EventHandler(this.ParentFormLocationChanged);
      this.control.ActiveTextAreaControl.VScrollBar.ValueChanged -= new EventHandler(this.ParentFormLocationChanged);
      this.control.ActiveTextAreaControl.HScrollBar.ValueChanged -= new EventHandler(this.ParentFormLocationChanged);
      this.control.ActiveTextAreaControl.TextArea.LostFocus -= new EventHandler(this.TextEditorLostFocus);
      this.control.ActiveTextAreaControl.Caret.PositionChanged -= new EventHandler(this.CaretOffsetChanged);
      this.control.ActiveTextAreaControl.TextArea.DoProcessDialogKey -= new DialogKeyProcessor(this.ProcessTextAreaKey);
      this.control.Resize -= new EventHandler(this.ParentFormLocationChanged);
      this.Dispose();
    }
  }
}
