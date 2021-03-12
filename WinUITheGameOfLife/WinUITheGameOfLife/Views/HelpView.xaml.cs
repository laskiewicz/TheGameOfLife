using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using WinUITheGameOfLife.ViewModels;

namespace WinUITheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for SplashView.xaml
    /// </summary>
    public partial class HelpView : Page
    {
        public HelpView()
        {
            InitializeComponent();
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            ViewModel = App.Current.Services.GetService<HelpViewModel>();
        }
        public HelpViewModel ViewModel { get; set; }
    }
}
