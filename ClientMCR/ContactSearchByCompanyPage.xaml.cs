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
    /// Interaction logic for ContactSearchByCompanyPage.xaml
    /// </summary>
    public partial class ContactSearchByCompanyPage : Page
    {
        CompanyEntityClass SW_CES;
        Frame frame;

        List<ContactSearchListData> dataReturned;
        int contactCount = 0;
        string rowValueString;
        public ContactSearchByCompanyPage(CompanyEntityClass CCES, Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;
            SW_CES = CCES;



            CompanyNameBox.Text = SW_CES.GetCompanyNameField();
            CompanyIDBox.Text = SW_CES.GetCompanyIDField();
            CompanyPhoneNumberBox.Text = SW_CES.GetCompanyPhoneNumberField();
            CompanyPhoneExtensionBox.Text = SW_CES.GetCompanyPhoneExtensionField();
            CompanyeMailBox.Text = SW_CES.GeteMailAddress();


            LoadGridWithContacts(SW_CES.GetCompanyEntityIDField());
        }

        public void LoadGridWithContacts(int CompanyEntityID)
        {
            dataReturned = ContactEntityRecordRetrieve.ConEntRecSea(CompanyEntityID);

            foreach (ContactSearchListData contact in dataReturned)
            {

                contactCount++;
                //rowValueString = "row" + contactCount.ToString();
                var height = GridLength.Auto;
                height = new GridLength(1, GridUnitType.Star);
                SearchWindowGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = height
                });

                ButtonModified btn1 = new ButtonModified();
                btn1.Content = contact.GetContactNameField();
                btn1.SetCompanyEntityIDField(contact.GetCompanyEntityIDField());
                btn1.SetContactEntityIDField(contact.GetEntityIDField());
                btn1.SetValue(Grid.RowProperty, contactCount);
                btn1.SetValue(Grid.ColumnProperty, 0);
                //the following code below is a lambda expression
                btn1.Click += (source, e) =>
                {
                    ContactEntityClass conEnt = new ContactEntityClass();
                    conEnt = ContactEntityRecordRetrieve.ConEntRecRet(btn1.GetEntityIDField(), btn1.GetContactEntityIDField());
                    frame.Content = new CaseSearchByContactPage(conEnt, frame);

                };
                SearchWindowGrid.Children.Add(btn1);
            }
        }

        private void AddCompanyEntityButton(object sender, RoutedEventArgs e)
        {
            SW_CES.SetAddCompanyEntity(true);
            frame.Content = new AddCompanyEntityPage(SW_CES, frame);
        }

        private void SearchContact(object sender, RoutedEventArgs e)
        {
            frame.Content = new ContactSearchPage(frame);
        }

        private void AddContactEntityButton(object sender, RoutedEventArgs e)
        {
            frame.Content = new AddContactEntityToCompanyPage(SW_CES, frame);
        }

        private void SearchCompany(object sender, RoutedEventArgs e)
        {
            frame.Content = new CompanySearchPage(SW_CES, frame);
        }

        private void EditCompany(object sender, RoutedEventArgs e)
        {
            //// Not developed yet.
            //throw new NotImplementedException();
            SW_CES.SetEditCompanyEntity(true);
            frame.Content = new AddCompanyEntityPage(SW_CES, frame);
        }
    }
}
