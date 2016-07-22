using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Base.DbSchemaReader.SqlGen.Db2
{
    class ConstraintWriter : ConstraintWriterBase
    {
        public ConstraintWriter(DatabaseTable table)
            : base(table)
        {
        }

        #region Overrides of ConstraintWriterBase

        protected override ISqlFormatProvider SqlFormatProvider()
        {
            return new SqlFormatProvider();
        }

        #endregion
    }
}
