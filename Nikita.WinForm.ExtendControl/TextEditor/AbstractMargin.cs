// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.AbstractMargin
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public abstract class AbstractMargin
  {
    protected Rectangle drawingPosition = new Rectangle(0, 0, 0, 0);
    protected TextArea textArea;

    public Rectangle DrawingPosition
    {
      get
      {
        return this.drawingPosition;
      }
      set
      {
        this.drawingPosition = value;
      }
    }

    public TextArea TextArea
    {
      get
      {
        return this.textArea;
      }
    }

    public IDocument Document
    {
      get
      {
        return this.textArea.Document;
      }
    }

    public ITextEditorProperties TextEditorProperties
    {
      get
      {
        return this.textArea.Document.TextEditorProperties;
      }
    }

    public virtual Cursor Cursor
    {
      get
      {
        return Cursors.Default;
      }
    }

    public virtual Size Size
    {
      get
      {
        return new Size(-1, -1);
      }
    }

    public virtual bool IsVisible
    {
      get
      {
        return true;
      }
    }

    public event MarginPaintEventHandler Painted;

    public event MarginMouseEventHandler MouseDown;

    public event MarginMouseEventHandler MouseMove;

    public event EventHandler MouseLeave;

    protected AbstractMargin(TextArea textArea)
    {
      this.textArea = textArea;
    }

    public virtual void HandleMouseDown(Point mousepos, MouseButtons mouseButtons)
    {
      if (this.MouseDown == null)
        return;
      this.MouseDown(this, mousepos, mouseButtons);
    }

    public virtual void HandleMouseMove(Point mousepos, MouseButtons mouseButtons)
    {
      if (this.MouseMove == null)
        return;
      this.MouseMove(this, mousepos, mouseButtons);
    }

    public virtual void HandleMouseLeave(EventArgs e)
    {
      if (this.MouseLeave == null)
        return;
      this.MouseLeave((object) this, e);
    }

    public virtual void Paint(Graphics g, Rectangle rect)
    {
      if (this.Painted == null)
        return;
      this.Painted(this, g, rect);
    }
  }
}
