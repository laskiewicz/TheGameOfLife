using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTheGameOfLife.ViewModels
{
    public class SplashViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand StartAplicationCommand { get; private set; }
        public SplashViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            StartAplicationCommand = new DelegateCommand(StartAplication);
        }

        private void StartAplication()
        {
            _regionManager.RequestNavigate("BoardRegion", "BoardView");
        }
    }
}
