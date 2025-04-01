Option Infer On

Imports SkiaSharp
Imports SautinSoft
Imports System.IO

Namespace SautinSoft
    Friend Class SaveImage
        Implements RtfToHtml.IHtmlImageSavingCallback

        Public Images As New Dictionary(Of String, Byte())()

        Public Sub ImageSaving(args As RtfToHtml.HtmlImageSavingArgs) Implements RtfToHtml.IHtmlImageSavingCallback.ImageSaving
            If Not Images.ContainsKey(args.ImageFileName) Then
                Dim bitmap As SKBitmap = SKBitmap.Decode(args.ImageStream)
                Dim ms = New MemoryStream()
                bitmap.Encode(ms, SKEncodedImageFormat.Png, 100)
                ms.Position = 0
                Images.Add(args.ImageFileName, ms.ToArray())
            End If
        End Sub
    End Class

    Friend Class SaveFont
        Implements RtfToHtml.IHtmlFontSavingCallback

        Public Fonts As New Dictionary(Of String, Byte())()

        Public Sub FontSaving(args As RtfToHtml.HtmlFontSavingArgs) Implements RtfToHtml.IHtmlFontSavingCallback.FontSaving
            If Not Fonts.ContainsKey(args.FontFileName) Then
                Dim ms = New MemoryStream()
                args.FontStream.CopyTo(ms)
                ms.Position = 0
                Fonts.Add(args.FontFileName, ms.ToArray())
            End If
        End Sub
    End Class

    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            ' Get your free trial key here:   
            ' https://sautinsoft.com/start-for-free/

            Convert()
        End Sub

        ''' <summary>
        ''' Creates a new Html document using custom fonts in the source document 
        ''' and placing fonts and images in separate folders.
        ''' </summary>
        ''' <remarks>
        ''' Details: 
        ''' </remarks>
        Public Shared Sub Convert()
            Dim inpFile As String = "..\..\..\text.docx"
            Dim outFile As String = Path.ChangeExtension(inpFile, ".html")
            Dim rth = New RtfToHtml()
            Dim a = New RtfToHtml.HtmlFixedSaveOptions()
            a.FontsDirectoryPath = Path.GetDirectoryName(outFile) & "\fonts"
            a.ImagesDirectoryPath = Path.GetDirectoryName(outFile) & "\images"
            a.ImageSavingCallback = New SaveImage()
            a.FontSavingCallback = New SaveFont()
            Dim ms = New MemoryStream()
            Dim inp = File.OpenRead(inpFile)
            rth.Convert(inp, ms, a)
            Dim images = (TryCast(a.ImageSavingCallback, SaveImage)).Images
            Dim fonts = (TryCast(a.FontSavingCallback, SaveFont)).Fonts
            ms.Position = 0
            File.WriteAllBytes(outFile, ms.ToArray())
            For Each image In images
                If Not Directory.Exists(a.ImagesDirectoryPath) Then
                    Directory.CreateDirectory(a.ImagesDirectoryPath)
                End If
                File.WriteAllBytes(a.ImagesDirectoryPath & "\" & image.Key & ".png", image.Value)
            Next image
            For Each font In fonts
                If Not Directory.Exists(a.FontsDirectoryPath) Then
                    Directory.CreateDirectory(a.FontsDirectoryPath)
                End If
                File.WriteAllBytes(a.FontsDirectoryPath & "\" & font.Key & ".ttf", font.Value)
            Next font
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
        End Sub
    End Class
End Namespace
