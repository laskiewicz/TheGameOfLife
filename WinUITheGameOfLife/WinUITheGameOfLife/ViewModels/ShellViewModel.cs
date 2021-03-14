using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using WinUITheGameOfLife.Views;

namespace WinUITheGameOfLife.ViewModels
{
    public class ShellViewModel : ObservableRecipient
    {
        private Page _currentpage;
        public Page CurrentPage
        {
            get => _currentpage;
            set => SetProperty(ref _currentpage, value);
        }
        public ShellViewModel(HelpView splashView)//IRegionManager regionManager)
        {
            CurrentPage = splashView;
        }
    }
}
