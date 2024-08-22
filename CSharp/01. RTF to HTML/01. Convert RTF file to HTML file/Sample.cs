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
            ConvertRtfToHtml();
        }
        /// <summary>
        /// Converts RTF file to HTML file.
        /// </summary>
        static void ConvertRtfToHtml()
        {
			
			// Get your free 100-day key here:   
            // https://sautinsoft.com/start-for-free/
			
            // If you need more information about "RTF to HTML .Net" 
            // Email us at: support@sautinsoft.com.

            string inpFile = @"..\..\..\example.rtf";
            string outfile = Path.GetFullPath("Result.html");
            
            RtfToHtml r = new RtfToHtml();
            r.Convert(inpFile, outfile, new RtfToHtml.HtmlFixedSaveOptions() {Title = "SautinSoft Example." });

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}