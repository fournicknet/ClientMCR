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

namespace ClientMCR
{
    /// <summary>
    /// Interaction logic for ContactSearchPage.xaml
    /// </summary>
    public partial class ContactSearchPage : Page
    {
        //CompanyEntityClass SW_CES;
        Frame frame;
        public ContactSearchPage(Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;

            //SW_CES = CCES;
        }

        private void ClearContactSearch(object sender, RoutedEventArgs e)
        {
            ClearContactEntityFields();
        }

        private void ClearContactEntityFields()
        {
            ContactNameBox.Text = "";
            ContactIDBox.Text = "";
            ContactPhoneNumberBox.Text = "";
            ContactPhoneNumberExtensionBox.Text = "";
            ContacteMailBox.Text = "";
        }

        private void ContactSearch(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void CompanySearch(object sender, RoutedEventArgs e)
        {
            frame.Content = new CompanySearchPage(frame);
        }
    }
}
