using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameHogerLager.Models;
using GameHogerLager.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameHogerLager
{
    public class GuessModel : PageModel
    {
        public GameState SessionInfo_GameState { get; private set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get<GameState>(Globals.SessionKeyGame) == null)
            {
                return StatusCode(408);    // fdj: zie https://www.talkingdotnet.com/return-http-status-code-from-asp-net-core-methods/ 
            }
            SessionInfo_GameState = HttpContext.Session.Get<GameState>(Globals.SessionKeyGame);
            return Page();
        }

        public IActionResult OnPost(int? guess)
        {
            if (HttpContext.Session.Get<GameState>(Globals.SessionKeyGame) == null)
            {
                return StatusCode(408);    // fdj: zie https://www.talkingdotnet.com/return-http-status-code-from-asp-net-core-methods/ 
            }

            SessionInfo_GameState = HttpContext.Session.Get<GameState>(Globals.SessionKeyGame);

            //Check to see if it's the right number, if it has value, too high or too low.
            if (guess == SessionInfo_GameState.Target)
            {
                SessionInfo_GameState.State = GameState.SUCCES;
                HttpContext.Session.Set<GameState>(Globals.SessionKeyGame, SessionInfo_GameState);

                return Redirect("/Success");       // -> response: 302 + location 
            }
            else if (!guess.HasValue || guess == null)
            {
                SessionInfo_GameState.State = GameState.WRONGINPUT;
            }
            else if (guess < SessionInfo_GameState.Target)
            {
                SessionInfo_GameState.State = GameState.HIGHER;
            }
            else if (guess > SessionInfo_GameState.Target)
            {
                SessionInfo_GameState.State = GameState.LOWER;
            }

            SessionInfo_GameState.Steps++;

            // Save session and go to next guess
            HttpContext.Session.Set<GameState>(Globals.SessionKeyGame, SessionInfo_GameState);

            // -> response: 302 + location 
            return Redirect("/Guess");
        }
    }
}