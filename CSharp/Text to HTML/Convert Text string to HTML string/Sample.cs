using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            // Read our Text file as string.
            string inpFile = @"..\..\example.txt";
            string textString = File.ReadAllText(inpFile);

            // We'll use the file only for the demonstration.
            string outFile = @"Result.html";
            string htmlString = String.Empty;

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Specify some properties for output HTML document.
            r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.HTML_5;
            r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8;
            r.TextStyle.Title = "Textual document.";

            try
            {
                r.OpenTextFromString(textString);

                // Here we've got the HTML document as string.
                r.ToHtml(out htmlString);

                // Save our HTML into file and open it for the demonstration purposes.
                File.WriteAllText(outFile, htmlString);
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
