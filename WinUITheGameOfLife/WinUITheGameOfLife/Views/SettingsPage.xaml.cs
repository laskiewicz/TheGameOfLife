using Microsoft.UI.Xaml.Controls;
using WinUITheGameOfLife.ViewModels;

namespace WinUITheGameOfLife.Views;

public partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetService<SettingsViewModel>();
    }
    public SettingsViewModel ViewModel { get; }
}
