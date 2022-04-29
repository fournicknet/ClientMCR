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
    /// Interaction logic for AustraliaCompanyAddress.xaml
    /// </summary>
    public partial class AustraliaCompanyAddress : Page
    {
        AustraliaPostalEntity APE;
        public AustraliaCompanyAddress(AustraliaPostalEntity preAPE)
        {
            InitializeComponent();

            APE = preAPE;
        }

        private void AddressLine1Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            APE.SetAddressLine1(AddressLine1Box.Text);
        }
    }
}
