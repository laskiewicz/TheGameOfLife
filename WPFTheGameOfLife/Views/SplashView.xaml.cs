using System.Windows.Controls;
using WPFTheGameOfLife.ViewModels;

namespace WPFTheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for SplashView.xaml
    /// </summary>
    public partial class SplashView : UserControl
    {
        public SplashView(SplashViewModel splashViewModel)
        {
            InitializeComponent();
            DataContext = splashViewModel;
        }
    }
}
