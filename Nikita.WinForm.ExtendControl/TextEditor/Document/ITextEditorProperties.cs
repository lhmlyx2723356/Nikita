// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.ITextEditorProperties
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public interface ITextEditorProperties
  {
    bool AutoInsertCurlyBracket { get; set; }

    bool HideMouseCursor { get; set; }

    bool IsIconBarVisible { get; set; }

    bool AllowCaretBeyondEOL { get; set; }

    bool ShowMatchingBracket { get; set; }

    bool UseAntiAliasedFont { get; set; }

    bool MouseWheelScrollDown { get; set; }

    bool MouseWheelTextZoom { get; set; }

    string LineTerminator { get; set; }

    bool CreateBackupCopy { get; set; }

    LineViewerStyle LineViewerStyle { get; set; }

    bool ShowInvalidLines { get; set; }

    int VerticalRulerRow { get; set; }

    bool ShowSpaces { get; set; }

    bool ShowTabs { get; set; }

    bool ShowEOLMarker { get; set; }

    bool ConvertTabsToSpaces { get; set; }

    bool ShowHorizontalRuler { get; set; }

    bool ShowVerticalRuler { get; set; }

    Encoding Encoding { get; set; }

    bool EnableFolding { get; set; }

    bool ShowLineNumbers { get; set; }

    int TabIndent { get; set; }

    IndentStyle IndentStyle { get; set; }

    DocumentSelectionMode DocumentSelectionMode { get; set; }

    Font Font { get; set; }

    BracketMatchingStyle BracketMatchingStyle { get; set; }

    bool UseCustomLine { get; set; }
  }
}
