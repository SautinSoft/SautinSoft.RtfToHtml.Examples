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
            SetCssStream();
        }
        /// <summary>
        /// This sample shows how to specify CSS Stream.
        /// </summary>
        static void SetCssStream()
        {
			// Get your free key here:   
            // https://sautinsoft.com/start-for-free/
			
            // If you need more information about "RTF to HTML .Net" 
            // Email us at: support@sautinsoft.com.
			
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";
            string cssFile = @"Styles.css";

            RtfToHtml r = new RtfToHtml();

            // Create a separate file to store css.
            FileStream fs = new FileStream(cssFile, FileMode.Create);

            RtfToHtml.HtmlFlowingSaveOptions opt = new RtfToHtml.HtmlFlowingSaveOptions()
            {
                CssStream = fs,
                KeepCssStreamOpen = false,
                CssExportMode = RtfToHtml.CssExportMode.External,
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