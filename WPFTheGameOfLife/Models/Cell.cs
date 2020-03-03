using System.Windows.Media;
using Prism.Mvvm;

namespace WPFTheGameOfLife.Models
{
    public class Cell : BindableBase
    {
        public bool isAlive{ get; set; }
        public bool willBeAlive{ get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Brush Stroke { get; set; }
        private Brush _fill;
        public Brush Fill
        {
            get { return _fill; }
            set { SetProperty(ref _fill, value); }
        }
    }
}
