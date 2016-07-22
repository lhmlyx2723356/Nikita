using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Assist.CodeMaker
{
    public class ParentChildEditDialogParameter : BaseParameter
    {
        /// <summary>
        /// 主表查询条件字段
        /// </summary>
        public string QueryColumns { get; set; }
        /// <summary>
        /// 主表查询窗体显示字段
        /// </summary>
        public string ShowColumns { get; set; }
        /// <summary>
        /// 主表编辑窗体显示字段
        /// </summary>
        public string EditColumns { get; set; }
        /// <summary>
        /// 主表必须输入字段
        /// </summary>
        public string CheckInputColumns { get; set; }
        /// <summary>
        /// 主表保存时判断唯一字段
        /// </summary>
        public string DontRepeatColumns { get; set; }

        /// <summary>
        /// 主表
        /// </summary>
        public DatabaseTable DatabaseTable { get; set; }


        /// <summary>
        /// 明细表查询窗体显示字段
        /// </summary>
        public string ShowColumnsDetail { get; set; }
        /// <summary>
        /// 明细表编辑窗体显示字段
        /// </summary>
        public string EditColumnsDetail { get; set; }
        /// <summary>
        /// 明细表必须输入字段
        /// </summary>
        public string CheckInputColumnsDetail { get; set; }
        /// <summary>
        /// 明细表保存时判断唯一字段
        /// </summary>
        public string DontRepeatColumnsDetail { get; set; }

        /// <summary>
        /// 明细表
        /// </summary>
        public DatabaseTable DatabaseTableDetail { get; set; }


        /// <summary>
        /// 主子表父键字段
        /// </summary>
        public string KeyMaster { get; set; }
        /// <summary>
        /// 主子表子键字段
        /// </summary>
        public string KeyDetail { get; set; }

    }
}
