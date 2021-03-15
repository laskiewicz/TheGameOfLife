using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI;
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
            ViewModel = Ioc.Default.GetService<BoardViewModel>();
        }
        public BoardViewModel ViewModel { get; set; }

        void canvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            args.DrawingSession.DrawEllipse(155, 115, 80, 30, Colors.Black, 3);
            args.DrawingSession.DrawText("Hello, world!", 100, 100, Colors.Yellow);
        }
    }
}
