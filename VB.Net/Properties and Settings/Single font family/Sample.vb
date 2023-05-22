Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SetSingleFontFamily()
		End Sub
		''' <summary>
		''' How to convert to HTML document and set single font family a whole text.
		''' </summary>
		Private Shared Sub SetSingleFontFamily()
			Dim inpFile As String = "..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			Dim opt As New HtmlFlowingSaveOptions() With {
				.Title = "Single font Courier",
				.SingleFontFamily = "Courier"
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
