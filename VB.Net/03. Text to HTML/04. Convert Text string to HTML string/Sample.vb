Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertTextToHtml()
		End Sub
		''' <summary>
		''' Converts Text string to HTML string.
		''' </summary>
		Private Shared Sub ConvertTextToHtml()
			Dim inpFile As String = "..\..\..\example.txt"
			Dim rtfString As String = File.ReadAllText(inpFile)
			Dim htmlString As String = String.Empty

			Dim r As New RtfToHtml()

			Using inpMS As New MemoryStream(Encoding.UTF8.GetBytes(rtfString))
				Using outMS As New MemoryStream()
					r.Convert(inpMS, outMS, New HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})
					htmlString = Encoding.UTF8.GetString(outMS.ToArray())
				End Using
			End Using

			' This file is necessary only to show the result.
			Dim outfile As String = Path.GetFullPath("Result.html")
			File.WriteAllText(outfile, htmlString)

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outfile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
