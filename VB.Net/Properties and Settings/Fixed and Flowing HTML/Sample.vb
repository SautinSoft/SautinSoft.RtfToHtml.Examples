Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports SautinSoft.RtfToHtml

Namespace Example
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			FixedAndFlowingHtml()
		End Sub
		''' <summary>
		''' This sample shows difference between Fixed-HTML and Flowing-HTML.
		''' </summary>
		Private Shared Sub FixedAndFlowingHtml()
			' This file is necessary to get DOCX content as byte array.
			Dim inpFile As String = "..\..\..\example.docx"
			Dim htmlFixedFile As String = "Fixed.html"
			Dim htmlFlowingFile As String = "Flowing.html"

			Dim r As New RtfToHtml()

			' 1. Convert to HTML-fixed.
			' The HTML in the fixed mode represents HTML document with pages and elements positioned by (x,y).
			Try
				r.Convert(inpFile, htmlFixedFile, New HtmlFixedSaveOptions() With {
					.Title = "Fixed",
					.PageMargins = 20F
				})
			Catch ex As Exception
				Console.WriteLine($"Conversion failed! {ex.Message}")
			End Try

			' 2. Convert to HTML-Flowing.
			' The HTML in the flowing mode represents HTML document like a created by a human
			' extended by a whole browser width.
			Try
				r.Convert(inpFile, htmlFlowingFile, New HtmlFlowingSaveOptions() With {.Title = "Flowing"})
			Catch ex As Exception
				Console.WriteLine($"Conversion failed! {ex.Message}")
			End Try


			' Open the results.
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFixedFile) With {.UseShellExecute = True})
			System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(htmlFlowingFile) With {.UseShellExecute = True})
		End Sub
	End Class
End Namespace
