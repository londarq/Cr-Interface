using Cr_Interface.Services.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

            var result = await currenciesService.GetTopCurrencies();

            base.OnStartup(e);
        }
    }
}
