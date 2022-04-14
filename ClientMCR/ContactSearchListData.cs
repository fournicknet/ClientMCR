using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    internal class ContactSearchListData
    {
        int ContactEntityIDField, CompanyEntityIDField;
        string ContactNameField = "null", ContactIDField = "null", PhoneNumberField = "null", eMailAddress = "null";

        public void SetContactNameField(string StringContactNameField)
        {
            ContactNameField = StringContactNameField;
        }

        public string GetContactNameField()
        {
            return ContactNameField;
        }

        public void SetCompanyEntityIDFieldString(string StringCompanyIDField)
        {
            int.TryParse(StringCompanyIDField, out CompanyEntityIDField);
            
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

        public void SetEntityIDFieldString(string StringContactIDField)
        {
            int.TryParse(StringContactIDField, out ContactEntityIDField);
        }
        public void SetEntityIDField(int IntContactIDField)
        {
            ContactEntityIDField = IntContactIDField;
        }

        public int GetEntityIDField()
        {
            return ContactEntityIDField;
        }

        public string GetEntityIDFieldString()
        {
            try
            {
                return ContactEntityIDField.ToString();
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

        public void SeteMailAddress(string StringeMailAddress)
        {
            eMailAddress = StringeMailAddress;
        }

        public string GeteMailAddress()
        {
            return eMailAddress;
        }
    }
}
