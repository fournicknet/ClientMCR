﻿using ClientMCR.ColorSchemes;
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
using ClientMCR.Themes;

namespace ClientMCR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int countByte =0;
        byte[] aByteArray = {0,0,0,0,0};
        public SolidColorBrush defaultbuttonBackground;
        public MainWindow()
        {
            InitializeComponent();

            ////The following below is how to create a new xaml page and navigate to it directly
            //CompanyEntityClass CEC = new CompanyEntityClass();
            //CEC.SetCompanyNameField("Instanciated");
            //SearchWindow sw = new SearchWindow(CEC); //create your new form.
            //sw.Show(); //show the new form.
            //this.Close();
            
            CompanyEntityClass CEC = new CompanyEntityClass();
            CEC.SetCompanyNameField("Instanced");
            Main.Content = new CompanySearchPage(CEC, Main);
            //SearchWindow sw = new SearchWindow(CEC);
            //this.Content = sw;
            //BrushConverter bc = new BrushConverter();
            //Brush brush = (Brush)bc.ConvertFromString(BackgoundColor.GetHexColorKellyGreen());
            //brush.Freeze();
            //MainStackPanel.Background = brush;

            //MainStackPanel.Background = new SolidColorBrush(Color.FromArgb(BackgoundColor.GetHexColorKellyGreen()));
            BackgoundColor backColor = new BackgoundColor();
            List<byte> aByteList = backColor.GetTestColor();
            foreach (byte aByte in aByteList)
            {
                
                aByteArray[countByte] =aByte;
                countByte++;
            }
            countByte = 0;
            //the alpha is in the last two decmal places of the hex value so it goes in the alpha
            Color color = new Color();
            color.A = aByteArray[3];
            color.R = aByteArray[0];
            color.G = aByteArray[1];
            color.B = aByteArray[2];


            List<byte> aMouseByteList = backColor.GetBackgroundButtonDefaultColor();
            foreach (byte aMouseByte in aMouseByteList)
            {

                aByteArray[countByte] = aMouseByte;
                countByte++;
            }
            //the alpha is in the last two decmal places of the hex value so it goes in the alpha
            Color MouseBackcolor = new Color();
            MouseBackcolor.A = aByteArray[3];
            MouseBackcolor.R = aByteArray[0];
            MouseBackcolor.G = aByteArray[1];
            MouseBackcolor.B = aByteArray[2];


            MainStackPanel.Background = new SolidColorBrush(color);

            defaultbuttonBackground = new SolidColorBrush(MouseBackcolor);

            //MainWindow mw = (MainWindow)Application.Current.MainWindow;
            //mw.Background = brush; 
        }

        private void ColorPalette_ButtonClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new ColorTintAdjuster();
        }

        //private void CompanyCustomerSearch(object sender, RoutedEventArgs e)
        //{

        //    //var newForm = new CompanyCustomerSearchResults(); //create your new form.
        //    //newForm.Show(); //show the new form.
        //    //this.Close(); //only if you want to close the current form.

        //    //NavigationService CCS = NavigationService.GetNavigationService(CompanyCustomerSearch);
        //    //this.Frame.Navigate(typeof(CompanyCustomerSearch));
        //    //NavigationService CCS = new NavigationService(CompanyCustomerSearch);
        //    //Uri uri = new Uri("CompanyCustomerSearch.xaml", UriKind.Relative);
        //    //NavigationService.Navigate(uri);
        //    //CompanyCustomerSearch page = new CompanyCustomerSearch();
        //}
    }
}
