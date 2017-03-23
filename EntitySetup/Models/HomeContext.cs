using Microsoft.EntityFrameworkCore;
namespace EntitySetup.Models
{
    public class HomeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        public DbSet<Person> Users { get; set; }
        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(50);
        // }
    }
}

//  [HttpPost]
//     public ActionResult Edit(int id, Blog blog)
//     {
//         try
//         {
//             db.Entry(blog).State = EntityState.Modified;
//             db.SaveChanges();
//             return RedirectToAction("Index");
//         }
//         catch(DbEntityValidationException ex)
//         {
//             var error = ex.EntityValidationErrors.First().ValidationErrors.First();
//             this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
//             return View();
//         }
//     }
//this is a try and except for if someone does try to exceed the cudtom model validation
//it needs to use this:    @Html.ValidationMessageFor(model => model.BloggerName)
//in order to pass the error back tot he view called HTML helper i may need to find another extension or using statement for this.
