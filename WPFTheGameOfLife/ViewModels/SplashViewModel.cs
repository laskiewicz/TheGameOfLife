using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WPFTheGameOfLife.ViewModels
{
    public class SplashViewModel : BindableBase
    {
        public string CurrentVersion
        {
            get
            {
                try
                {
                    return GetType().Assembly.GetName().Version.ToString();
                }
                catch
                {
                    _currentVersion = "Debug";
                }
                return _currentVersion;
            }
        }

        private string _currentVersion;
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
