using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Base.DbSchemaReader.SqlGen.MySql
{
    /// <summary>
    /// Generate MySql stored procedures.
    /// </summary>
    internal class ProcedureGenerator : ProcedureGeneratorBase
    {
        public ProcedureGenerator(DatabaseTable table) : base(table)
        {
            SqlWriter = new SqlWriter(table, SqlType.MySql);
            SqlWriter.InStoredProcedure = true;
            SqlWriter.FormatParameter = x => "p_" + x;
        }
        protected override IProcedureWriter CreateProcedureWriter(string procName)
        {
            return new ProcedureWriter(procName, TableName);
        }
        protected override string ColumnDataType(DatabaseColumn column)
        {
            return new DataTypeWriter().WriteDataType(column);
        }

        protected override string ColumnDataType(string dataType)
        {
            return dataType;
        }
    }
}
