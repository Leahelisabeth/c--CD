using Microsoft.EntityFrameworkCore;
using REST.Models;

namespace REST.Models
{
    public class RestContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Restar> Restar {get; set;}

    }
}