using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace ChuckNorrisAPICaller
{
    public class HttpClientClass
    {
        private HttpClient client;
        public string RequestUrl { get; set; }
        public string route { get; set; }

        public HttpClientClass(string url, string route)
        {
            RequestUrl = url;
            this.route = route;
            client = new HttpClient();
            client.BaseAddress = new Uri(RequestUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string GetMessageInfo()
        {
            var info = new StringBuilder();
            HttpResponseMessage response = client.GetAsync(route).Result;

            if (response.IsSuccessStatusCode)
            {
                info.AppendLine($"Request Message Information: {response.RequestMessage}\n");
                info.AppendLine($"Response Message Header: {response.Content.Headers}\n");
                info.AppendLine(response.Content.ReadAsStringAsync().Result);
            }

            return info.ToString();
        }

        public string CreateChuckFact(ChuckDTO c)
        {
            var response = client.PostAsJsonAsync(route, c).Result;
            if (response.IsSuccessStatusCode)
            {
                return "Success adding item!";
            }
            return "Error adding item";
        }

        public string UpdateChuckFact(ChuckDTO c)
        {
            var response = client.PutAsJsonAsync(route + "/" + c.Id.ToString(), c).Result;
            if (response.IsSuccessStatusCode)
            {
                return "Success updating item!";
            }
            return "Error updating item";
        }

        public string DeletechuckFact(ChuckDTO c)
        {
            var response = client.DeleteAsync(route + "/" + c.Id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                return "Success deleting item!";
            }
            return "Error deleting item";
        }
    }
}