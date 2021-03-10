using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            // We'll use the files only for the demonstration, 
            // the whole conversion will be done using MemoryStream.
            string inpFile = @"..\..\example.txt";
            string outFile = @"Result.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Specify some properties for output HTML document.
            r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.HTML_5;
            r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8;
            r.TextStyle.Title = "Textual document.";

            try
            {
                using (FileStream textFileStream = new FileStream(inpFile, FileMode.Open))
                {
                    r.OpenText(textFileStream);
                    using (MemoryStream htmlMemoryStream = new MemoryStream())
                    {
                        // Here we've got the HTML document as an array of bytes.
                        r.ToHtml(htmlMemoryStream);

                        // Save our HTML into file and open it for the demonstration purposes.
                        File.WriteAllBytes(outFile, htmlMemoryStream.ToArray());
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile)
                        { UseShellExecute = true });
                    }
                }
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
