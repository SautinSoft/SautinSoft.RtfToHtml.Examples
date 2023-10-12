Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			PageIndexAndCount()
		End Sub
		''' <summary>
		''' Let's convert 1st and 3rd pages.
		''' </summary>
		Private Shared Sub PageIndexAndCount()
			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			' Let's convert pages: 1, 3.
			Dim opt As New HtmlFixedSaveOptions() With {
				.Title = "Pages 1, 3",
				.SelectedPages = New Integer() {0, 2}
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
