Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			UseNumericCharacterReference()
		End Sub
		''' <summary>
		''' This sample shows how to use Numeric Character Reference.
		''' </summary>
		Private Shared Sub UseNumericCharacterReference()
			Dim inpFile As String = "..\..\..\utf-8.rtf"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			Dim opt As New RtfToHtml.HtmlFlowingSaveOptions() With {
				.UseNumericCharacterReference = True,
				.Title = "UseNumericCharacterReference"
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
