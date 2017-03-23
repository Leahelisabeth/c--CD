using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using System.Linq;

namespace LogReg.Controllers
{

    public class LogRegController : Controller
    {
        private readonly DbConnector _dbConnector;

        public LogRegController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            ViewBag.LoginError = "";
            return View();
        }
        //post register
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                string QueryString = "Insert into users (FirstName, LastName, Email, Password) values ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}')";
                _dbConnector.Execute(QueryString);
                return RedirectToAction("Index");
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Email, string Password)
        {

            string Query = $"Select * from users Where Email = '{Email}'";
            Dictionary<string, object> Oneuser = _dbConnector.Query(Query).SingleOrDefault();
            if (Oneuser != null && Password != null)
            {
                if (Password == (string)Oneuser["Password"])
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.LoginError = "Bad Password Email Combo";
            Dictionary<string, string> error = new Dictionary<string, string>();
            ViewBag.errors = error;
            return View("Index");

        }
    }
}
