using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyAbp.Configuration;
using MyAbp.Web;

namespace MyAbp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyAbpDbContextFactory : IDesignTimeDbContextFactory<MyAbpDbContext>
    {
        public MyAbpDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyAbpDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyAbpDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyAbpConsts.ConnectionStringName));

            return new MyAbpDbContext(builder.Options);
        }
    }
}
