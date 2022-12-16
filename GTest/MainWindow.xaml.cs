using GTest.Models;
using GTest.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Context();
        }
        private double factor = 30;
        public double width = 20;
        public double height = 12;
        readonly double _width = 34;
        bool select = false;
        Items item;
        Rectangle rect = new Rectangle();
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            factor = ow.ActualWidth / _width;
            UpdateSize();
        }
        private void UpdateSize()
        {
            elementView.Width = width * factor;
            elementView.Height = height * factor;

            draw();
        }

        private void dataView_SelectionChanged(object sender, SelectionChangedEventArgs e) { draw(); }
        private void draw()
        {
            try
            {
                select = true;
                if (select == true && dataView.SelectedItem != null)
                {
                    item = (Items)dataView.SelectedItem;
                    double x = item.Distance, y = item.Angle;
                    elementView.Children.Remove(rect);
                    rect.Width = item.Width * factor;
                    rect.Height = item.Height * factor;
                    rect.Fill = Brushes.Bisque;
                    rect.Name = "el";
                    elementView.Children.Add(rect);
                    Canvas.SetBottom(rect, y * factor - (rect.Height / 2));
                    Canvas.SetLeft(rect, x * factor - (rect.Width / 2));
                    select = false;
                }
            }
            catch
            {
                elementView.Children.Remove(rect);
            }

        }
    }
}
