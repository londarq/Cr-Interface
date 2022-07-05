using Cr_Interface.Model;
using Cr_Interface.Services.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cr_Interface.Services.API
{
    public class SearchService : ISearchService
    {
        const string URI = "https://api.coingecko.com/api/v3/search?query=";

        public async Task<List<SearchResult>> GetSearchResult(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = URI + query;

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                var jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                dynamic responseData = JObject.Parse(jsonResponse);
                List<SearchResult> result = responseData.coins.ToObject<List<SearchResult>>();

                return result;
            }
        }
    }
}
