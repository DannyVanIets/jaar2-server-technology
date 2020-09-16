using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakenlijstManager.DAL;
using TakenlijstManager.Models;

namespace TakenlijstManager.DAL
{
    public static class SeedData
    {
        public static void Initialize(TaakContext context)
        {
            context.Database.EnsureCreated();

            AddTaak(context, "Huiswerk Client", 5, 6);
            AddTaak(context, "Huiswerk Server", 3, 3);
            AddTaak(context, "Voorbereiden Tentamen Server", 4, 10);
            AddTaak(context, "Voorbereiden Tentamen Client", 5, 10);
            context.SaveChanges();
        }

        private static void AddTaak(TaakContext context, string naam, int omvang, int prioriteit)
        {
            var taak = context.Taak.FirstOrDefault(t => t.Naam == naam);
            if (taak == null)
            {
                context.Taak.Add(new Taak { Naam = naam, Omvang = omvang, Prioriteit = prioriteit });
            }
        }
    }
}
