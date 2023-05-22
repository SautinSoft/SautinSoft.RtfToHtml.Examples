using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SautinSoft.RtfToHtml;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertTextToHtml();
        }
        /// <summary>
        /// Converts Text file to HTML string.
        /// </summary>
        static void ConvertTextToHtml()
        {
            string inpFile = @"..\..\example.txt";
            string htmlString = String.Empty;
            
            RtfToHtml r = new RtfToHtml();

            using (StreamReader inpReader = new StreamReader(inpFile))
            {
                using (MemoryStream resultStream = new MemoryStream())
                {
                    r.Convert(inpReader.BaseStream, resultStream, new HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
                    htmlString = Encoding.UTF8.GetString(resultStream.ToArray());
                }
            }            

            // This file is necessary only to show the result.
            string outfile = Path.GetFullPath("Result.html");
            File.WriteAllText(outfile, htmlString);

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}