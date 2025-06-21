using CryptoApplication.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;

namespace CryptoApplication.Services;

public class CryptoApiService
{
    private readonly HttpClient client;
    private readonly string apiUrl;

    public CryptoApiService()
    {
        this.client = new HttpClient();
        this.apiUrl = "https://api.coingecko.com/api/v3/";
        this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        this.client.DefaultRequestHeaders.Add("x-cg-demo-api-key", "CG-roDi9De3Yv1hnd2DvCjTBPYb");
    }
    public async Task<List<CryptoCurrency>?> GetTopCurrenciesAsync()
    {
        string query = "coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1";
        string url = apiUrl + query;
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<CryptoCurrency>>(json);
        return result;
    }

    public async Task<DetailedCryptoCurrency?> GetDetailedCryptoCurrencyAsync(string id)
    {
        string query = $"coins/{id}?tickers=true";
        string url = apiUrl + query;
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<DetailedCryptoCurrency>(json);
        return result;
    }

    public async Task<CoinList?> GetCoinsByQueryAsync(string userQuery)
    {
        string query = $"search?query={userQuery}";
        string url = apiUrl + query;
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<CoinList>(json);
        return (result?.Coins?.Count ?? 0) > 0 ? result : null;
    }
}
