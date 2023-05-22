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
            SetCssStream();
        }
        /// <summary>
        /// This sample shows how to specify CSS Stream.
        /// </summary>
        static void SetCssStream()
        {
            string inpFile = @"..\..\example.docx";
            string outFile = @"Result.html";
            string cssFile = @"Styles.css";

            RtfToHtml r = new RtfToHtml();

            // Create a separate file to store css.
            FileStream fs = new FileStream(cssFile, FileMode.Create);

            HtmlFlowingSaveOptions opt = new HtmlFlowingSaveOptions()
            {
                CssStream = fs,
                KeepCssStreamOpen = false,
                CssExportMode = CssExportMode.External,
                CssFileName = cssFile,
                Title = "Working with CSS."
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