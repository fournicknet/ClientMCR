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

                //we now check if any of the strings match our collection of data
                //foreach (CompanySearchListData data in rawData)
                //{
                //    if (data.GetCompanyNameField().Contains(CompanyName))
                //    {
                //        dataToReturn.Add(data);

                //    }
                //    else if (data.GetCompanyIDField() == CompanyID)
                //    {
                //        //first thing is we check if it was already added to our list by comparing entity id's
                //        if (!dataToReturn.Contains(data))
                //        {
                //            dataToReturn.Add(data);
                //        }
                //        //CompareTwoLists(data, dataToReturn, CompanyName);
                //    }

                //    string dataPhoneNumber, userProvidedPhoneNumber;
                //    dataPhoneNumber = data.GetCompanyPhoneNumberField();
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

                //    else if (dataPhoneNumber.Contains(userProvidedPhoneNumber))
                //    {
                //        if (!dataToReturn.Contains(data))
                //        {
                //            dataToReturn.Add(data);
                //        }

                //        //dataToReturn.Add(data);
                //        //Commented out cause it can not remove data from a list being worked on
                //        //rawData.Remove(data);
                //        //CompareTwoPhoneNumbers(data, dataToReturn, CompanyName);
                //    }
                //    else if (data.GeteMailAddress() == eMailAddress)
                //    {
                //        if (!dataToReturn.Contains(data))
                //        {
                //            dataToReturn.Add(data);
                //        }
                //    }

                //}


            }
            catch (Exception ex)
            {

            }
            return contactDataToReturn;

        }

    }
}
