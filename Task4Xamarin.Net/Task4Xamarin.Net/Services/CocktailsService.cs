using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Task4Xamarin.Net.Models;

namespace Task4Xamarin.Net.Services
{
    class CocktailsService
    {
        const string Url = "http://localhost:5137/api/Cocktails";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем всех друзей
        public async Task<IEnumerable<Cocktails>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Cocktails>>(result);
        }

           }
}
