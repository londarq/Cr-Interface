using Cr_Interface.Model;
using Cr_Interface.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cr_Interface.Services.API
{
    public class AssetService : IAssetService
    {
        const string BASE_URI = "https://api.coingecko.com/api/v3/coins/";

        const string CHART_URI_END = "/market_chart?vs_currency=usd&days=1";
        const string DETAILS_URI_END = "?localization=false&tickers=false&community_data=false&developer_data=false&sparkline=false";

        public async Task<IEnumerable<PriceTime>> GetAsset(string assetId)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = BASE_URI + assetId + CHART_URI_END;

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();


                PriceTimeAPI apiPrices = JsonSerializer.Deserialize<PriceTimeAPI>(jsonResponse);

                var result = apiPrices.Prices.ToList().Select(apiPrice => new PriceTime()
                {
                    Time = UnixTimeStampToDateTime((long)apiPrice[0]),
                    Price = apiPrice[1]
                });

                return result.ToList();
            }
        }

        public async Task<AssetDetails> GetAssetDetails(string assetId)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = BASE_URI + assetId + DETAILS_URI_END;

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();


                AssetAPI assetApi = JsonSerializer.Deserialize<AssetAPI>(jsonResponse);

                AssetDetails assetDetails = new AssetDetails()
                {
                    CurrentPrice = assetApi.MarketData.CurrentPrice["usd"],
                    TotalVolume = assetApi.MarketData.TotalVolume["usd"],
                    PriceChange24h = assetApi.MarketData.PriceChange24h
                };

                return assetDetails;
            }
        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var sourceTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp);
            
            return sourceTime.DateTime;
        }
    }
}
