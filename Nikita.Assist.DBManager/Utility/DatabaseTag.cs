using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Assist.DBManager
{
    public class DatabaseTag
    {
        public string DatabaseName
        {
            get;
            set;
        }

        public DatabaseSchema DatabaseSchema
        {
            get;
            set;
        }

        public ServerTag ServerTag
        {
            get;
            set;
        }
    }
}