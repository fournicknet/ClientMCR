using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    
    internal class CompanyEntityRecordSearch
    {
        static string datadocPath = @"C:\DataMCR";
        static int companyNameField = 0;
        static char[] stringToRemove = { '(', ')', '-' };

        public static List<CompanySearchListData> ComEntRecSea(string CompanyName, string CompanyID, string phoneNumber, string eMailAddress)
        {
            List<CompanySearchListData> rawData = new List<CompanySearchListData>();

            List<CompanySearchListData> dataToReturn = new List<CompanySearchListData>();
            try
            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(datadocPath));
                int numberOfDirs = dirs.Count();
                dirs.Sort();
                foreach (string dir in dirs)
                {
                    //we need to add the  company entity id, company name, company id, phoneNumber and eMailAddress to each list object
                    CompanySearchListData comSeaLisData = new CompanySearchListData();
                    string dirNumberString = dir.Remove(0, 11);
                    int dirNumber = 0;
                    int.TryParse(dirNumberString, out dirNumber);
                    comSeaLisData.SetEntityIDField(dirNumber);
                    StreamReader sr = new StreamReader(dir + "\\" + "companydata.txt");
                    comSeaLisData.SetCompanyNameField(sr.ReadLine());
                    //this line is here so we get and skip the entity field we already have the entity id
                    Console.WriteLine(sr.ReadLine());
                    comSeaLisData.SetCompanyIDField(sr.ReadLine());
                    comSeaLisData.SetCompanyPhoneNumberField(sr.ReadLine());
                    comSeaLisData.SeteMailAddress(sr.ReadLine());
                    sr.Close();
                    //we now add it to our list
                    rawData.Add(comSeaLisData);
                }
            }
            catch (Exception ex)
            {

            }

            //we now check if any of the strings match our collection of data
            foreach (CompanySearchListData data in rawData)
            {
                if (data.GetCompanyNameField().Contains(CompanyName))
                {
                    dataToReturn.Add(data);
                    
                }
                else if (data.GetCompanyIDField() == CompanyID)
                {
                    //first thing is we check if it was already added to our list by comparing entity id's
                    if(!dataToReturn.Contains(data))
                    {
                        dataToReturn.Add(data);
                    }
                    //CompareTwoLists(data, dataToReturn, CompanyName);
                }

                string dataPhoneNumber, userProvidedPhoneNumber;
                dataPhoneNumber = data.GetCompanyPhoneNumberField();
                dataPhoneNumber = dataPhoneNumber.Trim(stringToRemove);
                userProvidedPhoneNumber = phoneNumber.Trim(stringToRemove);
                if (dataPhoneNumber.Trim().StartsWith("1"))
                {
                    dataPhoneNumber = dataPhoneNumber.TrimStart('1');
                }
                if (userProvidedPhoneNumber.Trim().StartsWith("1"))
                {
                    userProvidedPhoneNumber = userProvidedPhoneNumber.TrimStart('1');
                }

                else if (dataPhoneNumber.Contains(userProvidedPhoneNumber))
                {
                    if(!dataToReturn.Contains(data))
                    {
                        dataToReturn.Add(data);
                    }

                    //dataToReturn.Add(data);
                    //Commented out cause it can not remove data from a list being worked on
                    //rawData.Remove(data);
                    //CompareTwoPhoneNumbers(data, dataToReturn, CompanyName);
                }
                else if (data.GeteMailAddress() == eMailAddress)
                {
                    if (!dataToReturn.Contains(data))
                    {
                        dataToReturn.Add(data);
                    }
                }

            }

            return dataToReturn;
            
        }

        //static private void CompareTwoLists(CompanySearchListData CompanyNameRawData, List<CompanySearchListData> CompanyNameSearchEntered, string CompanyName)
        //{
        //    if(CompanyName == CompanyNameRawData.GetCompanyNameField())
        //    {

        //    }
        //    foreach (CompanySearchListData dataTo in CompanyNameSearchEntered)
        //    {
        //        if(CompanyNameRawData.GetCompanyNameField() == CompanyName)
        //        {
        //            if (CompanyNameRawData.GetEntityIDField() == dataTo.GetEntityIDField())
        //            {
        //                companyNameField++;
        //            }
        //        }
        //    }
        //    if (companyNameField == 0)
        //    {
        //        CompanyNameSearchEntered.Add(CompanyNameRawData);
        //    }
        //    else if (companyNameField >= 1)
        //    {
        //        companyNameField = 0;
        //    }
        //}

        //static private void CompareTwoPhoneNumbers(CompanySearchListData CompanyNameRawData, List<CompanySearchListData> CompanyNameSearchEntered, string CompanyName)
        //{
        //    foreach (CompanySearchListData dataTo in CompanyNameSearchEntered)
        //    {
        //        if (CompanyNameRawData.GetEntityIDField() == dataTo.GetEntityIDField())
        //        {
        //            companyNameField++;
        //        }
        //    }
        //    if (companyNameField == 0)
        //    {
        //        CompanyNameSearchEntered.Add(CompanyNameRawData);
        //    }
        //    else if (companyNameField >= 1)
        //    {
        //        companyNameField = 0;
        //    }
        //}

    }
}
