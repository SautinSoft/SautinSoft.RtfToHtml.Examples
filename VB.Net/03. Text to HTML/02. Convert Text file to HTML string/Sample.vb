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
		''' Converts Text file to HTML string.
		''' </summary>
		Private Shared Sub ConvertTextToHtml()
			Dim inpFile As String = "..\..\..\example.txt"
			Dim htmlString As String = String.Empty

			Dim r As New RtfToHtml()

			Using inpReader As New StreamReader(inpFile)
				Using resultStream As New MemoryStream()
					r.Convert(inpReader.BaseStream, resultStream, new RtfToHtml.HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})
					htmlString = Encoding.UTF8.GetString(resultStream.ToArray())
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
