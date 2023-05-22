Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertRtfToHtml()
		End Sub
		''' <summary>
		''' Converts RTF string to HTML file.
		''' </summary>
		Private Shared Sub ConvertRtfToHtml()
			' This file is necessary to get RTF content as string.
			Dim inpFile As String = "..\example.rtf"
			Dim rtfString As String = File.ReadAllText(inpFile)

			Dim outfile As String = Path.GetFullPath("Result.html")

			Dim r As New RtfToHtml()

			Using inpMs As New MemoryStream(Encoding.UTF8.GetBytes(rtfString))
				Using resMs As New MemoryStream()
					r.Convert(inpMs, resMs, New HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})
					File.WriteAllBytes(outfile, resMs.ToArray())
				End Using
			End Using

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outfile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
