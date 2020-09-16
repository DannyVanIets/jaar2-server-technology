using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WerkenMetRazorPages
{
    public class WorkWithHandlerModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Kies een knop!";
            ViewData["Groet"] = "Hallo wereld!";
            ViewData["Schaatsen"] = new Persoon("Kjelt Nuis", 30);
        }

        public void OnPostEdit()
        {
            Message = "Je hebt op Edit geklikt.";
        }

        public void OnPostDelete()
        {
            Message = "Je hebt op Delete geklikt.";
        }

        public void OnPostView()
        {
            Message = "Je hebt op View geklikt.";
        }
    }
}