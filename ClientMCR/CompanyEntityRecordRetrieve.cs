using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    internal class CompanyEntityRecordRetrieve
    {
        static string datadocPath = @"C:\DataMCR";
        static string entityIDasSTring;
        static int entityID;
        CompanyEntityClass comEntClass = new CompanyEntityClass();
        public CompanyEntityClass ComEntRecRet(int entityID)
        {
            try
            {
                StreamReader sr = new StreamReader(datadocPath + "\\"+ entityID.ToString() + "\\" + "companydata.txt");
                
                comEntClass.SetCompanyNameField(sr.ReadLine());
                //this line is here so we get and skip the entity field we already have the entity id
                entityIDasSTring = sr.ReadLine();
                int.TryParse(entityIDasSTring, out entityID);
                comEntClass.SetEntityIDField(entityID);
                comEntClass.SetCompanyIDField(sr.ReadLine());
                comEntClass.SetCompanyPhoneNumberField(sr.ReadLine());
                comEntClass.SeteMailAddress(sr.ReadLine());
                comEntClass.SetTypeofBusiness(sr.ReadLine());
                comEntClass.SetAddressLine1(sr.ReadLine());
                comEntClass.SetAddressLine2(sr.ReadLine());
                comEntClass.SetAddressCity(sr.ReadLine());
                comEntClass.SetAddressState(sr.ReadLine());
                comEntClass.SetAddressZipCode(sr.ReadLine());
                sr.Close();
                //we now add it to our list
                
                
            }
            catch (Exception ex)
            {

            }
            return comEntClass;
        }
        
    }
}
