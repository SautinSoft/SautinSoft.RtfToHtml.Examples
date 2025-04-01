
using SkiaSharp;

namespace SautinSoft
{
    class SaveImage : RtfToHtml.IHtmlImageSavingCallback
    {
        public Dictionary<string, byte[]> Images = new Dictionary<string, byte[]>();

        public void ImageSaving(RtfToHtml.HtmlImageSavingArgs args)
        {
            if (!Images.ContainsKey(args.ImageFileName))
            {
                SKBitmap bitmap = SKBitmap.Decode(args.ImageStream);
                var ms = new MemoryStream();
                bitmap.Encode(ms, SKEncodedImageFormat.Png, 100);
                ms.Position = 0;
                Images.Add(args.ImageFileName, ms.ToArray());
            }
        }
    }

    class SaveFont : RtfToHtml.IHtmlFontSavingCallback
    {
        public Dictionary<string, byte[]> Fonts = new Dictionary<string, byte[]>();

        public void FontSaving(RtfToHtml.HtmlFontSavingArgs args)
        {
            if (!Fonts.ContainsKey(args.FontFileName))
            {
                var ms = new MemoryStream();
                args.FontStream.CopyTo(ms);
                ms.Position = 0;
                Fonts.Add(args.FontFileName, ms.ToArray());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get your free trial key here:   
            // https://sautinsoft.com/start-for-free/

            Convert();
        }

        /// <summary>
        /// Creates a new Html document using custom fonts in the source document 
        /// and placing fonts and images in separate folders.
        /// </summary>
        /// <remarks>
        /// Details: 
        /// </remarks>
        public static void Convert()
        {
            string inpFile = @"..\..\..\text.docx";
            string outFile = Path.ChangeExtension(inpFile, ".html");
            var rth = new RtfToHtml();
            var a = new RtfToHtml.HtmlFixedSaveOptions();
            a.FontsDirectoryPath = Path.GetDirectoryName(outFile) + "\\fonts";
            a.ImagesDirectoryPath = Path.GetDirectoryName(outFile) + "\\images";
            a.ImageSavingCallback = new SaveImage();
            a.FontSavingCallback = new SaveFont();
            var ms = new MemoryStream();
            var inp = File.OpenRead(inpFile);
            rth.Convert(inp, ms, a);
            var images = (a.ImageSavingCallback as SaveImage).Images;
            var fonts = (a.FontSavingCallback as SaveFont).Fonts;
            ms.Position = 0;
            File.WriteAllBytes(outFile, ms.ToArray());
            foreach (var image in images)
            {
                if (!Directory.Exists(a.ImagesDirectoryPath)) Directory.CreateDirectory(a.ImagesDirectoryPath);
                File.WriteAllBytes(a.ImagesDirectoryPath + "\\" + image.Key + ".png", image.Value);
            }
            foreach (var font in fonts)
            {
                if (!Directory.Exists(a.FontsDirectoryPath)) Directory.CreateDirectory(a.FontsDirectoryPath);
                File.WriteAllBytes(a.FontsDirectoryPath + "\\" + font.Key + ".ttf", font.Value);
            }
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
        }
    }
}