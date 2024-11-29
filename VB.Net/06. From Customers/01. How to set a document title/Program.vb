Imports System
Imports System.IO
Imports System.Text

Namespace Sample
	Friend Class Sample
		Shared Sub Main(ByVal args() As String)
			Dim inpFile As String = "..\..\..\Images.rtf"
			Dim outFile As String = "..\..\..\Title.html"

			Dim r As New SautinSoft.RtfToHtml()
			Dim opt As New SautinSoft.RtfToHtml.HtmlFixedSaveOptions With {
				.Title = "Here is the custom TITLE!",
				.EmbedImages = False,
				.ImagesDirectoryPath = "..\..\..\Images",
				.ImagesDirectorySrcPath = "Images"
			}

			Try
				r.Convert(inpFile, outFile, opt)

				' Open the results for demonstration purposes.
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch e As Exception
				Console.WriteLine($"Error: {e.Message}")
				Console.WriteLine("Press any key ...")
				Console.ReadKey()
			End Try
		End Sub
	End Class
End Namespace
