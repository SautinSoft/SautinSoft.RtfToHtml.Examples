using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            string inpFile = @"..\..\example.rtf";
            string outFileInlineCSS = @"Inline CSS.html";
            string outFileClassCSS = @"Class CSS.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Skip images.
            r.ImageStyle.PreserveImages = false;

            try
            {
                r.OpenRtf(inpFile);

                // Specify the title.
                r.TextStyle.Title = "Inline CSS";

                // Generate inline CSS.
                r.TextStyle.InlineCSS = true;

                // Convert to HTML.
                r.ToHtml(outFileInlineCSS);

                // Specify the title.
                r.TextStyle.Title = "Class CSS";

                // Store CSS using the attribute "class".            
                r.TextStyle.InlineCSS = false;
                r.TextStyle.StyleName = "style";
                r.TextStyle.StartCSSNumber = 100;

                // Convert to HTML.
                r.ToHtml(outFileClassCSS);

                // Open the results for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileInlineCSS)
                { UseShellExecute = true });
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileClassCSS)
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
