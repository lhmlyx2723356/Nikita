using Nikita.DataAccess.Expression2Sql.Mapper;

namespace Nikita.DataAccess.PerformanceTest
{
    internal class UserInfo
    {
        [OrmField(InsertIgnore = true,IsPrimaryKey = true)]
        public int Id { get; set; }
        public int Sex { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}