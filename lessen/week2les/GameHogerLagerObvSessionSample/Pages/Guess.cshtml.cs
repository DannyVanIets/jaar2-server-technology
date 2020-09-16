using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionSample.Model;

namespace SessionSample.Pages
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

        public IActionResult OnPost(int? attempt)
        {
            if (HttpContext.Session.Get<GameState>(Globals.SessionKeyGame) == null)
            {
                return StatusCode(408);    // fdj: zie https://www.talkingdotnet.com/return-http-status-code-from-asp-net-core-methods/ 
            }
            SessionInfo_GameState = HttpContext.Session.Get<GameState>(Globals.SessionKeyGame);

            // Check value of attempt
            if (!attempt.HasValue)
            {
                // wrong input
                // but it still IS an extra try!
                SessionInfo_GameState.Steps++;
                SessionInfo_GameState.State = GameState.WRONGINPUT;
                return Page();
                //return RedirectToPage();
            }

            // Succes!
            if (attempt == SessionInfo_GameState.Target)
            {
                SessionInfo_GameState.State = GameState.SUCCES;
                HttpContext.Session.Set<GameState>(Globals.SessionKeyGame, SessionInfo_GameState);
                return Redirect("/Success");       // -> response: 302 + location 
            }

            // To high or to low
            SessionInfo_GameState.Steps = SessionInfo_GameState.Steps + 1;
            if (attempt < SessionInfo_GameState.Target)
                SessionInfo_GameState.State = GameState.HIGHER;
            else
                SessionInfo_GameState.State = GameState.LOWER;

            // Save session and go to next guess
            HttpContext.Session.Set<GameState>(Globals.SessionKeyGame, SessionInfo_GameState);

            return Redirect("/Guess");             // -> response: 302 + location 
        }

    }
}