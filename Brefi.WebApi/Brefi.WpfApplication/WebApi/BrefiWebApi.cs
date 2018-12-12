using Brefi.WpfApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Brefi.WpfApplication.WebApi
{
    public class BrefiWebApi
    {
        private const string httpUrl = "http://api.brefi/api/catalog";

        private readonly HttpClient client = new HttpClient();

        public async Task<FullCatalog> GetLines(DateTime? date = null)
        {
            var url = $"{httpUrl}/get?date={String.Format("{0:s}", date)}";

            using (var response = await client.GetAsync(url))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FullCatalog>(responseString);
            }
        }

        public async Task<FullCatalog> Update(FullCatalog catalog, DateTime? date = null)
        {
            var data = JsonConvert.SerializeObject(catalog);

            var url = $"{httpUrl}/post?date={String.Format("{0:s}", date)}";

            using (var httpClient = new HttpClient())
            {                
                var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, httpContent);
                //response.EnsureSuccessStatusCode();
                var responseDataString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FullCatalog>(responseDataString);
            }
        }
    }
}
