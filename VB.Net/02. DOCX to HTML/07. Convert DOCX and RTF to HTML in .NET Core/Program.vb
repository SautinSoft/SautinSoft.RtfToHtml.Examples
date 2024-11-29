Imports System

Namespace Sample
	Friend Class Sample
		Public Shared Sub Main(ByVal args() As String)
			Dim r As New SautinSoft.RtfToHtml()

			Dim inpFile1 As String = "..\..\..\example.rtf"
			Dim inpFile2 As String = "..\..\..\example.docx"
			Dim outFile1 As String = "Result RTF.html"
			Dim outFile2 As String = "Result DOCX.html"

			Dim opt1 As New SautinSoft.RtfToHtml.HtmlFixedSaveOptions() With {
				.Title = "Produced from RTF.",
				.EmbedImages = True
			}
			Dim opt2 As New SautinSoft.RtfToHtml.HtmlFixedSaveOptions() With {
				.Title = "Produced from DOCX.",
				.EmbedImages = True
			}

			Try
				r.Convert(inpFile1, outFile1, opt1)
				r.Convert(inpFile2, outFile2, opt2)

				' Open the results for demonstration purposes.
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile1) With {.UseShellExecute = True})

				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile2) With {.UseShellExecute = True})

			Catch e As Exception
				Console.WriteLine($"Error: {e.Message}")
				Console.WriteLine("Press any key ...")
				Console.ReadKey()
			End Try
		End Sub
	End Class
End Namespace
