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
            UsingImagesSavingCallback();
        }
        /// <summary>
        /// How to use image saving callback and set a template name for all images.
        /// </summary>
        static void UsingImagesSavingCallback()
        {
            string inpFile = @"..\..\..\example.docx";
            string outFile = Path.GetFullPath(@"Result.html");
            string imgDir = Path.GetDirectoryName(outFile);

            RtfToHtml r = new RtfToHtml();

            // Set images directory
            HtmlFixedSaveOptions opt = new HtmlFixedSaveOptions()
            {
                ImagesDirectoryPath = Path.Combine(imgDir, "Result_images"),
                ImagesDirectorySrcPath = "Result_images",
                // Change to store images as physical files on local drive.
                EmbedImages = false,
                ImageSavingCallback = new SaveImagesOpt() { TemplateImageName = "MyPicture"}
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
    public class SaveImagesOpt : IHtmlImageSavingCallback
    {
        public string TemplateImageName { get; set; } = "picture";
        public void ImageSaving(SautinSoft.Document.HtmlImageSavingArgs args)
        {
            args.ImageFileName = args.ImageFileName.Replace("image", TemplateImageName);
        }
    }
}