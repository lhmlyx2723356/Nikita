using System;

namespace Nikita.WinForm.ExtendControl
{
    public interface ILookupItem<T> where T : struct
    {
        T Id { get; }
        string Text { get; }
    }
}