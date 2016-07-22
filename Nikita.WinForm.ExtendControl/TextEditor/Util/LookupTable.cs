// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.LookupTable
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Util
{
  public class LookupTable
  {
    private LookupTable.Node root = new LookupTable.Node((object) null, (string) null);
    private bool casesensitive;
    private int length;

    public int Count
    {
      get
      {
        return this.length;
      }
    }

    public object this[IDocument document, LineSegment line, int offset, int length]
    {
      get
      {
        if (length == 0)
          return (object) null;
        LookupTable.Node node = this.root;
        int offset1 = line.Offset + offset;
        if (this.casesensitive)
        {
          for (int index1 = 0; index1 < length; ++index1)
          {
            int index2 = (int) document.GetCharAt(offset1 + index1) % 256;
            node = node.leaf[index2];
            if (node == null)
              return (object) null;
            if (node.color != null && TextUtility.RegionMatches(document, offset1, length, node.word))
              return node.color;
          }
        }
        else
        {
          for (int index1 = 0; index1 < length; ++index1)
          {
            int index2 = (int) char.ToUpper(document.GetCharAt(offset1 + index1)) % 256;
            node = node.leaf[index2];
            if (node == null)
              return (object) null;
            if (node.color != null && TextUtility.RegionMatches(document, this.casesensitive, offset1, length, node.word))
              return node.color;
          }
        }
        return (object) null;
      }
    }

    public object this[string keyword]
    {
      set
      {
        LookupTable.Node node1 = this.root;
        LookupTable.Node node2 = this.root;
        if (!this.casesensitive)
          keyword = keyword.ToUpper();
        ++this.length;
        for (int index1 = 0; index1 < keyword.Length; ++index1)
        {
          int index2 = (int) keyword[index1] % 256;
          int num = (int) keyword[index1];
          node2 = node2.leaf[index2];
          if (node2 == null)
          {
            node1.leaf[index2] = new LookupTable.Node(value, keyword);
            break;
          }
          if (node2.word != null && node2.word.Length != index1)
          {
            string index3 = node2.word;
            object obj = node2.color;
            node2.color = (object) (node2.word = (string) null);
            this[index3] = obj;
          }
          if (index1 == keyword.Length - 1)
          {
            node2.word = keyword;
            node2.color = value;
            break;
          }
          node1 = node2;
        }
      }
    }

    public LookupTable(bool casesensitive)
    {
      this.casesensitive = casesensitive;
    }

    private class Node
    {
      public LookupTable.Node[] leaf = new LookupTable.Node[256];
      public string word;
      public object color;

      public Node(object color, string word)
      {
        this.word = word;
        this.color = color;
      }
    }
  }
}
