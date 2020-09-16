using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Statemanagement
{
    public class SessionViewModel : PageModel
    {
        private SessionManager sessionmanager;
        private string SessionKey;

        public SessionViewModel()
        {
            sessionmanager = new SessionManager();
            SessionKey = "MijnSessie";
        }

        public void OnGet()
        {
            ViewData["SessieTekst"] = sessionmanager.Get<string>(HttpContext.Session, SessionKey);
            ViewData["Boek"] = sessionmanager.Get<string>(HttpContext.Session, "Book");
        }
    }
}