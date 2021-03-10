using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            string inpFile = @"..\..\links.rtf";
            string outFileNotDetected = @"detect false.html";
            string outFileDetected = @"detect true.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            try
            {
                r.OpenRtf(inpFile);

                // Don't detect hyperlinks from text, convert only real hyperlinks.
                r.TextStyle.HyperlinkDetect = false;
                r.TextStyle.Title = "HyperlinkDetect = false";
                r.ToHtml(outFileNotDetected);

                // Automatically detect hyperlinks from text.
                r.TextStyle.HyperlinkDetect = true;
                r.TextStyle.HyperlinkTarget = SautinSoft.RtfToHtml.eHyperlinkTarget.Blank;
                r.TextStyle.Title = "HyperlinkDetect = true";
                r.ToHtml(outFileDetected);

                // Open the results for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileNotDetected)
                { UseShellExecute = true });
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileDetected)
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
