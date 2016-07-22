using System.Text;
using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Base.DbSchemaReader.SqlGen.MySql
{

    class TablesGenerator : TablesGeneratorBase
    {
        public TablesGenerator(DatabaseSchema schema)
            : base(schema)
        {
        }


        protected override ConstraintWriterBase LoadConstraintWriter(DatabaseTable table)
        {
            return new ConstraintWriter(table);
        }

        protected override ITableGenerator LoadTableGenerator(DatabaseTable table)
        {
            return new TableGenerator(table);
        }

        protected override ISqlFormatProvider SqlFormatProvider()
        {
            return new SqlFormatProvider();
        }

        protected override void WriteDrops(StringBuilder sb)
        {
            sb.AppendLine(DropTables.Write(Schema, SqlFormatProvider()));
        }
    }
}
