using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Nikita.Core
{
    /// <summary>
    /// Sql的查询符号
    /// </summary>
    public enum SqlOperator
    {
        /// <summary>
        /// Like 模糊查询
        /// </summary>
        Like,

        /// <summary>
        /// ＝ is equal to 等于号
        /// </summary>
        Equal,

        /// <summary>
        ///   不等于
        /// </summary>
        NotEqual,

        /// <summary>
        /// ＞ is more than 大于号
        /// </summary>
        MoreThan,

        /// <summary>
        /// ＜ is less than 小于号
        /// </summary>
        LessThan,

        /// <summary>
        /// ≥ is more than or equal to 大于或等于号
        /// </summary>
        MoreThanOrEqual,

        /// <summary>
        /// ≤ is less than or equal to 小于或等于号
        /// </summary>
        LessThanOrEqual,

        /*
        /// <summary>
        /// 在某个值的中间，拆成两个符号 >= 和 <=
        /// </summary>
        Between,
        */

        /// <summary>
        /// 在某个字符串值中
        /// </summary>
        In
    }

    public class SearchCondition
    {
        private readonly Hashtable _conditionTable = new Hashtable();

        public Hashtable ConditionTable
        {
            get { return this._conditionTable; }
        }

        /// <summary>
        /// 为查询添加条件
        /// <example>
        /// 用法一：
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual);
        /// searchObj.AddCondition("Test2", "Test2Value", SqlOperator.Like);
        /// string conditionSql = searchObj.BuildConditionSql();
        ///
        /// 用法二：AddCondition函数可以串起来添加多个条件
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual).AddCondition("Test2", "Test2Value", SqlOperator.Like);
        /// string conditionSql = searchObj.BuildConditionSql();
        /// </example>
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <returns>增加条件后的Hashtable</returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator)
        {
            this._conditionTable.Add(Guid.NewGuid()/*fielName*/, new SearchInfo(fielName, fieldValue, sqlOperator));
            return this;
        }

        /// <summary>
        /// 为查询添加条件
        /// <example>
        /// 用法一：
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual, false);
        /// searchObj.AddCondition("Test2", "Test2Value", SqlOperator.Like, true);
        /// string conditionSql = searchObj.BuildConditionSql();
        ///
        /// 用法二：AddCondition函数可以串起来添加多个条件
        /// SearchCondition searchObj = new SearchCondition();
        /// searchObj.AddCondition("Test", 1, SqlOperator.NotEqual, false).AddCondition("Test2", "Test2Value", SqlOperator.Like, true);
        /// string conditionSql = searchObj.BuildConditionSql();
        /// </example>
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <returns></returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty)
        {
            this._conditionTable.Add(Guid.NewGuid()/*fielName*/, new SearchInfo(fielName, fieldValue, sqlOperator, excludeIfEmpty));
            return this;
        }

        /// <summary>
        /// 将多个条件分组归类作为一个条件来查询，
        /// 如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2")
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <param name="groupName">分组的名称，如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2"), 定义一个组名集中条件</param>
        /// <returns></returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator,
            bool excludeIfEmpty, string groupName)
        {
            this._conditionTable.Add(Guid.NewGuid()/*fielName*/, new SearchInfo(fielName, fieldValue, sqlOperator, excludeIfEmpty, groupName));
            return this;
        }

        /// <summary>
        /// 根据对象构造相关的条件语句（不使用参数），如返回的语句是:
        /// <![CDATA[
        /// Where (1=1)  AND Test4  <  'Value4' AND Test6  >=  'Value6' AND Test7  <=  'value7' AND Test  <>  '1' AND Test5  >  'Value5' AND Test2  Like  '%Value2%' AND Test3  =  'Value3'
        /// ]]>
        /// </summary>
        /// <returns></returns>
        public string BuildConditionSql()
        {
            string sql = " Where (1=1) ";

            StringBuilder sb = new StringBuilder();
            sql += BuildGroupCondiction();

            foreach (DictionaryEntry de in this._conditionTable)
            {
                var searchInfo = (SearchInfo)de.Value;

                //如果选择ExcludeIfEmpty为True,并且该字段为空值的话,跳过
                if (searchInfo.ExcludeIfEmpty &&
                    (searchInfo.FieldValue == null || string.IsNullOrEmpty(searchInfo.FieldValue.ToString())))
                {
                    continue;
                }

                //只有组别名称为空才继续，即正常的sql条件
                if (string.IsNullOrEmpty(searchInfo.GroupName))
                {
                    if (searchInfo.SqlOperator == SqlOperator.Like)
                    {
                        sb.AppendFormat(" AND {0} {1} '{2}'", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("%{0}%", searchInfo.FieldValue));
                    }
                    else if (searchInfo.SqlOperator == SqlOperator.In)
                    {
                        sb.AppendFormat(" AND {0} {1} {2}", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("({0})", searchInfo.FieldValue));
                    }
                    else
                    {
                        sb.AppendFormat(" AND {0} {1} '{2}'", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), searchInfo.FieldValue);
                    }
                }
            }

            sql += sb.ToString();

            return sql;
        }

        /// <summary>
        /// 建立分组条件
        /// </summary>
        /// <returns></returns>
        private string BuildGroupCondiction()
        {
            Hashtable ht = GetGroupNames();
            string sql = string.Empty;

            foreach (string groupName in ht.Keys)
            {
                var sb = new StringBuilder();
                var tempSql = " AND ({0})";
                foreach (DictionaryEntry de in this._conditionTable)
                {
                    var searchInfo = (SearchInfo)de.Value;

                    //如果选择ExcludeIfEmpty为True,并且该字段为空值的话,跳过
                    if (searchInfo.ExcludeIfEmpty &&
                        (searchInfo.FieldValue == null || string.IsNullOrEmpty(searchInfo.FieldValue.ToString())))
                    {
                        continue;
                    }

                    if (groupName.Equals(searchInfo.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        sb.AppendFormat(" OR {0} {1} '{2}'", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator),
                            searchInfo.SqlOperator == SqlOperator.Like
                                ? string.Format("%{0}%", searchInfo.FieldValue)
                                : searchInfo.FieldValue);
                    }
                }

                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    tempSql = string.Format(tempSql, sb.ToString().Substring(3));//从第一个Or开始位置
                    sql += tempSql;
                }
            }

            return sql;
        }

        /// <summary>
        /// 获取给定条件集合的组别对象集合
        /// </summary>
        /// <returns></returns>
        private Hashtable GetGroupNames()
        {
            Hashtable htGroupNames = new Hashtable();
            foreach (DictionaryEntry de in this._conditionTable)
            {
                var searchInfo = (SearchInfo)de.Value;
                if (!string.IsNullOrEmpty(searchInfo.GroupName) && !htGroupNames.Contains(searchInfo.GroupName))
                {
                    htGroupNames.Add(searchInfo.GroupName, searchInfo.GroupName);
                }
            }

            return htGroupNames;
        }

        #region 辅助函数

        /// <summary>
        /// 转换枚举类型为对应的Sql语句操作符号
        /// </summary>
        /// <param name="sqlOperator">SqlOperator枚举对象</param>
        /// <returns><![CDATA[对应的Sql语句操作符号（如 ">" "<>" ">=")]]></returns>
        private string ConvertSqlOperator(SqlOperator sqlOperator)
        {
            string stringOperator = " = ";
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    stringOperator = " = ";
                    break;

                case SqlOperator.LessThan:
                    stringOperator = " < ";
                    break;

                case SqlOperator.LessThanOrEqual:
                    stringOperator = " <= ";
                    break;

                case SqlOperator.Like:
                    stringOperator = " Like ";
                    break;

                case SqlOperator.MoreThan:
                    stringOperator = " > ";
                    break;

                case SqlOperator.MoreThanOrEqual:
                    stringOperator = " >= ";
                    break;

                case SqlOperator.NotEqual:
                    stringOperator = " <> ";
                    break;

                case SqlOperator.In:
                    stringOperator = " in ";
                    break;
            }

            return stringOperator;
        }

        /// <summary>
        /// 根据传入对象的值类型获取其对应的DbType类型
        /// </summary>
        /// <param name="fieldValue">对象的值</param>
        /// <returns>DbType类型</returns>
        private DbType GetFieldDbType(object fieldValue)
        {
            DbType type = DbType.String;

            switch (fieldValue.GetType().ToString())
            {
                case "System.Int16":
                    type = DbType.Int16;
                    break;

                case "System.UInt16":
                    type = DbType.UInt16;
                    break;

                case "System.Single":
                    type = DbType.Single;
                    break;

                case "System.UInt32":
                    type = DbType.UInt32;
                    break;

                case "System.Int32":
                    type = DbType.Int32;
                    break;

                case "System.UInt64":
                    type = DbType.UInt64;
                    break;

                case "System.Int64":
                    type = DbType.Int64;
                    break;

                case "System.String":
                    type = DbType.String;
                    break;

                case "System.Double":
                    type = DbType.Double;
                    break;

                case "System.Decimal":
                    type = DbType.Decimal;
                    break;

                case "System.Byte":
                    type = DbType.Byte;
                    break;

                case "System.Boolean":
                    type = DbType.Boolean;
                    break;

                case "System.DateTime":
                    type = DbType.DateTime;
                    break;

                case "System.Guid":
                    type = DbType.Guid;
                    break;
            }
            return type;
        }

        #endregion 辅助函数
    }

    /// <summary>
    /// 查询信息实体类
    /// </summary>
    public class SearchInfo
    {
        private bool _excludeIfEmpty = true;

        public SearchInfo()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        public SearchInfo(string fieldName, object fieldValue, SqlOperator sqlOperator)
            : this(fieldName, fieldValue, sqlOperator, true)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        public SearchInfo(string fieldName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty)
            : this(fieldName, fieldValue, sqlOperator, excludeIfEmpty, null)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <param name="groupName">分组的名称，如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2"), 定义一个组名集中条件</param>
        public SearchInfo(string fieldName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty, string groupName)
        {
            this.FieldName = fieldName;
            this.FieldValue = fieldValue;
            this.SqlOperator = sqlOperator;
            this._excludeIfEmpty = excludeIfEmpty;
            this.GroupName = groupName;
        }

        /// <summary>
        /// 如果字段为空或者Null则不作为查询条件
        /// </summary>
        public bool ExcludeIfEmpty
        {
            get { return _excludeIfEmpty; }
            set { _excludeIfEmpty = value; }
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段的值
        /// </summary>
        public object FieldValue { get; set; }

        /// <summary>
        /// 分组的名称，如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2"), 定义一个组名集中条件
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 字段的Sql操作符号
        /// </summary>
        public SqlOperator SqlOperator { get; set; }
    }
}