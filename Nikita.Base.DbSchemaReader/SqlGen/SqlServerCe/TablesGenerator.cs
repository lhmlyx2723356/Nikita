using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Base.DbSchemaReader.SqlGen.SqlServerCe
{
    class TablesGenerator : SqlServer.TablesGenerator
    {
        public TablesGenerator(DatabaseSchema schema)
            : base(schema)
        {
        }
        protected override ITableGenerator LoadTableGenerator(DatabaseTable table)
        {
            return new TableGenerator(table);
        }

        protected override ConstraintWriterBase LoadConstraintWriter(DatabaseTable table)
        {
            return new ConstraintWriter(table);
        }

        protected override ISqlFormatProvider SqlFormatProvider()
        {
            return new SqlServerCeFormatProvider();
        }
    }
}
