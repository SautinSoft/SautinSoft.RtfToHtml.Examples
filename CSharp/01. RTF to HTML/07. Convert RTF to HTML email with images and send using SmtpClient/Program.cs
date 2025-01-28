using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using SkiaSharp;
using System.Net.Mime;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string rtfFile = Path.GetFullPath(@"..\..\..\Images.rtf");

            // 1. Convert RTF to HTML and place all images to list
            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
            SautinSoft.RtfToHtml.HtmlFixedSaveOptions opt = new SautinSoft.RtfToHtml.HtmlFixedSaveOptions
            {
                EmbedImages = false,
                ImagesDirectoryPath = Path.GetFullPath(@"..\..\..\Images"),
                ImagesDirectorySrcPath = Path.GetFullPath(@"..\..\..\Images")
            };
            string[] imageList = Directory.GetFiles(@"..\..\..\Images");

            // 2. After launching this method we'll get our RTF document in HTML format
            string htmlFile = Path.GetFullPath(@"..\..\..\Result.html");
            r.Convert(rtfFile, htmlFile, opt);

            // 3. Create Smtp client
            string userName = "bobuser";
            string userPassword = "bobpassword";
            string host = "smtp.bobsite.com";
            int port = 587;

            SmtpClient client = new SmtpClient(host, port)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(userName, userPassword)
            };

            // 4. Create HTML email
            string from = "bob@bobsite.com";
            string to = "john@johnsite.com";
            string subject = "This is a testing email from Bob to John using SmtpClient";

            MailMessage emailMessage = new MailMessage
            {
                From = new MailAddress(from),
                Body = "Testing email",
                IsBodyHtml = true,
                Subject = subject.Replace("\r\n", "")
            };

            emailMessage.To.Add(to);

            // 5. Attach images to email
            AlternateView altView = AlternateView.CreateAlternateViewFromString(htmlFile, null, "text/html");

            foreach (string imgPath in imageList)
            {
                using (var inputStream = File.OpenRead(imgPath))
                {
                    using (var skBitmap = SKBitmap.Decode(inputStream))
                    {
                        if (skBitmap != null)
                        {
                            var ms = new MemoryStream();
                            using (var skImage = SKImage.FromBitmap(skBitmap))
                            using (var data = skImage.Encode(SKEncodedImageFormat.Png, 100))
                            {
                                data.SaveTo(ms);
                            }

                            ms.Position = 0;

                            var lr = new LinkedResource(ms)
                            {
                                ContentType = new ContentType("image/png"),
                                ContentId = Guid.NewGuid().ToString()
                            };

                            altView.LinkedResources.Add(lr);
                        }
                    }
                }
            }
            emailMessage.AlternateViews.Add(altView);

            // 6. Send the message using email account

            //client.UseDefaultCredentials = false;

            // Some smtp servers doesn't require credentials, therefore
            // you may set: client.UseDefaultCredentials = false;
            // and remove the line: client.Credentials = new NetworkCredential(userName, userPassword);

            // In the real example in case of the correct host, uncomment the line below:
            //client.Send(emailMessage);
            Console.WriteLine("The message has been sent!");
        }
    }
}

