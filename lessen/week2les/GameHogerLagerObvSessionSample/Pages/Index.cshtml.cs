using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionSample.Model;

namespace SessionSample.Pages
{
   // Fdj: Als uitgangspunt het voorbeeld project SessionSample van microsoft genomen:
   //      C:\D\VS\SERVER\int-scs\Docs-master\aspnetcore\fundamentals\app-state\samples\2.x\SessionSample
   public class IndexModel : PageModel
   {
      //public void OnGet()
      //{
      //}

      public IActionResult OnPost()
      {

         GameState gs = new GameState();
         HttpContext.Session.Set<GameState>(Globals.SessionKeyGame, gs);   // fdj: zie in dit project gedefinieerde SessionExtensions
         return RedirectToPage("/Guess"); // -> response: 302 + location. Wiki: "The HTTP response status code 302 Found is a common way of performing URL redirection.
                                          // An HTTP response with this status code will additionally provide a URL in the location header field. The user agent 
                                          // (e.g. a web browser) is invited by a response with this code to make a second, otherwise identical, request to the new 
                                          // URL specified in the location field."
      }
   }
}