using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Statemanagement
{
    public class ShowHiddenFieldModel : PageModel
    {
        public int ClickCount { get; set; }

        public void OnGet()
        {
            ViewData["Clicker"] = ClickCount.ToString();
        }

        public void OnPost(string clicks)
        {
            var cl = int.Parse(clicks);
            ClickCount = cl + 1;
            ViewData["Clicker"] = ClickCount.ToString();
        }

        public IActionResult OnPostShow(string clicks)
        {
            return RedirectToPage("./HiddenFieldView", new { clicks });
        }
    }
}