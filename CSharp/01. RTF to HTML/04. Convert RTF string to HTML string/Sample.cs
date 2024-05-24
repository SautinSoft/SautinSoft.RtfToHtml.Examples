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
        /// Converts RTF string to HTML string.
        /// </summary>
        static void ConvertRtfToHtml()
        {
            string inpFile = @"..\..\..\example.rtf";
            string rtfString = File.ReadAllText(inpFile);
            string htmlString = String.Empty;
            
            RtfToHtml r = new RtfToHtml();

            using (MemoryStream inpMS = new MemoryStream(Encoding.UTF8.GetBytes(rtfString)))
            {
                using (MemoryStream outMS = new MemoryStream())
                {
                    r.Convert(inpMS, outMS, new RtfToHtml.HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
                    htmlString = Encoding.UTF8.GetString(outMS.ToArray());
                }
            }            

            // This file is necessary only to show the result.
            string outfile = Path.GetFullPath("Result.html");
            File.WriteAllText(outfile, htmlString);

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outfile) { UseShellExecute = true });
        }
    }
}