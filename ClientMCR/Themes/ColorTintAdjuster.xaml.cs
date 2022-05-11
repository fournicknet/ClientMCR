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
using ClientMCR.SavingData;

namespace ClientMCR.Themes
{
    /// <summary>
    /// Interaction logic for ColorTintAdjuster.xaml
    /// </summary>
    public partial class ColorTintAdjuster : Page
    {        //Cursor customCursor;
        private Image image = new Image();
        private Image imageBlacknWhite = new Image();
        private BitmapImage myBitmapImage = new BitmapImage();
        private BitmapImage myBlackToWhiteBitmapImage = new BitmapImage();

        private PixelFormat pf = PixelFormats.Bgra32;
        private int widthNewPF = 382, blackToWhiteWidth;
        public byte[] byteArray;
        public byte[] blackToWhiteByteArray;
        public int stride;
        public byte[] pixels;
        public SolidColorBrush newBackground = new SolidColorBrush();

        private double SizeHeightRect = 30d, SizeWidthRect = 1d, positionWidth = 1d, positionHeight = 1d;

        public ColorTintAdjuster()
        {
            InitializeComponent();

            //We are getting the color spectrum from color-pallete that was made from rev9.
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"C:\Future Company Projects\WPF_APP_ColorTintAdjuster\WPFAPP_ColorTintAdjuster\WPFAPP_ColorTintAdjuster\Images\rev9-color-pallet-by-nick.bmp");
            myBitmapImage.EndInit();

            //we know the image we imported is 24 bit but just to be sure we are checking the format.
            if (myBitmapImage.Format != PixelFormats.Bgra32)
            {
                //we are converting the 24 bit image from myBitmapImage to 32 bit myDestImage.
                //in order to get positions correctly inside the image we had to convert it to 32 bit
                FormatConvertedBitmap myDestImage = new FormatConvertedBitmap(myBitmapImage, PixelFormats.Bgra32, null, 0);

                //assigned the new bitmap to a new image source to render to screen.
                image.Source = myDestImage;

                //getting the pixelwidth and height for mouse reference.
                int width = myDestImage.PixelWidth;
                int height = myDestImage.PixelHeight;

                //i think we are making the array *4 because we are using alpha, red, blue, green for our colors.
                byteArray = new byte[width * height * 4];

                //The stride is the number of bytes from one row of pixels in memory to the next row of pixels in memory. Stride is also called pitch
                //ms docs
                int stride = width * 4;

                //we are coping the pixles from the myDestImage into the byteArray, using the stride we provided earlier.
                //there is no off-set so we provide the value of 0
                myDestImage.CopyPixels(byteArray, stride, 0);

                //History lesson- backgrounds probibly need to be assigned for mouse enter and mouse leave to work.
                //ColorStackGrid.MouseEnter += new MouseEventHandler(GetMousePosition);
                //ColorStackGrid.MouseLeave -= new MouseEventHandler(GetMousePosition);

                //when we use the mouse left button down and up we are going to get the positon of the mouse
                //and call GetMousePosition
                //we are doing this so that the new control that we make will have the correct colors displayed in it.
                ColorStackGrid.MouseLeftButtonDown += new MouseButtonEventHandler(GetMousePosition);
                ColorStackGrid.MouseLeftButtonUp -= new MouseButtonEventHandler(GetMousePosition);

                //we are assigning our image as a child object in xaml to the grid that we named earlier in xaml.
                ColorStackGrid.Children.Add(image);

                //We need to make a clickable picture for the grayscale, importing the file into a bitmap image
                myBlackToWhiteBitmapImage.BeginInit();
                myBlackToWhiteBitmapImage.UriSource = new Uri(@"C:\Future Company Projects\WPF_APP_ColorTintAdjuster\WPFAPP_ColorTintAdjuster\WPFAPP_ColorTintAdjuster\Images\rev1-BlackToWhite.bmp");
                myBlackToWhiteBitmapImage.EndInit();
                if (myBlackToWhiteBitmapImage.Format != PixelFormats.Bgra32)
                {
                    //again converting it from 24bit to 32 bit.
                    FormatConvertedBitmap myBlacknWhiteImage = new FormatConvertedBitmap(myBlackToWhiteBitmapImage, PixelFormats.Bgra32, null, 0);
                    //assigning the image object to the bitmap image
                    imageBlacknWhite.Source = myBlacknWhiteImage;

                    //We now get the width and height of the pixels and assign them to ints
                    int blackToWhiteWidth = myBlacknWhiteImage.PixelWidth;
                    int blackToWhiteHeight = myBlacknWhiteImage.PixelHeight;

                    //creating the bitmap array size in bytes with the int values and since there are 4 colors 4.
                    blackToWhiteByteArray = new byte[blackToWhiteWidth * blackToWhiteHeight * 4];

                    //The stride is the number of bytes from one row of pixels in memory to the next row of pixels in memory. Stride is also called pitch
                    //ms docs
                    int strideBlackToWhite = blackToWhiteWidth * 4;

                    //we are now copying the pixels of the blacknwhite image to the array with the stride we made earlier, no offset so 0.
                    myBlacknWhiteImage.CopyPixels(blackToWhiteByteArray, strideBlackToWhite, 0);

                    //when the mouse is clicked over the canvas we are capturing the event and sending it to the GetMousePositionBlackToWhite Method
                    BlackToWhiteCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(GetMousePositionBlackToWhite);
                    BlackToWhiteCanvas.MouseLeftButtonUp -= new MouseButtonEventHandler(GetMousePositionBlackToWhite);

                    //we are now adding the image to the canvas that we imported
                    BlackToWhiteCanvas.Children.Add(imageBlacknWhite);
                }

            }
        }

