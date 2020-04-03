using Prism.Mvvm;
using Prism.Regions;
using WPFTheGameOfLife.Views;

namespace WPFTheGameOfLife.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ShellViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("BoardRegion", typeof(SplashView));
        }
    }
}
