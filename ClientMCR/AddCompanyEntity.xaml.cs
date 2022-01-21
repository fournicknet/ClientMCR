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
    /// Interaction logic for AddCompanyEntity.xaml
    /// </summary>
    public partial class AddCompanyEntity : Window
    {
        public AddCompanyEntity()
        {
            InitializeComponent();
        }

        private void SearchWindowButton(object sender, RoutedEventArgs e)
        {
            SearchWindow sw = new SearchWindow(); //create your new form.
            sw.Show(); //show the new form.
            this.Close();
        }

        private void SaveCompanyEntityButton(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();

        }

        private void ClearCompanyEntityButton(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void AddCompanyEntityButton(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }
    }
}
