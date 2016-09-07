using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Base.DbSchemaReader.SqlGen.SqlServerCe
{
    class ConstraintWriter : SqlServer.ConstraintWriter
    {
        public ConstraintWriter(DatabaseTable table)
            : base(table)
        {
        }

        protected override ISqlFormatProvider SqlFormatProvider()
        {
            return new SqlServerCeFormatProvider();
        }
    }
}
