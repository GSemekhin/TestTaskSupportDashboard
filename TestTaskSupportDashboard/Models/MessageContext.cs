using Microsoft.EntityFrameworkCore;

namespace TestTaskSupportDashboard.Models
{
    public class MessageContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
