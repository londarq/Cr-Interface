using Cr_Interface.Model;
using Cr_Interface.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cr_Interface.Services.API
{
    public class AssetService : IAssetService
    {
        const string requestUriStart = "https://api.coingecko.com/api/v3/coins/";
        const string requestUriEnd = "/market_chart?vs_currency=usd&days=30";

        public async Task<IEnumerable<PriceUWU>> GetAsset(string assetId)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = requestUriStart + assetId + requestUriEnd;

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();



                PriceWTime apiPrices = JsonSerializer.Deserialize<PriceWTime>(jsonResponse);

                var result = apiPrices.Prices.ToList().Select(apiPrice => new PriceUWU()
                {
                    Time = UnixTimeStampToDateTime((long)apiPrice[0]),
                    Price = apiPrice[1]
                });

                return result.ToList();
            }
        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var sourceTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp);
            
            return sourceTime.DateTime;
        }
    }
}
