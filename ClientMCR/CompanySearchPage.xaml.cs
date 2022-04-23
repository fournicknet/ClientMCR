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
        LineSelectButton BM_button;
        Frame frame;

        List<CompanySearchListData> returnedCompanies;
        string rowValueString = "null";
        int companyCount = 0;
        List<LineSelectButton> LineSelectButtons = new List<LineSelectButton>();
        Brush defaultBackground;

        public CompanySearchPage(CompanyEntityClass CCES, Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;

            SW_CES = CCES;
            CompanyIDBox.Text = "Not Required";

            
            Button btnDefault = new Button();
            //defaultBackground = btnDefault.Background;
            defaultBackground = Brushes.LightSkyBlue;
            //defaultBackground = btnDefault.Background;


        }
        public CompanySearchPage(Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;
            CompanyEntityClass CCES = new CompanyEntityClass();
            SW_CES = CCES;
            CompanyIDBox.Text = "Not Required";

            Button btnDefault = new Button();
            //defaultBackground = btnDefault.Background;
            defaultBackground = Brushes.LightSkyBlue;
            
            //defaultBackground = btnDefault.Background;

        }

        //private bool IsRemovable(LineSelectButton BM_button)
        //{
        //    if(BM_button != null)
        //    {
        //        return BM_button.Name.StartsWith("button");
        //    }
            
        //}

        private void CompanySearch(object sender, RoutedEventArgs e)
        {

            ClearSearchResults();
            //sudo code * if search results return nothing Do this
            

            if (SW_CES != null)
            {

                SW_CES.SetCompanyNameField(CompanyNameBox.Text);
            }
            returnedCompanies = CompanyEntityRecordSearch.ComEntRecSea(CompanyNameBox.Text, CompanyIDBox.Text, CompanyPhoneNumberBox.Text, CompanyeMailBox.Text);

            //the returnedCompanies is a list of companies found in the search returned to us
            //we are going through each company returned to us and making a row and a button and adding it.
            foreach (CompanySearchListData company in returnedCompanies)
            {
                
                companyCount++;
                //rowValueString = "row" + companyCount.ToString();

                AddRowDefinitionToSearchWindowGrid();

                AddModifiedButtonToSearchWindowGrid_CompanyName(company);

                AddModifiedButtonToSearchWindowGrid_CompanyID(company);

                AddModifiedButtonToSearchWindowGrid_CompanyPhone(company);

                AddModifiedButtonToSearchWindowGrid_CompanyeMail(company);


            }
            

            //commented out since the form is not ready, probibly won't use this code since we are listing results int mainwindow anyway
            //CompanyCustomerSearchResults newForm = new CompanyCustomerSearchResults(); //create your new form.
            //newForm.Show(); //show the new form.
            //this.Close();
        }

        private void AddRowDefinitionToSearchWindowGrid()
        {
            var height = GridLength.Auto;
            height = new GridLength(1, GridUnitType.Star);
            SearchWindowGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = height
            });
        }
        private void AddModifiedButtonToSearchWindowGrid_CompanyName(CompanySearchListData company)
        {
            LineSelectButton btn1 = new LineSelectButton();
            btn1.Content = company.GetCompanyNameField();
            btn1.Name = "buttonResult";
            btn1.BorderThickness = new Thickness(0);
            btn1.SetCompanyEntityIDField(company.GetEntityIDField());
            btn1.SetValue(Grid.RowProperty, companyCount);
            btn1.SetRowSpread(companyCount);
            btn1.SetValue(Grid.ColumnProperty, 0);
            btn1.SetColumnSpread(0);
            //the following code below is a lambda expression
            btn1.Click += (source, e) =>
            {
                CompanyEntityRecordRetrieve comEntRecRet = new CompanyEntityRecordRetrieve();
                SW_CES = comEntRecRet.ComEntRecRet(btn1.GetEntityIDField());

                frame.Content = new ContactSearchByCompanyPage(SW_CES, frame);

            };
            btn1.MouseEnter += (source, e) =>
            {
                foreach(LineSelectButton btn in LineSelectButtons)
                {
                    //if(btn.GetValue(Grid.RowProperty) == btn1.GetValue(Grid.RowProperty))
                    if(btn1.GetRowSpread() == btn.GetRowSpread())
                    {

                        btn.Background = new SolidColorBrush(Color.FromArgb(255, 190, 230, 253));
                        //BackgoundColor bgc = new BackgoundColor();
                        //btn.Background = bgc.buttonDefaultColor();

                        //btn.Background = System.Windows.Media.Brushes.Aqua;

                        //defaultBackground
                    }
                }
            };
            btn1.MouseLeave += (source, e) =>
            {
                foreach (LineSelectButton btn in LineSelectButtons)
                {
                    if (btn.GetValue(Grid.RowProperty) == btn1.GetValue(Grid.RowProperty))
                    {

                        //btn.Background = defaultBackground;

                        BackgoundColor bgc = new BackgoundColor();
                        btn.Background = bgc.buttonDefaultColor();

                        //btn.Background = System.Windows.Media.Brushes.Aqua;
                    }
                }
            };
            LineSelectButtons.Add(btn1);

            SearchWindowGrid.Children.Add(btn1);
            BM_button = btn1;
        }

        private void AddModifiedButtonToSearchWindowGrid_CompanyID(CompanySearchListData company)
        {
            LineSelectButton btn1 = new LineSelectButton();
            btn1.Content = company.GetCompanyIDField();
            btn1.Name = "buttonResult";
            btn1.BorderThickness = new Thickness(0);
            btn1.SetCompanyEntityIDField(company.GetEntityIDField());
            btn1.SetValue(Grid.RowProperty, companyCount);
            btn1.SetRowSpread(companyCount);
            btn1.SetValue(Grid.ColumnProperty, 1);
            btn1.SetColumnSpread(1);
            //the following code below is a lambda expression
            btn1.Click += (source, e) =>
            {
                CompanyEntityRecordRetrieve comEntRecRet = new CompanyEntityRecordRetrieve();
                SW_CES = comEntRecRet.ComEntRecRet(btn1.GetEntityIDField());

                frame.Content = new ContactSearchByCompanyPage(SW_CES, frame);

            };
            LineSelectButtons.Add(btn1);

            SearchWindowGrid.Children.Add(btn1);
            BM_button = btn1;
        }

        private void AddModifiedButtonToSearchWindowGrid_CompanyPhone(CompanySearchListData company)
        {
            LineSelectButton btn1 = new LineSelectButton();
            btn1.Content = company.GetCompanyPhoneNumberField();
            btn1.Name = "buttonResult";
            btn1.BorderThickness = new Thickness(0);
            btn1.SetCompanyEntityIDField(company.GetEntityIDField());
            btn1.SetValue(Grid.RowProperty, companyCount);
            btn1.SetRowSpread(companyCount);
            btn1.SetValue(Grid.ColumnProperty, 2);
            btn1.SetColumnSpread(2);
            //the following code below is a lambda expression
            btn1.Click += (source, e) =>
            {
                CompanyEntityRecordRetrieve comEntRecRet = new CompanyEntityRecordRetrieve();
                SW_CES = comEntRecRet.ComEntRecRet(btn1.GetEntityIDField());

                frame.Content = new ContactSearchByCompanyPage(SW_CES, frame);

            };
            
            LineSelectButtons.Add(btn1);

            SearchWindowGrid.Children.Add(btn1);
            BM_button = btn1;
        }

        private void AddModifiedButtonToSearchWindowGrid_CompanyeMail(CompanySearchListData company)
        {
            LineSelectButton btn1 = new LineSelectButton();
            btn1.Content = company.GeteMailAddress();
            btn1.Name = "buttonResult";
            btn1.BorderThickness = new Thickness(0);
            btn1.SetCompanyEntityIDField(company.GetEntityIDField());
            btn1.SetValue(Grid.RowProperty, companyCount);
            btn1.SetRowSpread(companyCount);
            btn1.SetValue(Grid.ColumnProperty, 3);
            btn1.SetColumnSpread(3);
            //the following code below is a lambda expression
            btn1.Click += (source, e) =>
            {
                CompanyEntityRecordRetrieve comEntRecRet = new CompanyEntityRecordRetrieve();
                SW_CES = comEntRecRet.ComEntRecRet(btn1.GetEntityIDField());

                frame.Content = new ContactSearchByCompanyPage(SW_CES, frame);

            };
            LineSelectButtons.Add(btn1);
            SearchWindowGrid.Children.Add(btn1);
            BM_button = btn1;
        }

        private void ClearCompanySearch(object sender, RoutedEventArgs e)
        {
            ClearCompanyEntityFields();
            ClearSearchResults();
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
            SW_CES.SetAddCompanyEntity(true);
            //AddCompanyEntityPage newAddCompanyEntityForm = new AddCompanyEntityPage(SW_CES); //create your new form.
            //newAddCompanyEntityForm.Show(); //show the new form.
            frame.Content = new AddCompanyEntityPage(SW_CES, frame); //Content = new 
            //this.Close();
        }

        private void SearchContact(object sender, RoutedEventArgs e)
        {
            frame.Content = new ContactSearchPage(frame);
        }

        private void ClearSearchResults()
        {
           int numberofObjectsCount = SearchWindowGrid.Children.Count;
            for (int i = 0; i <= numberofObjectsCount; ++i)
            {
                SearchWindowGrid.Children.Remove(BM_button);
                
                //SearchWindowGrid.RowDefinitions.Remove(i);
            }
            foreach(LineSelectButton LSB in LineSelectButtons)
            {
                LineSelectButtons.RemoveAt(0);
            }
            
        }

        
    }

        //We should format for everybody or not at all - because it might force formatting for somebody who does not need it
        //private void CompanyPhoneNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    CompanyPhoneNumberBox.Text = PhoneNumberFormatter.PhoneNumberFormatter(CompanyPhoneNumberBox.Text);
        //}
    
}