        //When the color Tint Shade is clicked it comes here to be reassigned to the currentcolorselected method and passed in color values
        private void GetColorRect(object sender, MouseEventArgs e)
        {
            //Nick: not sure why we are checking for null but it seemed like a good idea at the time.
            if (sender != null)
            {
                //we are creating a place for our color to go to get the values.
                SolidColorBrush myColorRectBrush = new SolidColorBrush();

                //We are getting the source of the click event and assigning it to a rectangle since we know that was what was clicked.
                Rectangle currentRect = (Rectangle)e.Source;
                //we now assign the color value of the rect.fill and recast to a solidcolorbrush
                myColorRectBrush = (SolidColorBrush)currentRect.Fill;
                //we now get each color from myColorRectBrush.Color.A Red Green Blue
                //and pass it to the canvas that we want to paint to.
                currentColorSelected(CurrentColorSelected, myColorRectBrush.Color.A, myColorRectBrush.Color.R, myColorRectBrush.Color.G, myColorRectBrush.Color.B);
            }

        }

        //this method is called when we are clicking on the blackandwhite canvas
        private void GetMousePositionBlackToWhite(object sender, MouseEventArgs e)
        {
            //The mouse position is cased in double/float initialy, in order to get our grid
            //to work correctly we have to re-cast the double/float into an int.

            //we get the horzontal and vertical coordinates respectivly and assign them to a window variable
            int windowX = (int)e.GetPosition(BlackToWhiteCanvas).X;
            int windowY = (int)e.GetPosition(BlackToWhiteCanvas).Y;

            //so a user was posting code to reference on the internet
            //how they are getting access to the colors via the bitArray that was created from the image created earlier.
            //this is the formula they were using. each integer 0,1,2,3 reperesents a color, red,blue,green or alpha
            //the stride is not used because it is already calculated in a reduced format.
            byte blue = blackToWhiteByteArray[(windowY * blackToWhiteWidth + windowX) * 4 + 0];
            byte green = blackToWhiteByteArray[(windowY * blackToWhiteWidth + windowX) * 4 + 1];
            byte red = blackToWhiteByteArray[(windowY * blackToWhiteWidth + windowX) * 4 + 2];
            byte alpha = blackToWhiteByteArray[(windowY * blackToWhiteWidth + windowX) * 4 + 3];

            //we now get each color from the BlackToWhiteByteArray and pass them to the color selected.
            currentColorSelected(CurrentColorSelected, alpha, red, green, blue);

        }

