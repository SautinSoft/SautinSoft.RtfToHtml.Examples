Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            EmbedImages()
        End Sub
        ''' <summary>
        ''' How to embed images inside HTML document using base64.
        ''' </summary>
        Private Shared Sub EmbedImages()
            ' Here we'll convert to two HTML documents:
            ' 1. HTML-document which have linked images.
            ' 2. HTML-document with embedded images.

            Dim inpFile As String = "..\..\..\..\example.docx"
            Dim htmlFileNonEmbeddedImg As String = Path.GetFullPath("NonEmbedded.html")
            Dim imgDir As String = Path.GetDirectoryName(htmlFileNonEmbeddedImg)

            Dim htmlFileEmbeddedImg As String = Path.GetFullPath("Embedded.html")

            Dim r As New RtfToHtml()


            ' 1. Convert to HTML with linked images.
            Dim opt As New HtmlFixedSaveOptions() With {
                .ImagesDirectoryPath = Path.Combine(imgDir, "Result_images"),
                .ImagesDirectorySrcPath = "Result_images",
                .EmbedImages = False,
                .Title = "HTML with linked images."
            }
            Try
                r.Convert(inpFile, htmlFileNonEmbeddedImg, opt)
            Catch ex As Exception
                Console.WriteLine($"Conversion failed! {ex.Message}")
            End Try

            ' 2. Convert to HTML with embedded images.
            opt.EmbedImages = True
            opt.Title = "HTML with embedded images"
            Try
                r.Convert(inpFile, htmlFileEmbeddedImg, opt)
            Catch ex As Exception
                Console.WriteLine($"Conversion failed! {ex.Message}")
            End Try

            ' Open the results.
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFileNonEmbeddedImg) With {.UseShellExecute = True})
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFileEmbeddedImg) With {.UseShellExecute = True})
        End Sub
    End Class
End Namespace
