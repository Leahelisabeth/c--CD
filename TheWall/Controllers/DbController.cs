using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;
using TheWall.Factory;
namespace TheWall.Controllers
{
    public class DbController : Controller
    {
        private readonly MessageFactory _msgFactory;
        private readonly UserFactory _userFactory;
        private readonly CommentFactory _cmFactory;
        public DbController()
        {
            _msgFactory = new MessageFactory();
            _userFactory = new UserFactory();
            _cmFactory = new CommentFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("Wall")]
        public IActionResult Wall()
        {
            ViewBag.errors = new List<string>();
            //get user name and id from session
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.users_id = HttpContext.Session.GetInt32("users_id"); 
            ViewBag.allmessages = _msgFactory.GetAll();
            if (ViewBag.UserName == null || ViewBag.users_id == null)
            {
                return RedirectToAction("Index", "User");
            }
            return View("Wall");
        }
        [HttpPost]
        [RouteAttribute("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        [Route("AddMsg")]
        public IActionResult AddMsg(Message msg)
        {
            if (ModelState.IsValid)
            {
                int? users_id = HttpContext.Session.GetInt32("users_id");
                _msgFactory.Add(msg, users_id);
                return RedirectToAction("Wall", "Db");
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
        [HttpPost]
        [Route("AddCm/{id}")]
        public IActionResult AddCm(Comment comment, int id)
        {
            System.Console.WriteLine("made it here!!!!!");
            System.Console.WriteLine(comment.commentbody);
            int? users_id = HttpContext.Session.GetInt32("users_id");
            // Message msg = _msgFactory.GetOne(msg_id);
            _cmFactory.Add(comment, users_id, id);
            return RedirectToAction("Wall");
        }
    }
}
