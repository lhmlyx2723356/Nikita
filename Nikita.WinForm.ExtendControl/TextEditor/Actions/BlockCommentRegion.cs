// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.BlockCommentRegion
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class BlockCommentRegion
  {
    private string commentStart = string.Empty;
    private string commentEnd = string.Empty;
    private int startOffset = -1;
    private int endOffset = -1;

    public string CommentStart
    {
      get
      {
        return this.commentStart;
      }
    }

    public string CommentEnd
    {
      get
      {
        return this.commentEnd;
      }
    }

    public int StartOffset
    {
      get
      {
        return this.startOffset;
      }
    }

    public int EndOffset
    {
      get
      {
        return this.endOffset;
      }
    }

    public BlockCommentRegion(string commentStart, string commentEnd, int startOffset, int endOffset)
    {
      this.commentStart = commentStart;
      this.commentEnd = commentEnd;
      this.startOffset = startOffset;
      this.endOffset = endOffset;
    }

    public override bool Equals(object obj)
    {
      BlockCommentRegion blockCommentRegion = obj as BlockCommentRegion;
      return blockCommentRegion != null && blockCommentRegion.commentStart == this.commentStart && (blockCommentRegion.commentEnd == this.commentEnd && blockCommentRegion.startOffset == this.startOffset) && blockCommentRegion.endOffset == this.endOffset;
    }

    public override int GetHashCode()
    {
      return this.commentStart.GetHashCode() & this.commentEnd.GetHashCode() & this.startOffset.GetHashCode() & this.endOffset.GetHashCode();
    }
  }
}
