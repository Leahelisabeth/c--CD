using Microsoft.EntityFrameworkCore;

namespace wedding.Models
{
    public class WedContext : DbContext
    {
        public WedContext(DbContextOptions<WedContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Attendee> Attendee { get; set; }


    }
}