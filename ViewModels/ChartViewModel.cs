using Cr_Interface.Model;
using Cr_Interface.Services;
using Cr_Interface.Services.Models;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cr_Interface.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        private readonly IAssetService _assetService;

        public ChartValues<double> AssetPrice { get; set; }
        public ObservableCollection<string> TimeIntervals { get; set; }


        private string _assetName;
        public string AssetName 
        {
            get { return _assetName; }
            set { _assetName = value; }
        }

        private AssetDetails _details;
        public AssetDetails Details {
            get { return _details; }
            set { _details = value; NotifyPropertyChanged("Details"); }
        }

        private ChartViewModel(IAssetService assetService)
        {
            _assetService = assetService;
            AssetName = "[eq cjcb";
            Details = new AssetDetails()
            {
                CurrentPrice = 0,
                PriceChange24h = 0,
                TotalVolume = 0
            };

            TimeIntervals = new ObservableCollection<string>();
        }

        public static ChartViewModel LoadViewModel(string id, IAssetService assetService, Action<Task> onLoaded = null)
        {
            ChartViewModel viewModel = new ChartViewModel(assetService);

            viewModel.Load(id).ContinueWith(t => onLoaded?.Invoke(t));

            return viewModel;
        }

        public async Task Load(string id)
        {
            AssetName = id;

            Details = await _assetService.GetAssetDetails(id);
            IEnumerable<PriceTime> prices = await _assetService.GetAsset(id);

            AssetPrice = new ChartValues<double>(prices.Select(p => p.Price));

            TimeIntervals.Clear();
            foreach (DateTime time in prices.Select(p => p.Time))
            {
                string timeStr = time.ToString();
                TimeIntervals.Add(timeStr);
            }
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
