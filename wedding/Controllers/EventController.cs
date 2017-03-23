using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wedding.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace wedding.Controllers
{
    public class EventController : Controller
    {
        private WedContext _context;

        public EventController(WedContext context)
        {
            _context = context;
        }
        // GET: /Home///////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            List<Event> AllEvents = _context.Event.ToList();
            ViewBag.AllEvents = AllEvents;


            return View("Home");
        }
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            ViewBag.NewError = "";
            ViewBag.UserId = HttpContext.Session.GetInt32("users_id");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            return View("Create");
        }
        [HttpPost]
        [Route("Plan")]
        public IActionResult Plan(EventViewModel model)
        {
            int? CuruserId = HttpContext.Session.GetInt32("users_id");
            if (ModelState.IsValid)
            {
                User Planner = _context.User.Where(user => user.id == CuruserId).SingleOrDefault();
                Event newEvent = new Event
                {
                    Spouse = model.Spouse,
                    SndSpouse = model.SndSpouse,
                    WedDay = model.WedDay.Date,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    User = Planner,
                    UserId = Planner.id
                };
                System.Console.WriteLine(newEvent.Spouse);
                System.Console.WriteLine(newEvent.SndSpouse);
                System.Console.WriteLine(newEvent.WedDay);
                System.Console.WriteLine(newEvent.CreatedAt);
                _context.Add(newEvent);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            ViewBag.UserId = HttpContext.Session.GetInt32("users_id");
            int? userId = HttpContext.Session.GetInt32("users_id");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            return View("Create");
        }
        [HttpGet]
        [Route("Rsvp/{EId}")]
        public IActionResult Rsvp(int EId)
        {
            Event thisevent = _context.Event.SingleOrDefault(e => e.id == EId);
            HttpContext.Session.SetInt32("event_id", thisevent.id);
            ViewBag.ThisEvent = thisevent;
            return RedirectToAction("ShowRsvp", "Guest");
        }
    }
}
