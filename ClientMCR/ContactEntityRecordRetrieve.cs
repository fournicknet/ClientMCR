using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    
    internal class ContactEntityRecordRetrieve
    {
        static string datadocPath = @"C:\DataMCR";
        static string entityIDasSTring;
        static int entityID;

        public static List<ContactSearchListData> ConEntRecSea(int CompanyEntityID)
        {
            List<ContactSearchListData> contactDataToReturn = new List<ContactSearchListData>();
            try

            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(datadocPath + "\\" + CompanyEntityID.ToString() + "\\" + "contacts"));
                int numberOfDirs = dirs.Count();
                dirs.Sort();
                dirs.Remove(datadocPath + "\\" + CompanyEntityID.ToString() + "\\" + "contacts"+"\\" + "1000000000");
                foreach (string dir in dirs)
                {
                    ContactSearchListData conSeaLisClass = new ContactSearchListData();
                    StreamReader sr = new StreamReader(dir + "\\" + "contactdata.txt");
                    conSeaLisClass.SetContactNameField(sr.ReadLine());
                    conSeaLisClass.SetEntityIDFieldString(sr.ReadLine());
                    conSeaLisClass.SetCompanyEntityIDFieldString(sr.ReadLine());
                    conSeaLisClass.SetContactPhoneNumberField(sr.ReadLine());
                    conSeaLisClass.SeteMailAddress(sr.ReadLine());
                    sr.Close();
                    contactDataToReturn.Add(conSeaLisClass);
                }

                //we now add it to our list


            }
            catch (Exception ex)
            {

            }
            return contactDataToReturn;

        }
    }
}
