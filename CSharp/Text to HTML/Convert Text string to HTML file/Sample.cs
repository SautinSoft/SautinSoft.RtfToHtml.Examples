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
        /// Converts Text string to HTML file.
        /// </summary>
        static void ConvertTextToHtml()
        {
            // This file is necessary to get Text content as string.
            string inpFile = @"..\..\example.txt";
            string rtfString = File.ReadAllText(inpFile);

            string outfile = Path.GetFullPath("Result.html");

            RtfToHtml r = new RtfToHtml();

            using (MemoryStream inpMs = new MemoryStream(Encoding.UTF8.GetBytes(rtfString)))
            {
                using (MemoryStream resMs = new MemoryStream())
                {
                    r.Convert(inpMs, resMs, new HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
                    File.WriteAllBytes(outfile, resMs.ToArray());
                }
            }            

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}