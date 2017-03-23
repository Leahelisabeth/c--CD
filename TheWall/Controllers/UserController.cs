using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;
using TheWall.Factory;
namespace TheWall.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory _userFactory;
        public UserController()
        {
            _userFactory = new UserFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.LoginError = "";
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.users_id = HttpContext.Session.GetInt32("users_id");
            return View();
        }
        ///REGISTER USER REDIRECT TO WALL 
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _userFactory.Add(user);
                HttpContext.Session.SetString("UserName", user.FirstName);
                User Oneuser = _userFactory.LoginValid(user.Email);
                HttpContext.Session.SetString("UserName", Oneuser.FirstName);
                HttpContext.Session.SetInt32("users_id", Oneuser.id);
                return RedirectToAction("Wall", "Db");
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
        //LOGIN USER AND REDIRECT TO WALL
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Email, string Password)
        {
            if (Email != null && Password != null)
            {
                User Oneuser = _userFactory.LoginValid(Email);
                //System.Console.WriteLine(Oneuser.FirstName + " !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                if (Oneuser != null)
                {
                    if (Password == (string)Oneuser.Password)
                    {
                        System.Console.WriteLine("Success!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        HttpContext.Session.SetString("UserName", Oneuser.FirstName);
                        HttpContext.Session.SetInt32("users_id", Oneuser.id);
                        return RedirectToAction("Wall", "Db");
                    }
                    ViewBag.LoginError = "Password is incorrect";
                    Dictionary<string, string> error3 = new Dictionary<string, string>();
                    ViewBag.errors = error3;
                    return RedirectToAction("Index");
                }
                ViewBag.LoginError = "Bad Password Email Combo";
                Dictionary<string, string> error = new Dictionary<string, string>();
                ViewBag.errors = error;
                return View("Index");
            }
            ViewBag.LoginError = "Bad Password Email Combo";
            Dictionary<string, string> error2 = new Dictionary<string, string>();
            ViewBag.errors = error2;
            return View("Index");


        }
    }
}
