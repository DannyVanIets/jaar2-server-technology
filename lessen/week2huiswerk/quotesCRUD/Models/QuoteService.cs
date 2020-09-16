using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotesCRUD.Models
{
    public class QuoteService : IQuoteService
    {
        private List<Quote> quotes;

        public QuoteService()
        {
            quotes = new List<Quote>();
            quotes.Add(new Quote(1, "Hallo", 5, "Danny"));
            quotes.Add(new Quote(2, "Test", 3, "Danny"));
            quotes.Add(new Quote(3, "Doei", 7, "Danny"));
        }

        public List<Quote> GetQuotes()
        {
            return quotes.ToList();
        }

        public Quote GetQuote(int id)
        {
            return quotes.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddQuote(Quote q)
        {
            quotes.Add(q);
        }

        public void UpdateQuote(Quote q)
        {
            var x = quotes.Where(x => x.Id == q.Id).FirstOrDefault();
            if (x != null)
            {
                x.Tekst = q.Tekst;
                x.Rating = q.Rating;
                x.Bedenker = q.Bedenker;
            }
        }

        public void DeleteQuote(int id)
        {
            Quote x = quotes.Where(x => x.Id == id).FirstOrDefault();
            if (x != null)
            {
                quotes.Remove(x);
            }
        }
    }
}
