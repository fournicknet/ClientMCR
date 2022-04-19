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


            //// Not developed yet.
            //throw new NotImplementedException();

            //if (SW_CES != null)
            //{

            //    SW_CES.SetCompanyNameField(CompanyNameBox.Text);

            //    returnedCompanies = CompanyEntityRecordSearch.ComEntRecSea(CompanyNameBox.Text, CompanyIDBox.Text, CompanyPhoneNumberBox.Text, CompanyeMailBox.Text);

            //    int companyCount = 0;


            //    //the returnedCompanies is a list of companies found in the search returned to us
            //    //we are going through each company returned to us and making a row and a button and adding it.
            //    foreach (CompanySearchListData company in returnedCompanies)
            //    {

            //        companyCount++;
            //        rowValueString = "row" + companyCount.ToString();
            //        var height = GridLength.Auto;
            //        height = new GridLength(1, GridUnitType.Star);
            //        SearchWindowGrid.RowDefinitions.Add(new RowDefinition()
            //        {
            //            Height = height
            //        });

            //        ButtonModified btn1 = new ButtonModified();
            //        btn1.Content = company.GetCompanyNameField();
            //        btn1.SetEntityIDField(company.GetEntityIDField());
            //        btn1.SetValue(Grid.RowProperty, companyCount);
            //        btn1.SetValue(Grid.ColumnProperty, 0);
            //        //the following code below is a lambda expression
            //        btn1.Click += (source, e) =>
            //        {
            //            CompanyEntityRecordRetrieve comEntRecRet = new CompanyEntityRecordRetrieve();
            //            SW_CES = comEntRecRet.ComEntRecRet(btn1.GetEntityIDField());

            //            frame.Content = new ContactSearchByCompanyPage(SW_CES, frame);

            //        };
            //        SearchWindowGrid.Children.Add(btn1);
            //    }
            //}
        }

        private void CompanySearch(object sender, RoutedEventArgs e)
        {
            frame.Content = new CompanySearchPage(frame);
        }
    }
}
