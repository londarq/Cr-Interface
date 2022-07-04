using System.Text.Json.Serialization;

namespace Cr_Interface.Model
{
    public class PriceWTime
    {
        [JsonPropertyName("prices")]
        public double[][] Prices { get; set; }

        [JsonPropertyName("market_caps")]
        public double[][] MarketCaps { get; set; }

        [JsonPropertyName("total_volumes")]
        public double[][] TotalVolumes { get; set; }
    }
}
