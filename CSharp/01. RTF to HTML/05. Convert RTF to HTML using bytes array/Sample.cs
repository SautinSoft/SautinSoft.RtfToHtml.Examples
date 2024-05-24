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
        /// Converts RTF to HTML using arrays of bytes.
        /// </summary>
        static void ConvertRtfToHtml()
        {
            // The files are necessary only to get input data and show the result.
            string inpFile = @"..\..\..\example.rtf";
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