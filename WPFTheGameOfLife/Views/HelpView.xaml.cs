using System.Windows.Controls;
using WPFTheGameOfLife.ViewModels;

namespace WPFTheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for SplashView.xaml
    /// </summary>
    public partial class HelpView : Page
    {
        public HelpView(HelpViewModel helpViewModel)
        {
            InitializeComponent();
            DataContext = helpViewModel;
        }
    }
}
