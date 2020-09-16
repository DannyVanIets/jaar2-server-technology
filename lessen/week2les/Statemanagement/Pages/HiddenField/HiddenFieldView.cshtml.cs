using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Statemanagement
{
    public class HiddenFieldViewModel : PageModel
    {
        public void OnGet(string clicks)
        {
            ViewData["Clicker"] = clicks;
        }
    }
}