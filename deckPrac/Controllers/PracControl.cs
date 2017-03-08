using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace ConsoleApplication
{
    public class HelloController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Hello World!";
        }
    }
}