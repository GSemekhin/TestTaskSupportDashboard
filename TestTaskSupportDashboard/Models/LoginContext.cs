using Microsoft.EntityFrameworkCore;

namespace TestTaskSupportDashboard.Models
{
    public class LoginContext : DbContext
    {
        public DbSet<SupportOperator> SupportOperators { get; set; }
        public DbSet<Role> Roles { get; set; }

        public LoginContext(DbContextOptions <LoginContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
