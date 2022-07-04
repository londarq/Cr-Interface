using Cr_Interface.Services;
using Cr_Interface.Services.API;
using Cr_Interface.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr_Interface.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator navigator { get; set; } = new Navigator();

        //public ChartViewModel chartViewModel { get; set; }

        public MainViewModel()
        {
            //IAssetService assetServise = new AssetService();
            //chartViewModel = ChartViewModel.LoadViewModel(assetServise);
        }
    }
}
