using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    internal class PhoneNumberFormatter
    {
        private static string newPhoneNumberString;
        private static string phoneNumberFormatter(string oldPhoneNumber)
        {
            newPhoneNumberString = oldPhoneNumber;

            return newPhoneNumberString;
        }
    }
}
