using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    public class CompanyEntityClass
    {
        string CompanyNameField = "null", CompanyIDField = "null", PhoneNumberField = "null", eMailAddress = "null", AddressLine1 = "null", AddressLine2 = "null", 
            AddressCity = "null", AddressState = "null", AddressZipCode = "null";

        public void SetCompanyNameField(string StringCompanyNameField)
        {
            CompanyNameField = StringCompanyNameField;
        }

        public string GetCompanyNameField()
        {
            return CompanyNameField;
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
