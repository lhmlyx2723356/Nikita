// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Gui.CompletionWindow.CodeCompletionListView
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Gui.CompletionWindow
{
  public class CodeCompletionListView : UserControl
  {
    private int selectedItem = -1;
    private ICompletionData[] completionData;
    private int firstItem;
    private ImageList imageList;

    public ImageList ImageList
    {
      get
      {
        return this.imageList;
      }
      set
      {
        this.imageList = value;
      }
    }

    public int FirstItem
    {
      get
      {
        return this.firstItem;
      }
      set
      {
        this.firstItem = value;
        this.OnFirstItemChanged(EventArgs.Empty);
      }
    }

    public ICompletionData SelectedCompletionData
    {
      get
      {
        if (this.selectedItem < 0)
          return (ICompletionData) null;
        return this.completionData[this.selectedItem];
      }
    }

    public int ItemHeight
    {
      get
      {
        return Math.Max(this.imageList.ImageSize.Height, (int) ((double) this.Font.Height * 1.25));
      }
    }

    public int MaxVisibleItem
    {
      get
      {
        return this.Height / this.ItemHeight;
      }
    }

    public event EventHandler SelectedItemChanged;

    public event EventHandler FirstItemChanged;

    public CodeCompletionListView(ICompletionData[] completionData)
    {
      Array.Sort<ICompletionData>(completionData);
      this.completionData = completionData;
    }

    public void Close()
    {
      if (this.completionData != null)
        Array.Clear((Array) this.completionData, 0, this.completionData.Length);
      this.Dispose();
    }

    public void SelectIndex(int index)
    {
      int val2 = this.selectedItem;
      int num1 = this.firstItem;
      index = Math.Max(0, index);
      this.selectedItem = Math.Max(0, Math.Min(this.completionData.Length - 1, index));
      if (this.selectedItem < this.firstItem)
        this.FirstItem = this.selectedItem;
      if (this.firstItem + this.MaxVisibleItem <= this.selectedItem)
        this.FirstItem = this.selectedItem - this.MaxVisibleItem + 1;
      if (val2 == this.selectedItem)
        return;
      if (this.firstItem != num1)
      {
        this.Invalidate();
      }
      else
      {
        int num2 = Math.Min(this.selectedItem, val2) - this.firstItem;
        int num3 = Math.Max(this.selectedItem, val2) - this.firstItem;
        this.Invalidate(new Rectangle(0, 1 + num2 * this.ItemHeight, this.Width, (num3 - num2 + 1) * this.ItemHeight));
      }
      this.Update();
      this.OnSelectedItemChanged(EventArgs.Empty);
    }

    public void ClearSelection()
    {
      if (this.selectedItem < 0)
        return;
      int num = this.selectedItem - this.firstItem;
      this.selectedItem = -1;
      this.Invalidate(new Rectangle(0, num * this.ItemHeight, this.Width, (num + 1) * this.ItemHeight + 1));
      this.Update();
      this.OnSelectedItemChanged(EventArgs.Empty);
    }

    public void PageDown()
    {
      this.SelectIndex(this.selectedItem + this.MaxVisibleItem);
    }

    public void PageUp()
    {
      this.SelectIndex(this.selectedItem - this.MaxVisibleItem);
    }

    public void SelectNextItem()
    {
      this.SelectIndex(this.selectedItem + 1);
    }

    public void SelectPrevItem()
    {
      this.SelectIndex(this.selectedItem - 1);
    }

    public void SelectItemWithStart(string startText)
    {
      if (startText == null || startText.Length == 0)
        return;
      string str1 = startText;
      startText = startText.ToLower();
      int index1 = -1;
      int num1 = -1;
      double num2 = 0.0;
      for (int index2 = 0; index2 < this.completionData.Length; ++index2)
      {
        string text = this.completionData[index2].Text;
        string str2 = text.ToLower();
        if (str2.StartsWith(startText))
        {
          double priority = this.completionData[index2].Priority;
          int num3 = !(str2 == startText) ? (!text.StartsWith(str1) ? 0 : 1) : (!(text == str1) ? 2 : 3);
          if (num1 < num3 || index1 != this.selectedItem && (index2 != this.selectedItem ? num1 == num3 && num2 < priority : num1 == num3))
          {
            index1 = index2;
            num2 = priority;
            num1 = num3;
          }
        }
      }
      if (index1 < 0)
        this.ClearSelection();
      else
        this.SelectIndex(index1);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      float y = 1f;
      float height = (float) this.ItemHeight;
      int num1 = (int) ((double) height * (double) this.imageList.ImageSize.Width / (double) this.imageList.ImageSize.Height);
      int index = this.firstItem;
      Graphics graphics = pe.Graphics;
      for (; index < this.completionData.Length && (double) y < (double) this.Height; ++index)
      {
        RectangleF rect = new RectangleF(1f, y, (float) (this.Width - 2), height);
        if (rect.IntersectsWith((RectangleF) pe.ClipRectangle))
        {
          if (index == this.selectedItem)
            graphics.FillRectangle(SystemBrushes.Highlight, rect);
          else
            graphics.FillRectangle(SystemBrushes.Window, rect);
          int num2 = 0;
          if (this.imageList != null && this.completionData[index].ImageIndex < this.imageList.Images.Count)
          {
            graphics.DrawImage(this.imageList.Images[this.completionData[index].ImageIndex], new RectangleF(1f, y, (float) num1, height));
            num2 = num1;
          }
          if (index == this.selectedItem)
            graphics.DrawString(this.completionData[index].Text, this.Font, SystemBrushes.HighlightText, (float) num2, y);
          else
            graphics.DrawString(this.completionData[index].Text, this.Font, SystemBrushes.WindowText, (float) num2, y);
        }
        y += height;
      }
      graphics.DrawRectangle(SystemPens.Control, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      float y = 1f;
      int index = this.firstItem;
      float height = (float) this.ItemHeight;
      for (; index < this.completionData.Length && (double) y < (double) this.Height; ++index)
      {
        if (new RectangleF(1f, y, (float) (this.Width - 2), height).Contains((float) e.X, (float) e.Y))
        {
          this.SelectIndex(index);
          break;
        }
        y += height;
      }
    }

    protected override void OnMouseWheel(MouseEventArgs mea)
    {
      int num;
      for (num = mea.Delta * SystemInformation.MouseWheelScrollLines / 120; num > 0; --num)
        this.SelectPrevItem();
      for (; num < 0; ++num)
        this.SelectNextItem();
    }

    protected override void OnPaintBackground(PaintEventArgs pe)
    {
    }

    protected virtual void OnSelectedItemChanged(EventArgs e)
    {
      if (this.SelectedItemChanged == null)
        return;
      this.SelectedItemChanged((object) this, e);
    }

    protected virtual void OnFirstItemChanged(EventArgs e)
    {
      if (this.FirstItemChanged == null)
        return;
      this.FirstItemChanged((object) this, e);
    }
  }
}
