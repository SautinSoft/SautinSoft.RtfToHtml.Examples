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
		''' Convert DOCX bytes to HTML file.
		''' </summary>
		Private Shared Sub ConvertDocxToHtml()
			' This file is necessary to get DOCX content as byte array.
			Dim inpFile As String = "..\..\..\..\example.docx"
			Dim docxBytes() As Byte = File.ReadAllBytes(inpFile)

			Dim outfile As String = Path.GetFullPath("Result.html")

			Dim r As New RtfToHtml()

			Using inpMS As New MemoryStream(docxBytes)
				Using outMS As New MemoryStream()
					r.Convert(inpMS, outMS, New HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})
					File.WriteAllBytes(outfile, outMS.ToArray())
				End Using
			End Using

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outfile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
