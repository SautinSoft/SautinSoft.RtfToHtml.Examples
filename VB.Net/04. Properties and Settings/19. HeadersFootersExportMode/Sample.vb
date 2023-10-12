Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			HeadersFootersExportMode()
		End Sub
		''' <summary>
		''' This sample shows how to export headers and footers.
		''' </summary>
		Private Shared Sub HeadersFootersExportMode()
			Dim inpFile As String = "..\..\..\doc with header and footer.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			Dim opt As New HtmlFlowingSaveOptions() With {.HeadersFootersExportMode = HtmlHeadersFootersExportMode.FirstSectionHeaderLastSectionFooter}

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
