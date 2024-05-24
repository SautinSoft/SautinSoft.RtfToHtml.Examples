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
            BuildNavigationPage();
        }
        /// <summary>
        /// This sample shows how to generate a navigation page (like a TOC - table of contents).
        /// </summary>
        static void BuildNavigationPage()
        {
            string inpFile = @"..\..\..\toc.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            RtfToHtml.HtmlFlowingSaveOptions opt = new RtfToHtml.HtmlFlowingSaveOptions()
            {
                BuildNavigationPage = false
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