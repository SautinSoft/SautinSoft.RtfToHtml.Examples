using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            string inpFile = @"..\..\unicode.rtf";
            string outFileNCR = @"NCR.html";
            string outFileNoNCR = @"Without NCR.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();            

            try
            {
                r.OpenRtf(inpFile);

                // Set to use NCR (Numeric Character Reference), in other words
                // write characters as &#XXXX;
                r.UseNumericCharacterReference = true;
                r.TextStyle.Title = "NCR";
                r.ToHtml(outFileNCR);

                // Don't use NCR, write characters us Unicode (utf-8), like a: på taket är en figur. 
                r.UseNumericCharacterReference = false;
                r.TextStyle.Title = "Without NCR";
                r.ToHtml(outFileNoNCR);

                // Open the results for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileNCR)
                { UseShellExecute = true });
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileNoNCR)
                { UseShellExecute = true });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Press any key ...");
                Console.ReadKey();
            }
        }
    }
}
