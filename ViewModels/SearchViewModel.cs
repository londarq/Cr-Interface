using Cr_Interface.Model;
using Cr_Interface.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cr_Interface.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly ISearchService _searchService;

        public ObservableCollection<SearchResult> SearchResults { get; set; }

        private string _query;
        public string Query
        { 
            get { return _query; }
            set { _query = value; NotifyPropertyChanged(); GetResults(_query); }
        }

        private SearchViewModel(ISearchService searchService)
        {
            _searchService = searchService;

            SearchResults = new ObservableCollection<SearchResult>();
        }

        public static SearchViewModel LoadViewModel(ISearchService searchService, Action<Task> onLoaded = null)
        {
            SearchViewModel viewModel = new SearchViewModel(searchService);

            viewModel.Load("").ContinueWith(t => onLoaded?.Invoke(t));

            return viewModel;
        }

        public async Task Load(string query)
        {
            var apiResult = await _searchService.GetSearchResult(query);

            SearchResults.Clear();
            foreach (SearchResult searchResult in apiResult.Select(a => a))
            {
                SearchResults.Add(searchResult);
            }
        }

        private void GetResults(string query, Action<Task> onLoaded = null)
        {
            this.Load(query).ContinueWith(t => onLoaded?.Invoke(t));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

