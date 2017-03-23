using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using quotingDojo.Factories;
using quotingDojo.Models;
//i had my controller named plurally quotescontroller, and it could not see my stuff
namespace quotingDojo.Controllers
{
    public class QuoteController : Controller
    {
        private readonly QuoteFactory _quoteFactory;
        public QuoteController()
        {
            _quoteFactory = new QuoteFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Landing()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult Index()
        {
            IEnumerable<Quote> AllQuotes = _quoteFactory.FindAll();
            ViewBag.Quotes = AllQuotes;
            return View();
        }
        [HttpPost]
        [RouteAttribute("quotes")]
        public IActionResult New(Quote model)
        {
            if(ModelState.IsValid){
                _quoteFactory.Add(model);
                return RedirectToAction("Index");
            }
            ViewBag.Errors = ModelState.Values;
            return View("Landing");
        }
    }
}
