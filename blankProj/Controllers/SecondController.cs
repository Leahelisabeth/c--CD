using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BlankApp.Controllers
{
    public class SecondController : Controller
    {
        //controller methods can return strings but we would rather 
        //have json objects so we must specify
        // Other code
        [HttpGet]//optional to sepcify Gets
        [RouteAttribute("redirected")]
        public IActionResult SecondEx(string Value)
        {
            ViewBag.Yo = "redirected to my second controller like a G";
            ViewBag.Value = Value;
            return View("Second");
            //remeber to pout things under shared folder 
            //if sloppily redirecting to another controller like i am rn
        }
    }
}