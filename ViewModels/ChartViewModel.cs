using Cr_Interface.Services;
using Cr_Interface.Services.Models;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr_Interface.ViewModels
{
    public class ChartViewModel
    {
        private readonly IAssetService _assetService;

        public ChartValues<double> AssetPrice { get; set; }
        public ObservableCollection<string> TimeIntervals { get; set; }

        public ChartViewModel(IAssetService assetService)
        {
            _assetService = assetService;

            TimeIntervals = new ObservableCollection<string>();
        }

        public static ChartViewModel LoadViewModel(IAssetService assetService, Action<Task> onLoaded = null)
        {
            ChartViewModel viewModel = new ChartViewModel(assetService);

            viewModel.Load().ContinueWith(t => onLoaded?.Invoke(t));

            return viewModel;
        }

        public async Task Load()
        {
            IEnumerable<PriceUWU> prices = await _assetService.GetAsset("bitcoin");

            AssetPrice = new ChartValues<double>(prices.Select(p => p.Price));
            //TimeIntervals = prices.Select(p => p.Time).ToArray(); //new double[prices.Price.Count];

            TimeIntervals.Clear();
            foreach (DateTime time in prices.Select(p => p.Time))
            {
                string timeStr = time.ToString();
                TimeIntervals.Add(timeStr);
            }
        }
    }
}
