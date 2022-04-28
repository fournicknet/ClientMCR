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

namespace ClientMCR.CountryFormatAddress
{
    /// <summary>
    /// Interaction logic for USCompanyAddress.xaml
    /// </summary>
    public partial class USCompanyAddress : Page
    {
        DataTemplate countryListDataTemplate { get; set; }
        Grid countryListBoxGrid { get; set; }
        DataTemplate DT = new DataTemplate();
        public USCompanyAddress()
        {
            InitializeComponent();

            
            //CompanyAddressGrid
            CustomListBoxControl countryListBox = new CustomListBoxControl();
            countryListBox.Name = "countriesListBox";
            countryListBox.SetValue(Grid.RowProperty, 7);
            countryListBox.SetValue(Grid.ColumnProperty, 0);
            countryListBox.SelectionMode = SelectionMode.Single;
            countryListBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            countryListBox.SelectionChanged += OnSelectionChangedCountryListBox;
            countryListBox.ItemTemplate = DT;

            TextBlock textBlock = new TextBlock();
            textBlock.SetBinding(TextBlock.TextProperty, new Binding("countryName"));
            
            //countryListBoxGrid.Children.Add(textBlock);
            
            StackPanel sp = new StackPanel { 
                Orientation = System.Windows.Controls.Orientation.Vertical 
            };

            sp.Children.Add(textBlock);

            countryListDataTemplate = DT;
            countryListDataTemplate.Resources.Add(sp, null);
                
                //= countryListBoxGrid;



            //countryListBox.ItemsSource = countries;
            CompanyAddressGrid.Children.Add(countryListBox);

            
            
        }

        private static void OnSelectionChangedCountryListBox(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
