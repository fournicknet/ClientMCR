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
        static string datadocPath;
        static string entityIDasSTring;
        static int entityID;
        
        public CompanyEntityClass ComEntRecRet(int entityID)
        {
            CompanyEntityClass comEntClass = new CompanyEntityClass();

            datadocPath = MainDataManager.GetDataDocPath();

            try
            {
                StreamReader sr = new StreamReader(datadocPath + "\\"+ entityID.ToString() + "\\" + "companydata.txt");
                
                comEntClass.SetCompanyNameField(sr.ReadLine());
                //this line is here so we get and skip the entity field we already have the entity id
                entityIDasSTring = sr.ReadLine();
                int.TryParse(entityIDasSTring, out entityID);
                comEntClass.SetCompanyEntityIDField(entityID);
                comEntClass.SetCompanyIDField(sr.ReadLine());
                comEntClass.SetCompanyPhoneNumberField(sr.ReadLine());
                comEntClass.SetCompanyPhoneExtension(sr.ReadLine());
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
