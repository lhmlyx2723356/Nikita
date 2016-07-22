using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Nikita.Core
{
    /// <summary>DataTable帮助类
    ///
    /// </summary>
    public class DataTableHelper
    {
        public static DataSet Ds;

        private static ArrayList _groupByFieldInfo;

        private static string _groupByFieldList;

        private static ArrayList _mFieldInfo;

        private static string _mFieldList;

        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>返回Datatable 增加字段 identityid </returns>
        public static DataTable AddIdentityColumn(DataTable dt)
        {
            if (!dt.Columns.Contains("identityid"))
            {
                dt.Columns.Add("identityid");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["identityid"] = (i + 1).ToString();
                }
            }
            return dt;
        }

        /// <summary>根据nameList里面的字段创建一个表格,返回该表格的DataTable
        ///
        /// </summary>
        /// <param name="nameList">包含字段信息的列表</param>
        /// <returns>DataTable</returns>
        public static DataTable CreateTable(List<string> nameList)
        {
            if (nameList.Count <= 0)
                return null;

            DataTable myDataTable = new DataTable();
            foreach (string columnName in nameList)
            {
                myDataTable.Columns.Add(columnName, typeof(string));
            }
            return myDataTable;
        }

        /// <summary>通过字符列表创建表字段，字段格式可以是：1) a,b,c,d,e2) a|int,b|string,c|bool,d|decimal
        ///
        /// </summary>
        /// <param name="nameString"></param>
        /// <returns></returns>
        public static DataTable CreateTable(string nameString)
        {
            string[] nameArray = nameString.Split(new char[] { ',', ';' });
            var nameList = new List<string>();
            DataTable dt = new DataTable();
            foreach (string item in nameArray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] subItems = item.Split('|');
                    if (subItems.Length == 2)
                    {
                        dt.Columns.Add(subItems[0], ConvertType(subItems[1]));
                    }
                    else
                    {
                        dt.Columns.Add(subItems[0]);
                    }
                }
            }
            return dt;
        }

        /// <summary>DataTable转换成实体列表
        ///
        /// </summary>
        /// <typeparam name="T">实体 T </typeparam>
        /// <param name="table">datatable</param>
        /// <returns></returns>
        public static IList<T> DataTableToList<T>(DataTable table)
            where T : class
        {
            if (!IsHaveRows(table))
                return new List<T>();

            IList<T> list = new List<T>();
            foreach (DataRow dr in table.Rows)
            {
                var model = Activator.CreateInstance<T>();

                foreach (DataColumn dc in dr.Table.Columns)
                {
                    object drValue = dr[dc.ColumnName];
                    PropertyInfo pi = model.GetType().GetProperty(dc.ColumnName);

                    if (pi != null && pi.CanWrite && (drValue != null && !Convert.IsDBNull(drValue)))
                    {
                        pi.SetValue(model, drValue, null);
                    }
                }

                list.Add(model);
            }
            return list;
        }

        /// <summary> Distinct方法，按照fieldName从sourceTable中选择出不重复的行
        ///  相当于select distinct fieldName from sourceTable
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="fieldName">显示的列名，用逗号分隔</param>
        /// <returns>一个新的不含重复行的DataTable，列只包括fieldName指明的列</returns>
        public static DataTable Distinct(DataTable sourceTable, string fieldName)
        {
            DataTable dt = new DataTable("temp");

            dt.Columns.Add(fieldName, sourceTable.Columns[fieldName].DataType);

            object lastValue = null;
            foreach (DataRow dr in sourceTable.Select("", fieldName))
            {
                if (lastValue == null || !(ColumnEqual(lastValue, dr[fieldName])))
                {
                    lastValue = dr[fieldName];
                    dt.Rows.Add(lastValue);
                }
            }
            if (Ds != null && !Ds.Tables.Contains("temp"))
            {
                Ds.Tables.Add(dt);
            }
            return dt;
        }

        /// <summary>Filter方法，通过参数对表格过滤
        ///
        /// </summary>
        /// <param name="sourceTable">原始数据表</param>
        /// <param>要过滤的字段，用逗号分隔，如:"Class='二班'|ID='2'"
        ///     <name>rowFilter</name>
        /// </param>
        /// <param name="rowFilter"></param>
        /// <returns></returns>
        public static DataTable Filter(DataTable sourceTable, string rowFilter)
        {
            DataTable dt = sourceTable.Clone();
            string[] filter = rowFilter.Split('|');
            foreach (string t in filter)
            {
                dt.Clear();
                InsertInto(dt, sourceTable, t);
            }
            return dt;
        }

        /// <summary>根据条件过滤表的内容
        ///
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable FilterDataTable(DataTable dt, string condition)
        {
            if (condition.Trim() == "")
            {
                return dt;
            }
            else
            {
                var newdt = dt.Clone();
                DataRow[] dr = dt.Select(condition);
                foreach (DataRow t in dr)
                {
                    newdt.ImportRow(t);
                }
                return newdt;
            }
        }

        /// <summary>获得从DataRowCollection转换成的DataRow数组
        ///
        /// </summary>
        /// <param name="drc">DataRowCollection</param>
        /// <returns></returns>
        public static DataRow[] GetDataRowArray(DataRowCollection drc)
        {
            int count = drc.Count;
            DataRow[] drs = new DataRow[count];
            for (int i = 0; i < count; i++)
            {
                drs[i] = drc[i];
            }
            return drs;
        }

        /// <summary>获取DataTable中的某个字段的值用逗号隔开
        ///
        /// </summary>
        /// <param name="dtUserName"></param>
        /// <param name="fiedName"></param>
        /// <param name="spilt"></param>
        /// <returns></returns>
        public static string GetStringWithSplit(DataTable dtUserName, string fiedName, char spilt)
        {
            string userNames = string.Empty;
            for (int i = 0; i < dtUserName.Rows.Count; i++)
            {
                userNames = userNames + dtUserName.Rows[i][fiedName] + spilt;
            }
            return userNames.TrimEnd(spilt);
        }

        /// <summary>将DataRow数组转换成DataTable，注意行数组的每个元素须具有相同的数据结构，否则当有元素长度大于第一个元素时，抛出异常
        ///
        /// </summary>
        /// <param name="rows">行数组</param>
        /// <returns></returns>
        public static DataTable GetTableFromRows(DataRow[] rows)
        {
            if (rows.Length <= 0)
            {
                return new DataTable();
            }
            DataTable dt = rows[0].Table.Clone();
            dt.DefaultView.Sort = rows[0].Table.DefaultView.Sort;
            foreach (DataRow t in rows)
            {
                dt.LoadDataRow(t.ItemArray, true);
            }
            return dt;
        }

        /// <summary>GroupBy方法，通过参数对表格实现分组
        ///
        /// </summary>
        /// <param name="sourceTable">原始数据表</param>
        /// <param name="fieldList">聚合函数字段，用逗号分隔。如:"ID,SUM(Num),COUNT(ID)"</param>
        /// <param name="groupBy">要分组的字段，用逗号分隔，如:"ID,Num"</param>
        /// <returns></returns>
        public static DataTable GroupBy(DataTable sourceTable, string fieldList, string groupBy)
        {
            DataTable dt = CreateGroupByTable(sourceTable, fieldList);

            InsertGroupByInto(dt, sourceTable, fieldList, groupBy);

            return dt;
        }

        /// <summary>构造DataTab
        ///
        /// </summary>
        /// <param name="columns">列数</param>
        /// <param name="rows">行数</param>
        /// <returns></returns>
        public static DataTable InitDataTable(int columns, int rows)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < columns; i++)
            {
                dt.Columns.Add("Column" + i, typeof(string));
            }

            for (int j = 0; j < rows; j++)
            {
                DataRow dr = dt.NewRow();
                for (int k = 0; k < columns; k++)
                {
                    dr[k] = "Data" + k;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>初始化构建空表
        ///
        /// </summary>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public static DataTable InitEmptyDataTable(string[] columnNames)
        {
            DataTable dt = new DataTable();
            foreach (string t in columnNames)
            {
                dt.Columns.Add(t, typeof(string));
            }

            return dt;
        }

        /// <summary> 给DataTable增加一个自增列,如果DataTable 存在 identityid 字段  则 直接返回DataTable 不做任何处理
        /// <summary>检查DataTable 是否有数据行
        ///
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static bool IsHaveRows(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
                return true;

            return false;
        }

        /// <summary> JOIN方法，通过参数实现两个表的INNER JOIN,LEFT JOIN,RIGHT JOIN,FULL JOIN
        ///
        /// </summary>
        /// <param name="left">左表</param>
        /// <param name="right">右表</param>
        /// <param name="leftCols">左表列</param>
        /// <param name="rightCols">右表列</param>
        /// <param name="includeLeftJoin">是否包含左联</param>
        /// <param name="includeRightJoin">是否包含右联</param>
        /// <returns></returns>
        public static DataTable Join(DataTable left, DataTable right, DataColumn[] leftCols,
            DataColumn[] rightCols, bool includeLeftJoin, bool includeRightJoin)
        {
            DataTable result = new DataTable("JoinResult");
            using (DataSet ds = new DataSet())
            {
                ds.Tables.AddRange(new[] { left.Copy(), right.Copy() });
                DataColumn[] leftRelationCols = new DataColumn[leftCols.Length];
                for (int i = 0; i < leftCols.Length; i++)
                    leftRelationCols[i] = ds.Tables[0].Columns[leftCols[i].ColumnName];

                DataColumn[] rightRelationCols = new DataColumn[rightCols.Length];
                for (int i = 0; i < rightCols.Length; i++)
                    rightRelationCols[i] = ds.Tables[1].Columns[rightCols[i].ColumnName];

                //create result columns
                for (int i = 0; i < left.Columns.Count; i++)
                    result.Columns.Add(left.Columns[i].ColumnName, left.Columns[i].DataType);
                for (int i = 0; i < right.Columns.Count; i++)
                {
                    string colName = right.Columns[i].ColumnName;
                    while (result.Columns.Contains(colName))
                        colName += "_2";
                    result.Columns.Add(colName, right.Columns[i].DataType);
                }

                //add left join relations
                DataRelation drLeftJoin = new DataRelation("rLeft", leftRelationCols, rightRelationCols, false);
                ds.Relations.Add(drLeftJoin);

                //join
                result.BeginLoadData();
                foreach (DataRow parentRow in ds.Tables[0].Rows)
                {
                    DataRow[] childrenRowList = parentRow.GetChildRows(drLeftJoin);
                    if (childrenRowList.Length > 0)
                    {
                        object[] parentArray = parentRow.ItemArray;
                        foreach (DataRow childRow in childrenRowList)
                        {
                            object[] childArray = childRow.ItemArray;
                            object[] joinArray = new object[parentArray.Length + childArray.Length];
                            Array.Copy(parentArray, 0, joinArray, 0, parentArray.Length);
                            Array.Copy(childArray, 0, joinArray, parentArray.Length, childArray.Length);
                            result.LoadDataRow(joinArray, true);
                        }
                    }
                    else //left join
                    {
                        if (includeLeftJoin)
                        {
                            object[] parentArray = parentRow.ItemArray;
                            object[] joinArray = new object[parentArray.Length];
                            Array.Copy(parentArray, 0, joinArray, 0, parentArray.Length);
                            result.LoadDataRow(joinArray, true);
                        }
                    }
                }

                if (includeRightJoin)
                {
                    //add right join relations
                    DataRelation drRightJoin = new DataRelation("rRight", rightRelationCols, leftRelationCols, false);
                    ds.Relations.Add(drRightJoin);

                    foreach (DataRow parentRow in ds.Tables[1].Rows)
                    {
                        DataRow[] childrenRowList = parentRow.GetChildRows(drRightJoin);
                        if (childrenRowList.Length == 0)
                        {
                            object[] parentArray = parentRow.ItemArray;
                            object[] joinArray = new object[result.Columns.Count];
                            Array.Copy(parentArray, 0, joinArray,
                            joinArray.Length - parentArray.Length, parentArray.Length);
                            result.LoadDataRow(joinArray, true);
                        }
                    }
                }
                result.EndLoadData();
            }
            return result;
        }

        /// <summary>实体列表转换成DataTable
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="list"> 实体列表</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IList<T> list)
            where T : class
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable(typeof(T).Name);

            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            int length = myPropertyInfo.Length;
            bool createColumn = true;

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                var row = dt.NewRow();
                for (int i = 0; i < length; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];
                    string name = pi.Name;
                    if (createColumn)
                    {
                        var column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                if (createColumn)
                {
                    createColumn = false;
                }

                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>取两个DataTable的交集,删除重复数据
        ///
        /// </summary>
        /// <param name="sourceDataTable">源DataTable</param>
        /// <param name="targetDataTable">目标DataTable</param>
        /// <param name="primaryKey">两个表的主键</param>
        /// <returns>合并后的表</returns>
        public static DataTable Merge(DataTable sourceDataTable, DataTable targetDataTable, string primaryKey)
        {
            if (sourceDataTable != null || targetDataTable != null || !sourceDataTable.Equals(targetDataTable))
            {
                if (sourceDataTable != null)
                {
                    sourceDataTable.PrimaryKey = new[] { sourceDataTable.Columns[primaryKey] };

                    if (targetDataTable != null)
                    {
                        DataTable dt = targetDataTable.Copy();

                        foreach (DataRow tRow in dt.Rows)
                        {
                            //拒绝自上次调用 System.Data.DataRow.AcceptChanges() 以来对该行进行的所有更改。

                            //因为行状态为DataRowState.Deleted时无法访问ItemArray的值

                            tRow.RejectChanges();

                            //在加载数据时关闭通知、索引维护和约束。

                            sourceDataTable.BeginLoadData();

                            //查找和更新特定行。如果找不到任何匹配行，则使用给定值创建新行。

                            DataRow temp = sourceDataTable.LoadDataRow(tRow.ItemArray, true);

                            sourceDataTable.EndLoadData();

                            sourceDataTable.Rows.Remove(temp);
                        }
                    }
                }
            }

            if (sourceDataTable != null)
            {
                sourceDataTable.AcceptChanges();
            }
            return sourceDataTable;
        }

        /// <summary>合并两个结构相同的表
        ///
        /// </summary>
        /// <param name="dt1">表1</param>
        /// <param name="dt2">表2</param>
        /// <returns></returns>
        public static DataTable MergeDataTable(DataTable dt1, DataTable dt2)
        {
            DataTable newTable = dt1.Copy();
            foreach (DataRow dr in dt2.Rows)
            {
                newTable.ImportRow(dr);
            }
            return newTable;
        }

        /// <summary>排序表的视图
        ///
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sorts"></param>
        /// <returns></returns>
        public static DataTable SortedTable(DataTable dt, params string[] sorts)
        {
            if (dt.Rows.Count > 0)
            {
                string tmp = sorts.Aggregate("", (current, t) => current + (t + ","));
                dt.DefaultView.Sort = tmp.TrimEnd(',');
            }
            return dt;
        }

        /// <summary>将泛型集合类转换成DataTable
        ///
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable(list, null);
        }

        /// <summary>将泛型集合类转换成DataTable
        ///
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="propertyName">需要返回的列的列名</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);

            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                        {
                            result.Columns.Add(pi.Name, pi.PropertyType);
                        }
                    }
                }

                foreach (T t in list)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(t, null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(t, null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /// <summary>UnionAll方法，实现对两张结构相近的数据表的合并
        ///
        /// </summary>
        /// <param name="sourceTable">原始数据表1</param>
        /// <param name="sourceTable2">原始数据表2</param>
        /// <returns></returns>
        public static DataTable UnionAll(DataTable sourceTable, DataTable sourceTable2)
        {
            sourceTable.Merge(sourceTable2);
            return sourceTable;
        }

        /// <summary> 将两个列不同(结构不同)的DataTable合并成一个新的DataTable
        ///
        /// </summary>
        /// <param name="dataTable1">表1</param>
        /// <param name="dataTable2">表2</param>
        /// <param name="dtName">合并后新的表名</param>
        /// <returns>合并后的新表</returns>
        public static DataTable UniteDataTable(DataTable dataTable1, DataTable dataTable2, string dtName)
        {
            //克隆DataTable1的结构
            DataTable newDataTable = dataTable1.Clone();
            for (int i = 0; i < dataTable2.Columns.Count; i++)
            {
                //再向新表中加入DataTable2的列结构
                newDataTable.Columns.Add(dataTable2.Columns[i].ColumnName);
            }
            object[] obj = new object[newDataTable.Columns.Count];
            //添加DataTable1的数据
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                dataTable1.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }

            if (dataTable1.Rows.Count >= dataTable2.Rows.Count)
            {
                for (int i = 0; i < dataTable2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable2.Columns.Count; j++)
                    {
                        newDataTable.Rows[i][j + dataTable1.Columns.Count] = dataTable2.Rows[i][j].ToString();
                    }
                }
            }
            else
            {
                //向新表中添加多出的几行
                for (int i = 0; i < dataTable2.Rows.Count - dataTable1.Rows.Count; i++)
                {
                    var dr3 = newDataTable.NewRow();
                    newDataTable.Rows.Add(dr3);
                }
                for (int i = 0; i < dataTable2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable2.Columns.Count; j++)
                    {
                        newDataTable.Rows[i][j + dataTable1.Columns.Count] = dataTable2.Rows[i][j].ToString();
                    }
                }
            }
            newDataTable.TableName = dtName; //设置DT的名字
            return newDataTable;
        }

        /// <summary> 将两个列不同(结构不同)的DataTable合并成一个新的DataTable
        ///
        /// </summary>
        /// <param name="dataTable1">表1</param>
        /// <param name="dataTable2">表2</param>
        /// <param name="dtName">合并后新的表名</param>
        /// <returns>合并后的新表</returns>
        public static DataTable UniteDataTable2(DataTable dataTable1, DataTable dataTable2, string dtName)
        {
            var newDataTable = dataTable1.Rows.Count > dataTable2.Rows.Count ? FillData(dataTable1, dataTable2) : FillData(dataTable2, dataTable1);
            newDataTable.TableName = dtName; //设置DT的名字
            return newDataTable;
        }

        /// <summary>过滤DataTable
        ///
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="strFilter">过滤条件 ID =1</param>
        /// <param name="sort"> Name ASC</param>
        /// <returns></returns>
        public DataTable FilterDataTable(DataTable dt, string strFilter, string sort)
        {
            var dtNew = sort.Trim().Length == 0 ? dt.Select(strFilter).CopyToDataTable() : dt.Select(strFilter, sort).CopyToDataTable();
            return dtNew;
        }

        private static object Add(object a, object b)
        {
            if (a is DBNull)
            {
                return b;
            }
            if (b is DBNull)
            {
                return a;
            }
            return (Convert.ToDecimal(a) + Convert.ToDecimal(b));
        }

        private static bool ColumnEqual(object objectA, object objectB)
        {
            if (objectA == DBNull.Value && objectB == DBNull.Value)
            {
                return true;
            }
            if (objectA == DBNull.Value || objectB == DBNull.Value)
            {
                return false;
            }
            return (objectA.Equals(objectB));
        }

        private static Type ConvertType(string typeName)
        {
            typeName = typeName.ToLower().Replace("system.", "");
            Type newType = typeof(string);
            switch (typeName)
            {
                case "boolean":
                case "bool":
                    newType = typeof(bool);
                    break;

                case "int16":
                case "short":
                    newType = typeof(short);
                    break;

                case "int32":
                case "int":
                    newType = typeof(int);
                    break;

                case "long":
                case "int64":
                    newType = typeof(long);
                    break;

                case "uint16":
                case "ushort":
                    newType = typeof(ushort);
                    break;

                case "uint32":
                case "uint":
                    newType = typeof(uint);
                    break;

                case "uint64":
                case "ulong":
                    newType = typeof(ulong);
                    break;

                case "single":
                case "float":
                    newType = typeof(float);
                    break;

                case "string":
                    newType = typeof(string);
                    break;

                case "guid":
                    newType = typeof(Guid);
                    break;

                case "decimal":
                    newType = typeof(decimal);
                    break;

                case "double":
                    newType = typeof(double);
                    break;

                case "datetime":
                    newType = typeof(DateTime);
                    break;

                case "byte":
                    newType = typeof(byte);
                    break;

                case "char":
                    newType = typeof(char);
                    break;
            }
            return newType;
        }

        private static DataTable CreateGroupByTable(DataTable sourceTable, string fieldList)
        {
            if (string.IsNullOrEmpty(fieldList))
            {
                return sourceTable.Clone();
            }
            else
            {
                DataTable dt = new DataTable();
                ParseGroupByFieldList(fieldList);
                foreach (FieldInfo field in _groupByFieldInfo)
                {
                    DataColumn dc = sourceTable.Columns[field.FieldName];
                    if (field.Aggregate == null)
                    {
                        dt.Columns.Add(field.FieldAlias, dc.DataType, dc.Expression);
                    }
                    else
                    {
                        dt.Columns.Add(field.FieldAlias, dc.DataType);
                    }
                }
                if (Ds != null)
                {
                    Ds.Tables.Add(dt);
                }
                return dt;
            }
        }

        private static DataTable FillData(DataTable dt1, DataTable dt2)
        {
            //克隆DataTable1的结构
            DataTable newDataTable = dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                //再向新表中加入DataTable2的列结构
                newDataTable.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[newDataTable.Columns.Count];
            //添加DataTable1的数据
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    newDataTable.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                }
            }
            return newDataTable;
        }

        private static void InsertGroupByInto(DataTable destTable, DataTable sourceTable, string fieldList, string groupBy)
        {
            if (string.IsNullOrEmpty(fieldList))
            {
                return;
            }
            ParseGroupByFieldList(fieldList);
            ParseFieldList(groupBy, false);
            DataRow[] rows = sourceTable.Select("", groupBy);
            DataRow lastSourceRow = null, destRow = null;
            int rowCount = 0;
            foreach (DataRow sourceRow in rows)
            {
                var sameRow = false;
                if (lastSourceRow != null)
                {
                    sameRow = _mFieldInfo.Cast<FieldInfo>().All(field => ColumnEqual(lastSourceRow[field.FieldName], sourceRow[field.FieldName]));
                    if (!sameRow)
                    {
                        destTable.Rows.Add(destRow);
                    }
                }
                if (!sameRow)
                {
                    destRow = destTable.NewRow();
                    rowCount = 0;
                }
                rowCount += 1;
                foreach (FieldInfo field in _groupByFieldInfo)
                {
                    string aggregate = null;
                    if (field.Aggregate == null)
                    {
                    }
                    else
                    {
                        aggregate = field.Aggregate.ToLower();
                    }
                    switch (aggregate)
                    {
                        case null:
                        case "":
                        case "last":
                            destRow[field.FieldAlias] = sourceRow[field.FieldName];
                            break;

                        case "first":
                            if (rowCount == 1)
                            {
                                destRow[field.FieldAlias] = sourceRow[field.FieldName];
                            }
                            break;

                        case "count":
                            destRow[field.FieldAlias] = rowCount;
                            break;

                        case "sum":
                            destRow[field.FieldAlias] = Add(destRow[field.FieldAlias], sourceRow[field.FieldName]);
                            break;

                        case "max":
                            destRow[field.FieldAlias] = Max(destRow[field.FieldAlias], sourceRow[field.FieldName]);
                            break;

                        case "min":
                            if (rowCount == 1)
                            {
                                destRow[field.FieldAlias] = sourceRow[field.FieldName];
                            }
                            else
                            {
                                destRow[field.FieldAlias] = Min(destRow[field.FieldAlias], sourceRow[field.FieldName]);
                            }
                            break;
                    }
                }
                lastSourceRow = sourceRow;
            }
            if (destRow != null)
            {
                destTable.Rows.Add(destRow);
            }
        }

        private static void InsertInto(DataTable destTable, DataTable sourceTable, string rowFilter)
        {
            DataRow[] rows = sourceTable.Select(rowFilter);
            foreach (DataRow sourceRow in rows)
            {
                var destRow = destTable.NewRow();

                foreach (DataColumn dc in destRow.Table.Columns)
                {
                    if (dc.Expression == "")
                    {
                        destRow[dc] = sourceRow[dc.ColumnName];
                    }
                }
                destTable.Rows.Add(destRow);
            }
        }

        private static object Max(object a, object b)
        {
            if (a is DBNull)
            {
                return b;
            }
            if (b is DBNull)
            {
                return a;
            }
            if (((IComparable)a).CompareTo(b) == 1)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private static object Min(object a, object b)
        {
            if ((a is DBNull) || (b is DBNull))
            {
                return DBNull.Value;
            }
            if (((IComparable)a).CompareTo(b) == -1)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private static void ParseFieldList(string fieldList, bool allowRelation)
        {
            if (_mFieldList == fieldList)
            {
                return;
            }
            _mFieldInfo = new ArrayList();
            _mFieldList = fieldList;
            string[] fields = fieldList.Split(',');
            for (int i = 0; i <= fields.Length - 1; i++)
            {
                var field = new FieldInfo();
                var fieldParts = fields[i].Trim().Split(' ');
                switch (fieldParts.Length)
                {
                    case 1:
                        //to be set at the end of the loop
                        break;

                    case 2:
                        field.FieldAlias = fieldParts[1];
                        break;

                    default:
                        return;
                }
                fieldParts = fieldParts[0].Split('.');
                switch (fieldParts.Length)
                {
                    case 1:
                        field.FieldName = fieldParts[0];
                        break;

                    case 2:
                        if (allowRelation == false)
                        {
                            return;
                        }
                        field.RelationName = fieldParts[0].Trim();
                        field.FieldName = fieldParts[1].Trim();
                        break;

                    default:
                        return;
                }
                if (field.FieldAlias == null)
                {
                    field.FieldAlias = field.FieldName;
                }
                _mFieldInfo.Add(field);
            }
        }

        private static void ParseGroupByFieldList(string fieldList)
        {
            if (_groupByFieldList == fieldList)
            {
                return;
            }
            _groupByFieldInfo = new ArrayList();
            string[] fields = fieldList.Split(',');
            for (int i = 0; i <= fields.Length - 1; i++)
            {
                var field = new FieldInfo();
                var fieldParts = fields[i].Trim().Split(' ');
                switch (fieldParts.Length)
                {
                    case 1:
                        //to be set at the end of the loop
                        break;

                    case 2:
                        field.FieldAlias = fieldParts[1];
                        break;

                    default:
                        return;
                }

                fieldParts = fieldParts[0].Split('(');
                switch (fieldParts.Length)
                {
                    case 1:
                        field.FieldName = fieldParts[0];
                        break;

                    case 2:
                        field.Aggregate = fieldParts[0].Trim().ToLower();
                        field.FieldName = fieldParts[1].Trim(' ', ')');
                        break;

                    default:
                        return;
                }
                if (field.FieldAlias == null)
                {
                    if (field.Aggregate == null)
                    {
                        field.FieldAlias = field.FieldName;
                    }
                    else
                    {
                        field.FieldAlias = field.Aggregate + "of" + field.FieldName;
                    }
                }
                _groupByFieldInfo.Add(field);
            }
            _groupByFieldList = fieldList;
        }

        private class FieldInfo
        {
            public string Aggregate;
            public string FieldAlias;
            public string FieldName;
            public string RelationName;
        }
    }
}