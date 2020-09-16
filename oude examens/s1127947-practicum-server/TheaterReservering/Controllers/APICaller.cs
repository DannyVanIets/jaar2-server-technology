using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TheaterReservering.Controllers
{
    public static class APICaller
    {
        private const string baseaddress = "https://localhost:44338/";
        private const string path = "api/Bereken/";

        public static async Task<int> CallBerekenPrijsAsync(int klantid)
        {
            int waarde = 0;
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(path + klantid);
            string answer = "";
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                answer = JsonConvert.DeserializeObject<string>(result);
                int.TryParse(answer, out waarde);
            }
            return waarde;
        }
    }
}
