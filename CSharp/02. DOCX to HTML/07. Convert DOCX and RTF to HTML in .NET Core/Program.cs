using System;

namespace Sample
{
    internal class Sample
    {
        private static void Main(string[] args)
        {
            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            string inpFile1 = @"..\..\..\example.rtf";
            string inpFile2 = @"..\..\..\example.docx";
            string outFile1 = @"Result RTF.html";
            string outFile2 = @"Result DOCX.html";

            SautinSoft.RtfToHtml.HtmlFixedSaveOptions opt1 = new SautinSoft.RtfToHtml.HtmlFixedSaveOptions()
            {
                Title = "Produced from RTF.",
                EmbedImages = true,
            };
            SautinSoft.RtfToHtml.HtmlFixedSaveOptions opt2 = new SautinSoft.RtfToHtml.HtmlFixedSaveOptions()
            {
                Title = "Produced from DOCX.",
                EmbedImages = true,
            };

            try
            {
                r.Convert(inpFile1, outFile1, opt1);
                r.Convert(inpFile2, outFile2, opt2);

                // Open the results for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile1)
                { UseShellExecute = true });

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile2)
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