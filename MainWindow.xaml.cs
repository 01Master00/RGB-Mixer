using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RGB_ColorMixer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color rgb = new Color();
        public MainWindow()
        {
            InitializeComponent();
            rgb.R = 0;
            rgb.G = 0;
            rgb.B = 0;
        }

        private void RedValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!(bool)RedLock.IsChecked)
            {
                rgb.R = (byte)e.NewValue;
                ChangeText();
            }
            rgb = Color.FromRgb(rgb.R, rgb.G, rgb.B);
        }

        private void GreenValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!(bool)GreenLock.IsChecked)
            {
                rgb.G = (byte)e.NewValue;
                ChangeText();
            }
            rgb = Color.FromRgb(rgb.R, rgb.G, rgb.B);
        }

        private void BlueValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!(bool)BlueLock.IsChecked)
            {
                rgb.B = (byte)e.NewValue;
                ChangeText();
            }
            rgb = Color.FromRgb(rgb.R, rgb.G, rgb.B);
        }

        private void RanomiseColorClick(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            if (!(bool)RedLock.IsChecked)
            {
                rgb.R = (byte)random.Next(0, 256);
                RedSlider.Value = rgb.R;
            }
            if (!(bool)GreenLock.IsChecked)
            {
                rgb.G = (byte)random.Next(0, 256);
                GreenSlider.Value = rgb.G;
            }
            if (!(bool)BlueLock.IsChecked)
            {
                rgb.B = (byte)random.Next(0, 256);
                BlueSlider.Value = rgb.B;
            }
            rgb = Color.FromRgb(rgb.R, rgb.G, rgb.B);
        }

        private void ResetColorClick(object sender, RoutedEventArgs e)
        {
            if (!(bool)RedLock.IsChecked)
            {
                rgb.R = 0;
                RedSlider.Value = rgb.R;
            }
            if (!(bool)GreenLock.IsChecked)
            {
                rgb.G = 0;
                GreenSlider.Value = rgb.G;
            }
            if (!(bool)BlueLock.IsChecked)
            {
                rgb.B = 0;
                BlueSlider.Value = rgb.B;
            }
            rgb = Color.FromRgb(rgb.R, rgb.G, rgb.B);
        }

        private void ResetCanvaClick(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeText()
        {
            redgreenblue.Text = $"RGB: ({rgb.R}, {rgb.G}, {rgb.B})";
            string hexR = rgb.R.ToString("X2");
            string hexG = rgb.G.ToString("X2");
            string hexB = rgb.B.ToString("X2");
            hexCode.Text = $"Hex: #{hexR}{hexG}{hexB}";

            FakeRectangle.Background = new SolidColorBrush(rgb);

            if (rgb.R + rgb.G + rgb.B < 382)
            {
                Preview.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                Preview.Foreground = new SolidColorBrush(Colors.Black);
            }

        }


    }
}