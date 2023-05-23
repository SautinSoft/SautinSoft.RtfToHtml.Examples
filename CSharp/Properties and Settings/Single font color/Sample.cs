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
            SetSingleFontColor();
        }
        /// <summary>
        /// How to convert to HTML document and set single font color a whole text.
        /// </summary>
        static void SetSingleFontColor()
        {
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            HtmlFixedSaveOptions opt = new HtmlFixedSaveOptions()
            {
                SingleFontColor = new Color(34, 139, 39) // Green
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