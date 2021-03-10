using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            // Read our DOCX document as bytes array.
            string inpFile = @"..\..\example.docx";
            byte[] docxBytes = File.ReadAllBytes(inpFile);

            string outFile = @"Result.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Specify some properties for output HTML document.
            r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.HTML_5;
            r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8;

            // Imagefolder must already exist.
            r.ImageStyle.ImageFolder = System.Environment.CurrentDirectory;

            // Subfolder for images will be created by the component.
            r.ImageStyle.ImageSubFolder = "image.files";

            // A template name for images.
            r.ImageStyle.ImageFileName = "picture";

            // false - store images as files on HDD,
            // true - store images inside HTML document using base64.
            r.ImageStyle.IncludeImageInHtml = false;

            try
            {
                r.OpenDocx(docxBytes);
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
