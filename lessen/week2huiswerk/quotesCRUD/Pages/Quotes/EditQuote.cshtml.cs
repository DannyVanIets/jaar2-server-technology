using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quotesCRUD.Models;

namespace quotesCRUD
{
    public class EditQuoteModel : PageModel
    {
        private IQuoteService service;
        [BindProperty]
        public Quote Quote { get; set; }

        public EditQuoteModel(IQuoteService service)
        {
            this.service = service;
        }

        public IActionResult OnGet(int id)
        {
            Quote = service.GetQuote(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            service.UpdateQuote(Quote);
            return RedirectToPage("./Index");
        }
    }
}