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
            ConvertTextToHtml();
        }
        /// <summary>
        /// Converts Text to HTML using arrays of bytes.
        /// </summary>
        static void ConvertTextToHtml()
        {
			// Get your free 100-day key here:   
            // https://sautinsoft.com/start-for-free/
			
            // If you need more information about "RTF to HTML .Net" 
            // Email us at: support@sautinsoft.com.
			
            // The files are necessary only to get input data and show the result.
            string inpFile = @"..\..\..\example.txt";
            string outfile = Path.GetFullPath("Result.html");


            byte[] rtfBytes = File.ReadAllBytes(inpFile);
            byte[] htmlBytes = null;
            
            RtfToHtml r = new RtfToHtml();

            using (MemoryStream inpMS = new MemoryStream(rtfBytes))
            {
                using (MemoryStream outMS = new MemoryStream())
                {
                    r.Convert(inpMS, outMS, new RtfToHtml.HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
                    htmlBytes = outMS.ToArray();
                }
            }
            
            File.WriteAllBytes(outfile, htmlBytes);

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}