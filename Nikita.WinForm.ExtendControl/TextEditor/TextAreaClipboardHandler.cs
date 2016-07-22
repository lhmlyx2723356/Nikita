// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextAreaClipboardHandler
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Actions;
using Nikita.WinForm.ExtendControl.Document;
using Nikita.WinForm.ExtendControl.Util;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public class TextAreaClipboardHandler
  {
    private TextArea textArea;

    public bool EnableCut
    {
      get
      {
        return this.textArea.EnableCutOrPaste;
      }
    }

    public bool EnableCopy
    {
      get
      {
        return true;
      }
    }

    public bool EnablePaste
    {
      get
      {
        try
        {
          return Clipboard.ContainsText();
        }
        catch (ExternalException ex)
        {
          return false;
        }
      }
    }

    public bool EnableDelete
    {
      get
      {
        if (this.textArea.SelectionManager.HasSomethingSelected)
          return this.textArea.EnableCutOrPaste;
        return false;
      }
    }

    public bool EnableSelectAll
    {
      get
      {
        return true;
      }
    }

    public event CopyTextEventHandler CopyText;

    public TextAreaClipboardHandler(TextArea textArea)
    {
      this.textArea = textArea;
      textArea.SelectionManager.SelectionChanged += new EventHandler(this.DocumentSelectionChanged);
    }

    private void DocumentSelectionChanged(object sender, EventArgs e)
    {
    }

    private bool CopyTextToClipboard(string stringToCopy)
    {
      if (stringToCopy.Length <= 0)
        return false;
      DataObject dataObject = new DataObject();
      dataObject.SetData(DataFormats.UnicodeText, true, (object) stringToCopy);
      if (this.textArea.Document.HighlightingStrategy.Name != "Default")
        dataObject.SetData(DataFormats.Rtf, (object) RtfWriter.GenerateRtf(this.textArea));
      this.OnCopyText(new CopyTextEventArgs(stringToCopy));
      int num = 0;
      while (true)
      {
        try
        {
          Clipboard.SetDataObject((object) dataObject, true, 5, 50);
          return true;
        }
        catch (ExternalException ex)
        {
          if (num++ > 5)
            throw;
        }
        Thread.Sleep(50);
        Application.DoEvents();
        Thread.Sleep(50);
      }
    }

    public void Cut(object sender, EventArgs e)
    {
      if (this.CopyTextToClipboard(this.textArea.SelectionManager.SelectedText))
      {
        this.textArea.BeginUpdate();
        this.textArea.Caret.Position = this.textArea.SelectionManager.SelectionCollection[0].StartPosition;
        this.textArea.SelectionManager.RemoveSelectedText();
        this.textArea.EndUpdate();
      }
      else
      {
        int lineNumberForOffset = this.textArea.Document.GetLineNumberForOffset(this.textArea.Caret.Offset);
        LineSegment lineSegment = this.textArea.Document.GetLineSegment(lineNumberForOffset);
        string text = this.textArea.Document.GetText(lineSegment.Offset, lineSegment.TotalLength);
        this.textArea.SelectionManager.SetSelection(this.textArea.Document.OffsetToPosition(lineSegment.Offset), this.textArea.Document.OffsetToPosition(lineSegment.Offset + lineSegment.TotalLength));
        if (!this.CopyTextToClipboard(text))
          return;
        this.textArea.BeginUpdate();
        this.textArea.Caret.Position = this.textArea.Document.OffsetToPosition(lineSegment.Offset);
        this.textArea.SelectionManager.RemoveSelectedText();
        this.textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.PositionToEnd, new Point(0, lineNumberForOffset)));
        this.textArea.EndUpdate();
      }
    }

    public void Copy(object sender, EventArgs e)
    {
      if (this.CopyTextToClipboard(this.textArea.SelectionManager.SelectedText))
        return;
      LineSegment lineSegment = this.textArea.Document.GetLineSegment(this.textArea.Document.GetLineNumberForOffset(this.textArea.Caret.Offset));
      string text = this.textArea.Document.GetText(lineSegment.Offset, lineSegment.TotalLength);
      this.textArea.SelectionManager.SetSelection(this.textArea.Document.OffsetToPosition(lineSegment.Offset), this.textArea.Document.OffsetToPosition(lineSegment.Offset + lineSegment.TotalLength));
      this.CopyTextToClipboard(text);
      this.textArea.SelectionManager.ClearSelection();
    }

    public void Paste(object sender, EventArgs e)
    {
      int num1 = 0;
      while (true)
      {
        try
        {
          IDataObject dataObject = Clipboard.GetDataObject();
          if (!dataObject.GetDataPresent(DataFormats.UnicodeText))
            break;
          string str = (string) dataObject.GetData(DataFormats.UnicodeText);
          if (str.Length <= 0)
            break;
          int num2 = 0;
          if (this.textArea.SelectionManager.HasSomethingSelected)
          {
            this.Delete(sender, e);
            ++num2;
          }
          this.textArea.InsertString(str);
          if (num2 <= 0)
            break;
          this.textArea.Document.UndoStack.UndoLast(num2 + 1);
          break;
        }
        catch (ExternalException ex)
        {
          if (num1 > 5)
            throw;
        }
        ++num1;
      }
    }

    public void Delete(object sender, EventArgs e)
    {
      new Delete().Execute(this.textArea);
    }

    public void SelectAll(object sender, EventArgs e)
    {
      new SelectWholeDocument().Execute(this.textArea);
    }

    protected virtual void OnCopyText(CopyTextEventArgs e)
    {
      if (this.CopyText == null)
        return;
      this.CopyText((object) this, e);
    }
  }
}
