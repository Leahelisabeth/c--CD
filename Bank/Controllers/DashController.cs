using System;
using MySQL.Data.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bank.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Bank.Controllers
{
    public class DashController : Controller
    {
        private BankContext _context;

        public DashController(BankContext context)
        {
            _context = context;
        }
        // GET: /Home///////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            ViewBag.NewError ="";
            ViewBag.UserId = HttpContext.Session.GetInt32("users_id");
            int? userId = HttpContext.Session.GetInt32("users_id");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            User MyUser = _context.User.Where(user => user.id == userId)
                    .Include(tr => tr.Transactions)
                    .SingleOrDefault();
            List<User> Allusers = _context.User
            .Include(tr => tr.Transactions)
            .ToList();
                    //include runs on queryable so if i already queried for one user it doesnt work.
            ViewBag.MyUser = MyUser;
            ViewBag.Allusers = Allusers;
            ViewBag.Transactions = MyUser.Transactions;
            ViewBag.errors = new List<object>();
            return View("Dashboard");
        }
        [HttpPostAttribute]
        [RouteAttribute("AddTake/{userId}")]
        public IActionResult Addtake(TransactionViewModel model, int userId)
        {
            System.Console.WriteLine(userId);
            User thisuser = _context.User.Where(user => user.id == userId)
            .SingleOrDefault();
            double crement = model.AddTake;
            thisuser.Balance = thisuser.Balance + crement;
            _context.SaveChanges();
            if(ModelState.IsValid){
                Transaction newTran = new Transaction 
                {
                    AddTake = crement,
                    User = thisuser,
                    UserId = thisuser.id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(newTran);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            ViewBag.errors = ModelState.Values;
            return RedirectToAction("Dashboard");
        }
    }
}