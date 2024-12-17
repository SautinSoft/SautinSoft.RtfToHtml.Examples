using System;
using System.IO;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SautinSoft;
using System.IO.Compression;

class Program
{
    static void Main()
    {
       
            RtfToHtml r = new RtfToHtml();
            r.Convert("test.docx", "test.html", new RtfToHtml.HtmlFixedSaveOptions() { Title = "SautinSoft Example." });
    }
}