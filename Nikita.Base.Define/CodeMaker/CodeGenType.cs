namespace Nikita.Base.Define
{
    /// <summary>
    /// 代码生成类型
    /// </summary>
    public enum CodeGenType
    {
        /// <summary>
        ///简单查询
        /// </summary>
        WinFromSimpleQuery = 1,
        /// <summary>
        ///嵌套查询(查询结果，最多支持三层嵌套，折叠显示)
        /// </summary>
        WinFromNestQuery = 3,
        /// <summary>
        ///单表查询编辑（编辑界面以弹出窗体形式）
        /// </summary>
        WinFromEditWithDialog = 2,
        /// <summary>
        ///树型编辑（编辑界面以弹出窗体形式）
        /// </summary>
        WinFromTreeEditWithDialog = 4,
        /// <summary>
        ///单表查询编辑（编辑界面跟查询同界面）
        /// </summary>
        WinFromEdit = 5,
        /// <summary>
        ///主子表表查询编辑（编辑界面以弹出窗体形式）
        /// </summary>
        WinFromParentChildEditWithDialog = 6
    }
}