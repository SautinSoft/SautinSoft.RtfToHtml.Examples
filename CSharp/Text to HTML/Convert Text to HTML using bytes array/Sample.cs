using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            // Read our RTF file a bytes array.
            string inpFile = @"..\..\example.txt";
            byte[] textBytes = File.ReadAllBytes(inpFile);

            // We'll use the file only for the demonstration.
            string outFile = @"Result.html";
            byte[] htmlBytes = null;

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Specify some properties for output HTML document.
            r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.HTML_5;
            r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8;
            r.TextStyle.Title = "Textual document.";

            try
            {                
                r.OpenText(textBytes);

                // Here we've got the HTML document as an array of bytes.
                htmlBytes = r.ToHtml();

                // Save our HTML into file and open it for the demonstration purposes.
                File.WriteAllBytes(outFile, htmlBytes);
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
