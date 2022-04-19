using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClientMCR
{

    internal class BackgoundColor
    {
        //The last two hex are the alpha
        static string OurBackGroundHexColorTanagerTurquoise = "#95DBE5FF";
        static string OurBackGroundHexColorKellyGreen = "#339E66FF";
        static string OurBackGroundHexColorTealBlue = "#078282FF";
        static string HexColorTanagerTurquoise = "95DBE5FF";

        static string HexColorKellyGreen = "339E66FF";
        static string StringHexColorKellyGreen1 = "33";
        static string StringHexColorKellyGreen2 = "9E";
        static string StringHexColorKellyGreen3 = "66";
        static string StringHexColorKellyGreen4 = "ff";

        //these variabls are the math done for you from hex to dec for the rgb and alpha values
        static byte byteHexColorKellyGreen1 = (3 * 16) + 3;
        static byte byteHexColorKellyGreen2 = (9 * 16) + 14;
        static byte byteHexColorKellyGreen3 = (6 * 16) + 6;
        static byte byteHexColorKellyGreen4 = (14 * 16) + 14;

        //this was challenging for me so i had to poke fun at code
        List<byte> myByteListFromHell = new List<byte>();
        


        static string HexColorTealBlue = "078282FF";


        internal static string GetHTMLColorTanagerTurquoise()
        {
            return OurBackGroundHexColorTanagerTurquoise;
        }
        internal static string GetHTMLColorKellyGreen()
        {
            return OurBackGroundHexColorKellyGreen;
        }
        internal static string GetHTMLColorTealBlue()
        {
            return OurBackGroundHexColorTealBlue;
        }
        internal static string GetHexColorTanagerTurquoise()
        {
            return OurBackGroundHexColorTanagerTurquoise;
        }
        internal static string GetHexColorKellyGreen()
        {
            return OurBackGroundHexColorKellyGreen;
        }
        internal static string GetHexColorTealBlue()
        {
            return OurBackGroundHexColorTealBlue;
        }

        internal List<byte> GetTestColor()
        {
            myByteListFromHell.Add(byteHexColorKellyGreen1);
            myByteListFromHell.Add(byteHexColorKellyGreen2);
            myByteListFromHell.Add(byteHexColorKellyGreen3);
            myByteListFromHell.Add(byteHexColorKellyGreen4);

            return myByteListFromHell;
        }

    }
}
