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
            UseNumericCharacterReference();
        }
        /// <summary>
        /// This sample shows how to use Numeric Character Reference.
        /// </summary>
        static void UseNumericCharacterReference()
        {
            string inpFile = @"..\..\..\utf-8.rtf";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            RtfToHtml.HtmlFlowingSaveOptions opt = new RtfToHtml.HtmlFlowingSaveOptions()
            {
                UseNumericCharacterReference = true,
                Title = "UseNumericCharacterReference"
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