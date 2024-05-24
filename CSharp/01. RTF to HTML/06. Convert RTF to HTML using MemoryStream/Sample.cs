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
        /// Converts RTF to HTML using MemoryStream objects.
        /// </summary>
        static void ConvertRtfToHtml()
        {
            // The files are necessary only to get input data and show the result.
            string inpFile = @"..\..\..\example.rtf";
            string outfile = Path.GetFullPath("Result.html");
            
            RtfToHtml r = new RtfToHtml();

            using (MemoryStream inpMS = new MemoryStream(File.ReadAllBytes(inpFile)))
            {
                using (MemoryStream outMS = new MemoryStream())
                {
                    r.Convert(inpMS, outMS, new RtfToHtml.HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
                    // Save the result from MemoryStream to the file to show the result.
                    File.WriteAllBytes(outfile, outMS.ToArray());
                }
            }            

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}