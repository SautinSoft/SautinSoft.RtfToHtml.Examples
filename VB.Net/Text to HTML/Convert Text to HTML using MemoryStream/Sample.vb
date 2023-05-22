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
        ''' Converts Text to HTML using MemoryStream objects.
        ''' </summary>
        Private Shared Sub ConvertTextToHtml()
			' The files are necessary only to get input data and show the result.
			Dim inpFile As String = "..\example.txt"
			Dim outfile As String = Path.GetFullPath("Result.html")

			Dim r As New RtfToHtml()

			Using inpMS As New MemoryStream(File.ReadAllBytes(inpFile))
				Using outMS As New MemoryStream()
					r.Convert(inpMS, outMS, New HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})
					' Save the result from MemoryStream to the file to show the result.
					File.WriteAllBytes(outfile, outMS.ToArray())
				End Using
			End Using

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outfile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
