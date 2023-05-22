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
            FixedAndFlowingHtml();
        }
        /// <summary>
        /// This sample shows difference between Fixed-HTML and Flowing-HTML.
        /// </summary>
        static void FixedAndFlowingHtml()
        {
            // This file is necessary to get DOCX content as byte array.
            string inpFile = @"..\..\example.docx";
            string htmlFixedFile = @"Fixed.html";
            string htmlFlowingFile = @"Flowing.html";

            RtfToHtml r = new RtfToHtml();

            // 1. Convert to HTML-fixed.
            // The HTML in the fixed mode represents HTML document with pages and elements positioned by (x,y).
            try
            {
                r.Convert(inpFile, htmlFixedFile, new HtmlFixedSaveOptions() { Title = "Fixed", PageMargins = 20f });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed! {ex.Message}");
            }

            // 2. Convert to HTML-Flowing.
            // The HTML in the flowing mode represents HTML document like a created by a human
            // extended by a whole browser width.
            try
            {
                r.Convert(inpFile, htmlFlowingFile, new HtmlFlowingSaveOptions() { Title = "Flowing"});
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed! {ex.Message}");
            }


            // Open the results.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFixedFile) { UseShellExecute = true });
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(htmlFlowingFile) { UseShellExecute = true });
        }
    }
}