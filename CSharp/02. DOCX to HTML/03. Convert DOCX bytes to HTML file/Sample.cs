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
        /// Convert DOCX bytes to HTML file.
        /// </summary>
        static void ConvertDocxToHtml()
        {
            // This file is necessary to get DOCX content as byte array.
            string inpFile = @"..\..\..\example.docx";
            byte[] docxBytes = File.ReadAllBytes(inpFile);

            string outfile = Path.GetFullPath("Result.html");

            RtfToHtml r = new RtfToHtml();

            using (MemoryStream inpMS = new MemoryStream(docxBytes))
            {
                using (MemoryStream outMS = new MemoryStream())
                {
                    r.Convert(inpMS, outMS, new RtfToHtml.HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
                    File.WriteAllBytes(outfile, outMS.ToArray());
                }
            }            

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}