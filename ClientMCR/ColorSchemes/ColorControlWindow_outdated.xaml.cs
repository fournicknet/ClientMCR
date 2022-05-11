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

            
        }

        private void PrimaryColor_ButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void DrawALine(int x,int y,byte r,byte g,byte b)
        {
            Line myLine = new Line();

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, r, g, b);

            //myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.Stroke = mySolidColorBrush;
            myLine.X1 = x;
            myLine.X2 = x;
            myLine.Y1 = y;
            myLine.Y2 = y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Top;
            myLine.StrokeThickness = 2;

            ColorGridDraw.Children.Add(myLine);
        }
        private async void DrawApixelNick(int x, int y, byte r, byte g, byte b)
        {
            PixelFormat pf = PixelFormats.Bgr32;
            int width = 1;
            int height = 1;
            //int rawStride = (width * pf.BitsPerPixel + 7) / 8;
            //byte[] rawImage = new byte[rawStride * height];
            int rawStride = pf.BitsPerPixel;
            byte[] rawImage = new byte[rawStride];
            rawImage[0] = b; //blue
            rawImage[1] = g;//Green
            rawImage[2] = r; //Red
            rawImage[3] = 0; //Alpha

            // Create a BitmapSource.
            BitmapSource bitmap = BitmapSource.Create(width, height,
                96, 96, pf, null,
                rawImage, rawStride);

            // Create an image element;
            Image myImage = new Image();
            myImage.Width = 10;
            myImage.Height = 10;
            // Set image source.
            myImage.Source = bitmap;

            
            myImage.SetValue(Grid.RowProperty, x);
            myImage.SetValue(Grid.ColumnProperty, y);

            ColorGridDraw.Children.Add(myImage);

        }

        private async void DrawSquareColorPalette()
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
                        DrawApixelNick(x, y, r, g, b);
                        DrawALine(x, y, r, g, b);
                    }
                    //AddColumnDefinitionToColorGridDraw();
                    y++;
                }
                //AddRowDefinitionToColorGridDraw();
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

        //private void DrawTextBlock(int x,int y, byte r, byte g, byte b)
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
        //}

        private async void AddRowDefinitionToColorGridDraw()
        {
            var height = GridLength.Auto;
            height = new GridLength(1, GridUnitType.Star);
            ColorGridDraw.RowDefinitions.Add(new RowDefinition()
            {
                Height = height
            });
        }

        private async void AddColumnDefinitionToColorGridDraw()
        {
            var width = GridLength.Auto;
            width = new GridLength(1, GridUnitType.Star);
            ColorGridDraw.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = width
            });
        }

        private async void DrawGrid_ButtonClick(object sender, RoutedEventArgs e)
        {
            DrawSquareColorPalette();
        }
    }
}
