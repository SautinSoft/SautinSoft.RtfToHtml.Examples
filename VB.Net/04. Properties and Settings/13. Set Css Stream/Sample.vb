Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SetCssStream()
		End Sub
		''' <summary>
		''' This sample shows how to specify CSS Stream.
		''' </summary>
		Private Shared Sub SetCssStream()
			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = "Result.html"
			Dim cssFile As String = "Styles.css"

			Dim r As New RtfToHtml()

			' Create a separate file to store css.
			Dim fs As New FileStream(cssFile, FileMode.Create)

			Dim opt As New RtfToHtml.HtmlFlowingSaveOptions() With {
				.CssStream = fs,
				.KeepCssStreamOpen = False,
				.CssExportMode = RtfToHtml.CssExportMode.External,
				.CssFileName = cssFile,
				.Title = "Working with CSS."
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
