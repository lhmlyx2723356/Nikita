// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.DocumentFactory
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Util;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class DocumentFactory
  {
    public IDocument CreateDocument()
    {
      DefaultDocument defaultDocument = new DefaultDocument();
      defaultDocument.TextBufferStrategy = (ITextBufferStrategy) new GapTextBufferStrategy();
      defaultDocument.FormattingStrategy = (IFormattingStrategy) new DefaultFormattingStrategy();
      defaultDocument.LineManager = (ILineManager) new DefaultLineManager((IDocument) defaultDocument, (IHighlightingStrategy) null);
      defaultDocument.FoldingManager = new FoldingManager((IDocument) defaultDocument, defaultDocument.LineManager);
      defaultDocument.FoldingManager.FoldingStrategy = (IFoldingStrategy) null;
      defaultDocument.MarkerStrategy = new MarkerStrategy((IDocument) defaultDocument);
      defaultDocument.BookmarkManager = new BookmarkManager((IDocument) defaultDocument, defaultDocument.LineManager);
      defaultDocument.CustomLineManager = (ICustomLineManager) new CustomLineManager(defaultDocument.LineManager);
      return (IDocument) defaultDocument;
    }

    public IDocument CreateFromFile(string fileName)
    {
      IDocument document = this.CreateDocument();
      Encoding @default = Encoding.Default;
      document.TextContent = FileReader.ReadFileContent(fileName, ref @default, @default);
      return document;
    }
  }
}
