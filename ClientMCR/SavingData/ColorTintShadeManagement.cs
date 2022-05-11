using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR.SavingData
{
    public class ColorTintShadeManagement
    {
        //We create Ints to hold our Alpha, Red, Green and Blue colors when being converted.
        private int TopIntAlpha, TopIntRed, TopIntGreen, TopIntBlue;
        private int SecondaryIntAlpha, SecondaryIntRed, SecondaryIntGreen, SecondaryIntBlue;
        private int TextObjectIntAlpha, TextObjectIntRed, TextObjectIntGreen, TextObjectIntBlue;

        //string array is to hold our colors when reading from disk/file, size is 3 because there are 4 colors, remember we count element 0 as number 1.
        private string[] array = new string[3];

        //int array is to hold colors when converting them from string to int
        private int[] myColorArray = new int[3];

        //byte array is what we are returning to the calling method
        private byte[] myColorBytes = new byte[3];

        //we are getting the byte values from outside the class with this method and we are being told where it is going for what menu
        public void SetToColorSave(byte alpha, byte red, byte green, byte blue, string whereItsGoing)
        {
            //we have 3 different areas to place our colors
            //the first is topwindowtitle
            if (whereItsGoing == "TopWindowTitle")
            {
                //we are converting the byte for each one that was passed to us into an int to save 
                TopIntAlpha = ConvertByteColorToInt(alpha);
                TopIntRed = ConvertByteColorToInt(red);
                TopIntGreen = ConvertByteColorToInt(green);
                TopIntBlue = ConvertByteColorToInt(blue);
                //we are now calling the method savecolorstodisk passing it the string so it knows which one we are saving.
                SaveColorsToDisk("TopWindowTitle");

            }
            //we are converting the byte for each one that was passed to us into an int to save 
            else if (whereItsGoing == "SecondaryBackGround")
            {
                SecondaryIntAlpha = ConvertByteColorToInt(alpha);
                SecondaryIntRed = ConvertByteColorToInt(red);
                SecondaryIntGreen = ConvertByteColorToInt(green);
                SecondaryIntBlue = ConvertByteColorToInt(blue);
                //we are now calling the method savecolorstodisk passing it the string so it knows which one we are saving.
                SaveColorsToDisk("SecondaryBackGround");
            }
            //We are using an else if instead of just an else so we can keep track of the objects in our code explicetly so we dont "lose" them
            else if (whereItsGoing == "TextObject")
            {
                TextObjectIntAlpha = ConvertByteColorToInt(alpha);
                TextObjectIntRed = ConvertByteColorToInt(red);
                TextObjectIntGreen = ConvertByteColorToInt(green);
                TextObjectIntBlue = ConvertByteColorToInt(blue);
                //we are now calling the method savecolorstodisk passing it the string so it knows which one we are saving.
                SaveColorsToDisk("TextObject");
            }
        }

        //This is the method that does the actual saving to files.
        private void SaveColorsToDisk(string themeType)
        {
            //checking where to save it
            if (themeType == "TopWindowTitle")
            {
                try
                {
                    //using myDocs for now, will use a "user" folder later stored on server
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    try
                    {
                        //we are trying to create the directory CustomerManagement
                        Directory.CreateDirectory(docPath + "\\" + "CustomerManagement");
                    }
                    catch
                    {

                    }
                    // if the directory exists
                    if (Directory.Exists(docPath + "\\CustomerManagement"))
                    {
                        //we try and write our values that were provided to us earlier that we saved in our private ints
                        try
                        {
                            //trying to write to a file that we named since we are dealing with the TopWindowTitle
                            using (StreamWriter sw = new StreamWriter(Path.Combine(docPath + "\\CustomerManagement", "TopWindowTitle.txt")))
                            {
                                sw.WriteLine(TopIntAlpha.ToString());
                                sw.WriteLine(TopIntRed.ToString());
                                sw.WriteLine(TopIntGreen.ToString());
                                sw.WriteLine(TopIntBlue.ToString());
                                sw.Flush();
                                sw.Close();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                catch (UnauthorizedAccessException uAEx)
                {

                }
            }
            //checking where to save it
            else if (themeType == "SecondaryBackGround")
            {
                try
                {
                    //using myDocs for now, will use a "user" folder later stored on server
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    try
                    {
                        //we are trying to create the directory CustomerManagement
                        Directory.CreateDirectory(docPath + "\\" + "CustomerManagement");
                    }
                    catch
                    {

                    }
                    // if the directory exists
                    if (Directory.Exists(docPath + "\\CustomerManagement"))
                    {
                        //we try and write our values that were provided to us earlier that we saved in our private ints
                        try
                        {
                            //trying to write to a file that we named since we are dealing with the SecondaryBackGround
                            using (StreamWriter sw = new StreamWriter(Path.Combine(docPath + "\\CustomerManagement", "SecondaryBackGround.txt")))
                            {
                                sw.WriteLine(SecondaryIntAlpha.ToString());
                                sw.WriteLine(SecondaryIntRed.ToString());
                                sw.WriteLine(SecondaryIntGreen.ToString());
                                sw.WriteLine(SecondaryIntBlue.ToString());
                                sw.Flush();
                                sw.Close();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                catch (UnauthorizedAccessException uAEx)
                {

                }
            }
            //checking where to save it, its the last object we are dealing with but remember, we are coding it so we dont "lose" it
            else if (themeType == "TextObject")
            {
                try
                {
                    //using myDocs for now, will use a "user" folder later stored on server
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    try
                    {
                        //we are trying to create the directory CustomerManagement
                        Directory.CreateDirectory(docPath + "\\" + "CustomerManagement");
                    }
                    catch
                    {

                    }
                    // if the directory exists
                    if (Directory.Exists(docPath + "\\CustomerManagement"))
                    {
                        //we try and write our values that were provided to us earlier that we saved in our private ints
                        try
                        {
                            //trying to write to a file that we named since we are dealing with the TextObject
                            using (StreamWriter sw = new StreamWriter(Path.Combine(docPath + "\\CustomerManagement", "TextObject.txt")))
                            {
                                sw.WriteLine(TextObjectIntAlpha.ToString());
                                sw.WriteLine(TextObjectIntRed.ToString());
                                sw.WriteLine(TextObjectIntGreen.ToString());
                                sw.WriteLine(TextObjectIntBlue.ToString());
                                sw.Flush();
                                sw.Close();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                catch (UnauthorizedAccessException uAEx)
                {

                }
            }
        }
        //this is the method that provides the byte values in an byte array for the topwindowtitle
        public byte[] GetTopWindowTitle()
        {
            try
            {
                //still saved to mydocs so we try and read that folder
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //if the CustomerManagement folder exists
                if (Directory.Exists(docPath + "\\CustomerManagement"))
                {
                    //since this is the topwindow title we are using that as the txt file
                    string fileLocation = "TopWindowTitle.txt";
                    try
                    {
                        //using streamreader since thats what we use to get our file
                        using (StreamReader sr = new StreamReader(Path.Combine(docPath + "\\CustomerManagement", fileLocation)))
                        {
                            //we are using a loop to go through each readline and assigning it to the string array
                            for (int j = 0; j < 3; j++)
                            {
                                array[j] = sr.ReadLine();
                            }
                            //closing the strea reader object since we are done.
                            sr.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (UnauthorizedAccessException uAEx)
            {

            }
            //convert our strings to ints
            convertStringToInt();
            //convert our ints to bytes into the byte array
            convertIntToByte();
            //we return the byte array
            return myColorBytes;
        }

        //this is the method that provides the byte values in an byte array for the SecondaryBackGround
        public byte[] GetSecondaryBackGround()
        {
            try
            {
                //still saved to mydocs so we try and read that folder
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //if the CustomerManagement folder exists
                if (Directory.Exists(docPath + "\\CustomerManagement"))
                {
                    //since this is the SecondaryBackGround we are using that as the txt file
                    string fileLocation = "SecondaryBackGround.txt";
                    try
                    {
                        //using streamreader since thats what we use to get our file
                        using (StreamReader sr = new StreamReader(Path.Combine(docPath + "\\CustomerManagement", fileLocation)))
                        {
                            //we are using a loop to go through each readline and assigning it to the string array
                            for (int j = 0; j < 3; j++)
                            {
                                array[j] = sr.ReadLine();
                            }
                            //closing the strea reader object since we are done.
                            sr.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (UnauthorizedAccessException uAEx)
            {

            }
            //convert our strings to ints
            convertStringToInt();
            //convert our ints to bytes into the byte array
            convertIntToByte();
            //we return the byte array
            return myColorBytes;
        }

        //this is the method that provides the byte values in an byte array for the TextObject
        public byte[] GetTextObject()
        {
            try
            {
                //still saved to mydocs so we try and read that folder
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //if the CustomerManagement folder exists
                if (Directory.Exists(docPath + "\\CustomerManagement"))
                {
                    //since this is the SecondaryBackGround we are using that as the txt file
                    string fileLocation = "TextObject.txt";
                    try
                    {
                        //using streamreader since thats what we use to get our file
                        using (StreamReader sr = new StreamReader(Path.Combine(docPath + "\\CustomerManagement", fileLocation)))
                        {
                            //we are using a loop to go through each readline and assigning it to the string array
                            for (int j = 0; j < 3; j++)
                            {
                                array[j] = sr.ReadLine();
                            }
                            //closing the strea reader object since we are done.
                            sr.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (UnauthorizedAccessException uAEx)
            {

            }
            //convert our strings to ints
            convertStringToInt();
            //convert our ints to bytes into the byte array
            convertIntToByte();
            //we return the byte array
            return myColorBytes;
        }

        private void convertStringToInt()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    //we try and convert each string in the array over into the intarray with in the loop
                    Int32.TryParse(array[i], out myColorArray[i]);
                }
            }
            catch
            {

            }
        }
        private void convertIntToByte()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    //We are getting using the int array and we cast it into the byte array
                    myColorBytes[i] = (byte)myColorArray[i];
                }
            }
            catch
            {

            }
        }
        private int ConvertByteColorToInt(byte color)
        {
            //we are casting the color that is a byte into an int and saving the results into convertedResults
            int convertedResults = (int)color;
            return convertedResults;
        }
    }
}
