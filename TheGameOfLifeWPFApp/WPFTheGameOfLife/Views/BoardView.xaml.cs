using System.Windows.Controls;
using WPFTheGameOfLife.ViewModels;

namespace WPFTheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : Page
    {
        public BoardView(BoardViewModel boardViewModel)
        {
            InitializeComponent();
            DataContext = boardViewModel;
        }
    }
}
