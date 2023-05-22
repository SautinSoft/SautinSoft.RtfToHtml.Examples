Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ListExportMode()
		End Sub
		''' <summary>
		''' This sample shows how to specify list export mode.
		''' </summary>
		Private Shared Sub ListExportMode()
			Dim inpFile As String = "..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			' Use <p> tags for list elements.
			Dim opt As New HtmlFlowingSaveOptions() With {.ListExportMode = HtmlListExportMode.AsInlineText}

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
