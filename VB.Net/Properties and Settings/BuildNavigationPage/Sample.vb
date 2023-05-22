Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			BuildNavigationPage()
		End Sub
		''' <summary>
		''' This sample shows how to generate a navigation page (like a TOC - table of contents).
		''' </summary>
		Private Shared Sub BuildNavigationPage()
			Dim inpFile As String = "..\toc.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			Dim opt As New HtmlFlowingSaveOptions() With {.BuildNavigationPage = True}

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
