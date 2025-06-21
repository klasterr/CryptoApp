using Newtonsoft.Json;

namespace CryptoApplication.Models;

public class CoinList
{
    [JsonProperty("coins")]
    public List<Coin> Coins { get; set; }
}
