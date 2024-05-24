Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Activation()
		End Sub
		''' <summary>
		''' How to activate SautinSoft.RtfToHtml component.
		''' </summary>
		Private Shared Sub Activation()
			' You will get own serial number after purchasing the license.
			' If you will have any questions, email us to sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.

			' Let us say, you have this key: 1234567890.            
			RtfToHtml.SetLicense("1234567890")
			' Activation of Rtf To Html .Net after purchasing.

			Dim r As New RtfToHtml()


			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = "Result.html"

			r.Convert(inpFile, outFile, new RtfToHtml.HtmlFixedSaveOptions() With {.Title = "SautinSoft.RtfToHtml Activation"})

			' Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
