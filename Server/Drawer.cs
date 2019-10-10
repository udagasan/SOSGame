using Common;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Server
{
    public class Drawer
    {
        public int ButtonSize { get; set; }
        public int StrokeThickness { get; set; } = 3;
        public System.Windows.Controls.Grid Grid { get; set; }
        public SolidColorBrush Color { get; set; }

        public Drawer(System.Windows.Controls.Grid grid, SolidColorBrush color, Model model)
        {
            ButtonSize = model.ButtonSize;
            Grid = grid;
            Color = color;

        }


        public void DrawLineHorizontal()
        {
            var myLine = new Line
            {
                Stroke = Color,
                X1 = ButtonSize / 2,
                X2 = ButtonSize / 2,
                Y1 = 0,
                Y2 = ButtonSize,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = StrokeThickness
            };
            Grid.Children.Add(myLine);

        }
        public void DrawLineVertical()
        {
            var myLine = new Line
            {
                Stroke = Color,
                X1 = 0,
                X2 = ButtonSize,
                Y1 = ButtonSize / 4,
                Y2 = ButtonSize / 4,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = StrokeThickness
            };
            Grid.Children.Add(myLine);

        }
        public void DrawLineLeftDiagonal()
        {
            var myLine = new Line
            {
                Stroke = Color,
                X1 = 0,
                X2 = ButtonSize,
                Y1 = 0,
                Y2 = ButtonSize,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = StrokeThickness
            };
            Grid.Children.Add(myLine);

        }
        public void DrawLineRightDiagonal()
        {
            var myLine = new Line
            {
                Stroke = Color,
                X1 = 0,
                X2 = ButtonSize,
                Y1 = ButtonSize,
                Y2 = 0,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = StrokeThickness
            };
            Grid.Children.Add(myLine);

        }
    }

}
