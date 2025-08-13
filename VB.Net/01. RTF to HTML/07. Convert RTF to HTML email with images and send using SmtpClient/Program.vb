Option Infer On

Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports SkiaSharp
Imports System.Net.Mime

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Dim rtfFile As String = Path.GetFullPath("..\..\..\Images.rtf")

			' 1. Convert RTF to HTML and place all images to list
			Dim r As New SautinSoft.RtfToHtml()
			Dim opt As New SautinSoft.RtfToHtml.HtmlFixedSaveOptions With {
				.EmbedImages = False,
				.ImagesDirectoryPath = Path.GetFullPath("..\..\..\Images"),
				.ImagesDirectorySrcPath = Path.GetFullPath("..\..\..\Images")
			}
			Dim imageList() As String = Directory.GetFiles("..\..\..\Images")

			' 2. After launching this method we'll get our RTF document in HTML format
			Dim htmlFile As String = Path.GetFullPath("..\..\..\Result.html")
			r.Convert(rtfFile, htmlFile, opt)

			' 3. Create Smtp client
			Dim userName As String = "bobuser"
			Dim userPassword As String = "bobpassword"
			Dim host As String = "smtp.bobsite.com"
			Dim port As Integer = 587

			Dim client As New SmtpClient(host, port) With {
				.EnableSsl = True,
				.DeliveryMethod = SmtpDeliveryMethod.Network,
				.Credentials = New NetworkCredential(userName, userPassword)
			}

			' 4. Create HTML email
			Dim from As String = "bob@bobsite.com"
			Dim [to] As String = "john@johnsite.com"
			Dim subject As String = "This is a testing email from Bob to John using SmtpClient"

			Dim emailMessage As New MailMessage With {
				.From = New MailAddress(from),
				.Body = "Testing email",
				.IsBodyHtml = True,
				.Subject = subject.Replace(vbCrLf, "")
			}

			emailMessage.To.Add([to])

			' 5. Attach images to email
			Dim altView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlFile, Nothing, "text/html")

			For Each imgPath As String In imageList
				Using inputStream = File.OpenRead(imgPath)
					Using skBitmap = SkiaSharp.SKBitmap.Decode(inputStream)
						If skBitmap IsNot Nothing Then
							Dim ms = New MemoryStream()
							Using skImage = SkiaSharp.SKImage.FromBitmap(skBitmap)
								Using data = skImage.Encode(SKEncodedImageFormat.Png, 100)
									data.SaveTo(ms)
								End Using
							End Using

							ms.Position = 0

							Dim lr = New LinkedResource(ms) With {
								.ContentType = New ContentType("image/png"),
								.ContentId = Guid.NewGuid().ToString()
							}

							altView.LinkedResources.Add(lr)
						End If
					End Using
				End Using
			Next imgPath
			emailMessage.AlternateViews.Add(altView)

			' 6. Send the message using email account

			'client.UseDefaultCredentials = false;

			' Some smtp servers doesn't require credentials, therefore
			' you may set: client.UseDefaultCredentials = false;
			' and remove the line: client.Credentials = new NetworkCredential(userName, userPassword);

			' In the real example in case of the correct host, uncomment the line below:
			'client.Send(emailMessage);
			Console.WriteLine("The message has been sent!")
		End Sub
	End Class
End Namespace
