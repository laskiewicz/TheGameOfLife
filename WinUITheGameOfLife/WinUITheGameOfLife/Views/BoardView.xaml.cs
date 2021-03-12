using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using WinUITheGameOfLife.ViewModels;

namespace WinUITheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : Page
    {
        public BoardView()
        {
            InitializeComponent();
            this.NavigationCacheMode = Microsoft.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            ViewModel = App.Current.Services.GetService<BoardViewModel>();
        }
        public BoardViewModel ViewModel { get; set; }
    }
}
