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
            ConvertDocxToHtml();
        }
        /// <summary>
        /// Converts DOCX to HTML using MemoryStream objects.
        /// </summary>
        static void ConvertDocxToHtml()
        {
            // The files are necessary only to get input data and show the result.
            string inpFile = @"..\..\..\..\example.docx";
            string outfile = Path.GetFullPath("Result.html");
            
            RtfToHtml r = new RtfToHtml();

            using (MemoryStream inpMS = new MemoryStream(File.ReadAllBytes(inpFile)))
            {
                using (MemoryStream outMS = new MemoryStream())
                {
                    r.Convert(inpMS, outMS, new HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
                    // Save the result from MemoryStream to the file to show the result.
                    File.WriteAllBytes(outfile, outMS.ToArray());
                }
            }            

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}