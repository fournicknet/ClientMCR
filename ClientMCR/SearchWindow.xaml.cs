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
using System.Windows.Shapes;

namespace ClientMCR
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {

        //CompanyEntityClass SW_CES = null;
        CompanyEntityClass SW_CES;
        public SearchWindow(CompanyEntityClass CCES)
        {
            InitializeComponent();
            
            SW_CES = CCES;
            CompanyIDBox.Text = "Not Required";
        }

        private void CompanyCustomerSearch(object sender, RoutedEventArgs e)
        {
            //sudo code * if search results return nothing Do this

            if (SW_CES != null)
            {
                SW_CES.SetCompanyNameField(CompanyNameBox.Text);
            }

            //commented out since the form is not ready, probibly won't use this code since we are listing results int mainwindow anyway
            //CompanyCustomerSearchResults newForm = new CompanyCustomerSearchResults(); //create your new form.
            //newForm.Show(); //show the new form.
            //this.Close();
        }



        private void ClearCompanyCustomerSearch(object sender, RoutedEventArgs e)
        {

        }

        private void AddCompanyEntityButton(object sender, RoutedEventArgs e)
        {




            SW_CES.SetCompanyNameField(CompanyNameBox.Text);
            SW_CES.SetCompanyIDField(CompanyIDBox.Text);
            SW_CES.SetCompanyPhoneNumberField(CompanyPhoneNumberBox.Text);
            SW_CES.SeteMailAddress(CompanyeMailBox.Text);

            AddCompanyEntity newAddCompanyEntityForm = new AddCompanyEntity(SW_CES); //create your new form.
            newAddCompanyEntityForm.Show(); //show the new form.
            this.Close();
        }
    }
}
