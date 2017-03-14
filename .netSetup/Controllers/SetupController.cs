using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace SetupApp.Controllers
{
    public class SetupController : Controller
    {
        //controller methods can return strings but we would rather 
        //have json objects so we must specify

        [HttpGet]//optional to sepcify this
        [RouteAttribute("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        // [HttpPost]//must be included on all post routes
        // [RouteAttribute("")]//stuff in here does not have leading slash!
        // public IActionResult Other()
        // {
        //     //

        // }
        // [HttpGet]
        // [RouteAttribute("template/{Name}")]//the route ca accpet parameters
        // //if its expects a paramter and doesnt get one it will break
        // //now that we have this cleaner toure syntax we dont need the stuff we put in app.usemvc
        // public IActionResult Method(string name)
        // {
        //     //body
        // }
        [HttpGet]
        [RouteAttribute("json")]
        public JsonResult Example()
        {
            //we can use anon objects to return groups of values as json that are diff types
            //example below: ---ask why it throws me and implcit conversion error
            // var AnonObject = new
            // {
            //     FirstName = "Raz",
            //     LastName = "Aquato",
            //     Age = 10
            // };
            // return (AnonObject);
            return Json(34);
            //json accepts any object from ints to dictionaries
            //if we had classes atached we could display: new Human();
        }
    }
}
//after we make our controller we must go back to startup.cs and let it know we did that