using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    internal class CompanySearchListData
    {
        int CompanyEntityIDField;
        string CompanyNameField = "null", CompanyIDField = "null", PhoneNumberField = "null", eMailAddress = "null";

        public void SetCompanyNameField(string StringCompanyNameField)
        {
            CompanyNameField = StringCompanyNameField;
        }

        public string GetCompanyNameField()
        {
            return CompanyNameField;
        }

        public void SetEntityIDField(int IntCompanyIDField)
        {
            CompanyEntityIDField = IntCompanyIDField;
        }

        public int GetEntityIDField()
        {
            return CompanyEntityIDField;
        }

        public string GetEntityIDFieldString()
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
