using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientMCR.ColorSchemes
{
    /// <summary>
    /// Interaction logic for ColorControlWindow.xaml
    /// </summary>
    public partial class ColorControlWindow : Page
    {
        Frame mainframe;
        public ColorControlWindow(Frame MainFrameWindow)
        {
            InitializeComponent();

            mainframe = MainFrameWindow;

            //DrawApixelNick();

            //DrawSquareColorPalette();
        }

        private void PrimaryColor_ButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void DrawApixelNick()
        {
            PixelFormat pf = PixelFormats.Bgr32;
            int width = 800;
            int height = 800;
            int rawStride = (width * pf.BitsPerPixel + 7) / 8;
            byte[] rawImage = new byte[rawStride * height];

            // Initialize the image with data.
            Random value = new Random();
            value.NextBytes(rawImage);

            // Create a BitmapSource.
            BitmapSource bitmap = BitmapSource.Create(width, height,
                96, 96, pf, null,
                rawImage, rawStride);

            // Create an image element;
            Image myImage = new Image();
            myImage.Width = 200;
            myImage.Height = 200;
            // Set image source.
            myImage.Source = bitmap;

            
            myImage.SetValue(Grid.RowProperty, 1);
            myImage.SetValue(Grid.ColumnProperty, 1);
        }

        private void DrawSquareColorPalette()
        {
            int x = 0
                , y = 0;
            //ColorGridDraw.Children
            for (byte r = 0; r < 256; r++)
            {
                

                for (byte g = 0; g < 256; g++)
                {
                    for (byte b = 0; b < 256; b++)
                    {
                        //DrawColorBlock(x, y, r, g, b);

                    }
                    AddColumnDefinitionToColorGridDraw();
                    y++;
                }
                AddRowDefinitionToColorGridDraw();
                x++;
            }
            


        }

        //private void DrawColorBlock(int x, int y, byte r, byte g, byte b)
        //{
        //    string textX = x.ToString();
        //    string textY = y.ToString();
        //    string totalXY = textX + textY;

            

        //    TextBlock TextBloAddressLine1 = new TextBlock();
        //    TextBloAddressLine1.Text = "";
        //    TextBloAddressLine1.Name = "totalXY";
        //    TextBloAddressLine1.SetValue(Grid.RowProperty, x);
        //    TextBloAddressLine1.SetValue(Grid.ColumnProperty, y);

        //    Color currentColor = new Color();
        //    currentColor.A = 255;
        //    currentColor.R = r;
        //    currentColor.G = g;
        //    currentColor.B = b;

        //    TextBloAddressLine1.Background = new SolidColorBrush(currentColor);

        //    ColorGridDraw.Children.Add(TextBloAddressLine1);

        //    PixelFormat pf = PixelFormats.Bgr32;
        //    int width = 200;
        //    int height = 200;


        //    Bitmap bitmap = new Bitmap()

        //    DrawingVisual visual = new DrawingVisual();
        //    visual.BitmapEffect
        //}

        private void DrawTextBlock(int x,int y, byte r, byte g, byte b)
        {
            string textX = x.ToString();
            string textY = y.ToString();
            string totalXY = textX + textY;
            TextBlock TextBloAddressLine1 = new TextBlock();
            TextBloAddressLine1.Text = "";
            TextBloAddressLine1.Name = "totalXY";
            TextBloAddressLine1.SetValue(Grid.RowProperty, x);
            TextBloAddressLine1.SetValue(Grid.ColumnProperty, y);

            Color currentColor = new Color();
            currentColor.A = 255;
            currentColor.R = r;
            currentColor.G = g;
            currentColor.B = b;
 
            TextBloAddressLine1.Background = new SolidColorBrush(currentColor);

            ColorGridDraw.Children.Add(TextBloAddressLine1);
        }

        private void AddRowDefinitionToColorGridDraw()
        {
            var height = GridLength.Auto;
            height = new GridLength(1, GridUnitType.Star);
            ColorGridDraw.RowDefinitions.Add(new RowDefinition()
            {
                Height = height
            });
        }

        private void AddColumnDefinitionToColorGridDraw()
        {
            var width = GridLength.Auto;
            width = new GridLength(1, GridUnitType.Star);
            ColorGridDraw.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = width
            });
        }
    }
}
