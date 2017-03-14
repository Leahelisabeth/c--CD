using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace SurveyApp.Controllers
{
    public class SurveyController : Controller
    {
        //controller methods can return strings but we would rather 
        //have json objects so we must specify

        [HttpGet]//optional to sepcify this
        [RouteAttribute("")]
        public IActionResult Index()
        {
            ViewBag.Example = "You are such a Viewbag";
            //viewbag does not persist across redirects
            //restart console or dotnet restore if viewbag doesnt show up...
            return View();
        }
        // [HttpPostAttribute]
        // [RouteAttribute("myroute")]
        // public string Myroute(string Textfield){
        //     //could also be IActionResult aND RETURN OF VIEWBAG
        //     return Textfield;
        // }
        [HttpGet]//optional to sepcify this
        [RouteAttribute("result")]
        public IActionResult Result(string Name, string Local, string Lang, string Comm)
        {
            ViewBag.Name = Name;
            ViewBag.Local = Local;
            ViewBag.Lang = Lang;
            ViewBag.Comm = Comm;

            return View("Result");
        }
        [HttpPostAttribute]
        [RouteAttribute("survey")]
        public IActionResult Survey(string Name, string Local, string Lang, string Comm)
        {
            //could also be IActionResult aND RETURN OF VIEWBAG
            return Result(Name, Local, Lang, Comm);
        }

    }
}