Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			PageMargins()
		End Sub
		''' <summary>
		''' Set page custom margins.
		''' </summary>
		Private Shared Sub PageMargins()
			Dim inpFile As String = "..\..\..\..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			' Set page margins 30 mm.
			Dim opt As New HtmlFixedSaveOptions() With {
				.Title = "Page Margins 30 mm",
				.PageMargins = LengthUnitConverter.Convert(30, LengthUnit.Millimeter, LengthUnit.Point)
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
