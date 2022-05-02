using ClientMCR.AddressObjects;
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

namespace ClientMCR.CountriesPage
{
    /// <summary>
    /// Interaction logic for CountryCompanyAddress.xaml
    /// </summary>
    public partial class CountryCompanyAddress : Page
    {
        CountryPostalEntity CPE;

        List<object> textBoxsAndTextBlocks;
        public CountryCompanyAddress(CountryPostalEntity preCPE)
        {
            InitializeComponent();

            CPE = preCPE;

            FindOutCountry(CPE);

            List<Object> myObjectListToTrackControls = new List<Object>();

            textBoxsAndTextBlocks = myObjectListToTrackControls;
        }

        public void FindOutCountry(CountryPostalEntity preFOCCPE)
        {
            string countryResult = preFOCCPE.GetStateTerritoryProvinceLocalityDeliveryOffice_Selector();

            if (countryResult != null)
            {
                if(countryResult == "Australia")
                {
                    ClearControls();
                    StandardAddressLines();
                    AddSpace();
                    AddAddressLocalityorDeliveryOffice();
                    AddAddressStateorTerritory();
                    AddAddressPostalorZip();
                }

                else if(countryResult == "Canada")
                {
                    ClearControls();
                    StandardAddressLines();
                    AddSpace();
                    AddAddressCity();
                    AddAddressProvinceorTerritory();
                    AddAddressPostalorZip();
                }

                else if (countryResult == "United States of America")
                {
                    ClearControls();
                    StandardAddressLines();
                    AddSpace();
                    AddAddressCity();
                    AddAddressStateorTerritory();
                    AddAddressPostalorZip();
                }

            }
            
        }

        private void ClearControls()
        {
            if(textBoxsAndTextBlocks != null)
            {
                for (int i = 0; i < textBoxsAndTextBlocks.Count; i++)
                {
                    CompanyAddressGrid.Children.RemoveAt(0);
                }
            }
        }

        private void StandardAddressLines()
        {
            AddAddressLine(0);
            AddAddressLine(1);
            AddAddressLine(2);
            AddAddressLine(3);
            
        }

        private void AddAddressLine(int i)
        {
            int count = i+1;
            string intString = count.ToString();
            //string TextBlockAddressLine = "TextBlockAddressLine" + intString;
            //AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressLine1 = new TextBlock();
            TextBloAddressLine1.Text = "Address Line " + intString;
            TextBloAddressLine1.Name = "TextBlockAddressLine" + intString;
            TextBloAddressLine1.SetValue(Grid.RowProperty, i);
            TextBloAddressLine1.SetValue(Grid.ColumnProperty, 0);
            
            TextBloAddressLine1.Background = new SolidColorBrush(Colors.White);

            CompanyAddressGrid.Children.Add(TextBloAddressLine1);

            TextBox TextBoxAddressLine1 = new TextBox();
            TextBoxAddressLine1.Name = "TextBloxAddressLine" + intString;
            TextBoxAddressLine1.Text = "";
            TextBoxAddressLine1.SetValue(Grid.RowProperty, i);
            TextBoxAddressLine1.SetValue(Grid.ColumnProperty, 1);

            
            CompanyAddressGrid.Children.Add(TextBoxAddressLine1);
        }

        private void AddSpace()
        {
            AddRowDefinitionToCompanyAddressGrid();
        }

        private void AddAddressCity()
        {
            //AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressCity = new TextBlock();
            TextBloAddressCity.Text = "City";
            TextBloAddressCity.Name = "TextBloAddressCityLine";
            TextBloAddressCity.SetValue(Grid.RowProperty, 5);
            TextBloAddressCity.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressCity);

            TextBox TextBoxAddressCity = new TextBox();
            TextBoxAddressCity.Name = "TextBoxAddressCityLine";
            TextBoxAddressCity.Text = "";
            TextBoxAddressCity.SetValue(Grid.RowProperty, 5);
            TextBoxAddressCity.SetValue(Grid.ColumnProperty, 1);

            
            CompanyAddressGrid.Children.Add(TextBoxAddressCity);
        }
        private void AddAddressLocalityorDeliveryOffice()
        {
            //AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressLocalityorDeliveryOffice = new TextBlock();
            TextBloAddressLocalityorDeliveryOffice.Text = "Locality or DeliveryOffice";
            TextBloAddressLocalityorDeliveryOffice.Name = "TextBloAddressLocalityorDeliveryOfficeLine";
            TextBloAddressLocalityorDeliveryOffice.SetValue(Grid.RowProperty, 6);
            TextBloAddressLocalityorDeliveryOffice.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressLocalityorDeliveryOffice);

