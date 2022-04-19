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
    /// Interaction logic for CaseSearchByContactPage.xaml
    /// </summary>
    public partial class CaseSearchByContactPage : Page
    {
        Frame frame;
        ContactEntityClass contact;
        public CaseSearchByContactPage(ContactEntityClass ConES, Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;

            contact = ConES;

            SetUIFieldsToCompanyEntityInfo();
        }
        private void SetUIFieldsToCompanyEntityInfo()
        {
            ContactNameBox.Text = contact.GetContactNameField();
            ContactIDBox.Text = contact.GetContactIDField();
            ContactPhoneNumberBox.Text = contact.GetContactPhoneNumberField();
            ContactPhoneExtensionBox.Text = contact.GetContactPhoneNumberExtensionField();
            ContacteMailBox.Text = contact.GeteMailAddress();
        }

        private void AddCompanyEntityButton(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void SearchContact(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void EditContact(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void SearchCompany(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void AddContactEntityButton(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void OpenNewTicket(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            //frame.Content = new CompanySearchPage(frame);
            throw new NotImplementedException();
        }
    }
}
