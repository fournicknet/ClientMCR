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
    /// Interaction logic for AddContactEntityToCompanyPage.xaml
    /// </summary>
    public partial class AddContactEntityToCompanyPage : Page
    {
        

        CompanyEntityClass ADE_CCES;
        ContactEntityClass ContactEC;
        int contactEntityID;
        bool savedButtonClicked = false;
        Frame frame;
        public AddContactEntityToCompanyPage(CompanyEntityClass CES, Frame mainframe)
        {
            InitializeComponent();

            frame = mainframe;

            ADE_CCES = CES;

            ContactEC = new ContactEntityClass();

            SetCompanyTipFields();
        }

        private void ClearCompanyEntityButton(object sender, RoutedEventArgs e)
        {

            //we clear content fields that the user entered data cause now they want to clear the form.
            ClearContactEntityFields();

            //We are now setting the company tip data back to default to what was passed to us
            SetCompanyTipFields();

            //we are now setting the contact tip fields back to default
            SetContactTipDatatoDefault();

            //// Not developed yet.
            //throw new NotImplementedException();
        }

        private void ContactSearchButton(object sender, RoutedEventArgs e)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }

        private void CompanySearchButton(object sender, RoutedEventArgs e)
        {
            //// Not developed yet.
            //throw new NotImplementedException();

            //we clear content fields that the user entered data cause now they want to clear the form.
            ClearContactEntityFields();

            //We are now setting the company tip data back to default to what was passed to us
            SetCompanyTipFields();

            //we are now setting the contact tip fields back to default
            SetContactTipDatatoDefault();

            frame.Content = new CompanySearchPage(ADE_CCES, frame);
        }

        private void SaveContactEntityButton(object sender, RoutedEventArgs e)
        {
            //SetContactEntityID();
            if (ContactNameBox.Text != "" || ContactIDBox.Text != "")
            {

                SetUIFieldsToContactEC();

                //now that we know the method exacuted and saved data, we can write back that it was saved.
                contactEntityID = ContactEntityRecordCreate.ContactRecordCreate(ContactEC);

                if (contactEntityID != -1 || contactEntityID != -2)
                {
                    ContactEC.SetEntityIDField(contactEntityID);
                    EntityID.Text = contactEntityID.ToString();
                    ContactEntityID2.Text = contactEntityID.ToString();
                    ContactID2.Text = ContactEC.GetContactIDField();

                    ContactName2.Text = ContactEC.GetContactNameField();
                    //EntityID2.Text = EntityID.Text;

                    ContactPhoneNumber2.Text = ContactEC.GetContactPhoneNumberField();
                    ContacteMail2.Text = ContactEC.GeteMailAddress();
                    DataSaved.Text = "Data Was Saved";
                    //We now clear the form since the data was saved and prepair for next use
                    ClearContactEntityFields();
                }
                else if (contactEntityID != -1)
                {
                    DataSaved.Text = "Data Was NOT Saved -1";
                }
                else if (contactEntityID != -2)
                {
                    DataSaved.Text = "Data Was NOT Saved -2";
                }


            }

            //We don't need to get another ID we already have one
            //SetCompanyEntityIDAssignment();

            //Not developed yet.
            //throw new NotImplementedException();
        }

        private void SetContactEntityID()
        {
            //so we are going into the ADE_CCES i.e. companycontact and getting the id that is stored locally for the company
            //and passing it into the ContactEntityRecordCreate class to the static method to get back our ID for the contact that is 
            //assigned to the company
            //int entityID = ContactEntityRecordCreate.AssignEntityID(ADE_CCES.GetEntityIDField());
            //EntityID.Text = entityID.ToString();
        }

        private void SetUIFieldsToContactEC()
        {
            ContactEC.SetContactNameField(ContactNameBox.Text);

            ContactEC.SetCompanyEntityIDField(ADE_CCES.GetEntityIDField());

            ContactEC.SetContactIDField(ContactIDBox.Text);
            ContactEC.SetContactPhoneNumberField(ContactPhoneNumberBox.Text);
            ContactEC.SeteMailAddress(ContacteMailBox.Text);

            ContactEC.SetAddressLine1(AddressLine1Box.Text);
            ContactEC.SetAddressLine2(AddressLine2Box.Text);
            ContactEC.SetAddressCity(AddressCity.Text);
            ContactEC.SetAddressState(AddressState.Text);
            ContactEC.SetAddressZipCode(AddressZipCode.Text);
        }

        private void SetCompanyTipFields()
        {
            CompanyName2.Text = ADE_CCES.GetCompanyNameField();
            EntityID2.Text = ADE_CCES.GetEntityIDFieldString();
            CompanyID2.Text = ADE_CCES.GetCompanyIDField();
            PhoneNumber2.Text = ADE_CCES.GetCompanyPhoneNumberField();
            eMail2.Text = ADE_CCES.GeteMailAddress();
            TypeofBusiness2.Text = ADE_CCES.GetTypeofBusiness();
        }

        private void SetCompanyEntityIDAssignment()
        {
            int currentRecordInt = ADE_CCES.GetEntityIDField();
            EntityID2.Text = currentRecordInt.ToString();
        }

        private void ClearContactEntityFields()
        {
            ContactNameBox.Text = "";
            //EntityID
            ContactIDBox.Text = "";
            ContactPhoneNumberBox.Text = "";
            ContacteMailBox.Text = "";

            AddressLine1Box.Text = "";
            AddressLine2Box.Text = "";
            AddressCity.Text = "";
            AddressState.Text = "";
            AddressZipCode.Text = "";
        }

        private void ClearContactTipFields()
        {

        }

        private void SetContactTipDatatoDefault()
        {
            ContactName2.Text = "Contact Name   ";
            //SetEntityID2
            ContactID2.Text = "Contact ID   ";
            ContactPhoneNumber2.Text = "Phone #";
            ContacteMail2.Text = "eMail";
            DataSaved.Text = "";
        }
    }
}
