using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Assist.CodeMaker
{
    public class EditDialogParameter : BaseParameter
    {
        /// <summary>
        /// 查询条件字段
        /// </summary>
        public string QueryColumns { get; set; }
        /// <summary>
        /// 查询窗体显示字段
        /// </summary>
        public string ShowColumns { get; set; }
        /// <summary>
        /// 编辑窗体显示字段
        /// </summary>
        public string EditColumns { get; set; }
        /// <summary>
        /// 必须输入字段
        /// </summary>
        public string CheckInputColumns { get; set; }
        /// <summary>
        /// 保存时判断唯一字段
        /// </summary>
        public string DontRepeatColumns { get; set; }
        public DatabaseTable DatabaseTable { get; set; } 
    }
}
