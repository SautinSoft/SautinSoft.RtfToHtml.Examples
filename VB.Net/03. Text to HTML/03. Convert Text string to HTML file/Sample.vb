Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertTextToHtml()
		End Sub
		''' <summary>
		''' Converts Text string to HTML file.
		''' </summary>
		Private Shared Sub ConvertTextToHtml()
			' This file is necessary to get Text content as string.
			Dim inpFile As String = "..\..\..\example.txt"
			Dim rtfString As String = File.ReadAllText(inpFile)

			Dim outfile As String = Path.GetFullPath("Result.html")

			Dim r As New RtfToHtml()

			Using inpMs As New MemoryStream(Encoding.UTF8.GetBytes(rtfString))
				Using resMs As New MemoryStream()
					r.Convert(inpMs, resMs, new RtfToHtml.HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})
					File.WriteAllBytes(outfile, resMs.ToArray())
				End Using
			End Using

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outfile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
