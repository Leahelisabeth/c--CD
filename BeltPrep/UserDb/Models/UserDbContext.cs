using Microsoft.EntityFrameworkCore;

namespace UserDb.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }


    }
}
//Transaction myt = _context.Transactions.Where(t => t.id = 1)
                        // .Include(tr => true.User)
                        //.SingleorDefault()
                        //myt.User.FirstName
                        //cool cool
//User myUser = _context.User.Where(U => U.id = 1)
//                          .Include(tr => User.Transactions)
//                             .SingleOrDefault();
//foreach(var trans in User.transactions){
//    trans.AddTake
//}
// List<Comments> Allcomments = _context.Messages()
// .Include(m=> comments)
// .ThenInclude(c=> comments.user)