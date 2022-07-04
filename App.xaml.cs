using Cr_Interface.Services.API;
using Cr_Interface.Services.Models;
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
            CurrenciesService currenciesService = new CurrenciesService();
            var resultCurrenciesService = await currenciesService.GetTopCurrencies();

            //AssetService assetService = new AssetService();
            //var resultAssetService = await assetService.GetAsset("bitcoin");


            MainWindow mainWindow = new MainWindow();

            mainWindow.DataContext = new MainViewModel();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
