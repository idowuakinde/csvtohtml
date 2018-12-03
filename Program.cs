using System;

namespace csvtohtml
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"/Users/greyjedi/TutorialsAndSamples/DotNet/Asp.Net Core 2/csvtohtml";

            int counter = 0;

            string line;

            string textToSend = @"<h1>Customers</h1>
            <table border=1>";

            System.IO.StreamReader file = new System.IO.StreamReader(filepath + @"/test.csv");

            while ((line = file.ReadLine()) != null)
            {
                string[] templine = line.Split(",");
                textToSend += "<tr>\n";

                if (counter == 0)
                {
                    // header row goes here
                    textToSend += "<th>" + templine[0] + "</th>\n";
                    textToSend += "<th>" + templine[1] + "</th>\n";
                    textToSend += "<th>" + templine[2] + "</th>\n";
                    textToSend += "<th>" + templine[3] + "</th>\n";
                }
                else
                {
                    // remaining rows go here
                    textToSend += "<td>" + templine[0] + "</td>\n";
                    textToSend += "<td>" + templine[1] + "</td>\n";
                    textToSend += "<td>" + templine[2] + "</td>\n";
                    textToSend += "<td>" + templine[3] + "</td>\n";
                }

                counter++;

                textToSend += "</tr>\n";
            }

            textToSend += "</table>";

            //System.Console.Write(textToSend);

            System.IO.File.WriteAllText(filepath + @"/test.html", textToSend);

            file.Close();

            System.Console.WriteLine("\n\nWrote {0} Customers to the page.", counter - 1);
        }
    }
}
