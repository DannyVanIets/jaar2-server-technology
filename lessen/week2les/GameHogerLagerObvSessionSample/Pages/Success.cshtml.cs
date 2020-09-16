﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SessionSample.Pages
{
   public class SuccessModel : PageModel
   {
      public void OnGet()
      {
         HttpContext.Session.Clear();
      }
   }
}