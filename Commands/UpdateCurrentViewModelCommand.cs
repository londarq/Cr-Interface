using Cr_Interface.Services;
using Cr_Interface.Services.API;
using Cr_Interface.State.Navigators;
using Cr_Interface.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cr_Interface.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public INavigator _navigator;

        public ChartViewModel chartViewModel { get; set; }


        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                switch(viewType)
                {
                    case ViewType.Main:
                        _navigator.CurrentViewModel = new MainViewModel();
                        break;
                    case ViewType.Chart:
                        IAssetService assetServise = new AssetService();
                        _navigator.CurrentViewModel = ChartViewModel.LoadViewModel(assetServise);

                        //_navigator.CurrentViewModel = new ChartViewModel();
                        break;
                    case ViewType.Convert:
                        _navigator.CurrentViewModel = new ConvertViewModel();
                        break;
                    default:
                        break;
                }
            }       
        }
    }
}
