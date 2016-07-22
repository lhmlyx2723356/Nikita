using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Core
{
    public class MsDBHelper
    {
        public static string GetMsInsertSql(DataTable dt, List<string> excludedFields = null)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            List<string> fieldNames = new List<string>();
            List<dynamic> columnConverts = new List<dynamic>();
            var columnTypes = new List<Type>();

            #region 获得字段的名称与转换器

            foreach (DataColumn col in dt.Columns)
            {
                if ((excludedFields != null) && (excludedFields.Contains(col.ColumnName)))
                {
                    continue;
                }
                fieldNames.Add(col.ColumnName);
                columnTypes.Add(col.DataType);
                if (col.DataType == typeof(Int64))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Int64 s = (Int64)s1;
                        return s.ToString();
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(Boolean))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Boolean s = (Boolean)s1;
                        if (s)
                        {
                            return "1";
                        }
                        return "0";
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(String))
                {
                    Func<object, string> convert = s1 =>
                    {
                        String s = (String)s1;
                        return "'" + s.Replace("'", "''") + "'";
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(DateTime))
                {
                    Func<object, string> convert = s1 =>
                    {
                        DateTime s = (DateTime)s1;
                        return "'";// +DateTimeHelper.GetFullString(s) + "'";
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(Decimal))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Decimal s = (Decimal)s1;
                        return s.ToString();
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(Double))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Double s = (Double)s1;
                        return s.ToString();
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(Single))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Single s = (Single)s1;
                        return s.ToString();
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(Int16))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Int16 s = (Int16)s1;
                        return s.ToString();
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(Guid))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Guid s = (Guid)s1;
                        return "'" + s.ToString() + "'";
                    };
                    columnConverts.Add(convert);
                }
                else if (col.DataType == typeof(Byte))
                {
                    Func<object, string> convert = s1 =>
                    {
                        Byte s = (Byte)s1;
                        return s.ToString();
                    };
                    columnConverts.Add(convert);
                }
                else
                {
                    // 对于byte[]等类型暂时不处理
                    columnConverts.Add(null);
                }
            }

            #endregion 获得字段的名称与转换器

            #region 数据库字段类型与C#类型的对应关系

            /*
            bigintCol---System.Int64
            binaryCol---System.Byte[]
            bitCol---System.Boolean
            charCol---System.String
            datetimeCol---System.DateTime
            decimalCol---System.Decimal
            floatCol---System.Double
            intCol---System.Int64
            imageCol---System.Byte[]
            moneyCol---System.Decimal
            ncharCol---System.String
            ntextCol---System.String
            numericCol---System.Decimal
            nvarcharCol---System.String
            realCol---System.Single
            smalldatetimeCol---System.DateTime
            smallintCol---System.Int16
            smallmoneyCol---System.Decimal
            sql_variantCol---System.Object
            textCol---System.Int64
            timestampCol---System.Byte[]
            tinyintCol---System.Byte
            uniqueidentifierCol---System.Guid
            varcharCol---System.String
            xmlCol---System.String
            */

            #endregion 数据库字段类型与C#类型的对应关系

            string insertSql = string.Format(" insert into {0} ({1}) values ("
                , dt.TableName, string.Join(",", fieldNames));

            foreach (DataRow dr in dt.Rows)
            {
                sqlBuilder.Append(insertSql);
                bool isStart = true;
                for (int i = 0; i < fieldNames.Count; i++)
                {
                    if (isStart)
                    {
                        isStart = false;
                    }
                    else
                    {
                        sqlBuilder.Append(",");
                    }
                    if (Convert.IsDBNull(dr[fieldNames[i]]) || columnConverts[i] == null)
                    {
                        sqlBuilder.Append("null");
                    }
                    else
                    {
                        //object obj = dr.Field<columnTypes[i]>(fieldNames[i]);
                        sqlBuilder.Append(columnConverts[i](dr[fieldNames[i]]));
                    }
                }
                sqlBuilder.Append(")");
                sqlBuilder.AppendLine();
            }
            return sqlBuilder.ToString();
        }
    }
}