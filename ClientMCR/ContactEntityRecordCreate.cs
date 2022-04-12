using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClientMCR
{
    internal class ContactEntityRecordCreate
    {
        static int secondsInMinute = 60;
        static int timeToWait;
        static int newDirectoryToCreate;
        static string stringNewDirectoryToCreate;
        static string datadocPath = @"C:\DataMCR";
        static string companyDatadocPath;
        static string stringCompanyEntityID;
        //public static int AssignEntityID(int companyEntityID)
        //{

        //}
        //static async void directoryMonitor(string directoryToMonitor)
        //{
        //    timeToWait = secondsInMinute * 60;
        //    await Task.Delay(TimeSpan.FromSeconds(timeToWait));
        //    if (File.Exists(directoryToMonitor + "\\contactdata.txt"))
        //    {

        //    }
        //    else
        //    {
        //        Directory.Delete(directoryToMonitor);
        //    }

        //}

        ContactEntityClass ContactEC;
        //CRC stands for CompanyRecordCreate
        public static int ContactRecordCreate(ContactEntityClass ContactEC)
        {
            if (ContactEC != null)
            {
                int lastCreatedDirectory;
                try
                {
                    //when trying to get to the path to the root directly with directory enumerateDirectoreis
                    //it adds on the path to C:\Future Company Projects\ClientMCR\ClientMCR\ClientMCR\bin\Debug\net6.0-windows
                    try
                    {
                        stringCompanyEntityID = ContactEC.GetCompanyEntityIDFieldString();
                    }
                    catch (Exception)
                    {
                        //DO SOMETHING HERE
                        //Exception
                    }


                    List<string> dirs = new List<string>(Directory.EnumerateDirectories(datadocPath + "\\" + stringCompanyEntityID + "\\" + "contacts"));

                    int numberOfDirs = dirs.Count();
                    //commented out for optimization
                    //if(dirs.Count() == 0)
                    //{
                    //    Directory.CreateDirectory(datadocPath + "\\" + "1000000000");
                    //}

                    dirs.Sort();
                    //we are accessing the position inside the list of dirs and assigning the value to a string
                    string lastDir = dirs[numberOfDirs - 1];

                    //This code should work "assuming" that we are accounting for all the spaces and that the following directory structure hasn't changed. e.i
                    //@"C:\DataMCR" + "\\" + "1000000000" + "\\" + "contacts"+ "\\" + "1000000000"
                    string newLastDir = lastDir.Remove(0, 31);
                    //string newLastDir = lastDir.TrimStart('C',':','\\','D','a','t','a','M','C','R','\\');
                    //we are now getting the number value of the directory
                    int.TryParse(newLastDir, out lastCreatedDirectory);
                    newDirectoryToCreate = lastCreatedDirectory + 1;
                    stringNewDirectoryToCreate = newDirectoryToCreate.ToString();
                    Directory.CreateDirectory(datadocPath + "\\" + stringCompanyEntityID + "\\" + "contacts" + "\\" + stringNewDirectoryToCreate);
                    companyDatadocPath = datadocPath + "\\" + stringCompanyEntityID + "\\" + "contacts" + "\\" + stringNewDirectoryToCreate;

                    //now that the directory is created, we are going to verify that it is being used other wise we are going to delete it.
                    //directoryMonitor(datadocPath + "\\" + stringNewDirectoryToCreate);
                }


                //try
                //{
                //    //Directory.CreateDirectory()

                //    int fileCount = 0;
                //    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //    var files = from file in Directory.EnumerateFiles(docPath, "*.txt", SearchOption.TopDirectoryOnly) //AllDirectories
                //                from line in File.ReadLines(file)
                //                where line.Contains("phone")
                //                select new
                //                {
                //                    File = file,
                //                    Line = line
                //                };

                //    foreach (var f in files)
                //    {
                //        fileCount++;

                //        //Console.WriteLine($"{f.File}\t{f.Line}");
                //    }
                //        return fileCount;
                //}
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
                // Set a variable to the Documents path.  Commented out cause we are not using windows mydocs
                //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(companyDatadocPath, "contactdata.txt")))//Path.Combine(docPath, 
                {
                    outputFile.WriteLine(ContactEC.GetContactNameField());
                    outputFile.WriteLine(stringNewDirectoryToCreate);//try/catch not completed for int to string conversion
                    outputFile.WriteLine(ContactEC.GetCompanyEntityIDFieldString());
                    outputFile.WriteLine(ContactEC.GetContactPhoneNumberField());//variable should be an int and not a string inside SW_CES
                    outputFile.WriteLine(ContactEC.GetContactPhoneNumberExtensionField());
                    outputFile.WriteLine(ContactEC.GeteMailAddress());//so.... ; break strings and leave it as null or change it to null
                    outputFile.WriteLine(ContactEC.GetAddressLine1());
                    outputFile.WriteLine(ContactEC.GetAddressLine2());
                    outputFile.WriteLine(ContactEC.GetAddressCity());
                    outputFile.WriteLine(ContactEC.GetAddressState());
                    outputFile.WriteLine(ContactEC.GetAddressZipCode());
                    outputFile.Flush();
                }

            }
            //create method that informs the client that the save has completed.
            //return 1;
            return newDirectoryToCreate;
        }
    }

}
