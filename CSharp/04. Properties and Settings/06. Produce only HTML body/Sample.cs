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
            ProduceOnlyHtmlBody();
        }
        /// <summary>
        /// How to produce HTML document only between &lt;body&gt;...&lt;/body&gt; tags.
        /// </summary>
        static void ProduceOnlyHtmlBody()
        {
			// Get your free 100-day key here:   
            // https://sautinsoft.com/start-for-free/
			
            // If you need more information about "RTF to HTML .Net" 
            // Email us at: support@sautinsoft.com.
			
            string inpFile = @"..\..\..\example.docx";
            string outFile = @"Result.html";

            RtfToHtml r = new RtfToHtml();

            // Set properties to produce HTML document only
            // between &lt;body&gt;...&lt;/body&gt; tags
            RtfToHtml.HtmlFlowingSaveOptions opt = new RtfToHtml.HtmlFlowingSaveOptions()
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