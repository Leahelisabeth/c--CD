using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wedding.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace wedding.Controllers
{
    public class GuestController : Controller
    {
        private WedContext _context;

        public GuestController(WedContext context)
        {
            _context = context;
        }
        [HttpGetAttribute]
        [RouteAttribute("Rsvp")]
        public IActionResult ShowRsvp()
        {
            int? EId = HttpContext.Session.GetInt32("event_id");
            Event thisevent = _context.Event.SingleOrDefault(e => e.id == EId);
            ViewBag.ThisEvent = thisevent;
            return View("Rsvp");

        }

        // ////////////////////////Add Guest////////////////////////////////////////////////////////////////////////////
        [HttpPostAttribute]
        [RouteAttribute("attend")]
        public IActionResult Attend(GuestViewModel model)
        {
            int? EId = HttpContext.Session.GetInt32("event_id");

            Event Selectedevent = _context.Event.SingleOrDefault(e => e.id == EId);
            //User UserWed = _context.User.SingleOrDefault(u => u.id == Selectedevent.UserId);
            if(ModelState.IsValid)
            {
                Attendee newGuest = new Attendee
                {
                    Name = model.Name,
                    GuestOf = model.GuestOf,
                    Event = Selectedevent,
                    EventId = Selectedevent.id
                };
                System.Console.WriteLine("MADE IT HEREE");
                System.Console.WriteLine(newGuest.Name);
                System.Console.WriteLine(newGuest.GuestOf);
                
                System.Console.WriteLine(newGuest.EventId);
                System.Console.WriteLine("THESE SHOULD BE MY CWS ABOVE!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                _context.Add(newGuest);
                //_context.SaveChanges();
                return RedirectToAction("Home", "Event");
            }
            ViewBag.errors = ModelState.Values;
            Event thisevent = _context.Event.SingleOrDefault(e => e.id == EId);
            ViewBag.ThisEvent = thisevent;
            return View("Rsvp");
        }
    }
}