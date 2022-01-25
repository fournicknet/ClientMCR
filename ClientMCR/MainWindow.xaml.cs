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

            CompanyEntityClass CEC = new CompanyEntityClass();
            CEC.SetCompanyNameField("Instanciated");
            //    public WindowStartupLocation WindowStartupLocation 
            //{ 
            //    get; 
            //    set; 
            //}
            
            //getting off the main window into our Search Window i'm doing it because i'm experimenting
            SearchWindow sw = new SearchWindow(CEC); //create your new form.
            sw.Show(); //show the new form.
            this.Close();
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
