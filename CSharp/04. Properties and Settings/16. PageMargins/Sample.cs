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
            PageMargins();
        }
        /// <summary>
        /// Set page custom margins.
        /// </summary>
        static void PageMargins()
        {
			// Get your free 100-day key here:   
            // https://sautinsoft.com/start-for-free/
			
            // If you need more information about "RTF to HTML .Net" 
            // Email us at: support@sautinsoft.com.
			
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            // Set page margins 30 mm.
            RtfToHtml.HtmlFixedSaveOptions opt = new RtfToHtml.HtmlFixedSaveOptions()
            {
                Title = "Page Margins 30 mm",
                PageMargins = RtfToHtml.LengthUnitConverter.Convert(30, RtfToHtml.LengthUnit.Millimeter, RtfToHtml.LengthUnit.Point)
            };

            try
            {
                r.Convert(inpFile, outFile, opt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed! {ex.Message}");
            }

            // Open the result.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
        }
    }
}