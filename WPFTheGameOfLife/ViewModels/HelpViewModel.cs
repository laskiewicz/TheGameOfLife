using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using WPFTheGameOfLife.Views;

namespace WPFTheGameOfLife.ViewModels
{
    public class HelpViewModel : ObservableObject
    {
        public HelpViewModel()
        {
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
        public ICommand StartAplicationCommand { get; private set; }

        private void StartAplication()
        {
            ShellView shell = App.Current.Services.GetService<ShellView>();
            shell.GetNavigationFrame().Navigate(App.Current.Services.GetService<BoardView>());
            shell.GetNavigationFrame().ContextMenu = null;
        }
    }
}
