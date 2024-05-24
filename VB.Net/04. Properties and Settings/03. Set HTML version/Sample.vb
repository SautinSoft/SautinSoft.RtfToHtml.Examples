Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SetHtmlVersion()
		End Sub
		''' <summary>
		''' This sample shows how to set HTML version: xhtml, html5, html401, html32.
		''' </summary>
		Private Shared Sub SetHtmlVersion()
			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			' Let's convert to the HTML 3.2
			Dim opt As New RtfToHtml.HtmlFlowingSaveOptions() With {.Version = RtfToHtml.HtmlVersion.Html32}

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
