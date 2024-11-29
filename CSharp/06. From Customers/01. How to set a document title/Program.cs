using System;
using System.IO;
using System.Text;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            string inpFile = @"..\..\..\Images.rtf";
            string outFile = @"..\..\..\Title.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
            SautinSoft.RtfToHtml.HtmlFixedSaveOptions opt = new SautinSoft.RtfToHtml.HtmlFixedSaveOptions
            {
                // Set document title, <title>...</title>
                Title = "Here is the custom TITLE!",
                // If you want to disable embedded images
                EmbedImages = false,
                // Set the folder to store images
                ImagesDirectoryPath = @"..\..\..\Images",
                // Set the folder in <image src="..." >
                ImagesDirectorySrcPath = "Images"
            };

            try
            {
                r.Convert(inpFile, outFile, opt);

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

