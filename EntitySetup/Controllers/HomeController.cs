using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntitySetup.Models;
using System.Linq;
namespace EntitySetup.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext _context;

        public HomeController(HomeContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Person> AllUsers = _context.Users.ToList();
            List<Person> ReturnedValues = _context.Users.Where(user => user.Age > 17).ToList();
            Person ReturnedValue = _context.Users.SingleOrDefault(user => user.Email == Email);
            Person RetrievedUser = _context.Users.SingleOrDefault(user => user.ID == SomeNumber);
            RetrievedUser.Name = "New name";
            _context.SaveChanges();
            Person RetrievedUser = _context.Users.SingleOrDefault(user => user.ID == SomeNumber);
            _context.Users.Remove(RetrievedUser);
            _context.SaveChanges()

            return View();
        }
    }
}
