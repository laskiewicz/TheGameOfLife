using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUITheGameOfLife.ViewModels;

namespace WinUITheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public sealed partial class ShellView : Window
    {
        public ShellView()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<ShellViewModel>();
            MainContentFrame.Navigate(typeof(HelpView));
        }
        public ShellViewModel ViewModel { get; set; }
        public Frame GetNavigationFrame()
            => MainContentFrame;
    }
}
