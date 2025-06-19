using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApp.Models
{
    

    public class DetailedCryptoCurrency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("market_data")]
        public MarketData MarketData { get; set; }

        [JsonProperty("tickers")]
        public List<Ticker> Tickers { get; set; }
    }

}
