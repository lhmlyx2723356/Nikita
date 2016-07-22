namespace Nikita.Assist.WcfService
{
    public enum MethodType
    {
        DataQuery,
        BllExecute
    }

    /// <summary>
    /// 客户端请求 数据结构
    /// </summary>
    public struct MethodRequest
    {
        public int ParamIndex { get; set; }
        public string[] ParamKeys { get; set; }
        public object[] ParamVals { get; set; }
        public string ProceDb { get; set; }
        public string ProceName { get; set; }
    }

    public struct MethodRequestEntery
    {
        public MethodRequest MethodEntery { get; set; }
        public string MethodKey { get; set; }
    }
}