using ClientMCR.CountryFormatAddress;
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
    /// Interaction logic for AddCompanyEntityPage.xaml
    /// </summary>
    public partial class AddCompanyEntityPage : Page
    {
        CompanyEntityClass ADE_CCES;

        private int entityID;
        private int maxTextLength = 0;
        private int resultFromEntityRecordCreate;
        bool savedButtonClicked = false;
        Frame frame, frameCountryAddress;
        public AddCompanyEntityPage(CompanyEntityClass CES, Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;
            //CompanyEntityClass ADE_CCES = null;
            //If CompanyEntityClass was not null we are assigning it to ADE_CCES and pulling data from the search window that was passed to us
            //we are creating a company id since we are now on this page
            //we are getting the maxTxtLength for all fields that only require x number of spaces, ie 40
            SetMaxTextLengthForFields();

            ADE_CCES = CES;
            if (ADE_CCES != null)
            {
                CompanyNameBox.Text = ADE_CCES.GetCompanyNameField();
                CompanyIDBox.Text = ADE_CCES.GetCompanyIDField();
                CompanyPhoneNumberBox.Text = ADE_CCES.GetCompanyPhoneNumberField();
                CompanyeMailBox.Text = ADE_CCES.GeteMailAddress();

                SetMaxTextLengthForFields();

                listOfCountries loc = new listOfCountries();
                List<country> countries = new List<country>();
                countries = loc.GetCountries();


                lb.ItemsSource = countries;


                if (ADE_CCES.GetAddCompanyEntity())
                {
                    //ADE_CCES.SetAddCompanyEntity(false);

                }

                

                else if (ADE_CCES.GetEditCompanyEntity())
                {
                    
                    //We need to load data from "database"
                    CompanyEntityRecordRetrieve comEntRecRet = new CompanyEntityRecordRetrieve();
                    CompanyEntityClass newADE_CCES = comEntRecRet.ComEntRecRet(ADE_CCES.GetCompanyEntityIDField());
                    ADE_CCES = newADE_CCES;

                    ADE_CCES.SetEditCompanyEntity(true);

                    SetUIFieldsToCompanyEntityInfo();

                }
            }

            

            if (ADE_CCES == null)
            {
                CompanyNameBox.Text = "was null ref - look at how the class is created and passed between wpf pages";
            }
            frameCountryAddress = MainCountryAddress;
            
            //frame.Content = new AddContactEntityToCompanyPage(ADE_CCES, frame);
        }
        private void SetUIFieldsToCompanyEntityInfo()
        {
            CompanyNameBox.Text = ADE_CCES.GetCompanyNameField();
            //EntityID field was already set when it was assigned
            CompanyIDBox.Text = ADE_CCES.GetCompanyIDField();
            CompanyPhoneNumberBox.Text = ADE_CCES.GetCompanyPhoneNumberField();
            CompanyPhoneNumberExtensionBox.Text = ADE_CCES.GetCompanyPhoneExtensionField();
            CompanyeMailBox.Text = ADE_CCES.GeteMailAddress();
            CompanyTypeofBusiness.Text = ADE_CCES.GetTypeofBusiness();

            //AddressLine1Box.Text = ADE_CCES.GetAddressLine1();
            //AddressLine2Box.Text = ADE_CCES.GetAddressLine2();
            //AddressCity.Text = ADE_CCES.GetAddressCity();
            //AddressState.Text = ADE_CCES.GetAddressState();
            //AddressZipCode.Text = ADE_CCES.GetAddressZipCode();
        }

        private void SetMaxTextLengthForFields()
        {
            xamlFieldControls xfc = new xamlFieldControls();
            maxTextLength = xfc.MaxTextLengthControlMethod();

            CompanyNameBox.MaxLength = maxTextLength;
            CompanyIDBox.MaxLength = maxTextLength;
            CompanyeMailBox.MaxLength = maxTextLength;
            CompanyTypeofBusiness.MaxLength = maxTextLength;
            //AddressLine1Box.MaxLength = maxTextLength;
            //AddressLine2Box.MaxLength = maxTextLength;
            //AddressCity.MaxLength = maxTextLength;
            //AddressState.MaxLength = maxTextLength;
            //AddressZipCode.MaxLength = maxTextLength;
        }
        //private void entityIDAssignment()
        //{
        //    int currentRecordInt = CompanyEntityRecordCreate.AssignEntityID();
        //    NumberOfRecords.Text = currentRecordInt.ToString();
        //    EntityID.Text = currentRecordInt.ToString();
        //    ADE_CCES.SetEntityIDField(currentRecordInt);
        //}

        private void SearchWindowButton(object sender, RoutedEventArgs e)
        {
            ClearCompanyEntityFields();

            ClearCompanyTipFields();

            SetUIFieldsToADEObject();

            savedButtonClicked = false;

            frame.Content = new CompanySearchPage(ADE_CCES, frame);
            //SearchWindow sw = new SearchWindow(ADE_CCES); //create your new form.
            //sw.Show(); //show the new form.
            //this.Close();
        }

        //we are passing the company entityclass to companyrecordcreate class to add the company to file/database
        //need to scrub data from end user
        private void SaveCompanyEntityButton(object sender, RoutedEventArgs e)
        {
            if (CompanyNameBox.Text != "" || CompanyIDBox.Text != "")
            {

                //entityIDAssignment();

                SetUIFieldsToADEObject();

                resultFromEntityRecordCreate = CompanyEntityRecordCreate.CRC(ADE_CCES);
                if (resultFromEntityRecordCreate != -1 || resultFromEntityRecordCreate != -2)
                {
                    ADE_CCES.SetCompanyEntityIDField(resultFromEntityRecordCreate);
                    EntityID.Text = resultFromEntityRecordCreate.ToString();

                    CompanyName2.Text = CompanyNameBox.Text;
                    EntityID2.Text = EntityID.Text;
                    CompanyID2.Text = CompanyIDBox.Text;
                    PhoneNumber2.Text = CompanyPhoneNumberBox.Text;
                    PhoneNumberExtension2.Text = CompanyPhoneNumberExtensionBox.Text;
                    eMail2.Text = CompanyeMailBox.Text;
                    TypeofBusiness2.Text = CompanyTypeofBusiness.Text;
                    DataSaved.Text = "Data Was Saved";

                    ClearCompanyEntityFields();
                    //now that we know the method exacuted and saved data, we can write back that it was saved.
                }
                else if (resultFromEntityRecordCreate != -1)
                {
                    DataSaved.Text = "Data Was NOT Saved -1";
                }
                else if (resultFromEntityRecordCreate != -2)
                {
                    DataSaved.Text = "Data Was NOT Saved -2";
                }

            }
        }

        private void ClearCompanyEntityButton(object sender, RoutedEventArgs e)
        {
            //we blank the form for company and address information since we are now clearing the form
            ClearCompanyEntityFields();

            ClearCompanyTipFields();

            SetUIFieldsToADEObject();

            savedButtonClicked = false;
            //entityIDAssignment();
        }

        private void SetUIFieldsToADEObject()
        {
            ADE_CCES.SetCompanyNameField(CompanyNameBox.Text);
            //EntityID field was already set when it was assigned
            ADE_CCES.SetCompanyIDField(CompanyIDBox.Text);
            ADE_CCES.SetCompanyPhoneNumberField(CompanyPhoneNumberBox.Text);
            ADE_CCES.SetCompanyPhoneExtension(CompanyPhoneNumberExtensionBox.Text);
            ADE_CCES.SeteMailAddress(CompanyeMailBox.Text);
            ADE_CCES.SetTypeofBusiness(CompanyTypeofBusiness.Text);
            //ADE_CCES.SetAddressLine1(AddressLine1Box.Text);
            //ADE_CCES.SetAddressLine2(AddressLine2Box.Text);
            //ADE_CCES.SetAddressCity(AddressCity.Text);
            //ADE_CCES.SetAddressState(AddressState.Text);
            //ADE_CCES.SetAddressZipCode(AddressZipCode.Text);
        }

        private void ClearCompanyEntityFields()
        {
            CompanyNameBox.Text = "";
            CompanyIDBox.Text = "";
            CompanyPhoneNumberBox.Text = "";
            CompanyPhoneNumberExtensionBox.Text = "";
            CompanyeMailBox.Text = "";
            CompanyTypeofBusiness.Text = "";
            //AddressLine1Box.Text = "";
            //AddressLine2Box.Text = "";
            //AddressCity.Text = "";
            //AddressState.Text = "";
            //AddressZipCode.Text = "";
        }

        private void ClearCompanyTipFields()
        {
            CompanyName2.Text = "";
            EntityID2.Text = "";
            CompanyID2.Text = "";
            PhoneNumber2.Text = "";
            PhoneNumberExtension2.Text = "";
            eMail2.Text = "";
            TypeofBusiness2.Text = "";
            DataSaved.Text = "";
        }

        private void AddContactEntityButton(object sender, RoutedEventArgs e)
        {
            frame.Content = new AddContactEntityToCompanyPage(ADE_CCES, frame);

            //AddContactEntityToCompany ACETC = new AddContactEntityToCompany(ADE_CCES); //create your new form.
            //ACETC.Show(); //show the new form.
            //this.Close();

            //// Not developed yet.
            //throw new NotImplementedException();
        }
        void CountryDropDownSelection(object sender, SelectionChangedEventArgs args)
        {
            country newCountry = (country)(sender as ComboBox).SelectedItem;
            //tb.Text =

            if (newCountry.countryName == "Afghanistan")
            {
                frameCountryAddress.Content = new CountriesPage.AfghanistanCompanyAddress();
            }

            if (newCountry.countryName== "United States of America")
            {
                frameCountryAddress.Content = new CountryFormatAddress.USCompanyAddress();
            }

            else
            {
                frameCountryAddress.Content = new CountryFormatAddress.BlankCountry();
            }
        }

        
    }
}


