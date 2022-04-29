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
        public CountryCompanyAddress(CountryPostalEntity preCPE)
        {
            InitializeComponent();

            CPE = preCPE;

            FindOutCountry(CPE);
        }

        public void FindOutCountry(CountryPostalEntity preFOCCPE)
        {
            string countryResult = preFOCCPE.GetAddressLocalityorDeliveryOffice();

            if (countryResult != null)
            {
                if(countryResult == "Australia")
                {
                    StandardAddressLines();
                    AddSpace();
                    AddAddressLocalityorDeliveryOffice();
                    AddAddressStateorTerritory();
                    AddAddressPostalorZip();
                }

                else if(countryResult == "Canada")
                {
                    StandardAddressLines();
                    AddSpace();
                    AddAddressCity();
                    AddAddressProvinceorTerritory();
                    AddAddressPostalorZip();
                }

                else if (countryResult == "United States of America")
                {
                    StandardAddressLines();
                    AddSpace();
                    AddAddressCity();
                    AddAddressStateorTerritory();
                    AddAddressPostalorZip();
                }

            }
            
        }

        private void StandardAddressLines()
        {
            AddAddressLine(0);
            AddAddressLine(1);
            AddAddressLine(2);
            AddAddressLine(3);
            
            AddAddressCity();

            
        }

        private void AddAddressLine(int i)
        {
            int count = i+1;
            string intString = count.ToString();
            //string TextBlockAddressLine = "TextBlockAddressLine" + intString;
            AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressLine1 = new TextBlock();
            TextBloAddressLine1.Text = "Address Line " + intString;
            TextBloAddressLine1.Name = "TextBlockAddressLine" + intString;
            TextBloAddressLine1.SetValue(Grid.RowProperty, i);
            TextBloAddressLine1.SetValue(Grid.ColumnProperty, 0);

            TextBox TextBoxAddressLine1 = new TextBox();
            TextBoxAddressLine1.Name = "TextBloxAddressLine" + intString;
            TextBloAddressLine1.SetValue(Grid.RowProperty, i);
            TextBloAddressLine1.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressLine1);
            CompanyAddressGrid.Children.Add(TextBoxAddressLine1);
        }

        private void AddSpace()
        {
            AddRowDefinitionToCompanyAddressGrid();
        }

        private void AddAddressCity()
        {
            AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressCity = new TextBlock();
            TextBloAddressCity.Text = "City";
            TextBloAddressCity.Name = "TextBloAddressCityLine";
            TextBloAddressCity.SetValue(Grid.RowProperty, 5);
            TextBloAddressCity.SetValue(Grid.ColumnProperty, 0);

            TextBox TextBoxAddressCity = new TextBox();
            TextBoxAddressCity.Name = "TextBoxAddressCityLine";
            TextBoxAddressCity.SetValue(Grid.RowProperty, 5);
            TextBoxAddressCity.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressCity);
            CompanyAddressGrid.Children.Add(TextBoxAddressCity);
        }
        private void AddAddressLocalityorDeliveryOffice()
        {
            AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressLocalityorDeliveryOffice = new TextBlock();
            TextBloAddressLocalityorDeliveryOffice.Text = "Locality or DeliveryOffice";
            TextBloAddressLocalityorDeliveryOffice.Name = "TextBloAddressLocalityorDeliveryOfficeLine";
            TextBloAddressLocalityorDeliveryOffice.SetValue(Grid.RowProperty, 5);
            TextBloAddressLocalityorDeliveryOffice.SetValue(Grid.ColumnProperty, 0);

            TextBox TextBoxAddressLocalityorDeliveryOffice = new TextBox();
            TextBoxAddressLocalityorDeliveryOffice.Name = "TextBoxAddressLocalityorDeliveryOfficeLine";
            TextBoxAddressLocalityorDeliveryOffice.SetValue(Grid.RowProperty, 5);
            TextBoxAddressLocalityorDeliveryOffice.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressLocalityorDeliveryOffice);
            CompanyAddressGrid.Children.Add(TextBoxAddressLocalityorDeliveryOffice);
        }

        private void AddAddressProvinceorTerritory()
        {
            AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressProvinceorTerritory = new TextBlock();
            TextBloAddressProvinceorTerritory.Text = "Province or Territory";
            TextBloAddressProvinceorTerritory.Name = "TextBloAddressProvinceorTerritoryLine";
            TextBloAddressProvinceorTerritory.SetValue(Grid.RowProperty, 5);
            TextBloAddressProvinceorTerritory.SetValue(Grid.ColumnProperty, 0);

            TextBox TextBoxAddressStateorTerritory = new TextBox();
            TextBoxAddressStateorTerritory.Name = "TextBoxAddressStateorTerritoryLine";
            TextBoxAddressStateorTerritory.SetValue(Grid.RowProperty, 5);
            TextBoxAddressStateorTerritory.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressProvinceorTerritory);
            CompanyAddressGrid.Children.Add(TextBoxAddressStateorTerritory);
        }
        private void AddAddressStateorTerritory()
        {
            AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressStateorTerritory = new TextBlock();
            TextBloAddressStateorTerritory.Text = "State or Territory";
            TextBloAddressStateorTerritory.Name = "TextBloAddressStateorTerritoryLine";
            TextBloAddressStateorTerritory.SetValue(Grid.RowProperty, 5);
            TextBloAddressStateorTerritory.SetValue(Grid.ColumnProperty, 0);

            TextBox TextBoxAddressStateorTerritory = new TextBox();
            TextBoxAddressStateorTerritory.Name = "TextBoxAddressStateorTerritoryLine";
            TextBoxAddressStateorTerritory.SetValue(Grid.RowProperty, 5);
            TextBoxAddressStateorTerritory.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressStateorTerritory);
            CompanyAddressGrid.Children.Add(TextBoxAddressStateorTerritory);
        }

        private void AddAddressPostalorZip()
        {
            AddRowDefinitionToCompanyAddressGrid();
            TextBlock TextBloAddressPostalorZip = new TextBlock();
            TextBloAddressPostalorZip.Text = "Postal or Zip Code";
            TextBloAddressPostalorZip.Name = "TextBloAddressPostalorZipLine";
            TextBloAddressPostalorZip.SetValue(Grid.RowProperty, 7);
            TextBloAddressPostalorZip.SetValue(Grid.ColumnProperty, 0);

            TextBox TextBoxAddressPostalorZip = new TextBox();
            TextBoxAddressPostalorZip.Name = "TextBoxAddressCityLine";
            TextBoxAddressPostalorZip.SetValue(Grid.RowProperty, 7);
            TextBoxAddressPostalorZip.SetValue(Grid.ColumnProperty, 0);

            CompanyAddressGrid.Children.Add(TextBloAddressPostalorZip);
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

        private void RowDefinitionToCompanyAddressGrid()
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
