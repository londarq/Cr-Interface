using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cr_Interface.Model
{
    public class SearchResult
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        [JsonProperty("market_cap_rank")]
        public long MarketCapRank { get; set; }

        public string Large { get; set; }
    }
}
