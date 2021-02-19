using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using WPFTheGameOfLife.Views;

namespace WPFTheGameOfLife.ViewModels
{
    public class SplashViewModel : ObservableObject
    {
        public SplashViewModel()// ShellViewModel shellViewModel)
        {
           // _shellViewModel = shellViewModel;
            StartAplicationCommand = new RelayCommand(StartAplication);
        }

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
        //private ShellViewModel _shellViewModel;
        public ICommand StartAplicationCommand { get; private set; }


        private void StartAplication()
        {
            App.Current.Services.GetService<ShellViewModel>().CurrentPage =
                App.Current.Services.GetService<BoardView>();
        }
    }
}
