// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextEditorControlBase
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Actions;
using Nikita.WinForm.ExtendControl.Document;
using Nikita.WinForm.ExtendControl.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  [ToolboxItem(false)]
  public abstract class TextEditorControlBase : UserControl
  {
    protected Dictionary<Keys, IEditAction> editactions = new Dictionary<Keys, IEditAction>();
    private string currentFileName;
    private int updateLevel;
    private IDocument document;
    private Encoding encoding;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ITextEditorProperties TextEditorProperties
    {
      get
      {
        return this.document.TextEditorProperties;
      }
      set
      {
        this.document.TextEditorProperties = value;
        this.OptionsChanged();
      }
    }

    public Encoding Encoding
    {
      get
      {
        if (this.encoding == null)
          return this.TextEditorProperties.Encoding;
        return this.encoding;
      }
      set
      {
        this.encoding = value;
      }
    }

    [Browsable(false)]
    [ReadOnly(true)]
    public string FileName
    {
      get
      {
        return this.currentFileName;
      }
      set
      {
        if (!(this.currentFileName != value))
          return;
        this.currentFileName = value;
        this.OnFileNameChanged(EventArgs.Empty);
      }
    }

    [Browsable(false)]
    public bool IsUpdating
    {
      get
      {
        return this.updateLevel > 0;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public IDocument Document
    {
      get
      {
        return this.document;
      }
      set
      {
        this.document = value;
        this.document.UndoStack.TextEditorControl = this;
      }
    }

    [Browsable(true)]
    public override string Text
    {
      get
      {
        return this.Document.TextContent;
      }
      set
      {
        this.Document.TextContent = value;
      }
    }

    [Browsable(false)]
    [ReadOnly(true)]
    public bool IsReadOnly
    {
      get
      {
        return this.Document.ReadOnly;
      }
      set
      {
        this.Document.ReadOnly = value;
      }
    }

    [Browsable(false)]
    public bool IsInUpdate
    {
      get
      {
        return this.updateLevel > 0;
      }
    }

    protected override Size DefaultSize
    {
      get
      {
        return new Size(100, 100);
      }
    }

    [Description("If true spaces are shown in the textarea")]
    [DefaultValue(false)]
    [Category("Appearance")]
    public bool ShowSpaces
    {
      get
      {
        return this.document.TextEditorProperties.ShowSpaces;
      }
      set
      {
        this.document.TextEditorProperties.ShowSpaces = value;
        this.OptionsChanged();
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    [Description("If true antialiased fonts are used inside the textarea")]
    public bool UseAntiAliasFont
    {
      get
      {
        return this.document.TextEditorProperties.UseAntiAliasedFont;
      }
      set
      {
        this.document.TextEditorProperties.UseAntiAliasedFont = value;
        this.OptionsChanged();
      }
    }

    [Description("If true tabs are shown in the textarea")]
    [Category("Appearance")]
    [DefaultValue(false)]
    public bool ShowTabs
    {
      get
      {
        return this.document.TextEditorProperties.ShowTabs;
      }
      set
      {
        this.document.TextEditorProperties.ShowTabs = value;
        this.OptionsChanged();
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    [Description("If true EOL markers are shown in the textarea")]
    public bool ShowEOLMarkers
    {
      get
      {
        return this.document.TextEditorProperties.ShowEOLMarker;
      }
      set
      {
        this.document.TextEditorProperties.ShowEOLMarker = value;
        this.OptionsChanged();
      }
    }

    [Description("If true the horizontal ruler is shown in the textarea")]
    [DefaultValue(false)]
    [Category("Appearance")]
    public bool ShowHRuler
    {
      get
      {
        return this.document.TextEditorProperties.ShowHorizontalRuler;
      }
      set
      {
        this.document.TextEditorProperties.ShowHorizontalRuler = value;
        this.OptionsChanged();
      }
    }

    [Description("If true the vertical ruler is shown in the textarea")]
    [Category("Appearance")]
    [DefaultValue(false)]
    public bool ShowVRuler
    {
      get
      {
        return this.document.TextEditorProperties.ShowVerticalRuler;
      }
      set
      {
        this.document.TextEditorProperties.ShowVerticalRuler = value;
        this.OptionsChanged();
      }
    }

    [Description("The row in which the vertical ruler is displayed")]
    [Category("Appearance")]
    [DefaultValue(80)]
    public int VRulerRow
    {
      get
      {
        return this.document.TextEditorProperties.VerticalRulerRow;
      }
      set
      {
        this.document.TextEditorProperties.VerticalRulerRow = value;
        this.OptionsChanged();
      }
    }

    [Category("Appearance")]
    [Description("If true line numbers are shown in the textarea")]
    [DefaultValue(true)]
    public bool ShowLineNumbers
    {
      get
      {
        return this.document.TextEditorProperties.ShowLineNumbers;
      }
      set
      {
        this.document.TextEditorProperties.ShowLineNumbers = value;
        this.OptionsChanged();
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    [Description("If true invalid lines are marked in the textarea")]
    public bool ShowInvalidLines
    {
      get
      {
        return this.document.TextEditorProperties.ShowInvalidLines;
      }
      set
      {
        this.document.TextEditorProperties.ShowInvalidLines = value;
        this.OptionsChanged();
      }
    }

    [Description("If true folding is enabled in the textarea")]
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool EnableFolding
    {
      get
      {
        return this.document.TextEditorProperties.EnableFolding;
      }
      set
      {
        this.document.TextEditorProperties.EnableFolding = value;
        this.OptionsChanged();
      }
    }

    [Description("If true matching brackets are highlighted")]
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowMatchingBracket
    {
      get
      {
        return this.document.TextEditorProperties.ShowMatchingBracket;
      }
      set
      {
        this.document.TextEditorProperties.ShowMatchingBracket = value;
        this.OptionsChanged();
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    [Description("If true the icon bar is displayed")]
    public bool IsIconBarVisible
    {
      get
      {
        return this.document.TextEditorProperties.IsIconBarVisible;
      }
      set
      {
        this.document.TextEditorProperties.IsIconBarVisible = value;
        this.OptionsChanged();
      }
    }

    [Description("The width in spaces of a tab character")]
    [Category("Appearance")]
    [DefaultValue(4)]
    public int TabIndent
    {
      get
      {
        return this.document.TextEditorProperties.TabIndent;
      }
      set
      {
        this.document.TextEditorProperties.TabIndent = value;
        this.OptionsChanged();
      }
    }

    [DefaultValue(LineViewerStyle.None)]
    [Category("Appearance")]
    [Description("The line viewer style")]
    public LineViewerStyle LineViewerStyle
    {
      get
      {
        return this.document.TextEditorProperties.LineViewerStyle;
      }
      set
      {
        this.document.TextEditorProperties.LineViewerStyle = value;
        this.OptionsChanged();
      }
    }

    [Category("Behavior")]
    [Description("The indent style")]
    [DefaultValue(IndentStyle.Smart)]
    public IndentStyle IndentStyle
    {
      get
      {
        return this.document.TextEditorProperties.IndentStyle;
      }
      set
      {
        this.document.TextEditorProperties.IndentStyle = value;
        this.OptionsChanged();
      }
    }

    [Description("Converts tabs to spaces while typing")]
    [Category("Behavior")]
    [DefaultValue(false)]
    public bool ConvertTabsToSpaces
    {
      get
      {
        return this.document.TextEditorProperties.ConvertTabsToSpaces;
      }
      set
      {
        this.document.TextEditorProperties.ConvertTabsToSpaces = value;
        this.OptionsChanged();
      }
    }

    [Description("Creates a backup copy for overwritten files")]
    [Category("Behavior")]
    [DefaultValue(false)]
    public bool CreateBackupCopy
    {
      get
      {
        return this.document.TextEditorProperties.CreateBackupCopy;
      }
      set
      {
        this.document.TextEditorProperties.CreateBackupCopy = value;
        this.OptionsChanged();
      }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("Hide the mouse cursor while typing")]
    public bool HideMouseCursor
    {
      get
      {
        return this.document.TextEditorProperties.HideMouseCursor;
      }
      set
      {
        this.document.TextEditorProperties.HideMouseCursor = value;
        this.OptionsChanged();
      }
    }

    [Category("Behavior")]
    [Description("Allows the caret to be places beyonde the end of line")]
    [DefaultValue(false)]
    public bool AllowCaretBeyondEOL
    {
      get
      {
        return this.document.TextEditorProperties.AllowCaretBeyondEOL;
      }
      set
      {
        this.document.TextEditorProperties.AllowCaretBeyondEOL = value;
        this.OptionsChanged();
      }
    }

    [Category("Behavior")]
    [DefaultValue(BracketMatchingStyle.After)]
    [Description("Specifies if the bracket matching should match the bracket before or after the caret.")]
    public BracketMatchingStyle BracketMatchingStyle
    {
      get
      {
        return this.document.TextEditorProperties.BracketMatchingStyle;
      }
      set
      {
        this.document.TextEditorProperties.BracketMatchingStyle = value;
        this.OptionsChanged();
      }
    }

    [Browsable(true)]
    [Description("The base font of the text area. No bold or italic fonts can be used because bold/italic is reserved for highlighting purposes.")]
    public override Font Font
    {
      get
      {
        return this.document.TextEditorProperties.Font;
      }
      set
      {
        this.document.TextEditorProperties.Font = value;
        this.OptionsChanged();
      }
    }

    public abstract TextAreaControl ActiveTextAreaControl { get; }

    public event EventHandler FileNameChanged;

    public event EventHandler Changed;

    protected TextEditorControlBase()
    {
      this.GenerateDefaultActions();
      HighlightingManager.Manager.ReloadSyntaxHighlighting += new EventHandler(this.ReloadHighlighting);
    }

    private static Font ParseFont(string font)
    {
      string[] strArray = font.Split(new char[2]
      {
        ',',
        '='
      });
      return new Font(strArray[1], float.Parse(strArray[3]));
    }

    private void ReloadHighlighting(object sender, EventArgs e)
    {
      if (this.Document.HighlightingStrategy == null)
        return;
      this.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(this.Document.HighlightingStrategy.Name);
      this.OptionsChanged();
    }

    internal IEditAction GetEditAction(Keys keyData)
    {
      if (!this.editactions.ContainsKey(keyData))
        return (IEditAction) null;
      return this.editactions[keyData];
    }

    private void GenerateDefaultActions()
    {
      this.editactions[Keys.Left] = (IEditAction) new CaretLeft();
      this.editactions[Keys.Left | Keys.Shift] = (IEditAction) new ShiftCaretLeft();
      this.editactions[Keys.Left | Keys.Control] = (IEditAction) new WordLeft();
      this.editactions[Keys.Left | Keys.Shift | Keys.Control] = (IEditAction) new ShiftWordLeft();
      this.editactions[Keys.Right] = (IEditAction) new CaretRight();
      this.editactions[Keys.Right | Keys.Shift] = (IEditAction) new ShiftCaretRight();
      this.editactions[Keys.Right | Keys.Control] = (IEditAction) new WordRight();
      this.editactions[Keys.Right | Keys.Shift | Keys.Control] = (IEditAction) new ShiftWordRight();
      this.editactions[Keys.Up] = (IEditAction) new CaretUp();
      this.editactions[Keys.Up | Keys.Shift] = (IEditAction) new ShiftCaretUp();
      this.editactions[Keys.Up | Keys.Control] = (IEditAction) new ScrollLineUp();
      this.editactions[Keys.Down] = (IEditAction) new CaretDown();
      this.editactions[Keys.Down | Keys.Shift] = (IEditAction) new ShiftCaretDown();
      this.editactions[Keys.Down | Keys.Control] = (IEditAction) new ScrollLineDown();
      this.editactions[Keys.Insert] = (IEditAction) new ToggleEditMode();
      this.editactions[Keys.Insert | Keys.Control] = (IEditAction) new Copy();
      this.editactions[Keys.Insert | Keys.Shift] = (IEditAction) new Paste();
      this.editactions[Keys.Delete] = (IEditAction) new Delete();
      this.editactions[Keys.Delete | Keys.Shift] = (IEditAction) new Cut();
      this.editactions[Keys.Home] = (IEditAction) new Home();
      this.editactions[Keys.Home | Keys.Shift] = (IEditAction) new ShiftHome();
      this.editactions[Keys.Home | Keys.Control] = (IEditAction) new MoveToStart();
      this.editactions[Keys.Home | Keys.Shift | Keys.Control] = (IEditAction) new ShiftMoveToStart();
      this.editactions[Keys.End] = (IEditAction) new End();
      this.editactions[Keys.End | Keys.Shift] = (IEditAction) new ShiftEnd();
      this.editactions[Keys.End | Keys.Control] = (IEditAction) new MoveToEnd();
      this.editactions[Keys.End | Keys.Shift | Keys.Control] = (IEditAction) new ShiftMoveToEnd();
      this.editactions[Keys.Prior] = (IEditAction) new MovePageUp();
      this.editactions[Keys.Prior | Keys.Shift] = (IEditAction) new ShiftMovePageUp();
      this.editactions[Keys.Next] = (IEditAction) new MovePageDown();
      this.editactions[Keys.Next | Keys.Shift] = (IEditAction) new ShiftMovePageDown();
      this.editactions[Keys.Return] = (IEditAction) new Return();
      this.editactions[Keys.Tab] = (IEditAction) new Tab();
      this.editactions[Keys.Tab | Keys.Shift] = (IEditAction) new ShiftTab();
      this.editactions[Keys.Back] = (IEditAction) new Backspace();
      this.editactions[Keys.Back | Keys.Shift] = (IEditAction) new Backspace();
      this.editactions[Keys.X | Keys.Control] = (IEditAction) new Cut();
      this.editactions[Keys.C | Keys.Control] = (IEditAction) new Copy();
      this.editactions[Keys.V | Keys.Control] = (IEditAction) new Paste();
      this.editactions[Keys.A | Keys.Control] = (IEditAction) new SelectWholeDocument();
      this.editactions[Keys.Escape] = (IEditAction) new ClearAllSelections();
      this.editactions[Keys.Divide | Keys.Control] = (IEditAction) new ToggleComment();
      this.editactions[Keys.OemQuestion | Keys.Control] = (IEditAction) new ToggleComment();
        this.editactions[Keys.Back | Keys.Alt] = (IEditAction) new Actions.Undo();
        this.editactions[Keys.Z | Keys.Control] = (IEditAction)new Actions.Undo();
      this.editactions[Keys.Y | Keys.Control] = (IEditAction) new Redo();
      this.editactions[Keys.Delete | Keys.Control] = (IEditAction) new DeleteWord();
      this.editactions[Keys.Back | Keys.Control] = (IEditAction) new WordBackspace();
      this.editactions[Keys.D | Keys.Control] = (IEditAction) new DeleteLine();
      this.editactions[Keys.D | Keys.Shift | Keys.Control] = (IEditAction) new DeleteToLineEnd();
      this.editactions[Keys.B | Keys.Control] = (IEditAction) new GotoMatchingBrace();
    }

    public virtual void BeginUpdate()
    {
      ++this.updateLevel;
    }

    public virtual void EndUpdate()
    {
      this.updateLevel = Math.Max(0, this.updateLevel - 1);
    }

    public void LoadFile(string fileName)
    {
      this.LoadFile(fileName, true, true);
    }

    public void LoadFile(string fileName, bool autoLoadHighlighting, bool autodetectEncoding)
    {
      this.BeginUpdate();
      this.document.TextContent = string.Empty;
      this.document.UndoStack.ClearAll();
      this.document.BookmarkManager.Clear();
      if (autoLoadHighlighting)
        this.document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile(fileName);
      if (autodetectEncoding)
      {
        Encoding encoding = this.Encoding;
        this.Document.TextContent = FileReader.ReadFileContent(fileName, ref encoding, this.TextEditorProperties.Encoding);
        this.Encoding = encoding;
      }
      else
      {
        using (StreamReader streamReader = new StreamReader(fileName, this.Encoding))
          this.Document.TextContent = streamReader.ReadToEnd();
      }
      this.FileName = fileName;
      this.OptionsChanged();
      this.Document.UpdateQueue.Clear();
      this.EndUpdate();
      this.Refresh();
    }

    public bool CanSaveWithCurrentEncoding()
    {
      if (this.encoding == null || FileReader.IsUnicode(this.encoding))
        return true;
      string textContent = this.document.TextContent;
      return this.encoding.GetString(this.encoding.GetBytes(textContent)) == textContent;
    }

    public void SaveFile(string fileName)
    {
      if (this.document.TextEditorProperties.CreateBackupCopy)
        this.MakeBackupCopy(fileName);
      Encoding encoding = this.Encoding;
      StreamWriter streamWriter = encoding != null ? new StreamWriter(fileName, false, encoding) : new StreamWriter(fileName, false, Encoding.UTF8);
      foreach (LineSegment lineSegment in this.Document.LineSegmentCollection)
      {
        streamWriter.Write(this.Document.GetText(lineSegment.Offset, lineSegment.Length));
        streamWriter.Write(this.document.TextEditorProperties.LineTerminator);
      }
      streamWriter.Close();
      this.FileName = fileName;
    }

    private void MakeBackupCopy(string fileName)
    {
      try
      {
        if (!File.Exists(fileName))
          return;
        string destFileName = fileName + ".bak";
        File.Copy(fileName, destFileName, true);
      }
      catch (Exception ex)
      {
      }
    }

    public abstract void OptionsChanged();

    public virtual string GetRangeDescription(int selectedItem, int itemCount)
    {
      StringBuilder stringBuilder = new StringBuilder(selectedItem.ToString());
      stringBuilder.Append(" from ");
      stringBuilder.Append(itemCount.ToString());
      return stringBuilder.ToString();
    }

    public override void Refresh()
    {
      if (this.IsUpdating)
        return;
      base.Refresh();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        HighlightingManager.Manager.ReloadSyntaxHighlighting -= new EventHandler(this.ReloadHighlighting);
        this.document.HighlightingStrategy = (IHighlightingStrategy) null;
        this.document.UndoStack.TextEditorControl = (TextEditorControlBase) null;
      }
      base.Dispose(disposing);
    }

    protected virtual void OnFileNameChanged(EventArgs e)
    {
      if (this.FileNameChanged == null)
        return;
      this.FileNameChanged((object) this, e);
    }

    protected virtual void OnChanged(EventArgs e)
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, e);
    }
  }
}
