using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    internal class CompanyRecordCreate
    {
        //we are taking the companyentityclass that was passed to us and we are saving it to a file/database in this class.
        //SW_CES is CompanyEntityClass
        CompanyEntityClass SW_CES;
        public static async void CRC(CompanyEntityClass SW_CES)
        {
            if (SW_CES != null)
            {
                // Set a variable to the Documents path.
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                SW_CES.GetCompanyNameField();
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteTextAsync.txt")))//Path.Combine(docPath, 
                {
                    await outputFile.WriteLineAsync(SW_CES.GetCompanyNameField());
                    await outputFile.WriteLineAsync(SW_CES.GetEntityIDFieldString());//try/catch not completed for int to string conversion
                    await outputFile.WriteLineAsync(SW_CES.GetCompanyIDField());
                    await outputFile.WriteLineAsync(SW_CES.GetCompanyPhoneNumberField());//variable should be an int and not a string inside SW_CES
                    await outputFile.WriteLineAsync(SW_CES.GeteMailAddress());//so.... ; break strings and leave it as null or change it to null
                    await outputFile.WriteLineAsync(SW_CES.GetTypeofBusiness());//need to create unit testing
                    await outputFile.WriteLineAsync(SW_CES.GetAddressLine1());
                    await outputFile.WriteLineAsync(SW_CES.GetAddressLine2());
                    await outputFile.WriteLineAsync(SW_CES.GetAddressCity());
                    await outputFile.WriteLineAsync(SW_CES.GetAddressState());
                    await outputFile.WriteLineAsync(SW_CES.GetAddressZipCode());
                    await outputFile.FlushAsync();
                }


            }
        }
    }
}
