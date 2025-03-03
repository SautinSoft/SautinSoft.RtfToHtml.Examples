Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SetImagesFormat()
		End Sub
		''' <summary>
		''' How to set images format.
		''' </summary>
		Private Shared Sub SetImagesFormat()
		
				    ' Get your free key here:   
            ' https://sautinsoft.com/start-for-free/
			
            ' If you need more information about "RTF to HTML .Net" 
            ' Email us at: support@sautinsoft.com.
			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = Path.GetFullPath("Result.html")
			Dim imgDir As String = Path.GetDirectoryName(outFile)

			Dim r As New RtfToHtml()

			' 1. Set PNG format.
			Dim opt As New RtfToHtml.HtmlFixedSaveOptions() With {
				.ImagesDirectoryPath = Path.Combine(imgDir, "Result_images"),
				.ImagesDirectorySrcPath = "Result_images",
				.EmbedImages = False,
				.ImageFormat = RtfToHtml.HtmlSaveOptions.ImagesFormat.Png,
				.Title = "HTML document, PNG images"
			}
			Try
				r.Convert(inpFile, outFile, opt)
			Catch ex As Exception
				Console.WriteLine($"Conversion failed! {ex.Message}")
			End Try

			' Open the result.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