            TextBox TextBoxAddressLocalityorDeliveryOffice = new TextBox();
            TextBoxAddressLocalityorDeliveryOffice.Name = "TextBoxAddressLocalityorDeliveryOfficeLine";
            TextBoxAddressLocalityorDeliveryOffice.Text = "";
            TextBoxAddressLocalityorDeliveryOffice.SetValue(Grid.RowProperty, 6);
            TextBoxAddressLocalityorDeliveryOffice.SetValue(Grid.ColumnProperty, 1);

            CompanyAddressGrid.Children.Add(TextBoxAddressLocalityorDeliveryOffice);
        }

        private void AddAddressProvinceorTerritory()
        {
            //AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressProvinceorTerritory = new TextBlock();
            TextBloAddressProvinceorTerritory.Text = "Province or Territory";
            TextBloAddressProvinceorTerritory.Name = "TextBloAddressProvinceorTerritoryLine";
            TextBloAddressProvinceorTerritory.SetValue(Grid.RowProperty, 6);
            TextBloAddressProvinceorTerritory.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressProvinceorTerritory);

            TextBox TextBoxAddressStateorTerritory = new TextBox();
            TextBoxAddressStateorTerritory.Name = "TextBoxAddressStateorTerritoryLine";
            TextBoxAddressStateorTerritory.Text = "";
            TextBoxAddressStateorTerritory.SetValue(Grid.RowProperty, 6);
            TextBoxAddressStateorTerritory.SetValue(Grid.ColumnProperty, 1);
                        
            CompanyAddressGrid.Children.Add(TextBoxAddressStateorTerritory);
        }
        private void AddAddressStateorTerritory()
        {
            //AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressStateorTerritory = new TextBlock();
            TextBloAddressStateorTerritory.Text = "State or Territory";
            TextBloAddressStateorTerritory.Name = "TextBloAddressStateorTerritoryLine";
            TextBloAddressStateorTerritory.SetValue(Grid.RowProperty, 6);
            TextBloAddressStateorTerritory.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressStateorTerritory);

            TextBox TextBoxAddressStateorTerritory = new TextBox();
            TextBoxAddressStateorTerritory.Name = "TextBoxAddressStateorTerritoryLine";
            TextBoxAddressStateorTerritory.Text = "";
            TextBoxAddressStateorTerritory.SetValue(Grid.RowProperty, 6);
            TextBoxAddressStateorTerritory.SetValue(Grid.ColumnProperty, 1);

            CompanyAddressGrid.Children.Add(TextBoxAddressStateorTerritory);
        }

        private void AddAddressPostalorZip()
        {
            //AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressPostalorZip = new TextBlock();
            TextBloAddressPostalorZip.Text = "Postal or Zip Code";
            TextBloAddressPostalorZip.Name = "TextBloAddressPostalorZipLine";
            TextBloAddressPostalorZip.SetValue(Grid.RowProperty, 7);
            TextBloAddressPostalorZip.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressPostalorZip);

            TextBox TextBoxAddressPostalorZip = new TextBox();
            TextBoxAddressPostalorZip.Name = "TextBoxAddressCityLine";
            TextBoxAddressPostalorZip.Text = "";
            TextBoxAddressPostalorZip.SetValue(Grid.RowProperty, 7);
            TextBoxAddressPostalorZip.SetValue(Grid.ColumnProperty, 1);

            CompanyAddressGrid.Children.Add(TextBoxAddressPostalorZip);
        }


        private void AddRowDefinitionToCompanyAddressGrid()
        {
            var height = GridLength.Auto;
            height = new GridLength(1, GridUnitType.Star);
            CompanyAddressGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = height
            });
        }

        private void RemoveRowDefinitionToCompanyAddressGrid()
        {
            var height = GridLength.Auto;
            height = new GridLength(1, GridUnitType.Star);
            CompanyAddressGrid.RowDefinitions.Remove(new RowDefinition()
            {
                Height = height
            });
        }
    }
}
