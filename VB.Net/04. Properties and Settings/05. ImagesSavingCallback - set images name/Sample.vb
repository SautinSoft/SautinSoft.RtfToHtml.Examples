Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			UsingImagesSavingCallback()
		End Sub
		''' <summary>
		''' How to use image saving callback and set a template name for all images.
		''' </summary>
		Private Shared Sub UsingImagesSavingCallback()
			Dim inpFile As String = "..\..\..\..\example.docx"
			Dim outFile As String = Path.GetFullPath("Result.html")
			Dim imgDir As String = Path.GetDirectoryName(outFile)

			Dim r As New RtfToHtml()

			' Set images directory
			Dim opt As New HtmlFixedSaveOptions() With {
				.ImagesDirectoryPath = Path.Combine(imgDir, "Result_images"),
				.ImagesDirectorySrcPath = "Result_images",
				.EmbedImages = False,
				.ImageSavingCallback = New SaveImagesOpt() With {.TemplateImageName = "MyPicture"}
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
	Public Class SaveImagesOpt
        Implements SautinSoft.Document.IHtmlImageSavingCallback

        Public Property TemplateImageName() As String = "picture"

        Private Sub IHtmlImageSavingCallback_ImageSaving(args As SautinSoft.Document.HtmlImageSavingArgs) Implements SautinSoft.Document.IHtmlImageSavingCallback.ImageSaving
            args.ImageFileName = args.ImageFileName.Replace("image", TemplateImageName)
        End Sub
    End Class
End Namespace
