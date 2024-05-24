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
            ListExportMode();
        }
        /// <summary>
        /// This sample shows how to specify list export mode.
        /// </summary>
        static void ListExportMode()
        {
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            // Use <p> tags for list elements.
            RtfToHtml.HtmlFlowingSaveOptions opt = new RtfToHtml.HtmlFlowingSaveOptions()
            {
                ListExportMode = RtfToHtml.HtmlListExportMode.AsInlineText
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