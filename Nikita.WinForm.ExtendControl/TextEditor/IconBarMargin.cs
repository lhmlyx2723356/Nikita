// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.IconBarMargin
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public class IconBarMargin : AbstractMargin
  {
    private static readonly Size iconBarSize = new Size(18, -1);
    private const int iconBarWidth = 18;

    public override Size Size
    {
      get
      {
        return IconBarMargin.iconBarSize;
      }
    }

    public override bool IsVisible
    {
      get
      {
        return this.textArea.TextEditorProperties.IsIconBarVisible;
      }
    }

    public IconBarMargin(TextArea textArea)
      : base(textArea)
    {
    }

    public override void Paint(Graphics g, Rectangle rect)
    {
      if (rect.Width <= 0 || rect.Height <= 0)
        return;
      g.FillRectangle(SystemBrushes.Control, new Rectangle(this.drawingPosition.X, rect.Top, this.drawingPosition.Width - 1, rect.Height));
      g.DrawLine(SystemPens.ControlDark, this.drawingPosition.Right - 1, rect.Top, this.drawingPosition.Right - 1, rect.Bottom);
      foreach (Bookmark bookmark in this.textArea.Document.BookmarkManager.Marks)
      {
        int visibleLine = this.textArea.Document.GetVisibleLine(bookmark.LineNumber);
        int y = visibleLine * this.textArea.TextView.FontHeight - this.textArea.VirtualTop.Y;
        if (y >= rect.Y && y <= rect.Bottom && visibleLine != this.textArea.Document.GetVisibleLine(bookmark.LineNumber - 1))
          bookmark.Draw(this, g, new Point(0, y));
      }
      base.Paint(g, rect);
    }

    public override void HandleMouseDown(Point mousePos, MouseButtons mouseButtons)
    {
      List<Bookmark> marks = this.textArea.Document.BookmarkManager.Marks;
      int count = marks.Count;
      foreach (Bookmark bookmark in marks)
      {
        int visibleLine = this.textArea.Document.GetVisibleLine(bookmark.LineNumber);
        int fontHeight = this.textArea.TextView.FontHeight;
        int num = visibleLine * fontHeight - this.textArea.VirtualTop.Y;
        if (mousePos.Y >= num && mousePos.Y < num + fontHeight)
        {
          bookmark.Click((Control) this.textArea, new MouseEventArgs(mouseButtons, 1, mousePos.X, mousePos.Y, 0));
          if (count == marks.Count)
            return;
          this.textArea.UpdateLine(visibleLine);
          return;
        }
      }
      base.HandleMouseDown(mousePos, mouseButtons);
    }

    public void DrawBreakpoint(Graphics g, int y, bool isEnabled)
    {
      int num = Math.Min(16, this.textArea.TextView.FontHeight);
      Rectangle rect = new Rectangle(1, y + (this.textArea.TextView.FontHeight - num) / 2, num, num);
      using (GraphicsPath path = new GraphicsPath())
      {
        path.AddEllipse(rect);
        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
        {
          pathGradientBrush.CenterPoint = new PointF((float) (rect.Left + rect.Width / 3), (float) (rect.Top + rect.Height / 3));
          pathGradientBrush.CenterColor = Color.MistyRose;
          Color[] colorArray = new Color[1]
          {
            Color.Firebrick
          };
          pathGradientBrush.SurroundColors = colorArray;
          if (isEnabled)
          {
            g.FillEllipse((Brush) pathGradientBrush, rect);
          }
          else
          {
            g.FillEllipse(SystemBrushes.Control, rect);
            using (Pen pen = new Pen((Brush) pathGradientBrush))
              g.DrawEllipse(pen, new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2));
          }
        }
      }
    }

    public void DrawBookmark(Graphics g, int y, bool isEnabled)
    {
      int num = this.textArea.TextView.FontHeight / 8;
      Rectangle r = new Rectangle(1, y + num, this.drawingPosition.Width - 4, this.textArea.TextView.FontHeight - num * 2);
      if (isEnabled)
      {
        using (Brush b = (Brush) new LinearGradientBrush(new Point(r.Left, r.Top), new Point(r.Right, r.Bottom), Color.SkyBlue, Color.White))
          this.FillRoundRect(g, b, r);
      }
      else
        this.FillRoundRect(g, Brushes.White, r);
      using (Brush brush = (Brush) new LinearGradientBrush(new Point(r.Left, r.Top), new Point(r.Right, r.Bottom), Color.SkyBlue, Color.Blue))
      {
        using (Pen p = new Pen(brush))
          this.DrawRoundRect(g, p, r);
      }
    }

    public void DrawArrow(Graphics g, int y)
    {
      int num = this.textArea.TextView.FontHeight / 8;
      Rectangle r = new Rectangle(1, y + num, this.drawingPosition.Width - 4, this.textArea.TextView.FontHeight - num * 2);
      using (Brush b = (Brush) new LinearGradientBrush(new Point(r.Left, r.Top), new Point(r.Right, r.Bottom), Color.LightYellow, Color.Yellow))
        this.FillArrow(g, b, r);
      using (Brush brush = (Brush) new LinearGradientBrush(new Point(r.Left, r.Top), new Point(r.Right, r.Bottom), Color.Yellow, Color.Brown))
      {
        using (Pen p = new Pen(brush))
          this.DrawArrow(g, p, r);
      }
    }

    private GraphicsPath CreateArrowGraphicsPath(Rectangle r)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      int num1 = r.Width / 2;
      int num2 = r.Height / 2;
      graphicsPath.AddLine(r.X, r.Y + num2 / 2, r.X + num1, r.Y + num2 / 2);
      graphicsPath.AddLine(r.X + num1, r.Y + num2 / 2, r.X + num1, r.Y);
      graphicsPath.AddLine(r.X + num1, r.Y, r.Right, r.Y + num2);
      graphicsPath.AddLine(r.Right, r.Y + num2, r.X + num1, r.Bottom);
      graphicsPath.AddLine(r.X + num1, r.Bottom, r.X + num1, r.Bottom - num2 / 2);
      graphicsPath.AddLine(r.X + num1, r.Bottom - num2 / 2, r.X, r.Bottom - num2 / 2);
      graphicsPath.AddLine(r.X, r.Bottom - num2 / 2, r.X, r.Y + num2 / 2);
      graphicsPath.CloseFigure();
      return graphicsPath;
    }

    private GraphicsPath CreateRoundRectGraphicsPath(Rectangle r)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      int num = r.Width / 2;
      graphicsPath.AddLine(r.X + num, r.Y, r.Right - num, r.Y);
      graphicsPath.AddArc(r.Right - num, r.Y, num, num, 270f, 90f);
      graphicsPath.AddLine(r.Right, r.Y + num, r.Right, r.Bottom - num);
      graphicsPath.AddArc(r.Right - num, r.Bottom - num, num, num, 0.0f, 90f);
      graphicsPath.AddLine(r.Right - num, r.Bottom, r.X + num, r.Bottom);
      graphicsPath.AddArc(r.X, r.Bottom - num, num, num, 90f, 90f);
      graphicsPath.AddLine(r.X, r.Bottom - num, r.X, r.Y + num);
      graphicsPath.AddArc(r.X, r.Y, num, num, 180f, 90f);
      graphicsPath.CloseFigure();
      return graphicsPath;
    }

    private void DrawRoundRect(Graphics g, Pen p, Rectangle r)
    {
      using (GraphicsPath rectGraphicsPath = this.CreateRoundRectGraphicsPath(r))
        g.DrawPath(p, rectGraphicsPath);
    }

    private void FillRoundRect(Graphics g, Brush b, Rectangle r)
    {
      using (GraphicsPath rectGraphicsPath = this.CreateRoundRectGraphicsPath(r))
        g.FillPath(b, rectGraphicsPath);
    }

    private void DrawArrow(Graphics g, Pen p, Rectangle r)
    {
      using (GraphicsPath arrowGraphicsPath = this.CreateArrowGraphicsPath(r))
        g.DrawPath(p, arrowGraphicsPath);
    }

    private void FillArrow(Graphics g, Brush b, Rectangle r)
    {
      using (GraphicsPath arrowGraphicsPath = this.CreateArrowGraphicsPath(r))
        g.FillPath(b, arrowGraphicsPath);
    }
  }
}
