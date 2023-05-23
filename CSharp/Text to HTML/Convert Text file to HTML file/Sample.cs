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
        /// Converts Text file to HTML file.
        /// </summary>
        static void ConvertTextToHtml()
        {
            string inpFile = @"..\..\..\example.txt";
            string outfile = Path.GetFullPath("Result.html");
            
            RtfToHtml r = new RtfToHtml();
            r.Convert(inpFile, outfile, new HtmlFixedSaveOptions() {Title = "SautinSoft Example." });

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}