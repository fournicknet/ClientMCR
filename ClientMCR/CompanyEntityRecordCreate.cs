using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClientMCR
{
    internal class CompanyEntityRecordCreate
    {
        static int secondsInMinute = 60;
        static int timeToWait;
        static string stringNewDirectoryToCreate;
        static string datadocPath;
        static string companyDatadocPath;
        static int newDirectoryToCreate;
        //public static int AssignEntityID()
        //{




        //}
        static async void directoryMonitor(string directoryToMonitor)
        {
            timeToWait = secondsInMinute * 60;
            await Task.Delay(TimeSpan.FromSeconds(timeToWait));
            if (File.Exists(directoryToMonitor + "\\companydata.txt"))
            {

            }
            else
            {
                Directory.Delete(directoryToMonitor);
            }

        }

        CompanyEntityClass SW_CES;
        //CRC stands for CompanyRecordCreate
        public static int CRC(CompanyEntityClass SW_CES)
        {
            datadocPath = MainDataManager.GetDataDocPath();

            if (SW_CES != null)
            {
                if(SW_CES.GetAddCompanyEntity())
                {
                    int lastCreatedDirectory;
                    try
                    {
                        //when trying to get to the path to the root directly with directory enumerateDirectoreis
                        //it adds on the path to C:\Future Company Projects\ClientMCR\ClientMCR\ClientMCR\bin\Debug\net6.0-windows

                        //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        List<string> dirs = new List<string>(Directory.EnumerateDirectories(datadocPath));

                        int numberOfDirs = dirs.Count();
                        //commented out for optimization
                        //if(dirs.Count() == 0)
                        //{
                        //    Directory.CreateDirectory(datadocPath + "\\" + "1000000000");
                        //}

                        dirs.Sort();
                        //we are accessing the position inside the list of dirs and assigning the value to a string
                        string lastDir = dirs[numberOfDirs - 1];
                        //we are trimming the entire value from the directory and only getting the result of the sub directory
                        string newLastDir = lastDir.TrimStart('C', ':', '\\', 'D', 'a', 't', 'a', 'M', 'C', 'R', '\\', 'c', 'o', 'm', 'p', 'a', 'n', 'i', 'e', 's', '\\');
                        //we are now getting the number value of the directory
                        int.TryParse(newLastDir, out lastCreatedDirectory);
                        newDirectoryToCreate = lastCreatedDirectory + 1;
                        stringNewDirectoryToCreate = newDirectoryToCreate.ToString();
                        Directory.CreateDirectory(datadocPath + "\\" + stringNewDirectoryToCreate);
                        companyDatadocPath = datadocPath + "\\" + stringNewDirectoryToCreate;

                        //now that the directory is created, we are going to verify that it is being used other wise we are going to delete it.
                        //directoryMonitor(datadocPath + "\\" + stringNewDirectoryToCreate);
                        //the company needs a place for its employees to be stored so
                        Directory.CreateDirectory(companyDatadocPath + "\\" + "contacts");
                        Directory.CreateDirectory(companyDatadocPath + "\\" + "contacts" + "\\" + "1000000000");
                        //return newDirectoryToCreate;
                    }

                    catch (UnauthorizedAccessException uAEx)
                    {
                        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "uAEx.txt")))//Path.Combine(docPath, 
                        {
                            outputFile.WriteLine(uAEx.Message);
                            outputFile.Close();
                            Debug.WriteLine(uAEx.Message);
                        }
                        return -1;

                    }
                    catch (PathTooLongException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        return -2;
                    }
                    writeCompanyDataTXT(SW_CES);


                }
                //Set a variable to the Documents path.  Commented out cause we are not using windows mydocs
                //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if(SW_CES.GetEditCompanyEntity())
                {
                    companyDatadocPath = datadocPath + "\\" + SW_CES.GetCompanyEntityIDFieldString();
                    stringNewDirectoryToCreate = SW_CES.GetCompanyEntityIDFieldString();
                    writeCompanyDataTXT(SW_CES);
                }

                

            }
            //create method that informs the client that the save has completed.
            return newDirectoryToCreate;

        }

        static void writeCompanyDataTXT(CompanyEntityClass SW_CES)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(companyDatadocPath, "companydata.txt")))//Path.Combine(docPath, 
            {
                outputFile.WriteLine(SW_CES.GetCompanyNameField());

                outputFile.WriteLine(stringNewDirectoryToCreate);//try/catch not completed for int to string conversion

                outputFile.WriteLine(SW_CES.GetCompanyIDField());
                outputFile.WriteLine(SW_CES.GetCompanyPhoneNumberField());//variable should be an int and not a string inside SW_CES
                outputFile.WriteLine(SW_CES.GetCompanyPhoneExtensionField());
                outputFile.WriteLine(SW_CES.GeteMailAddress());//so.... ; break strings and leave it as null or change it to null
                outputFile.WriteLine(SW_CES.GetTypeofBusiness());//need to create unit testing
                outputFile.WriteLine(SW_CES.GetAddressLine1());
                outputFile.WriteLine(SW_CES.GetAddressLine2());
                outputFile.WriteLine(SW_CES.GetAddressCity());
                outputFile.WriteLine(SW_CES.GetAddressState());
                outputFile.WriteLine(SW_CES.GetAddressZipCode());
                outputFile.Flush();
            }
        }
    }

}
