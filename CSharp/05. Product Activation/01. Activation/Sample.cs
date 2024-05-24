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
            Activation();
        }
        /// <summary>
        /// How to activate SautinSoft.RtfToHtml component.
        /// </summary>
        static void Activation()
        {
            // You will get own serial number after purchasing the license.
            // If you will have any questions, email us to sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.
            // Let us say, you have this key: 1234567890.            

            RtfToHtml.SetLicense("1234567890");
            // Activation of Rtf To Html .Net after purchasing.
 
			RtfToHtml r = new RtfToHtml();

            string inpFile = @"..\..\..\example.docx";
            string outFile = "Result.html";

            r.Convert(inpFile, outFile, new RtfToHtml.HtmlFixedSaveOptions() { Title = "SautinSoft.RtfToHtml Activation" });

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
        }
    }
}