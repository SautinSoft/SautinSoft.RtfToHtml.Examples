Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SetSingleFontColor()
		End Sub
		''' <summary>
		''' How to convert to HTML document and set single font color a whole text.
		''' </summary>
		Private Shared Sub SetSingleFontColor()
			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			Dim opt As New RtfToHtml.HtmlFixedSaveOptions() With {.SingleFontColor = New RtfToHtml.Color(34, 139, 39)}

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
