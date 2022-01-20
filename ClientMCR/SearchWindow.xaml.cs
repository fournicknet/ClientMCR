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
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void CompanyCustomerSearch(object sender, RoutedEventArgs e)
        {


            CompanyCustomerSearchResults newForm = new CompanyCustomerSearchResults(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close();
        }
    }
}