        //When we click in the maincolor canvas it is passed here to recast the color in the color tint shade area
        private void GetMousePosition(object sender, MouseEventArgs e)
        {
            //The mouse position is cased in double/float initialy, in order to get our grid
            //to work correctly we have to re-cast the double/float into an int.

            //we get the horzontal and vertical coordinates respectivly and assign them to a window variable
            int windowX = (int)e.GetPosition(ColorStackGrid).X;
            int windowY = (int)e.GetPosition(ColorStackGrid).Y;

            //the width of the image that was set earlier is assigned to width.
            int width = widthNewPF;

            //so a user was posting code to reference on the internet
            //how they are getting access to the colors via the bitArray that was created from the image created earlier.
            //this is the formula they were using. each integer 0,1,2,3 reperesents a color, red,blue,green or alpha
            //the stride is not used because it is already calculated in a reduced format.
            byte blue = byteArray[(windowY * width + windowX) * 4 + 0];
            byte green = byteArray[(windowY * width + windowX) * 4 + 1];
            byte red = byteArray[(windowY * width + windowX) * 4 + 2];
            byte alpha = byteArray[(windowY * width + windowX) * 4 + 3];

            //Incase we just want to use a basic color it is passed to the current color selected canvas
            currentColorSelected(CurrentColorSelected, alpha, red, green, blue);

            //This is the method that gives us different shades of the color to choose from
            colorTintControl(MyCanvasColorTint, alpha, red, green, blue);
        }



        //This is where we draw the square for the color selected from one of the three areas.
        private void currentColorSelected(Canvas CurrentColorSelected, byte alphaColor, byte redColor, byte greenColor, byte blueColor)
        {
            //we are creating a color brush to store our values passed to us.
            SolidColorBrush myTintColorBrush = new SolidColorBrush();

            //we can not pass the values directly that were provided as a color, we must assign them to the color
            //we create a solidcolorbrush so that our colors have a place to go
            myTintColorBrush.Color = Color.FromArgb(alphaColor, redColor, greenColor, blueColor);

            //we now create a rectangle from the rectangle class, this provides our "pixel to draw to the canvas"
            Rectangle rectangle = new Rectangle
            {
                //I assigned it to 50double to give an appropriate size that felt right
                //we are getting the size of the width and hight of the canvas and passing the doubles into height and width
                Height = 70d,
                Width = 70d,
            };

            //we assign the colorbrush to the rectangle
            rectangle.Fill = myTintColorBrush;
            CurrentColorSelected.Children.Add(rectangle);
            //we are now providing the position of the rect to our canvas and 
            //the 1d represents the positions in doubles
            Canvas.SetLeft(rectangle, 1d * 50d);
            Canvas.SetTop(rectangle, 1d * 50d);

            //Assign the colors to the rectangles we xamled in
            TopTitle.Fill = myTintColorBrush;
            SecondaryColor.Fill = myTintColorBrush;
            TextObject.Fill = myTintColorBrush;

        }

