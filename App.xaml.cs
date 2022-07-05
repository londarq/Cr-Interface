using Cr_Interface.Services;
using Cr_Interface.Services.API;
using Cr_Interface.ViewModels;
using System.Windows;


namespace Cr_Interface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            //SearchService searchService = new SearchService();
            //var resultCurrenciesService = await searchService.GetSearchResult("btc");

            //CurrenciesService currenciesService = new CurrenciesService();
            //var resultCurrenciesService = await currenciesService.GetTopCurrencies();

            //AssetService assetService = new AssetService();
            //var resultAssetService = await assetService.GetAsset("bitcoin");

            MainWindow mainWindow = new MainWindow();
            ICurrenciesService currencyService = new CurrenciesService();
           
            mainWindow.DataContext = MainViewModel.LoadViewModel(currencyService);
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
