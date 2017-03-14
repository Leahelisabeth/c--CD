using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace SetupApp
{
    public class CcController : Controller
    {
        [HttpGet]
        [RouteAttribute("card/{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult GetCard(string FirstName, string LastName, int Age, string FavColor)
        {

            return Json(new {FirstName= FirstName, LastName = LastName, Age = Age, FavColor = FavColor});
        }
    }
}
//after we make our controller we must go back to startup.cs and let it know we did that