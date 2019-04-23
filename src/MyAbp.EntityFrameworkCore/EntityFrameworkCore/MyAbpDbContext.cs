using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyAbp.Authorization.Roles;
using MyAbp.Authorization.Users;
using MyAbp.MultiTenancy;
using MyAbp.Authorization.Tasks;
using MyAbp.Authorization.People;

namespace MyAbp.EntityFrameworkCore
{
    public class MyAbpDbContext : AbpZeroDbContext<Tenant, Role, User, MyAbpDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Person> People { get; set; }
        
        public MyAbpDbContext(DbContextOptions<MyAbpDbContext> options)
            : base(options)
        {
        }
    }
}
