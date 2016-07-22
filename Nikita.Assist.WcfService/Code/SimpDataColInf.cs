using System.Runtime.Serialization;

namespace Nikita.Assist.WcfService
{
    public enum DotNetType
    {
        Byte,
        Int64,
        Int32,
        String,
        Boolean,
        DateTime,
        Decimal
    }

    public struct SimpDataColInf
    {
        public string Name { get; set; }
        public DotNetType Type { get; set; }
    }
}