using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoutingAttributes.Models;

namespace RoutingAttributes.Controllers
{
    [Route("Books/List")]
    public class BooksController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BooksController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Kunt meerdere toevoegen
        [Route("Iets")]
        [Route("Overview")]
        public IActionResult Inventory()
        {
            return View();
        }

        //Als je ergens route neerzet, moet je het overal neerzetten.
        [Route("Id")]
        public IActionResult Id()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
