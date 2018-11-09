using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Getting_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string line;
            string strValfromLine=string.Empty;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =new System.IO.StreamReader(@"D:\TextWork\TxtOne.txt");

            System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"D:\TextWork\Json.txt");

            int i = 1;
            while ((line = file.ReadLine()) != null)
            {
               
                string line_trim = line.Trim();

                if (line_trim!="" && line_trim!=null)
                {
                    if (line_trim.Contains("value"))
                    {
                        
                        int indexOfEquals = line_trim.IndexOf('=');
                        int indexOfLessMark = line_trim.IndexOf('>');
                        strValfromLine = line_trim.Substring(indexOfEquals+1,indexOfLessMark - indexOfEquals-1);


                    }

                    int cutIndex = 2;
                    string cutString = line_trim.Substring(cutIndex, line_trim.Length - cutIndex);
                    // System.Console.WriteLine(line);
                    
                   

                        // If the line doesn't contain the word 'Second', write the line to the file.
                        if (line_trim != null)
                        {
                
                            int startIndex = cutString.IndexOf(">") + ">".Length;

                            int endIndex = cutString.IndexOf("<") + "<".Length;

                           if(startIndex > 0 && endIndex > 0)
                            {
                            string newString = cutString.Substring(startIndex, endIndex - startIndex - 1);
                            //file2.WriteLine(newString.ToString()+"\r\n");


                            // start txt string format
                            string strTxt1 = @"""text""";
                            string strColon = ": ";
                            string strTxt2 = @"+"+newString.Trim()+"+";
                             strTxt2 = strTxt2.Replace('+','"');

                            // get complete  "text": "ARUBA (ABW)"
                            string getTxt = strTxt1 + strColon + strTxt2;
                            // End txt string format

                            //Start value string formate
                            // start txt string format
                            string strVal1 = @"""value""";
                            string strColon2 = ": ";
                            string strItem = "";

                            // strItem = "item"+i;
                            strItem = strValfromLine;
                            i++;

                            // string strVal2 = @"+" + strItem + "+";
                            string strVal2 = @"+" + strTxt2 + "+";
                            strVal2 = strVal2.Replace('+', ' ');

                            // get complete  "text": "ARUBA (ABW)"
                            string getValue = strVal1 + strColon2 + strVal2.Trim();

                            //End value string formate


                            file2.WriteLine("{");
                            file2.WriteLine(getValue+",");
                            file2.WriteLine(getTxt);
                            file2.WriteLine("},");

                        }
  
                        }

                }

                
            }

            file.Close();
            file2.Close();
           // System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
          //  System.Console.ReadLine();
        }
    }
}
