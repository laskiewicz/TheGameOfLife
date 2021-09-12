using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;
using Windows.UI;
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

            _ = DrawLoopAsync();
        }

        private async Task DrawLoopAsync()
        {
            while (true)
            {
                canvasControl.Invalidate();
                await Task.Delay(250);
            }
        }

        public BoardViewModel ViewModel { get; set; }

        private void CanvasAnimatedControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Color cellColor = ViewModel.CellItems[i][j].isAlive ? Colors.Green : Colors.Gray;
                    if (ViewModel.CellItems[i][j].wasAlive)
                        cellColor = Colors.Red;
                    args.DrawingSession.DrawRectangle(i * 10, j * 10, 10, 10, Colors.White, 1);
                    args.DrawingSession.FillRectangle(i * 10, j * 10, 10, 10, cellColor);
                }
            }
        }

        private void CanvasAnimatedControl_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            CanvasCommandList cl = new CanvasCommandList(sender);
            using (CanvasDrawingSession clds = cl.CreateDrawingSession())
            {
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        Color isAlive = ViewModel.CellItems[i][j].isAlive ? Colors.Green : Colors.Gray;
                        clds.DrawRectangle(i * 10, j * 10, 10, 10, Colors.White, 1);
                        clds.FillRectangle(i * 10, j * 10, 10, 10, isAlive);
                    }
                }
            }
        }
    }
}
