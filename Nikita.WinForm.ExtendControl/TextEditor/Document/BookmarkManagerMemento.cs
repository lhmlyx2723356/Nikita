// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.BookmarkManagerMemento
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections.Generic;
using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class BookmarkManagerMemento
  {
    private List<int> bookmarks = new List<int>();

    public List<int> Bookmarks
    {
      get
      {
        return this.bookmarks;
      }
      set
      {
        this.bookmarks = value;
      }
    }

    public BookmarkManagerMemento()
    {
    }

    public BookmarkManagerMemento(XmlElement element)
    {
      foreach (XmlNode xmlNode in element.ChildNodes)
        this.bookmarks.Add(int.Parse(xmlNode.Attributes["line"].InnerText));
    }

    public BookmarkManagerMemento(List<int> bookmarks)
    {
      this.bookmarks = bookmarks;
    }

    public void CheckMemento(IDocument document)
    {
      for (int index = 0; index < this.bookmarks.Count; ++index)
      {
        int num = this.bookmarks[index];
        if (num < 0 || num >= document.TotalNumberOfLines)
        {
          this.bookmarks.RemoveAt(index);
          --index;
        }
      }
    }

    public object FromXmlElement(XmlElement element)
    {
      return (object) new BookmarkManagerMemento(element);
    }

    public XmlElement ToXmlElement(XmlDocument doc)
    {
      XmlElement element1 = doc.CreateElement("Bookmarks");
      foreach (int num in this.bookmarks)
      {
        XmlElement element2 = doc.CreateElement("Mark");
        XmlAttribute attribute = doc.CreateAttribute("line");
        attribute.InnerText = num.ToString();
        element2.Attributes.Append(attribute);
        element1.AppendChild((XmlNode) element2);
      }
      return element1;
    }
  }
}
