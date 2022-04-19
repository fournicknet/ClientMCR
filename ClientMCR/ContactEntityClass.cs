using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    public class ContactEntityClass
    {
        //ContactIDfield is a string because maybe our customer uses letters with numbers for an ID
        //EntityID is what "we" assign to the companies our customers will be working with to work with data
        string ContactNameField = "null";

        int EntityIDField, CompanyEntityID;
        string ContactIDField = "null", PhoneNumberField = "null", PhoneNumberExtensionField = "null", eMailAddress = "null",
            AddressLine1 = "null", AddressLine2 = "null", AddressCity = "null", AddressState = "null", AddressZipCode = "null";

        public void SetContactNameField(string StringContactNameField)
        {
            ContactNameField = StringContactNameField;
        }

        public string GetContactNameField()
        {
            return ContactNameField;
        }

        public void SetEntityIDFieldString(string StringContactIDField)
        {
            int.TryParse(StringContactIDField, out EntityIDField);
        }
        public void SetEntityIDField(int IntContactIDField)
        {
            EntityIDField = IntContactIDField;
        }

        public int GetEntityIDField()
        {
            return EntityIDField;
        }

        public string GetEntityIDFieldString()
        {
            try
            {
                return EntityIDField.ToString();
            }
            catch (Exception e)
            {
                //better method for exeption handling maybe needed here
                return string.Empty;
            }
        }

        public void SetCompanyEntityIDFieldString(string StringCompanyIDField)
        {
            int.TryParse(StringCompanyIDField, out CompanyEntityID);
        }
        public void SetCompanyEntityIDField(int IntCompanyIDField)
        {
            CompanyEntityID = IntCompanyIDField;
        }

        public int GetCompanyEntityIDField()
        {
            return CompanyEntityID;
        }

        public string GetCompanyEntityIDFieldString()
        {
            try
            {
                return CompanyEntityID.ToString();
            }
            catch (Exception e)
            {
                //better method for exeption handling maybe needed here
                return string.Empty;
            }
        }

        public void SetContactIDField(string StringContactIDField)
        {
            ContactIDField = StringContactIDField;
        }

        public string GetContactIDField()
        {
            return ContactIDField;
        }

        public void SetContactPhoneNumberField(string StringContactPhoneNumberField)
        {
            PhoneNumberField = StringContactPhoneNumberField;
        }

        public string GetContactPhoneNumberField()
        {
            return PhoneNumberField;
        }

        public void SetContactPhoneNumberExtension(string StringContactPhoneNumberExtensionField)
        {
            PhoneNumberExtensionField = StringContactPhoneNumberExtensionField;
        }

        public string GetContactPhoneNumberExtensionField()
        {
            return PhoneNumberExtensionField;
        }

        public void SeteMailAddress(string StringeMailAddress)
        {
            eMailAddress = StringeMailAddress;
        }

        public string GeteMailAddress()
        {
            return eMailAddress;
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
