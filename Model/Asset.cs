using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cr_Interface.Model
{
    public class Asset
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image")]
        public Uri Image { get; set; }

        [JsonPropertyName("current_price")]
        public double CurrentPrice { get; set; }

        //[JsonPropertyName("market_cap")]
        //public long MarketCap { get; set; }

        //[JsonPropertyName("market_cap_rank")]
        //public long MarketCapRank { get; set; }

        //[JsonPropertyName("fully_diluted_valuation")]
        //public long FullyDilutedValuation { get; set; }

        //[JsonPropertyName("total_volume")]
        //public long TotalVolume { get; set; }

        //[JsonPropertyName("high_24h")]
        //public double High24H { get; set; }

        //[JsonPropertyName("low_24h")]
        //public double Low24H { get; set; }

        //[JsonPropertyName("price_change_24h")]
        //public double PriceChange24H { get; set; }

        //[JsonPropertyName("price_change_percentage_24h")]
        //public double PriceChangePercentage24H { get; set; }

        //[JsonPropertyName("market_cap_change_24h")]
        //public double MarketCapChange24H { get; set; }

        //[JsonPropertyName("market_cap_change_percentage_24h")]
        //public double MarketCapChangePercentage24H { get; set; }

        //[JsonPropertyName("circulating_supply")]
        //public long CirculatingSupply { get; set; }

        //[JsonPropertyName("total_supply")]
        //public long TotalSupply { get; set; }

        //[JsonPropertyName("max_supply")]
        //public long MaxSupply { get; set; }

        //[JsonPropertyName("ath")]
        //public long Ath { get; set; }

        //[JsonPropertyName("ath_change_percentage")]
        //public double AthChangePercentage { get; set; }

        //[JsonPropertyName("ath_date")]
        //public DateTimeOffset AthDate { get; set; }

        //[JsonPropertyName("atl")]
        //public double Atl { get; set; }

        //[JsonPropertyName("atl_change_percentage")]
        //public double AtlChangePercentage { get; set; }

        //[JsonPropertyName("atl_date")]
        //public DateTimeOffset AtlDate { get; set; }

        //[JsonPropertyName("roi")]
        //public object Roi { get; set; }

        //[JsonPropertyName("last_updated")]
        //public DateTimeOffset LastUpdated { get; set; }
    }
}
