using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPFTheGameOfLife.Models
{
    public class Cell: ObservableObject
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
            get => _fill;
            set => SetProperty(ref _fill, value);
        }
    }
}
