﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR.AddressObjects
{
    public class CountryPostalEntity
    {
        bool EditAddressEntity = false;
        string AddressLine1 = "null", 
            AddressLine2 = "null", 
            AddressLine3 = "null", 
            AddressLine4 = "null", 
            AddressCity = "null",

            StateTerritoryProvinceLocalityDeliveryOffice_Selector = "null",

            AddressStateorTerritory = "null",
            AddressProvinceorTerritory = "null",
            AddressLocalityorDeliveryOffice = "null",
            AddressProvince = "null", 

            AddressPostalCode = "null";

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


        public void SetAddressCity(string StringAddressCity)
        {
            AddressCity = StringAddressCity;
        }

        public string GetAddressCity()
        {
            return AddressCity;
        }

        public void SetAddressStateorTerritory(string StringAddressStateorTerritory)
        {
            AddressStateorTerritory = StringAddressStateorTerritory;
        }

        public string GetAddressStateorTerritory()
        {
            return AddressStateorTerritory;
        }


        public void SetStateTerritoryProvinceLocalityDeliveryOffice_Selector(string StringStateTerritoryProvinceLocalityDeliveryOffice_Selector)
        {
            StateTerritoryProvinceLocalityDeliveryOffice_Selector = StringStateTerritoryProvinceLocalityDeliveryOffice_Selector;
        }

        public string GetStateTerritoryProvinceLocalityDeliveryOffice_Selector()
        {
            return StateTerritoryProvinceLocalityDeliveryOffice_Selector;
        }
        public void SetAddressProvinceorTerritory(string StringAddressProvinceorTerritory)
        {
            AddressProvinceorTerritory = StringAddressProvinceorTerritory;
        }

        public string GetAddressProvinceorTerritory()
        {
            return AddressProvinceorTerritory;
        }

        public void SetAddressLocalityorDeliveryOffice(string StringAddressLocalityorDeliveryOffice)
        {
            AddressLocalityorDeliveryOffice = StringAddressLocalityorDeliveryOffice;
        }

        public string GetAddressLocalityorDeliveryOffice()
        {
            return AddressLocalityorDeliveryOffice;
        }

        public void SetAddressProvince(string StringAddressProvince)
        {
            AddressProvince = StringAddressProvince;
        }

        public string GetAddressProvince()
        {
            return AddressProvince;
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
