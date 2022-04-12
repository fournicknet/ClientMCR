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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ////The following below is how to create a new xaml page and navigate to it directly
            //CompanyEntityClass CEC = new CompanyEntityClass();
            //CEC.SetCompanyNameField("Instanciated");
            //SearchWindow sw = new SearchWindow(CEC); //create your new form.
            //sw.Show(); //show the new form.
            //this.Close();
            
            CompanyEntityClass CEC = new CompanyEntityClass();
            CEC.SetCompanyNameField("Instanced");
            Main.Content = new CompanySearchPage(CEC, Main);
            //SearchWindow sw = new SearchWindow(CEC);
            //this.Content = sw;

        }

        //private void CompanyCustomerSearch(object sender, RoutedEventArgs e)
        //{

        //    //var newForm = new CompanyCustomerSearchResults(); //create your new form.
        //    //newForm.Show(); //show the new form.
        //    //this.Close(); //only if you want to close the current form.

        //    //NavigationService CCS = NavigationService.GetNavigationService(CompanyCustomerSearch);
        //    //this.Frame.Navigate(typeof(CompanyCustomerSearch));
        //    //NavigationService CCS = new NavigationService(CompanyCustomerSearch);
        //    //Uri uri = new Uri("CompanyCustomerSearch.xaml", UriKind.Relative);
        //    //NavigationService.Navigate(uri);
        //    //CompanyCustomerSearch page = new CompanyCustomerSearch();
        //}
    }
}
