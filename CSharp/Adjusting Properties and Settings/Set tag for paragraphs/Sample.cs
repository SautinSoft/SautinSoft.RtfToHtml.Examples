using System;
using System.IO;
using System.Text;

namespace Sample
{
    class sample
    {
        static void Main(string[] args)
        {
            string inpFile = @"..\..\two paragraphs.rtf";
            string outFileTagP = @"p.html";
            string outFileTagDiv = @"div.html";

            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();            

            try
            {
                r.OpenRtf(inpFile);

                // Set tag <p>...</p> for the paragraphs.
                r.TagStyle.ParagraphTag = SautinSoft.RtfToHtml.eTags.p;
                r.TextStyle.Title = "P tag";
                r.ToHtml(outFileTagP);

                // Set tag <div>...</div> for the paragraphs.
                r.TagStyle.ParagraphTag = SautinSoft.RtfToHtml.eTags.div;
                r.TextStyle.Title = "DIV tag";
                r.ToHtml(outFileTagDiv);

                // Open the results for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileTagP)
                { UseShellExecute = true });
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFileTagDiv)
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
