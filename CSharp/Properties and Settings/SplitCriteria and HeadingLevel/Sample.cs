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
            SplitCriteria();
        }
        /// <summary>
        /// Specifies how the document should be split when saving to Html format.
        /// </summary>
        static void SplitCriteria()
        {
            string inpFile = @"..\..\..\toc.docx";
            string outFile = @"toc.html";

            RtfToHtml r = new RtfToHtml();

            HtmlFlowingSaveOptions opt = new HtmlFlowingSaveOptions()
            {
                SplitCriteria = HtmlSplitCriteria.PageBreak,
                SplitHeadingLevel = 2
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