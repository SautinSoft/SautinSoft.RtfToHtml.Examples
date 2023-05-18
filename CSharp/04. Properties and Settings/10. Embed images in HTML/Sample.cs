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
            EmbedImages();
        }
        /// <summary>
        /// How to embed images inside HTML document using base64.
        /// </summary>
        static void EmbedImages()
        {
            // Here we'll convert to two HTML documents:
            // 1. HTML-document which have linked images.
            // 2. HTML-document with embedded images.

            string inpFile = @"..\..\..\..\example.docx";
            string htmlFileNonEmbeddedImg = Path.GetFullPath(@"NonEmbedded.html");
            string imgDir = Path.GetDirectoryName(htmlFileNonEmbeddedImg);

            string htmlFileEmbeddedImg = Path.GetFullPath(@"Embedded.html");

            RtfToHtml r = new RtfToHtml();


            // 1. Convert to HTML with linked images.
            HtmlFixedSaveOptions opt = new HtmlFixedSaveOptions()
            {
                ImagesDirectoryPath = Path.Combine(imgDir, "Result_images"),
                ImagesDirectorySrcPath = "Result_images",
                // Change to store images as physical files on local drive.
                EmbedImages = false,
                Title = "HTML with linked images."
            };
            try
            {
                r.Convert(inpFile, htmlFileNonEmbeddedImg, opt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed! {ex.Message}");
            }

            // 2. Convert to HTML with embedded images.
            opt.EmbedImages = true;
            opt.Title = "HTML with embedded images";
            try
            {
                r.Convert(inpFile, htmlFileEmbeddedImg, opt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed! {ex.Message}");
            }

            // Open the results.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFileNonEmbeddedImg) { UseShellExecute = true });
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFileEmbeddedImg) { UseShellExecute = true });
        }
    }
}