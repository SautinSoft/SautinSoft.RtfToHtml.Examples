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
            PageIndexAndCount();
        }
        /// <summary>
        /// Let's convert 1st, 3rd and 5th pages.
        /// </summary>
        static void PageIndexAndCount()
        {
            string inpFile = @"..\..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            // Let's convert pages: 1, 3 and 5.
            HtmlFixedSaveOptions opt = new HtmlFixedSaveOptions()
            {
                Title = "Pages 1, 3, 5",
                SelectedPages = new int[] {0, 2, 4}
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