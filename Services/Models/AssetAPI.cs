using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cr_Interface.Services.Models
{

    class AssetAPI
    {
        [JsonPropertyName("market_data")]
        public MarketData? MarketData { get; set; }
    }
    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public Dictionary<string, double>? CurrentPrice { get; set; }

        [JsonPropertyName("total_volume")]
        public Dictionary<string, double>? TotalVolume { get; set; }

        [JsonPropertyName("price_change_24h")]
        public double? PriceChange24h { get; set; }
    }
}
