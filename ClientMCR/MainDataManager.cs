using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    static internal class MainDataManager
    {
        static string datadocPath = @"C:\DataMCR\companies";

        public static string GetDataDocPath()
        {
            return datadocPath;
        }

    }
}
