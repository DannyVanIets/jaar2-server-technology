﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Statemanagement
{
    public class ShowCookieDataModel : PageModel
    {
        public string CookieText { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Response.Cookies.Append("MijnCookie", CookieText);
            return RedirectToPage("./CookieView");
        }
    }
}