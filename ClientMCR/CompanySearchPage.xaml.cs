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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class CompanySearchPage : Page
    {
        //CompanyEntityClass SW_CES = null;
        CompanyEntityClass SW_CES;
        Frame frame;

        List<CompanySearchListData> returnedCompanies;
        string rowValueString = "null";

        public CompanySearchPage(CompanyEntityClass CCES, Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;

            SW_CES = CCES;
            CompanyIDBox.Text = "Not Required";
        }
        public CompanySearchPage(Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;
            CompanyEntityClass CCES = new CompanyEntityClass();
            SW_CES = CCES;
            CompanyIDBox.Text = "Not Required";
        }

        private void CompanySearch(object sender, RoutedEventArgs e)
        {
            //sudo code * if search results return nothing Do this

            if (SW_CES != null)
            {

                SW_CES.SetCompanyNameField(CompanyNameBox.Text);

                returnedCompanies = CompanyEntityRecordSearch.ComEntRecSea(CompanyNameBox.Text, CompanyIDBox.Text, CompanyPhoneNumberBox.Text, CompanyeMailBox.Text);

                int companyCount = 0;

                
                
                foreach (CompanySearchListData company in returnedCompanies)
                {

                    companyCount++;
                    rowValueString = "row" + companyCount.ToString();
                    var height = GridLength.Auto;
                        height = new GridLength(1, GridUnitType.Star);
                    SearchWindowGrid.RowDefinitions.Add(new RowDefinition()
                        {
                            Height = height
                    });

                    Button btn1 = new Button();
                    btn1.Content = company.GetCompanyNameField();
                    btn1.SetValue(Grid.RowProperty, companyCount);
                    btn1.SetValue(Grid.ColumnProperty, 0);
                    SearchWindowGrid.Children.Add(btn1);
                    

                    
                }
            }

            //commented out since the form is not ready, probibly won't use this code since we are listing results int mainwindow anyway
            //CompanyCustomerSearchResults newForm = new CompanyCustomerSearchResults(); //create your new form.
            //newForm.Show(); //show the new form.
            //this.Close();
        }



        private void ClearCompanySearch(object sender, RoutedEventArgs e)
        {
            ClearCompanyEntityFields();
        }

        private void ClearCompanyEntityFields()
        {
            CompanyNameBox.Text = "";
            CompanyIDBox.Text = "";
            CompanyPhoneNumberBox.Text = "";
            CompanyPhoneExtensionBox.Text = "";
            CompanyeMailBox.Text = "";
            
        }

        private void AddCompanyEntityButton(object sender, RoutedEventArgs e)
        {

            SW_CES.SetCompanyNameField(CompanyNameBox.Text);
            SW_CES.SetCompanyIDField(CompanyIDBox.Text);
            SW_CES.SetCompanyPhoneNumberField(CompanyPhoneNumberBox.Text);
            SW_CES.SetCompanyPhoneExtension(CompanyPhoneExtensionBox.Text);
            SW_CES.SeteMailAddress(CompanyeMailBox.Text);

            //AddCompanyEntityPage newAddCompanyEntityForm = new AddCompanyEntityPage(SW_CES); //create your new form.
            //newAddCompanyEntityForm.Show(); //show the new form.
            frame.Content = new AddCompanyEntityPage(SW_CES, frame); //Content = new 
            //this.Close();
        }

        private void SearchContact(object sender, RoutedEventArgs e)
        {
            frame.Content = new ContactSearchPage(frame);
        }

        //We should format for everybody or not at all - because it might force formatting for somebody who does not need it
        //private void CompanyPhoneNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    CompanyPhoneNumberBox.Text = PhoneNumberFormatter.PhoneNumberFormatter(CompanyPhoneNumberBox.Text);
        //}
    }
}

