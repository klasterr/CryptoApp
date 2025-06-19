using CryptoApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public class CryptoApiService
    {
        private readonly HttpClient client;
        public CryptoApiService(HttpClient client)
        {
            this.client = client;
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.client.DefaultRequestHeaders.Add("x-cg-demo-api-key", "CG-roDi9De3Yv1hnd2DvCjTBPYb");
        }
        public async Task<List<CryptoCurrency>> GetTopCurrenciesAsync()
        {
            string url = "https://api.coingecko.com/api/v3/coins/markets" +
                         "?vs_currency=usd&order=market_cap_desc&per_page=10&page=1";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CryptoCurrency>>(json);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<DetailedCryptoCurrency> GetDetailedCryptoCurrencyAsync(string id)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{id}?tickers=true";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DetailedCryptoCurrency>(json);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
