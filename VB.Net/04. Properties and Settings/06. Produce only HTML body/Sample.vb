Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ProduceOnlyHtmlBody()
		End Sub
        ''' <summary>
        ''' How to produce HTML document only between &lt;body&gt;...&lt;/body&gt; tags.
        ''' </summary>
        Private Shared Sub ProduceOnlyHtmlBody()
				    ' Get your free 100-day key here:   
            ' https://sautinsoft.com/start-for-free/
			
            ' If you need more information about "RTF to HTML .Net" 
            ' Email us at: support@sautinsoft.com.
			Dim inpFile As String = "..\..\..\example.docx"
			Dim outFile As String = "Result.html"

			Dim r As New RtfToHtml()

			' Set properties to produce HTML document only
			' between &lt;body&gt;...&lt;/body&gt; tags
			Dim opt As New RtfToHtml.HtmlFlowingSaveOptions() With {
				.ProduceOnlyHtmlBody = True
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
