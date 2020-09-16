using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quotesCRUD.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int Rating { get; set; }
        public string Bedenker { get; set; }

        public Quote(int id, string tekst, int rating, string bedenker)
        {
            Id = id;
            Tekst = tekst;
            Rating = rating;
            Bedenker = bedenker;
        }

        public Quote()
        {

        }
    }
}
