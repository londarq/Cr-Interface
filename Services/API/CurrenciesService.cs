using Cr_Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cr_Interface.Services.API
{
    public class CurrenciesService : ICurrenciesService
    {
        public async Task<IEnumerable<Asset>> GetTopCurrencies(int amountOfCurrencies = 10)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&per_page=" + amountOfCurrencies;

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                List<Asset> apiCurrencies = JsonSerializer.Deserialize<List<Asset>>(jsonResponse);

                return apiCurrencies.Select(apiAsset => new Asset()
                {
                    Id = apiAsset.Id,
                    Symbol = apiAsset.Symbol,
                    Name = apiAsset.Name,
                    CurrentPrice = apiAsset.CurrentPrice
                });
            }
        }
    }
}
