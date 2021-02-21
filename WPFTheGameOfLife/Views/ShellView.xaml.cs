using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using WPFTheGameOfLife.ViewModels;

namespace WPFTheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<ShellViewModel>();
            MainContentFrame.Navigate(App.Current.Services.GetService<HelpView>());
        }
        public Frame GetNavigationFrame()
            => MainContentFrame;
    }
}
