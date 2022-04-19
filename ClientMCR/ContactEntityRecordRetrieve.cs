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
        public static ContactEntityClass ConEntRecRet(int CompanyEntityID, int ContactEntityID)
        {
            ContactEntityClass contactDataToReturn = new ContactEntityClass();

            try
            {
                StreamReader sr = new StreamReader(datadocPath + "\\" + CompanyEntityID.ToString() + "\\" + "contacts" + "\\" + ContactEntityID.ToString());
                contactDataToReturn.SetContactNameField(sr.ReadLine());
                contactDataToReturn.SetEntityIDFieldString(sr.ReadLine());
                contactDataToReturn.SetCompanyEntityIDFieldString(sr.ReadLine());
                contactDataToReturn.SetContactPhoneNumberField(sr.ReadLine());
                contactDataToReturn.SetContactPhoneNumberExtension(sr.ReadLine());
                contactDataToReturn.SeteMailAddress(sr.ReadLine());
                contactDataToReturn.SetAddressLine1(sr.ReadLine());
                contactDataToReturn.SetAddressLine2(sr.ReadLine());
                contactDataToReturn.SetAddressCity(sr.ReadLine());
                contactDataToReturn.SetAddressState(sr.ReadLine());
                contactDataToReturn.SetAddressZipCode(sr.ReadLine());
                sr.Close();
            }
            catch (Exception ex)
            {

            }
            return contactDataToReturn;
        }

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

        public static List<ContactSearchListData> ConEntRecSea(string ContactName, string ContactID, string phoneNumber, string phoneNumberExtension, string eMailAddress)
        {
            List<ContactSearchListData> rawContactData = new List<ContactSearchListData>();

            List<ContactSearchListData> contactDataToReturn = new List<ContactSearchListData>();
                        
            try

            {
                //first we are getting a list of the company directories
                List<string> companyDirs = new List<string>(Directory.EnumerateDirectories(datadocPath + "\\"));
                int numberOfCompanyDirs = companyDirs.Count();
                companyDirs.Sort();
                companyDirs.Remove(datadocPath + "\\" + "1000000000");
                foreach (string companyDir in companyDirs)
                {
                    List<string> listOfContacts = new List<string>(Directory.EnumerateDirectories(companyDir + "\\" + "contacts"));
                    int numberOfDirsInListOfContacts = listOfContacts.Count();
                    listOfContacts.Sort();
                    listOfContacts.Remove(datadocPath + "\\" + companyDir + "\\" + "contacts" + "\\" + "1000000000");

                    foreach(string contact in listOfContacts)
                    {
                        ContactSearchListData conSeaLisClass = new ContactSearchListData();
                        StreamReader sr = new StreamReader(contact + "\\" + "contactdata.txt");
                        conSeaLisClass.SetContactNameField(sr.ReadLine());
                        conSeaLisClass.SetEntityIDFieldString(sr.ReadLine());
                        conSeaLisClass.SetCompanyEntityIDFieldString(sr.ReadLine());
                        conSeaLisClass.SetContactPhoneNumberField(sr.ReadLine());
                        conSeaLisClass.SetContactPhoneNumberExtension(sr.ReadLine());
                        conSeaLisClass.SeteMailAddress(sr.ReadLine());
                        sr.Close();
                        rawContactData.Add(conSeaLisClass);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            //we now check if any of the strings match our collection of data
            foreach (ContactSearchListData contact in rawContactData)
            {
                if(contact.GetContactNameField().Contains(ContactName))
                {
                    addContactToList(contactDataToReturn, contact);
                }
                else if (contact.GetContactIDField() == ContactID)
                {
                    //first thing is we check if it was already added to our list by comparing entity id's
                    ifDoesNot(contactDataToReturn, contact);
                }
                //string contactPhoneNumber, userProvidedPhoneNumber;
                //contactPhoneNumber = contact.GetContactPhoneNumberField();
                //    code below would remove the leading 1 but since we are going international that won't work
                //    dataPhoneNumber = dataPhoneNumber.Trim(stringToRemove);
                //    userProvidedPhoneNumber = phoneNumber.Trim(stringToRemove);
                //    if (dataPhoneNumber.Trim().StartsWith("1"))
                //    {
                //        dataPhoneNumber = dataPhoneNumber.TrimStart('1');
                //    }
                //    if (userProvidedPhoneNumber.Trim().StartsWith("1"))
                //    {
                //        userProvidedPhoneNumber = userProvidedPhoneNumber.TrimStart('1');
                //    }

                else if (contact.GetContactPhoneNumberField().Contains(phoneNumber))
                {
                    ifDoesNot(contactDataToReturn, contact);
                    //Commented out cause it can not remove data from a list being worked on
                    //contactDataToReturn.Remove(data);
                }

                else if (contact.GetContactPhoneNumberExtensionField().Contains(phoneNumberExtension))
                {
                    ifDoesNot(contactDataToReturn, contact);
                }

                else if (contact.GeteMailAddress() == eMailAddress)
                {
                    ifDoesNot(contactDataToReturn, contact);
                }

            }

            return contactDataToReturn;

        }

        public static void ifDoesNot(List<ContactSearchListData> contactDataToReturn, ContactSearchListData contact)
        {
            if(!contactDataToReturn.Contains(contact))
            {
                addContactToList(contactDataToReturn, contact);
            }
        }
        public static void addContactToList(List<ContactSearchListData> contactDataToReturn, ContactSearchListData contact)
        {
            contactDataToReturn.Add(contact);
        }
    }
}
