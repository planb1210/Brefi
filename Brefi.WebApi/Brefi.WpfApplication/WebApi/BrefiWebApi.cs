using Brefi.WpfApplication.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
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
            var url = $"{httpUrl}/get{GetDate(date)}";

            using (var response = await client.GetAsync(url))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FullCatalog>(responseString);
            }
        }

        public async Task<FullCatalog> Update(FullCatalog catalog, DateTime? date = null)
        {
            var data = JsonConvert.SerializeObject(catalog);
            var url = $"{httpUrl}/updatelines{GetDate(date)}";            
            var httpContent = new StringContent(data, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(url, httpContent))
            {
                var responseDataString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FullCatalog>(responseDataString);
            }
        }

        private string GetDate(DateTime? date = null)
        {
            if (date != null)
            {
                return $"?date={String.Format("{0:s}", date)}";
            }
            return "";
        }
    }
}
