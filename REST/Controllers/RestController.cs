using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace REST.Controllers
{
    public class RestController : Controller
    {
        private RestContext _context;

        public RestController(RestContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGetAttribute]
        [RouteAttribute("")]
        public IActionResult Register(User user)
        {
            ViewBag.errors = new List<object>();
            return View("Register");
        }
        [HttpPostAttribute]
        [RouteAttribute("Registers")]
        public IActionResult Registers(User user)
        {
            string thisuser = user.UserName;
            if (ModelState.IsValid)
            {
                _context.Add(user);
                // OR _context.Users.Add(NewPerson);
                _context.SaveChanges();
                User cur_user = _context.User.SingleOrDefault(user1 => user1.UserName == user.UserName);
                HttpContext.Session.SetInt32("users_id", cur_user.id);

                return RedirectToAction("Index");
            }
            ViewBag.errors = ModelState.Values;
            return View("Register");
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.AllUsers = _context.User.ToList();
            ViewBag.AllReview = _context.Reviews.ToList();
            ViewBag.AllRest = _context.Restar.ToList();
            ViewBag.errors = new List<object>();
            System.Console.WriteLine(ViewBag.AllUsers);

            return View();
        }
        [HttpPostAttribute]
        [RouteAttribute("add")]
        public IActionResult Add(Reviews review, Restar restar)
        {
            if (ModelState.IsValid)
            {
                ViewBag.AllReview = _context.Reviews.ToList();
                ViewBag.AllRest = _context.Restar.ToList();
                return RedirectToAction("Index");
            }
            ViewBag.AllUsers = _context.User.ToList();
            ViewBag.AllReview = _context.Reviews.ToList();
            ViewBag.AllRest = _context.Restar.ToList();
            ViewBag.errors = ModelState.Values;
            return View("Index");

        }
    }
}
