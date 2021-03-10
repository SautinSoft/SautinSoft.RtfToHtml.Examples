using System;
using System.IO;
using System.Text;

namespace SampleConvert
{
	class sample
	{
		static void Main(string[] args)
		{
            string inpFile = @"..\..\images.rtf";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            try
            {
                r.OpenRtf(inpFile);

                // Case "1" - store image as separate *.png files in subfolder "filename.images".
                string outFile = Path.Combine(Directory.GetCurrentDirectory(), "case 1.html");

                // The image folder must be already existed.
                r.ImageStyle.ImageFolder = Path.GetDirectoryName(outFile);

                // If subfolder is not exist, it will be created by the component.
                r.ImageStyle.ImageSubFolder = "case 1.images";

                // A template name for images.
                r.ImageStyle.ImageFileName = "picture";

                // Don't embed images inside HTML document.
                r.ImageStyle.IncludeImageInHtml = false;

                // Assume, that we already have 100 images in the subfolder, let's start to name images from 101.
                r.ImageStyle.ImageNumStart = 101;
                r.ImageStyle.ImagesFormat = SautinSoft.RtfToHtml.eImageFormat.Png;

                // Case "1" - convert to HTML and Show the result.
                r.TextStyle.Title = "Case 1 - PNG files";
                r.ToHtml(outFile);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile)
                { UseShellExecute = true });

                // Case "2" - store image as separate *.jpeg files in subfolder "filename.images".
                outFile = Path.Combine(Directory.GetCurrentDirectory(), "case 2.html");
                r.ImageStyle.ImagesFormat = SautinSoft.RtfToHtml.eImageFormat.Jpg;
                r.TextStyle.Title = "Case 2 - JPEG files";
                r.ToHtml(outFile);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile)
                { UseShellExecute = true });

                // Case "3" - skip images.
                outFile = Path.Combine(Directory.GetCurrentDirectory(), "case 3.html");
                r.ImageStyle.PreserveImages = false;
                r.TextStyle.Title = "Case 3 - No images";
                r.ToHtml(outFile);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile)
                { UseShellExecute = true });

                // Case "4" - embed images inside HTML document using base64.
                outFile = Path.Combine(Directory.GetCurrentDirectory(), "case 4.html");
                r.ImageStyle.PreserveImages = true;
                r.ImageStyle.IncludeImageInHtml = true;
                r.TextStyle.Title = "Case 4 - Embedded images";
                r.ToHtml(outFile);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile)
                { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press any key ...");
                Console.ReadKey();
            }
		}
	}
}
