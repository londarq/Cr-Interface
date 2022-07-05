using Cr_Interface.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cr_Interface.Services
{
    public interface ISearchService
    {
        Task<List<SearchResult>> GetSearchResult(string query);
    }
}
