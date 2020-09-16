using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace callStripfiguur
{
    class Program
    {
        private string requestUri = "https://localhost:44392/";
        private string apiUri = "api/Stripfiguur";
        private HttpClient client;

        public Program()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(requestUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.ReadStripfiguurList();

            StripfiguurDTO sf = new StripfiguurDTO { Id = 5, Naam = "Hallo", Omschrijving = "Dit is geen echte stripfiguur" };
            program.CreateStripfiguur(sf);
            program.PrintStripfiguurList();

            sf.Naam = "Nieuwe naam!";
            sf.Omschrijving = "Een nieuwe leuke omschrijving.";

            program.UpdateStripfiguur(sf);
            program.PrintStripfiguurList();

            program.DeleteStripfiguur(sf);
            program.PrintStripfiguurList();

            Console.ReadLine();
        }

        public void ReadStripfiguurList()
        {
            HttpResponseMessage response = client.GetAsync(apiUri).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
                Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.WriteLine($"{response.StatusCode} ({response.ReasonPhrase})");
            }
        }

        public void PrintStripfiguurList()
        {
            var stream = client.GetStreamAsync(apiUri).Result;
            var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var currentLine = reader.ReadLine();
                Console.WriteLine(currentLine);
            }
        }

        public void CreateStripfiguur(StripfiguurDTO sf)
        {
            var response = client.PostAsJsonAsync(apiUri, sf).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Succesvol een stripfiguur toegevoegd!");
            }
            else
            {
                Console.WriteLine("Er was een error bij het toevoegen!");
            }
            Console.ReadLine();
        }

        public void UpdateStripfiguur(StripfiguurDTO sf)
        {
            var response = client.PutAsJsonAsync(apiUri + "/" + sf.Id.ToString(), sf).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Succesvol een stripfiguur geüpdate!");
            }
            else
            {
                Console.WriteLine("Er was een error bij het updaten!");
            }
            Console.ReadLine();
        }

        public void DeleteStripfiguur(StripfiguurDTO sf)
        {
            var response = client.DeleteAsync(apiUri + "/" + sf.Id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Succesvol een stripfiguur verwijderd!");
            }
            else
            {
                Console.WriteLine("Er was een error met het verwijderen!");
            }
            Console.ReadLine();
        }
    }
}
