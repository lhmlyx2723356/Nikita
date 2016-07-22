namespace Nikita.Base.Define
{
    /// <summary>操作状态
    /// 
    /// </summary>
    public enum EntityOperationType
    {
        /// <summary>新增
        ///
        /// </summary>
        新增 = 1,

        /// <summary>修改
        ///
        /// </summary>
        修改 = 2,

        /// <summary>删除
        ///
        /// </summary>
        删除 = 3,

        /// <summary>撤销
        ///
        /// </summary> 
        撤销 = 4,

        /// <summary>只读
        ///
        /// </summary>
        只读 = 5,

        /// <summary>新增明细
        ///
        /// </summary>
        新增明细 = 6,

        /// <summary>修改明细
        ///
        /// </summary>
        修改明细 = 7,

        /// <summary>删除明细
        ///
        /// </summary>
        删除明细 = 8,

        /// <summary>撤销明细
        ///
        /// </summary> 
        撤销明细 = 9,

        /// <summary>只读明细
        ///
        /// </summary>
        只读明细 = 10,
        /// <summary>作废
        ///
        /// </summary>
        作废 = 11
        
    }
}