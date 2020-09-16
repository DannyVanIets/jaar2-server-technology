using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterReservering.Models;

namespace TheaterReservering.DAL
{
    public static class SeedData
    {
        public static void Initialize(TheaterContext context)
        {
            // Check if the database already exists
            context.Database.EnsureCreated();

            // Check if there exists any "Customers" already
            if (context.Klant.Any() && context.Reservering.Any())
            {
                return;
            }

            AddKlant(context, "Peter Baan", "Dorpstraat 1", "Nudorp", "pieterbaan@centrum.nl");
            AddKlant(context, "Sjoukje van Leeuwen", "Brink 32", "Dwingeloo", "leewerik@live.nl");
            AddKlant(context, "Maria van der Voorst", "Energieweg 23", "Eindhoven", "maria@ikke.com");
            AddKlant(context, "Ad Veenstra", "Amersfoortseweg 12A", "Hilversum", "venie@utc.org");
            context.SaveChanges();

            string reserveringNaam = "";
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    reserveringNaam = "A";
                }
                else if (i == 1)
                {
                    reserveringNaam = "B";
                }
                else if (i == 2)
                {
                    reserveringNaam = "C";
                }
                else if (i == 3)
                {
                    reserveringNaam = "D";
                }
                else if (i == 4)
                {
                    reserveringNaam = "E";
                }

                for (int j = 1; j < 7; j++)
                {
                    AddReservering(context, reserveringNaam + j.ToString());
                }
            }
            context.SaveChanges();
        }

        private static void AddKlant(TheaterContext context, string naam, string adres, string woonplaats, string email)
        {
            var klant = context.Klant.FirstOrDefault(k => k.Naam == naam);
            if (klant == null)
            {
                context.Klant.Add(new KlantModel { Naam = naam, Adres = adres, Woonplaats = woonplaats, Email = email });
            }
        }

        private static void AddReservering(TheaterContext context, string naam)
        {
            var reservering = context.Reservering.FirstOrDefault(r => r.Naam == naam);
            if (reservering == null)
            {
                context.Reservering.Add(new ReserveringModel { Naam = naam });
            }
        }
    }
}
