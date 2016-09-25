using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace Nikita.DataAccess.Expression2Sql.Mapper
{
    /// <summary>
    /// ** 描述：DataReader实体生成
    /// </summary>
    public class DataReaderEntityBuilder<T>
    {
        private static readonly MethodInfo isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new Type[] { typeof(int) });

        //default method
        private static readonly MethodInfo getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new Type[] { typeof(int) });

        //dr valueType method
        private static readonly MethodInfo getBoolean = typeof(IDataRecord).GetMethod("GetBoolean", new Type[] { typeof(int) });

        private static readonly MethodInfo getByte = typeof(IDataRecord).GetMethod("GetByte", new Type[] { typeof(int) });
        private static readonly MethodInfo getDateTime = typeof(IDataRecord).GetMethod("GetDateTime", new Type[] { typeof(int) });
        private static readonly MethodInfo getDecimal = typeof(IDataRecord).GetMethod("GetDecimal", new Type[] { typeof(int) });
        private static readonly MethodInfo getDouble = typeof(IDataRecord).GetMethod("GetDouble", new Type[] { typeof(int) });
        private static readonly MethodInfo getFloat = typeof(IDataRecord).GetMethod("GetFloat", new Type[] { typeof(int) });
        private static readonly MethodInfo getGuid = typeof(IDataRecord).GetMethod("GetGuid", new Type[] { typeof(int) });
        private static readonly MethodInfo getInt16 = typeof(IDataRecord).GetMethod("GetInt16", new Type[] { typeof(int) });
        private static readonly MethodInfo getInt32 = typeof(IDataRecord).GetMethod("GetInt32", new Type[] { typeof(int) });
        private static readonly MethodInfo getInt64 = typeof(IDataRecord).GetMethod("GetInt64", new Type[] { typeof(int) });
        private static readonly MethodInfo getString = typeof(IDataRecord).GetMethod("GetString", new Type[] { typeof(int) });

        //convert method
        private static readonly MethodInfo getConvertBoolean = typeof(DataRecordExtensions).GetMethod("GetConvertBoolean");

        private static readonly MethodInfo getConvertByte = typeof(DataRecordExtensions).GetMethod("GetConvertByte");
        private static readonly MethodInfo getConvertChar = typeof(DataRecordExtensions).GetMethod("GetConvertChar");
        private static readonly MethodInfo getConvertDateTime = typeof(DataRecordExtensions).GetMethod("GetConvertDateTime");
        private static readonly MethodInfo getConvertDecimal = typeof(DataRecordExtensions).GetMethod("GetConvertDecimal");
        private static readonly MethodInfo getConvertDouble = typeof(DataRecordExtensions).GetMethod("GetConvertDouble");
        private static readonly MethodInfo getConvertGuid = typeof(DataRecordExtensions).GetMethod("GetConvertGuid");
        private static readonly MethodInfo getConvertInt16 = typeof(DataRecordExtensions).GetMethod("GetConvertInt16");
        private static readonly MethodInfo getConvertInt32 = typeof(DataRecordExtensions).GetMethod("GetConvertInt32");
        private static readonly MethodInfo getConvetInt64 = typeof(DataRecordExtensions).GetMethod("getConvetInt64");
        private static readonly MethodInfo getConvertToEnum_Nullable = typeof(DataRecordExtensions).GetMethod("GetConvertEnum_Nullable");
        private static readonly MethodInfo getOtherNull = typeof(DataRecordExtensions).GetMethod("GetOtherNull");
        private static readonly MethodInfo getOther = typeof(DataRecordExtensions).GetMethod("GetOther");

        private delegate T Load(IDataRecord dataRecord);

        private Load handler;

        public T Build(IDataRecord dataRecord)
        {
            return handler(dataRecord);
        }

        public static DataReaderEntityBuilder<T> CreateBuilder(Type type, IDataRecord dataRecord)
        {
            {
                DataReaderEntityBuilder<T> dynamicBuilder = new DataReaderEntityBuilder<T>();
                DynamicMethod method = new DynamicMethod("DynamicCreateEntity", type,
                        new Type[] { typeof(IDataRecord) }, type, true);
                ILGenerator generator = method.GetILGenerator();
                LocalBuilder result = generator.DeclareLocal(type);
                generator.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
                generator.Emit(OpCodes.Stloc, result);
                for (int i = 0; i < dataRecord.FieldCount; i++)
                {
                    string fieldName = dataRecord.GetName(i);
                    PropertyInfo propertyInfo = type.GetProperty(fieldName);
                    Label endIfLabel = generator.DefineLabel();
                    if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                    {
                        bool isNullable = false;
                        var underType = MappingUntilTool.GetUnderType(propertyInfo, ref isNullable);

                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4, i);
                        generator.Emit(OpCodes.Callvirt, isDBNullMethod);
                        generator.Emit(OpCodes.Brtrue, endIfLabel);
                        generator.Emit(OpCodes.Ldloc, result);
                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4, i);
                        GeneratorCallMethod(generator, underType, isNullable, propertyInfo, dataRecord.GetDataTypeName(i), fieldName);
                        generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                        generator.MarkLabel(endIfLabel);
                    }
                }
                generator.Emit(OpCodes.Ldloc, result);
                generator.Emit(OpCodes.Ret);
                dynamicBuilder.handler = (Load)method.CreateDelegate(typeof(Load));
                return dynamicBuilder;
            }
        }

        private static void CheckType(List<string> errorTypes, string objType, string dbType, string field)
        {
            var isAny = errorTypes.Contains(objType);
            if (isAny)
            {
                throw new Exception(string.Format("{0} can't  convert {1} to {2}", field, dbType, objType));
            }
        }

        /// <summary>
        /// 动态获取IDataRecord里面的函数
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="isNullable"></param>
        /// <param name="pro"></param>
        /// <param name="type"></param>
        /// <param name="dbTypeName"></param>
        /// <param name="fieldName"></param>
        private static void GeneratorCallMethod(ILGenerator generator, Type type, bool isNullable, PropertyInfo pro, string dbTypeName, string fieldName)
        {
            List<string> guidThrow = new List<string>() { "int32", "datetime", "decimal", "double", "byte", "string" };//数据库为GUID有错的实体类形
            List<string> intThrow = new List<string>() { "datetime", "byte" };//数据库为int有错的实体类形
            List<string> stringThrow = new List<string>() { "int32", "datetime", "decimal", "double", "byte", "guid" };//数据库为vachar有错的实体类形
            List<string> decimalThrow = new List<string>() { "datetime", "byte", "guid" };
            List<string> doubleThrow = new List<string>() { "datetime", "byte", "guid" };
            List<string> dateThrow = new List<string>() { "int32", "decimal", "double", "byte", "guid" };
            List<string> shortThrow = new List<string>() { "datetime", "guid" };
            List<string> byteThrow = new List<string>() { "datetime", "guid" };
            MethodInfo method;
            var typeName = ChangeDbTypeToCSharpType(dbTypeName);
            var objTypeName = type.Name.ToLower();
            var isEnum = type.IsEnum;
            if (isEnum)
            {
                typeName = "ENUMNAME";
            }
            else if (dbTypeName.Contains("hierarchyid") || typeName == "byte[]" || objTypeName == "object")
            {
                generator.Emit(OpCodes.Call, getValueMethod);
                generator.Emit(OpCodes.Unbox_Any, pro.PropertyType);//找不到类型才执行拆箱（类型转换）
                return;
            }
            if (isNullable)
            {
                switch (typeName)
                {
                    case "int":
                        CheckType(intThrow, objTypeName, typeName, fieldName);
                        var isNotInt = objTypeName != "int32";
                        method = isNotInt ? getOtherNull.MakeGenericMethod(type) : getConvertInt32; break;
                    case "bool":
                        if (objTypeName != "bool" && objTypeName != "boolean")
                            method = getOtherNull.MakeGenericMethod(type);
                        else
                            method = getConvertBoolean; break;
                    case "string":
                        CheckType(stringThrow, objTypeName, typeName, fieldName);
                        method = getString; break;
                    case "dateTime":
                        CheckType(dateThrow, objTypeName, typeName, fieldName);
                        method = objTypeName != "datetime" ? getOtherNull.MakeGenericMethod(type) : getConvertDateTime; break;
                    case "decimal":
                        CheckType(decimalThrow, objTypeName, typeName, fieldName);
                        var isNotDecimal = objTypeName != "decimal";
                        method = isNotDecimal ? getOtherNull.MakeGenericMethod(type) : getConvertDecimal; break;
                    case "double":
                        CheckType(doubleThrow, objTypeName, typeName, fieldName);
                        var isNotDouble = objTypeName != "double";
                        method = isNotDouble ? getOtherNull.MakeGenericMethod(type) : getConvertDouble; break;
                    case "guid":
                        CheckType(guidThrow, objTypeName, typeName, fieldName);
                        method = objTypeName != "guid" ? getOtherNull.MakeGenericMethod(type) : getConvertGuid; break;
                    case "byte":
                        CheckType(byteThrow, objTypeName, typeName, fieldName);
                        method = objTypeName != "byte" ? getOtherNull.MakeGenericMethod(type) : getConvertByte; break;
                    case "ENUMNAME":
                        method = getConvertToEnum_Nullable.MakeGenericMethod(type); break;
                    case "short":
                        CheckType(shortThrow, objTypeName, typeName, fieldName);
                        var isNotShort = objTypeName != "int16" && objTypeName != "short";
                        method = isNotShort ? getOtherNull.MakeGenericMethod(type) : getConvertInt16;
                        break;

                    default:
                        method = getOtherNull.MakeGenericMethod(type); break;
                }

                generator.Emit(OpCodes.Call, method);
            }
            else
            {
                switch (typeName)
                {
                    case "int":
                        CheckType(intThrow, objTypeName, typeName, fieldName);
                        var isNotInt = objTypeName != "int32";
                        method = isNotInt ? getOther.MakeGenericMethod(type) : getInt32; break;
                    case "bool":
                        if (objTypeName != "bool" && objTypeName != "boolean")
                            method = getOther.MakeGenericMethod(type);
                        else
                            method = getBoolean; break;
                    case "string":
                        CheckType(stringThrow, objTypeName, typeName, fieldName);
                        method = getString; break;
                    case "dateTime":
                        CheckType(dateThrow, objTypeName, typeName, fieldName);
                        method = objTypeName != "datetime" ? getOther.MakeGenericMethod(type) : getDateTime; break;
                    case "decimal":
                        CheckType(decimalThrow, objTypeName, typeName, fieldName);
                        var isNotDecimal = objTypeName != "decimal";
                        method = isNotDecimal ? getOther.MakeGenericMethod(type) : getDecimal; break;
                    case "double":
                        CheckType(doubleThrow, objTypeName, typeName, fieldName);
                        var isNotDouble = objTypeName != "double";
                        method = isNotDouble ? getOther.MakeGenericMethod(type) : getDouble; break;
                    case "guid":
                        CheckType(guidThrow, objTypeName, typeName, fieldName);
                        method = objTypeName != "guid" ? getOther.MakeGenericMethod(type) : getGuid; break;
                    case "byte":
                        CheckType(byteThrow, objTypeName, typeName, fieldName);
                        method = objTypeName != "byte" ? getOther.MakeGenericMethod(type) : getByte; break;
                    case "ENUMNAME":
                        method = getValueMethod; break;
                    case "short":
                        CheckType(shortThrow, objTypeName, typeName, fieldName);
                        var isNotShort = objTypeName != "int16" && objTypeName != "short";
                        method = isNotShort ? getOther.MakeGenericMethod(type) : getInt16;
                        break;

                    default: method = getOther.MakeGenericMethod(type); break;
                }

                generator.Emit(OpCodes.Call, method);

                if (method == getValueMethod)
                {
                    generator.Emit(OpCodes.Unbox_Any, pro.PropertyType);//找不到类型才执行拆箱（类型转换）
                }
            }
        }

        /// <summary>
        /// 将SqlType转成C#Type
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static string ChangeDbTypeToCSharpType(string typeName)
        {
            string reval;
            switch (typeName.ToLower())
            {
                case "int":
                    reval = "int";
                    break;

                case "text":
                    reval = "string";
                    break;

                case "bigint":
                    reval = "long";
                    break;

                case "binary":
                    reval = "object";
                    break;

                case "bit":
                    reval = "bool";
                    break;

                case "char":
                    reval = "string";
                    break;

                case "datetime":
                    reval = "dateTime";
                    break;

                case "decimal":
                    reval = "decimal";
                    break;

                case "float":
                    reval = "double";
                    break;

                case "image":
                    reval = "byte[]";
                    break;

                case "money":
                    reval = "decimal";
                    break;

                case "nchar":
                    reval = "string";
                    break;

                case "ntext":
                    reval = "string";
                    break;

                case "numeric":
                    reval = "decimal";
                    break;

                case "nvarchar":
                    reval = "string";
                    break;

                case "real":
                    reval = "float";
                    break;

                case "smalldatetime":
                    reval = "dateTime";
                    break;

                case "smallint":
                    reval = "short";
                    break;

                case "smallmoney":
                    reval = "decimal";
                    break;

                case "timestamp":
                    reval = "dateTime";
                    break;

                case "tinyint":
                    reval = "byte";
                    break;

                case "uniqueidentifier":
                    reval = "guid";
                    break;

                case "varbinary":
                    reval = "byte[]";
                    break;

                case "varchar":
                    reval = "string";
                    break;

                case "Variant":
                    reval = "object";
                    break;

                default:
                    reval = "string";
                    break;
            }
            return reval;
        }
    }
}