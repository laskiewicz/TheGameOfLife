using Microsoft.UI.Xaml.Controls;
using WinUITheGameOfLife.ViewModels;

namespace WinUITheGameOfLife.Views;

/// <summary>
/// Interaction logic for SplashView.xaml
/// </summary>
public partial class HelpView : Page
{
    public HelpView()
    {
        InitializeComponent();
        this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        ViewModel = Ioc.Default.GetService<HelpViewModel>();
    }
    public HelpViewModel ViewModel { get; set; }
}
