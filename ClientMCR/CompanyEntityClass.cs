using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    public class CompanyEntityClass
    {
        //CompanyIDfield is a string because maybe our customer uses letters with numbers for an ID
        //EntityID is what "we" assign to the companies our customers will be working with to work with data
        string CompanyNameField = "null";
        int CompanyEntityIDField;
        bool AddCompanyEntity = false, EditCompanyEntity = false;
        string CompanyIDField = "null", PhoneNumberField = "null", PhoneExtention = "null", eMailAddress = "null", TypeofBusiness = "null",
            AddressLine1 = "null", AddressLine2 = "null", AddressCity = "null", AddressState = "null", AddressZipCode = "null";

        public void SetCompanyNameField(string StringCompanyNameField)
        {
            CompanyNameField = StringCompanyNameField;
        }

        public string GetCompanyNameField()
        {
            return CompanyNameField;
        }

        

        public void SetCompanyEntityIDField(int IntCompanyIDField)
        {
            CompanyEntityIDField = IntCompanyIDField;
        }

        public int GetCompanyEntityIDField()
        {
            return CompanyEntityIDField;
        }

        public string GetCompanyEntityIDFieldString()
        {
            try
            {
                return CompanyEntityIDField.ToString();
            }
            catch (Exception e)
            {
                //better method for exeption handling maybe needed here
                return string.Empty;
            }
        }

        public bool GetAddCompanyEntity()
        {
            return AddCompanyEntity;
        }

        public void SetAddCompanyEntity(bool valueToSet)
        {
            AddCompanyEntity = valueToSet;
        }
        public bool GetEditCompanyEntity()
        {
            return EditCompanyEntity;
        }

        public void SetEditCompanyEntity(bool valueToSet)
        {
            EditCompanyEntity = valueToSet;
        }

        public void SetCompanyIDField(string StringCompanyIDField)
        {
            CompanyIDField = StringCompanyIDField;
        }

        public string GetCompanyIDField()
        {
            return CompanyIDField;
        }

        public void SetCompanyPhoneNumberField(string StringCompanyPhoneNumberField)
        {
            PhoneNumberField = StringCompanyPhoneNumberField;
        }

        public string GetCompanyPhoneNumberField()
        {
            return PhoneNumberField;
        }
        public void SetCompanyPhoneExtension(string StringCompanyPhoneExtensionField)
        {
            PhoneExtention = StringCompanyPhoneExtensionField;
        }

        public string GetCompanyPhoneExtensionField()
        {
            return PhoneExtention;
        }

        public void SeteMailAddress(string StringeMailAddress)
        {
            eMailAddress = StringeMailAddress;
        }

        public string GeteMailAddress()
        {
            return eMailAddress;
        }

        public void SetTypeofBusiness(string StringTypeofBusiness)
        {
            TypeofBusiness = StringTypeofBusiness;
        }

        public string GetTypeofBusiness()
        {
            return TypeofBusiness;
        }

        public void SetAddressLine1(string StringAddressLine1)
        {
            AddressLine1 = StringAddressLine1;
        }

        public string GetAddressLine1()
        {
            return AddressLine1;
        }

        public void SetAddressLine2(string StringAddressLine2)
        {
            AddressLine2 = StringAddressLine2;
        }

        public string GetAddressLine2()
        {
            return AddressLine2;
        }

        
        public void SetAddressCity(string StringAddressCity)
        {
            AddressCity = StringAddressCity;
        }

        public string GetAddressCity()
        {
            return AddressCity;
        }

        public void SetAddressState(string StringAddressState)
        {
            AddressState = StringAddressState;
        }

        public string GetAddressState()
        {
            return AddressState;
        }

        public void SetAddressZipCode(string StringAddressZipCode)
        {
            AddressZipCode = StringAddressZipCode;
        }
        public string GetAddressZipCode()
        {
            return AddressZipCode;
        }


    }
}
