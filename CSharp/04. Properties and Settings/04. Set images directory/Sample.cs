using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SautinSoft.RtfToHtml;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SetImagesDirectory();
        }
        /// <summary>
        /// How to set directory to store images.
        /// </summary>
        static void SetImagesDirectory()
        {
            string inpFile = @"..\..\..\..\example.docx";
            string outFile = Path.GetFullPath(@"Result2.html");
            string imgDir = Path.GetDirectoryName(outFile);

            RtfToHtml r = new RtfToHtml();

            // Set images directory
            HtmlFixedSaveOptions opt = new HtmlFixedSaveOptions()
            {
                ImagesDirectoryPath = Path.Combine(imgDir, "Result_images"),
                ImagesDirectorySrcPath = "Result_images",
                // Change to store images as physical files on local drive.
                EmbedImages = false
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