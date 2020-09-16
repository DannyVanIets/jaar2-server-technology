using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Statemanagement.Models;

namespace Statemanagement
{
    public class ShowSessionModel : PageModel
    {
        [BindProperty]
        public string SessionText { get; set; }
        public string SessionKey { get; set; }

        private SessionManager sessionmanager;

        public ShowSessionModel()
        {
            sessionmanager = new SessionManager();
            SessionKey = "MijnSessie";
        }

        public void OnGet()
        {
            var sessietext = sessionmanager.Get<string>(HttpContext.Session, SessionKey);
            ViewData["SessieTekst"] = sessietext;
        }

        public IActionResult OnPost()
        {
            sessionmanager.Set(HttpContext.Session, SessionKey, SessionText);
            sessionmanager.Set(HttpContext.Session, "Book", new Book(1, "Nooit meer slapen", "Hallo"));
            return RedirectToPage("./SessionView");
        }
    }
}