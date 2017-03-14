using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace PortfolioApp.Controllers
{
    public class PortfolioController : Controller
    {
        //controller methods can return strings but we would rather 
        //have json objects so we must specify

        [HttpGet]//optional to sepcify this
        [RouteAttribute("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]//optional to sepcify this
        [RouteAttribute("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
        [HttpGet]//optional to sepcify this
        [RouteAttribute("projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }
    }
}