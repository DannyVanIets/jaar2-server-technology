using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutingWithDynamicController.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult list(string language)
        {
            ViewData.Add("language", language);
            return View();
        }
    }
}