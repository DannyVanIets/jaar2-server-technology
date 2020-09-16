using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urenregistratie.Models;

namespace Urenregistratie.DAL
{
    public static class Seeddata
    {
        public static void Initialize(UrenContext context)
        {
            // Check if the database already exists
            context.Database.EnsureCreated();

            // Check if there exists any "Customers" already
            if (context.Medewerker.Any() && context.Registratie.Any())
            {
                return;
            }

            AddMedewerker(context, "Benthe", "Blaauw", "088-4698024");
            AddMedewerker(context, "Mitchell", "Groenendal", "088-4699720");
            AddMedewerker(context, "Tesse", "Demandt", "088-4699954");
            AddMedewerker(context, "Romano", "Rijneveld", "088-4697125");
            context.SaveChanges();

            foreach(var medewerker in context.Medewerker.ToList())
            {
                for(int week = 19; week < 25; week++)
                {
                    AddRegistratie(context, 2020, week, 3, medewerker.MedewerkerId);
                }
            }
            context.SaveChanges();
        }

        private static void AddMedewerker(UrenContext context, string voornaam, string achternaam, string telefoonnummer)
        {
            var medewerker = context.Medewerker.FirstOrDefault(k => k.Voornaam == voornaam && k.Achternaam == achternaam);
            if (medewerker == null)
            {
                context.Medewerker.Add(new MedewerkerModel { Voornaam = voornaam, Achternaam = achternaam, Telefoonnummer = telefoonnummer });
            }
        }

        private static void AddRegistratie(UrenContext context, int jaar, int week, int dinsdagUren, int medewerkerId)
        {
            var registratie = context.Registratie.FirstOrDefault(r => r.MedewerkerId == medewerkerId && r.Week == week);
            if (registratie == null)
            {
                context.Registratie.Add(new RegistratieModel { Jaar = jaar, Week = week, Dinsdag = dinsdagUren, MedewerkerId = medewerkerId });
            }
        }
    }
}
