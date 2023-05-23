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
            PageMargins();
        }
        /// <summary>
        /// Set page custom margins.
        /// </summary>
        static void PageMargins()
        {
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            // Set page margins 30 mm.
            HtmlFixedSaveOptions opt = new HtmlFixedSaveOptions()
            {
                Title = "Page Margins 30 mm",
                PageMargins = LengthUnitConverter.Convert(30, LengthUnit.Millimeter, LengthUnit.Point)
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