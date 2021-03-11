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
            ViewModel = new HelpViewModel();
        }
        public HelpViewModel ViewModel { get; set; }
    }
}
