using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyAbp.EntityFrameworkCore
{
    public static class MyAbpDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyAbpDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString, b => b.UseRowNumberForPaging());
        }

        public static void Configure(DbContextOptionsBuilder<MyAbpDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection, b => b.UseRowNumberForPaging());
        }
    }
}
