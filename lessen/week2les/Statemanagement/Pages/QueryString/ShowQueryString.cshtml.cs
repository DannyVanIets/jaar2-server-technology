using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Statemanagement
{
    public class ShowQueryStringModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Naam"] = HttpContext.Request.Query["Naam"];
            ViewData["Leeftijd"] = HttpContext.Request.Query["Leeftijd"];
        }
    }
}