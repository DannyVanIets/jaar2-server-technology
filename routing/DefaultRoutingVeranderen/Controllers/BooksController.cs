using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DefaultRoutingVeranderen.Models;

namespace DefaultRoutingVeranderen.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BooksController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Overview()
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
