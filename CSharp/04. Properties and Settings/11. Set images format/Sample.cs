using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SautinSoft;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SetImagesFormat();
        }
        /// <summary>
        /// How to set images format.
        /// </summary>
        static void SetImagesFormat()
        {
			// Get your free key here:   
            // https://sautinsoft.com/start-for-free/
			
            // If you need more information about "RTF to HTML .Net" 
            // Email us at: support@sautinsoft.com.
			
            string inpFile = @"..\..\..\example.docx";
            string outFile = Path.GetFullPath(@"Result.html");
            string imgDir = Path.GetDirectoryName(outFile);

            RtfToHtml r = new RtfToHtml();

            // 1. Set PNG format.
            RtfToHtml.HtmlFixedSaveOptions opt = new RtfToHtml.HtmlFixedSaveOptions()
            {
                ImagesDirectoryPath = Path.Combine(imgDir, "Result_images"),
                ImagesDirectorySrcPath = "Result_images",
                // Change to store images as physical files on local drive.
                EmbedImages = false,
                ImageFormat = RtfToHtml.HtmlSaveOptions.ImagesFormat.Png,
                Title = "HTML document, PNG images"
            };
            try
            {
                r.Convert(inpFile, outFile, opt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed! {ex.Message}");
            }

            // Open the result.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
        }
    }
}