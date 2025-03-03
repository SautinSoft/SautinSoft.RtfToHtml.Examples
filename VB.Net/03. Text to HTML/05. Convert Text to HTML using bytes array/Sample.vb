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
        ''' Convert Text to HTML using bytes array.
        ''' </summary>
        Private Shared Sub ConvertTextToHtml()
				    ' Get your free key here:   
            ' https://sautinsoft.com/start-for-free/
			
            ' If you need more information about "RTF to HTML .Net" 
            ' Email us at: support@sautinsoft.com.
            ' The files are necessary only to get input data and show the result.
            Dim inpFile As String = "..\..\..\example.txt"
            Dim outfile As String = Path.GetFullPath("Result.html")


            Dim rtfBytes() As Byte = File.ReadAllBytes(inpFile)
            Dim htmlBytes() As Byte = Nothing

            Dim r As New RtfToHtml()

            Using inpMS As New MemoryStream(rtfBytes)
                Using outMS As New MemoryStream()
                    r.Convert(inpMS, outMS, new RtfToHtml.HtmlFixedSaveOptions() With {.Title = "SautinSoft Example."})
                    htmlBytes = outMS.ToArray()
                End Using
            End Using

            File.WriteAllBytes(outfile, htmlBytes)

            ' Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outfile) With {.UseShellExecute = True})
        End Sub
    End Class
End Namespace
