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
            SetHtmlVersion();
        }
        /// <summary>
        /// This sample shows how to set HTML version: xhtml, html5, html401, html32.
        /// </summary>
        static void SetHtmlVersion()
        {
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            // Let's convert to the HTML 3.2
            RtfToHtml.HtmlFlowingSaveOptions opt = new RtfToHtml.HtmlFlowingSaveOptions()
            {
                Version = RtfToHtml.HtmlVersion.Html32
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