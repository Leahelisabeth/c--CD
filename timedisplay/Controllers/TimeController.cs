using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace TimeApp.Controllers
{
    public class TimeController : Controller
    {
        //controller methods can return strings but we would rather 
        //have json objects so we must specify

        [HttpGet]//optional to sepcify this
        [RouteAttribute("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}