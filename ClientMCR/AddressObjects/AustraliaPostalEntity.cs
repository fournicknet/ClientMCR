using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR.AddressObjects
{
    public class AustraliaPostalEntity
    {
        bool EditAddressEntity = false;
        string AddressLine1 = "null", AddressLine2 = "null", AddressLine3 = "null", AddressLine4 = "null", AddressLocalityorDeliveryOffice = "null", AddressStateorTerritory = "null", AddressPostalCode = "null";

        public bool GetEditCompanyEntity()
        {
            return EditAddressEntity;
        }

        public void SetEditCompanyEntity(bool valueToSet)
        {
            EditAddressEntity = valueToSet;
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

        public void SetAddressLine3(string StringAddressLine3)
        {
            AddressLine3 = StringAddressLine3;
        }

        public string GetAddressLine3()
        {
            return AddressLine3;
        }

        public void SetAddressLine4(string StringAddressLine4)
        {
            AddressLine4 = StringAddressLine4;
        }

        public string GetAddressLine4()
        {
            return AddressLine4;
        }


        public void SetAddressLocalityorDeliveryOffice(string StringAddressLocalityorDeliveryOffice)
        {
            AddressLocalityorDeliveryOffice = StringAddressLocalityorDeliveryOffice;
        }

        public string GetAddressLocalityorDeliveryOffice()
        {
            return AddressLocalityorDeliveryOffice;
        }

        public void SetAddressStateorTerritory(string StringStateorTerritory)
        {
            AddressStateorTerritory = StringStateorTerritory;
        }

        public string GetAddressStateorTerritory()
        {
            return AddressStateorTerritory;
        }

        public void SetAddressPostalCode(string StringAddressPostalCode)
        {
            AddressPostalCode = StringAddressPostalCode;
        }
        public string GetAddressPostalCode()
        {
            return AddressPostalCode;
        }

    }
}
