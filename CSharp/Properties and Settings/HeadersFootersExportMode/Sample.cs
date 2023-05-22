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
            HeadersFootersExportMode();
        }
        /// <summary>
        /// This sample shows how to export headers and footers.
        /// </summary>
        static void HeadersFootersExportMode()
        {
            string inpFile = @"..\..\doc with header and footer.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            HtmlFlowingSaveOptions opt = new HtmlFlowingSaveOptions()
            {
                HeadersFootersExportMode = HtmlHeadersFootersExportMode.FirstSectionHeaderLastSectionFooter
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