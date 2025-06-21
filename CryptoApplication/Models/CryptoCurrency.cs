using Newtonsoft.Json;

namespace CryptoApplication.Models;

public class CryptoCurrency
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("current_price")]
    public decimal CurrentPrice { get; set; }

    [JsonProperty("price_change_percentage_24h")]
    public decimal PriceChangePercentage24h { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }
}
