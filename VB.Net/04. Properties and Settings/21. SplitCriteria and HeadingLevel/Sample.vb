Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SplitCriteria()
		End Sub
		''' <summary>
		''' Specifies how the document should be split when saving to Html format.
		''' </summary>
		Private Shared Sub SplitCriteria()
			Dim inpFile As String = "..\..\..\toc.docx"
			Dim outFile As String = "toc.html"

			Dim r As New RtfToHtml()

			Dim opt As New RtfToHtml.HtmlFlowingSaveOptions() With {
				.SplitCriteria = RtfToHtml.HtmlSplitCriteria.PageBreak,
				.SplitHeadingLevel = 2
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
