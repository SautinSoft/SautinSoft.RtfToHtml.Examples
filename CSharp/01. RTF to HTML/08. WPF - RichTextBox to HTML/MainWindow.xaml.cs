using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace WPF___RichTextBox_to_HTML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string inpFile = @"..\..\..\example.rtf";
        public MainWindow()
        {
            InitializeComponent();

            // Insert RTF document into RichText Control.
            byte[] rtfBytes = File.ReadAllBytes(inpFile);

            using (MemoryStream ms = new MemoryStream(rtfBytes))
            {
                System.Windows.Documents.TextRange tr = new System.Windows.Documents.TextRange(
                   rtfControl.Document.ContentStart, rtfControl.Document.ContentEnd);
                tr.Load(ms, DataFormats.Rtf);
            }

        }
        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            // Get RTF from RichTextBox
            string rtfString = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                TextRange range = new TextRange(rtfControl.Document.ContentStart, rtfControl.Document.ContentEnd);
                range.Save(ms, DataFormats.Rtf);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    rtfString = sr.ReadToEnd();
                }
            }
            // Convert RTF to HTML using SautinSoft.RtfToHtml.dll            
            string outFile = "Result.html";
            string imgDir = Directory.GetCurrentDirectory();

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

            // Specify some properties for output HTML document.
            // 
            // EmbedImages
            // false - store images as files on HDD,
            // true - store images inside HTML document using base64.
            // 
            // ImagesDirectoryPath Sets the physical directory where all images will be saved.
            //
            // ImagesDirectorySrcPath Sets the relative directory that will be used when referencing images in the HTML.

            SautinSoft.RtfToHtml.HtmlFixedSaveOptions opt = new SautinSoft.RtfToHtml.HtmlFixedSaveOptions()
            {
                EmbedImages = false,
                ImagesDirectoryPath = Path.Combine(imgDir, "image.files"),
                ImagesDirectorySrcPath = "image.files"
            };

            try
            {
                r.Convert(inpFile, outFile, opt);
                // Open the result for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile)
                { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}

