using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SautinSoft;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertDocxToHtml();
        }
        /// <summary>
        /// Convert DOCX file to HTML file.
        /// </summary>
        static void ConvertDocxToHtml()
        {
            string inpFile = @"..\..\..\example.docx";
            string outfile = Path.GetFullPath("Result.html");
            
            RtfToHtml r = new RtfToHtml();
            r.Convert(inpFile, outfile, new RtfToHtml.HtmlFixedSaveOptions() {Title = "SautinSoft Example." });

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}