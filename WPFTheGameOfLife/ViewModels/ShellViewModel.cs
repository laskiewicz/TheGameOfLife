using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using WPFTheGameOfLife.Views;

namespace WPFTheGameOfLife.ViewModels
{
    public class ShellViewModel : ObservableRecipient
    {
        private UserControl _currentpage;
        public UserControl CurrentPage
        {
            get => _currentpage;
            set => SetProperty(ref _currentpage, value);
        }
        public ShellViewModel(BoardView splashView)//IRegionManager regionManager)
        {
            CurrentPage = splashView;
        }
    }
}
