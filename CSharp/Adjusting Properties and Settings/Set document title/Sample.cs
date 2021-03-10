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
            string outFile = @"Title.html";            

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Set document title, <title>...</title>
            r.TextStyle.Title = "Here is the custom TITLE!";

            // Set the folder to store images
            r.ImageStyle.ImageFolder = Path.GetDirectoryName(Path.GetFullPath(outFile));

            try
            {
                r.OpenRtf(inpFile);
                r.ToHtml(outFile);

                // Open the results for demonstration purposes.
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
