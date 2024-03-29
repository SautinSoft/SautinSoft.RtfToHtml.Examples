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
            ProduceOnlyHtmlBody();
        }
        /// <summary>
        /// How to produce HTML document only between &lt;body&gt;...&lt;/body&gt; tags.
        /// </summary>
        static void ProduceOnlyHtmlBody()
        {
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            // Set properties to produce HTML document only
            // between &lt;body&gt;...&lt;/body&gt; tags
            HtmlFlowingSaveOptions opt = new HtmlFlowingSaveOptions()
            {
                ProduceOnlyHtmlBody = true
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