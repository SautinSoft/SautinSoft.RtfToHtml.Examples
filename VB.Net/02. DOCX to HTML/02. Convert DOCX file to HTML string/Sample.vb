Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertDocxToHtml()
		End Sub
		''' <summary>
		''' Convert DOCX file to HTML string.
		''' </summary>
		Private Shared Sub ConvertDocxToHtml()
				    ' Get your free key here:   
            ' https://sautinsoft.com/start-for-free/
			
            ' If you need more information about "RTF to HTML .Net" 
            ' Email us at: support@sautinsoft.com.
			Dim inpFile As String = "..\..\..\example.docx"
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
