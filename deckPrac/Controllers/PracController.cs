using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
 
namespace ConsoleApplication.Controllers
{
    public class PracController : Controller
    {
        [HttpGet]
        [Route("card")]
        public JsonResult DisplayDeck()
        {
            Deck mydeck = new Deck();
            mydeck.Shuffle();
            
            
            foreach(Card card in mydeck.cards){
                

            }
            return Json(mydeck.ToString());
        }
        // [HttpGet]
        // [Route("counter")]
        // public IActionResult Counter(){
        //     System.Console.WriteLine("clicked");
        //     return View("Index");
        // }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Deck mydeck = new Deck();
            mydeck.Shuffle();
            ViewBag.counter = 0;
            ViewBag.mydeck = mydeck;
            return View();
        }
    }
}