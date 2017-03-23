using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace testProj.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("pokeinfo/{pokeid}")]
        public IActionResult Index(int pokeid)
        {
            var PokeObject = new Pokemon();
            WebRequest.GetPokemonDataAsync(pokeid, PokeResponse =>
                {
                    PokeObject = PokeResponse;
                }
            ).Wait();
            // Other code
            ViewBag.Pokemon = PokeObject;
            return View();
        }
    }

}
