using HumanResources.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.DataAccess.Utility
{
    public class MigrationHelper
    {
        public static void UpdateDatabase(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer(connectionString);
            using var context = new Context(builder.Options);
            context.Database.Migrate();
        }
    }
}
