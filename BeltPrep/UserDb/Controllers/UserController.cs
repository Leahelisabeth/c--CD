using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDb.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace UserDb.Controllers
{
    public class UserController : Controller
    {
        private UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }
        // GET: /Home///////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.NewError = "";
            ViewBag.errors = new List<object>();
            return View();
        }
        [HttpGet]
        [Route("Register")]
        public IActionResult GetResgister()
        {
            ViewBag.NewError = "";
            ViewBag.errors = new List<object>();
            return View("Register");
        }
        // ////////////////////////Register////////////////////////////////////////////////////////////////////////////
        [HttpPostAttribute]
        [RouteAttribute("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //check if a user with this email already exists
                User new_user = _context.User.SingleOrDefault(user1 => user1.Email == model.Email);
                if (new_user == null)
                {
                    //if they dont exist make a new one
                    User NewUser = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserLevel = false,
                        UpdatedAt = DateTime.Now,
                        CreatedAt = DateTime.Now,
                        Desc = "You currently dont have a desciption, add one in your profile tab.",
                        Password = model.Password
                    };
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    //find the user we just registered in database and put them in session
                    User curuser = _context.User.SingleOrDefault(user2 => user2.Email == NewUser.Email);
                    //check if user we just registered was an admin
                    if (curuser.UserLevel == true)
                    {
                        //set the session so we can retrieve them
                        HttpContext.Session.SetInt32("users_id", curuser.UserId);
                        HttpContext.Session.SetString("UserName", curuser.FirstName);
                        return RedirectToAction("AdminDash");
                    }
                    //if they werent put them into session and take them to regular dash
                    HttpContext.Session.SetInt32("users_id", curuser.UserId);
                    HttpContext.Session.SetString("UserName", curuser.FirstName);

                    return RedirectToAction("Dashboard");
                }
                //the user wasnt null
                ViewBag.NewError = "A User with this email already exists, please login";
                ViewBag.errors = new List<string>();
                return View("Register");
            }
            //the modelstate wasnt valid
            ViewBag.NewError = "";
            ViewBag.errors = ModelState.Values;
            return View("Register");
        }
        // ////////////////////////Login //////////////////////////////////////////////////////////////////////
        [HttpPostAttribute]
        [RouteAttribute("Login")]
        public IActionResult Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                if (Email == null || Password == null)
                {
                    ViewBag.NewError = "Please type in both an Email and Password";
                    ViewBag.errors = new List<object>();
                    return View("Index");
                }
                User cur_user = _context.User.SingleOrDefault(user1 => user1.Email.ToString() == Email);
                if (cur_user != null)
                {
                    if ((string)cur_user.Password == Password)
                    {
                        HttpContext.Session.SetInt32("users_id", cur_user.UserId);
                        HttpContext.Session.SetString("UserName", cur_user.FirstName);
                        return RedirectToAction("Dashboard");
                    }
                    ViewBag.NewError = "Password is incorrect!";
                    ViewBag.errors = new List<String>();
                    return View("Index");
                }

                ViewBag.errors = new List<object>(); ViewBag.NewError = "We could not find your email please register";
                return View("Index");
            }
            ViewBag.errors = ModelState.Values;
            ViewBag.NewError = "";
            return View("Index");
        }
        [HttpPostAttribute]
        [RouteAttribute("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // ///////////////////////////////NEW CONTENT FROM USUAL///////////////////////////////////////////////////
        [HttpGetAttribute]
        [RouteAttribute("/Dashboard")]
        public IActionResult Dashboard()
        {
            //check if userid is in session 
            int? userId = HttpContext.Session.GetInt32("users_id");
            if (userId == null)
            {
                //user not in session take to login page
                ViewBag.NewError = "Please login or register to view the page";
                ViewBag.errors = new List<String>();
                return View("Index");
            }
            User MyUser = _context.User.Where(user => user.UserId == userId)
                    .SingleOrDefault();
            //check if user is an admnin
            if (MyUser.UserLevel == true)
            {
                //if they are send them to the admin dashboard
                return RedirectToAction("AdminDash");
            }
            //regular view for regular user
            ViewBag.NewError = "";
            ViewBag.UserId = HttpContext.Session.GetInt32("users_id");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");


            List<User> Allusers = _context.User
            .ToList();
            ViewBag.Allusers = Allusers;
            return View("Dash");
        }
        // ///////////////////////////////---ADMIN----/////////////
        [HttpGetAttribute]
        [RouteAttribute("Dashboard/Admin")]
        public IActionResult AdminDash()
        {
            //user in session?
            int? userId = HttpContext.Session.GetInt32("users_id");
            if (userId == null)
            {
                //if not send to login
                ViewBag.NewError = "Please login or register to view the page";
                ViewBag.errors = new List<String>();
                return View("Index");
            }
            User MyUser = _context.User.Where(user => user.UserId == userId)
                    .SingleOrDefault();
            //user is not admin?
            if (MyUser.UserLevel == false)
            {
                //send to dashboard and display error
                ViewBag.NewError = "You do not have permission to view the previous page.";
                ViewBag.UserId = HttpContext.Session.GetInt32("users_id");
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.Allusers = _context.User
                .ToList();
                return View("Dash");
            }
            //user was both in session and an admin:
            ViewBag.NewError = "";
            ViewBag.UserId = HttpContext.Session.GetInt32("users_id");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            List<User> Allusers = _context.User
            .ToList();
            ViewBag.Allusers = Allusers;
            return View("AdminDash");
        }
        [HttpPostAttribute]
        [RouteAttribute("Remove/{UserId}")]

        public IActionResult Remove(int UserId)
        {
            return RedirectToAction("AdminDash");
        }
    }
}
