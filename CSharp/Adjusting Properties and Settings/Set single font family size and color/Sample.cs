using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            string inpFile = Path.GetFullPath(@"..\..\example.rtf");
            string outFileOriginalFonts = @"Original Fonts.html";
            string outFileSingleFont = @"Single Font.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Skip images.
            r.ImageStyle.PreserveImages = false;

            try
            {
                r.OpenRtf(inpFile);

                // Specify the title.
                r.TextStyle.Title = "Original Fonts";

                // Convert to HTML.
                r.ToHtml(outFileOriginalFonts);

                // Specify the title.
                r.TextStyle.Title = "Single Font";

                // Set single font family, size and color.            
                r.TextStyle.FontColor.SetRGB(6, 85, 53);
                r.TextStyle.FontFace = "Verdana";
                r.TextStyle.FontSize = 18;

                // Convert to HTML.
                r.ToHtml(outFileSingleFont);

                // Open the results for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileOriginalFonts)
                { UseShellExecute = true });
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileSingleFont)
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
