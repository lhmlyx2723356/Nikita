// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Gui.CompletionWindow.DeclarationViewWindow
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Gui.CompletionWindow
{
  public class DeclarationViewWindow : Form, IDeclarationViewWindow
  {
    private string description = string.Empty;
    public bool HideOnClick;

    public string Description
    {
      get
      {
        return this.description;
      }
      set
      {
        this.description = value;
        if (value == null && this.Visible)
        {
          this.Visible = false;
        }
        else
        {
          if (value == null)
            return;
          if (!this.Visible)
            this.ShowDeclarationViewWindow();
          this.Refresh();
        }
      }
    }

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

    public DeclarationViewWindow(Form parent)
    {
      this.SetStyle(ControlStyles.Selectable, false);
      this.StartPosition = FormStartPosition.Manual;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Owner = parent;
      this.ShowInTaskbar = false;
      this.Size = new Size(0, 0);
      this.CreateHandle();
    }

    protected override void OnClick(EventArgs e)
    {
      base.OnClick(e);
      if (!this.HideOnClick)
        return;
      this.Hide();
    }

    public void ShowDeclarationViewWindow()
    {
      this.Show();
    }

    public void CloseDeclarationViewWindow()
    {
      this.Close();
      this.Dispose();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      if (this.description == null || this.description.Length <= 0)
        return;
      TipPainterTools.DrawHelpTipFromCombinedDescription((Control) this, pe.Graphics, this.Font, (string) null, this.description);
    }

    protected override void OnPaintBackground(PaintEventArgs pe)
    {
      pe.Graphics.FillRectangle(SystemBrushes.Info, pe.ClipRectangle);
    }
  }
}
