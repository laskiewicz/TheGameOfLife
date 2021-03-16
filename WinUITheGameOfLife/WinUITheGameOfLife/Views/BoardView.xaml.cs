using Microsoft.Graphics.Canvas.Geometry;
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
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    args.DrawingSession.DrawRectangle(i*10, j*10, 10, 10, Colors.White, 1);
                    args.DrawingSession.FillRectangle(i*10, j*10, 10, 10, Colors.LightGreen);
                }
            }
        }
    }
}
