using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GameHogerLager.Models;
using GameHogerLager.Extensions;

namespace GameHogerLager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            GameState gs = new GameState();
            HttpContext.Session.Set<GameState>(Globals.SessionKeyGame, gs);
            return RedirectToPage("./Guess");
        }
    }
}
