using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BlankApp.Controllers
{
    public class BlankController : Controller
    {
        //controller methods can return strings but we would rather 
        //have json objects so we must specify

        [HttpGet]//optional to sepcify this
        [RouteAttribute("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPostAttribute]
        [RouteAttribute("redirectEx")]
        public IActionResult Method(string Value)
        {
            // Will redirect to the "OtherMethod" method
            //using an anon object lets us pass params to our redirected methods. 
            //here i passed throiugh form data
            return RedirectToAction("OtherMethod", new { value = Value });
        }
        // Other code
        [HttpGet]//optional to sepcify Gets
        [RouteAttribute("redirect")]
        public IActionResult OtherMethod(string Value)
        {
            ViewBag.Yo = "Yoyo hey hey";
            ViewBag.Value = Value;
            return View("Blank");
        }
        [HttpPostAttribute]
        [RouteAttribute("redirect2")]
        public IActionResult Method2(string Value)
        {
            // To store a string we use ".SetString"
            // The first string passed is the key and the second is the value we want to retrieve later
            HttpContext.Session.SetString("UserName", "Samantha");
            // To retrieve a string we use ".GetString"
            string LocalVariable = HttpContext.Session.GetString("UserName");
            // To store an int we use ".SetInt32"
            HttpContext.Session.SetInt32("UserAge", 28);
            // To retrieve an int we use ".GetInt32"
            int? IntVariable = HttpContext.Session.GetInt32("UserAge");
            // Will redirect to the "OtherMethod" method
            //using an anon object lets us pass params to our redirected methods. 
            //here i passed throiugh form data
            return RedirectToAction("SecondEx", "Second", new { value = Value });
        }
    }
}
//SESSION NOTES:
//  There are some limitations to the kind of data we can store in session. 
//  In ASP.NET Core MVC we can only use the session to hold on to integers 
//  and strings by default. We have to specify what kind of 
//  data the session contains both when we set it, and when we retrieve it.
//CLEAR OUT SESSION: 
// //HttpContext.Session.Clear();
// Just because the session is only designed to hold simple data types,
//  doesn't mean we can't configure it to store other things. 
//  We can write a class that lets us serialize our objects and store
//   them as a json string.