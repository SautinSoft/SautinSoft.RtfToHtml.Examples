Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SetSingleFontSize()
		End Sub
		''' <summary>
		''' How to convert to HTML document and set single font size a whole text.
		''' </summary>
		Private Shared Sub SetSingleFontSize()
				    ' Get your free 100-day key here:   
            ' https://sautinsoft.com/start-for-free/
			
            ' If you need more information about "RTF to HTML .Net" 
            ' Email us at: support@sautinsoft.com.
			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			Dim opt As New RtfToHtml.HtmlFlowingSaveOptions() With {
				.Title = "12 pt",
				.SingleFontSize = 12F
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
