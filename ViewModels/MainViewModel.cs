using Cr_Interface.Model;
using Cr_Interface.Services;
using Cr_Interface.State.Navigators;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Cr_Interface.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private const int AMOUNT_OF_ASSETS = 10;

        private readonly ICurrenciesService _currenciesService;
        
        public INavigator navigator { get; set; } = new Navigator();
        
        public ObservableCollection<Asset> Assets { get; set; }

        private MainViewModel(ICurrenciesService currenciesService)
        {
            _currenciesService = currenciesService;

            Assets = new ObservableCollection<Asset>();
        }

        public static MainViewModel LoadViewModel(ICurrenciesService currenciesService, Action<Task> onLoaded = null)
        {
            MainViewModel viewModel = new MainViewModel(currenciesService);

            viewModel.Load().ContinueWith(t => onLoaded?.Invoke(t));

            return viewModel;
        }

        public async Task Load()
        {
            var apiResult = await _currenciesService.GetTopCurrencies(AMOUNT_OF_ASSETS);

            Assets.Clear();
            foreach (Asset asset in apiResult.Select(a => a))
            {
                Assets.Add(asset);
            }
        }
    }
}