        //this control will control the tint of the colors passed to it.
        //we are passing the name of the canvas for more control options on modify the position of the rects that we will create
        private void colorTintControl(Canvas MyCanvasColorTint, byte alphaColor, byte redColor, byte greenColor, byte blueColor)
        {

            //we are saving our color values in the same type so we can work with them in the loop
            byte newAlphaColor = alphaColor;
            //OLD Value
            //byte newAlphaColor = (byte)255;

            byte newRedColor = redColor;
            byte newGreenColor = greenColor;
            byte newBlueColor = blueColor;

            //when we start the loop below we are starting in the middle of the color tint bar so we initialize the height to 256.
            //I did 256 twice to give good color definition
            positionWidth = 256d;
            positionHeight = 1d;
            //there is a range of 256 colors so we start half way in the middle and iterate assigning each color to our tint control
            for (int i = 0; i < 256; i++)
            {
                //we have to create a new brush for each rect we draw
                SolidColorBrush myTintColorBrush = new SolidColorBrush();

                //we can not pass the values directly that were provided as a color, we must assign them to the color
                //we create a solidcolorbrush so that our colors have a place to go
                myTintColorBrush.Color = Color.FromArgb(newAlphaColor, newRedColor, newGreenColor, newBlueColor);

                //we now create a rectangle from the rectangle class, this provides our "pixel to draw to the canvas"
                Rectangle rectangle = new Rectangle
                {
                    Height = SizeHeightRect,
                    Width = SizeWidthRect,
                };
                //We now assign a click event when the mouse butten is clicked to pass the values that were stored.
                rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(GetColorRect);
                rectangle.MouseLeftButtonUp -= new MouseButtonEventHandler(GetColorRect);
                //we assign the colorbrush to the rectangle
                rectangle.Fill = myTintColorBrush;
                MyCanvasColorTint.Children.Add(rectangle);
                //we are now providing the position of the rect to our canvas and 
                Canvas.SetLeft(rectangle, positionWidth * SizeWidthRect);
                Canvas.SetTop(rectangle, positionHeight * SizeHeightRect);

                //we now have to adjust our values to get ready for the next iteration
                //I tried 0.9f  instead of 1f so that i could reduce the size of the tint color to match but it didn't work
                //other wise i just would have used positionHeight++;
                positionWidth = positionWidth - 1d;

                //bytes can not be added together, so we have to do the operation manually, it is best to create a new method to not repeat our selves.
                //we are going to call our increase method
                newRedColor = DecreaseBytes(newRedColor);
                newGreenColor = DecreaseBytes(newGreenColor);
                newBlueColor = DecreaseBytes(newBlueColor);
            }

            //now we have do the same thing what we did earlier but this time in the other direction and in reverse or forward how ever you look at it.
            byte newDarkerAlphaColor = newAlphaColor;
            //Old Value
            //byte newDarkerAlphaColor = (byte)255;
            byte newDarkerRedColor = redColor;
            byte newDarkerGreenColor = greenColor;
            byte newDarkerBlueColor = blueColor;

            //when we start the loop below we are starting in the middle of the color tint bar so we initialize the height to 257 and work the other direction.
            positionWidth = 257d;
            //there is a range of 256 colors so we start half way in the middle and iterate assigning each color to our tint control
            //Again, this was done to provide better color defitintion.
            for (int i = 0; i < 256; i++)
            {
                //we have to create a new brush for each rect we draw
                SolidColorBrush myTintColorBrush = new SolidColorBrush();

                //we can not pass the values directly that were provided as a color, we must assign them to the color
                //we create a solidcolorbrush so that our colors have a place to go
                myTintColorBrush.Color = Color.FromArgb(newDarkerAlphaColor, newDarkerRedColor, newDarkerGreenColor, newDarkerBlueColor);

                //we now create a rectangle from the rectangle class, this provides our "pixel to draw to the canvas"
                Rectangle rectangle = new Rectangle
                {
                    Height = SizeHeightRect,
                    Width = SizeWidthRect,
                };
                //We now assign a click event when the mouse butten is clicked to pass the values that were stored.
                rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(GetColorRect);
                rectangle.MouseLeftButtonUp -= new MouseButtonEventHandler(GetColorRect);
                //we assign the colorbrush to the rectangle
                rectangle.Fill = myTintColorBrush;
                MyCanvasColorTint.Children.Add(rectangle);
                //we are now providing the position of the rect to our canvas and 
                Canvas.SetLeft(rectangle, positionWidth * SizeWidthRect);
                Canvas.SetTop(rectangle, positionHeight * SizeHeightRect);

                //we now have to adjust our values to get ready for the next iteration
                //I tried 0.9f  instead of 1f so that i could reduce the size of the tint color to match but it didn't work
                //other wise i just would have used positionHeight++;
                positionWidth = positionWidth + 1d;

                //bytes can not be added together, so we have to do the operation manually, it is best to create a new method to not repeat our selves.
                //we are going to call our increase method
                newDarkerRedColor = IncreaseBytes(newDarkerRedColor, "red");
                newDarkerGreenColor = IncreaseBytes(newDarkerGreenColor, "green");
                newDarkerBlueColor = IncreaseBytes(newDarkerBlueColor, "blue");
            }

        }

