using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WerkenMetRazorPages
{
    public class Persoon
    {
        public int Leeftijd { get; set; }
        public string Naam { get; set; }

        public Persoon(string naam, int leeftijd)
        {
            Leeftijd = leeftijd;
            Naam = naam;
        }
    }
}