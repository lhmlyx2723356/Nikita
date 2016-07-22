// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.FoldingManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class FoldingManager
  {
    private List<Nikita.WinForm.ExtendControl.Document.FoldMarker> foldMarker = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
    private IFoldingStrategy foldingStrategy;
    private IDocument document;

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> FoldMarker
    {
      get
      {
        return this.foldMarker;
      }
    }

    public IFoldingStrategy FoldingStrategy
    {
      get
      {
        return this.foldingStrategy;
      }
      set
      {
        this.foldingStrategy = value;
      }
    }

    public event EventHandler FoldingsChanged;

    public FoldingManager(IDocument document, ILineManager lineTracker)
    {
      this.document = document;
      document.DocumentChanged += new DocumentEventHandler(this.DocumentChanged);
    }

    private void DocumentChanged(object sender, DocumentEventArgs e)
    {
      int count = this.foldMarker.Count;
      this.document.UpdateSegmentListOnDocumentChange<Nikita.WinForm.ExtendControl.Document.FoldMarker>(this.foldMarker, e);
      if (count == this.foldMarker.Count)
        return;
      this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetFoldingsFromPosition(int line, int column)
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        for (int index = 0; index < this.foldMarker.Count; ++index)
        {
          Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker = this.foldMarker[index];
          if (foldMarker.StartLine == line && column > foldMarker.StartColumn && (foldMarker.EndLine != line || column < foldMarker.EndColumn) || foldMarker.EndLine == line && column < foldMarker.EndColumn && (foldMarker.StartLine != line || column > foldMarker.StartColumn) || line > foldMarker.StartLine && line < foldMarker.EndLine)
            list.Add(foldMarker);
        }
      }
      return list;
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetFoldingsWithStart(int lineNumber)
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.StartLine == lineNumber)
            list.Add(foldMarker);
        }
      }
      return list;
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetFoldedFoldingsWithStart(int lineNumber)
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.IsFolded && foldMarker.StartLine == lineNumber)
            list.Add(foldMarker);
        }
      }
      return list;
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetFoldedFoldingsWithStartAfterColumn(int lineNumber, int column)
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.IsFolded && foldMarker.StartLine == lineNumber && foldMarker.StartColumn > column)
            list.Add(foldMarker);
        }
      }
      return list;
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetFoldingsWithEnd(int lineNumber)
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.EndLine == lineNumber)
            list.Add(foldMarker);
        }
      }
      return list;
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetFoldedFoldingsWithEnd(int lineNumber)
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.IsFolded && foldMarker.EndLine == lineNumber)
            list.Add(foldMarker);
        }
      }
      return list;
    }

    public bool IsFoldStart(int lineNumber)
    {
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.StartLine == lineNumber)
            return true;
        }
      }
      return false;
    }

    public bool IsFoldEnd(int lineNumber)
    {
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.EndLine == lineNumber)
            return true;
        }
      }
      return false;
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetFoldingsContainsLineNumber(int lineNumber)
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.StartLine < lineNumber && lineNumber < foldMarker.EndLine)
            list.Add(foldMarker);
        }
      }
      return list;
    }

    public bool IsBetweenFolding(int lineNumber)
    {
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.StartLine < lineNumber && lineNumber < foldMarker.EndLine)
            return true;
        }
      }
      return false;
    }

    public bool IsLineVisible(int lineNumber)
    {
      if (this.foldMarker != null)
      {
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.IsFolded && foldMarker.StartLine < lineNumber && lineNumber < foldMarker.EndLine)
            return false;
        }
      }
      return true;
    }

    public List<Nikita.WinForm.ExtendControl.Document.FoldMarker> GetTopLevelFoldedFoldings()
    {
      List<Nikita.WinForm.ExtendControl.Document.FoldMarker> list = new List<Nikita.WinForm.ExtendControl.Document.FoldMarker>();
      if (this.foldMarker != null)
      {
        Point point = new Point(0, 0);
        foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
        {
          if (foldMarker.IsFolded && (foldMarker.StartLine > point.Y || foldMarker.StartLine == point.Y && foldMarker.StartColumn >= point.X))
          {
            list.Add(foldMarker);
            point = new Point(foldMarker.EndColumn, foldMarker.EndLine);
          }
        }
      }
      return list;
    }

    public void UpdateFoldings(string fileName, object parseInfo)
    {
      int count = this.foldMarker.Count;
      lock (this)
      {
        List<Nikita.WinForm.ExtendControl.Document.FoldMarker> local_1 = this.foldingStrategy.GenerateFoldMarkers(this.document, fileName, parseInfo);
        if (local_1 != null && local_1.Count != 0)
        {
          local_1.Sort();
          if (this.foldMarker.Count == local_1.Count)
          {
            for (int local_2 = 0; local_2 < this.foldMarker.Count; ++local_2)
              local_1[local_2].IsFolded = this.foldMarker[local_2].IsFolded;
            this.foldMarker = local_1;
          }
          else
          {
            int local_3 = 0;
            int local_4 = 0;
            while (local_3 < this.foldMarker.Count && local_4 < local_1.Count)
            {
              int local_5 = local_1[local_4].CompareTo((object) this.foldMarker[local_3]);
              if (local_5 > 0)
              {
                ++local_3;
              }
              else
              {
                if (local_5 == 0)
                  local_1[local_4].IsFolded = this.foldMarker[local_3].IsFolded;
                ++local_4;
              }
            }
          }
        }
        if (local_1 != null)
          this.foldMarker = local_1;
        else
          this.foldMarker.Clear();
      }
      if (count == this.foldMarker.Count)
        return;
      this.document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
      this.document.CommitUpdate();
    }

    public string SerializeToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
      {
        stringBuilder.Append(foldMarker.Offset);
        stringBuilder.Append("\n");
        stringBuilder.Append(foldMarker.Length);
        stringBuilder.Append("\n");
        stringBuilder.Append(foldMarker.FoldText);
        stringBuilder.Append("\n");
        stringBuilder.Append(foldMarker.IsFolded);
        stringBuilder.Append("\n");
      }
      return stringBuilder.ToString();
    }

    public void DeserializeFromString(string str)
    {
      try
      {
        string[] strArray = str.Split('\n');
        int index = 0;
        while (index < strArray.Length && strArray[index].Length > 0)
        {
          int offset = int.Parse(strArray[index]);
          int length = int.Parse(strArray[index + 1]);
          string foldText = strArray[index + 2];
          bool isFolded = bool.Parse(strArray[index + 3]);
          bool flag = false;
          foreach (Nikita.WinForm.ExtendControl.Document.FoldMarker foldMarker in this.foldMarker)
          {
            if (foldMarker.Offset == offset && foldMarker.Length == length)
            {
              foldMarker.IsFolded = isFolded;
              flag = true;
              break;
            }
          }
          if (!flag)
            this.foldMarker.Add(new Nikita.WinForm.ExtendControl.Document.FoldMarker(this.document, offset, length, foldText, isFolded));
          index += 4;
        }
        if (strArray.Length <= 0)
          return;
        this.NotifyFoldingsChanged(EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    public void NotifyFoldingsChanged(EventArgs e)
    {
      if (this.FoldingsChanged == null)
        return;
      this.FoldingsChanged((object) this, e);
    }
  }
}