        private byte IncreaseBytes(byte colorPassedToUs, string colorPassed)
        {
            int currentColor = (int)colorPassedToUs;
            if (currentColor < 253)
            {
                //Debug is disabled since we dont need it now.
                //if (colorPassed == "blue")
                //{
                //    Debug.Write(currentColor.ToString() + colorPassed);
                //}
                //else if(colorPassed == "green")
                //{
                //    Debug.Write(currentColor.ToString() + colorPassed);
                //}
                //else
                //{
                //    Debug.WriteLine(currentColor.ToString() + colorPassed);
                //}

                //we are now incrementing it by 2 because we did the previous opperations for drawing rects in two loops.
                //it was incremented twice before because we didn't have twice the length to work with when working vertical
                currentColor++;
                //need to cast the int back into byte
                byte colorTheyWant = (byte)currentColor;
                return colorTheyWant;
            }
            else
            {
                //we now have to cast it back to a byte since we did nothing
                return colorPassedToUs;
            }

        }

        private byte DecreaseBytes(byte colorPassedToUs)
        {
            int currentColor = (int)colorPassedToUs;
            if (currentColor > 3)
            {
                //we are now incrementing it by 1 because we did the previous opperations for drawing rects in two loops with twice the defenition.
                //it was decremented twice before because we didn't have twice the length to work with when working vertical
                currentColor--;
                byte colorTheyWant = (byte)currentColor;
                //need to cast the int back into byte
                return colorTheyWant;
            }
            else
            {
                //we now have to cast it back to a byte since we did nothing
                return colorPassedToUs;
            }

        }

        //When the user clicks this button it saves the color to the prevew and saves changes
        private void OnClick_SaveToTopTitle(object sender, RoutedEventArgs e)
        {
            //we instantiate our color backgroundpicker to save our values
            ColorTintShadeManagement colorBackGroundPicker = new ColorTintShadeManagement();

            //create a myColorSave to save the color too
            SolidColorBrush myColorToSave = new SolidColorBrush();

            //get the color from the topTitleRect and assign to background
            TopTitleStackPanel.Background = TopTitle.Fill;

            //Recast the color we are saving to the solidcolorbrush
            myColorToSave = (SolidColorBrush)TopTitle.Fill;

            //we now get each color from myColorToSave.Color.A Red Green Blue
            //and pass it to the colorpicker that we want to save to.
            colorBackGroundPicker.SetToColorSave(myColorToSave.Color.A, myColorToSave.Color.R, myColorToSave.Color.G, myColorToSave.Color.B, "TopWindowTitle");
        }

        //When the user clicks this button it saves the color to the prevew and saves changes
        private void OnClick_SaveToSecondaryBackground(object sender, RoutedEventArgs e)
        {
            //we instantiate our color backgroundpicker to save our values
            ColorTintShadeManagement colorBackGroundPicker = new ColorTintShadeManagement();

            //create a myColorSave to save the color too
            SolidColorBrush myColorToSave = new SolidColorBrush();

            //get the color from the Secondarycolor.fill and assign to background
            SecondTitleStackPanel.Background = SecondaryColor.Fill;

            //Recast the color we are saving to the solidcolorbrush
            myColorToSave = (SolidColorBrush)SecondaryColor.Fill;

            //we now get each color from myColorToSave.Color.A Red Green Blue
            //and pass it to the colorpicker that we want to save to.
            colorBackGroundPicker.SetToColorSave(myColorToSave.Color.A, myColorToSave.Color.R, myColorToSave.Color.G, myColorToSave.Color.B, "SecondaryBackGround");
        }

        //When the user clicks this button it saves the color to the prevew and saves changes
        private void OnClick_SaveToTextObject(object sender, RoutedEventArgs e)
        {
            //we instantiate our color backgroundpicker to save our values
            ColorTintShadeManagement colorBackGroundPicker = new ColorTintShadeManagement();

            //create a myColorSave to save the color too
            SolidColorBrush myColorToSave = new SolidColorBrush();

            //get the color from the Secondarycolor.fill and assign to background
            TextObject1.Background = TextObject.Fill;
            TextObject2.Background = TextObject.Fill;

            //Recast the color we are saving to the solidcolorbrush
            myColorToSave = (SolidColorBrush)TextObject.Fill;

            //we now get each color from myColorToSave.Color.A Red Green Blue
            //and pass it to the colorpicker that we want to save to.
            colorBackGroundPicker.SetToColorSave(myColorToSave.Color.A, myColorToSave.Color.R, myColorToSave.Color.G, myColorToSave.Color.B, "TextObject");
        }
    }
}
