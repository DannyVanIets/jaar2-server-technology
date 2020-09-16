using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quotesCRUD.Models;

namespace quotesCRUD
{
    public class AddQuoteModel : PageModel
    {
        private IQuoteService service;
        [BindProperty]
        public Quote Quote { get; set; }

        public AddQuoteModel(IQuoteService service)
        {
            this.service = service;
        }

        public void OnGet()
        {
            Quote = new Quote();
        }

        public IActionResult OnPost()
        {
            service.AddQuote(Quote);
            return RedirectToPage("./Index");
        }
    }
}