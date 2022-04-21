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
        ContactEntityClass ConES;
        Frame frame;
        List<ContactSearchListData> returnedContacts;
        string rowValueString;

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
            //We are getting the search paramaters provided by the user
            //ContactNameBox.Text;
            //ContactIDBox.Text;
            //ContactPhoneNumberBox.Text;
            //ContactPhoneNumberExtensionBox.Text;
            //ContacteMailBox.Text;

            //WE NEED TO GET A LIST OF CONTACTS THAT MATCH OUR SEARCH SETTINGS

            //if (SW_CES != null)
            //{

            //    SW_CES.SetCompanyNameField(CompanyNameBox.Text);

            returnedContacts = ContactEntityRecordRetrieve.ConEntRecSea(ContactNameBox.Text, ContactIDBox.Text, ContactNameBox.Text, ContactPhoneNumberExtensionBox.Text, ContacteMailBox.Text);
            //We set it to 1 since we are taking into account the title
            int contactCount = 0;
            //the returnedContacts is a list of contacts found in the search returned to us
            //we are going through each contact returned to us and making a row and a button and adding it.
            foreach (ContactSearchListData contact in returnedContacts)
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
                    //ContactEntityRecordRetrieve.ConEntRecSea()
                    //CompanyEntityRecordRetrieve comEntRecRet = new CompanyEntityRecordRetrieve();
                    //SW_CES = comEntRecRet.ComEntRecRet(btn1.GetEntityIDField());
                    ConES = ContactEntityRecordRetrieve.ConEntRecRet(btn1.GetEntityIDField(), btn1.GetContactEntityIDField());
                    frame.Content = new CaseSearchByContactPage(ConES, frame);

                };
                SearchWindowGrid.Children.Add(btn1);
            }
        }

        private void CompanySearch(object sender, RoutedEventArgs e)
        {
            frame.Content = new CompanySearchPage(frame);
        }
    }
}
