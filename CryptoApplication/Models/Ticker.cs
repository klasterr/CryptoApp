using Newtonsoft.Json;

namespace CryptoApplication.Models;

public class Ticker
{
    [JsonProperty("market")]
    public Market Market { get; set; }

    [JsonProperty("base")]
    public string Base { get; set; }

    [JsonProperty("target")]
    public string Target { get; set; }

    [JsonProperty("last")]
    public decimal LastPrice { get; set; }

    [JsonProperty("trade_url")]
    public string TradeUrl { get; set; }
}

public class Market
{
    [JsonProperty("name")]
    public string Name { get; set; }
}
