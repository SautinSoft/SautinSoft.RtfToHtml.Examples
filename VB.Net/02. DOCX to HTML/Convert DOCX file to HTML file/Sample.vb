Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertDocxToHtml()
		End Sub
		''' <summary>
		''' Convert DOCX file to HTML file.
		''' </summary>
		Private Shared Sub ConvertDocxToHtml()
			Dim inpFile As String = "..\..\..\..\example.docx"
			Dim outfile As String = Path.GetFullPath("Result.html")

			Dim r As New RtfToHtml()
			r.Convert(inpFile, outfile, New HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outfile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
