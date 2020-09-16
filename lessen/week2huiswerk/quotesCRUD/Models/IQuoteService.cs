using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotesCRUD.Models
{
    public interface IQuoteService
    {
        List<Quote> GetQuotes();
        Quote GetQuote(int id);
        void AddQuote(Quote q);
        void UpdateQuote(Quote q);
        void DeleteQuote(int id);
    }
}
