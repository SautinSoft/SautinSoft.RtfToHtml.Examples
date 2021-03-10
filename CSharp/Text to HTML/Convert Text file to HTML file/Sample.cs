using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            string inpFile = @"..\..\example.txt";
            string outFile = @"Result.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Specify some properties for output HTML document.
            r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.HTML_5;
            r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8;
			r.TextStyle.Title = "Textual document.";

            try
            {
                r.OpenText(inpFile);                
                r.ToHtml(outFile);

                // Open the result for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile)
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
