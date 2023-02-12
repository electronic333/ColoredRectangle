using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ColoredRectangle.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ClickButton(object senter, RoutedEventArgs routedEventArgs)
        {
            Button? b = senter as Button;
            Rect.Fill = b.Background;
        }
    }
}
