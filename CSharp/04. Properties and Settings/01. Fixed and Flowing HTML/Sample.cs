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
            FixedAndFlowingHtml();
        }
        /// <summary>
        /// This sample shows difference between Fixed-HTML and Flowing-HTML.
        /// </summary>
        static void FixedAndFlowingHtml()
        {
			// Get your free 100-day key here:   
            // https://sautinsoft.com/start-for-free/
			
            // If you need more information about "RTF to HTML .Net" 
            // Email us at: support@sautinsoft.com.
			
            // This file is necessary to get DOCX content as byte array.
            string inpFile = @"..\..\..\example.docx";
            string htmlFixedFile = @"Fixed.html";
            string htmlFlowingFile = @"Flowing.html";

            RtfToHtml r = new RtfToHtml();

            // 1. Convert to HTML-fixed.
            // The HTML in the fixed mode represents HTML document with pages and elements positioned by (x,y).
            try
            {
                r.Convert(inpFile, htmlFixedFile, new RtfToHtml.HtmlFixedSaveOptions() { Title = "Fixed", PageMargins = 20f });
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
                r.Convert(inpFile, htmlFlowingFile, new RtfToHtml.HtmlFlowingSaveOptions() { Title = "Flowing"});
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