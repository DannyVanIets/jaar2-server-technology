using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quotesCRUD.Models;

namespace quotesCRUD
{
    public class IndexModel : PageModel
    {
        //Je krijgt hier een error als je het niet bij ConfigureServices in startup.cs een singleton hier voor toevoegd!
        private IQuoteService service;
        [BindProperty]
        public List<Quote> Quotes { get; set; }

        public IndexModel(IQuoteService service)
        {
            this.service = service;
        }

        public void OnGet()
        {
            Quotes = service.GetQuotes();
        }
    }
}